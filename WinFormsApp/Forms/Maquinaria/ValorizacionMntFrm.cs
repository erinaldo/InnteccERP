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
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ValorizacionMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ValorizacionFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Valorizacion ValorizacionMnt { get; set; }
      
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwEquipo> VwEquipoList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwValorizaciondet> VwValorizaciondetList { get; set; }
        public List<VwValorizacionegreso> VwValorizacionegresoList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }

        public ValorizacionMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ValorizacionFrm formParent) 
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
        private void ValorizacionMntFrm_Load(object sender, EventArgs e)
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
                const string nombreTipodocMov = "VALORIZA-VENTA";
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
                    ValorizacionMnt = new Valorizacion();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoReferenciaCpventa();
                    iIdtipomoneda.Enabled = false;
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                  //  
                    

                    break;
            }           
        }
        private void EstadoReferenciaCpventa()
        {
            if (Service.ValorizacionTieneReferenciaCpventa(IdEntidadMnt))
            {
                XtraMessageBox.Show("La Valorizacion tiene Documento de Venta", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "VALORIZA-VENTA", SessionApp.SucursalSel.Idsucursal);
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

                ValorizacionMnt = Service.GetValorizacion(IdEntidadMnt);

                iIdtipocp.EditValue = ValorizacionMnt.Idtipocp;
                rSerievalorizacion.EditValue = ValorizacionMnt.Serievalorizacion;
                rNumerovalorizacion.EditValue = ValorizacionMnt.Numerovalorizacion;
                iFechavalorizacion.EditValue = ValorizacionMnt.Fechavalorizacion;
                iFechainicio.EditValue = ValorizacionMnt.Fechainicio;
                iFechafinal.EditValue = ValorizacionMnt.Fechafinal;
                iIdsocionegocio.EditValue = ValorizacionMnt.Idsocionegocio;
                CargarDatosSocioNegocio(ValorizacionMnt.Idsocionegocio);
                iIdproyecto.EditValue = ValorizacionMnt.Idproyecto;
                iIdequipo.EditValue = ValorizacionMnt.Idequipo;
                iIdtipoalquiler.EditValue = ValorizacionMnt.Idtipoalquiler;
                iEsmaquinaseca.EditValue = ValorizacionMnt.Esmaquinaseca;
                iEsmaquinaconductor.EditValue = ValorizacionMnt.Esmaquinaconductor;
                iImportetarifa.EditValue = ValorizacionMnt.Importetarifa;
                iHoraminima.EditValue = ValorizacionMnt.Horaminima;
                iFechaingreso.EditValue = ValorizacionMnt.Fechaingreso;
                rTotalhorometro.EditValue = ValorizacionMnt.Totalhorometro;
                rTotaldescuentohorometro.EditValue = ValorizacionMnt.Totaldescuentohorometro;
                rTotalhorometroreal.EditValue = ValorizacionMnt.Totalhorometroreal;
                rTotalvalorizado.EditValue = ValorizacionMnt.Totalhorometrominimo;
                rTotaldiastrabajo.EditValue = ValorizacionMnt.Totaldiastrabajo;
                rTotalvalorizado.EditValue = ValorizacionMnt.Totalvalorizado;
                rTotaldescuento.EditValue = ValorizacionMnt.Totaldescuento;
                rTotalimpuesto.EditValue = ValorizacionMnt.Totalimpuesto;
                iPorcentajedetraccion.EditValue = ValorizacionMnt.Porcentajedetraccion;
                iTotaldetraccion.EditValue = ValorizacionMnt.Totaldetraccion;
                rTotaldocumento.EditValue = ValorizacionMnt.Totaldocumento;
                rIdsucursal.EditValue = ValorizacionMnt.Idsucursal;
                iAnulado.EditValue = ValorizacionMnt.Anulado;
                iFechaanulado.EditValue = ValorizacionMnt.Fechaanulado;
                iTipocambio.EditValue = ValorizacionMnt.Tipocambio;
                iIdtipomoneda.EditValue = ValorizacionMnt.Idtipomoneda;
                iIdimpuesto.EditValue = ValorizacionMnt.Idimpuesto;
                iGlosavalorizacion.EditValue = ValorizacionMnt.Glosavalorizacion;
                iIdempleado.EditValue = ValorizacionMnt.Idempleado;
                iIdordendeventadet.EditValue = ValorizacionMnt.Idordendeventadet;
                iDiames.EditValue = ValorizacionMnt.Diames;

                CargarDatosOrdenVenta();

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

            string where = string.Format("idvalorizacion = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwValorizaciondetList = Service.GetAllVwValorizaciondet(where, "numeroitem");
            gcDetalle.DataSource = VwValorizaciondetList;   
            CargarDetalleEgresos();
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private void CargarDetalleEgresos()
        {
            string where = string.Format("idvalorizacion = '{0}'", IdEntidadMnt);
            gcDetDato.BeginUpdate();
            VwValorizacionegresoList = Service.GetAllVwValorizacionegreso(where, "idvalorizacionegreso");
            gcDetDato.DataSource = VwValorizacionegresoList;
            gvDetDato.BestFitColumns();
            gcDetDato.EndUpdate();
        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            ValorizacionMnt.Idtipocp = (int)iIdtipocp.EditValue;
            ValorizacionMnt.Serievalorizacion = rSerievalorizacion.Text.Trim();
            ValorizacionMnt.Numerovalorizacion = rNumerovalorizacion.Text.Trim();
            ValorizacionMnt.Fechavalorizacion = (DateTime)iFechavalorizacion.EditValue;
            ValorizacionMnt.Fechainicio = (DateTime)iFechainicio.EditValue;
            ValorizacionMnt.Fechafinal = (DateTime)iFechafinal.EditValue;
            ValorizacionMnt.Idsocionegocio = (int)iIdsocionegocio.EditValue;
            ValorizacionMnt.Idproyecto = (int)iIdproyecto.EditValue;
            ValorizacionMnt.Idequipo = (int)iIdequipo.EditValue;
            ValorizacionMnt.Idtipoalquiler = (int)iIdtipoalquiler.EditValue;
            ValorizacionMnt.Esmaquinaseca = (bool)iEsmaquinaseca.EditValue;
            ValorizacionMnt.Esmaquinaconductor = (bool)iEsmaquinaconductor.EditValue;
            ValorizacionMnt.Importetarifa = (decimal)iImportetarifa.EditValue;
            ValorizacionMnt.Horaminima = (decimal)iHoraminima.EditValue;
            ValorizacionMnt.Fechaingreso = (DateTime)iFechaingreso.EditValue;
            ValorizacionMnt.Totalhorometro = (decimal)rTotalhorometro.EditValue;
            ValorizacionMnt.Totaldescuentohorometro = (decimal)rTotaldescuentohorometro.EditValue;
            ValorizacionMnt.Totalhorometroreal = (decimal)rTotalhorometroreal.EditValue;
            ValorizacionMnt.Totalhorometrominimo = (decimal)rTotalhorometrominimo.EditValue;
            ValorizacionMnt.Totaldiastrabajo = (decimal)rTotaldiastrabajo.EditValue;
            ValorizacionMnt.Totalvalorizado = (decimal)rTotalvalorizado.EditValue;
            ValorizacionMnt.Totaldescuento = (decimal)rTotaldescuento.EditValue;
            ValorizacionMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            ValorizacionMnt.Porcentajedetraccion = (decimal)iPorcentajedetraccion.EditValue;
            ValorizacionMnt.Totaldetraccion = (decimal)iTotaldetraccion.EditValue;
            ValorizacionMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            ValorizacionMnt.Idsucursal = (int)rIdsucursal.EditValue;
            ValorizacionMnt.Anulado = (bool)iAnulado.EditValue;
            ValorizacionMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            ValorizacionMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            ValorizacionMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            ValorizacionMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            ValorizacionMnt.Glosavalorizacion = iGlosavalorizacion.Text.Trim();
            ValorizacionMnt.Idempleado = (int?)iIdempleado.EditValue;
            ValorizacionMnt.Idordendeventadet = (int?)iIdordendeventadet.EditValue;
            ValorizacionMnt.Diames = (int?)iDiames.EditValue;


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

                        if (Service.GuardarValorizacion(TipoMnt, ValorizacionMnt, VwValorizaciondetList))
                    {
                        IdEntidadMnt = ValorizacionMnt.Idvalorizacion;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarValorizacion(TipoMnt, ValorizacionMnt, VwValorizaciondetList);
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

            var itemsCantidadInvalida = VwValorizaciondetList.Where(x => x.Horometroinicio <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Fecha + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con Horometro inicial con valor cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwValorizaciondetList.Where(x => x.Horometrofinal <= 0);
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
                        Service.DeletePersona(IdEntidadMnt);
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

                    ValorizacionMnt = null;
                    ValorizacionMnt = new Valorizacion();

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
                        ValorizacionMnt = null;
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
                        ImpresionFormato.FormatoValorizacion(ValorizacionMnt);
                    }
                    break;
                case "btnElementosDeGastoDanios":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoElementoDesgasteDanio(ValorizacionMnt);
                    }
                    break;
                case "btnOrdenventa":

                    var idClienteSel = (int)iIdsocionegocio.EditValue;
                    if (idClienteSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el Cliente.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        iIdsocionegocio.Select();
                        return;
                    }

                    var vwSocionegocioSel = Service.GetVwSocionegocio(x => x.Idsocionegocio == (int)iIdsocionegocio.EditValue);

                    ValorizacionImpOrdenventaFrm valorizacionImpOrdenventaFrm = new ValorizacionImpOrdenventaFrm(vwSocionegocioSel);
                    valorizacionImpOrdenventaFrm.ShowDialog();

                    if (valorizacionImpOrdenventaFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdendeventadetvalorizaimp vwOrdendeventadetvalorizaimpSelImp = valorizacionImpOrdenventaFrm.VwOrdendeventadetvalorizaimpSel;
                        if (vwOrdendeventadetvalorizaimpSelImp != null){

                            iIdordendeventadet.EditValue = vwOrdendeventadetvalorizaimpSelImp.Idordendeventadet;
                            iIdtipomoneda.EditValue = vwOrdendeventadetvalorizaimpSelImp.Idtipomoneda;
                            iIdequipo.EditValue = vwOrdendeventadetvalorizaimpSelImp.Idequipo;
                            iImportetarifa.EditValue = vwOrdendeventadetvalorizaimpSelImp.Preciounitarioneto;
                            iIdproyecto.EditValue = vwOrdendeventadetvalorizaimpSelImp.Idproyecto;
                            CargarDatosOrdenVenta();
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
        private void ValorizacionMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ValorizacionMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            ValorizacionMntItemFrm valorizacionMntItemFrm;
            VwValorizaciondet vwValorizaciondetMntItem;
            Datosvalorizacion.FechaFinal = (DateTime) iFechafinal.EditValue;
            Datosvalorizacion.HorasMinima = (decimal) iHoraminima.EditValue;
            Datosvalorizacion.Diames = (int)iDiames.EditValue;
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
                    vwValorizaciondetMntItem = new VwValorizaciondet();

                    //Asignar el siguiente item
                    var sgtItem = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwValorizaciondetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;
                    if (sgtItem != null)
                    {
                        DateTime ultFecha = sgtItem.Fecha;
                        DateTime sgtFecha = ultFecha.AddDays(1);
                        vwValorizaciondetMntItem.Fecha = sgtFecha;
                        vwValorizaciondetMntItem.Turno = sgtItem.Turno;
                        vwValorizaciondetMntItem.Horometroinicio = sgtItem.Horometrofinal;
                        vwValorizaciondetMntItem.Idcentrodecosto = sgtItem.Idcentrodecosto;
                    }
                    
                        tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                        valorizacionMntItemFrm = new ValorizacionMntItemFrm(tipoMantenimientoItem, vwValorizaciondetMntItem);
                        valorizacionMntItemFrm.IdcentroCosto = (int) iIdcentrocosto.EditValue;
                        valorizacionMntItemFrm.ShowDialog();
                    if (valorizacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizaciondetList.Add(vwValorizaciondetMntItem);
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

                    vwValorizaciondetMntItem = (VwValorizaciondet) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    valorizacionMntItemFrm = new ValorizacionMntItemFrm(tipoMantenimientoItem, vwValorizaciondetMntItem);
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

                        vwValorizaciondetMntItem = (VwValorizaciondet)gvDetalle.GetFocusedRow();
                        vwValorizaciondetMntItem.DataEntityState = DataEntityState.Deleted;

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

            var totalHmini = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometroinicio);
           
            var totalHmDia = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrodia);
            rTotalhorometro.EditValue = totalHmDia;

            var totalHmDsc = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Descuentohorometro);
            rTotaldescuentohorometro.EditValue = totalHmDsc;

            var totalHmReal = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrorealdia);
            rTotalhorometroreal.EditValue = totalHmReal;

            var totalHmMin = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Horometrominimo);
            rTotalhorometrominimo.EditValue = totalHmMin;

            var totalDiasTrb = VwValorizaciondetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Diastrabajo);
            rTotaldiastrabajo.EditValue = totalDiasTrb;

            var totalDesc = VwValorizacionegresoList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotaldescuento.EditValue = totalDesc;

            var totalTarifa = (decimal)iImportetarifa.EditValue;
            decimal totalGravado = 0;

            if (totalHmini != 0)
            {
                if (totalHmReal < totalHmMin)
                {
                    totalGravado = Decimal.Round(totalHmMin * totalTarifa, 2) + totalDesc;
                }
                else
                {
                    totalGravado = Decimal.Round(totalHmReal * totalTarifa, 2) + totalDesc;
                }
            }
            else
            {
               // var diasMes = ((DateTime) iFechafinal.EditValue - (DateTime) iFechainicio.EditValue).TotalDays;
                var diasMes =(int)iDiames.EditValue;

                if (diasMes > 0)
                {
                    totalGravado = Decimal.Round((totalTarifa / diasMes) * totalDiasTrb, 2);
                }
                
            }


            rTotalvalorizado.EditValue = totalGravado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                rTotalimpuesto.EditValue = decimal.Round(totalGravado * (porcentajeImpuesto / 100), 2);
            }
            CalcularDetraccion();
           
            gvDetalle.EndDataUpdate();

            gvDetalle.BestFitColumns(true);
        }

        private void CalcularHorometro()
        {


            foreach (var item in VwValorizaciondetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
            {
                
                var hinicial = item.Horometroinicio;
                var hfinal = item.Horometrofinal;
                var hdia = Decimal.Round(hfinal - hinicial, 2);
                var hdes = item.Descuentohorometro;
                var hreal = hdia - hdes;
                var valHrsMinMes =(decimal) iHoraminima.EditValue;
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
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                TipoCpMnt = vwTipocp;
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
            btnElementosDeGastoDanios.Enabled = !enabled;
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
            ValorizacionegresoMntItemFrm valorizacionegresoMntItemFrm;
            var vwValorizacionegresoMnt = new VwValorizacionegreso();

            Valorizacionegreso valorizacionegresoMnt;

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

                    valorizacionegresoMntItemFrm = new ValorizacionegresoMntItemFrm(tipoMantenimientoItem, vwValorizacionegresoMnt);
                    valorizacionegresoMntItemFrm.ShowDialog();

                    if (valorizacionegresoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizacionegresoList.Add(vwValorizacionegresoMnt);

                        valorizacionegresoMnt = new Valorizacionegreso
                        {
                            Idvalorizacion = IdEntidadMnt,
                            Idtipoegresovalorizacion = vwValorizacionegresoMnt.Idtipoegresovalorizacion,
                            Cantidad = vwValorizacionegresoMnt.Cantidad,
                            Preciounitario = vwValorizacionegresoMnt.Preciounitario,
                            Importetotal = vwValorizacionegresoMnt.Importetotal
                        };

                        Service.SaveValorizacionegreso(valorizacionegresoMnt);

                        CargarDetalleEgresos();
                        SumarTotales();

                    }

                    break;

                case "btnEditEgreso":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwValorizacionegresoMnt = (VwValorizacionegreso)gvDetDato.GetFocusedRow();

                    if (vwValorizacionegresoMnt == null)
                    {
                        break;
                    }
                    valorizacionegresoMntItemFrm = new ValorizacionegresoMntItemFrm(tipoMantenimientoItem, vwValorizacionegresoMnt);
                    valorizacionegresoMntItemFrm.ShowDialog();

                    if (valorizacionegresoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        valorizacionegresoMnt = new Valorizacionegreso
                        {
                            Idvalorizacionegreso = vwValorizacionegresoMnt.Idvalorizacionegreso,
                            Idvalorizacion = IdEntidadMnt,
                            Idtipoegresovalorizacion = vwValorizacionegresoMnt.Idtipoegresovalorizacion,
                            Cantidad = vwValorizacionegresoMnt.Cantidad,
                            Preciounitario = vwValorizacionegresoMnt.Preciounitario,
                            Importetotal = vwValorizacionegresoMnt.Importetotal
                        };

                        Service.UpdateValorizacionegreso(valorizacionegresoMnt);

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
                            Service.DeleteValorizacionegreso(idvalorizacionegreso);
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

        private void CargarDatosOrdenVenta()
        {

            VwOrdendeventadet vwOrdendeventadet = Service.GetVwOrdendeventadetalle(x => x.Idordendeventadet == (int)iIdordendeventadet.EditValue);

            if (vwOrdendeventadet != null)
            {
                rSerie.EditValue = vwOrdendeventadet.Serieordenventa;
                iNumero.EditValue = vwOrdendeventadet.Numeroordenventa;
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
            if (VwValorizaciondetList != null)
            {
                CalcularHorometro();
                SumarTotales();

            }
            
        }

        private void iHoraminima_EditValueChanged(object sender, EventArgs e)
        {
            if (VwValorizaciondetList != null)
            {
                CalcularHorometro();
                SumarTotales();

            }
        }

    }
    
    public static class Datosvalorizacion
    {
        public static DateTime FechaFinal { get; set; }
        public static decimal HorasMinima { get; set; }
        public static int Diames { get; set; }

    }
}