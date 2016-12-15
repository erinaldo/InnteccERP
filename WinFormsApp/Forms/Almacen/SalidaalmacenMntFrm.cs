using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
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
    public partial class SalidaalmacenMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public DataEntityState DataEntityState { get; set; }
        public GridControl GridParent { get; set; }
        public SalidaalmacenFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Salidaalmacen SalidaalmacenMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSalidaalmacendet> VwSalidaalmacendetList { get; set; }
        public List<VwSalidaalmacenubicacion> VwSalidaalmacenubicacionList { get; set; }
        private List<Tipocppago> TipocppagoList { get; set; }
        private List<Almacen> AlmacenList { get; set; }
        private List<Tipodocmov> TipodocmovList { get; set; }
        private VwSocionegocio VwSocionegocioSel { get; set; }
        private ImpresionFormato ImpresionFormato { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public SalidaalmacenMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, SalidaalmacenFrm formParent)
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
        private void SalidaalmacenMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFechasalida.EditValue = DateTime.Now;
            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

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


            iIdtipodocmov.EditValue = 13; //Guia de remision

            int? idAlmacenDefecto = SessionApp.SucursalSel.Idalmacendefecto;
            if (idAlmacenDefecto > 0)
            {
                iIdalmacen.EditValue = idAlmacenDefecto;
            }

            iIdtipolista.EditValue = SessionApp.SucursalSel.Idtipolistadefecto;
            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "SALIDA-ALM";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

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
                    SalidaalmacenMnt = new Salidaalmacen();
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
                    break;
            }
        }
        private void CargarReferencias()
        {

            VwSucursalList = Service.GetAllVwSucursal();
            iIdsucursal.Properties.DataSource = VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "SALIDA-ALM", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "SALIDA-ALM", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;


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

            //string whereAlmacen = string.Format("idsucursal = {0}", UsuarioAutenticado.SucursalSel.Idsucursal);
            AlmacenList = CacheObjects.AlmacenList.Where(x => x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();// Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereCpIng = string.Format("regventas = '{0}'", "1");
            TipocppagoList = CacheObjects.TipocppagoList.Where(x => x.Regventas).ToList();

            iIddocumentosalida.Properties.DataSource = TipocppagoList;
            iIddocumentosalida.Properties.DisplayMember = "Nombretipocppago";
            iIddocumentosalida.Properties.ValueMember = "Idtipocppago";
            iIddocumentosalida.Properties.BestFitMode = BestFitMode.BestFit;

            iIddocproveedor.Properties.DataSource = TipocppagoList;
            iIddocproveedor.Properties.DisplayMember = "Nombretipocppago";
            iIddocproveedor.Properties.ValueMember = "Idtipocppago";
            iIddocproveedor.Properties.BestFitMode = BestFitMode.BestFit;


            iIdestadoreclamo.Properties.DataSource = Service.GetAllEstadoreclamo("nombreestadoreclamo");
            iIdestadoreclamo.Properties.DisplayMember = "Nombreestadoreclamo";
            iIdestadoreclamo.Properties.ValueMember = "Idestadoreclamo";
            iIdestadoreclamo.Properties.BestFitMode = BestFitMode.BestFit;

            //idtipodocmov = 13 : GUIAREMISION
            //idtipodocmov = 28 : CAJACHICA
            //idtipodocmov = 1 : CPVENTA
            string whereTipoImp = "idtipodocmov in(1,13,28)";
            TipodocmovList = Service.GetAllTipodocmov(whereTipoImp, "nombretipodocmov");
            iIdtipodocmov.Properties.DataSource = TipodocmovList;
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

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
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        break;
                    case "SALIDA-ALM":
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        VwGuiaremision vwGuiaremision = Service.GetVwGuiaremision(x => x.Idguiaremision == SalidaalmacenMnt.Idguiaremision);
                        if (vwGuiaremision != null)
                        {
                            rDocReferencia.EditValue = vwGuiaremision.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwGuiaremision.Serieguiaremision, vwGuiaremision.Numeroguiaremision);
                            rFechaDocRef.EditValue = vwGuiaremision.Fechaguiaremision.ToString();
                        }
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
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                    case "CAJA-CHICA":
                        VwRendicioncajachica vwRendicioncajachica = Service.GetVwRendicioncajachica(x => x.Idrendicioncajachica == SalidaalmacenMnt.Idrendicioncajachica);
                        if (vwRendicioncajachica != null)
                        {
                            rDocReferencia.EditValue = vwRendicioncajachica.Nombretipoformato;
                            rNumeroRef.EditValue = string.Format("{0}-{1}", vwRendicioncajachica.Serierendicioncaja, vwRendicioncajachica.Numerorendicioncaja);
                            rFechaDocRef.EditValue = vwRendicioncajachica.Fecharendicioncaja.ToString();
                        }
                        break;
                }

            }
        }
        private void TraerDatos()
        {
            try
            {
                SalidaalmacenMnt = Service.GetSalidaalmacen(IdEntidadMnt);

                iIdsucursal.EditValue = SalidaalmacenMnt.Idsucursal;
                iIdalmacen.EditValue = SalidaalmacenMnt.Idalmacen;
                iIdtipocp.EditValue = SalidaalmacenMnt.Idtipocp;
                iIdcptooperacion.EditValue = SalidaalmacenMnt.Idcptooperacion;
                rSeriesalidaalmacen.EditValue = SalidaalmacenMnt.Seriesalidaalmacen;
                rNumerosalidaalmacen.EditValue = SalidaalmacenMnt.Numerosalidaalmacen;
                iIdempleado.EditValue = SalidaalmacenMnt.Idempleado;
                iIdsocionegocio.EditValue = SalidaalmacenMnt.Idsocionegocio;
                iFechasalida.EditValue = SalidaalmacenMnt.Fechasalida;
                iAnulado.EditValue = SalidaalmacenMnt.Anulado;
                iFechaanulado.EditValue = SalidaalmacenMnt.Fechaanulado;
                iTipocambio.EditValue = SalidaalmacenMnt.Tipocambio;
                iIdtipomoneda.EditValue = SalidaalmacenMnt.Idtipomoneda;
                iIdimpuesto.EditValue = SalidaalmacenMnt.Idimpuesto;
                iGlosa.EditValue = SalidaalmacenMnt.Glosa;
                iIddocumentosalida.EditValue = SalidaalmacenMnt.Iddocumentosalida;
                iSerieguiaremision.EditValue = SalidaalmacenMnt.Serieguiaremision;
                iNumeroguiaremision.EditValue = SalidaalmacenMnt.Numeroguiaremision;
                iIddocproveedor.EditValue = SalidaalmacenMnt.Iddocproveedor;
                iSeriedocproveedor.EditValue = SalidaalmacenMnt.Seriedocproveedor;
                iNumerodocproveedor.EditValue = SalidaalmacenMnt.Numerodocproveedor;
                iIdestadoreclamo.EditValue = SalidaalmacenMnt.Idestadoreclamo;

                rTotalbruto.EditValue = SalidaalmacenMnt.Totalbruto;
                rTotalgravado.EditValue = SalidaalmacenMnt.Totalgravado;
                rTotalinafecto.EditValue = SalidaalmacenMnt.Totalinafecto;
                rTotalexonerado.EditValue = SalidaalmacenMnt.Totalexonerado;
                rImportetotal.EditValue = SalidaalmacenMnt.Importetotal;
                rPorcentajepercepcion.EditValue = SalidaalmacenMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = SalidaalmacenMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = SalidaalmacenMnt.Totaldocumento;
                rTotalimpuesto.EditValue = SalidaalmacenMnt.Totalimpuesto;
                iIdtipodocmov.EditValue = SalidaalmacenMnt.Idtipodocmov;
                iIncluyeimpuestoitems.EditValue = SalidaalmacenMnt.Incluyeimpuestoitems;

                iHoratransaccion.EditValue = SalidaalmacenMnt.Horatransaccion;
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
            //Detalle de salida
            string where = string.Format("idSalidaalmacen = '{0}'", IdEntidadMnt);
            gvDetalle.BeginDataUpdate();
            VwSalidaalmacendetList = Service.GetAllVwSalidaalmacendet(where, "numeroitem");
            gcDetalle.DataSource = VwSalidaalmacendetList;
            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);

            //Detalle de utilizacion
            gvDetalleUso.BeginDataUpdate();
            gcDetalleUso.DataSource = VwSalidaalmacendetList;
            gvDetalleUso.EndDataUpdate();
            //gvDetalleUso.BestFitColumns(true);

        }
        public bool Guardar()
        {

            if (!Validaciones()) return false;

            SalidaalmacenMnt.Idsucursal = (int?)iIdsucursal.EditValue;
            SalidaalmacenMnt.Idalmacen = (int?)iIdalmacen.EditValue;
            SalidaalmacenMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            SalidaalmacenMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            SalidaalmacenMnt.Seriesalidaalmacen = rSeriesalidaalmacen.Text.Trim();
            SalidaalmacenMnt.Numerosalidaalmacen = rNumerosalidaalmacen.Text.Trim();
            SalidaalmacenMnt.Idempleado = (int?)iIdempleado.EditValue;
            SalidaalmacenMnt.Idsocionegocio = (int?)iIdsocionegocio.EditValue;
            SalidaalmacenMnt.Fechasalida = (DateTime)iFechasalida.EditValue;
            SalidaalmacenMnt.Anulado = (bool)iAnulado.EditValue;
            SalidaalmacenMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            SalidaalmacenMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            SalidaalmacenMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;
            SalidaalmacenMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;
            SalidaalmacenMnt.Glosa = iGlosa.Text.Trim();
            SalidaalmacenMnt.Iddocumentosalida = (int?)iIddocumentosalida.EditValue;
            SalidaalmacenMnt.Serieguiaremision = iSerieguiaremision.Text.Trim();
            SalidaalmacenMnt.Numeroguiaremision = iNumeroguiaremision.Text.Trim();
            SalidaalmacenMnt.Iddocproveedor = (int?)iIddocproveedor.EditValue;
            SalidaalmacenMnt.Seriedocproveedor = (string)iSeriedocproveedor.EditValue;
            SalidaalmacenMnt.Numerodocproveedor = (string)iNumerodocproveedor.EditValue;
            SalidaalmacenMnt.Idestadoreclamo = (int?)iIdestadoreclamo.EditValue;
            SalidaalmacenMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            SalidaalmacenMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            SalidaalmacenMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            SalidaalmacenMnt.Totalexonerado = (decimal)rTotalexonerado.EditValue;
            SalidaalmacenMnt.Importetotal = (decimal)rImportetotal.EditValue;
            SalidaalmacenMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            SalidaalmacenMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            SalidaalmacenMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            SalidaalmacenMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            SalidaalmacenMnt.Idtipodocmov = (int)iIdtipodocmov.EditValue;
            SalidaalmacenMnt.Incluyeimpuestoitems = iIncluyeimpuestoitems.Checked;

            SalidaalmacenMnt.Horatransaccion = (DateTime)iHoratransaccion.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    SalidaalmacenMnt.Createdby = IdUsuario;
                    SalidaalmacenMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    SalidaalmacenMnt.Modifiedby = IdUsuario;
                    SalidaalmacenMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        IdEntidadMnt = Service.SaveSalidaalmacen(SalidaalmacenMnt);
                        SalidaalmacenMnt.Idsalidaalmacen = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        DataEntityState = DataEntityState.Added;

                        if (IdEntidadMnt > 0
                            && TipoCpMnt.Numeracionauto
                            && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerosalidaalmacen.EditValue)))
                        {
                            iIdtipocp.ReadOnly = true;
                            iIdcptooperacion.ReadOnly = true;
                        }



                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateSalidaalmacen(SalidaalmacenMnt);
                        DataEntityState = DataEntityState.Modified;
                        if (iAnulado.Checked)
                        {
                            AnularSalidaDeAlmacen();
                        }
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriesalidaalmacen.Text.Trim(), rNumerosalidaalmacen.Text.Trim());
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                Cursor = Cursors.Default;
                XtraMessageBox.Show("Se guardo correctamente el documento " + numeroDoc, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CamposSoloLectura(true);
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
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "SALIDA-ALM";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        public bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpSalidaAlmacen, _errorProvider))
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


            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            decimal tipoCambio = (decimal)iTipocambio.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            {
                XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iTipocambio.Select();
                return false;
            }

            int idSucursal = (int)iIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSeriesalidaalmacen.Text.Trim();
            string numeroDocumento = rNumerosalidaalmacen.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroSalidaAlmacenExiste(idSucursal, idTipoCp, numeroSerie, numeroDocumento))
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
                        Service.DeleteSalidaalmacen(IdEntidadMnt);
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

                    SalidaalmacenMnt = null;
                    SalidaalmacenMnt = new Salidaalmacen();

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
                    //SalidaalmacenMnt = null;
                    DialogResult = DialogResult.OK;
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoValeSalida(SalidaalmacenMnt);
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
        private void SalidaalmacenMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpSalidaAlmacen, readOnly);
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
            SalidaalmacenMntItemFrm salidaalmacenMntItemFrm;
            VwSalidaalmacendet vwSalidaalmacendetMnt = new VwSalidaalmacendet();
            Salidaalmacendet salidaalmacendetMnt;
            const string nombreIdDetalle = "Idsalidaalmacendet";
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
                    vwSalidaalmacendetMnt.Numeroitem = VwSalidaalmacendetList.Count + 1;

                    salidaalmacenMntItemFrm = new SalidaalmacenMntItemFrm(tipoMantenimientoItem, vwSalidaalmacendetMnt);
                    salidaalmacenMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    salidaalmacenMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    salidaalmacenMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;

                    salidaalmacenMntItemFrm.ShowDialog();

                    if (salidaalmacenMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        salidaalmacendetMnt = AsignarSalidaAlmacenDetalle(vwSalidaalmacendetMnt);

                        int idsalidaalmacendet = Service.SaveSalidaalmacendet(salidaalmacendetMnt);
                        if (idsalidaalmacendet > 0)
                        {
                            vwSalidaalmacendetMnt.Idsalidaalmacendet = idsalidaalmacendet;
                            VwSalidaalmacendetList.Add(vwSalidaalmacendetMnt);


                            //Agregar los detalles de componente
                            if (salidaalmacenMntItemFrm.VwSalidaalmacendetComponenteList != null && salidaalmacenMntItemFrm.VwSalidaalmacendetComponenteList.Count > 0)
                            {
                                foreach (VwSalidaalmacendet itemComponente in salidaalmacenMntItemFrm.VwSalidaalmacendetComponenteList)
                                {
                                    Salidaalmacendet salidaalmacendetComponente = AsignarSalidaAlmacenDetalle(itemComponente);
                                    int idsalidaalmacendetComponente = Service.SaveSalidaalmacendet(salidaalmacendetComponente);
                                    if (idsalidaalmacendetComponente > 0)
                                    {
                                        itemComponente.Idsalidaalmacendet = idsalidaalmacendetComponente;
                                        VwSalidaalmacendetList.Add(itemComponente);
                                    }
                                }
                            }
                            //

                            SumarTotales(true);
                            //Enfocar el id generado
                            if (idsalidaalmacendet > 0)
                            {
                                gvDetalle.BeginUpdate();
                                var rowHandle = gvDetalle.LocateByValue(nombreIdDetalle, idsalidaalmacendet);
                                if (rowHandle == GridControl.InvalidRowHandle)
                                {
                                    gvDetalle.EndUpdate();
                                    return;
                                }
                                gvDetalle.EndUpdate();
                                gvDetalle.FocusedRowHandle = rowHandle;
                            }

                            gvDetalle.RefreshData();
                            gvDetalleUso.RefreshData();
                            gvDetalle.BestFitColumns(true);

                        }



                        //Insertar la ubicaciones del articulo del almacen seleccionado
                        List<VwArticuloubicacion> vwArticuloubicacionList = Service.GetAllVwArticuloubicacion(
                            x => x.Idarticulo == vwSalidaalmacendetMnt.Idarticulo
                            && x.Idalmacen == (int)iIdalmacen.EditValue);

                        foreach (var vwArticuloubicacion in vwArticuloubicacionList)
                        {
                            Salidaalmacenubicacion salidaalmacenubicacion = new Salidaalmacenubicacion
                            {
                                Idsalidaalmacendet = idsalidaalmacendet,
                                Idubicacion = vwArticuloubicacion.Idubicacion,
                                Cantidadarticulo = 0m
                            };
                            Service.SaveSalidaalmacenubicacion(salidaalmacenubicacion);
                        }
                        CargarDetalleUbicaciones();

                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwSalidaalmacendetMnt = (VwSalidaalmacendet)gvDetalle.GetFocusedRow();
                    if (vwSalidaalmacendetMnt == null)
                    {
                        break;
                    }

                    salidaalmacenMntItemFrm = new SalidaalmacenMntItemFrm(tipoMantenimientoItem, vwSalidaalmacendetMnt);
                    salidaalmacenMntItemFrm.ShowDialog();

                    if (salidaalmacenMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        salidaalmacendetMnt = AsignarSalidaAlmacenDetalle(vwSalidaalmacendetMnt);
                        Service.UpdateSalidaalmacendet(salidaalmacendetMnt);
                        gvDetalle.RefreshData();
                        gvDetalleUso.RefreshData();
                        SumarTotales(true);
                    }

                    break;

                case "btnDelItem":
                    int idSalidaalmacendetSel = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));
                    if (idSalidaalmacendetSel > 0)
                    {
                        int cantidadRefUbicaciones = VwSalidaalmacenubicacionList.Count(x => x.Idsalidaalmacendet == idSalidaalmacendetSel);
                        if (cantidadRefUbicaciones > 0)
                        {
                            XtraMessageBox.Show("No puede eliminar tiene referencia de ubicaciones.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwSalidaalmacendet vwSalidaalmacendet = (VwSalidaalmacendet)gvDetalle.GetFocusedRow();
                            if (VwSalidaalmacendetList.Remove(vwSalidaalmacendet))
                            {
                                Service.DeleteSalidaalmacendet(idSalidaalmacendetSel);
                                gvDetalle.RefreshData();
                                gvDetalleUso.RefreshData();
                                if (!gvDetalle.IsFirstRow)
                                {
                                    gvDetalle.MovePrev();
                                }

                                if (gvDetalle.RowCount == 0)
                                {
                                    AnularSalidaDeAlmacen();

                                    SalidaalmacenMnt.Idguiaremision = null;
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
        private Salidaalmacenubicacion AsignarSalidaAlmacenUbicacion(VwSalidaalmacenubicacion vwSalidaalmacenubicacionMnt)
        {
            Salidaalmacenubicacion salidaalmacenubicacion = new Salidaalmacenubicacion();
            salidaalmacenubicacion.Idsalidaalmacenubicacion = vwSalidaalmacenubicacionMnt.Idsalidaalmacenubicacion;
            salidaalmacenubicacion.Idsalidaalmacendet = vwSalidaalmacenubicacionMnt.Idsalidaalmacendet;
            salidaalmacenubicacion.Idubicacion = vwSalidaalmacenubicacionMnt.Idubicacion;
            salidaalmacenubicacion.Cantidadarticulo = vwSalidaalmacenubicacionMnt.Cantidadarticulo;
            return salidaalmacenubicacion;
        }
        private Salidaalmacendet AsignarSalidaAlmacenDetalle(VwSalidaalmacendet vwSalidaalmacendetMntItem)
        {
            Salidaalmacendet salidaalmacendetMnt = new Salidaalmacendet
            {
                Idsalidaalmacendet = vwSalidaalmacendetMntItem.Idsalidaalmacendet,
                Idsalidaalmacen = IdEntidadMnt,
                Numeroitem = vwSalidaalmacendetMntItem.Numeroitem,
                Idarticulo = vwSalidaalmacendetMntItem.Idarticulo,
                Idimpuesto = vwSalidaalmacendetMntItem.Idimpuesto,
                Idunidadmedida = vwSalidaalmacendetMntItem.Idunidadmedida,
                Especificacion = vwSalidaalmacendetMntItem.Especificacion,
                Cantidad = vwSalidaalmacendetMntItem.Cantidad,
                Preciounitario = vwSalidaalmacendetMntItem.Preciounitario,
                Importetotal = vwSalidaalmacendetMntItem.Importetotal,
                Idproyecto = vwSalidaalmacendetMntItem.Idproyecto,
                Idarea = vwSalidaalmacendetMntItem.Idarea,
                Idcentrodecosto = vwSalidaalmacendetMntItem.Idcentrodecosto,
                Porcentajepercepcion = vwSalidaalmacendetMntItem.Porcentajepercepcion,
                Idtipoafectacionigv = vwSalidaalmacendetMntItem.Idtipoafectacionigv,
                Cantidadutilizada = vwSalidaalmacendetMntItem.Cantidadutilizada,
                Idguiaremisiondet = vwSalidaalmacendetMntItem.Idguiaremisiondet,
                Calcularitem = vwSalidaalmacendetMntItem.Calcularitem,
                Idcpventadet = vwSalidaalmacendetMntItem.Idcpventadet
                
            };
            return salidaalmacendetMnt;
        }
        private void SumarTotales(bool actualizar)
        {

            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            decimal totalbruto = VwSalidaalmacendetList.Where(w => w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwSalidaalmacendetList.Where(w => w.Gravado && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwSalidaalmacendetList.Where(w => w.Inafecto).Sum(s => s.Importetotal);
            decimal totalexonerado = VwSalidaalmacendetList.Where(w => w.Exonerado && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwSalidaalmacendetList.Where(
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
                Salidaalmacen salidaalmacen = new Salidaalmacen();
                salidaalmacen.Idsalidaalmacen = IdEntidadMnt;
                salidaalmacen.Totalbruto = (decimal)rTotalbruto.EditValue;
                salidaalmacen.Totalgravado = (decimal)rTotalgravado.EditValue;
                salidaalmacen.Totalinafecto = (decimal)rTotalinafecto.EditValue;
                salidaalmacen.Totalexonerado = (decimal)rTotalexonerado.EditValue;
                salidaalmacen.Importetotal = (decimal)rImportetotal.EditValue;
                salidaalmacen.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
                salidaalmacen.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
                salidaalmacen.Totaldocumento = (decimal)rTotaldocumento.EditValue;
                salidaalmacen.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
                Service.ActualizarTotalesSalidaAlmacen(salidaalmacen);
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);

            //Si tiene registro el detalle deshabilitar
            iIdalmacen.ReadOnly = gvDetalle.RowCount > 0;

        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        public void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                TipoCpMnt = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriesalidaalmacen.EditValue = vwTipocp.Seriecp;
                        rNumerosalidaalmacen.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerosalidaalmacen.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerosalidaalmacen.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerosalidaalmacen.EditValue = vwTipocp.Seriecp;
                        rNumerosalidaalmacen.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerosalidaalmacen.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriesalidaalmacen.EditValue = @"0000";
                rNumerosalidaalmacen.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void iIdsocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioMnt = iIdsocionegocio.EditValue;
            if (idSocioNegocioMnt == null || (int)idSocioNegocioMnt <= 0) return;

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int)idSocioNegocioMnt);
            if (vwSocionegocioSel != null)
            {
                VwSocionegocioSel = vwSocionegocioSel;
                beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                iIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
            }
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
        private void gvDetSalidaalmacen_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleUbicaciones();
        }
        private void CargarDetalleUbicaciones()
        {
            VwSalidaalmacendet salidaalmacendet = (VwSalidaalmacendet)gvDetalle.GetFocusedRow();
            if (salidaalmacendet != null)
            {
                string condicion = string.Format("idsalidaalmacendet ={0}", salidaalmacendet.Idsalidaalmacendet);
                const string orden = "idsalidaalmacenubicacion";
                VwSalidaalmacenubicacionList = Service.GetAllVwSalidaalmacenubicacion(condicion, orden);
                gcUbicacionDet.DataSource = VwSalidaalmacenubicacionList;
                //gvUbicacionDet.BestFitColumns(true);
            }
        }
        private void bmUbicaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            SalidaalmacenubicacionMntItemFrm salidaalmacenubicacionMntItemFrm;
            const string nombreidsalidaalmacenubicacion = "Idsalidaalmacenubicacion";
            VwSalidaalmacendet vwSalidaalmacendetRef = (VwSalidaalmacendet)gvDetalle.GetFocusedRow();
            VwSalidaalmacenubicacion vwSalidaalmacenubicacionMnt;
            if (vwSalidaalmacendetRef == null)
            {
                return;
            }


            switch (e.Item.Name)
            {
                case "cmdAddUbicacion":
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwSalidaalmacenubicacionMnt = new VwSalidaalmacenubicacion();
                    salidaalmacenubicacionMntItemFrm = new SalidaalmacenubicacionMntItemFrm(tipoMantenimientoItem, vwSalidaalmacendetRef, vwSalidaalmacenubicacionMnt);
                    salidaalmacenubicacionMntItemFrm.FechaSalida = (DateTime) iFechasalida.EditValue;

                    salidaalmacenubicacionMntItemFrm.IdAlmacenSel = (int)iIdalmacen.EditValue;
                    salidaalmacenubicacionMntItemFrm.ShowDialog();

                    if (salidaalmacenubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Salidaalmacenubicacion salidaalmacenubicacion = AsignarSalidaAlmacenUbicacion(vwSalidaalmacenubicacionMnt);

                        int idsalidaalmacenubicacion = Service.SaveSalidaalmacenubicacion(salidaalmacenubicacion);
                        if (idsalidaalmacenubicacion > 0)
                        {
                            vwSalidaalmacenubicacionMnt.Idsalidaalmacenubicacion = idsalidaalmacenubicacion;
                        }

                        VwSalidaalmacenubicacionList.Add(vwSalidaalmacenubicacionMnt);
                        gvUbicacionDet.RefreshData();

                        //Enfocar el id generado
                        if (idsalidaalmacenubicacion > 0)
                        {
                            gvUbicacionDet.BeginUpdate();
                            var rowHandle = gvUbicacionDet.LocateByValue(nombreidsalidaalmacenubicacion, idsalidaalmacenubicacion);
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
                    vwSalidaalmacenubicacionMnt = (VwSalidaalmacenubicacion)gvUbicacionDet.GetFocusedRow();
                    salidaalmacenubicacionMntItemFrm = new SalidaalmacenubicacionMntItemFrm(tipoMantenimientoItem, vwSalidaalmacendetRef, vwSalidaalmacenubicacionMnt);
                    salidaalmacenubicacionMntItemFrm.FechaSalida = (DateTime)iFechasalida.EditValue;
                    salidaalmacenubicacionMntItemFrm.IdAlmacenSel = (int)iIdalmacen.EditValue;
                    salidaalmacenubicacionMntItemFrm.ShowDialog();
                    if (salidaalmacenubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Salidaalmacenubicacion salidaalmacenubicacion = AsignarSalidaAlmacenUbicacion(vwSalidaalmacenubicacionMnt);

                        Service.UpdateSalidaalmacenubicacion(salidaalmacenubicacion);
                        gvUbicacionDet.RefreshData();
                    }
                    break;
                case "cmdDelUbicacion":
                    int idsalidaalmacenubicacionSel = Convert.ToInt32(gvUbicacionDet.GetRowCellValue(gvUbicacionDet.FocusedRowHandle, nombreidsalidaalmacenubicacion));
                    if (idsalidaalmacenubicacionSel > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwSalidaalmacenubicacion vwSalidaalmacenubicacionSel = (VwSalidaalmacenubicacion)gvUbicacionDet.GetFocusedRow();
                            if (VwSalidaalmacenubicacionList.Remove(vwSalidaalmacenubicacionSel))
                            {
                                Service.DeleteSalidaalmacenubicacion(idsalidaalmacenubicacionSel);
                                gvUbicacionDet.RefreshData();
                            }

                        }
                    }
                    break;
            }
        }
        private void cmdImportar_Click(object sender, EventArgs e)
        {
            if (!Validaciones()) return;
            Almacen almacenSel = AlmacenList.FirstOrDefault(x => x.Idalmacen == (int)iIdalmacen.EditValue);
            Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);


            if (DialogResult.No == XtraMessageBox.Show(string.Format("¿El almacén de salida es {0}?", iIdalmacen.Text.Trim()),
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
                        SalidaalmacenImpCpVentaFrm salidaalmacenImpCpVentaFrm = new SalidaalmacenImpCpVentaFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        salidaalmacenImpCpVentaFrm.ShowDialog();
                        break;
                    case "CPCOMPRA":
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        break;
                    case "SALIDA-ALM":
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        SalidaalmacenImpGuiaRemisionFrm salidaalmacenImpGuiaRemisionFrm = new SalidaalmacenImpGuiaRemisionFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        salidaalmacenImpGuiaRemisionFrm.ShowDialog();
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
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                    case "CAJA-CHICA":
                        SalidaalmacenImpCajaChicaFrm salidaalmacenImpCajaChicaFrm = new SalidaalmacenImpCajaChicaFrm(tipodocmovSel, VwSocionegocioSel, almacenSel, this);
                        salidaalmacenImpCajaChicaFrm.ShowDialog();
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


            //BarMntItems.BeginUpdate();
            //foreach (BarItem item in bmItems.Items)
            //{
            //    item.Enabled = enabled;
            //}
            //BarMntItems.EndUpdate();

        }
        private void AnularSalidaDeAlmacen()
        {
            Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);
            Salidaalmacen salidaalmacen = Service.GetSalidaalmacen(x => x.Idsalidaalmacen == IdEntidadMnt);

            if (tipodocmovSel != null && salidaalmacen != null && salidaalmacen.Anulado)
            {
                string sqlCommandAnular;
                switch (tipodocmovSel.Nombretipodocmov)
                {
                    case "CPVENTA":
                         sqlCommandAnular = string.Format(@"UPDATE almacen.salidaalmacen set idcpventa = null where idsalidaalmacen = {0};
                                            UPDATE almacen.salidaalmacendet set idcpventadet = null where idsalidaalmacen = {0}", IdEntidadMnt);
                        Service.AnularSalidaDeAlmacen(sqlCommandAnular);
                        break;
                    case "CPCOMPRA":
                        break;
                    case "REQUERIMIENTO":
                        break;
                    case "ORDENCOMPRA":
                        break;
                    case "SALIDA-ALM":
                        break;
                    case "ENTRADA-ALM":
                        break;
                    case "GUIAREMISION":
                        sqlCommandAnular = string.Format(@"UPDATE almacen.salidaalmacen set idguiaremision = null where idsalidaalmacen = {0};
                                            UPDATE almacen.salidaalmacendet set idguiaremisiondet = null where idsalidaalmacen = {0}", IdEntidadMnt);
                        Service.AnularSalidaDeAlmacen(sqlCommandAnular);
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
                        break;
                    case "ND-CLIENTE":
                        break;
                    case "INVENTARIO":
                        break;
                    case "COTIZA-PROVEEDOR":
                        break;
                    case "CUADROCC":
                        break;
                    case "CAJA-CHICA":
                        sqlCommandAnular = string.Format(@"UPDATE almacen.salidaalmacen set idrendicioncajachica = null where idsalidaalmacen = {0};
                                           UPDATE almacen.salidaalmacendet set idrendicioncajachicadet = null, idcpcompradetrendicioncajachicadet = null where idsalidaalmacen = {0}", IdEntidadMnt);
                        Service.AnularSalidaDeAlmacen(sqlCommandAnular);
                        break;

                }
            }
        }
        private void gvDetalleUso_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwSalidaalmacendet item = (VwSalidaalmacendet)gvDetalle.GetFocusedRow();
            TipoMantenimiento tipoMnt = item.Idsalidaalmacendet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
                case "Cantidadutilizada":
                    Salidaalmacendet salidaalmacendet = AsignarSalidaAlmacenDetalle(item);
                    if (salidaalmacendet.Idsalidaalmacendet > 0)
                    {
                        decimal cantidadAdevolver = item.Cantidad - item.Cantidadutilizada;
                        if (cantidadAdevolver >= 0)
                        {
                            item.Cantidadadevolver = cantidadAdevolver;
                            Service.UpdateSalidaalmacendet(salidaalmacendet);
                            gvDetalleUso.RefreshRow(gvDetalleUso.FocusedRowHandle);

                        }
                        else
                        {
                            XtraMessageBox.Show("Cantidad utilizada invalida, verifique", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //item.Cantidadutilizada = cantidadUtilizadaInicial;
                            //item.Cantidadadevolver = item.Cantidad - item.Cantidadutilizada;
                            item.Cantidadutilizada = 0m;
                            item.Cantidadadevolver = 0m;
                            gvDetalleUso.RefreshRow(gvDetalleUso.FocusedRowHandle);
                        }
                    }
                    break;
            }
        }
        private void ri2Numerico4_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se termina de digitar
            //gvDetalleUso.PostEditor();
            //Deshabilitado
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwSalidaalmacendetList != null)
            {
                SumarTotales(false);
            }
        }
        private void SalidaalmacenMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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

            List<VwSalidaalmacendetverificacioncantidad> vwSalidaalmacendetverificacioncantidadList =
            Service.GetAllVwSalidaalmacendetverificacioncantidad(x => x.Cantidad != x.Cantidadubicacion && x.Idsalidaalmacen == IdEntidadMnt);
            if (vwSalidaalmacendetverificacioncantidadList != null &&
                vwSalidaalmacendetverificacioncantidadList.Count > 0)
            {
                foreach (var item in vwSalidaalmacendetverificacioncantidadList)
                {
                    msgValidacion = msgValidacion + "-" + item.Nombrearticulo + " " + item.Nombremarca + " " + item.Abrunidadmedida + " " + item.Cantidad.ToString("n4") + " \\ " + item.Cantidadubicacion.ToString("n4");
                }
            }
            return msgValidacion.Trim();
        }
    }

    public static class ParametrosAlmacen
    {
        public static int Idalmacen { get; set; }
    }
}