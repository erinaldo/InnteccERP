using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ProgramacioncitaVisorFrmBackup : XtraForm
    {
        #region Socket Client

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
        #endregion


        private static ProgramacioncitaVisorFrmBackup _uniqueInstance;
        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();
        public List<Estadocita> EstadocitaList { get; set; }
        public List<VwProgramacioncitadet> VwProgramacioncitadetList { get; set; }

        private ProgramacioncitaVisorFrmBackup()
        {
            InitializeComponent();
            EstadocitaList = Service.GetAllEstadocita();

            NameUser = string.Format("{0}-{1}", SystemInformation.ComputerName, SessionApp.UsuarioSel.Nombreusuario);
            ServerIp = ConfigurationManager.AppSettings.Get("LogServerIP");
            
        }

        public static ProgramacioncitaVisorFrmBackup GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new ProgramacioncitaVisorFrmBackup();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }

        private void CargarCitas()
        {
            DateTime fechaCalendario = iCalendarioCita.DateTime;
            gvCitas.BeginUpdate();

            VwProgramacioncitadetList = Service.GetAllVwProgramacioncitadet(x => x.Fechaprogramacion == fechaCalendario);
            gcCitas.DataSource = VwProgramacioncitadetList;
            gvCitas.BestFitColumns(true);
            gvCitas.EndDataUpdate();

            Text = string.Empty;
            Text = string.Format("Citas para el día {0}", fechaCalendario.ToString("D"));
        }

        private void ProgramacioncitaVisorFrmBackup_Load(object sender, EventArgs e)
        {

            // Initialise delegate
            _displayMessageDelegate = DisplayMessage;

            iCalendarioCita.EditValue = DateTime.Now;

            ConnectToServerUpd();

        }

        #region Other Methods

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
            int idProgramacionDet = Convert.ToInt32(message.Substring(indexMsg+2));

            if (idProgramacionDet > 0)
            {
                VwProgramacioncitadet vwRequerimientodetModified = VwProgramacioncitadetList.FirstOrDefault(x => x.Idprogramacioncitadet == idProgramacionDet);
                int indexItem = VwProgramacioncitadetList.IndexOf(vwRequerimientodetModified);
                VwProgramacioncitadetList.Remove(vwRequerimientodetModified);
                if (vwRequerimientodetModified != null)
                {
                    VwProgramacioncitadet vwProgramacioncitadetNew = Service.GetVwProgramacioncitadet(x => x.Idprogramacioncitadet == idProgramacionDet);
                    if (vwProgramacioncitadetNew != null)
                    {
                        VwProgramacioncitadetList.Insert(indexItem, vwProgramacioncitadetNew);
                        ActualizarCitas();
                        Alertar(vwProgramacioncitadetNew);
                    }
                }
            }
        }

        #endregion

        #region Send And Receive

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

        #endregion

        private void bmCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
              var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnVerEditarrCita":
                     if (gvCitas.RowCount == 0)
                    {
                        break;
                    }
                    VerEditarCita();
                    break;
                case "btnActualizar":
                    CargarCitas();
                    break;
            }

        }

        private void VerEditarCita()
        {
            VwProgramacioncitadet vwProgramacioncitadet;
            ProgramacioncitaMntItemVisorFrm programacioncitaMntItemFrm;
            vwProgramacioncitadet = (VwProgramacioncitadet) gvCitas.GetFocusedRow();

            programacioncitaMntItemFrm = new ProgramacioncitaMntItemVisorFrm(TipoMantenimiento.Modificar, vwProgramacioncitadet);
            programacioncitaMntItemFrm.ShowDialog();

            if (programacioncitaMntItemFrm.DialogResult == DialogResult.OK)
            {
                Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                if (programacioncitadet.Idprogramacioncitadet > 0)
                {
                    Service.UpdateProgramacioncitadet(programacioncitadet);
                    //string message = vwProgramacioncitadet.Horaprogramacion.ToString("t") + "-" +
                    //                 vwProgramacioncitadet.Nombreestadocita + "-" +
                    //                 vwProgramacioncitadet.Razonsocialpaciente + "-" +
                    //                 programacioncitadet.Idprogramacioncitadet;

                    string message = programacioncitadet.Idprogramacioncitadet.ToString();

                    SendMessage(message);
                    ActualizarCitas();
                }
            }
        }

        private void ActualizarCitas()
        {

            gvCitas.BeginUpdate();
            gvCitas.RefreshData();
            gvCitas.EndUpdate();
            gvCitas.BestFitColumns(true);
        }

        private Programacioncitadet AsignarProgramacioncitadet(VwProgramacioncitadet vwProgramacioncitadet)
        {

            Programacioncitadet programacioncitadet = new Programacioncitadet
            {
                Idprogramacioncitadet = vwProgramacioncitadet.Idprogramacioncitadet,
                Idprogramacioncita = vwProgramacioncitadet.Idprogramacioncita,
                Horaprogramacion = vwProgramacioncitadet.Horaprogramacion,
                Idpersona = vwProgramacioncitadet.Idpaciente,
                Idestadocita = vwProgramacioncitadet.Idestadocita

            };
            return programacioncitadet;
        }

        private void gvCitas_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            GridView view = sender as GridView;
            if (e.RowHandle >= 0 && view != null)
            {
                string nombreEstadoCita = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Nombreestadocita"]);
                Estadocita estadocita = EstadocitaList.FirstOrDefault(x => x.Nombreestadocita.Equals(nombreEstadoCita.Trim()));
                if (estadocita != null)
                {
                    if (nombreEstadoCita.Trim() == estadocita.Nombreestadocita.Trim())
                    {
                        e.Appearance.BackColor = Color.FromArgb(estadocita.Colorestadocita);
                    }
                }
            }
        }

        private void gvCitas_DoubleClick(object sender, EventArgs e)
        {
            VerEditarCita();
        }

        private void iCalendarioCita_DateTimeChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void ProgramacioncitaVisorFrmBackup_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text.Trim());
        }

        private void SendMessage(string message)
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

        private void Alertar(VwProgramacioncitadet vwProgramacioncitadet)
        {

            if (vwProgramacioncitadet != null)
            {
                AlertControlCita.Buttons["btnCita"].Visible = true;
                AlertControlCita.Show(FindForm()
                , "Información de cita"
                , string.Format("Hora :{0}\nServicio: {1}\nPaciente: {2}\nEstado: {3}", vwProgramacioncitadet.Horaprogramacion.ToString("t"), vwProgramacioncitadet.Nombrearticulo, vwProgramacioncitadet.Razonsocialpaciente, vwProgramacioncitadet.Nombreestadocita)
                , string.Empty
                , Resources.date_time_32x32);
            }
        }
    }
}