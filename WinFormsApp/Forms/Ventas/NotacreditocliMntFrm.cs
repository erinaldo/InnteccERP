using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class NotacreditocliMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public NotacreditocliFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Notacreditocli NotacreditocliMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public List<VwNotacreditoclidet> VwNotacreditoclidetList { get; set; }
        public NotacreditocliMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, NotacreditocliFrm formParent) 
        {
            if (tipoMnt == TipoMantenimiento.SinEspecificar && idEntidadMnt <= 0)
            {
                throw new ArgumentException("El valor primario de la entidad no contiene un valor valido.");
            }

            InitializeComponent();

            IdEntidadMnt = idEntidadMnt;
            TipoMnt = tipoMnt;
            SeEliminoObjeto = false;
            GridParent = gridParent;
            FormParent = formParent;

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;                       
        }        
        private void NotacreditocliMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Crear " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void ValoresPorDefecto()
        {

            iFechaemision.EditValue = SessionApp.DateServer;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            if (SessionApp.EmpleadoSel == null)
            {
                iIdvendedor.EditValue = null;
                iIdvendedor.Enabled = true;
            }
            else
            {
                iIdvendedor.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdvendedor.Enabled = false;
            }


            iFechaemision.EditValue = SessionApp.DateServer;
            iFechavencimiento.EditValue = SessionApp.DateServer;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "NC-CLIENTE";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

            int idPeriodo = Service.GetIdPeriodo(SessionApp.DateServer);
            if (idPeriodo > 0)
            {
                iIdperiodo.EditValue = idPeriodo;
            }

            iIdtipocp.Select();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    NotacreditocliMnt = new Notacreditocli();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();

                    iIdvendedor.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    ListarCpVentaReferencia();
                    CargarDocReferencia();
                    break;
            }           
        }

        private void CargarDocReferencia()
        {
            var iidCpVenta = iIdcpventa.EditValue;
            if (iidCpVenta != null)
            {
                VwCpventa vwCpventaRef = Service.GetVwCpventa((int)iidCpVenta);
                if (vwCpventaRef != null)
                {
                    rDocReferenciaVenta.EditValue = vwCpventaRef.Nombretipoformato;
                    rDocSerieNumero.EditValue = string.Format("{0}-{1}", vwCpventaRef.Seriecpventa,vwCpventaRef.Numerocpventa);
                    rFechaDocReferencia.EditValue = vwCpventaRef.Fechaemision;
                    rTipoCambioDocReferencia.EditValue = vwCpventaRef.Tipocambio;
                    iIdcpventa.EditValue = vwCpventaRef.Idcpventa;
                }
            }
        }

        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "NC-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "NC-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
            
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            ImpuestoList = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DataSource = ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdvendedor.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdvendedor.Properties.DisplayMember = "Razonsocial";
            iIdvendedor.Properties.ValueMember = "Idempleado";
            iIdvendedor.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereProyecto = string.Format("idsucursal = '{0}'", UsuarioAutenticado.SucursalSel.Idsucursal);
            //iIdproyecto.Properties.DataSource = Service.GetAllVwProyecto(whereProyecto,"Nombreproyecto");
            //iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            //iIdproyecto.Properties.ValueMember = "Idproyecto";
            //iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            iIdperiodo.Properties.DataSource = Service.GetAllVwPeriodo("anioejercicio,mes");
            iIdperiodo.Properties.DisplayMember = "Periodo";
            iIdperiodo.Properties.ValueMember = "Idperiodo";
            iIdperiodo.Properties.BestFitMode = BestFitMode.BestFit;
           
        }
        private void TraerDatos()
        {
            try
            {

                NotacreditocliMnt = Service.GetNotacreditocli(IdEntidadMnt);                
                rIdsucursal.EditValue = NotacreditocliMnt.Idsucursal;
                iIdtipocp.EditValue = NotacreditocliMnt.Idtipocp;
                iIdcptooperacion.EditValue = NotacreditocliMnt.Idcptooperacion;
                rSerieDoc.EditValue = NotacreditocliMnt.Serienotacredito;
                rNumeroDoc.EditValue = NotacreditocliMnt.Numeronotacredito;

                iIdcliente.EditValue = NotacreditocliMnt.Idcliente;
                CargarDatosSocioNegocio(NotacreditocliMnt.Idcliente);

                iFechaemision.EditValue = NotacreditocliMnt.Fechaemision;
                iIdperiodo.EditValue = NotacreditocliMnt.Idperiodo;
                iFechavencimiento.EditValue = NotacreditocliMnt.Fechavencimiento;
                iAnulado.EditValue = NotacreditocliMnt.Anulado;
                iFechaanulado.EditValue = NotacreditocliMnt.Fechaanulado;
                iIdvendedor.EditValue = NotacreditocliMnt.Idempleado;
                //iIdtipocondicion.EditValue = NotacreditocliMnt.Idtipocondicion;
                iTipocambio.EditValue = NotacreditocliMnt.Tipocambio;
                iIdtipomoneda.EditValue = NotacreditocliMnt.Idtipomoneda;
                rTotalbruto.EditValue = NotacreditocliMnt.Totalbruto;
                rTotalgravado.EditValue = NotacreditocliMnt.Totalgravado;
                rTotalinafecto.EditValue = NotacreditocliMnt.Totalinafecto;
                rtotalexonerado.EditValue = NotacreditocliMnt.Totalexonerado;
                rTotalimpuesto.EditValue = NotacreditocliMnt.Totalimpuesto;
                rImportetotal.EditValue = NotacreditocliMnt.Importetotal;
                rPorcentajepercepcion.EditValue = NotacreditocliMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = NotacreditocliMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = NotacreditocliMnt.Totaldocumento;
                iGlosacpventa.EditValue = NotacreditocliMnt.Glosanotacredito;
                iIdimpuesto.EditValue = NotacreditocliMnt.Idimpuesto;
                iIncluyeimpuestoitems.EditValue = NotacreditocliMnt.Incluyeimpuestoitems;
                iIdtipolista.EditValue = NotacreditocliMnt.Idtipolista;
                iIddireccionfacturacion.EditValue = NotacreditocliMnt.Iddireccionfacturacion;
                iListadocpventaref.EditValue = NotacreditocliMnt.Listadocpventaref;
                iIdcpventa.EditValue = NotacreditocliMnt.Idcpventa;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private void CargarDetalle()
        {
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            string where = string.Format("idnotacreditocli = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwNotacreditoclidetList = Service.GetAllVwNotacreditoclidet(where, "numeroitem");
            gcDetalle.DataSource = VwNotacreditoclidetList;            
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            NotacreditocliMnt.Idsucursal = (int?)rIdsucursal.EditValue;
            NotacreditocliMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            NotacreditocliMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            NotacreditocliMnt.Serienotacredito = rSerieDoc.Text.Trim();
            NotacreditocliMnt.Numeronotacredito = rNumeroDoc.Text.Trim();
            NotacreditocliMnt.Idcliente = (int)iIdcliente.EditValue;

            NotacreditocliMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            NotacreditocliMnt.Idperiodo = (int)iIdperiodo.EditValue;
            NotacreditocliMnt.Fechavencimiento = (DateTime)iFechavencimiento.EditValue;
            NotacreditocliMnt.Anulado = (bool)iAnulado.EditValue;
            NotacreditocliMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            NotacreditocliMnt.Idempleado = (int)iIdvendedor.EditValue;
            //NotacreditocliMnt.Idtipocondicion = (int?)iIdtipocondicion.EditValue;
            NotacreditocliMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            NotacreditocliMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;

            NotacreditocliMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            NotacreditocliMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            NotacreditocliMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            NotacreditocliMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            NotacreditocliMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            NotacreditocliMnt.Importetotal = (decimal)rImportetotal.EditValue;
            NotacreditocliMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            NotacreditocliMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            NotacreditocliMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            NotacreditocliMnt.Glosanotacredito = iGlosacpventa.Text.Trim();
            NotacreditocliMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            NotacreditocliMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            NotacreditocliMnt.Idtipolista = (int) iIdtipolista.EditValue;
            NotacreditocliMnt.Iddireccionfacturacion = (int)iIddireccionfacturacion.EditValue;
            NotacreditocliMnt.Listadocpventaref = iListadocpventaref.Text.Trim();
            NotacreditocliMnt.Idcpventa = (int?) iIdcpventa.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //OrdendeventaMnt.Createdby = IdUsuario;
                    //OrdendeventaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                  //  OrdendeventaMnt.Modifiedby = IdUsuario;
                   // OrdendeventaMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                        if (Service.GuardarNotaCreditoCli(TipoMnt, NotacreditocliMnt, VwNotacreditoclidetList))
                    {
                        IdEntidadMnt = NotacreditocliMnt.Idnotacreditocli;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarNotaCreditoCli(TipoMnt, NotacreditocliMnt, VwNotacreditoclidetList);
                    break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerieDoc.Text.Trim(),rNumeroDoc.Text.Trim());
                Cursor = Cursors.Default;

                //if (tcCotizaCliente.SelectedTabPage == tpLogistica)
                //{
                //    tcCotizaCliente.SelectedTabPage = tpOrdendeventa;
                //}

                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                XtraMessageBox.Show("Se guardo correctamente el documento "+numeroDoc, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdvendedor.EditValue;
            const string nombreTipodocMov = "NC-CLIENTE";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;
            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCpVenta, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCpVenta;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCpVenta, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCpVenta;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }


            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwNotacreditoclidetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwNotacreditoclidetList.Where(x => x.Preciounitario <= 0);
            string msgItemPreUni = itemsPrecioUniInvalido.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemPreUni))
            {
                XtraMessageBox.Show("Existe items con precio unitario cero verifique: \n\n" + msgItemPreUni, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            decimal tipoCambio = (decimal)iTipocambio.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            {
                XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iTipocambio.Select();
                return false;
            }

            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSerieDoc.Text.Trim();
            string numeroViaje = rNumeroDoc.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroOrdendeventaExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
            {
                CargarInfoCorrelativo();
                return true;
            }
            
            return true;
        }
        private void EliminaRegistro()
        {
            if (Convert.ToInt32(pkIdEntidad.EditValue) > 0)
            {
                if (DialogResult.Yes == XtraMessageBox.Show(Resources.msgEliminarRegistro,
                                                        Resources.titPregunta, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        Service.DeleteNotacreditocli(IdEntidadMnt);
                        SeEliminoObjeto = true;
                        DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
                        SeEliminoObjeto = false;
                        DeshabilitarBtnMnt();
                        CamposSoloLectura(true);
                        throw;
                    }
                }
            }
        }
        private void EstablecerPermisos()
        {
            if (FormParent == null)
            {
                int index = Name.Trim().LastIndexOf("Mnt", StringComparison.Ordinal);
                string nameFrm = Name.Substring(0, index) + "Frm";
                Permisos = Service.GetPermisosForm(IdUsuario, nameFrm);
            }
            else
            {
                Permisos = FormParent.Permisos;
            }            

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Nuevo;
                    btnGrabarCerrar.Enabled = Permisos.Nuevo;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    iAnulado.Enabled = Permisos.Anular;
                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    iAnulado.Enabled = Permisos.Anular;
                    CamposSoloLectura(!Permisos.Editar);
                    break;
            }
        }
        private void bmMantenimiento_ItemClick(object sender, ItemClickEventArgs e)
        {            
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();

                    TipoMnt =TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    NotacreditocliMnt = null;
                    NotacreditocliMnt = new Notacreditocli();

                    btnGrabar.Enabled = true;
                    btnGrabarCerrar.Enabled = true;
                    btnGrabarNuevo.Enabled = true;      

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                    ValoresPorDefecto();

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);
                    break;

                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        //btnGrabar.Enabled = false;
                        //btnGrabarCerrar.Enabled = false;
                        btnGrabarNuevo.Enabled = false;

                        if (IdEntidadMnt > 0)
                        {
                            TipoMnt = TipoMantenimiento.Modificar;
                        }                        

                        if (Permisos.Eliminar)
                        {
                            btnEliminar.Enabled = true;
                            btnActualizar.Enabled = true;
                        }
                        //
                        DeshabilitarModificacion();
                    }                    
                    break;
                case "btnGrabarCerrar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        DialogResult = DialogResult.OK;
                    }                    
                    break;
                case "btnEliminar":
                    EliminaRegistro();
                    break;
                case "btnLimpiarCampos":
                    LimpiarCampos();
                    break;
                case "btnActualizar":
                    if (IdEntidadMnt > 0)
                    {
                        TraerDatos();
                        CargarDetalle();
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        NotacreditocliMnt = null;
                        DialogResult = DialogResult.OK;
                    }                    
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.VistaPreviaNotaCreditoCliente(NotacreditocliMnt);
                    }
                    break;
                case "btnCpventa":
                    int idClienteSel = (int)iIdcliente.EditValue;
                    if (idClienteSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el Cliente.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        beSocioNegocio.Select();
                        return;
                    }


                    NotacreditocliImpCpVentaFrm notacreditoImpCpventa = new NotacreditocliImpCpVentaFrm(VwNotacreditoclidetList, VwSocionegocioSel, (int)iIdtipomoneda.EditValue);
                    notacreditoImpCpventa.ShowDialog();

                    if (notacreditoImpCpventa.DialogResult == DialogResult.OK)
                    {
                        VwCpventa vwCpventaSelImp = notacreditoImpCpventa.VwCpventaSel;
                        if (vwCpventaSelImp != null)
                        {
                            iIdcliente.EditValue = vwCpventaSelImp.Idcliente;
                            iIdtipomoneda.EditValue = vwCpventaSelImp.Idtipomoneda;
                            iTipocambio.EditValue = vwCpventaSelImp.Tipocambio;
                            iIdtipomoneda.Enabled = false;

                            rDocReferenciaVenta.EditValue = vwCpventaSelImp.Nombretipoformato;
                            rDocSerieNumero.EditValue = string.Format("{0}-{1}", vwCpventaSelImp.Seriecpventa, vwCpventaSelImp.Numerocpventa);
                            rFechaDocReferencia.EditValue = vwCpventaSelImp.Fechaemision;
                            rTipoCambioDocReferencia.EditValue = vwCpventaSelImp.Tipocambio;
                            iIdcpventa.EditValue = vwCpventaSelImp.Idcpventa;
                            iIncluyeimpuestoitems.EditValue = vwCpventaSelImp.Incluyeimpuestoitems;

                        }
                        foreach (var item in VwNotacreditoclidetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();

                        ListarCpVentaReferencia();
                        iIdcliente.Enabled = false;


                    }
                    break;
            }
        }
        private void ListarCpVentaReferencia()
        {
            List<string> listadoNumeroCpVentas = new List<string>();
            List<string> serieNumeroCpVentaList = VwNotacreditoclidetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Seriecpventa))
                .Select(p => p.Serienumerocpventa).Distinct().ToList();

            if (serieNumeroCpVentaList.Count > 0)
            {
                foreach (string serieNumeroCpVenta in serieNumeroCpVentaList)
                {
                    string[] splitSerieNumeroCpVenta = serieNumeroCpVenta.Split('-');
                    if (splitSerieNumeroCpVenta.Count() == 2)
                    {
                        string numeroOvRef = string.Format("{0}-{1}"
                            , splitSerieNumeroCpVenta[0]
                            , Convert.ToInt32(splitSerieNumeroCpVenta[1]));
                        listadoNumeroCpVentas.Add(numeroOvRef);
                    }
                }
                string listadoOrdenVenta = listadoNumeroCpVentas.Aggregate(String.Empty,
                    (current, numeroOrden) => current + numeroOrden + ",");
                iListadocpventaref.EditValue = listadoOrdenVenta.Trim().Length == 0
                    ? string.Empty
                    : listadoOrdenVenta.Substring(0, listadoOrdenVenta.Length - 1);
            }
            else
            {
                iListadocpventaref.EditValue = string.Empty;
            }
        }
        private void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);
        }
        private void DeshabilitarBtnMnt()
        {
            pkIdEntidad.EditValue = 0;
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = false;
            btnGrabarCerrar.Enabled = false;
            btnGrabarNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnActualizar.Enabled = false;
        }
        private void NotacreditocliMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }
        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(tpCpVenta, readOnly);
            //XtraFormUtils.ReadOnlyFields(tpLogistica, readOnly);        
        }
        private void NotacreditocliMntFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormParent != null)
            {                
                if (SeEliminoObjeto)
                {
                    FormParent.CargarDatosConsulta();
                }
                if (SeGuardoObjeto)
                {                    
                    FormParent.IdEntidadMnt = IdEntidadMnt;
                    FormParent.CargarDatosConsulta();
                    FormParent.SetFocusIdEntity();
                }
            }
            e.Cancel = false;
        }
        public ImpresionFormato ImpresionFormato { get; set; }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            NotacreditocliMntItemFrm cpventaMntItemFrm;
            VwNotacreditoclidet vwCpventadetMntItem;

            //Propiedades para consulta
            int idSucursalConsulta = 0;
            int idAlmacenConsulta = 0;
            int idTipoListaConsulta = 0;

            //Validar que se seleccione el cliente
            int idClienteSel = (int)iIdcliente.EditValue;
            if (idClienteSel == 0)
            {
                XtraMessageBox.Show("Seleccione el cliente", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                beSocioNegocio.Select();
                return;
            }

            VwSucursal vwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)rIdsucursal.EditValue);
            if (vwSucursalSel != null)
            {
                idSucursalConsulta = vwSucursalSel.Idsucursal;
                idAlmacenConsulta = vwSucursalSel.Idalmacendefecto;
                idTipoListaConsulta = (int)iIdtipolista.EditValue;
            }

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Asignar el siguiente item
                    vwCpventadetMntItem = new VwNotacreditoclidet();

                    //Asignar el siguiente item
                    var sgtItem = VwNotacreditoclidetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwCpventadetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    cpventaMntItemFrm = new NotacreditocliMntItemFrm(tipoMantenimientoItem, vwCpventadetMntItem);

                    //
                    cpventaMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    cpventaMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    cpventaMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;
                    //

                    cpventaMntItemFrm.ShowDialog();
                  
                    if (cpventaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwNotacreditoclidetList.Add(vwCpventadetMntItem);
                        SumarTotales();
                        if (!gvDetalle.IsLastRow)
                        {
                            gvDetalle.MoveLastVisible();
                            gvDetalle.Focus();
                            gvDetalle.FocusedColumn = gvDetalle.Columns["Cantidad"];
                        }  
                    }


                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }


                    //itemSel = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdOrdendeventadet > 0
                    //&& Service.CantidadReferenciasItemOrdendeventa(itemSel.IdOrdendeventadet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    vwCpventadetMntItem = (VwNotacreditoclidet) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    cpventaMntItemFrm = new NotacreditocliMntItemFrm(tipoMantenimientoItem, vwCpventadetMntItem);

                    //
                    cpventaMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    cpventaMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    cpventaMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;
                    //

                    cpventaMntItemFrm.ShowDialog();
                    if (cpventaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();

                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    //itemSel = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdOrdendeventadet > 0
                    //&& Service.CantidadReferenciasItemOrdendeventa(itemSel.IdOrdendeventadet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwCpventadetMntItem = (VwNotacreditoclidet)gvDetalle.GetFocusedRow();
                        vwCpventadetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }

                        SumarTotales();
                        ListarCpVentaReferencia();
                                              
                    }
                    break;
            }
            
        }
        private void SumarTotales()
        {
            //gvDetalle.BeginDataUpdate();
            //gvDetalle.RefreshData();


            //var totalbruto = VwNotacreditoclidetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Cantidad * s.Preciounitario);
            //rTotalbruto.EditValue = totalbruto;

            //var totalgravado = VwNotacreditoclidetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            //rTotalgravado.EditValue = totalgravado;

            //var totalinafecto = VwNotacreditoclidetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            //rTotalinafecto.EditValue = totalinafecto;

            //var totalexonerado = VwNotacreditoclidetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            //rtotalexonerado.EditValue = totalexonerado;

            //var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            //if (impuestoSel != null)
            //{
            //    var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
            //    decimal totalImpuesto = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
            //    rTotalimpuesto.EditValue = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
            //    rImportetotal.EditValue = totalgravado + totalinafecto + totalexonerado + totalImpuesto;
                
            //    //Calculo percepcion
            //    decimal totalValorPercepcion = VwNotacreditoclidetList.Where(
            //        w=>w.DataEntityState != DataEntityState.Deleted
            //        && w.Porcentajepercepcion > 0).Sum(s => s.Importetotal * (s.Porcentajepercepcion/100));
            //    rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

            //    decimal importetotalpercepcion = Math.Round(totalValorPercepcion * (1 + porcentajeImpuesto / 100),2);
            //    rImportetotalpercepcion.EditValue = importetotalpercepcion;
            //    //fin calculo percepcion

            //    rTotaldocumento.EditValue = (decimal) rImportetotal.EditValue +
            //                                (decimal) rImportetotalpercepcion.EditValue;

            //}

            //gvDetalle.EndDataUpdate();

            //gvDetalle.BestFitColumns(true);
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();


            var totalbruto = VwNotacreditoclidetList.Where(w => w.DataEntityState != DataEntityState.Deleted ).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalgravado = VwNotacreditoclidetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotalgravado.EditValue = totalgravado;

            var totalinafecto = VwNotacreditoclidetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotalinafecto.EditValue = totalinafecto;

            var totalexonerado = VwNotacreditoclidetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rtotalexonerado.EditValue = totalexonerado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null)
            {
                var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);
                //

                //Calculo percepcion
                decimal totalValorPercepcion = VwNotacreditoclidetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                //
                rImportetotalpercepcion.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalValorPercepcion : totalValorPercepcion * factorImpuesto, 2);
                rTotalgravado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado / factorImpuesto : totalgravado, 2);
                rTotalinafecto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalinafecto / factorImpuesto : totalinafecto, 2);
                rtotalexonerado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalexonerado / factorImpuesto : totalexonerado, 2);

                rTotalimpuesto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado - (decimal)rTotalgravado.EditValue : totalgravado * porcentajeImpuesto / 100, 2);
                rImportetotal.EditValue = (decimal)rTotalgravado.EditValue + (decimal)rTotalinafecto.EditValue + (decimal)rtotalexonerado.EditValue + (decimal)rTotalimpuesto.EditValue;
                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rImportetotalpercepcion.EditValue;


            }

            gvDetalle.EndDataUpdate();

            gvDetalle.BestFitColumns(true);
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                TipoCpMnt = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSerieDoc.EditValue = vwTipocp.Seriecp;
                        rNumeroDoc.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroDoc.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroDoc.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroDoc.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroDoc.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroDoc.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieDoc.EditValue = @"0000";
                rNumeroDoc.EditValue = 0;
            }
        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwNotacreditoclidet item = (VwNotacreditoclidet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idnotacreditocli <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
            switch (tipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //item.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                    //item.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //item.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                    //item.Lastmodified = DateTime.Now;
                    break;
            }

            switch (e.Column.FieldName)
            {
                case "Cantidad":
                case "Preciounitario":
                case "Descuento1":
                case "Descuento2":
                case "Descuento3":
                case "Descuento4":
                    CalculaItem1(item);
                    SumarTotales();
                    break;
                case "Importetotal":
                    CalculaItem2(item);
                    SumarTotales();
                    break;
                case "Porcentajepercepcion":
                    SumarTotales();
                    break;
            }

            if (gvDetalle.FocusedColumn.FieldName == "Cantidad")
            {
                //VwOrdendeventadet vwOrdendeventadet = Service.GetVwOrdendeventadet(x => x.IdOrdendeventadet == item.IdOrdendeventadet);
                //decimal cantidadAnterior = vwOrdendeventadet.Cantidad;
                //if (item.IdOrdendeventadet > 0
                //    && Service.CantidadReferenciasItemOrdendeventa(item.IdOrdendeventadet) > 0)
                //{
                //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                //        MessageBoxIcon.Exclamation);
                //    item.Cantidad = cantidadAnterior;
                //    gvDetalle.RefreshRowCell(gvDetalle.FocusedRowHandle, gvDetalle.FocusedColumn);
                //    CalculaItem1(item);
                //    SumarTotales();
                //    //gvDetalle.RefreshRowCell(gvDetalle.FocusedRowHandle, gvDetalle.FocusedColumn);
                //}
            }
        }
        private void CalculaItem1(VwNotacreditoclidet item)
        {
            //VwOrdendeventadet item = (VwOrdendeventadet)gvDetalle.GetFocusedRow();

            decimal precioUnitarioNeto = item.Preciounitario * (1 - item.Descuento1 / 100) * (1 - item.Descuento2 / 100) *
                                      (1 - item.Descuento3 / 100) * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwNotacreditoclidet item)
        {
            //VwOrdendeventadet item = (VwOrdendeventadet)gvDetalle.GetFocusedRow();

            item.Preciounitarioneto = item.Cantidad == 0 ? 0 : item.Importetotal / item.Cantidad;
            decimal precioUnitario = item.Preciounitarioneto * 100 / (100 - item.Descuento4);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento3);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento2);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento1);
            item.Preciounitario = precioUnitario;
            item.Importetotal = Decimal.Round(item.Cantidad * item.Preciounitario, 2);
            item.DataEntityState = DataEntityState.Modified;
            
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object) DateTime.Now : null;
        }
        private void HabilitarBotonesMnt(bool enabled)
        {
            BarMnt.BeginUpdate();
            foreach (BarItem item in bmMantenimiento.Items)
            {
                item.Enabled = enabled;
            }
            BarMnt.EndUpdate();
            btnCerrar.Enabled = !enabled;
            btnImprimir.Enabled = !enabled;
            btnActualizar.Enabled = !enabled;

            BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItems.EndUpdate();

        }
        private void iIdCliente_EditValueChanged(object sender, EventArgs e)
        {
            //var idSocioNegocioMnt = iIdcliente.EditValue;
            //if (idSocioNegocioMnt == null || (int)idSocioNegocioMnt <= 0) return;

            //VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int)idSocioNegocioMnt);
            //if (vwSocionegocioSel != null)
            //{
            //    beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
            //    iIdcliente.EditValue = vwSocionegocioSel.Idsocionegocio;
            //}

            //CargarDatosSocioNegocio();
        }
        private void ObtenerTipoDeCambioVentaSunat()
        {

            

        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        CargarDatosSocioNegocio(buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio);
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        CargarDatosSocioNegocio(socionegocioMntFrm.IdEntidadMnt);
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdcliente.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            CargarDatosSocioNegocio(socionegocioMntFrm.IdEntidadMnt);
                        }
                    }
                    break;
            }
        }
        private void CargarDatosSocioNegocio(int idSocioNegocio)
        {

            VwSocionegocioSel = Service.GetVwSocionegocio(idSocioNegocio);

            if (VwSocionegocioSel != null)
            {
                beSocioNegocio.Text = VwSocionegocioSel.Razonsocial.Trim();
                iIdcliente.EditValue = VwSocionegocioSel.Idsocionegocio;
                //iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                iIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
                //iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
                CargarDirecciones();
            }

        }
        private void CargarDirecciones()
        {
            if (VwSocionegocioSel != null)
            {
                string whereDireccionSocio = string.Format("idsocionegocio = '{0}'", VwSocionegocioSel.Idsocionegocio);
                iIddireccionfacturacion.Properties.DataSource = Service.GetAllSocionegociodireccion(whereDireccionSocio, "Direccionsocionegocio");
                iIddireccionfacturacion.Properties.DisplayMember = "Direccionsocionegocio";
                iIddireccionfacturacion.Properties.ValueMember = "Idsocionegociodireccion";
                iIddireccionfacturacion.Properties.BestFitMode = BestFitMode.BestFit;

                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    int idDireccionPrincipal = Service.GetIdDireccionPrincipal(VwSocionegocioSel.Idsocionegocio);
                    if (idDireccionPrincipal > 0)
                    {
                        iIddireccionfacturacion.EditValue = idDireccionPrincipal;
                    }
                }
            }
        }
    }    
}