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
    public partial class CotizacionclienteMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CotizacionclienteFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cotizacioncliente CotizacionclienteMnt { get; set; }
        public VwCotizacioncliente VwCotizacionclienteMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwCotizacionclientedet> VwCotizacionclientedetList { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public List<Socionegociodireccion> SocionegociodireccionList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public List<VwEmpleadoarea> VwEmpleadoareaList { get; private set; }
        private List<VwSocionegocioproyecto> VwProyectoList { get; set; }
        public List<VwSocionegocioproyecto> SocionegocioproyectoList { get; set; }
        public List<Socionegociocontacto> SocionegociocontactoList { get; set; }
        public CotizacionVentaItem OrdenVentaItemParameter { get; set; }
        public VwSucursal VwSucursalSel { get; set; }
        public UserAudit UserAudit { get; set; }

        public CotizacionclienteMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CotizacionclienteFrm formParent)
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

            UserAudit = new UserAudit();
        }
        private void CotizacionclienteMntFrm_Load(object sender, EventArgs e)
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
            Cursor = Cursors.WaitCursor;

            iFechacotizacion.EditValue = SessionApp.DateServer;

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


            rNumeronegociacion.EditValue = 1;

            iFechacotizacion.EditValue = SessionApp.DateServer;
            iFechavencimiento.EditValue = SessionApp.DateServer;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "COTIZA-CLIENTE";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

            //Asignar el area del empleado logeado
            if (SessionApp.EmpleadoSel != null)
            {
                int idAreaEmpleadoLogeado = SessionApp.EmpleadoSel.Idarea;
                var areaEmpleadoPorDefecto =
                    Service.GetVwEmpleadoarea(
                        x => x.Idempleado == SessionApp.EmpleadoSel.Idempleado &&
                            x.Idarea == idAreaEmpleadoLogeado);
                if (areaEmpleadoPorDefecto != null)
                {
                    iIdarea.EditValue = areaEmpleadoPorDefecto.Idarea;
                }

            }

            iIdtipocp.Select();
            Cursor = Cursors.Default;


            VwSocionegocio vwSocionegocioEventual = Service.GetVwSocionegocio(x => x.Razonsocial.Contains("EVENTUAL"));
            if (vwSocionegocioEventual != null)
            {
                CargarDatosSocioNegocio(vwSocionegocioEventual);
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
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    CotizacionclienteMnt = new Cotizacioncliente();
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoReferenciaOrdenVenta();
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();



                    break;
            }
        }
        private void EstadoReferenciaOrdenVenta()
        {
            if (Service.CotizacionClienteTieneReferenciaOrdenVenta(IdEntidadMnt))
            {
                XtraMessageBox.Show("La Cotizacion ya tiene Orden de Venta", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {
            Cursor = Cursors.WaitCursor;

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "COTIZA-CLIENTE"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            VwTipocpList = VwTipocpList;
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            VwCptooperacionList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "COTIZA-CLIENTE"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            VwCptooperacionList = VwCptooperacionList;

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

            iIdempleado.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            rIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            rIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            rIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwSucursalList = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal");
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            VwAreaList = CacheObjects.VwAreaList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList(); //Service.GetAllVwArea(whereArea, "Codigoarea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipolista.Properties.DataSource = CacheObjects.TipolistaList;
            rIdtipolista.Properties.DisplayMember = "Nombretipolista";
            rIdtipolista.Properties.ValueMember = "Idtipolista";
            rIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            Cursor = Cursors.Default;
        }
        private void TraerDatos()
        {
            try
            {

                Cursor = Cursors.WaitCursor;

                VwCotizacionclienteMnt = Service.GetVwCotizacioncliente(IdEntidadMnt);

                iIdtipocp.EditValue = VwCotizacionclienteMnt.Idtipocp;
                rSeriecotizacion.EditValue = VwCotizacionclienteMnt.Seriecotizacion;
                rNumerocotizacion.EditValue = VwCotizacionclienteMnt.Numerocotizacion;
                rNumeronegociacion.EditValue = VwCotizacionclienteMnt.Numeronegociacion;
                iFechacotizacion.EditValue = VwCotizacionclienteMnt.Fechacotizacion;
                iAnulado.EditValue = VwCotizacionclienteMnt.Anulado;
                iFechaanulado.EditValue = VwCotizacionclienteMnt.Fechaanulado;
                iIdempleado.EditValue = VwCotizacionclienteMnt.Idempleado;
                iIdcliente.EditValue = VwCotizacionclienteMnt.Idcliente;
                beSocioNegocio.Text = VwCotizacionclienteMnt.Razonsocial;

                CargarReferenciasCliente(VwCotizacionclienteMnt.Idcliente);

                iPersonacontacto.EditValue = VwCotizacionclienteMnt.Personacontacto;
                iPersonadestinario.EditValue = VwCotizacionclienteMnt.Personadestinario;
                iIddireccionentrega.EditValue = VwCotizacionclienteMnt.Iddireccionentrega;
                iIddireccionfacturacion.EditValue = VwCotizacionclienteMnt.Iddireccionfacturacion;
                rIdtipolista.EditValue = VwCotizacionclienteMnt.Idtipolista;
                iTipocambio.EditValue = VwCotizacionclienteMnt.Tipocambio;
                iIdtipomoneda.EditValue = VwCotizacionclienteMnt.Idtipomoneda;
                rIdtipocondicion.EditValue = VwCotizacionclienteMnt.Idtipocondicion;
                rTotalbruto.EditValue = VwCotizacionclienteMnt.Totalbruto;
                rTotalgravado.EditValue = VwCotizacionclienteMnt.Totalgravado;
                rTotalinafecto.EditValue = VwCotizacionclienteMnt.Totalinafecto;
                rtotalexonerado.EditValue = VwCotizacionclienteMnt.Totalexonerado;
                rTotalimpuesto.EditValue = VwCotizacionclienteMnt.Totalimpuesto;
                rImportetotal.EditValue = VwCotizacionclienteMnt.Importetotal;
                rPorcentajepercepcion.EditValue = VwCotizacionclienteMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = VwCotizacionclienteMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = VwCotizacionclienteMnt.Totaldocumento;
                iGlosacotizacion.EditValue = VwCotizacionclienteMnt.Glosacotizacion;
                iFechavencimiento.EditValue = VwCotizacionclienteMnt.Fechavencimiento;
                iAprobado.EditValue = VwCotizacionclienteMnt.Aprobado;
                iFechaapobacion.EditValue = VwCotizacionclienteMnt.Fechaaprobacion;
                iIdproyecto.EditValue = VwCotizacionclienteMnt.Idproyecto;
                iIdimpuesto.EditValue = VwCotizacionclienteMnt.Idimpuesto;
                rIdsucursal.EditValue = VwCotizacionclienteMnt.Idsucursal;
                rIncluyeimpuestoitems.EditValue = VwCotizacionclienteMnt.Incluyeimpuestoitems;
                iDocrefcliente.EditValue = VwCotizacionclienteMnt.Docrefcliente;
                iIdcptooperacion.EditValue = VwCotizacionclienteMnt.Idcptooperacion;
                iIdarea.EditValue = VwCotizacionclienteMnt.Idarea;
                iAlcanzecondicion.RtfText = VwCotizacionclienteMnt.Alcanzecondicion;

                UserAudit.Createdby = VwCotizacionclienteMnt.Createdby;
                UserAudit.Creationdate = VwCotizacionclienteMnt.Creationdate;
                UserAudit.Modifiedby = VwCotizacionclienteMnt.Modifiedby;
                UserAudit.Lastmodified = VwCotizacionclienteMnt.Lastmodified;

                Cursor = Cursors.Default;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                Cursor = Cursors.Default;
                throw;
            }
        }
        private void CargarDetalle()
        {
            Cursor = Cursors.WaitCursor;
            gcDetalle.BeginUpdate();
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idCotizacioncliente = '{0}'", IdEntidadMnt);

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwCotizacionclientedetList = new List<VwCotizacionclientedet>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwCotizacionclientedetList = Service.GetAllVwCotizacionclientedet(where, "numeroitem");
                    break;
            }

            gcDetalle.DataSource = VwCotizacionclientedetList;
            SumarTotales();
            gcDetalle.EndUpdate();
            Cursor = Cursors.Default;
        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            CotizacionclienteMnt = new Cotizacioncliente();
            CotizacionclienteMnt.Idcotizacioncliente = (int)pkIdEntidad.EditValue;
            CotizacionclienteMnt.Idtipocp = (int)iIdtipocp.EditValue;
            CotizacionclienteMnt.Seriecotizacion = rSeriecotizacion.Text.Trim();
            CotizacionclienteMnt.Numerocotizacion = rNumerocotizacion.Text.Trim();
            CotizacionclienteMnt.Numeronegociacion = (int)rNumeronegociacion.EditValue;
            CotizacionclienteMnt.Fechacotizacion = (DateTime)iFechacotizacion.EditValue;
            CotizacionclienteMnt.Anulado = (bool)iAnulado.EditValue;
            CotizacionclienteMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            CotizacionclienteMnt.Idempleado = (int)iIdempleado.EditValue;
            CotizacionclienteMnt.Idcliente = (int)iIdcliente.EditValue;
            CotizacionclienteMnt.Iddireccionfacturacion = (int)iIddireccionfacturacion.EditValue;
            CotizacionclienteMnt.Iddireccionentrega = (int)iIddireccionentrega.EditValue;

            CotizacionclienteMnt.Personacontacto = (int?)iPersonacontacto.EditValue;
            CotizacionclienteMnt.Personadestinario = iPersonadestinario.Text.Trim();
            CotizacionclienteMnt.Idtipolista = (int)rIdtipolista.EditValue;
            CotizacionclienteMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            CotizacionclienteMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            CotizacionclienteMnt.Idtipocondicion = (int)rIdtipocondicion.EditValue;

            CotizacionclienteMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            CotizacionclienteMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            CotizacionclienteMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            CotizacionclienteMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            CotizacionclienteMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            CotizacionclienteMnt.Importetotal = (decimal)rImportetotal.EditValue;
            CotizacionclienteMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            CotizacionclienteMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            CotizacionclienteMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            CotizacionclienteMnt.Glosacotizacion = iGlosacotizacion.Text.Trim();
            CotizacionclienteMnt.Fechavencimiento = (DateTime?)iFechavencimiento.EditValue;
            CotizacionclienteMnt.Aprobado = (bool)iAprobado.EditValue;
            CotizacionclienteMnt.Fechaaprobacion = (DateTime?)iFechaapobacion.EditValue;
            CotizacionclienteMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            CotizacionclienteMnt.Idsucursal = (int)rIdsucursal.EditValue;
            CotizacionclienteMnt.Incluyeimpuestoitems = (bool)rIncluyeimpuestoitems.EditValue;
            CotizacionclienteMnt.Docrefcliente = (string)iDocrefcliente.EditValue;
            CotizacionclienteMnt.Idproyecto = (int?)iIdproyecto.EditValue;
            CotizacionclienteMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            CotizacionclienteMnt.Idarea = (int)iIdarea.EditValue;
            CotizacionclienteMnt.Alcanzecondicion = iAlcanzecondicion.RtfText;



            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CotizacionclienteMnt.Createdby = IdUsuario;
                    CotizacionclienteMnt.Creationdate = DateTime.Now;
                    CotizacionclienteMnt.Modifiedby = UserAudit.Modifiedby;
                    CotizacionclienteMnt.Lastmodified = UserAudit.Lastmodified;

                    break;
                case TipoMantenimiento.Modificar:
                    CotizacionclienteMnt.Createdby = UserAudit.Createdby;
                    CotizacionclienteMnt.Creationdate = UserAudit.Creationdate;
                    CotizacionclienteMnt.Modifiedby = IdUsuario;
                    CotizacionclienteMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:

                        if (Service.GuardarCotizacionCliente(TipoMnt, CotizacionclienteMnt, VwCotizacionclientedetList))
                        {
                            IdEntidadMnt = CotizacionclienteMnt.Idcotizacioncliente;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.GuardarCotizacionCliente(TipoMnt, CotizacionclienteMnt, VwCotizacionclientedetList);
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriecotizacion.Text.Trim(), rNumerocotizacion.Text.Trim());
                Cursor = Cursors.Default;

                if (tcCotizaCliente.SelectedTabPage == tpLogistica)
                {
                    tcCotizaCliente.SelectedTabPage = tpCotizacioncliente;
                }

                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

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
            const string nombreTipodocMov = "COTIZA-CLIENTE";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;
            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCotizacioncliente, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCotizacioncliente;
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

            var itemsCantidadInvalida = VwCotizacionclientedetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwCotizacionclientedetList.Where(x => x.Preciounitario <= 0);
            string msgItemPreUni = itemsPrecioUniInvalido.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemPreUni))
            {
                XtraMessageBox.Show("Existe items con precio unitario cero verifique: \n\n" + msgItemPreUni, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSeriecotizacion.Text.Trim();
            string numeroDoc = rNumerocotizacion.Text.Trim();







            if (iAprobado.Checked)
            {
                //Validar aprobacion de cotizacion
                Cotizacioncliente cotizacioncliente =
                    Service.GetCotizacioncliente(x => x.Idsucursal == idSucursal
                            && x.Idtipocp == idTipoCp
                            && x.Seriecotizacion == numeroSerie
                            && x.Numerocotizacion == numeroDoc
                            && x.Aprobado
                            && !x.Anulado
                            && x.Idcotizacioncliente != IdEntidadMnt);

                if (cotizacioncliente != null)
                {
                    string numeroCotizacion = string.Format("N° {0}-{1}-Revisión({2})",
                        cotizacioncliente.Seriecotizacion.Trim(),
                        cotizacioncliente.Numerocotizacion.Trim(),
                        cotizacioncliente.Numeronegociacion);
                    XtraMessageBox.Show(string.Format("La cotización {0} ya esta aprobado, verifique", numeroCotizacion), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iAprobado.EditValue = false;
                    iFechaapobacion.EditValue = null;
                    return false;
                }

                var fechaAprobacion = iFechaapobacion.EditValue;
                if (fechaAprobacion == null)
                {
                    XtraMessageBox.Show("Ingrese la fecha de aprobacion", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    iFechaapobacion.Select();
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

                if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroCotizacionClienteExiste(idSucursal, idTipoCp, numeroSerie, numeroDoc))
                {
                    CargarInfoCorrelativo();
                    return true;
                }

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
                    btnImprimir.Enabled = Permisos.Imprimir;

                    CamposSoloLectura(!Permisos.Nuevo);

                    btnAddItem.Enabled = Permisos.Nuevo;
                    btnEditItem.Enabled = Permisos.Nuevo;
                    btnDelItem.Enabled = Permisos.Nuevo;
                    btnDelItemAll.Enabled = Permisos.Nuevo;
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    iAnulado.Enabled = Permisos.Anular;
                    btnImprimir.Enabled = Permisos.Imprimir;
                    CamposSoloLectura(!Permisos.Editar);

                    btnAddItem.Enabled = Permisos.Nuevo;
                    btnEditItem.Enabled = Permisos.Editar;
                    btnDelItem.Enabled = Permisos.Editar;
                    btnDelItemAll.Enabled = Permisos.Editar;

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

                    CotizacionclienteMnt = null;
                    CotizacionclienteMnt = new Cotizacioncliente();

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
                        CotizacionclienteMnt = null;
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

                        ImpresionFormato.FormatoCotizacionCliente(IdEntidadMnt);
                    }
                    break;
                case "btnRequerimiento":

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
        private void CotizacionclienteMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpCotizacioncliente, readOnly);
            WinFormUtils.ReadOnlyFields(tpLogistica, readOnly);
        }
        private void CotizacionclienteMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!ValidacionItems())
            {
                return;
            }

            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            CotizacionclienteMntItemFrm cotizacionclienteMntItemFrm;
            VwCotizacionclientedet vwCotizacionclientedetMntItem;

            if (OrdenVentaItemParameter == null)
            {
                OrdenVentaItemParameter = new CotizacionVentaItem();
            }


            if (VwSucursalSel == null)
            {
                VwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)rIdsucursal.EditValue);
                if (VwSucursalSel != null)
                {
                    OrdenVentaItemParameter.IdSucursalConsulta = VwSucursalSel.Idsucursal;
                    OrdenVentaItemParameter.IdAlmacenConsulta = VwSucursalSel.Idalmacendefecto;
                }
            }

            OrdenVentaItemParameter.IdTipoListaConsulta = (int)rIdtipolista.EditValue;
            OrdenVentaItemParameter.IdTipoMonedaConsulta = (int)iIdtipomoneda.EditValue;
            OrdenVentaItemParameter.IdTipoCondicion = (int)rIdtipocondicion.EditValue;
            OrdenVentaItemParameter.IdCliente = (int)iIdcliente.EditValue;

            if (gvDetalle.RowCount == 0)
            {
                VwEmpleado vwEmpleadoSel = CacheObjects.VwEmpleadoList.FirstOrDefault(x => x.Idempleado == (int)iIdempleado.EditValue);
                VwSocionegocioproyecto vwSocionegocioproyectoDefecto = CacheObjects.VwSocionegocioproyectoList.FirstOrDefault(x => x.Idsocionegocio == (int)iIdcliente.EditValue && x.Proyectopordefecto);
                if (vwEmpleadoSel != null && vwSocionegocioproyectoDefecto != null)
                {
                    OrdenVentaItemParameter.IdAreaEmpleado = vwEmpleadoSel.Idarea;
                    OrdenVentaItemParameter.IdProyectoCliente = vwSocionegocioproyectoDefecto.Idproyecto;
                    OrdenVentaItemParameter.IdCentroBeneficio = SessionApp.SucursalSel.Idcentrobeneficioventadefecto;
                }
            }

            switch (e.Item.Name)
            {
                case "btnAddItem":


                    //Asignar el siguiente item
                    vwCotizacionclientedetMntItem = new VwCotizacionclientedet();
                    var sgtItem = VwCotizacionclientedetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();
                    //

                    vwCotizacionclientedetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    cotizacionclienteMntItemFrm = new CotizacionclienteMntItemFrm(tipoMantenimientoItem, vwCotizacionclientedetMntItem, VwCotizacionclientedetList, OrdenVentaItemParameter);


                    cotizacionclienteMntItemFrm.ShowDialog();

                    if (cotizacionclienteMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwCotizacionclientedetList.Add(vwCotizacionclientedetMntItem);

                        //Agregar items de detalle compuesto
                        if (cotizacionclienteMntItemFrm.VwCotizacionclientedetComponenteList != null && cotizacionclienteMntItemFrm.VwCotizacionclientedetComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in cotizacionclienteMntItemFrm.VwCotizacionclientedetComponenteList)
                            {
                                VwCotizacionclientedetList.Add(itemDetCompuesto);
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


                    //itemSel = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();
                    //if (itemSel.Idcotizacionclientedet > 0
                    //&& Service.CantidadReferenciasItemCotizacioncliente(itemSel.IdCotizacionclientedet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    vwCotizacionclientedetMntItem = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    cotizacionclienteMntItemFrm = new CotizacionclienteMntItemFrm(tipoMantenimientoItem, vwCotizacionclientedetMntItem, VwCotizacionclientedetList, OrdenVentaItemParameter);


                    cotizacionclienteMntItemFrm.ShowDialog();
                    if (cotizacionclienteMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    //itemSel = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdCotizacionclientedet > 0
                    //&& Service.CantidadReferenciasItemCotizacioncliente(itemSel.IdCotizacionclientedet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwCotizacionclientedetMntItem = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();
                        vwCotizacionclientedetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }

                        SumarTotales();

                    }
                    break;
                case "btnDelItemAll":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    if (DialogResult.Yes == XtraMessageBox.Show(
                        "¿Desea eliminar todos los items?",
                        "Eliminar producto",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1))
                    {
                        foreach (var vwOrdendeventadet in VwCotizacionclientedetList)
                        {
                            //Validaciones por item
                            vwOrdendeventadet.DataEntityState = DataEntityState.Deleted;
                        }
                        SumarTotales();
                    }
                    break;
            }

        }
        private bool ValidacionItems()
        {

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCotizacioncliente, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCotizacioncliente;
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

            return true;
        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();


            var totalbruto = VwCotizacionclientedetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalgravado = VwCotizacionclientedetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rTotalgravado.EditValue = totalgravado;

            var totalinafecto = VwCotizacionclientedetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rTotalinafecto.EditValue = totalinafecto;

            var totalexonerado = VwCotizacionclientedetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rtotalexonerado.EditValue = totalexonerado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null)
            {
                var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal totalImpuesto = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
                rTotalimpuesto.EditValue = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
                rImportetotal.EditValue = totalgravado + totalinafecto + totalexonerado + totalImpuesto;

                //Calculo percepcion
                decimal totalValorPercepcion = VwCotizacionclientedetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                decimal importetotalpercepcion = Math.Round(totalValorPercepcion * (1 + porcentajeImpuesto / 100), 2);
                rImportetotalpercepcion.EditValue = importetotalpercepcion;
                //fin calculo percepcion

                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue +
                                            (decimal)rImportetotalpercepcion.EditValue;

            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);

            //Validaciones de referencias de documentos
            EstadoBuscadorSocioNegocio();
        }
        private void EstadoBuscadorSocioNegocio()
        {
            bool estado = gvDetalle.RowCount == 0;
            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = estado;
            }
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
                        rSeriecotizacion.EditValue = vwTipocp.Seriecp;
                        rNumerocotizacion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocotizacion.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocotizacion.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerocotizacion.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocotizacion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocotizacion.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriecotizacion.EditValue = @"0000";
                rNumerocotizacion.EditValue = 0;
            }
        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCotizacionclientedet item = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idcotizacionclientedet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
                //VwCotizacionclientedet vwCotizacionclientedet = Service.GetVwCotizacionclientedet(x => x.Idcotizacionclientedet == item.Idcotizacionclientedet);
                //decimal cantidadAnterior = vwCotizacionclientedet.Cantidad;
                //if (item.IdCotizacionclientedet > 0
                //    && Service.CantidadReferenciasItemCotizacioncliente(item.Idcotizacionclientedet) > 0)
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
        private void CalculaItem1(VwCotizacionclientedet item)
        {
            //VwCotizacionclientedet item = (VwCotizacionclientedet)gvDetalle.GetFocusedRow();

            decimal precioUnitarioNeto = item.Preciounitario
                                        * (1 - item.Descuento1 / 100)
                                        * (1 - item.Descuento2 / 100)
                                        * (1 - item.Descuento3 / 100)
                                        * (1 - item.Descuento4 / 100);

            item.Preciounitarioneto = decimal.Round(precioUnitarioNeto, 4);
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwCotizacionclientedet item)
        {
            decimal precioUnitarioNetoAux = item.Cantidad == 0 ? 0 : item.Importetotal / item.Cantidad;
            decimal precioUnitario = precioUnitarioNetoAux * 100 / (100 - item.Descuento4);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento3);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento2);
            precioUnitario = precioUnitario * 100 / (100 - item.Descuento1);

            item.Preciounitario = decimal.Round(precioUnitario, 4);

            decimal precioUnitarioNeto = item.Preciounitario
                            * (1 - item.Descuento1 / 100)
                            * (1 - item.Descuento2 / 100)
                            * (1 - item.Descuento3 / 100)
                            * (1 - item.Descuento4 / 100);

            item.Preciounitarioneto = decimal.Round(precioUnitarioNeto, 4);

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
            BarMntItems.EndUpdate();

        }
        private void CargarReferenciasCliente(int idSocioNegocio)
        {
            CargarDireccionesCliente(idSocioNegocio);
            CargarContactosCliente(idSocioNegocio);
            CargarProyectosCliente(idSocioNegocio);
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                int idDireccionPrincipal = Service.GetIdDireccionPrincipal(idSocioNegocio);
                if (idDireccionPrincipal > 0)
                {
                    iIddireccionfacturacion.EditValue = idDireccionPrincipal;
                    iIddireccionentrega.EditValue = idDireccionPrincipal;
                }
            }
        }
        private void CargarProyectosCliente(int idSocioNegocio)
        {
            string condicionCliente = string.Format("idsocionegocio = {0} and idempresa = {1}", idSocioNegocio, SessionApp.EmpresaSel.Idempresa);
            VwProyectoList = Service.GetAllVwSocionegocioproyecto(condicionCliente, "Nombreproyecto");
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                VwSocionegocioproyecto vwSocionegocioproyecto = VwProyectoList.FirstOrDefault(x => x.Proyectopordefecto);
                if (vwSocionegocioproyecto != null)
                {
                    iIdproyecto.EditValue = vwSocionegocioproyecto.Idproyecto;
                }
            }
        }
        private void CargarContactosCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociocontactoList = Service.GetAllSocionegociocontacto(whereSocioNegocio, "Nombrecontacto");
            iPersonacontacto.Properties.DataSource = SocionegociocontactoList;
            iPersonacontacto.Properties.DisplayMember = "Nombrecontacto";
            iPersonacontacto.Properties.ValueMember = "Idsocionegociocontacto";
            iPersonacontacto.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarDireccionesCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociodireccionList = Service.GetAllSocionegociodireccion(whereSocioNegocio, "Direccionsocionegocio");

            iIddireccionfacturacion.Properties.DataSource = SocionegociodireccionList;
            iIddireccionfacturacion.Properties.DisplayMember = "Direccionsocionegocio";
            iIddireccionfacturacion.Properties.ValueMember = "Idsocionegociodireccion";
            iIddireccionfacturacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIddireccionentrega.Properties.DataSource = SocionegociodireccionList;
            iIddireccionentrega.Properties.DisplayMember = "Direccionsocionegocio";
            iIddireccionentrega.Properties.ValueMember = "Idsocionegociodireccion";
            iIddireccionentrega.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void ObtenerTipoDeCambioVentaSunat()
        {
            Cursor = Cursors.WaitCursor;

            Cursor = Cursors.Default;
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
                        CargarDatosSocioNegocio(buscarSocioNegocioFrm.VwSocionegocioSel);
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        CargarDatosSocioNegocio(socionegocioMntFrm.VwSocionegocio);
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdcliente.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            CargarDatosSocioNegocio(socionegocioMntFrm.VwSocionegocio);
                        }
                    }
                    break;
            }
        }
        private void CargarDatosSocioNegocio(VwSocionegocio vwSocionegocio)
        {

            if (vwSocionegocio != null)
            {
                beSocioNegocio.Text = vwSocionegocio.Razonsocial.Trim();
                iIdcliente.EditValue = vwSocionegocio.Idsocionegocio;
                rIdtipocondicion.EditValue = vwSocionegocio.Idtipocondicion;
                rIdtipolista.EditValue = vwSocionegocio.Idtipolista;
                rIdtipocondicion.EditValue = vwSocionegocio.Idtipocondicion;
                rIncluyeimpuestoitems.EditValue = vwSocionegocio.Incluyeigvitems;
                VwSocionegocioSel = vwSocionegocio;
                CargarReferenciasCliente(vwSocionegocio.Idsocionegocio);
            }
        }
        private void iAprobado_EditValueChanged(object sender, EventArgs e)
        {
            iFechaapobacion.EditValue = iAprobado.Checked ? (object)DateTime.Now : null;
        }
        private void iIdempleado_EditValueChanged(object sender, EventArgs e)
        {
            var idEmpleadoSel = iIdempleado.EditValue ?? 0;
            string conditionEmpleadoArea = string.Format("idempleado = {0}", (int)idEmpleadoSel);
            VwEmpleadoareaList = Service.GetAllVwEmpleadoarea(conditionEmpleadoArea, "Nombrearea");
            iIdarea.Properties.DataSource = VwEmpleadoareaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                if (SessionApp.EmpleadoSel != null)
                {
                    var idAreaEmpleadoLogeado = SessionApp.EmpleadoSel.Idarea;
                    var areaEmpleadoPorDefecto =
                        Service.GetVwEmpleadoarea(
                            x => x.Idempleado == SessionApp.EmpleadoSel.Idempleado &&
                                 x.Idarea == idAreaEmpleadoLogeado);
                    if (areaEmpleadoPorDefecto != null)
                    {
                        iIdarea.EditValue = areaEmpleadoPorDefecto.Idarea;
                    }
                }
            }


        }
        private void iIdproyecto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm((int)iIdcliente.EditValue, TipoMantenimiento.Modificar, null, null, "tpProyectos");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0 && socionegocioMntFrm.IdProyectoSocioNegocioNuevo > 0)
            {
                CargarProyectosCliente(idCliente);                
                e.Cancel = false;
                e.NewValue = socionegocioMntFrm.IdProyectoSocioNegocioNuevo;
                
            }
        }
        private void iPersonacontacto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;

            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpContactos");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0 && socionegocioMntFrm.IdsocionegociocontactoNuevo > 0)
            {
                CargarReferenciasCliente(idCliente);
                e.Cancel = false;
                e.NewValue = socionegocioMntFrm.IdsocionegociocontactoNuevo;

            }
        }
        private void iIddireccionentrega_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpDirecciones");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0 && socionegocioMntFrm.IdsocionegociodireccionNuevo > 0)
            {
                CargarDireccionesCliente(idCliente);
                e.Cancel = false;
                e.NewValue = socionegocioMntFrm.IdsocionegociodireccionNuevo;

            }
        }
        private void iIddireccionfacturacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpDirecciones");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0 && socionegocioMntFrm.IdsocionegociodireccionNuevo > 0)
            {
                CargarDireccionesCliente(idCliente);
                e.Cancel = false;
                e.NewValue = socionegocioMntFrm.IdsocionegociodireccionNuevo;

            }
        }
    }

    public class CotizacionVentaItem
    {
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public int IdTipoMonedaConsulta { get; set; }
        public int IdTipoCondicion { get; set; }
        public int? IdAreaEmpleado { get; set; }
        public int? IdProyectoCliente { get; set; }
        public int? IdCentroBeneficio { get; set; }
        public int IdCliente { get; set; }
    }
}