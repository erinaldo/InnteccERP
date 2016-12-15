using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ValorizacionproveedorMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ValorizacionproveedorFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Valorizacionproveedor ValorizacionproveedorMnt { get; set; }
      
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwEquipo> VwEquipoList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwValorizacionproveedordet> VwValorizacionproveedordetList { get; set; }
        public List<VwValorizacionegresoproveedor> VwValorizacionegresoproveedorList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }

        private static readonly HelperDb HelperDb = new HelperDb();
        public ValorizacionproveedorMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ValorizacionproveedorFrm formParent) 
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
        private void ValorizacionproveedorMntFrm_Load(object sender, EventArgs e)
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

            iFechavalorizacion.EditValue = SessionApp.DateServer;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
            //iIdempleado.Enabled = false;
            iDiames.EditValue = 30;
           
            iFechavalorizacion.EditValue = SessionApp.DateServer;
            iFechainicio.EditValue = SessionApp.DateServer;
            iFechafinal.EditValue = SessionApp.DateServer;
            iFechaingreso.EditValue = SessionApp.DateServer;
            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "VALORIZA-PROV";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                }

            }
            VwTipocp vwTipocpLast = VwTipocpList.FirstOrDefault();
            iIdtipocp.EditValue = vwTipocpLast != null ? vwTipocpLast.Idtipocp : 0;
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
                    iIdtipomoneda.Enabled = false;
                    ValorizacionproveedorMnt = new Valorizacionproveedor();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdtipomoneda.Enabled = false;
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    

                    break;
            }           
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "VALORIZA-PROV", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
            
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            ImpuestoList = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DataSource = ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;
            
            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereProyecto = string.Format("idsucursal = '{0}'", UsuarioAutenticado.SucursalSel.Idsucursal);
            iIdproyecto.Properties.DataSource = Service.GetAllVwProyecto("Nombreproyecto");
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            VwEquipoList = Service.GetAllVwEquipo("Nombreequipo");
            iIdequipo.Properties.DataSource = VwEquipoList;
            iIdequipo.Properties.DisplayMember = "Nombreequipo";
            iIdequipo.Properties.ValueMember = "Idequipo";
            iIdequipo.Properties.BestFitMode = BestFitMode.BestFit;

           
            iIdtipoalquiler.Properties.DataSource = Service.GetAllTipoalquiler("Nombretipoalquiler");
            iIdtipoalquiler.Properties.DisplayMember = "Nombretipoalquiler";
            iIdtipoalquiler.Properties.ValueMember = "Idtipoalquiler";
            iIdtipoalquiler.Properties.BestFitMode = BestFitMode.BestFit;
          

        }
        private void TraerDatos()
        {
            try
            {

                ValorizacionproveedorMnt = Service.GetValorizacionproveedor(IdEntidadMnt);

                iIdtipocp.EditValue = ValorizacionproveedorMnt.Idtipocp;
                rSerievalorizacion.EditValue = ValorizacionproveedorMnt.Serievalorizacion;
                rNumerovalorizacion.EditValue = ValorizacionproveedorMnt.Numerovalorizacion;
                iFechavalorizacion.EditValue = ValorizacionproveedorMnt.Fechavalorizacion;
                iFechainicio.EditValue = ValorizacionproveedorMnt.Fechainicio;
                iFechafinal.EditValue = ValorizacionproveedorMnt.Fechafinal;
                iIdsocionegocio.EditValue = ValorizacionproveedorMnt.Idsocionegocio;
                CargarDatosSocioNegocio(ValorizacionproveedorMnt.Idsocionegocio);
                iIdproyecto.EditValue = ValorizacionproveedorMnt.Idproyecto;
                iIdequipo.EditValue = ValorizacionproveedorMnt.Idequipo;
                iIdtipoalquiler.EditValue = ValorizacionproveedorMnt.Idtipoalquiler;
                iEsmaquinaseca.EditValue = ValorizacionproveedorMnt.Esmaquinaseca;
                iEsmaquinaconductor.EditValue = ValorizacionproveedorMnt.Esmaquinaconductor;
                iImportetarifa.EditValue = ValorizacionproveedorMnt.Importetarifa;
                iHoraminima.EditValue = ValorizacionproveedorMnt.Horaminima;
                iFechaingreso.EditValue = ValorizacionproveedorMnt.Fechaingreso;
                rTotalhorometro.EditValue = ValorizacionproveedorMnt.Totalhorometro;
                rTotaldescuentohorometro.EditValue = ValorizacionproveedorMnt.Totaldescuentohorometro;
                rTotalhorometroreal.EditValue = ValorizacionproveedorMnt.Totalhorometroreal;
                rTotalvalorizado.EditValue = ValorizacionproveedorMnt.Totalhorometrominimo;
                rTotaldiastrabajo.EditValue = ValorizacionproveedorMnt.Totaldiastrabajo;
                rTotalvalorizado.EditValue = ValorizacionproveedorMnt.Totalvalorizado;
                rTotaldescuento.EditValue = ValorizacionproveedorMnt.Totaldescuento;
                rTotalimpuesto.EditValue = ValorizacionproveedorMnt.Totalimpuesto;
                iPorcentajedetraccion.EditValue = ValorizacionproveedorMnt.Porcentajedetraccion;
                iTotaldetraccion.EditValue = ValorizacionproveedorMnt.Totaldetraccion;
                rTotaldocumento.EditValue = ValorizacionproveedorMnt.Totaldocumento;
                rIdsucursal.EditValue = ValorizacionproveedorMnt.Idsucursal;
                iAnulado.EditValue = ValorizacionproveedorMnt.Anulado;
                iFechaanulado.EditValue = ValorizacionproveedorMnt.Fechaanulado;
                iTipocambio.EditValue = ValorizacionproveedorMnt.Tipocambio;
                iIdtipomoneda.EditValue = ValorizacionproveedorMnt.Idtipomoneda;
                iIdimpuesto.EditValue = ValorizacionproveedorMnt.Idimpuesto;
                iGlosavalorizacion.EditValue = ValorizacionproveedorMnt.Glosavalorizacion;
                iIdempleado.EditValue = ValorizacionproveedorMnt.Idempleado;
                iIdordenserviciodet.EditValue = ValorizacionproveedorMnt.Idordenserviciodet;
                iDiames.EditValue = ValorizacionproveedorMnt.Diames;

                CargarDatosOrdenServicio();

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

            string where = string.Format("idvalorizacionproveedor = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwValorizacionproveedordetList = Service.GetAllVwValorizacionproveedordet(where, "numeroitem");
            gcDetalle.DataSource = VwValorizacionproveedordetList;   
            CargarDetalleEgresos();
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private void CargarDetalleEgresos()
        {
            string where = string.Format("idvalorizacionproveedor = '{0}'", IdEntidadMnt);
            gcDetDato.BeginUpdate();
            VwValorizacionegresoproveedorList = Service.GetAllVwValorizacionegresoproveedor(where, "idvalorizacionegresoproveedor");
            gcDetDato.DataSource = VwValorizacionegresoproveedorList;
            gvDetDato.BestFitColumns();
            gcDetDato.EndUpdate();
        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            ValorizacionproveedorMnt.Idtipocp = (int)iIdtipocp.EditValue;
            ValorizacionproveedorMnt.Serievalorizacion = rSerievalorizacion.Text.Trim();
            ValorizacionproveedorMnt.Numerovalorizacion = rNumerovalorizacion.Text.Trim();
            ValorizacionproveedorMnt.Fechavalorizacion = (DateTime)iFechavalorizacion.EditValue;
            ValorizacionproveedorMnt.Fechainicio = (DateTime)iFechainicio.EditValue;
            ValorizacionproveedorMnt.Fechafinal = (DateTime)iFechafinal.EditValue;
            ValorizacionproveedorMnt.Idsocionegocio = (int)iIdsocionegocio.EditValue;
            ValorizacionproveedorMnt.Idproyecto = (int)iIdproyecto.EditValue;
            ValorizacionproveedorMnt.Idequipo = (int)iIdequipo.EditValue;
            ValorizacionproveedorMnt.Idtipoalquiler = (int)iIdtipoalquiler.EditValue;
            ValorizacionproveedorMnt.Esmaquinaseca = (bool)iEsmaquinaseca.EditValue;
            ValorizacionproveedorMnt.Esmaquinaconductor = (bool)iEsmaquinaconductor.EditValue;
            ValorizacionproveedorMnt.Importetarifa = (decimal)iImportetarifa.EditValue;
            ValorizacionproveedorMnt.Horaminima = (decimal)iHoraminima.EditValue;
            ValorizacionproveedorMnt.Fechaingreso = (DateTime)iFechaingreso.EditValue;
            ValorizacionproveedorMnt.Totalhorometro = (decimal)rTotalhorometro.EditValue;
            ValorizacionproveedorMnt.Totaldescuentohorometro = (decimal)rTotaldescuentohorometro.EditValue;
            ValorizacionproveedorMnt.Totalhorometroreal = (decimal)rTotalhorometroreal.EditValue;
            ValorizacionproveedorMnt.Totalhorometrominimo = (decimal)rTotalhorometrominimo.EditValue;
            ValorizacionproveedorMnt.Totaldiastrabajo = (decimal)rTotaldiastrabajo.EditValue;
            ValorizacionproveedorMnt.Totalvalorizado = (decimal)rTotalvalorizado.EditValue;
            ValorizacionproveedorMnt.Totaldescuento = (decimal)rTotaldescuento.EditValue;
            ValorizacionproveedorMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            ValorizacionproveedorMnt.Porcentajedetraccion = (decimal)iPorcentajedetraccion.EditValue;
            ValorizacionproveedorMnt.Totaldetraccion = (decimal)iTotaldetraccion.EditValue;
            ValorizacionproveedorMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            ValorizacionproveedorMnt.Idsucursal = (int)rIdsucursal.EditValue;
            ValorizacionproveedorMnt.Anulado = (bool)iAnulado.EditValue;
            ValorizacionproveedorMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            ValorizacionproveedorMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            ValorizacionproveedorMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            ValorizacionproveedorMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            ValorizacionproveedorMnt.Glosavalorizacion = iGlosavalorizacion.Text.Trim();
            ValorizacionproveedorMnt.Idempleado = (int?)iIdempleado.EditValue;
            ValorizacionproveedorMnt.Idordenserviciodet = (int?)iIdordenserviciodet.EditValue;
            ValorizacionproveedorMnt.Diames = (int?)iDiames.EditValue;


            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //ValorizacionMnt.Createdby = IdUsuario;
                    //ValorizacionMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                  //  ValorizacionMnt.Modifiedby = IdUsuario;
                   // ValorizacionMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                        if (Service.GuardarValorizacionProveedor(TipoMnt, ValorizacionproveedorMnt, VwValorizacionproveedordetList))
                    {
                        IdEntidadMnt = ValorizacionproveedorMnt.Idvalorizacionproveedor;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarValorizacionProveedor(TipoMnt, ValorizacionproveedorMnt, VwValorizacionproveedordetList);
                    break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerievalorizacion.Text.Trim(),rNumerovalorizacion.Text.Trim());
                Cursor = Cursors.Default;

                if (tcCotizaCliente.SelectedTabPage == tpLogistica)
                {
                    tcCotizaCliente.SelectedTabPage = tpValorizacion;
                }

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
            //int idSucursal = (int)rIdsucursal.EditValue;
            //int idEmpleado = (int)iIdempleado.EditValue;
            //const string nombreTipodocMov = "Valorizacion";
            //int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;

            //Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
            //    0);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpValorizacion, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpValorizacion;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpLogistica, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpLogistica;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }


            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwValorizacionproveedordetList.Where(x => x.Horometroinicio <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Fecha + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con Horometro inicial con valor cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwValorizacionproveedordetList.Where(x => x.Horometrofinal <= 0);
            string msgItemPreUni = itemsPrecioUniInvalido.Aggregate(string.Empty, (current, item) => current + "-" + item.Fecha + "\n");
            if (!string.IsNullOrEmpty(msgItemPreUni))
            {
                XtraMessageBox.Show("Existe items con Horometro Final con valor cero verifique: \n\n" + msgItemPreUni, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return false;
            }        


            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSerievalorizacion.Text.Trim();
            string numeroViaje = rNumerovalorizacion.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroValorizacionExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
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
                        Service.DeleteValorizacion(IdEntidadMnt);
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

                    ValorizacionproveedorMnt = null;
                    ValorizacionproveedorMnt = new Valorizacionproveedor();

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
                        ValorizacionproveedorMnt = null;
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
                        ImpresionFormato.FormatoValorizacionProveedor(ValorizacionproveedorMnt);
                    }
                    break;
                case "btnOrdenventa":

                    var idClienteSel = (int)iIdsocionegocio.EditValue;
                    if (idClienteSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el Proveedor.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        iIdsocionegocio.Select();
                        return;
                    }

                    var vwSocionegocioSel = Service.GetVwSocionegocio(x => x.Idsocionegocio == (int)iIdsocionegocio.EditValue);

                    ValorizacionproveedorImpOrdenservicioFrm valorizacionProveedorImpOrdenventaFrm = new ValorizacionproveedorImpOrdenservicioFrm(vwSocionegocioSel);
                    valorizacionProveedorImpOrdenventaFrm.ShowDialog();

                    if (valorizacionProveedorImpOrdenventaFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdendeserviciodetvalorizaimp vwOrdendeserviciodetvalorizaimpSelImp = valorizacionProveedorImpOrdenventaFrm.VwOrdendeserviciodetvalorizaimpSel;
                        if (vwOrdendeserviciodetvalorizaimpSelImp != null){

                            iIdordenserviciodet.EditValue = vwOrdendeserviciodetvalorizaimpSelImp.Idordenserviciodet;
                            iIdtipomoneda.EditValue = vwOrdendeserviciodetvalorizaimpSelImp.Idtipomoneda;
                            iIdequipo.EditValue = vwOrdendeserviciodetvalorizaimpSelImp.Idequipo;
                            iImportetarifa.EditValue = vwOrdendeserviciodetvalorizaimpSelImp.Preciounitarioneto;
                            iIdproyecto.EditValue = vwOrdendeserviciodetvalorizaimpSelImp.Idproyecto;
                            CargarDatosOrdenServicio();
                            iIdproyecto.Enabled = false;

                        }
                       
                    }
                    break;
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
        private void ValorizacionproveedorMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpValorizacion, readOnly);
            WinFormUtils.ReadOnlyFields(tpLogistica, readOnly);        
        }
        private void ValorizacionproveedorMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            ValorizacionproveedorMntItemFrm valorizacionMntItemFrm;
            VwValorizacionproveedordet vwValorizacionproveedordetMntItem;
            DatosvalorizacionProveedor.FechaFinal = (DateTime) iFechafinal.EditValue;
            DatosvalorizacionProveedor.HorasMinima = (decimal) iHoraminima.EditValue;
            DatosvalorizacionProveedor.Diames = (int)iDiames.EditValue;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if ((decimal)iHoraminima.EditValue == 0m)
                    {
                        XtraMessageBox.Show("Ingrese Horas Minima", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tcContenido.SelectedTabPage = tpLogistica;
                        break;
                    }
                    if ((decimal)iImportetarifa.EditValue == 0m)
                    {
                        XtraMessageBox.Show("Ingrese Importe Tarifa", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tcContenido.SelectedTabPage = tpLogistica;

                        break;
                    }
                    //Asignar el siguiente item
                    vwValorizacionproveedordetMntItem = new VwValorizacionproveedordet();

                    //Asignar el siguiente item
                    var sgtItem = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwValorizacionproveedordetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;
                    if (sgtItem != null)
                    {
                        DateTime ultFecha = sgtItem.Fecha;
                        DateTime sgtFecha = ultFecha.AddDays(1);
                        vwValorizacionproveedordetMntItem.Fecha = sgtFecha;
                        vwValorizacionproveedordetMntItem.Turno = sgtItem.Turno;
                        vwValorizacionproveedordetMntItem.Horometroinicio = sgtItem.Horometrofinal;
                        vwValorizacionproveedordetMntItem.Idcentrodecosto = sgtItem.Idcentrodecosto;
                    }
                    
                        tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                        valorizacionMntItemFrm = new ValorizacionproveedorMntItemFrm(tipoMantenimientoItem, vwValorizacionproveedordetMntItem);
                        valorizacionMntItemFrm.IdcentroCosto = (int) iIdcentrocosto.EditValue;
                        valorizacionMntItemFrm.ShowDialog();
                    if (valorizacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizacionproveedordetList.Add(vwValorizacionproveedordetMntItem);
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


                    //itemSel = (VwValorizaciondet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdValorizaciondet > 0
                    //&& Service.CantidadReferenciasItemValorizacion(itemSel.IdValorizaciondet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    vwValorizacionproveedordetMntItem = (VwValorizacionproveedordet) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    valorizacionMntItemFrm = new ValorizacionproveedorMntItemFrm(tipoMantenimientoItem, vwValorizacionproveedordetMntItem);
                    valorizacionMntItemFrm.IdcentroCosto = (int)iIdcentrocosto.EditValue;
                    valorizacionMntItemFrm.ShowDialog();
                    if (valorizacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    //itemSel = (VwValorizaciondet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdValorizaciondet > 0
                    //&& Service.CantidadReferenciasItemValorizacion(itemSel.IdValorizaciondet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwValorizacionproveedordetMntItem = (VwValorizacionproveedordet)gvDetalle.GetFocusedRow();
                        vwValorizacionproveedordetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }

                        SumarTotales();
                                              
                    }
                    break;
            }
            
        }
        private void SumarTotales()
        {            
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();

            var totalHmini = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometroinicio);
           
            var totalHmDia = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrodia);
            rTotalhorometro.EditValue = totalHmDia;

            var totalHmDsc = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Descuentohorometro);
            rTotaldescuentohorometro.EditValue = totalHmDsc;

            var totalHmReal = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrorealdia);
            rTotalhorometroreal.EditValue = totalHmReal;

            var totalHmMin = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrominimo);
            rTotalhorometrominimo.EditValue = totalHmMin;

            var totalDiasTrb = VwValorizacionproveedordetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Diastrabajo);
            rTotaldiastrabajo.EditValue = totalDiasTrb;

            var totalDesc = VwValorizacionegresoproveedorList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotaldescuento.EditValue = totalDesc;

            decimal totalTarifa = (decimal)iImportetarifa.EditValue;
            decimal totalGravado = 0m;

            if (totalHmini != 0)
            {
                if (totalHmReal < totalHmMin)
                {
                    totalGravado = Decimal.Round(totalHmMin * totalTarifa, 2) - totalDesc;
                }
                else
                {
                    totalGravado = Decimal.Round(totalHmReal * totalTarifa, 2) - totalDesc;
                }
            }
            else
            {
               // var diasMes = ((DateTime) iFechafinal.EditValue - (DateTime) iFechainicio.EditValue).TotalDays;
                var diasMes =(int)iDiames.EditValue;

                if (diasMes > 0)
                {
                    totalGravado = Decimal.Round((totalTarifa / (decimal)diasMes) * totalDiasTrb, 2);
                }
                
            }


            rTotalvalorizado.EditValue = totalGravado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            decimal porcentajeImpuesto = 0m;
            if (impuestoSel != null)
            {
                porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                rTotalimpuesto.EditValue = decimal.Round(totalGravado * (porcentajeImpuesto / 100), 2);
            }
            CalcularDetraccion();
           
            gvDetalle.EndDataUpdate();

            gvDetalle.BestFitColumns(true);
        }
        private void CalcularHorometro()
        {


            foreach (var item in VwValorizacionproveedordetList.Where(x=>x.DataEntityState != DataEntityState.Deleted))
            {

                var hinicial = item.Horometroinicio;
                var hfinal = item.Horometrofinal;
                var hdia = Decimal.Round(hfinal - hinicial, 2);
                var hdes = item.Descuentohorometro;
                var hreal = hdia - hdes;
                var valHrsMinMes = (decimal)iHoraminima.EditValue;
                var diasmes = (int)iDiames.EditValue;
                var valHrsMinDia = Decimal.Round(valHrsMinMes / diasmes, 2);

                item.Horometrodia = hdia;
                item.Horometrorealdia = hreal;
                item.Horometrominimo = valHrsMinDia;
                if (hdia == 0)
                {
                    item.Diastrabajo = 0m;
                }
                else
                {
                    item.Diastrabajo = 1m;
                }
                item.DataEntityState = DataEntityState.Modified;
            }
          
          
            gcDetalle.RefreshDataSource();
            gvDetalle.RefreshData();
        }
        private void CalcularDetraccion()
        {
            var totalvaloriza = ((decimal) rTotalvalorizado.EditValue + (decimal) rTotalimpuesto.EditValue);
            var procentajedetraccion = (decimal) iPorcentajedetraccion.EditValue;
            var detraccion = decimal.Round(totalvaloriza*(procentajedetraccion/100), 2);
            iTotaldetraccion.EditValue = detraccion;

            rTotaldocumento.EditValue = totalvaloriza - detraccion;
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
                var vwTipocp = Service.GetVwTipocp((int) idTipocp);
                TipoCpMnt = vwTipocp;
                if (vwTipocp != null)
                {
                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            rSerievalorizacion.EditValue = vwTipocp.Seriecp;
                            rNumerovalorizacion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                            rNumerovalorizacion.EditValue = vwTipocp.Numerocorrelativocp;
                            rNumerovalorizacion.TabStop = !vwTipocp.Numeracionauto;
                            break;
                        case TipoMantenimiento.Modificar:
                            rNumerovalorizacion.EditValue = vwTipocp.Numerocorrelativocp;
                            rNumerovalorizacion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                            rNumerovalorizacion.TabStop = !vwTipocp.Numeracionauto;
                            break;
                    }
                }
            }
            else
            {
                rSerievalorizacion.EditValue = @"0000";
                rNumerovalorizacion.EditValue = 0;
            }
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

        private void ObtenerTipoDeCambioVentaSunat()
        {

            

        }

        private void iIdequipo_EditValueChanged(object sender, EventArgs e)
        {
            var idEquipoSel = iIdequipo.EditValue;
            VwEquipo vwEquipoSel = VwEquipoList.FirstOrDefault(x => x.Idequipo == (int)idEquipoSel);
            if (vwEquipoSel != null)
                {
                    iCodigoequipo.EditValue = vwEquipoSel.Codigoequipo;
                    iNombremarcaequipo.EditValue = vwEquipoSel.Nombremarcaequipo;
                    iNombremodeloequipo.EditValue = vwEquipoSel.Nombremodeloequipo;
                    iColorequipo.EditValue = vwEquipoSel.Colorequipo;
                    iCapacidadequipo.EditValue = vwEquipoSel.Capacidadequipo;
                    iNumeroserieequipo.EditValue = vwEquipoSel.Numeroserieequipo;
                    iPlacaequipo.EditValue = vwEquipoSel.Placaequipo;
                    iHoraminima.EditValue = vwEquipoSel.Horaminima;
                    iIdcentrocosto.EditValue = vwEquipoSel.Idcentrocosto;

                }
            
        }

        private void bmItemsEgreso_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            ValorizacionegresoproveedorMntItemFrm valorizacionegresoMntItemFrm;
            VwValorizacionegresoproveedor vwValorizacionegresoMnt = new VwValorizacionegresoproveedor();

            Valorizacionegresoproveedor valorizacionegresoMnt;

            switch (e.Item.Name)
            {
                case "btnAddEgreso":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                   // vwValorizacionegresoMnt.Idtipoegresovalorizacion = rRazonsocial.Text;

                    valorizacionegresoMntItemFrm = new ValorizacionegresoproveedorMntItemFrm(tipoMantenimientoItem, vwValorizacionegresoMnt);
                    valorizacionegresoMntItemFrm.ShowDialog();

                    if (valorizacionegresoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizacionegresoproveedorList.Add(vwValorizacionegresoMnt);

                        valorizacionegresoMnt = new Valorizacionegresoproveedor
                        {
                            Idvalorizacionproveedor = IdEntidadMnt,
                            Idtipoegresovalorizacion = vwValorizacionegresoMnt.Idtipoegresovalorizacion,
                            Cantidad = vwValorizacionegresoMnt.Cantidad,
                            Preciounitario = vwValorizacionegresoMnt.Preciounitario,
                            Importetotal = vwValorizacionegresoMnt.Importetotal
                        };

                        Service.SaveValorizacionegresoproveedor(valorizacionegresoMnt);

                        CargarDetalleEgresos();
                        SumarTotales();

                    }

                    break;

                case "btnEditEgreso":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwValorizacionegresoMnt = (VwValorizacionegresoproveedor)gvDetDato.GetFocusedRow();

                    if (vwValorizacionegresoMnt == null)
                    {
                        break;
                    }
                    valorizacionegresoMntItemFrm = new ValorizacionegresoproveedorMntItemFrm(tipoMantenimientoItem, vwValorizacionegresoMnt);
                    valorizacionegresoMntItemFrm.ShowDialog();

                    if (valorizacionegresoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        valorizacionegresoMnt = new Valorizacionegresoproveedor
                        {
                            Idvalorizacionegresoproveedor = vwValorizacionegresoMnt.Idvalorizacionegresoproveedor,
                            Idvalorizacionproveedor = IdEntidadMnt,
                            Idtipoegresovalorizacion = vwValorizacionegresoMnt.Idtipoegresovalorizacion,
                            Cantidad = vwValorizacionegresoMnt.Cantidad,
                            Preciounitario = vwValorizacionegresoMnt.Preciounitario,
                            Importetotal = vwValorizacionegresoMnt.Importetotal
                        };

                        Service.UpdateValorizacionegresoproveedor(valorizacionegresoMnt);

                        CargarDetalleEgresos();
                        SumarTotales();
                    }

                    break;

                case "btnDelEgreso":
                    int idvalorizacionegreso = Convert.ToInt32(gvDetDato.GetRowCellValue(gvDetDato.FocusedRowHandle, "Idvalorizacionegreso"));

                    if (idvalorizacionegreso > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            Service.DeleteValorizacionegresoproveedor(idvalorizacionegreso);
                            CargarDetalleEgresos();
                            SumarTotales();
                        }
                    }
                    break;
            }
        }

        private void tcCotizaCliente_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosOrdenServicio()
        {

            VwOrdenserviciodet vwOrdenserviciodet = Service.GetVwOrdenserviciodet(x => x.Idordenserviciodet == (int)iIdordenserviciodet.EditValue);

            if (vwOrdenserviciodet != null)
            {
                rSerie.EditValue = vwOrdenserviciodet.Serieorden;
                iNumero.EditValue = vwOrdenserviciodet.Numeroorden;
            }

        }

        private void iPorcentajedetraccion_EditValueChanged(object sender, EventArgs e)
        {
            CalcularDetraccion();
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
                    var idSocioNegocioMnt = iIdsocionegocio.EditValue;
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
                iIdsocionegocio.EditValue = VwSocionegocioSel.Idsocionegocio;
                string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", VwSocionegocioSel.Idsocionegocio); 
                iIdproyecto.Properties.DataSource = Service.GetAllVwSocionegocioproyecto(whereSocioNegocio, "Nombreproyecto");
                iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
                iIdproyecto.Properties.ValueMember = "Idproyecto";
                iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            }
        }

        private void iDiames_EditValueChanged(object sender, EventArgs e)
        {
            if (VwValorizacionproveedordetList != null)
            {
                CalcularHorometro();
                SumarTotales();
            }

        }

    }
    
    public static class DatosvalorizacionProveedor
    {
        public static DateTime FechaFinal { get; set; }
        public static decimal HorasMinima { get; set; }
        public static int Diames { get; set; }

    }
}