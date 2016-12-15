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
    public partial class GuiaremisionMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public DataEntityState DataEntityState { get; set; }
        public int IdUsuario { get; set; }
        public GridControl GridParent { get; set; }
        public GuiaremisionFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Guiaremision GuiaremisionMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public VwSocionegocio VwEmpresaTransporteSel { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public List<Socionegociodireccion> SocionegociodireccionList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwGuiaremisiondet> VwGuiaremisiondetList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public GuiaremisionMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, GuiaremisionFrm formParent) 
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
        private void GuiaremisionMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFechaguiaremision.EditValue = DateTime.Now;
            iFechatrasladoguia.EditValue = DateTime.Now;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            iAlmacenorigen.EditValue = SessionApp.SucursalSel.Idsucursal;
    

            int? idAlmacenDefecto = SessionApp.SucursalSel.Idalmacendefecto;
            if (idAlmacenDefecto > 0)
            {
                iAlmacenorigen.EditValue = idAlmacenDefecto;
            }

            if (SessionApp.EmpleadoSel != null)
            {
                iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
            }

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            iIdtipolista.EditValue = SessionApp.SucursalSel.Idtipolistadefecto;
            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "GUIAREMISION";
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
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    GuiaremisionMnt = new Guiaremision();                    
                    CargarDetalle();
                    iIdtipocp.Select();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoMenuImportacion();
                    CargarDetalle();
                    EstadoReferenciaSalidaAlmacen();
                    break;
            }           
        }
        private void EstadoReferenciaSalidaAlmacen()
        {
            if (Service.GuiaRemisionTieneReferenciaSalidaAlmacen(IdEntidadMnt))
            {
                XtraMessageBox.Show("Guia tiene referencias en salida de almacen", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
                EstadoBuscadorSocioNegocio(false);
                EstadoBuscadorEmpresaTransporte(false);

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

            BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItems.EndUpdate();

        }
        private void EstadoMenuImportacion()
        {
            if (rListadoreqref.Text.Trim().Length > 0)
            {
                btnRequerimiento.Enabled = true;
                btnOrdenVenta.Enabled = false;
                btnCpCompraImp.Enabled = false;
                btnEntradaAlmacen.Enabled = false;

                gcNumeroReq.Visible = true;
                gcNumeroOrden.Visible = false;
                gcCpCompra.Visible = false;
                gcEntAlmacen.Visible = false;
            }

            if (rListadoordenventaref.Text.Trim().Length > 0)
            {
                btnRequerimiento.Enabled = false;
                btnOrdenVenta.Enabled = true;
                btnCpCompraImp.Enabled = false;
                btnEntradaAlmacen.Enabled = false;


                gcNumeroReq.Visible = false;
                gcNumeroOrden.Visible = true;
                gcCpCompra.Visible = false;
                gcEntAlmacen.Visible = false;
            }


            if (rListadpcpcompraref.Text.Trim().Length > 0)
            {
                btnRequerimiento.Enabled = false;
                btnOrdenVenta.Enabled = false;
                btnCpCompraImp.Enabled = true;
                btnEntradaAlmacen.Enabled = false;


                gcNumeroReq.Visible = false;
                gcNumeroOrden.Visible = false;
                gcCpCompra.Visible = true;
                gcEntAlmacen.Visible = false;

                iIdguiaremisionmotivo.ReadOnly = true;
            }


            if (rListadoentradaalmacenref.Text.Trim().Length > 0)
            {
                btnRequerimiento.Enabled = false;
                btnOrdenVenta.Enabled = false;
                btnCpCompraImp.Enabled = false;
                btnEntradaAlmacen.Enabled = true;


                gcNumeroReq.Visible = false;
                gcNumeroOrden.Visible = false;
                gcCpCompra.Visible = false;
                gcEntAlmacen.Visible = true;
            }

            if (rListadoreqref.Text.Trim().Length == 0 
                && rListadoordenventaref.Text.Trim().Length == 0
                && rListadpcpcompraref .Text.Trim().Length == 0
                && rListadoentradaalmacenref.Text.Trim().Length == 0)
            {
                btnRequerimiento.Enabled = true;
                btnOrdenVenta.Enabled = true;
                btnCpCompraImp.Enabled = true;
                btnEntradaAlmacen.Enabled = true;

                gcNumeroReq.Visible = false;
                gcNumeroOrden.Visible = false;
                gcCpCompra.Visible = false;
                gcEntAlmacen.Visible = false;

            }


        }
        private void CargarReferencias()
        {


            iAlmacenorigen.Properties.DataSource = Service.GetAllVwAlmacen();
            iAlmacenorigen.Properties.DisplayMember = "Nombrealmacen";
            iAlmacenorigen.Properties.ValueMember = "Idalmacen";
            iAlmacenorigen.Properties.BestFitMode = BestFitMode.BestFit;

            iAlmacendestino.Properties.DataSource = Service.GetAllAlmacen();
            iAlmacendestino.Properties.DisplayMember = "Nombrealmacen";
            iAlmacendestino.Properties.ValueMember = "Idalmacen";
            iAlmacendestino.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "GUIAREMISION", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "GUIAREMISION", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdguiaremisionmotivo.Properties.DataSource = Service.GetAllGuiaremisionmotivo();
            iIdguiaremisionmotivo.Properties.DisplayMember = "Nombreguiaremisionmotivo";
            iIdguiaremisionmotivo.Properties.ValueMember = "Idguiaremisionmotivo";
            iIdguiaremisionmotivo.Properties.BestFitMode = BestFitMode.BestFit;

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

            string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwSucursalList = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal");
            iIdsucursal.Properties.DataSource = VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void TraerDatos()
        {
            try
            {
                GuiaremisionMnt = Service.GetGuiaremision(IdEntidadMnt);


                iIdtipocp.EditValue = GuiaremisionMnt.Idtipocp;
                iIdcptooperacion.EditValue = GuiaremisionMnt.Idcptooperacion;
                rSerieguiaremision.EditValue = GuiaremisionMnt.Serieguiaremision;
                rNumeroguiaremision.EditValue = GuiaremisionMnt.Numeroguiaremision;
                iFechaguiaremision.EditValue = GuiaremisionMnt.Fechaguiaremision;
                iFechatrasladoguia.EditValue = GuiaremisionMnt.Fechatrasladoguia;
                iAnulado.EditValue = GuiaremisionMnt.Anulado;
                iFechaanulado.EditValue = GuiaremisionMnt.Fechaanulado;                
                iIdsucursal.EditValue = GuiaremisionMnt.Idsucursal;
                iAlmacenorigen.EditValue = GuiaremisionMnt.Almacenorigen;
                iAlmacendestino.EditValue = GuiaremisionMnt.Almacendestino;
                iIdsocionegocio.EditValue = GuiaremisionMnt.Idsocionegocio;
                CargarDatosSocioNegocio(GuiaremisionMnt.Idsocionegocio);

                iIddireccionsocio.EditValue = GuiaremisionMnt.Iddireccionsocio;
                iIdguiaremisionmotivo.EditValue = GuiaremisionMnt.Idguiaremisionmotivo;
                iIdempleado.EditValue = GuiaremisionMnt.Idempleado;
                iGlosaguiaremision.EditValue = GuiaremisionMnt.Glosaguiaremision;
                iIdempresatransporte.EditValue = GuiaremisionMnt.Idempresatransporte;

                if (GuiaremisionMnt.Idempresatransporte != null)
                {
                    CargarDatosEmpresaDeTransporte((int)GuiaremisionMnt.Idempresatransporte);
                }
                

                iPlacavehiculo.EditValue = GuiaremisionMnt.Placavehiculo;
                iMarcavehiculo.EditValue = GuiaremisionMnt.Marcavehiculo;
                iCertificadovehiculo.EditValue = GuiaremisionMnt.Certificadovehiculo;
                iChofervehiculo.EditValue = GuiaremisionMnt.Chofervehiculo;
                iLicenciachofer.EditValue = GuiaremisionMnt.Licenciachofer;
                iDnichofer.EditValue = GuiaremisionMnt.Dnichofer;
                iIdtipomoneda.EditValue = GuiaremisionMnt.Idtipomoneda;
                iIdimpuesto.EditValue = GuiaremisionMnt.Idimpuesto;
                iTipocambio.EditValue = GuiaremisionMnt.Tipocambio;
                rTotalbruto.EditValue = GuiaremisionMnt.Totalbruto;
                rTotalgravado.EditValue = GuiaremisionMnt.Totalgravado;
                rTotalinafecto.EditValue = GuiaremisionMnt.Totalinafecto;
                rTotalexonerado.EditValue = GuiaremisionMnt.Totalexonerado;
                rTotalimpuesto.EditValue = GuiaremisionMnt.Totalimpuesto;
                rImportetotal.EditValue = GuiaremisionMnt.Importetotal;
                rPorcentajepercepcion.EditValue = GuiaremisionMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = GuiaremisionMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = GuiaremisionMnt.Totaldocumento;
                iIdtipolista.EditValue = GuiaremisionMnt.Idtipolista;

                rListadoreqref.EditValue = GuiaremisionMnt.Listadoreqref;
                rListadoordenventaref.EditValue = GuiaremisionMnt.Listadoordenventaref;
                rListadpcpcompraref.EditValue = GuiaremisionMnt.Listadpcpcompraref;
                rListadoentradaalmacenref.EditValue = GuiaremisionMnt.Listadoentradaalmacenref;

                iIncluyeimpuestoitems.EditValue = GuiaremisionMnt.Incluyeimpuestoitems;




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
            string where = string.Format("idguiaremision = '{0}'", IdEntidadMnt);
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            gvDetalle.BeginUpdate();
            VwGuiaremisiondetList = Service.GetAllVwGuiaremisiondet(where, "numeroitem");
            gcDetalle.DataSource = VwGuiaremisiondetList;
            SumarTotales();  
            gvDetalle.EndUpdate();

        }
        private void SumarTotales()
        {
            
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            decimal totalbruto = VwGuiaremisiondetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwGuiaremisiondetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwGuiaremisiondetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalexonerado = VwGuiaremisiondetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwGuiaremisiondetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
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

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;



            GuiaremisionMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            GuiaremisionMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            GuiaremisionMnt.Serieguiaremision = rSerieguiaremision.Text.Trim();
            GuiaremisionMnt.Numeroguiaremision = rNumeroguiaremision.Text.Trim();
            GuiaremisionMnt.Fechaguiaremision = (DateTime)iFechaguiaremision.EditValue;
            GuiaremisionMnt.Fechatrasladoguia = (DateTime)iFechatrasladoguia.EditValue;
            GuiaremisionMnt.Anulado = (bool)iAnulado.EditValue;
            GuiaremisionMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            GuiaremisionMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            GuiaremisionMnt.Idsucursal = (int?)iIdsucursal.EditValue;
            GuiaremisionMnt.Almacenorigen = (int?)iAlmacenorigen.EditValue;
            GuiaremisionMnt.Almacendestino = (int?)iAlmacendestino.EditValue;
            GuiaremisionMnt.Idsocionegocio = (int)iIdsocionegocio.EditValue;
            GuiaremisionMnt.Iddireccionsocio = (int?)iIddireccionsocio.EditValue;
            GuiaremisionMnt.Idguiaremisionmotivo = (int?)iIdguiaremisionmotivo.EditValue;
            GuiaremisionMnt.Idempleado = (int?)iIdempleado.EditValue;
            GuiaremisionMnt.Glosaguiaremision = iGlosaguiaremision.Text.Trim();
            GuiaremisionMnt.Idempresatransporte = (int?)iIdempresatransporte.EditValue;
            GuiaremisionMnt.Placavehiculo = iPlacavehiculo.Text.Trim();
            GuiaremisionMnt.Marcavehiculo = iMarcavehiculo.Text.Trim();
            GuiaremisionMnt.Certificadovehiculo = iCertificadovehiculo.Text.Trim();
            GuiaremisionMnt.Chofervehiculo = iChofervehiculo.Text.Trim();
            GuiaremisionMnt.Licenciachofer = iLicenciachofer.Text.Trim();
            GuiaremisionMnt.Dnichofer = iDnichofer.Text.Trim();
            GuiaremisionMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            GuiaremisionMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            GuiaremisionMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            GuiaremisionMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            GuiaremisionMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            GuiaremisionMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            GuiaremisionMnt.Totalexonerado = (decimal)rTotalexonerado.EditValue;
            GuiaremisionMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            GuiaremisionMnt.Importetotal = (decimal)rImportetotal.EditValue;
            GuiaremisionMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            GuiaremisionMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            GuiaremisionMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            GuiaremisionMnt.Idtipolista = (int) iIdtipolista.EditValue;

            GuiaremisionMnt.Listadoreqref = rListadoreqref.Text.Trim();
            GuiaremisionMnt.Listadoordenventaref = rListadoordenventaref.Text.Trim();
            GuiaremisionMnt.Listadpcpcompraref = rListadpcpcompraref.Text.Trim();
            GuiaremisionMnt.Listadoentradaalmacenref = rListadoentradaalmacenref.Text.Trim();


            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //PersonaMnt.Createdby = IdUsuario;
                    //PersonaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //PersonaMnt.Modifiedby = IdUsuario;
                    //PersonaMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    if (Service.GuardarGuiaremision(TipoMnt, GuiaremisionMnt, VwGuiaremisiondetList))
                    {
                        IdEntidadMnt = GuiaremisionMnt.Idguiaremision;
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
                    Service.GuardarGuiaremision(TipoMnt, GuiaremisionMnt, VwGuiaremisiondetList);
                    DataEntityState = DataEntityState.Modified;
                    break;
                }

                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerieguiaremision.Text.Trim(), rNumeroguiaremision.Text.Trim());
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

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
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "GUIAREMISION";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpGuiaRemision, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }


            var idcptooperacion = iIdcptooperacion.EditValue;
            if (idcptooperacion != null)
            {
                VwCptooperacion vwCptooperacionSel = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int)idcptooperacion);
                if (vwCptooperacionSel != null && vwCptooperacionSel.Generatrasladoentrealmacenes && iAlmacendestino.EditValue == null)
                {
                    XtraMessageBox.Show("Seleccione el almacén de destino", Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    iAlmacendestino.Select();
                    return false;
                }

            }

            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            decimal tipoCambio = (decimal) iTipocambio.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            {
                XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK,MessageBoxIcon.Error);
                iTipocambio.Select();
                return false;
            }
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
                        Service.DeleteGuiaremision(IdEntidadMnt);
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
            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();

                    TipoMnt =TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    GuiaremisionMnt = null;
                    GuiaremisionMnt = new Guiaremision();

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
                    GuiaremisionMnt = null;
                    DialogResult = DialogResult.OK;
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoGuiaRemision(GuiaremisionMnt);
                    }
                    break;
                case "btnRequerimiento":
                    if (!ValidarSocioNegocioImportacion()) return;

                    GuiaRemisionMntImpReqFrm guiaRemisionMntImpReqFrm = new GuiaRemisionMntImpReqFrm(VwGuiaremisiondetList,(int)iIdtipomoneda.EditValue);
                    guiaRemisionMntImpReqFrm.ShowDialog();

                    if (guiaRemisionMntImpReqFrm.DialogResult == DialogResult.OK)
                    {
                        iIdtipomoneda.EditValue = guiaRemisionMntImpReqFrm.VwRequerimientoSel.Idtipomoneda;
                        iIncluyeimpuestoitems.EditValue = guiaRemisionMntImpReqFrm.VwRequerimientoSel.Incluyeimpuestoitems;
                        iIdtipomoneda.ReadOnly = true;
                        iTipocambio.EditValue = guiaRemisionMntImpReqFrm.VwRequerimientoSel.Tipocambio;

                        foreach (var item in VwGuiaremisiondetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        

                        //VwRequerimiento vwRequerimientoSel = guiaRemisionMntImpReqFrm.VwRequerimientoSel;

                        //if (vwRequerimientoSel != null)
                        //{
                        //    iIdsucursal.EditValue = vwRequerimientoSel.Idsucursal;
                        //}

                        EstadoBuscadorSocioNegocio(false);
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();
                        SumarTotales();

                    }
                    break;
                case "btnOrdenVenta":
                    if (!ValidarSocioNegocioImportacion()) return;

                    GuiaRemisionMntImpOrdenVtaFrm guiaRemisionMntImpOrdenVtaFrm = new GuiaRemisionMntImpOrdenVtaFrm(VwGuiaremisiondetList, VwSocionegocioSel, (int)iIdtipomoneda.EditValue);
                    guiaRemisionMntImpOrdenVtaFrm.ShowDialog();

                    if (guiaRemisionMntImpOrdenVtaFrm.DialogResult == DialogResult.OK)
                    {
                        iIdtipomoneda.EditValue = guiaRemisionMntImpOrdenVtaFrm.VwOrdendeventaSel.Idtipomoneda;
                        iIncluyeimpuestoitems.EditValue = guiaRemisionMntImpOrdenVtaFrm.VwOrdendeventaSel.Incluyeimpuestoitems;
                        iIdtipomoneda.ReadOnly = true;
                        iTipocambio.EditValue = guiaRemisionMntImpOrdenVtaFrm.VwOrdendeventaSel.Tipocambio;

                        foreach (var item in VwGuiaremisiondetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        


                        //VwOrdendeventa vwOrdendeventaSel = guiaRemisionMntImpOrdenVtaFrm.VwOrdendeventaSel;
                        //if (vwOrdendeventaSel != null)
                        //{
                        //    iIdsucursal.EditValue = vwOrdendeventaSel.Idsucursal;
                        //}


                        EstadoBuscadorSocioNegocio(false);
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();
                        SumarTotales();

                    }
                    break;
                case "btnCpCompraImp":
                    if (!ValidarSocioNegocioImportacion()) return;

                    GuiaRemisionMntImpCpCompraFrm guiaRemisionMntImpCpCompraFrm = new GuiaRemisionMntImpCpCompraFrm(VwGuiaremisiondetList, VwSocionegocioSel, (int)iIdtipomoneda.EditValue);
                    guiaRemisionMntImpCpCompraFrm.ShowDialog();

                    if (guiaRemisionMntImpCpCompraFrm.DialogResult == DialogResult.OK)
                    {
                        iIdtipomoneda.EditValue = guiaRemisionMntImpCpCompraFrm.VwCpcompraSel.Idtipomoneda;
                        iIncluyeimpuestoitems.EditValue = guiaRemisionMntImpCpCompraFrm.VwCpcompraSel.Incluyeimpuestoitems;
                        iIdtipomoneda.ReadOnly = true;
                        iTipocambio.EditValue = guiaRemisionMntImpCpCompraFrm.VwCpcompraSel.Tipocambio;

                        foreach (var item in VwGuiaremisiondetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        
                        //VwRequerimiento vwRequerimientoSel = guiaRemisionMntImpReqFrm.VwRequerimientoSel;
                        //if (vwRequerimientoSel != null)
                        //{
                        //    iIdsucursal.EditValue = vwRequerimientoSel.Idsucursal;
                        //}
                        EstadoBuscadorSocioNegocio(false);
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();

                        SumarTotales();

                        //Asginar el motivo a devolucion
                        iIdguiaremisionmotivo.EditValue = 4; //DEVOLUCION
                        iIdguiaremisionmotivo.ReadOnly = true;
                    }
                    break;
                case "btnEntradaAlmacen":
                    if (!ValidarSocioNegocioImportacion()) return;

                    GuiaRemisionMntImpEntradaAlmacenFrm guiaRemisionMntImpEntradaAlmacenFrm = new GuiaRemisionMntImpEntradaAlmacenFrm(VwGuiaremisiondetList, VwSocionegocioSel, (int)iIdtipomoneda.EditValue);
                    guiaRemisionMntImpEntradaAlmacenFrm.ShowDialog();

                    if (guiaRemisionMntImpEntradaAlmacenFrm.DialogResult == DialogResult.OK)
                    {
                        iIdtipomoneda.EditValue = guiaRemisionMntImpEntradaAlmacenFrm.VwEntradaalmacenSel.Idtipomoneda;
                        iIncluyeimpuestoitems.EditValue = guiaRemisionMntImpEntradaAlmacenFrm.VwEntradaalmacenSel.Incluyeimpuestoitems;
                        iIdtipomoneda.ReadOnly = true;
                        iTipocambio.EditValue = guiaRemisionMntImpEntradaAlmacenFrm.VwEntradaalmacenSel.Tipocambio;

                        foreach (var item in VwGuiaremisiondetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }

                        //VwRequerimiento vwRequerimientoSel = guiaRemisionMntImpReqFrm.VwRequerimientoSel;
                        //if (vwRequerimientoSel != null)
                        //{
                        //    iIdsucursal.EditValue = vwRequerimientoSel.Idsucursal;
                        //}

                        EstadoBuscadorSocioNegocio(false);
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();

                        SumarTotales();

                        //Asginar el motivo a devolucion
                        iIdguiaremisionmotivo.EditValue = 4; //DEVOLUCION
                        iIdguiaremisionmotivo.ReadOnly = true;
                    }
                    break;
            }
        }
        private void EstadoBuscadorSocioNegocio(bool estado)
        {
            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = estado;
            }
        }
        private void EstadoBuscadorEmpresaTransporte(bool estado)
        {
            for (int i = 0; i < beEmpresatransporte.Properties.Buttons.Count; i++)
            {
                beEmpresatransporte.Properties.Buttons[i].Enabled = estado;
            }
        }
        private void ListarDocumentosReferencia()
        {
            ListarRequerimientosReferencia();
            ListarOrdenesDeVentaReferencia();
            ListarCpCompraReferencia();
            ListarEntradaAlmacen();
        }
        private void ListarEntradaAlmacen()
        {
            List<string> listadoEntradas = new List<string>();
            List<string> serieNumeroEntradaList = VwGuiaremisiondetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Serienumeroentradaalmacen ))
                .Select(p => p.Serienumeroentradaalmacen).Distinct().ToList();

            if (serieNumeroEntradaList.Count > 0)
            {
                foreach (string serieNumeroEntrada in serieNumeroEntradaList)
                {
                    string[] splitSerieNumerioOrden = serieNumeroEntrada.Split('-');
                    if (splitSerieNumerioOrden.Count() == 2)
                    {
                        string numeroOvRef = string.Format("{0}-{1}"
                            , Convert.ToInt32(splitSerieNumerioOrden[0])
                            , Convert.ToInt32(splitSerieNumerioOrden[1]));
                        listadoEntradas.Add(numeroOvRef);
                    }
                }
                string listadoEntradaAlmacen = listadoEntradas.Aggregate(String.Empty,
                    (current, numeroOrden) => current + numeroOrden + ",");

                rListadoentradaalmacenref.EditValue = listadoEntradaAlmacen.Trim().Length == 0
                    ? string.Empty
                    : listadoEntradaAlmacen.Substring(0, listadoEntradaAlmacen.Length - 1);
            }
            else
            {
                rListadoentradaalmacenref.EditValue = string.Empty;
            }
        }
        private void ListarCpCompraReferencia()
        {
            List<string> listadoNumeroCpCompras = new List<string>();
            List<string> serieNumeroCpCompraList = VwGuiaremisiondetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Serienumerocpcompra))
                .Select(p => p.Serienumerocpcompra).Distinct().ToList();

            if (serieNumeroCpCompraList.Count > 0)
            {
                foreach (string serieCpCompra in serieNumeroCpCompraList)
                {
                    string[] splitSerieNumeroCpCompra = serieCpCompra.Split('-');
                    if (splitSerieNumeroCpCompra.Count() == 2)
                    {
                        string numeroCpCompraRef = string.Format("{0}-{1}"
                            , splitSerieNumeroCpCompra[0]
                            , Convert.ToInt32(splitSerieNumeroCpCompra[1]));
                        listadoNumeroCpCompras.Add(numeroCpCompraRef);
                    }
                }
                string listadoCpCompra = listadoNumeroCpCompras.Aggregate(String.Empty,
                    (current, numeroOrden) => current + numeroOrden + ",");
                rListadpcpcompraref.EditValue = listadoCpCompra.Trim().Length == 0
                    ? string.Empty
                    : listadoCpCompra.Substring(0, listadoCpCompra.Length - 1);
            }
            else
            {
                rListadpcpcompraref.EditValue = string.Empty;
            }

        }
        private void ListarOrdenesDeVentaReferencia()
        {
            List<string> listadoNumeroOrdenes = new List<string>();
            List<string> serieNumeroOrdenList = VwGuiaremisiondetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Serienumeroordenventa))
                .Select(p => p.Serienumeroordenventa).Distinct().ToList();

            if (serieNumeroOrdenList.Count > 0)
            {
                foreach (string serieNumeroOrden in serieNumeroOrdenList)
                {
                    string[] splitSerieNumerioOrden = serieNumeroOrden.Split('-');
                    if (splitSerieNumerioOrden.Count() == 2)
                    {
                        string numeroOvRef = string.Format("{0}-{1}"
                            , Convert.ToInt32(splitSerieNumerioOrden[0])
                            , Convert.ToInt32(splitSerieNumerioOrden[1]));
                        listadoNumeroOrdenes.Add(numeroOvRef);
                    }
                }
                string listadoOrdenVenta = listadoNumeroOrdenes.Aggregate(String.Empty,
                    (current, numeroOrden) => current + numeroOrden + ",");
                rListadoordenventaref.EditValue = listadoOrdenVenta.Trim().Length == 0
                    ? string.Empty
                    : listadoOrdenVenta.Substring(0, listadoOrdenVenta.Length - 1);
            }
            else
            {
                rListadoordenventaref.EditValue = string.Empty;
            }
        }
        private void ListarRequerimientosReferencia()
        {
            List<string> listadoNumeroReq = new List<string>();

            List<string> serieNumeroReqList = VwGuiaremisiondetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Serienumeroreq))
                .Select(p => p.Serienumeroreq).Distinct().ToList();

            if (serieNumeroReqList.Count > 0)
            {
                foreach (string serieNumeroReq in serieNumeroReqList)
                {
                    string[] splitSerieNumeroReq = serieNumeroReq.Split('-');
                    if (splitSerieNumeroReq.Count() == 2)
                    {
                        string numeroOvRef = string.Format("{0}-{1}"
                            , Convert.ToInt32(splitSerieNumeroReq[0])
                            , Convert.ToInt32(splitSerieNumeroReq[1]));
                        listadoNumeroReq.Add(numeroOvRef);
                    }
                }
                string listadoReq = listadoNumeroReq.Aggregate(String.Empty,
                    (current, numeroReq) => current + numeroReq + ",");
                rListadoreqref.EditValue = listadoReq.Trim().Length == 0
                    ? string.Empty
                    : listadoReq.Substring(0, listadoReq.Length - 1);
            }
            else
            {
                rListadoreqref.EditValue = string.Empty;
            }
        }
        private bool ValidarSocioNegocioImportacion()
        {
            var idSocioNegocioSel = iIdsocionegocio.EditValue;
            if ((int) idSocioNegocioSel == 0)
            {
                XtraMessageBox.Show("Seleccione el Socio de negocio.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                beSocioNegocio.Select();
                return false;
            }
            return true;
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
        private void GuiaremisionMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpGuiaRemision, readOnly);
            WinFormUtils.ReadOnlyFields(tpTransporte, readOnly);
            WinFormUtils.ReadOnlyFields(tpObservacion, readOnly);
            WinFormUtils.ReadOnlyFields(tpReferencias, readOnly);

        }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            GuiaremisionMntItemFrm guiaremisionMntItemFrm;
            VwGuiaremisiondet vwGuiaremisiondetMnt;

            //Propiedades para consulta
            int idSucursalConsulta = 0;
            int idAlmacenConsulta = 0;
            int idTipoListaConsulta = 0;

            VwSucursal vwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)iIdsucursal.EditValue);
            if (vwSucursalSel != null)
            {
                idSucursalConsulta = vwSucursalSel.Idsucursal;
                idAlmacenConsulta = vwSucursalSel.Idalmacendefecto;
                idTipoListaConsulta = (int)iIdtipolista.EditValue;
            }
            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Validar que se seleccione el cliente
                    int idSocioNegocioSel = (int)iIdsocionegocio.EditValue;
                    if (idSocioNegocioSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione la persona", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        beSocioNegocio.Select();
                        return;
                    }

                    //Asignar el siguiente item
                    vwGuiaremisiondetMnt = new VwGuiaremisiondet();
                    var sgtItem = VwGuiaremisiondetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();
                    //

                    vwGuiaremisiondetMnt.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    guiaremisionMntItemFrm = new GuiaremisionMntItemFrm(tipoMantenimientoItem, vwGuiaremisiondetMnt);

                    //Establecer el ultimo centro de costo
                    VwGuiaremisiondet vwGuiaremisiondetLast = VwGuiaremisiondetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);
                    if (vwGuiaremisiondetLast != null)
                    {
                        guiaremisionMntItemFrm.IdCentroDeCostoPorDefecto = vwGuiaremisiondetLast.Idcentrodecosto;
                        guiaremisionMntItemFrm.IdAreaPorDefecto = vwGuiaremisiondetLast.Idarea;
                        guiaremisionMntItemFrm.IdProyectoPorDefecto = vwGuiaremisiondetLast.Idproyecto;
                    }
                    else
                    {
                        guiaremisionMntItemFrm.IdCentroDeCostoPorDefecto = 0;
                        guiaremisionMntItemFrm.IdAreaPorDefecto = 0;
                        guiaremisionMntItemFrm.IdProyectoPorDefecto = 0;
                    }

                    //
                    guiaremisionMntItemFrm.IdSucursalConsulta = idSucursalConsulta;
                    guiaremisionMntItemFrm.IdAlmacenConsulta = idAlmacenConsulta;
                    guiaremisionMntItemFrm.IdTipoListaConsulta = idTipoListaConsulta;

                    guiaremisionMntItemFrm.ShowDialog();

                    if (guiaremisionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwGuiaremisiondetList.Add(vwGuiaremisiondetMnt);

                        //Agregar items de detalle compuesto
                        if (guiaremisionMntItemFrm.VwVwGuiaremisiondetComponenteList != null && guiaremisionMntItemFrm.VwVwGuiaremisiondetComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in guiaremisionMntItemFrm.VwVwGuiaremisiondetComponenteList)
                            {
                                VwGuiaremisiondetList.Add(itemDetCompuesto);
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

                    vwGuiaremisiondetMnt = (VwGuiaremisiondet)gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    guiaremisionMntItemFrm = new GuiaremisionMntItemFrm(tipoMantenimientoItem, vwGuiaremisiondetMnt);
                    guiaremisionMntItemFrm.ShowDialog();
                    if (guiaremisionMntItemFrm.DialogResult == DialogResult.OK)
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
                        vwGuiaremisiondetMnt = (VwGuiaremisiondet)gvDetalle.GetFocusedRow();
                        vwGuiaremisiondetMnt.DataEntityState = DataEntityState.Deleted;
                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }
                        SumarTotales();
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();
                        if (gvDetalle.RowCount == 0)
                        {
                            EstadoBuscadorSocioNegocio(true);
                        }
                    }
                    break;
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
                        rSerieguiaremision.EditValue = vwTipocp.Seriecp;
                        rNumeroguiaremision.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroguiaremision.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroguiaremision.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroguiaremision.EditValue = vwTipocp.Seriecp;
                        rNumeroguiaremision.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroguiaremision.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieguiaremision.EditValue = @"0000";
                rNumeroguiaremision.EditValue = 0;
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
                iIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
                iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
                CargarDirecciones();
            }
        }
        private void CargarDatosEmpresaDeTransporte(int idSocioNegocio)
        {
            VwSocionegocioSel = Service.GetVwSocionegocio(idSocioNegocio);

            if (VwSocionegocioSel != null)
            {
                beEmpresatransporte.Text = VwSocionegocioSel.Razonsocial.Trim();
                iIdempresatransporte.EditValue = VwSocionegocioSel.Idsocionegocio;
            }
        }
        private void CargarDirecciones()
        {
            if (VwSocionegocioSel != null)
            {
                string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", VwSocionegocioSel.Idsocionegocio);
                SocionegociodireccionList = Service.GetAllSocionegociodireccion(whereSocioNegocio, "Direccionsocionegocio");

                iIddireccionsocio.Properties.DataSource = SocionegociodireccionList;
                iIddireccionsocio.Properties.DisplayMember = "Direccionsocionegocio";
                iIddireccionsocio.Properties.ValueMember = "Idsocionegociodireccion";
                iIddireccionsocio.Properties.BestFitMode = BestFitMode.BestFit;


                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    int idDireccionPrincipal = Service.GetIdDireccionPrincipal(VwSocionegocioSel.Idsocionegocio);
                    if (idDireccionPrincipal > 0)
                    {
                        iIddireccionsocio.EditValue = idDireccionPrincipal;                        
                    }
                }
            }
        }
        private void beEmpresatransporte_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        CargarDatosEmpresaDeTransporte(buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio);
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        CargarDatosEmpresaDeTransporte(socionegocioMntFrm.IdEntidadMnt);
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdempresatransporte.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            CargarDatosEmpresaDeTransporte(socionegocioMntFrm.IdEntidadMnt);
                        }
                    }
                    break;
            }
        }
        private void CalculaItem1(VwGuiaremisiondet item)
        {
            item.Importetotal = Decimal.Round(item.Cantidad * item.Preciounitario, 2);
            item.Pesototal = Decimal.Round(item.Cantidad * item.Pesounitario, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwGuiaremisiondet item)
        {
            item.Preciounitario = Decimal.Round(item.Importetotal / item.Cantidad, 2);
            item.DataEntityState = DataEntityState.Modified;

        }
        private void CalculaItem3(VwGuiaremisiondet item)
        {
            item.Pesototal  = Decimal.Round(item.Pesototal / item.Cantidad, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwGuiaremisiondet item = (VwGuiaremisiondet)gvDetalle.GetFocusedRow();

            //TipoMantenimiento TipoMnt = item.Idguiaremisiondet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
            //switch (TipoMnt)
            //{
            //    case TipoMantenimiento.Nuevo:
            //        item.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
            //        item.Creationdate = DateTime.Now;
            //        break;
            //    case TipoMantenimiento.Modificar:
            //        item.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
            //        item.Lastmodified = DateTime.Now;
            //        break;
            //}

            switch (e.Column.FieldName)
            {
                case "Cantidad":
                case "Preciounitario":
                case "Pesounitario":
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
                case "Pesototal":                    
                    CalculaItem3(item);
                    SumarTotales();
                    break;
            }
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwGuiaremisiondetList != null)
            {
                SumarTotales();
            }   
        }
        private void iIdcptooperacion_EditValueChanged(object sender, EventArgs e)
        {
            var idcptooperacion = iIdcptooperacion.EditValue;
            if (idcptooperacion != null)
            {
                VwCptooperacion vwCptooperacionSel = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int) idcptooperacion);
                if (vwCptooperacionSel != null && vwCptooperacionSel.Generatrasladoentrealmacenes)
                {
                    iIdguiaremisionmotivo.EditValue = 2; //TRASLADO ENTRE ESTABLECIMIENTO DE UNA MISMA EMPRESA
                }
                else
                {
                    iIdguiaremisionmotivo.EditValue = null;
                }
            }
        }
    }
}