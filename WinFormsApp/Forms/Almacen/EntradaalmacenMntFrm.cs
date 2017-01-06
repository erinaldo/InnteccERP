using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class EntradaalmacenMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public DataEntityState DataEntityState { get; set; }
        public GridControl GridParent { get; set; }
        public EntradaalmacenFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        static readonly HelperDb HelperDb = new HelperDb();
        public Entradaalmacen EntradaalmacenMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwEntradaalmacendet> VwEntradaalmacendetList { get; set; }
        public List<VwEntradaalmacenubicacion> VwEntradaalmacenubicacionList { get; set; }
        private List<Almacen> AlmacenList { get; set; }
        private List<Tipodocmov> TipodocmovList { get; set; }
        private VwSocionegocio VwSocionegocioSel { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }

        List<Inventario> _inventarioList;
        public EntradaalmacenMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EntradaalmacenFrm formParent)
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
        private void EntradaalmacenMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFechaentrada.EditValue = SessionApp.DateServer;
            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;

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

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            iIdtipodocmov.EditValue = 4;
            //iIdtipodocmov.Enabled = false;

            iIddocumentoingreso.EditValue = 10; //Guia de remision



            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "ENTRADA-ALM";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

            int? idAlmacenDefecto = SessionApp.SucursalSel.Idalmacendefecto;
            if (idAlmacenDefecto > 0)
            {
                iIdalmacen.EditValue = idAlmacenDefecto;
            }

            iHoratransaccion.EditValue = DateTime.Now;
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
                    EntradaalmacenMnt = new Entradaalmacen();
                    CargarDetalle();

                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDocumentoReferencia();
                    CargarDetalle();
                    EstadoModificacionImportacion();
                    if (iAnulado.Checked)
                    {
                        DeshabilitarModificacion();
                    }
                    SumarTotales(false);
                    CargarReferenciasCpCompra();
                    break;
            }
        }
        private void CargarReferenciasCpCompra()
        {
            string filtro = string.Format(@"idcpcompra in (
                      select distinct a.idcpcompra
                      from almacen.entradaalmacendetitemcpcompradet a
                           left join almacen.entradaalmacendet b ON a.identradaalmacendet = b.identradaalmacendet
                           left join almacen.entradaalmacen c ON b.identradaalmacen = c.identradaalmacen
                      where c.identradaalmacen = {0})", IdEntidadMnt);
            List<VwCpcompra> vwCpcompraList = Service.GetAllVwCpcompra(filtro, "nombretipoformato,seriecpcompra,numerocpcompra");            
            gcCpCompraRef.DataSource = vwCpcompraList;
            gvCpCompraRef.BestFitColumns(true);
        }
        private void HabilitarBotonesMnt(bool enabled)
        {
            BarMnt.BeginUpdate();
            foreach (BarItem item in bmMantenimiento.Items)
            {
                item.Enabled = enabled;
            }
            BarMnt.EndUpdate();

            BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItems.EndUpdate();

            BarMntItemsUbicacion.BeginUpdate();
            foreach (BarItem item in bmUbicaciones.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItemsUbicacion.EndUpdate();

            btnCerrar.Enabled = !enabled;
            btnImprimir.Enabled = !enabled;
            btnActualizar.Enabled = !enabled;
            btnGenerarCpCompra.Enabled = !enabled;

            //BarMntItems.BeginUpdate();
            //foreach (BarItem item in bmItems.Items)
            //{
            //    item.Enabled = enabled;
            //}
            //BarMntItems.EndUpdate();

        }
        private void CargarReferencias()
        {
            VwSucursalList = Service.GetAllVwSucursal();
            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ENTRADA-ALM", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ENTRADA-ALM", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            string whereCp = string.Format("regcompras = '{0}'", "1");

            iIddocumentocompra.Properties.DataSource = Service.GetAllTipocppago(whereCp, "codigotipocppago");
            iIddocumentocompra.Properties.DisplayMember = "Nombretipocppago";
            iIddocumentocompra.Properties.ValueMember = "Idtipocppago";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereCpIng = string.Format("regventas = '{0}'", "1");
            iIddocumentoingreso.Properties.DataSource = Service.GetAllTipocppago(whereCpIng, "codigotipocppago");
            iIddocumentoingreso.Properties.DisplayMember = "Nombretipocppago";
            iIddocumentoingreso.Properties.ValueMember = "Idtipocppago";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipomoneda.Properties.DataSource = Service.GetAllTipomoneda();
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            ImpuestoList = Service.GetAllImpuesto();
            iIdimpuesto.Properties.DataSource = ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            AlmacenList = Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            //4: orden de compra, 5: Salida de almacen, 2: Comprobante de compra, 19: NC-CLIENTE
            TipodocmovList = Service.GetAllTipodocmov("idtipodocmov IN (4,5,2,19)", "nombretipodocmov");
            iIdtipodocmov.Properties.DataSource = TipodocmovList;
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                EntradaalmacenMnt = Service.GetEntradaalmacen(IdEntidadMnt);

                iIdsucursal.EditValue = EntradaalmacenMnt.Idsucursal;
                iIdalmacen.EditValue = EntradaalmacenMnt.Idalmacen;
                iIdtipocp.EditValue = EntradaalmacenMnt.Idtipocp;
                iIdcptooperacion.EditValue = EntradaalmacenMnt.Idcptooperacion;
                rSerieentradaalmacen.EditValue = EntradaalmacenMnt.Serieentradaalmacen;
                rNumeroentradaalmacen.EditValue = EntradaalmacenMnt.Numeroentradaalmacen;
                iIdempleado.EditValue = EntradaalmacenMnt.Idempleado;

                iIdsocionegocio.EditValue = EntradaalmacenMnt.Idsocionegocio;
                iFechaentrada.EditValue = EntradaalmacenMnt.Fechaentrada;
                iAnulado.EditValue = EntradaalmacenMnt.Anulado;
                iFechaanulado.EditValue = EntradaalmacenMnt.Fechaanulado;
                iTipocambio.EditValue = EntradaalmacenMnt.Tipocambio;
                iIdtipomoneda.EditValue = EntradaalmacenMnt.Idtipomoneda;
                iIdimpuesto.EditValue = EntradaalmacenMnt.Idimpuesto;
                iGlosa.EditValue = EntradaalmacenMnt.Glosa;
                iIddocumentocompra.EditValue = EntradaalmacenMnt.Iddocumentocompra;
                iSeriecpcompra.EditValue = EntradaalmacenMnt.Seriecpcompra;
                iNumerocpcompra.EditValue = EntradaalmacenMnt.Numerocpcompra;
                iIddocumentoingreso.EditValue = EntradaalmacenMnt.Iddocumentoingreso;
                iSerieguiaremision.EditValue = EntradaalmacenMnt.Serieguiaremision;
                iNumeroguiaremision.EditValue = EntradaalmacenMnt.Numeroguiaremision;
                iIdtipodocmov.EditValue = EntradaalmacenMnt.Idtipodocmov;
                rTotalbruto.EditValue = EntradaalmacenMnt.Totalbruto;
                rTotalgravado.EditValue = EntradaalmacenMnt.Totalgravado;
                rTotalinafecto.EditValue = EntradaalmacenMnt.Totalinafecto;
                rTotalexonerado.EditValue = EntradaalmacenMnt.Totalexonerado;
                rImportetotal.EditValue = EntradaalmacenMnt.Importetotal;
                rPorcentajepercepcion.EditValue = EntradaalmacenMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = EntradaalmacenMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = EntradaalmacenMnt.Totaldocumento;
                rTotalimpuesto.EditValue = EntradaalmacenMnt.Totalimpuesto;
                iIncluyeimpuestoitems.EditValue = EntradaalmacenMnt.Incluyeimpuestoitems;
                iHoratransaccion.EditValue = EntradaalmacenMnt.Horatransaccion;

            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        public void CargarDetalle()
        {
            string where = string.Format("idEntradaalmacen = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwEntradaalmacendetList = Service.GetAllVwEntradaalmacendet(where, "numeroitem");
            gcDetalle.DataSource = VwEntradaalmacendetList;
            gcDetalle.EndUpdate();
            gvDetalle.BestFitColumns();

        }
        public bool Guardar()
        {

            if (!Validaciones()) return false;

            EntradaalmacenMnt.Idsucursal = (int?)iIdsucursal.EditValue;
            EntradaalmacenMnt.Idalmacen = (int?)iIdalmacen.EditValue;
            EntradaalmacenMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            EntradaalmacenMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            EntradaalmacenMnt.Serieentradaalmacen = rSerieentradaalmacen.Text.Trim();
            EntradaalmacenMnt.Numeroentradaalmacen = rNumeroentradaalmacen.Text.Trim();
            EntradaalmacenMnt.Idempleado = (int?)iIdempleado.EditValue;
            EntradaalmacenMnt.Idsocionegocio = (int?)iIdsocionegocio.EditValue;
            EntradaalmacenMnt.Fechaentrada = (DateTime)iFechaentrada.EditValue;
            EntradaalmacenMnt.Anulado = (bool)iAnulado.EditValue;
            EntradaalmacenMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            EntradaalmacenMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            EntradaalmacenMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;
            EntradaalmacenMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;
            EntradaalmacenMnt.Glosa = iGlosa.Text.Trim();
            EntradaalmacenMnt.Iddocumentocompra = (int?)iIddocumentocompra.EditValue;
            EntradaalmacenMnt.Seriecpcompra = iSeriecpcompra.Text.Trim();
            EntradaalmacenMnt.Numerocpcompra = iNumerocpcompra.Text.Trim();
            EntradaalmacenMnt.Iddocumentoingreso = (int)iIddocumentoingreso.EditValue;
            EntradaalmacenMnt.Serieguiaremision = iSerieguiaremision.Text.Trim();
            EntradaalmacenMnt.Numeroguiaremision = iNumeroguiaremision.Text.Trim();
            EntradaalmacenMnt.Idtipodocmov = (int?)iIdtipodocmov.EditValue;
            EntradaalmacenMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            EntradaalmacenMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            EntradaalmacenMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            EntradaalmacenMnt.Totalexonerado = (decimal)rTotalexonerado.EditValue;
            EntradaalmacenMnt.Importetotal = (decimal)rImportetotal.EditValue;
            EntradaalmacenMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            EntradaalmacenMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            EntradaalmacenMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            EntradaalmacenMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            EntradaalmacenMnt.Incluyeimpuestoitems = iIncluyeimpuestoitems.Checked;

            EntradaalmacenMnt.Horatransaccion = (DateTime)iHoratransaccion.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    EntradaalmacenMnt.Createdby = IdUsuario;
                    EntradaalmacenMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    EntradaalmacenMnt.Modifiedby = IdUsuario;
                    EntradaalmacenMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        IdEntidadMnt = Service.SaveEntradaalmacen(EntradaalmacenMnt);
                        EntradaalmacenMnt.Identradaalmacen = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        DataEntityState = DataEntityState.Added;

                        if (IdEntidadMnt > 0
                            && TipoCpMnt.Numeracionauto
                            && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumeroentradaalmacen.EditValue)))
                        {
                            iIdtipocp.ReadOnly = true;
                            iIdcptooperacion.ReadOnly = true;
                        }

                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateEntradaalmacen(EntradaalmacenMnt);
                        DataEntityState = DataEntityState.Modified;
                        if (EntradaalmacenMnt.Anulado)
                        {
                            AnularEntradaDeAlmacen();
                        }
                        break;
                }
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                Cursor = Cursors.Default;
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        private decimal CostoPromedio(int idArticulo, DateTime fechaInicio, DateTime fechaFinal, int idEmpresa)
        {
            string sqlQuery = "inntecc.fnultimocostopromedioarticulo";
            object[] parametrosConsulta = { 
                        idArticulo,
                        fechaInicio,
                        fechaFinal,
                        idEmpresa
                    };
            DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            DataRow dr = dt.Rows[0];
            return Convert.ToDecimal(dr["fnultimocostopromedioarticulo"]);
        }
        public void ActualizarListaDePrecioDesdeCostoPromedio()
        {
            int idtipodocmov = (int)iIdtipodocmov.EditValue;
            if (idtipodocmov == 2 || idtipodocmov == 4) //CPCOMPRA y ORDENCOMPRA
            {
                DateTime fechaInicio = FechaInicialInventario();
                DateTime fechaFinal = TipoMnt == TipoMantenimiento.Nuevo ? SessionApp.DateServer : (DateTime)iFechaentrada.EditValue;
                List<VwListaprecio> vwListaprecioList = Service.GetAllVwListaprecio("Agregararticuloauto = '1'", "Tipolistaprecio");
                foreach (VwEntradaalmacendet vwEntradaalmacendet in VwEntradaalmacendetList)
                {
                    foreach (VwListaprecio vwListaprecio in vwListaprecioList)
                    {
                        decimal costoPromedio = CostoPromedio(vwEntradaalmacendet.Idarticulo, fechaInicio, fechaFinal, SessionApp.EmpresaSel.Idempresa);
                        Service.ActualizarArticuloListaPrecioDesdeCostoPromedio(vwEntradaalmacendet.Idarticulo, vwListaprecio.Idlistaprecio, costoPromedio);
                    }
                }
            }
        }
        private DateTime FechaInicialInventario()
        {
            DateTime fechaInicio = new DateTime();
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
            }
            return fechaInicio;
        }
        public bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpReferencias, _errorProvider))
            {
                tcRequerimiento.SelectedTabPage = tpReferencias;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            //if (iIddocumentoingreso.EditValue == null || iSerieguiaremision.Text.Trim() == "0000" || iNumeroguiaremision.Text.Trim() == @"00000000")
            //{
            //    tcRequerimiento.SelectedTabPage = tpReferencias;
            //    XtraMessageBox.Show("Ingrese el documento ingreso", Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);                
            //    return false;
            //}

            //if (iIddocumentocompra.EditValue == null || iSeriecpcompra.Text.Trim() == "0000" || iNumerocpcompra.Text.Trim() == @"00000000")
            //{
            //    //tcRequerimiento.SelectedTabPage = tpReferencias;
            //    //XtraMessageBox.Show("Ingrese el documento de compra", Resources.titAtencion, MessageBoxButtons.OK,
            //    //    MessageBoxIcon.Warning);
            //    //iIddocumentocompra.Select();
            //    //return false;
            //    if (iIddocumentoingreso.EditValue == null || iSerieguiaremision.Text.Trim() == "0000" || iNumeroguiaremision.Text.Trim() == @"00000000")
            //    {
            //        tcRequerimiento.SelectedTabPage = tpReferencias;
            //        XtraMessageBox.Show("Ingrese el documento de compra ó ingreso", Resources.titAtencion, MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);
            //        //iIddocumentoingreso.Select();
            //        return false;
            //    }
            //}


            //if (iIddocumentoingreso.EditValue == null || iSerieguiaremision.Text.Trim() == "0000" || iNumeroguiaremision.Text.Trim() == @"00000000")
            //{
            //    //tcRequerimiento.SelectedTabPage = tpReferencias;
            //    //XtraMessageBox.Show("Ingrese el documento de compra", Resources.titAtencion, MessageBoxButtons.OK,
            //    //    MessageBoxIcon.Warning);
            //    //iIddocumentocompra.Select();
            //    //return false;
            //    if (iIddocumentocompra.EditValue == null || iSeriecpcompra.Text.Trim() == "0000" || iNumerocpcompra.Text.Trim() == @"00000000")
            //    {
            //        tcRequerimiento.SelectedTabPage = tpReferencias;
            //        XtraMessageBox.Show("Ingrese el documento de compra ó ingreso", Resources.titAtencion, MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning);
            //        //iIddocumentoingreso.Select();
            //        return false;
            //    }
            //}


            //var idTipoMonedaSel = iIdtipomoneda.EditValue;
            //decimal tipoCambio = (decimal)iTipocambio.EditValue;
            //if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            //{
            //    XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    iTipocambio.Select();
            //    return false;
            //}

            //if (iSerieguiaremision.Text.Trim() == "0000")
            //{
            //    tcRequerimiento.SelectedTabPage = tpReferencias;
            //    XtraMessageBox.Show("El número de serie Ingreso no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    iSerieguiaremision.Focus();
            //    return false;
            //}

            //if (iNumeroguiaremision.Text.Trim() == "00000000")
            //{
            //    tcRequerimiento.SelectedTabPage = tpReferencias;
            //    XtraMessageBox.Show("El número de comprobante Ingreso no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    iNumeroguiaremision.Focus();
            //    return false;
            //}



            //int idPersona = TipoMnt == TipoMantenimiento.Nuevo ? 0 : IdEntidadMnt;

            //if (Service.NroDocumentoPersonaExiste(iNrodocentidad.Text.Trim(), idPersona))
            //{
            //    XtraMessageBox.Show("Número de documento ya existe.", "Documento de identidad", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    iNrodocentidad.Focus();
            //    return false;
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
                    //iAnulado.Enabled = Permisos.Anular;
                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    //iAnulado.Enabled = Permisos.Anular;
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

                    TipoMnt = TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    EntradaalmacenMnt = null;
                    EntradaalmacenMnt = new Entradaalmacen();

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

                    //EntradaalmacenMnt = null;
                    DialogResult = DialogResult.OK;

                    break;
                case "btnImprimir":
                    //if (EntradaalmacenImpresion == null)
                    //{
                    //    EntradaalmacenImpresion = new EntradaalmacenImpresion();
                    //}
                    //if (IdEntidadMnt > 0)
                    //{
                    //    EntradaalmacenImpresion.VistaPrevia(IdEntidadMnt);
                    //}
                    break;
                case "btnGenerarCpCompra":
                    if (IdEntidadMnt <= 0)
                    {
                        return;
                    }
                    VwEntradaalmacen vwEntradaalmacenOrigen = Service.GetVwEntradaalmacen(IdEntidadMnt);
                    if (vwEntradaalmacenOrigen != null)
                    {
                        List<VwEntradaalmacendet> vwEntradaalmacendetListOrigen =
                            Service.GetAllVwEntradaalmacendet(string.Format("identradaalmacen = {0}", vwEntradaalmacenOrigen.Identradaalmacen ),"numeroitem");
                        if (vwEntradaalmacendetListOrigen != null)
                        {
                            CpcompraMntFrm cpcompraMntFrm = new CpcompraMntFrm(0, TipoMantenimiento.Nuevo, null, null, vwEntradaalmacenOrigen, vwEntradaalmacendetListOrigen);
                            if (cpcompraMntFrm.ShowDialog() == DialogResult.OK)
                            {
                                //MessageBox.Show(cpcompraMntFrm.IdEntidadMnt.ToString());

                            }

                        }
                    }
                    break;
            }
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
        private void EntradaalmacenMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            //XtraFormUtils.ReadOnlyFields(this, readOnly);
            WinFormUtils.ReadOnlyFields(tpDatos, readOnly);
            WinFormUtils.ReadOnlyFields(tpReferencias, readOnly);
        }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Validaciones())
            {
                return;
            }

            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            EntradaalmacenMntItemFrm entradaalmacenMntItemFrm;
            VwEntradaalmacendet vwEntradaalmacendetMnt = new VwEntradaalmacendet();
            Entradaalmacendet entradaalmacendet;
            const string nombreIdDetalle = "Identradaalmacendet";

            ParametrosAlmacen.Idalmacen = (int)iIdalmacen.EditValue;


            //Propiedades para consulta
            int idSucursalConsulta = 0;
            int idAlmacenConsulta = 0;
            int idTipoListaConsulta = 0;

            VwSucursal vwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)iIdsucursal.EditValue);
            if (vwSucursalSel != null)
            {
                idSucursalConsulta = vwSucursalSel.Idsucursal;
                idAlmacenConsulta = (int)iIdalmacen.EditValue;
                idTipoListaConsulta = (int)iIdtipolista.EditValue;
            }

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwEntradaalmacendetMnt.Numeroitem = VwEntradaalmacendetList.Count + 1;

                    entradaalmacenMntItemFrm = new EntradaalmacenMntItemFrm(tipoMantenimientoItem, vwEntradaalmacendetMnt);
                    entradaalmacenMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    entradaalmacenMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    entradaalmacenMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;

                    entradaalmacenMntItemFrm.ShowDialog();

                    if (entradaalmacenMntItemFrm.DialogResult == DialogResult.OK)
                    {

                        entradaalmacendet = AsignarEntradaAlmacenDetalle(vwEntradaalmacendetMnt);
                        int identradaalmacendet = Service.SaveEntradaalmacendet(entradaalmacendet);
                        if (identradaalmacendet > 0)
                        {
                            vwEntradaalmacendetMnt.Identradaalmacendet = identradaalmacendet;
                            VwEntradaalmacendetList.Add(vwEntradaalmacendetMnt);


                            //Agregar los detalles de componente
                            if (entradaalmacenMntItemFrm.VwEntradaalmacendetComponenteList != null && entradaalmacenMntItemFrm.VwEntradaalmacendetComponenteList.Count > 0)
                            {
                                foreach (VwEntradaalmacendet itemComponente in entradaalmacenMntItemFrm.VwEntradaalmacendetComponenteList)
                                {
                                    Entradaalmacendet entradaalmacendetComponente = AsignarEntradaAlmacenDetalle(itemComponente);
                                    int identradaalmacendetComponente = Service.SaveEntradaalmacendet(entradaalmacendetComponente);
                                    if (identradaalmacendetComponente > 0)
                                    {
                                        itemComponente.Identradaalmacendet = identradaalmacendetComponente;
                                        VwEntradaalmacendetList.Add(itemComponente);
                                    }
                                }
                            }
                            //

                            SumarTotales(true);
                            //Enfocar el id generado
                            if (identradaalmacendet > 0)
                            {
                                gvDetalle.BeginUpdate();
                                var rowHandle = gvDetalle.LocateByValue(nombreIdDetalle, identradaalmacendet);
                                if (rowHandle == GridControl.InvalidRowHandle)
                                {
                                    gvDetalle.EndUpdate();
                                    return;
                                }
                                gvDetalle.EndUpdate();
                                gvDetalle.FocusedRowHandle = rowHandle;
                            }

                            gvDetalle.RefreshData();
                            gvDetalle.BestFitColumns(true);

                        }


                        //Verificar las ubicacion registradas por articulo
                        long cantidadRefUbicaciones = Service.CountVwArticuloubicacion(
                            x => x.Idarticulo == vwEntradaalmacendetMnt.Idarticulo
                            && x.Idalmacen == (int)iIdalmacen.EditValue);

                        if (cantidadRefUbicaciones == 0)
                        {
                            //Insertar ubicacion por defecto
                            Almacen almacenSel = AlmacenList.FirstOrDefault(x => x.Idalmacen == (int)iIdalmacen.EditValue);
                            if (almacenSel != null)
                            {

                                if (identradaalmacendet > 0)
                                {
                                    Entradaalmacenubicacion entradaalmacenubicacion = new Entradaalmacenubicacion
                                    {
                                        Identradaalmacendet = identradaalmacendet,
                                        Idubicacion = almacenSel.Idubicaciondefecto,
                                        Cantidadarticulo = entradaalmacendet.Cantidad
                                    };
                                    Service.SaveEntradaalmacenubicacion(entradaalmacenubicacion);

                                    //Agregar al articulo la ubicacion por defecto
                                    Articuloubicacion articuloubicacion = new Articuloubicacion();
                                    articuloubicacion.Idarticulo = vwEntradaalmacendetMnt.Idarticulo;
                                    articuloubicacion.Idubicacion = Convert.ToInt32(almacenSel.Idubicaciondefecto);
                                    Service.SaveArticuloubicacion(articuloubicacion);
                                }
                            }

                            CargarDetalleUbicaciones();
                        }
                        else
                        {
                            //Insertar la ubicaciones del articulo del almacen seleccionado
                            List<VwArticuloubicacion> vwArticuloubicacionList = Service.GetAllVwArticuloubicacion(
                                x => x.Idarticulo == vwEntradaalmacendetMnt.Idarticulo
                                && x.Idalmacen == (int)iIdalmacen.EditValue);

                            foreach (var vwArticuloubicacion in vwArticuloubicacionList)
                            {
                                Entradaalmacenubicacion entradaalmacenubicacion = new Entradaalmacenubicacion
                                {
                                    Identradaalmacendet = identradaalmacendet,
                                    Idubicacion = vwArticuloubicacion.Idubicacion,
                                    Cantidadarticulo = 0m
                                };
                                Service.SaveEntradaalmacenubicacion(entradaalmacenubicacion);
                            }
                            CargarDetalleUbicaciones();
                        }
                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwEntradaalmacendetMnt = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();
                    if (vwEntradaalmacendetMnt == null)
                    {
                        break;
                    }

                    entradaalmacenMntItemFrm = new EntradaalmacenMntItemFrm(tipoMantenimientoItem, vwEntradaalmacendetMnt);
                    entradaalmacenMntItemFrm.ShowDialog();

                    if (entradaalmacenMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        entradaalmacendet = AsignarEntradaAlmacenDetalle(vwEntradaalmacendetMnt);
                        Service.UpdateEntradaalmacendet(entradaalmacendet);
                        gvDetalle.RefreshData();
                        SumarTotales(true);
                    }

                    break;

                case "btnDelItem":
                    int idEntradaalmacendetSel = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));
                    if (idEntradaalmacendetSel > 0)
                    {
                        int cantidadRefUbicaciones = VwEntradaalmacenubicacionList.Count(x => x.Identradaalmacendet == idEntradaalmacendetSel);
                        if (cantidadRefUbicaciones > 0)
                        {
                            XtraMessageBox.Show("No puede eliminar tiene referencia de ubicaciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwEntradaalmacendet vwEntradaalmacendet = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();
                            if (VwEntradaalmacendetList.Remove(vwEntradaalmacendet))
                            {
                                Service.DeleteEntradaalmacendet(idEntradaalmacendetSel);
                                gvDetalle.RefreshData();
                                if (!gvDetalle.IsFirstRow)
                                {
                                    gvDetalle.MovePrev();
                                }

                                if (gvDetalle.RowCount == 0)
                                {
                                    AnularEntradaDeAlmacen();

                                    EntradaalmacenMnt.Idordencompra = null;
                                    rDocReferencia.EditValue = string.Empty;
                                    rNumeroRef.EditValue = string.Empty;
                                    rFechaDocRef.EditValue = string.Empty;
                                    EstadoModificacionImportacion();
                                }
                                SumarTotales(true);
                            }
                        }
                    }
                    break;


            }
        }
        public void EstadoModificacionImportacion()
        {
            bool estado = rDocReferencia.Text.Trim().Length > 0;
            iIdtipodocmov.Enabled = !estado;
            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = !estado;
            }
            btnImportar.Enabled = !estado;
        }
        private void AnularEntradaDeAlmacen()
        {
            Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);
            Entradaalmacen entradaalmacen = Service.GetEntradaalmacen(x => x.Identradaalmacen == IdEntidadMnt);

            if (tipodocmovSel != null && entradaalmacen != null && entradaalmacen.Anulado)
            {
                string sqlCommandAnular;
                switch (tipodocmovSel.Nombretipodocmov)
                {
                    case "CPVENTA":
                        break;
                    case "CPCOMPRA":
                        sqlCommandAnular =
                        string.Format(@"UPDATE almacen.entradaalmacen set idcpcompra = null where identradaalmacen = {0};
                                        UPDATE almacen.entradaalmacendet set idcpcompradet = null where identradaalmacen = {0};",
                                        IdEntidadMnt);
                        Service.AnularEntradaDeAlmacen(sqlCommandAnular);
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        sqlCommandAnular =
                        string.Format(@"UPDATE almacen.entradaalmacen set idordencompra = null where identradaalmacen = {0};
                                        UPDATE almacen.entradaalmacendet set idordencompradet = null where identradaalmacen = {0};",
                                        IdEntidadMnt);
                        Service.AnularEntradaDeAlmacen(sqlCommandAnular);
                        break;
                    case "SALIDA-ALM":
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        sqlCommandAnular =
                        string.Format(@"UPDATE almacen.entradaalmacen set idguiaremision = null where identradaalmacen = {0};
                                        UPDATE almacen.entradaalmacendet set idguiaremisiondet = null where identradaalmacen = {0};",
                                        IdEntidadMnt);
                        Service.AnularEntradaDeAlmacen(sqlCommandAnular);
                        break;
                    case "NC-PROVEEDOR":
                        break;
                    case "ND-PROVEEDOR":
                        break;
                    case "COTIZA-CLIENTE":
                        break;
                    case "ORDEN-VENTA":
                        break;
                    case "VALORIZA-VENTA":
                        break;
                    case "NC-CLIENTE":
                        sqlCommandAnular =
                        string.Format(@"UPDATE almacen.entradaalmacen set idnotacreditocli = null where identradaalmacen = {0};
                                        UPDATE almacen.entradaalmacendet set idnotacreditoclidet = null where identradaalmacen = {0};",
                                        IdEntidadMnt);
                        Service.AnularEntradaDeAlmacen(sqlCommandAnular);
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                }

            }
        }
        private void CargarDetalleUbicaciones()
        {
            VwEntradaalmacendet entradaalmacendet = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();
            if (entradaalmacendet != null)
            {
                string condicion = string.Format("identradaalmacendet ={0}", entradaalmacendet.Identradaalmacendet);
                const string orden = "identradaalmacenubicacion";
                VwEntradaalmacenubicacionList = Service.GetAllVwEntradaalmacenubicacion(condicion, orden);
                gcUbicacionDet.DataSource = VwEntradaalmacenubicacionList;
                //gvUbicacionDet.BestFitColumns(true);
            }
        }
        private void SumarTotales(bool actualizar)
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            decimal totalbruto = VwEntradaalmacendetList.Where(w => w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwEntradaalmacendetList.Where(w => w.Gravado && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwEntradaalmacendetList.Where(w => w.Inafecto).Sum(s => s.Importetotal);
            decimal totalexonerado = VwEntradaalmacendetList.Where(w => w.Exonerado && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwEntradaalmacendetList.Where(
                    w => w.Porcentajepercepcion > 0
                    && w.Gravado
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                rImportetotalpercepcion.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalValorPercepcion : totalValorPercepcion * factorImpuesto, 2);
                rTotalgravado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado / factorImpuesto : totalgravado, 2);
                rTotalinafecto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalinafecto / factorImpuesto : totalinafecto, 2);
                rTotalexonerado.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalexonerado / factorImpuesto : totalexonerado, 2);

                rTotalimpuesto.EditValue = decimal.Round(iIncluyeimpuestoitems.Checked ? totalgravado - (decimal)rTotalgravado.EditValue : totalgravado * porcentajeImpuesto / 100, 2);
                rImportetotal.EditValue = (decimal)rTotalgravado.EditValue + (decimal)rTotalinafecto.EditValue + (decimal)rTotalexonerado.EditValue + +(decimal)rTotalimpuesto.EditValue;
                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rImportetotalpercepcion.EditValue;
            }

            if (actualizar)
            {
                Entradaalmacen entradaalmacen = new Entradaalmacen();
                entradaalmacen.Identradaalmacen = IdEntidadMnt;
                entradaalmacen.Totalbruto = (decimal)rTotalbruto.EditValue;
                entradaalmacen.Totalgravado = (decimal)rTotalgravado.EditValue;
                entradaalmacen.Totalinafecto = (decimal)rTotalinafecto.EditValue;
                entradaalmacen.Totalexonerado = (decimal)rTotalexonerado.EditValue;
                entradaalmacen.Importetotal = (decimal)rImportetotal.EditValue;
                entradaalmacen.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
                entradaalmacen.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
                entradaalmacen.Totaldocumento = (decimal)rTotaldocumento.EditValue;
                entradaalmacen.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
                Service.ActualizarTotalesEntradaAlmacen(entradaalmacen);
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);

            //Si tiene registro el detalle deshabilitar
            iIdalmacen.ReadOnly = gvDetalle.RowCount > 0;
        }
        private Entradaalmacendet AsignarEntradaAlmacenDetalle(VwEntradaalmacendet vwEntradaalmacendet)
        {
            Entradaalmacendet entradaalmacendetMnt = new Entradaalmacendet
            {
                Identradaalmacendet = vwEntradaalmacendet.Identradaalmacendet,
                Identradaalmacen = IdEntidadMnt,
                Numeroitem = vwEntradaalmacendet.Numeroitem,
                Idarticulo = vwEntradaalmacendet.Idarticulo,
                Idimpuesto = vwEntradaalmacendet.Idimpuesto,
                Idunidadmedida = vwEntradaalmacendet.Idunidadmedida,
                Especificacion = vwEntradaalmacendet.Especificacion,
                Cantidad = vwEntradaalmacendet.Cantidad,
                Preciounitario = vwEntradaalmacendet.Preciounitario,
                Importetotal = vwEntradaalmacendet.Importetotal,
                Idproyecto = vwEntradaalmacendet.Idproyecto,
                Idarea = vwEntradaalmacendet.Idarea,
                Idcentrodecosto = vwEntradaalmacendet.Idcentrodecosto,
                Porcentajepercepcion = vwEntradaalmacendet.Porcentajepercepcion,
                Idtipoafectacionigv = vwEntradaalmacendet.Idtipoafectacionigv,
                Calcularitem = vwEntradaalmacendet.Calcularitem
            };
            return entradaalmacendetMnt;
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
                        rSerieentradaalmacen.EditValue = vwTipocp.Seriecp;
                        rNumeroentradaalmacen.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroentradaalmacen.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroentradaalmacen.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroentradaalmacen.EditValue = vwTipocp.Seriecp;
                        rNumeroentradaalmacen.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroentradaalmacen.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieentradaalmacen.EditValue = @"0000";
                rNumeroentradaalmacen.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            VwSocionegocio vwSocionegocioSel;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        vwSocionegocioSel = buscarSocioNegocioFrm.VwSocionegocioSel;

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;

                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdsocionegocio.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                            beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                            iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                        }
                    }
                    break;
            }
        }
        private void iIdsocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioMnt = iIdsocionegocio.EditValue;
            if (idSocioNegocioMnt == null || (int)idSocioNegocioMnt <= 0) return;

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int)idSocioNegocioMnt);
            VwSocionegocioSel = vwSocionegocioSel;
            if (vwSocionegocioSel != null)
            {
                beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                iIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
            }
        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "ENTRADA-ALM";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            beSocioNegocio.Tag = string.IsNullOrEmpty(beSocioNegocio.Text) ? null : "Seleccione el proveedor";

            if (!Validaciones()) return;

            Almacen almacenSel = AlmacenList.FirstOrDefault(x => x.Idalmacen == (int)iIdalmacen.EditValue);
            Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);

            if (DialogResult.No == XtraMessageBox.Show(string.Format("¿El almacén de entrada es {0}?", iIdalmacen.Text.Trim()),
                "Confirmar almacén", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                return;
            }

            if (tipodocmovSel != null)
            {
                switch (tipodocmovSel.Nombretipodocmov)
                {
                    case "CPVENTA":
                        break;
                    case "CPCOMPRA":
                        EntradaalmacenImpCpCompraFrm entradaalmacenImpCpCompraFrm = new EntradaalmacenImpCpCompraFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        entradaalmacenImpCpCompraFrm.ShowDialog();
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        EntradaalmacenImpOrdenCompraFrm entradaalmacenImpOrdenCompraFrm = new EntradaalmacenImpOrdenCompraFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        entradaalmacenImpOrdenCompraFrm.ShowDialog();
                        break;
                    case "SALIDA-ALM":
                        EntradaalmacenImpSalidaAlmacenFrm entradaalmacenImpSalidaAlmacenFrm = new EntradaalmacenImpSalidaAlmacenFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        entradaalmacenImpSalidaAlmacenFrm.ShowDialog();
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        break;
                    case "NC-PROVEEDOR":
                        break;
                    case "ND-PROVEEDOR":
                        break;
                    case "COTIZA-CLIENTE":
                        break;
                    case "ORDEN-VENTA":
                        break;
                    case "VALORIZA-VENTA":
                        break;
                    case "NC-CLIENTE":
                        EntradaalmacenImpNotaCreditoClienteFrm entradaalmacenImpNotaCreditoClienteFrm = new EntradaalmacenImpNotaCreditoClienteFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        entradaalmacenImpNotaCreditoClienteFrm.ShowDialog();
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                }

            }
            SumarTotales(true);
        }
        public void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);

            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = false;
            }
            btnImportar.Enabled = false;
        }
        public void CargarDocumentoReferencia()
        {
            Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);
            if (tipodocmovSel != null)
            {
                switch (tipodocmovSel.Nombretipodocmov)
                {
                    case "CPVENTA":
                        break;
                    case "CPCOMPRA":
                        VwCpcompra vwCpcompra = Service.GetVwCpcompra(x => x.Idcpcompra == EntradaalmacenMnt.Idcpcompra);
                        if (vwCpcompra != null)
                        {
                            rDocReferencia.EditValue = vwCpcompra.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwCpcompra.Seriecpcompra, vwCpcompra.Numerocpcompra);
                            rFechaDocRef.EditValue = vwCpcompra.Fechaemision.ToString();
                            iIdtipomoneda.Enabled = false;
                        }
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        VwOrdencompra vwOrdencompra = Service.GetVwOrdencompra(x => x.Idordencompra == EntradaalmacenMnt.Idordencompra);
                        if (vwOrdencompra != null)
                        {
                            rDocReferencia.EditValue = vwOrdencompra.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwOrdencompra.Serieorden, vwOrdencompra.Numeroorden);
                            rFechaDocRef.EditValue = vwOrdencompra.Fechaordencompra.ToString();
                            iIdtipomoneda.Enabled = false;
                        }
                        break;
                    case "SALIDA-ALM":
                        VwSalidaalmacen vwSalidaalmacen = Service.GetVwSalidaalmacen(x => x.Idsalidaalmacen == EntradaalmacenMnt.Idsalidaalmacen);
                        if (vwSalidaalmacen != null)
                        {
                            rDocReferencia.EditValue = vwSalidaalmacen.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwSalidaalmacen.Seriesalidaalmacen, vwSalidaalmacen.Numerosalidaalmacen);
                            rFechaDocRef.EditValue = vwSalidaalmacen.Fechasalida.ToString();
                            iIdtipomoneda.Enabled = false;
                        }
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        break;
                    case "NC-PROVEEDOR":
                        break;
                    case "ND-PROVEEDOR":
                        break;
                    case "COTIZA-CLIENTE":
                        break;
                    case "ORDEN-VENTA":
                        break;
                    case "VALORIZA-VENTA":
                        break;
                    case "NC-CLIENTE":
                        VwNotacreditocli vwNotacreditocli = Service.GetVwNotacreditocli(x => x.Idnotacreditocli == EntradaalmacenMnt.Idnotacreditocli);
                        if (vwNotacreditocli != null)
                        {
                            rDocReferencia.EditValue = vwNotacreditocli.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwNotacreditocli.Serienotacredito, vwNotacreditocli.Numeronotacredito);
                            rFechaDocRef.EditValue = vwNotacreditocli.Fechaemision.ToString();
                            iIdtipomoneda.Enabled = false;
                        }
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                }

            }
        }
        private void gvDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CargarDetalleUbicaciones();
        }
        private void bmUbicaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            EntradaalmacenubicacionMntItemFrm entradaalmacenubicacionMntItemFrm;
            const string nombreidentradaalmacenubicacion = "Identradaalmacenubicacion";
            VwEntradaalmacendet vwEntradaalmacendetRef = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();
            VwEntradaalmacenubicacion vwEntradaalmacenubicacionMnt;
            if (vwEntradaalmacendetRef == null)
            {
                return;
            }


            switch (e.Item.Name)
            {
                case "cmdAddUbicacion":
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwEntradaalmacenubicacionMnt = new VwEntradaalmacenubicacion();
                    entradaalmacenubicacionMntItemFrm = new EntradaalmacenubicacionMntItemFrm(tipoMantenimientoItem, vwEntradaalmacendetRef, vwEntradaalmacenubicacionMnt);

                    entradaalmacenubicacionMntItemFrm.IdAlmacenSel = (int)iIdalmacen.EditValue;
                    entradaalmacenubicacionMntItemFrm.ShowDialog();

                    if (entradaalmacenubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Entradaalmacenubicacion entradaalmacenubicacion = AsignarEntradaAlmacenUbicacion(vwEntradaalmacenubicacionMnt);

                        int identradaalmacenubicacion = Service.SaveEntradaalmacenubicacion(entradaalmacenubicacion);
                        if (identradaalmacenubicacion > 0)
                        {
                            vwEntradaalmacenubicacionMnt.Identradaalmacenubicacion = identradaalmacenubicacion;
                        }

                        VwEntradaalmacenubicacionList.Add(vwEntradaalmacenubicacionMnt);
                        gvUbicacionDet.RefreshData();

                        //Enfocar el id generado
                        if (identradaalmacenubicacion > 0)
                        {
                            gvUbicacionDet.BeginUpdate();
                            var rowHandle = gvUbicacionDet.LocateByValue(nombreidentradaalmacenubicacion, identradaalmacenubicacion);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {
                                gvUbicacionDet.EndUpdate();
                                return;
                            }
                            gvUbicacionDet.EndUpdate();
                            gvUbicacionDet.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;
                case "cmdEditUbicacion":

                    if (gvUbicacionDet.RowCount <= 0)
                    {
                        return;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwEntradaalmacenubicacionMnt = (VwEntradaalmacenubicacion)gvUbicacionDet.GetFocusedRow();
                    entradaalmacenubicacionMntItemFrm = new EntradaalmacenubicacionMntItemFrm(tipoMantenimientoItem, vwEntradaalmacendetRef, vwEntradaalmacenubicacionMnt);

                    entradaalmacenubicacionMntItemFrm.IdAlmacenSel = (int)iIdalmacen.EditValue;
                    entradaalmacenubicacionMntItemFrm.ShowDialog();
                    if (entradaalmacenubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Entradaalmacenubicacion entradaalmacenubicacion = AsignarEntradaAlmacenUbicacion(vwEntradaalmacenubicacionMnt);

                        Service.UpdateEntradaalmacenubicacion(entradaalmacenubicacion);
                        gvUbicacionDet.RefreshData();
                    }
                    break;
                case "cmdDelUbicacion":
                    int identradaalmacenubicacionSel = Convert.ToInt32(gvUbicacionDet.GetRowCellValue(gvUbicacionDet.FocusedRowHandle, nombreidentradaalmacenubicacion));
                    if (identradaalmacenubicacionSel > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwEntradaalmacenubicacion vwEntradaalmacenubicacionSel = (VwEntradaalmacenubicacion)gvUbicacionDet.GetFocusedRow();
                            if (VwEntradaalmacenubicacionList.Remove(vwEntradaalmacenubicacionSel))
                            {
                                Service.DeleteEntradaalmacenubicacion(identradaalmacenubicacionSel);
                                gvUbicacionDet.RefreshData();
                            }

                        }
                    }
                    break;
            }
        }
        private Entradaalmacenubicacion AsignarEntradaAlmacenUbicacion(VwEntradaalmacenubicacion vwEntradaalmacenubicacionMnt)
        {
            Entradaalmacenubicacion entradaalmacenubicacion = new Entradaalmacenubicacion();
            entradaalmacenubicacion.Identradaalmacenubicacion = vwEntradaalmacenubicacionMnt.Identradaalmacenubicacion;
            entradaalmacenubicacion.Identradaalmacendet = vwEntradaalmacenubicacionMnt.Identradaalmacendet;
            entradaalmacenubicacion.Idubicacion = vwEntradaalmacenubicacionMnt.Idubicacion;
            entradaalmacenubicacion.Cantidadarticulo = vwEntradaalmacenubicacionMnt.Cantidadarticulo;
            return entradaalmacenubicacion;
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwEntradaalmacendetList != null)
            {
                SumarTotales(false);
            }
        }
        private void EntradaalmacenMntFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //int cantidadModificados = VwEntradaalmacendetList.Count(x => x.DataEntityState == DataEntityState.Modified);

            //if (cantidadModificados > 0 && iAnulado.Checked == false && VwEntradaalmacendetList.Count > 0)
            if (iAnulado.Checked == false && VwEntradaalmacendetList.Count > 0)
            {
                //ActualizarListaDePrecioDesdeCostoPromedio();
            }
        }
        private void EntradaalmacenMntFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msgItemsCantidadInvalida = CantidadUbicacionEsValido();
            if (msgItemsCantidadInvalida.Length > 0)
            {
                XtraMessageBox.Show(
                    "Existe productos con cantidad invalida en las ubicaciones. Verique.\n\n" + msgItemsCantidadInvalida,
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private string CantidadUbicacionEsValido()
        {
            string msgValidacion = string.Empty;

            List<VwEntradaalmacendetverificacioncantidad> vwEntradaalmacendetverificacioncantidadList =
            Service.GetAllVwEntradaalmacendetverificacioncantidad(x => x.Cantidad != x.Cantidadubicacion && x.Identradaalmacen == IdEntidadMnt);
            if (vwEntradaalmacendetverificacioncantidadList != null &&
                vwEntradaalmacendetverificacioncantidadList.Count > 0)
            {
                foreach (var item in vwEntradaalmacendetverificacioncantidadList)
                {
                    msgValidacion = msgValidacion + "-" + item.Nombrearticulo + " " + item.Nombremarca + " " + item.Abrunidadmedida + " " + item.Cantidad.ToString("n4") + " \\ " + item.Cantidadubicacion.ToString("n4");
                }
            }
            return msgValidacion.Trim();
        }
    }
}