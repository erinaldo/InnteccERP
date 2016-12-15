using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using Utilities;
using WinFormsApp.Properties;
using System.Speech.Synthesis;

namespace WinFormsApp
{
    public partial class ModuloClinica : RibbonForm
    {
        #region Socket

        // Client socket
        private Socket _clientSocket;

        // Client _name
        private string _name;

        // Server End Point
        private EndPoint _epServer;

        // Data stream
        private byte[] _dataStream = new byte[1024];

        // Display message delegate
        private delegate void DisplayMessageDelegate(string message);

        private DisplayMessageDelegate _displayMessageDelegate;
        public string NameUser { get; set; }
        public string ServerIp { get; set; }
        public bool AllowMessagesUdp { get; set; }

        public VwProgramacioncitadet VwProgramacioncitadetBusqueda { get; set; }
        #region Methods

        private void ConnectToServerUpd()
        {
            try
            {
                _name = NameUser;

                // Initialise a packet object to store the data to be sent
                Packet sendData = new Packet();
                sendData.ChatName = _name;
                sendData.ChatMessage = null;
                sendData.ChatDataIdentifier = DataIdentifier.LogIn;

                // Initialise socket
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise server IP
                IPAddress serverIp = IPAddress.Parse(ServerIp);

                // Initialise the IPEndPoint for the server and use port 30000
                IPEndPoint server = new IPEndPoint(serverIp, 30000);

                // Initialise the EndPoint for the server
                _epServer = server;

                // Get packet as byte array
                byte[] data = sendData.GetDataStream();

                // Send data to server
                _clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, _epServer, SendData, null);

                // Initialise data stream
                _dataStream = new byte[1024];

                // Begin listening for broadcasts
                _clientSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref _epServer, ReceiveData, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Connection Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayMessage(string message)
        {
            rtxtConversation.Text += message + Environment.NewLine;



            int indexMsg = message.LastIndexOf(":", StringComparison.Ordinal);
            if (indexMsg > 0)
            {
                int idprogramacioncitadet = Convert.ToInt32(message.Substring(indexMsg + 2));
                if (idprogramacioncitadet > 0)
                {                    
                    VwProgramacioncitadet vwProgramacioncitadet = Service.GetVwProgramacioncitadet(idprogramacioncitadet);
                    if (vwProgramacioncitadet != null && SessionApp.DateServer.Date == vwProgramacioncitadet.Fechaprogramacion.Date)
                    {
                        AlertarCitas(vwProgramacioncitadet);
                        BuscarProgramacionCitaVisor();
                    }
                }
            }
        }
        private void SendData(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Send Data: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReceiveData(IAsyncResult ar)
        {
            try
            {
                // Receive all data
                _clientSocket.EndReceive(ar);

                // Initialise a packet object to store the received data
                Packet receivedData = new Packet(_dataStream);

                // Update display through a delegate
                if (receivedData.ChatMessage != null)
                    Invoke(_displayMessageDelegate, receivedData.ChatMessage);

                // Reset data stream
                _dataStream = new byte[1024];

                // Continue listening for broadcasts
                _clientSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref _epServer, ReceiveData, null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(@"Receive Data: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SendMessage(string message)
        {
            if (AllowMessagesUdp)
            {
                try
                {
                    // Initialise a packet object to store the data to be sent
                    Packet sendData = new Packet
                    {
                        ChatName = _name,
                        ChatMessage = message,
                        ChatDataIdentifier = DataIdentifier.Message
                    };

                    // Get packet as byte array
                    byte[] byteData = sendData.GetDataStream();

                    // Send packet to the server
                    _clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, _epServer, SendData, null);

                    txtMessage.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Send Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AlertarCitas(VwProgramacioncitadet vwProgramacioncitadet)
        {
            if (vwProgramacioncitadet != null)
            {
                foreach (AlertForm form in AlertControlCita.AlertFormList)
                {
                    form.Close();
                }

                //string horaProgramacion = string.Format("{0}:{1}", vwProgramacioncitadet.Horaprogramacion.Hour, vwProgramacioncitadet.Horaprogramacion.Minute);
                //string message = string.Format("Paciente: {0}. Turno: {1}. Estado: {2}. Motivo: {3}", vwProgramacioncitadet.Razonsocialpaciente, horaProgramacion, vwProgramacioncitadet.Nombreestadocita, vwProgramacioncitadet.Nombremotivocita);
                //SpeechMessage(message);

                VwProgramacioncitadetBusqueda = vwProgramacioncitadet;
                AlertControlCita.Buttons["btnCita"].Visible = true;              
                AlertControlCita.AllowHotTrack = false;
                AlertControlCita.Show(FindForm()
                , "Información de cita"
                , string.Format("Paciente: {0}\nTurno: {1}\nEstado: {2}\nMotivo: {3}", vwProgramacioncitadet.Razonsocialpaciente, vwProgramacioncitadet.Horaprogramacion.ToString("t"), vwProgramacioncitadet.Nombreestadocita, vwProgramacioncitadet.Nombremotivocita)
                , string.Empty
                , Resources.date_time_32x32);                

            }
        }
        private void ModuloClinica_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_clientSocket != null)
                {
                    // Initialise a packet object to store the data to be sent
                    Packet sendData = new Packet();
                    sendData.ChatDataIdentifier = DataIdentifier.LogOut;
                    sendData.ChatName = _name;
                    sendData.ChatMessage = null;

                    // Get packet as byte array
                    byte[] byteData = sendData.GetDataStream();

                    // Send packet to the server
                    _clientSocket.SendTo(byteData, 0, byteData.Length, SocketFlags.None, _epServer);

                    // Close the socket
                    _clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Closing Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AlertControlCita_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            
            switch (e.ButtonName)
            {
                case "btnCita":
                    BuscarProgramacionCitaVisor();
                    break;
            }

        }
        private void ShowProgramacionCitaVisor()
        {
            //TODO: Descomentar
            ProgramacioncitaVisorFrm = ProgramacioncitaVisorFrm.GetInstance(this);
            ProgramacioncitaVisorFrm.MdiParent = this;
            ProgramacioncitaVisorFrm.Show();
        }
        private void BuscarProgramacionCitaVisor()
        {
            //TODO: Descomentar
            VwProgramacioncitadet vwProgramacioncitadetBusqueda = VwProgramacioncitadetBusqueda;
            ProgramacioncitaVisorFrm = ProgramacioncitaVisorFrm.GetInstance(this);
            ProgramacioncitaVisorFrm.MdiParent = this;
            ProgramacioncitaVisorFrm.Show();
            ProgramacioncitaVisorFrm.BuscarCita(vwProgramacioncitadetBusqueda);
        }

        #endregion

        #endregion

        #region Speech

        readonly SpeechSynthesizer _synthesizer;

        public void SpeechMessage(string message)
        {
            _synthesizer.SpeakAsync(message);
        }

        #endregion

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public List<VwGrupousuarioitem> GrupousuarioitemsPermisos { get; set; }

        List<Inventario> _inventarioList;

        public ProgramacioncitaVisorFrm ProgramacioncitaVisorFrm { get; set; }
        public ModuloClinica()
        {
            InitializeComponent();
            InitSkinGallery();

            AllowMessagesUdp = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("AllowMessagesUdp"));

            if (AllowMessagesUdp)
            {
                NameUser = string.Format("{0}-{1}", SystemInformation.ComputerName, SessionApp.UsuarioSel.Nombreusuario);
                ServerIp = ConfigurationManager.AppSettings.Get("LogServerIP");

            }
            _synthesizer = new SpeechSynthesizer();
            _synthesizer.Volume = 100;  // 0...100
            _synthesizer.Rate = 1;     // -10...10

        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        private void ribbonControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Name)
            {
                case "iDesigner":
                    XRDesignFormEx xrDesignFormEx = new XRDesignFormEx();
                    xrDesignFormEx.ShowDialog();
                    break;

                case "SalirBbi":
                    Close();
                    break;
                case "iCambioDeUsuario":

                    Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
                    foreach (Form form in forms)
                    {
                        if (form.Name.EndsWith("Frm"))
                        {
                            form.Close();
                        }
                    }

                    UsuarioIngresoFrm usuarioIngresoFrm = new UsuarioIngresoFrm();
                    usuarioIngresoFrm.ShowDialog();
                    if (usuarioIngresoFrm.DialogResult == DialogResult.OK)
                    {
                        CargarDatosSistema();
                    }

                    EstablecerPermisos();
                    break;
                case "iBaseFrm":
                    BaseFrm grupoFrm = BaseFrm.GetInstance();
                    grupoFrm.MdiParent = this;
                    grupoFrm.Show();
                    break;

                case "iTipocpFrm":
                    TipocpFrm tipocpFrm = TipocpFrm.GetInstance();
                    tipocpFrm.MdiParent = this;
                    tipocpFrm.Show();
                    break;

                case "iTipoformatoFrm":
                    TipoformatoFrm tipoformatoMntFrm = TipoformatoFrm.GetInstance();
                    tipoformatoMntFrm.MdiParent = this;
                    tipoformatoMntFrm.Show();
                    break;
                case "iCptooperacionFrm":
                    CptooperacionFrm cptooperacionFrm = CptooperacionFrm.GetInstance();
                    cptooperacionFrm.MdiParent = this;
                    cptooperacionFrm.Show();
                    break;
                case "iAreaFrm":
                    AreaFrm areaFrm = AreaFrm.GetInstance();
                    areaFrm.MdiParent = this;
                    areaFrm.Show();
                    break;
                case "iMarcaFrm":
                    MarcaFrm marcaFrm = MarcaFrm.GetInstance();
                    marcaFrm.MdiParent = this;
                    marcaFrm.Show();
                    break;
                case "iEmpresaFrm":
                    EmpresaFrm empresaFrm = EmpresaFrm.GetInstance();
                    empresaFrm.MdiParent = this;
                    empresaFrm.Show();
                    break;
                case "iCentrodecostoFrm":
                    CentrodecostoFrm centrodecostoFrm = CentrodecostoFrm.GetInstance();
                    centrodecostoFrm.MdiParent = this;
                    centrodecostoFrm.Show();
                    break;
                case "iTiposcontactoFrm":
                    TiposcontactoFrm tiposcontactoFrm = TiposcontactoFrm.GetInstance();
                    tiposcontactoFrm.MdiParent = this;
                    tiposcontactoFrm.Show();
                    break;
                case "iSocionegocioFrm":
                    SocionegocioFrm socionegocioFrm = SocionegocioFrm.GetInstance();
                    socionegocioFrm.MdiParent = this;
                    socionegocioFrm.Show();
                    break;
                case "iAlmacenFrm":
                    AlmacenFrm almacenFrm = AlmacenFrm.GetInstance();
                    almacenFrm.MdiParent = this;
                    almacenFrm.Show();
                    break;
                case "iEmpleadoFrm":
                    EmpleadoFrm empleadoFrm = EmpleadoFrm.GetInstance();
                    empleadoFrm.MdiParent = this;
                    empleadoFrm.Show();
                    break;
                case "iListaprecioFrm":
                    ListaprecioFrm listaprecioFrm = ListaprecioFrm.GetInstance();
                    listaprecioFrm.MdiParent = this;
                    listaprecioFrm.Show();
                    break;
                case "iPrioridadFrm":
                    PrioridadFrm prioridadFrm = PrioridadFrm.GetInstance();
                    prioridadFrm.MdiParent = this;
                    prioridadFrm.Show();
                    break;
                case "iTipomediopagoFrm":
                    TipomediopagoFrm tipomediopagoFrm = TipomediopagoFrm.GetInstance();
                    tipomediopagoFrm.MdiParent = this;
                    tipomediopagoFrm.Show();
                    break;
                case "iArticuloFrm":
                    if (!ExisteInventarioInicial())
                    {
                        return;
                    }
                    ArticuloFrm articuloFrm = ArticuloFrm.GetInstance();
                    articuloFrm.MdiParent = this;
                    articuloFrm.Show();
                    break;
                case "iArticuloclasificacionFrm":
                    ArticuloclasificacionFrm articuloclasificacionFrm = ArticuloclasificacionFrm.GetInstance();
                    articuloclasificacionFrm.MdiParent = this;
                    articuloclasificacionFrm.Show();
                    break;
                case "iEjercicioFrm":
                    EjercicioFrm ejercicioFrm = EjercicioFrm.GetInstance();
                    ejercicioFrm.MdiParent = this;
                    ejercicioFrm.Show();
                    break;
                case "iPeriodoFrm":
                    PeriodoFrm periodoFrm = PeriodoFrm.GetInstance();
                    periodoFrm.MdiParent = this;
                    periodoFrm.Show();
                    break;
                case "iRequerimientoFrm":
                    RequerimientoFrm requerimientoFrm = RequerimientoFrm.GetInstance();
                    requerimientoFrm.MdiParent = this;
                    requerimientoFrm.Show();
                    break;
                case "iOrdencompraFrm":
                    if (!ExisteTipoDeCambioFechaActual())
                    {
                        return;
                    }

                    OrdencompraFrm ordencompraFrm = OrdencompraFrm.GetInstance();
                    ordencompraFrm.MdiParent = this;
                    ordencompraFrm.Show();
                    break;
                case "iEntidadfinancieraFrm":
                    EntidadfinancieraFrm entidadfinancieraFrm = EntidadfinancieraFrm.GetInstance();
                    entidadfinancieraFrm.MdiParent = this;
                    entidadfinancieraFrm.Show();
                    break;
                case "iProyectoFrm":
                    ProyectoFrm proyectoFrm = ProyectoFrm.GetInstance();
                    proyectoFrm.MdiParent = this;
                    proyectoFrm.Show();
                    break;
                case "iUnidadmedidaFrm":
                    UnidadmedidaFrm unidadmedidaFrm = UnidadmedidaFrm.GetInstance();
                    unidadmedidaFrm.MdiParent = this;
                    unidadmedidaFrm.Show();
                    break;
                case "iTipolistaFrm":
                    TipolistaFrm tipolistaFrm = TipolistaFrm.GetInstance();
                    tipolistaFrm.MdiParent = this;
                    tipolistaFrm.Show();
                    break;
                case "iCpcompraFrm":
                    CpcompraFrm cpcompraFrm = CpcompraFrm.GetInstance();
                    cpcompraFrm.MdiParent = this;
                    cpcompraFrm.Show();
                    break;
                case "iNotacreditoFrm":
                    NotacreditoFrm notacreditoFrm = NotacreditoFrm.GetInstance();
                    notacreditoFrm.MdiParent = this;
                    notacreditoFrm.Show();
                    break;
                case "iUsuarioFrm":
                    UsuarioFrm usuarioFrm = UsuarioFrm.GetInstance();
                    usuarioFrm.MdiParent = this;
                    usuarioFrm.Show();
                    break;
                case "iGrupousuarioFrm":
                    GrupousuarioFrm grupousuarioFrm = GrupousuarioFrm.GetInstance();
                    grupousuarioFrm.MdiParent = this;
                    grupousuarioFrm.Show();
                    break;
                case "iEntradaalmacenFrm":
                    EntradaalmacenFrm entradaalmacenFrm = EntradaalmacenFrm.GetInstance();
                    entradaalmacenFrm.MdiParent = this;
                    entradaalmacenFrm.Show();
                    break;

                case "iSalidaalmacenFrm":
                    SalidaalmacenFrm salidaalmacenFrm = SalidaalmacenFrm.GetInstance();
                    salidaalmacenFrm.MdiParent = this;
                    salidaalmacenFrm.Show();
                    break;

                case "iGuiaremisionFrm":
                    GuiaremisionFrm guiaremisionFrm = GuiaremisionFrm.GetInstance();
                    guiaremisionFrm.MdiParent = this;
                    guiaremisionFrm.Show();
                    break;
                case "iRequerimientoListadoAprobacionFrm":

                    if (SessionApp.UsuarioSel.Idusuario > 0)
                    {
                        Accesoform permisoAprobacionRequerimiento = Service.GetPermisosForm(SessionApp.UsuarioSel.Idusuario, "RequerimientoListadoAprobacionFrm");
                        if (permisoAprobacionRequerimiento != null && !permisoAprobacionRequerimiento.Permitir)
                        {
                            XtraMessageBox.Show("No tiene permiso para esta opción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }

                    RequerimientoListadoAprobacionFrm requerimientoListadoAprobacionFrm = new RequerimientoListadoAprobacionFrm();
                    requerimientoListadoAprobacionFrm.ShowDialog();

                    break;
                case "iConfiguracionempleadoFrm":
                    ConfiguracionempleadoFrm configuracionempleado = new ConfiguracionempleadoFrm();
                    configuracionempleado.ShowDialog();
                    break;
                case "btnControles":
                    Controles controles = new Controles();
                    controles.ShowDialog();
                    break;
                case "iSucursalFrm":
                    SucursalFrm sucursal = SucursalFrm.GetInstance();
                    sucursal.MdiParent = this;
                    sucursal.Show();

                    break;
                case "iEntradaalmacenVerificacionFrm":
                    if (SessionApp.UsuarioSel.Idusuario > 0)
                    {
                        Accesoform permisoAprobacionRequerimiento = Service.GetPermisosForm(SessionApp.UsuarioSel.Idusuario, "EntradaalmacenVerificacionFrm");
                        if (permisoAprobacionRequerimiento != null && !permisoAprobacionRequerimiento.Permitir)
                        {
                            XtraMessageBox.Show("No tiene permiso para esta opción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    EntradaalmacenVerificacionFrm entradaalmacenVerificacionFrm = new EntradaalmacenVerificacionFrm(0, TipoMantenimiento.Modificar, null, null);
                    entradaalmacenVerificacionFrm.ShowDialog();
                    break;
                case "iOrdenCompraRpFrm":
                    //OrdenCompraRpFrm ordenCompraRpFrm = new OrdenCompraRpFrm();
                    //ordenCompraRpFrm.ShowDialog();
                    break;
                case "iEntradaAlmacenRpFrm":
                    EntradaAlmacenRpFrm entradaAlmacenRp = new EntradaAlmacenRpFrm();
                    entradaAlmacenRp.ShowDialog();
                    break;
                case "iRpOrdenCompraFrm":
                    RpOrdenCompraFrm rpOrdenCompraFrm = new RpOrdenCompraFrm();
                    rpOrdenCompraFrm.ShowDialog();
                    break;
                case "iRpCpCompraFrm":
                    RpCpCompraFrm rpCpCompraFrm = new RpCpCompraFrm();
                    rpCpCompraFrm.ShowDialog();
                    break;

                case "iRpReclamosFrm":
                    RpReclamosFrm rpReclamosFrm = new RpReclamosFrm();
                    rpReclamosFrm.ShowDialog();
                    break;

                case "iKardexPorArticuloFrm":
                    KardexFisicoPorArticuloFrm kardexPorArticuloFrm = new KardexFisicoPorArticuloFrm();
                    kardexPorArticuloFrm.ShowDialog();
                    break;
                case "iHistorialDocumentosFrm":
                    HistorialDocumentosFrm historialDocumentosFrm = new HistorialDocumentosFrm();
                    historialDocumentosFrm.ShowDialog();
                    break;
                case "iNotadebitoFrm":
                    NotadebitoFrm notadebitoFrm = NotadebitoFrm.GetInstance();
                    notadebitoFrm.MdiParent = this;
                    notadebitoFrm.Show();
                    break;
                case "iCambiarPasswordFrm":
                    CambiarPasswordFrm cambiarPasswordFrm = new CambiarPasswordFrm(SessionApp.UsuarioSel.Idusuario);
                    cambiarPasswordFrm.ShowDialog();
                    break;
                case "iCpcostoshistorialFrm":
                    CpcostoshistorialFrm cpcostoshistorialFrm = new CpcostoshistorialFrm();
                    cpcostoshistorialFrm.ShowDialog();
                    break;
                case "iEstadoreclamoFrm":
                    EstadoreclamoFrm estadoreclamoFrm = EstadoreclamoFrm.GetInstance();
                    estadoreclamoFrm.MdiParent = this;
                    estadoreclamoFrm.Show();
                    break;
                case "iCotizacionclienteFrm":
                    CotizacionclienteFrm cotizacionclienteFrm = CotizacionclienteFrm.GetInstance();
                    cotizacionclienteFrm.MdiParent = this;
                    cotizacionclienteFrm.Show();
                    break;

                case "iTipoafectacionigvFrm":
                    TipoafectacionigvFrm tipoafectacionigvFrm = TipoafectacionigvFrm.GetInstance();
                    tipoafectacionigvFrm.MdiParent = this;
                    tipoafectacionigvFrm.Show();
                    break;
                case "iOrdendeventaFrm":
                    OrdendeventaFrm ordendeventaFrm = OrdendeventaFrm.GetInstance();
                    ordendeventaFrm.MdiParent = this;
                    ordendeventaFrm.Show();
                    break;
                case "iCpventaFrm":
                    CpventaFrm cpventaFrm = CpventaFrm.GetInstance();
                    cpventaFrm.MdiParent = this;
                    cpventaFrm.Show();
                    break;

                case "iListaprecioActualizacionFrm":
                    ListaprecioActualizacionFrm listaprecioActualizacionFrm = new ListaprecioActualizacionFrm();
                    listaprecioActualizacionFrm.ShowDialog();
                    break;
                case "iMarcaequipoFrm":
                    MarcaequipoFrm marcaequipoFrm = MarcaequipoFrm.GetInstance();
                    marcaequipoFrm.MdiParent = this;
                    marcaequipoFrm.Show();
                    break;
                case "iClasificacionequipoFrm":
                    ClasificacionequipoFrm clasificacionequipoFrm = ClasificacionequipoFrm.GetInstance();
                    clasificacionequipoFrm.MdiParent = this;
                    clasificacionequipoFrm.Show();
                    break;
                case "iModeloequipoFrm":
                    ModeloequipoFrm modeloequipoFrm = ModeloequipoFrm.GetInstance();
                    modeloequipoFrm.MdiParent = this;
                    modeloequipoFrm.Show();
                    break;
                case "iEquipoFrm":
                    EquipoFrm equipoFrm = EquipoFrm.GetInstance();
                    equipoFrm.MdiParent = this;
                    equipoFrm.Show();
                    break;
                case "iNotacreditocliFrm":
                    NotacreditocliFrm notacreditocliFrm = NotacreditocliFrm.GetInstance();
                    notacreditocliFrm.MdiParent = this;
                    notacreditocliFrm.Show();
                    break;
                case "iNotadebitocliFrm":
                    NotadebitocliFrm notadebitocliFrm = NotadebitocliFrm.GetInstance();
                    notadebitocliFrm.MdiParent = this;
                    notadebitocliFrm.Show();
                    break;
                case "iUbicacionFrm":
                    UbicacionFrm ubicacionFrm = UbicacionFrm.GetInstance();
                    ubicacionFrm.MdiParent = this;
                    ubicacionFrm.Show();
                    break;
                case "iInventarioFrm":
                    InventarioFrm inventarioFrm = InventarioFrm.GetInstance();
                    inventarioFrm.MdiParent = this;
                    inventarioFrm.Show();
                    break;
                case "iRequerimientoListadoFrm":
                    RequerimientoListadoFrm requerimientoListadoFrm = new RequerimientoListadoFrm();
                    requerimientoListadoFrm.ShowDialog();
                    break;
                case "iCuadrocomparativoFrm":
                    CuadrocomparativoFrm cuadrocomparativoFrm = CuadrocomparativoFrm.GetInstance();
                    cuadrocomparativoFrm.MdiParent = this;
                    cuadrocomparativoFrm.Show();
                    break;
                case "iCotizacionprvFrm":
                    CotizacionprvFrm cotizacionprvFrm = CotizacionprvFrm.GetInstance();
                    cotizacionprvFrm.MdiParent = this;
                    cotizacionprvFrm.Show();
                    break;
                case "iModeloautorizacionFrm":
                    ModeloautorizacionFrm modeloautorizacionFrm = ModeloautorizacionFrm.GetInstance();
                    modeloautorizacionFrm.MdiParent = this;
                    modeloautorizacionFrm.Show();
                    break;
                case "iEtapaautorizacionFrm":
                    EtapaautorizacionFrm etapaautorizacionFrm = EtapaautorizacionFrm.GetInstance();
                    etapaautorizacionFrm.MdiParent = this;
                    etapaautorizacionFrm.Show();
                    break;
                case "iValorizacionFrm":
                    ValorizacionFrm valorizacionFrm = ValorizacionFrm.GetInstance();
                    valorizacionFrm.MdiParent = this;
                    valorizacionFrm.Show();
                    break;
                case "iRecibocajaingresoFrm":
                    RecibocajaingresoFrm recibocajaFrm = RecibocajaingresoFrm.GetInstance();
                    recibocajaFrm.MdiParent = this;
                    recibocajaFrm.Show();
                    break;
                case "iElementogastoFrm":
                    ElementogastoFrm elementogastoFrm = ElementogastoFrm.GetInstance();
                    elementogastoFrm.MdiParent = this;
                    elementogastoFrm.Show();
                    break;
                case "iCuadrocomparativoListadoAprobacionFrm":
                    CuadrocomparativoListadoAprobacionFrm cuadrocomparativoListadoAprobacionFrm = new CuadrocomparativoListadoAprobacionFrm();
                    cuadrocomparativoListadoAprobacionFrm.ShowDialog();
                    break;
                case "iOrdenservicioFrm":
                    OrdenservicioFrm ordenservicioFrm = OrdenservicioFrm.GetInstance();
                    ordenservicioFrm.MdiParent = this;
                    ordenservicioFrm.Show();
                    break;
                case "iRendicioncajachicaFrm":
                    RendicioncajachicaFrm rendicioncajachicaFrm = RendicioncajachicaFrm.GetInstance();
                    rendicioncajachicaFrm.MdiParent = this;
                    rendicioncajachicaFrm.Show();
                    break;
                case "iRecibocajaegresoFrm":
                    RecibocajaegresoFrm recibocajaegresoFrm = RecibocajaegresoFrm.GetInstance();
                    recibocajaegresoFrm.MdiParent = this;
                    recibocajaegresoFrm.Show();
                    break;
                case "iSaldosFisicosRpFrm":
                    SaldosFisicosRpFrm saldosFisicosRpFrm = new SaldosFisicosRpFrm();
                    saldosFisicosRpFrm.ShowDialog();
                    break;
                case "iReporteUsuarioFrm":
                    ReporteUsuarioFrm reporteUsuarioFrm = ReporteUsuarioFrm.GetInstance();
                    reporteUsuarioFrm.MdiParent = this;
                    reporteUsuarioFrm.Show();
                    break;
                case "iValorizacionproveedorFrm":
                    ValorizacionproveedorFrm valorizacionproveedorFrm = ValorizacionproveedorFrm.GetInstance();
                    valorizacionproveedorFrm.MdiParent = this;
                    valorizacionproveedorFrm.Show();
                    break;
                case "iMantenimientoFrm":
                    MantenimientoFrm mantenimientoFrm = MantenimientoFrm.GetInstance();
                    mantenimientoFrm.MdiParent = this;
                    mantenimientoFrm.Show();
                    break;
                case "iKardexFisicoValoradoPorArticuloFrm":
                    KardexFisicoValoradoPorArticuloFrm kardexFisicoValoradoPorArticuloFrm = new KardexFisicoValoradoPorArticuloFrm();
                    kardexFisicoValoradoPorArticuloFrm.ShowDialog();
                    break;
                case "iReporteCustom":
                    ReporteCustom reporteCustom = new ReporteCustom();
                    reporteCustom.ShowDialog();
                    break;
                case "iOrdentrabajoFrm":
                    OrdentrabajoFrm ordentrabajoFrm = OrdentrabajoFrm.GetInstance();
                    ordentrabajoFrm.MdiParent = this;
                    ordentrabajoFrm.Show();
                    break;
                case "iTipocomisioncobroFrm":
                    TipocomisioncobroFrm tipocomisioncobroFrm = TipocomisioncobroFrm.GetInstance();
                    tipocomisioncobroFrm.MdiParent = this;
                    tipocomisioncobroFrm.Show();
                    break;
                case "iComisioncobroFrm":
                    ComisioncobroFrm comisioncobroFrm = ComisioncobroFrm.GetInstance();
                    comisioncobroFrm.MdiParent = this;
                    comisioncobroFrm.Show();
                    break;
                case "iTipocambioFrm":
                    TipocambioFrm tipocambioFrm = TipocambioFrm.GetInstance();
                    tipocambioFrm.MdiParent = this;
                    tipocambioFrm.Show();
                    break;
                case "iValorizaciondanioelementoFrm":
                    ValorizaciondanioelementoFrm valorizaciondanioelementoFrm = ValorizaciondanioelementoFrm.GetInstance();
                    valorizaciondanioelementoFrm.MdiParent = this;
                    valorizaciondanioelementoFrm.Show();
                    break;
                case "iRubronegocioFrm":
                    RubronegocioFrm rubronegocioFrm = RubronegocioFrm.GetInstance();
                    rubronegocioFrm.MdiParent = this;
                    rubronegocioFrm.Show();
                    break;
                case "iCategoriasocionegocioFrm":
                    CategoriasocionegocioFrm categoriasocionegocioFrm = CategoriasocionegocioFrm.GetInstance();
                    categoriasocionegocioFrm.MdiParent = this;
                    categoriasocionegocioFrm.Show();
                    break;
                case "iGrupoeconomicoFrm":
                    GrupoeconomicoFrm grupoeconomicoFrm = GrupoeconomicoFrm.GetInstance();
                    grupoeconomicoFrm.MdiParent = this;
                    grupoeconomicoFrm.Show();
                    break;
                case "iZonaFrm":
                    ZonaFrm zonaFrm = ZonaFrm.GetInstance();
                    zonaFrm.MdiParent = this;
                    zonaFrm.Show();
                    break;
                case "iCajaMostradorFrm":
                    Empleado empleadoSel = SessionApp.EmpleadoSel;
                    if (empleadoSel == null)
                    {
                        XtraMessageBox.Show("Debe ingresar con usuario de caja valido", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        break;
                    }
                    CajaMostradorFrm cajaMostradorFrm = CajaMostradorFrm.GetInstance();
                    cajaMostradorFrm.MdiParent = this;
                    cajaMostradorFrm.Show();
                    break;
                case "iCierrecajaFrm":
                    CierrecajaFrm cierrecajaFrm = CierrecajaFrm.GetInstance();
                    cierrecajaFrm.MdiParent = this;
                    cierrecajaFrm.Show();
                    break;
                case "iTipolistatipocondicionFrm":
                    TipolistatipocondicionFrm tipolistatipocondicionFrm = TipolistatipocondicionFrm.GetInstance();
                    tipolistatipocondicionFrm.MdiParent = this;
                    tipolistatipocondicionFrm.Show();
                    break;
                case "iTipocondicionFrm":
                    TipocondicionFrm tipocondicionFrm = TipocondicionFrm.GetInstance();
                    tipocondicionFrm.MdiParent = this;
                    tipocondicionFrm.Show();
                    break;
                case "iEstadosocionegocioFrm":
                    EstadosocionegocioFrm estadosocionegocioFrm = EstadosocionegocioFrm.GetInstance();
                    estadosocionegocioFrm.MdiParent = this;
                    estadosocionegocioFrm.Show();
                    break;
                case "iEstadoarticuloFrm":
                    EstadoarticuloFrm estadoarticuloFrm = EstadoarticuloFrm.GetInstance();
                    estadoarticuloFrm.MdiParent = this;
                    estadoarticuloFrm.Show();
                    break;
                case "iTiposnpFrm":
                    TiposnpFrm tiposnpFrm = TiposnpFrm.GetInstance();
                    tiposnpFrm.MdiParent = this;
                    tiposnpFrm.Show();

                    break;
                case "iTipocontratoempleadoFrm":
                    TipocontratoempleadoFrm tipocontratoempleadoFrm = TipocontratoempleadoFrm.GetInstance();
                    tipocontratoempleadoFrm.MdiParent = this;
                    tipocontratoempleadoFrm.Show();
                    break;
                case "iInventarioinicialFrm":
                    InventarioinicialFrm inventarioinicialFrm = InventarioinicialFrm.GetInstance();
                    inventarioinicialFrm.MdiParent = this;
                    inventarioinicialFrm.Show();
                    break;
                case "iProgramacioncitaVisorFrm":
                    //ProgramacioncitaVisorFrm programacioncitaVisorFrm = ProgramacioncitaVisorFrm.GetInstance(this);
                    //programacioncitaVisorFrm.MdiParent = this;
                    //programacioncitaVisorFrm.Show();
                    if (SessionApp.EmpleadoSel == null)
                    {
                        XtraMessageBox.Show("Debe ingresar con usuario valido", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        break;
                    }
                    ShowProgramacionCitaVisor();


                    //ProgramacioncitaVisorFrmBackup programacioncitaVisorFrm = ProgramacioncitaVisorFrmBackup.GetInstance();
                    //programacioncitaVisorFrm.MdiParent = this;
                    //programacioncitaVisorFrm.Show();
                    break;
                case "iEstadocitaFrm":
                    EstadocitaFrm estadocitaFrm = EstadocitaFrm.GetInstance();
                    estadocitaFrm.MdiParent = this;
                    estadocitaFrm.Show();
                    break;
                case "iProgramacioncitaFrm":
                    ProgramacioncitaFrm programacioncitaFrm = ProgramacioncitaFrm.GetInstance();
                    programacioncitaFrm.MdiParent = this;
                    programacioncitaFrm.Show();
                    break;
                case "iMotivocitaFrm":
                    MotivocitaFrm motivocitaFrm = MotivocitaFrm.GetInstance();
                    motivocitaFrm.MdiParent = this;
                    motivocitaFrm.Show();

                    break;
                case "iTipohistoriaFrm":
                    TipohistoriaFrm tipohistoriaFrm = TipohistoriaFrm.GetInstance();
                    tipohistoriaFrm.MdiParent = this;
                    tipohistoriaFrm.Show();
                    break;
                case "iCategoriaitemFrm":
                    CategoriaitemFrm categoriaitemFrm = CategoriaitemFrm.GetInstance();
                    categoriaitemFrm.MdiParent = this;
                    categoriaitemFrm.Show();
                    break;
                case "iItemhistoriaFrm":
                    ItemhistoriaFrm itemhistoriaFrm = ItemhistoriaFrm.GetInstance();
                    itemhistoriaFrm.MdiParent = this;
                    itemhistoriaFrm.Show();
                    break;
                case "iTipoarchivoFrm":
                    TipoarchivoFrm tipoarchivoFrm = TipoarchivoFrm.GetInstance();
                    tipoarchivoFrm.MdiParent = this;
                    tipoarchivoFrm.Show();
                    break;
                case "iPlantillahistoriaFrm":
                    PlantillahistoriaFrm plantillahistoriaFrm = PlantillahistoriaFrm.GetInstance();
                    plantillahistoriaFrm.MdiParent = this;
                    plantillahistoriaFrm.Show();

                    break;
                case "iHistoriaFrm":
                    HistoriaFrm historiaFrm = HistoriaFrm.GetInstance();
                    historiaFrm.MdiParent = this;
                    historiaFrm.Show();

                    break;
                case "iSeriearticuloFrm":
                    SeriearticuloFrm seriearticuloFrm = SeriearticuloFrm.GetInstance();
                    seriearticuloFrm.MdiParent = this;
                    seriearticuloFrm.Show();
                    break;
                case "iClaseFrm":
                    ClaseFrm claseFrm = ClaseFrm.GetInstance();
                    claseFrm.MdiParent = this;
                    claseFrm.Show();
                    break;
                case "iPlanFrm":
                    PlanFrm planFrm = PlanFrm.GetInstance();
                    planFrm.MdiParent = this;
                    planFrm.Show();
                    break;
                case "iTipoFrm":
                    TipoFrm tipoFrm = TipoFrm.GetInstance();
                    tipoFrm.MdiParent = this;
                    tipoFrm.Show();
                    break;
                case "iTipotopeFrm":
                    TipotopeFrm tipotopeFrm = TipotopeFrm.GetInstance();
                    tipotopeFrm.MdiParent = this;
                    tipotopeFrm.Show();
                    break;

                case "iDiaferiadoFrm":
                    DiaferiadoFrm diaferiadoFrm = DiaferiadoFrm.GetInstance();
                    diaferiadoFrm.MdiParent = this;
                    diaferiadoFrm.Show();

                    break;
            }

        }
        private bool ExisteInventarioInicial()
        {
            string condicion = "fechainventarioinicial desc limit 1";
            string where = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);

            VwInventario vwInventario = Service.GetAllVwInventario(where, condicion).FirstOrDefault();
            if (vwInventario == null)
            {
                XtraMessageBox.Show("No existe un inventario inicial registrado para la empresa seleccionada, verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool ExisteTipoDeCambioFechaActual()
        {

            Tipocambio tipocambio = Service.GetTipocambio(x => x.Fechatipocambio == SessionApp.DateServer);
            if (tipocambio == null)
            {
                XtraMessageBox.Show(string.Format("Debe ingresar el tipo de cambio para la fecha {0}", SessionApp.DateServer.ToString("dd-MM-yyyy")), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TipocambioMntFrm tipocambioMntFrm = new TipocambioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                tipocambioMntFrm.ShowDialog();

                if (tipocambioMntFrm.TipocambioMnt != null && tipocambioMntFrm.TipocambioMnt.Fechatipocambio == SessionApp.DateServer)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        private void ModuloClinica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection aps = config.AppSettings;
            aps.Settings["AppSkinStyle"].Value = UserLookAndFeel.Default.SkinName.Trim();
            config.Save(ConfigurationSaveMode.Modified);
            EliminarArchivosTemporales();
        }
        private void ModuloClinica_Load(object sender, EventArgs e)
        {
            CargarDatosSistema();
            EstablecerPermisos();
            //timerReqAlerta.Enabled = true;


            // Initialise delegate
            if (AllowMessagesUdp)
            {
                _displayMessageDelegate = DisplayMessage;
                ConnectToServerUpd();
            }

        }
        private void EstablecerPermisos()
        {

            GrupousuarioitemsPermisos = Service.GetAllVwGrupousuarioitem(x => x.Idgrupousuario == SessionApp.UsuarioSel.Idgrupousuario);
            foreach (var control in ribbonControl.Items)
            {
                var itemPagina = control as BarButtonItem;
                if (itemPagina == null) continue;

                if (SessionApp.UsuarioSel.Nombreusuario == "ADMIN")
                {
                    itemPagina.Enabled = true;
                }
                else
                {
                    VwGrupousuarioitem grupousuarioitem = GrupousuarioitemsPermisos.FirstOrDefault(x => x.Namepaginaitem == itemPagina.Name);
                    if (grupousuarioitem != null)
                    {
                        itemPagina.Enabled = grupousuarioitem.Activo;
                    }

                }
            }
            iCambioDeUsuario.Enabled = true;
        }
        private void CargarDatosSistema()
        {
            DatosServidor datosServidor = new DatosServidor();
            datosServidor.ObtenerDatosServidor();

            bsiEmpresa.Caption = string.Format("Empresa: {0}", SessionApp.EmpresaSel.Razonsocial);
            bsiSucursal.Caption = SessionApp.SucursalSel != null ? string.Format("Sucusal: {0}", SessionApp.SucursalSel.Nombresucursal) : string.Empty;
            bsiUsuario.Caption = string.Format("Usuario: {0}", SessionApp.UsuarioSel.Nombreusuario);
            iEjercicio.EditValue = SessionApp.EjercicioActual;
            bsiServidor.Caption = string.Format("Servidor: {0}", datosServidor.Servidor);
            bsiBaseDatos.Caption = string.Format("Base de datos: {0}", datosServidor.NombreBaseDeDato);                

        }
        private int CantidadReqPendientesDeAprobacion
        {
            get
            {
                //string whereEstado = string.Empty;
                //        whereEstado = string.Format("idestadoreq = 2 and idsucursal = {0} and idempleadoaprueba = {1} ",
                if (SessionApp.EmpleadoSel == null)
                {
                    return 0;
                }
                //var listReqPendientes =  Service.GetAllVwRequerimientosaaprobar(
                //        x => x.Idestadoreq == 2 
                //            && x.Idsucursal == UsuarioAutenticado.SucursalSel.Idsucursal
                //            && x.Idempleadoaprueba == UsuarioAutenticado.EmpleadoSel.Idempleado);
                var listReqPendientes = Service.GetAllVwRequerimientosaaprobar(
                        x => x.Idestadoreq == 2
                            && x.Idempleadoaprueba == SessionApp.EmpleadoSel.Idempleado);

                if (listReqPendientes != null)
                {
                    var total = listReqPendientes.Sum(x => x.Cantrequerimiento);

                    return total;
                }
                //return
                //    Service.CountVwRequerimientosaaprobar(
                //        x => x.Idestadoreq == 2 
                //            && x.Idsucursal == UsuarioAutenticado.SucursalSel.Idsucursal
                //            && x.Idempleadoaprueba == UsuarioAutenticado.EmpleadoSel.Idempleado);
                return 0;
            }

        }
        private void alertControl_ButtonClick(object sender, AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "btnVerReq")
            {
                RequerimientoListadoAprobacionFrm requerimientoListadoAprobacionFrm = new RequerimientoListadoAprobacionFrm();
                requerimientoListadoAprobacionFrm.ShowDialog();
            }

            if (e.ButtonName == "btnStockMinimo")
            {
                StockMinimoRpFrm stockMinimo = new StockMinimoRpFrm();
                stockMinimo.ShowDialog();
            }            

        }
        private void AlertarOtros()
        {
            long cntReqPorAprobar = CantidadReqPendientesDeAprobacion;
            if (cntReqPorAprobar > 0)
            {
                alertControl.Buttons["btnVerReq"].Visible = true;
                alertControl.Buttons["btnStockMinimo"].Visible = false;

                alertControl.Show(FindForm()
                , "Aprobación de requerimientos"
                , string.Format("Existe ({0}) requerimiento(s) pendiente(s) de aprobación", cntReqPorAprobar)
                , string.Empty
                , Resources.Action_Report_Object_Inplace_Preview_32x32);
            }

            int cntArticuloStock = CantidadArticulosConStockMinimo();
            if (cntArticuloStock > 0)
            {
                alertControl.Buttons["btnVerReq"].Visible = false;
                alertControl.Buttons["btnStockMinimo"].Visible = true;

                alertControl.Show(FindForm()
                , "Artículos con stock mínimo"
                , string.Format("Existe ({0}) Artículos por debajo ó igual al stock mínimo", cntArticuloStock)
                , string.Empty
                , Resources.Action_Copy_CellValue_32x32);
            }
        }
        private int CantidadArticulosConStockMinimo()
        {
            DateTime fechaInicio = new DateTime();
            DateTime fechaFinal = SessionApp.DateServer;


            string condicion = string.Format("idsucursal = '{0}' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";


            if (_inventarioList == null)
            {
                _inventarioList = Service.GetAllInventario(condicion, orden);
            }

            if (_inventarioList != null)
            {
                Inventario inventario = _inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    fechaInicio = inventario.Fechainventario;
                }

                const string sqlQuery = "reportes.fn_stockminimo";

                object[] parametrosConsulta = {
                fechaInicio,
                fechaFinal,
                SessionApp.EmpresaSel.Idempresa /*pidempresa*/,
                null /*pidarticuloclasificacion*/,
                null /*pidmarca*/};

                DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
                return dt.Rows.Count;
            }
            return 0;
        }
        private void timerReqAlerta_Tick(object sender, EventArgs e)
        {
            
            AlertarOtros();
            
        }
        private void EliminarArchivosTemporales()
        {
            string[] archivosTemp = Directory.GetFiles(Path.GetTempPath(), "#*.*");
            foreach (string archivo in archivosTemp)
            {
                try
                {
                    if (File.Exists(archivo))
                    {
                        File.Delete(archivo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text.Trim());
        }

    }
}