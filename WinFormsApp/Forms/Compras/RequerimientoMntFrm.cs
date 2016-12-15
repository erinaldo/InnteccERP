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
    public partial class RequerimientoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }

        public DataEntityState DataEntityState { get; set; }
        public GridControl GridParent { get; set; }
        public RequerimientoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Requerimiento RequerimientoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwCptooperacion VwCptooperacionSel { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwEmpleadoarea> VwEmpleadoareaList { get; private set; }
        public List<VwEmpleadoareaproyecto> VwEmpleadoProyectoList { get; private set; }
        public List<Estadoreq> EstadoreqList { get; private set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public List<VwEmpleado> VwEmpleadoList { get; set; }
        public ImpresionFormato RequerimientoImpresion { get; set; }
        public List<Almacen> AlmacenList { get; set; }
        public RequerimientoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, RequerimientoFrm formParent) 
        {
            if (tipoMnt == TipoMantenimiento.SinEspecificar && idEntidadMnt <= 0)
            {
                throw new ArgumentException("El valor primario de la entidad no contiene un valor valido.");
            }

            InitializeComponent();

            IdEntidadMnt = idEntidadMnt;
            TipoMnt = tipoMnt;
            GridParent = gridParent;
            FormParent = formParent;

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;                       
        }        
        private void RequerimientoMntFrm_Load(object sender, EventArgs e)
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
            //iFechareq.EditValue = DateTime.Now;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            if (SessionApp.EmpleadoSel == null)
            {
                iIdempleado.EditValue = null;
                iIdempleado.Enabled = true;            
            }
            else
            {
                iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdempleado.Enabled = false;            
            }

            //Registrado
            iIdestadoreq.EditValue = 1;
            iFechareq.EditValue = SessionApp.DateServer;

            iIdtipolista.EditValue = SessionApp.SucursalSel.Idtipolistadefecto;

            iIdtipocp.Select();

            int? idAlmacenDefecto = SessionApp.SucursalSel.Idalmacendefecto;
            if (idAlmacenDefecto > 0)
            {
                iIdalmacen.EditValue = idAlmacenDefecto;
            }

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "REQUERIMIENTO";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }
            }            
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();      
                    CargarAreasDeEmpleado();

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    RequerimientoMnt = new Requerimiento();                    
                    CargarDetalle();

                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    CargarAreasDeEmpleado();
                    TraerDatos();
                    

                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();

                    EstablecerEstadoRequerimiento();
                    break;
            }
        }
        private void EstablecerEstadoRequerimiento()
        {
            Estadoreq estadoreq = EstadoreqList.FirstOrDefault(x => x.Idestadoreq == (int) iIdestadoreq.EditValue);

            //Deshabilitar si el id estado es 2(Pendiende de aprobacion), 3(Aprobado), 4(Desaprobado)
            if (estadoreq != null && (estadoreq.Idestadoreq == 2 || estadoreq.Idestadoreq == 3 || estadoreq.Idestadoreq == 4))
            {
                DeshabilitarModificacion();
            }

            if ((int) iIdestadoreq.EditValue == 4)
            {
                DeshabilitarModificacion();
            }
        }
        private void CargarReferencias()
        {

            VwSucursalList = CacheObjects.VwSucursalList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;


            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "REQUERIMIENTO" 
                && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            VwCptooperacionList =CacheObjects.VwCptooperacionList.Where(x =>x.Nombretipodocmov == "REQUERIMIENTO" 
                    && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

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

            VwEmpleadoList = CacheObjects.VwEmpleadoList;
            iIdempleado.Properties.DataSource = VwEmpleadoList;
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleadoaprueba.Properties.DataSource = VwEmpleadoList;
            iIdempleadoaprueba.Properties.DisplayMember = "Razonsocial";
            iIdempleadoaprueba.Properties.ValueMember = "Idempleado";
            iIdempleadoaprueba.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipolista.Properties.DataSource = CacheObjects.TipolistaList;
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            AlmacenList = CacheObjects.AlmacenList.Where(x => x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();// Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    EstadoreqList = CacheObjects.EstadoreqList.Where(x => x.Estadoinicial).ToList();
                    iIdestadoreq.Properties.DataSource = EstadoreqList;
                    iIdestadoreq.Properties.DisplayMember = "Nombreestadoreq";
                    iIdestadoreq.Properties.ValueMember = "Idestadoreq";
                    iIdestadoreq.Properties.BestFitMode = BestFitMode.BestFit;

                    break;
                case TipoMantenimiento.Modificar:
                    if (! Service.RequerimientoAprobado(IdEntidadMnt))
                    {
                        EstadoreqList = CacheObjects.EstadoreqList.Where(x => x.Estadoinicial).ToList();
                        iIdestadoreq.Properties.DataSource = EstadoreqList;
                        iIdestadoreq.Properties.DisplayMember = "Nombreestadoreq";
                        iIdestadoreq.Properties.ValueMember = "Idestadoreq";
                        iIdestadoreq.Properties.BestFitMode = BestFitMode.BestFit;
                    }
                    else
                    {
                        EstadoreqList = CacheObjects.EstadoreqList.Where(x => !x.Estadoinicial).ToList();
                        iIdestadoreq.Properties.DataSource = EstadoreqList;
                        iIdestadoreq.Properties.DisplayMember = "Nombreestadoreq";
                        iIdestadoreq.Properties.ValueMember = "Idestadoreq";
                        iIdestadoreq.Properties.BestFitMode = BestFitMode.BestFit;                        
                    }

                    break;
            }



        }        
        private void CargarAreasDeEmpleado()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    var idEmpleadoSel = iIdempleado.EditValue ?? 0;
                    //string conditionEmpleadoArea = string.Format("idempleado = {0}", (int)idEmpleadoSel);
                    //VwEmpleadoareaList = Service.GetAllVwEmpleadoarea(conditionEmpleadoArea, "Nombrearea");
                    VwEmpleadoareaList = CacheObjects.VwEmpleadoareaList.Where(x => x.Idempleado == (int) idEmpleadoSel).ToList();
                    iIdarea.Properties.DataSource = VwEmpleadoareaList;
                    iIdarea.Properties.DisplayMember = "Nombrearea";
                    iIdarea.Properties.ValueMember = "Idarea";
                    iIdarea.Properties.BestFitMode = BestFitMode.BestFit;


                    if (SessionApp.EmpleadoSel != null)
                    {
                        int idAreaEmpleadoLogeado = SessionApp.EmpleadoSel.Idarea;
                        //VwEmpleadoarea areaEmpleadoPorDefecto = Service.GetVwEmpleadoarea(x => x.Idempleado == UsuarioAutenticado.EmpleadoSel.Idempleado && x.Idarea == idAreaEmpleadoLogeado);
                        VwEmpleadoarea areaEmpleadoPorDefecto = CacheObjects.VwEmpleadoareaList.
                            FirstOrDefault(x => x.Idempleado == SessionApp.EmpleadoSel.Idempleado 
                                && x.Idarea == idAreaEmpleadoLogeado);

                        if (areaEmpleadoPorDefecto != null)
                        {
                            iIdarea.EditValue = areaEmpleadoPorDefecto.Idarea;
                        }

                    }

                    if (VwEmpleadoProyectoList != null && VwEmpleadoProyectoList.Count == 1)
                    {
                        VwEmpleadoareaproyecto empleadoAreaPorDefecto = VwEmpleadoProyectoList.FirstOrDefault();
                        if (empleadoAreaPorDefecto != null)
                        {
                            iIdproyecto.EditValue = empleadoAreaPorDefecto.Idproyecto;
                        }
                    }

                    break;
                case TipoMantenimiento.Modificar:


                    //iIdarea.Properties.DataSource = Service.GetAllVwArea("codigoarea");
                    iIdarea.Properties.DataSource = CacheObjects.VwAreaList;
                    iIdarea.Properties.DisplayMember = "Nombrearea";
                    iIdarea.Properties.ValueMember = "Idarea";
                    iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

                    //iIdproyecto.Properties.DataSource = Service.GetAllProyecto("codigoproyecto");
                    iIdproyecto.Properties.DataSource = CacheObjects.VwProyectoList;
                    iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
                    iIdproyecto.Properties.ValueMember = "Idproyecto";
                    iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

                    iIdarea.Enabled = false;
                    iIdproyecto.Enabled = false;
                    break;
            }
        }
        private void TraerDatos()
        {
            try
            {
                RequerimientoMnt = Service.GetRequerimiento(IdEntidadMnt);

                iIdarea.EditValue = RequerimientoMnt.Idarea;
                iIdproyecto.EditValue = RequerimientoMnt.Idproyecto;
                iIdtipocp.EditValue = RequerimientoMnt.Idtipocp;
                rSeriereq.EditValue = RequerimientoMnt.Seriereq;
                rNumeroreq.EditValue = RequerimientoMnt.Numeroreq;
                iFechareq.EditValue = RequerimientoMnt.Fechareq;
                iIdempleado.EditValue = RequerimientoMnt.Idempleado;
                iAnulado.EditValue = RequerimientoMnt.Anulado;
                iFechaanulado.EditValue = RequerimientoMnt.Fechaanulado;
                iTipocambio.EditValue = RequerimientoMnt.Tipocambio;
                iIdtipomoneda.EditValue = RequerimientoMnt.Idtipomoneda;
                iIdimpuesto.EditValue = RequerimientoMnt.Idimpuesto;

                rTotalbruto.EditValue = RequerimientoMnt.Totalbruto;
                rTotalgravado.EditValue = RequerimientoMnt.Totalgravado;
                rTotalinafecto.EditValue = RequerimientoMnt.Totalinafecto;
                rtotalexonerado.EditValue = RequerimientoMnt.Totalexonerado;
                rTotalimpuesto.EditValue = RequerimientoMnt.Totalimpuesto;
                rImportetotal.EditValue = RequerimientoMnt.Importetotal;
                rPorcentajepercepcion.EditValue = RequerimientoMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = RequerimientoMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = RequerimientoMnt.Totaldocumento;

                iGlosareq.EditValue = RequerimientoMnt.Glosareq;
                iIdcptooperacion.EditValue = RequerimientoMnt.Idcptooperacion;
                rIdsucursal.EditValue = RequerimientoMnt.Idsucursal;
                iIdestadoreq.EditValue = RequerimientoMnt.Idestadoreq;

                iFechaaprobacion.EditValue = RequerimientoMnt.Fechaaprobacion;
                iIdempleadoaprueba.EditValue = RequerimientoMnt.Idempleadoaprueba;
                iObservacionaprobacion.EditValue = RequerimientoMnt.Observacionaprobacion;
                iIdtipolista.EditValue = RequerimientoMnt.Idtipolista;
                iIncluyeimpuestoitems.EditValue = RequerimientoMnt.Incluyeimpuestoitems;
                rListadoordentrabajoref.EditValue = RequerimientoMnt.Listadoordentrabajoref;
                rNumerordendetrabajo.EditValue = RequerimientoMnt.Numerordendetrabajo;
                rFechaordentrabajo.EditValue = RequerimientoMnt.Fechaordentrabajo;
                iIdalmacen.EditValue = RequerimientoMnt.Idalmacen;



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

            string where = string.Format("idrequerimiento = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwRequerimientodetList = Service.GetAllVwRequerimientodet(where, "numeroitem");
            gcDetalle.DataSource = VwRequerimientodetList;            
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {

            if (!Validaciones()) return false;

            RequerimientoMnt.Idarea = (int?)iIdarea.EditValue;
            RequerimientoMnt.Idproyecto = (int?)iIdproyecto.EditValue;
            RequerimientoMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            RequerimientoMnt.Seriereq = rSeriereq.Text.Trim();
            RequerimientoMnt.Numeroreq = rNumeroreq.Text.Trim();
            RequerimientoMnt.Fechareq = (DateTime)iFechareq.EditValue;
            RequerimientoMnt.Idempleado = (int?)iIdempleado.EditValue;
            RequerimientoMnt.Anulado = (bool)iAnulado.EditValue;
            RequerimientoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            RequerimientoMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            RequerimientoMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;
            RequerimientoMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;

            RequerimientoMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            RequerimientoMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            RequerimientoMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            RequerimientoMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            RequerimientoMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            RequerimientoMnt.Importetotal = (decimal)rImportetotal.EditValue;
            RequerimientoMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            RequerimientoMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            RequerimientoMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            RequerimientoMnt.Glosareq = iGlosareq.Text.Trim();
            RequerimientoMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            RequerimientoMnt.Idsucursal = (int)rIdsucursal.EditValue;
            RequerimientoMnt.Idestadoreq = (int)iIdestadoreq.EditValue;
            RequerimientoMnt.Fechaaprobacion = (DateTime?)iFechaaprobacion.EditValue;
            RequerimientoMnt.Idempleadoaprueba = (int?)iIdempleadoaprueba.EditValue;
            RequerimientoMnt.Observacionaprobacion = iObservacionaprobacion.Text.Trim();
            RequerimientoMnt.Idtipolista = (int)iIdtipolista.EditValue;
            RequerimientoMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            RequerimientoMnt.Listadoordentrabajoref = rListadoordentrabajoref.Text.Trim();
            RequerimientoMnt.Numerordendetrabajo = rNumerordendetrabajo.Text.Trim();
            RequerimientoMnt.Fechaordentrabajo = (DateTime?)rFechaordentrabajo.EditValue;
            RequerimientoMnt.Idalmacen = (int) iIdalmacen.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    RequerimientoMnt.Createdby = IdUsuario;
                    RequerimientoMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    RequerimientoMnt.Modifiedby = IdUsuario;
                    RequerimientoMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:

                        if (Service.GuardarRequerimiento(TipoMnt, RequerimientoMnt, VwRequerimientodetList))
                        {
                            IdEntidadMnt = RequerimientoMnt.Idrequerimiento;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                            DataEntityState = DataEntityState.Added;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.GuardarRequerimiento(TipoMnt, RequerimientoMnt, VwRequerimientodetList);
                        DataEntityState = DataEntityState.Modified;
                        break;
                }

                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriereq.Text.Trim(), rNumeroreq.Text.Trim());
                Cursor = Cursors.Default;
                XtraMessageBox.Show("Se guardo correctamente el documento " + numeroDoc, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        private bool Validaciones()
        {
      

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpRequerimiento, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            VwCptooperacion vwCptooperacion = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int)iIdcptooperacion.EditValue);
            if (vwCptooperacion != null)
            {
                if (vwCptooperacion.Validarvalorunitario && (decimal)rTotaldocumento.EditValue <= 0)
                {
                    XtraMessageBox.Show("El importe total del documento no es valido.", Resources.titAtencion, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (vwCptooperacion.Validarstock && TipoMnt == TipoMantenimiento.Nuevo)
                {
                    string msgItemStock = null;
                    foreach (VwRequerimientodet vwRequerimientodet in VwRequerimientodetList)
                    {
                        if (vwRequerimientodet.Stock - vwRequerimientodet.Cantidad < 0)
                        {
                            msgItemStock = msgItemStock + string.Format(" - {0} {1} ({2})", vwRequerimientodet.Nombrearticulo, vwRequerimientodet.Nombremarca, vwRequerimientodet.Stock) + "\n";
                        }
                    }
                    if (!string.IsNullOrEmpty(msgItemStock))
                    {
                        XtraMessageBox.Show("No hay stock suficiente, verifique. \n\n"+ msgItemStock,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (vwCptooperacion.Tieneordencompra)
                {
                    var idTipoMonedaSel = iIdtipomoneda.EditValue;
                    decimal tipoCambio = (decimal)iTipocambio.EditValue;
                    if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
                    {
                        XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        iTipocambio.Select();
                        return false;
                    }
                }
            }



            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSeriereq.Text.Trim();
            string numeroViaje = rNumeroreq.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroRequerimientoExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
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
                        DataEntityState = DataEntityState.Deleted;
                        DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
                        DataEntityState = DataEntityState.Unchanged;
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
                    CamposSoloLectura(!Permisos.Nuevo);
                    iAnulado.Enabled = Permisos.Anular;
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

                    RequerimientoMnt = null;
                    RequerimientoMnt = new Requerimiento();

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
                    RequerimientoMnt = null;
                    DialogResult = DialogResult.OK;
                    break;
                case "btnImprimir":
                    if (RequerimientoImpresion == null)
                    {
                        RequerimientoImpresion = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        RequerimientoImpresion.FormatoRequerimiento(RequerimientoMnt);
                    }
                    break;
                case "btnCopiarItemsReq":

                    RequerimientoCopiarItemsFrm requerimientoCopiarItemsFrm = new RequerimientoCopiarItemsFrm(VwRequerimientodetList,(string)rNumerordendetrabajo.EditValue);
                    requerimientoCopiarItemsFrm.ShowDialog();
                    if (requerimientoCopiarItemsFrm.DialogResult == DialogResult.OK && requerimientoCopiarItemsFrm.VwRequerimientoSel != null)
                    {
                        iIncluyeimpuestoitems.EditValue = requerimientoCopiarItemsFrm.VwRequerimientoSel.Incluyeimpuestoitems;


                        rNumerordendetrabajo.EditValue = requerimientoCopiarItemsFrm.VwRequerimientoSel.Numerordendetrabajo;
                        rFechaordentrabajo.EditValue = requerimientoCopiarItemsFrm.VwRequerimientoSel.Fechaordentrabajo;
                        rListadoordentrabajoref.EditValue = requerimientoCopiarItemsFrm.VwRequerimientoSel.Descripcionordentrabajo;

                        //Agregar items de detalle compuesto
                        if (requerimientoCopiarItemsFrm.VwRequerimientoComponenteList != null && requerimientoCopiarItemsFrm.VwRequerimientoComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in requerimientoCopiarItemsFrm.VwRequerimientoComponenteList)
                            {
                                VwRequerimientodetList.Add(itemDetCompuesto);
                            }
                        }

                        int numeroItem = 1;
                        foreach (var item in VwRequerimientodetList)
                        {
                            item.Numeroitem = numeroItem;
                            numeroItem++;
                            CalculaItem(item);
                        }

                        SumarTotales();
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
        private void RequerimientoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpRequerimiento, readOnly);
            WinFormUtils.ReadOnlyFields(tpAprobacionRequerimiento, readOnly);
            WinFormUtils.ReadOnlyFields(tpObservacion, readOnly);
            WinFormUtils.ReadOnlyFields(tpReferencias, readOnly);   
         

        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int) rIdsucursal.EditValue;
            int idEmpleado = (int) iIdempleado.EditValue;
            const string nombreTipodocMov = "REQUERIMIENTO";
            int idTipoCpPorDefecto = (int) iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int) iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }        
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!Validaciones()) return;

            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            RequerimientoMntItemFrm requerimientoMntItemFrm;
            VwRequerimientodet vwRequerimientodetMntItem;



            //Propiedades para consulta
            int idSucursalConsulta = 0;
            int idAlmacenConsulta = 0;
            int idTipoListaConsulta = 0;


            VwSucursal vwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)rIdsucursal.EditValue);
            if (vwSucursalSel != null)
            {
                idSucursalConsulta = vwSucursalSel.Idsucursal;
                idAlmacenConsulta = (int)iIdalmacen.EditValue;
                idTipoListaConsulta = (int)iIdtipolista.EditValue;
            }

            VwCptooperacion vwCptooperacionSel = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int) iIdcptooperacion.EditValue);

            VwCptooperacionSel = vwCptooperacionSel;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    
                    vwRequerimientodetMntItem = new VwRequerimientodet();

                    //Asignar el siguiente item
                    var sgtItem = VwRequerimientodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwRequerimientodetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    requerimientoMntItemFrm = new RequerimientoMntItemFrm(tipoMantenimientoItem, vwRequerimientodetMntItem, VwRequerimientodetList);


                    VwRequerimientodet vwRequerimientodetLast = VwRequerimientodetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);
                    requerimientoMntItemFrm.IdCentroDeCostoPorDefecto = vwRequerimientodetLast != null ? vwRequerimientodetLast.Idcentrodecosto : 0;
                    requerimientoMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    requerimientoMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    requerimientoMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;
                    requerimientoMntItemFrm.VwCptooperacionSel = VwCptooperacionSel;

                    requerimientoMntItemFrm.ShowDialog();
                  
                    if (requerimientoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwRequerimientodetList.Add(vwRequerimientodetMntItem);

                        //Agregar items de detalle compuesto
                        if (requerimientoMntItemFrm.VwRequerimientoComponenteList != null && requerimientoMntItemFrm.VwRequerimientoComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in requerimientoMntItemFrm.VwRequerimientoComponenteList)
                            {
                                VwRequerimientodetList.Add(itemDetCompuesto);
                            }
                        }

                        //Actualizar la cantidad inicial mientras el estado del requerimiento este en registrado (1)

                        Estadoreq estadoreq = Service.GetEstadoRequerimiento(IdEntidadMnt);
                        if (estadoreq != null && estadoreq.Idestadoreq == 1)
                        {
                            vwRequerimientodetMntItem.Cantidadinicial = vwRequerimientodetMntItem.Cantidad;
                        }

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

                    vwRequerimientodetMntItem = (VwRequerimientodet) gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    requerimientoMntItemFrm = new RequerimientoMntItemFrm(tipoMantenimientoItem, vwRequerimientodetMntItem, VwRequerimientodetList);
                    requerimientoMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    requerimientoMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    requerimientoMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;
                    requerimientoMntItemFrm.VwCptooperacionSel = VwCptooperacionSel;
                    requerimientoMntItemFrm.ShowDialog();

                    if (requerimientoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwRequerimientodetMntItem = (VwRequerimientodet)gvDetalle.GetFocusedRow();
                        vwRequerimientodetMntItem.DataEntityState = DataEntityState.Deleted;

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
            decimal totalbruto = VwRequerimientodetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;
            decimal totalgravado = VwRequerimientodetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwRequerimientodetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalexonerado = VwRequerimientodetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwRequerimientodetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Gravado
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));
                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                rImportetotalpercepcion.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalValorPercepcion : totalValorPercepcion * factorImpuesto, 2);
                rTotalgravado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado / factorImpuesto : totalgravado, 2);
                rTotalinafecto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalinafecto / factorImpuesto : totalinafecto, 2);
                rtotalexonerado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalexonerado / factorImpuesto : totalexonerado, 2);

                rTotalimpuesto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado - (decimal)rTotalgravado.EditValue : totalgravado * porcentajeImpuesto / 100, 2);
                rImportetotal.EditValue = (decimal)rTotalgravado.EditValue + (decimal)rTotalinafecto.EditValue + (decimal)rtotalexonerado.EditValue + +(decimal)rTotalimpuesto.EditValue;
                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rImportetotalpercepcion .EditValue;
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
                        rSeriereq.EditValue = vwTipocp.Seriecp;
                        rNumeroreq.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroreq.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroreq.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroreq.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroreq.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroreq.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriereq.EditValue = @"0000";
                rNumeroreq.EditValue = 0;
            }
        }
        private void gvDetRequerimiento_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwRequerimientodet item = (VwRequerimientodet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idrequerimientodet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;

            switch (tipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    item.Createdby = SessionApp.UsuarioSel.Idusuario;
                    item.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    item.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                    item.Lastmodified = DateTime.Now;
                    break;
            }


            switch (e.Column.FieldName)
            {
                case "Cantidad":
                case "Preciounitario":
                case "Porcentajepercepcion":
                    CalculaItem(item);
                    break;
                case "Importetotal":
                    CalculaItem2(item);
                    SumarTotales();
                    break;
            } 
           
            //SumarTotales();
        }
        private void CalculaItem(VwRequerimientodet item)
        {

            item.Importetotal = item.Cantidad * item.Preciounitario;
            item.DataEntityState = DataEntityState.Modified;

            //Actualizar la cantidad inicial mientras el estado del requerimiento este en registrado
            Estadoreq estadoreq = Service.GetEstadoRequerimiento(IdEntidadMnt);
            if (estadoreq != null && estadoreq.Idestadoreq == 1)
            {
                item.Cantidadinicial = item.Cantidad;
            }

            SumarTotales();
        }
        private void CalculaItem2(VwRequerimientodet item)
        {
            item.Preciounitario = decimal.Round(item.Importetotal / item.Cantidad, 4, MidpointRounding.AwayFromZero);
            item.DataEntityState = DataEntityState.Modified;
            SumarTotales();
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object) DateTime.Now : null;
        }
        private void iIdarea_EditValueChanged(object sender, EventArgs e)
        {
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                var idAreaSel = iIdarea.EditValue;
                if (idAreaSel == null) return;
                VwEmpleadoarea vwEmpleadoareaSel = VwEmpleadoareaList.FirstOrDefault(x => x.Idarea == (int)idAreaSel);

                if (vwEmpleadoareaSel != null)
                {
                    //VwEmpleadoProyectoList = Service.GetAllVwEmpleadoareaproyecto(x => x.Idempleadoarea == vwEmpleadoareaSel.Idempleadoarea);
                    VwEmpleadoProyectoList = CacheObjects.VwEmpleadoareaproyectoList.Where(x => x.Idempleadoarea == vwEmpleadoareaSel.Idempleadoarea).ToList();
                    iIdproyecto.Properties.DataSource = VwEmpleadoProyectoList;
                    iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
                    iIdproyecto.Properties.ValueMember = "Idproyecto";
                    iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;
                }
            }
            
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
            btnCopiarItemsReq.Enabled = !enabled;

            BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItems.EndUpdate();

        }
        private void iIdempleado_EditValueChanged(object sender, EventArgs e)
        {
            if (SessionApp.EmpleadoSel == null)
            {
                CargarAreasDeEmpleado();
            }
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwRequerimientodetList != null)
            {
                SumarTotales();
            }  
        }

        private void btnImportarOt_Click(object sender, EventArgs e)
        {
            SeleccionarOrdentrabajoFrm seleccionarOrdentrabajoFrm = new SeleccionarOrdentrabajoFrm();
            seleccionarOrdentrabajoFrm.ShowDialog();
            if (seleccionarOrdentrabajoFrm.VwOrdentrabajoSel != null)
            {
                rNumerordendetrabajo.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Numeroordentrabajo;
                rFechaordentrabajo.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Fecharegistro;
                rListadoordentrabajoref.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Descripcioncentrodecosto;
            }
        }

        private void iIdcptooperacion_EditValueChanged(object sender, EventArgs e)
        {
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                var idcptooperacion = iIdcptooperacion.EditValue;
                VwCptooperacion vwCptooperacion = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int)idcptooperacion);
                if (vwCptooperacion != null && vwCptooperacion.Generasalida)
                {
                    iIdtipomoneda.EditValue = 1; //Nuevos Soles
                    iIdtipomoneda.ReadOnly = true;
                }
                else
                {
                    iIdtipomoneda.ReadOnly = false;
                }
            }
        }
    }    
}