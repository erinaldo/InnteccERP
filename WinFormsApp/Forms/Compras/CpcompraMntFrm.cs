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
    public partial class CpcompraMntFrm : XtraForm
    {
        public DataEntityState DataEntityState { get; set; }
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public GridControl GridParent { get; set; }
        public CpcompraFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cpcompra CpcompraMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwCpcompradet> VwCpcompradetList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public VwEntradaalmacen VwEntradaalmacenOrigen { get; set; }
        public List<VwEntradaalmacendet> VwEntradaalmacendetListOrigen { get; set; }

        //private static readonly HelperDb HelperDb = new HelperDb();
        public CpcompraMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CpcompraFrm formParent)
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

        public CpcompraMntFrm(
            int idEntidadMnt,
            TipoMantenimiento tipoMnt,
            GridControl gridParent,
            CpcompraFrm formParent,
            VwEntradaalmacen vwEntradaAlmacenOrigen,
            List<VwEntradaalmacendet> vwEntradaalmacendetListOrigen)
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
            VwEntradaalmacenOrigen = vwEntradaAlmacenOrigen;
            VwEntradaalmacendetListOrigen = vwEntradaalmacendetListOrigen;

        }

        private void CpcompraMntFrm_Load(object sender, EventArgs e)
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

            iFechaemision.EditValue = DateTime.Now;
            iFecharegistro.EditValue = DateTime.Now;
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

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "CPCOMPRA";
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

            iIdestadopago.EditValue = 2;

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
                    CpcompraMnt = new Cpcompra();
                    CargarDetalle();
                    iIdtipocp.Select();
                    ObtenerTipoDeCambioVentaSunat();
                    if (VwEntradaalmacenOrigen != null)
                    {
                        ImportarEntradaAlmacen();
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoReferenciaCaja();
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaRendicionCajaChica();
                    EstadoReferenciaNotacredito();
                    break;
            }
        }

        private void ImportarEntradaAlmacen()
        {
            iIdproveedor.EditValue = VwEntradaalmacenOrigen.Idsocionegocio;
            CargarDatosSocioNegocio(VwEntradaalmacenOrigen.Idsocionegocio);
            iIdempleado.EditValue = VwEntradaalmacenOrigen.Idempleado;
            iIdtipomoneda.EditValue = VwEntradaalmacenOrigen.Idtipomoneda;
            iIdimpuesto.EditValue = VwEntradaalmacenOrigen.Idimpuesto;
            iIncluyeimpuestoitems.EditValue = VwEntradaalmacenOrigen.Incluyeimpuestoitems;

            //Detalle
            foreach (var item in VwEntradaalmacendetListOrigen)
            {
                VwCpcompradet vwCpcompradet = new VwCpcompradet();
                vwCpcompradet.Numeroitem = item.Numeroitem;
                vwCpcompradet.Idarticulo = item.Idarticulo;
                vwCpcompradet.Codigoarticulo = item.Codigoarticulo;
                vwCpcompradet.Codigoproveedor = item.Codigoproveedor;
                vwCpcompradet.Idunidadinventario = item.Idunidadmedida;
                vwCpcompradet.Nombremarca = item.Nombremarca;
                vwCpcompradet.Nombrearticulo = item.Nombrearticulo;
                vwCpcompradet.Cantidad = item.Cantidad;
                vwCpcompradet.Idunidadmedida = item.Idunidadmedida;
                vwCpcompradet.Abrunidadmedida = item.Abrunidadmedida;
                vwCpcompradet.Preciounitario = item.Preciounitario;
                vwCpcompradet.Especificacion = item.Especificacion;
                vwCpcompradet.Descuento1 = 0.00m;
                vwCpcompradet.Descuento2 = 0.00m;
                vwCpcompradet.Descuento3 = 0.00m;
                vwCpcompradet.Descuento4 = 0.00m;
                vwCpcompradet.Preciounitarioneto = item.Preciounitario;
                vwCpcompradet.Importetotal = item.Importetotal;
                vwCpcompradet.Pesounitario = 0.00m;
                vwCpcompradet.Pesototal = vwCpcompradet.Cantidad * vwCpcompradet.Pesounitario;

                vwCpcompradet.Idimpuesto = item.Idimpuesto;

                vwCpcompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwCpcompradet.Gravado = item.Gravado;
                vwCpcompradet.Exonerado = item.Exonerado;
                vwCpcompradet.Inafecto = item.Inafecto;
                vwCpcompradet.Exportacion = item.Exportacion;

                vwCpcompradet.Idcentrodecosto = item.Idcentrodecosto;
                vwCpcompradet.Codigocentrodecosto = item.Codigocentrodecosto;
                vwCpcompradet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                vwCpcompradet.Porcentajepercepcion = item.Porcentajepercepcion;
                vwCpcompradet.Idarea = item.Idarea;
                vwCpcompradet.Nombrearea = item.Nombrearea;
                vwCpcompradet.Idproyecto = item.Idproyecto;
                vwCpcompradet.Nombreproyecto = item.Nombreproyecto;
                vwCpcompradet.Calcularitem = item.Calcularitem;

                if (vwCpcompradet.Idordencompradet == null)
                {
                    vwCpcompradet.Idordencompradet = null;
                    vwCpcompradet.Serienumeroorden = string.Empty;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCpcompradet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwCpcompradet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCpcompradet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwCpcompradet.Lastmodified = DateTime.Now;
                        break;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCpcompradet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCpcompradet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                VwCpcompradetList.Add(vwCpcompradet);
            }
            gvDetalle.RefreshData();
            SumarTotales();
            

        }

        private void EstadoReferenciaCaja()
        {
            var idTipoCp = (int)iIdtipocp.EditValue;
            var serieTipoCp = (string)iSeriecpcompra.EditValue;
            var numeroTipoCp = (string)iNumerocpcompra.EditValue;

            if (Service.CpCompraTieneReferenciaCaja(idTipoCp, serieTipoCp, numeroTipoCp))
            {
                XtraMessageBox.Show("El Comprobante de Compra tiene Recibo de Caja", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void EstadoReferenciaRendicionCajaChica()
        {
            if (Service.CpCompraTieneReferenciasRendicionCajaChica(CpcompraMnt.Idtipocp, CpcompraMnt.Idproveedor, CpcompraMnt.Seriecpcompra, CpcompraMnt.Numerocpcompra))
            {
                XtraMessageBox.Show("El comprobante de compra  tiene referencias en rendición de caja chica.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (SessionApp.UsuarioSel.Nombreusuario != "ADMIN")
                {
                    HabilitarBotonesMnt(false);
                }

                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void EstadoReferenciaNotacredito()
        {



            if (Service.CpCompraTieneNotaCredito(IdEntidadMnt))
            {
                XtraMessageBox.Show("El Comprobante de Compra tiene Nota de Credito", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPCOMPRA", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPCOMPRA", SessionApp.SucursalSel.Idsucursal);
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

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            iIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            iIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            iIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdperiodo.Properties.DataSource = Service.GetAllVwPeriodo("periodo");
            iIdperiodo.Properties.DisplayMember = "Periodo";
            iIdperiodo.Properties.ValueMember = "Idperiodo";
            iIdperiodo.Properties.BestFitMode = BestFitMode.BestFit;

            rIdsucursal.Properties.DataSource = CacheObjects.VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdestadopago.Properties.DataSource = CacheObjects.EstadopagoList;
            iIdestadopago.Properties.DisplayMember = "Nombreestadopago";
            iIdestadopago.Properties.ValueMember = "Idestadopago";
            iIdestadopago.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void TraerDatos()
        {
            try
            {

                CpcompraMnt = Service.GetCpcompra(IdEntidadMnt);

                iIdtipocp.EditValue = CpcompraMnt.Idtipocp;
                iIdcptooperacion.EditValue = CpcompraMnt.Idcptooperacion;
                rIdsucursal.EditValue = CpcompraMnt.Idsucursal;
                iSeriecpcompra.EditValue = CpcompraMnt.Seriecpcompra;
                iNumerocpcompra.EditValue = CpcompraMnt.Numerocpcompra;
                iFechaemision.EditValue = CpcompraMnt.Fechaemision;
                iFecharecepcion.EditValue = CpcompraMnt.Fecharecepcion;
                iIdimpuesto.EditValue = CpcompraMnt.Idimpuesto;

                CargarDatosSocioNegocio(CpcompraMnt.Idproveedor);
                iIdproveedor.EditValue = CpcompraMnt.Idproveedor;
                iAnulado.EditValue = CpcompraMnt.Anulado;
                iFechaanulado.EditValue = CpcompraMnt.Fechaanulado;
                iIdempleado.EditValue = CpcompraMnt.Idempleado;
                iTipocambio.EditValue = CpcompraMnt.Tipocambio;
                iIdtipocondicion.EditValue = CpcompraMnt.Idtipocondicion;
                iIdtipomoneda.EditValue = CpcompraMnt.Idtipomoneda;


                rTotalbruto.EditValue = CpcompraMnt.Totalbruto;
                rTotalgravado.EditValue = CpcompraMnt.Totalgravado;
                rTotalinafecto.EditValue = CpcompraMnt.Totalinafecto;
                rtotalexonerado.EditValue = CpcompraMnt.Totalexonerado;
                rTotalimpuesto.EditValue = CpcompraMnt.Totalimpuesto;
                rImportetotal.EditValue = CpcompraMnt.Importetotal;
                rPorcentajepercepcion.EditValue = CpcompraMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = CpcompraMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = CpcompraMnt.Totaldocumento;


                iGlosacpcompra.EditValue = CpcompraMnt.Glosacpcompra;

                iIncluyeimpuestoitems.EditValue = CpcompraMnt.Incluyeimpuestoitems;
                iFecharegistro.EditValue = CpcompraMnt.Fecharegistro;
                iIdperiodo.EditValue = CpcompraMnt.Idperiodo;
                nDescuentounicosteo.EditValue = CpcompraMnt.Descuentounicosteo;
                nOtrosgastossoles.EditValue = CpcompraMnt.Otrosgastossoles;
                nFletetmsoles.EditValue = CpcompraMnt.Fletetmsoles;
                rPesototalkg.EditValue = CpcompraMnt.Pesototalkg;
                iIdestadopago.EditValue = CpcompraMnt.Idestadopago;

                rNumerordendetrabajo.EditValue = CpcompraMnt.Numerordendetrabajo;
                rFechaordentrabajo.EditValue = CpcompraMnt.Fechaordentrabajo;
                rDescripcionordentrabajo.EditValue = CpcompraMnt.Descripcionordentrabajo;
                iHoratransaccion.EditValue = CpcompraMnt.Horatransaccion;

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

            string where = string.Format("idcpcompra = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwCpcompradetList = Service.GetAllVwCpcompradet(where, "numeroitem");
            gcDetalle.DataSource = VwCpcompradetList;
            gcDetalle.EndUpdate();


            gcCostos.BeginUpdate();
            gcCostos.DataSource = VwCpcompradetList;
            gcCostos.EndUpdate();
            SumarTotales();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            CpcompraMnt.Idtipocp = (int)iIdtipocp.EditValue;
            CpcompraMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            CpcompraMnt.Idsucursal = (int?)rIdsucursal.EditValue;
            CpcompraMnt.Seriecpcompra = iSeriecpcompra.Text.Trim();
            CpcompraMnt.Numerocpcompra = iNumerocpcompra.Text.Trim();
            CpcompraMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            CpcompraMnt.Fecharecepcion = (DateTime?)iFecharecepcion.EditValue;
            CpcompraMnt.Idproveedor = (int)iIdproveedor.EditValue;
            CpcompraMnt.Anulado = (bool)iAnulado.EditValue;
            CpcompraMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            CpcompraMnt.Idempleado = (int?)iIdempleado.EditValue;
            CpcompraMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            CpcompraMnt.Idtipocondicion = (int?)iIdtipocondicion.EditValue;
            CpcompraMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;

            CpcompraMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            CpcompraMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            CpcompraMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            CpcompraMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            CpcompraMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            CpcompraMnt.Importetotal = (decimal)rImportetotal.EditValue;
            CpcompraMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            CpcompraMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            CpcompraMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;


            CpcompraMnt.Glosacpcompra = iGlosacpcompra.Text.Trim();
            CpcompraMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;
            CpcompraMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            CpcompraMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            CpcompraMnt.Idperiodo = (int?)iIdperiodo.EditValue;
            CpcompraMnt.Descuentounicosteo = (decimal)nDescuentounicosteo.EditValue;
            CpcompraMnt.Otrosgastossoles = (decimal)nOtrosgastossoles.EditValue;
            CpcompraMnt.Fletetmsoles = (decimal)nFletetmsoles.EditValue;
            CpcompraMnt.Pesototalkg = (decimal)rPesototalkg.EditValue;
            CpcompraMnt.Idestadopago = (int)iIdestadopago.EditValue;

            CpcompraMnt.Numerordendetrabajo = rNumerordendetrabajo.Text.Trim();
            CpcompraMnt.Fechaordentrabajo = (DateTime?)rFechaordentrabajo.EditValue;
            CpcompraMnt.Descripcionordentrabajo = rDescripcionordentrabajo.Text.Trim();

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CpcompraMnt.Createdby = IdUsuario;
                    CpcompraMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    CpcompraMnt.Modifiedby = IdUsuario;
                    CpcompraMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        //Autoenumerar por proveedor
                        if (VwTipocpSel.Enumerarporsocionegocio)
                        {
                            iNumerocpcompra.EditValue = Service.SiguienteNumeroCpCompraPorProveedor(CpcompraMnt.Idtipocp, CpcompraMnt.Idproveedor, CpcompraMnt.Seriecpcompra);
                            CpcompraMnt.Numerocpcompra = (string)iNumerocpcompra.EditValue;
                        }

                        if (Service.GuardarCpCompra(TipoMnt, CpcompraMnt, VwCpcompradetList, VwEntradaalmacendetListOrigen))
                        {
                            IdEntidadMnt = CpcompraMnt.Idcpcompra;
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
                        Service.GuardarCpCompra(TipoMnt, CpcompraMnt, VwCpcompradetList, VwEntradaalmacendetListOrigen);
                        DataEntityState = DataEntityState.Modified;
                        break;
                }

                RegistrarValoresPorDefecto();

                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), iSeriecpcompra.Text.Trim(), iNumerocpcompra.Text.Trim());
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
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "CPCOMPRA";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpRequerimiento, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (iSeriecpcompra.Text.Trim() == "0000")
            {
                XtraMessageBox.Show("El número de serie no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iSeriecpcompra.Focus();
                return false;
            }

            if (!VwTipocpSel.Enumerarporsocionegocio)
            {
                if (iNumerocpcompra.Text.Trim() == "00000000")
                {
                    XtraMessageBox.Show("El número de comprobante no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    iNumerocpcompra.Focus();
                    return false;
                }
            }


            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwCpcompradetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwCpcompradetList.Where(x => x.Preciounitario <= 0);
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

            //int idSucursal = (int)rIdsucursal.EditValue;
            //int idTipoCp = (int)iIdtipocp.EditValue;
            //string numeroSerie = rSeriecpcompra.Text.Trim();
            //string numeroViaje = rNumerocpcompra.Text.Trim();

            //if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroOrdenCompraExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
            //{
            //    CargarInfoCorrelativo();
            //    return true;
            //}

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

            int idProveedorSel;
            VwSocionegocio vwSocionegocio;

            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();

                    TipoMnt = TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    CpcompraMnt = null;
                    CpcompraMnt = new Cpcompra();

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
                    CpcompraMnt = null;
                    DialogResult = DialogResult.OK;
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {

                    }
                    break;
                case "btnImportarOc":

                    idProveedorSel = (int)iIdproveedor.EditValue;
                    if (idProveedorSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el proveedor.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        beSocioNegocio.Select();
                        return;
                    }

                    vwSocionegocio = Service.GetVwSocionegocio(idProveedorSel);

                    var cpcompraMntImpOcFrm = new CpcompraMntImpOcFrm(VwCpcompradetList, vwSocionegocio);
                    cpcompraMntImpOcFrm.ShowDialog();

                    if (cpcompraMntImpOcFrm.DialogResult == DialogResult.OK)
                    {
                        var vwOrdencompraSelImp = cpcompraMntImpOcFrm.VwOrdencompraSel;
                        if (vwOrdencompraSelImp != null)
                        {
                            iIdproveedor.EditValue = vwOrdencompraSelImp.Idproveedor;
                            iIdtipomoneda.EditValue = vwOrdencompraSelImp.Idtipomoneda;
                            iIdtipocondicion.EditValue = vwOrdencompraSelImp.Idtipocondicion;
                            iIdestadopago.EditValue = vwOrdencompraSelImp.Idestadopago;
                            iIncluyeimpuestoitems.EditValue = vwOrdencompraSelImp.Incluyeimpuestoitems;

                            //VwCptooperacion vwCptooperacionCompra = VwCptooperacionList.FirstOrDefault(x => x.Nombrecptooperacion.Contains("COMPRA"));
                            //if (vwCptooperacionCompra != null)
                            //{
                            //    iIdcptooperacion.EditValue = vwCptooperacionCompra.Idcptooperacion;
                            //    iIdcptooperacion.ReadOnly = true;
                            //}

                        }
                        foreach (var item in VwCpcompradetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();


                        iIdproveedor.Enabled = false;
                    }


                    break;
                case "btnImportarOs":
                    idProveedorSel = (int)iIdproveedor.EditValue;
                    if (idProveedorSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el proveedor.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        beSocioNegocio.Select();
                        return;
                    }

                    vwSocionegocio = Service.GetVwSocionegocio(idProveedorSel);

                    var cpcompraMntImpOsFrm = new CpcompraMntImpOsFrm(VwCpcompradetList, vwSocionegocio);
                    cpcompraMntImpOsFrm.ShowDialog();

                    if (cpcompraMntImpOsFrm.DialogResult == DialogResult.OK)
                    {
                        var vwOrdenservicioSelImp = cpcompraMntImpOsFrm.VwOrdenservicioSel;
                        if (vwOrdenservicioSelImp != null)
                        {
                            iIdproveedor.EditValue = vwOrdenservicioSelImp.Idproveedor;
                            iIdtipomoneda.EditValue = vwOrdenservicioSelImp.Idtipomoneda;
                            iIdtipocondicion.EditValue = vwOrdenservicioSelImp.Idtipocondicion;
                            iIdestadopago.EditValue = vwOrdenservicioSelImp.Idestadopago;
                            iIncluyeimpuestoitems.EditValue = vwOrdenservicioSelImp.Incluyeimpuestoitems;

                            //Obtener la operacion por defecto cuando se importa de ordenes de servicio a cp compra
                            if (SessionApp.SucursalSel.Idcptooperacionordenservicio != null)
                            {
                                iIdcptooperacion.EditValue = SessionApp.SucursalSel.Idcptooperacionordenservicio;
                                iIdcptooperacion.Enabled = false;
                            }
                        }
                        foreach (var item in VwCpcompradetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();


                        iIdproveedor.Enabled = false;
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
        private void CpcompraMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(gcDatosCosto, readOnly);
        }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            CpcompraMntItemFrm cpcompraMntItemFrm;
            VwCpcompradet vwCpcompradetMntItem;


            switch (e.Item.Name)
            {
                case "btnAddItem":
                    //Asignar el siguiente item
                    vwCpcompradetMntItem = new VwCpcompradet();

                    //Asignar el siguiente item
                    VwCpcompradet sgtItem = VwCpcompradetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwCpcompradetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;

                    //Establecer el ultimo centro de costo
                    VwCpcompradet vwCpcompradetUltimoItem = VwCpcompradetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);

                    cpcompraMntItemFrm = new CpcompraMntItemFrm(tipoMantenimientoItem, vwCpcompradetMntItem);
                    if (vwCpcompradetUltimoItem != null)
                    {
                        cpcompraMntItemFrm.IdCentroDeCostoPorDefecto = vwCpcompradetUltimoItem.Idcentrodecosto;
                        cpcompraMntItemFrm.IdProyectoPorDefecto = vwCpcompradetUltimoItem.Idproyecto;
                        cpcompraMntItemFrm.IdAreaPorDefecto = vwCpcompradetUltimoItem.Idarea;
                    }

                    cpcompraMntItemFrm.ShowDialog();

                    if (cpcompraMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwCpcompradetList.Add(vwCpcompradetMntItem);

                        //Agregar items de detalle compuesto
                        if (cpcompraMntItemFrm.VwCpcompradetComponenteList != null && cpcompraMntItemFrm.VwCpcompradetComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in cpcompraMntItemFrm.VwCpcompradetComponenteList)
                            {
                                VwCpcompradetList.Add(itemDetCompuesto);
                            }
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
                    vwCpcompradetMntItem = (VwCpcompradet)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    cpcompraMntItemFrm = new CpcompraMntItemFrm(tipoMantenimientoItem, vwCpcompradetMntItem);
                    cpcompraMntItemFrm.ShowDialog();

                    if (cpcompraMntItemFrm.DialogResult == DialogResult.OK)
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

                        vwCpcompradetMntItem = (VwCpcompradet)gvDetalle.GetFocusedRow();
                        vwCpcompradetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }

                        SumarTotales();

                    }
                    break;
                case "btnSeries":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe el documento para registrar series", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwCpcompradetMntItem = (VwCpcompradet)gvDetalle.GetFocusedRow();
                    CpCompraDetSerieMntFrm cpCompraDetSerieMntFrm = new CpCompraDetSerieMntFrm(TipoMantenimiento.Modificar, vwCpcompradetMntItem, string.Empty);
                    cpCompraDetSerieMntFrm.ShowDialog();

                    break;
            }

        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            decimal totalbruto = VwCpcompradetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwCpcompradetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwCpcompradetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalexonerado = VwCpcompradetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwCpcompradetList.Where(
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
            VwTipocpSel = idTipocp != null ? VwTipocpList.FirstOrDefault(x => x.Idtipocp == (int)idTipocp) : null;
        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompradet item = (VwCpcompradet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idcpcompradet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
                case "Descuento1":
                case "Descuento2":
                case "Descuento3":
                case "Descuento4":
                    CalculaItem1(item);
                    SumarTotales();
                    break;
                case "Porcentajepercepcion":
                    SumarTotales();
                    break;
                case "Importetotal":
                    CalculaItem2(item);
                    SumarTotales();
                    break;
            }

        }
        private void CalculaItem2(VwCpcompradet item)
        {
            item.Preciounitarioneto = item.Cantidad == 0 ? 0 : item.Importetotal / item.Cantidad;
            decimal precioUnitario = item.Preciounitarioneto * 100 / (100 - item.Descuento4);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento3);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento2);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento1);
            item.Preciounitario = precioUnitario;
            item.Importetotal = Decimal.Round(item.Cantidad * item.Preciounitario, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem1(VwCpcompradet item)
        {
            decimal precioUnitarioNeto = item.Preciounitario * (1 - item.Descuento1 / 100) * (1 - item.Descuento2 / 100) *
                                         (1 - item.Descuento3 / 100) * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
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
            btnSeries.Enabled = !enabled;

            BarMntItems.EndUpdate();

        }
        private void gvCostos_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompradet item = (VwCpcompradet)gvCostos.GetFocusedRow();

            switch (e.Column.FieldName)
            {
                case "Descuentoproveedorcosto":
                    item.DataEntityState = DataEntityState.Modified;
                    gvCostos.RefreshData();
                    break;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            VwCpcompradet vwCpcompradet = (VwCpcompradet)gvCostos.GetFocusedRow();
            if (vwCpcompradet != null)
            {
                CpcostoshistorialFrm cpcostoshistorialFrm = new CpcostoshistorialFrm(vwCpcompradet.Idarticulo);
                cpcostoshistorialFrm.ShowDialog();
            }


        }
        private void iFechaemision_EditValueChanged(object sender, EventArgs e)
        {
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                ObtenerTipoDeCambioVentaSunat();
            }

        }
        private void ObtenerTipoDeCambioVentaSunat()
        {
            DateTime fechaEmision = (DateTime)iFechaemision.EditValue;
            Tipocambio tipocambio = Service.GetTipocambio(x => x.Fechatipocambio == fechaEmision);
            if (tipocambio != null)
            {
                iTipocambio.EditValue = tipocambio.Valorventasunat;
            }
            else
            {
                iTipocambio.EditValue = 0m;
            }
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
                    var idSocioNegocioMnt = iIdproveedor.EditValue;
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
                iIdproveedor.EditValue = VwSocionegocioSel.Idsocionegocio;
                iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
            }
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwCpcompradetList != null)
            {
                SumarTotales();
            }
        }
        private void iSeriecpcompra_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string serieCpCompra = iSeriecpcompra.Text.Trim();
            iSeriecpcompra.EditValue = serieCpCompra.PadLeft(4, '0');
        }
        private void btnImportarOt_Click(object sender, EventArgs e)
        {
            SeleccionarOrdentrabajoFrm seleccionarOrdentrabajoFrm = new SeleccionarOrdentrabajoFrm();
            seleccionarOrdentrabajoFrm.ShowDialog();
            if (seleccionarOrdentrabajoFrm.VwOrdentrabajoSel != null)
            {
                rNumerordendetrabajo.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Numeroordentrabajo;
                rFechaordentrabajo.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Fecharegistro;
                rDescripcionordentrabajo.EditValue = seleccionarOrdentrabajoFrm.VwOrdentrabajoSel.Descripcioncentrodecosto;
            }
        }
    }
}