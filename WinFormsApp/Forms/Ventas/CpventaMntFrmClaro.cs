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
    public partial class CpventaMntFrmClaro : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CpventaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public VwCpventa VwCpventaMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public List<VwCpventadet> VwCpventadetList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        private List<VwGuiaremisiondetimpcpventadet> VwGuiaremisiondetimpcpventadetImpList { get; set; }
        public VwSucursal VwSucursalSel { get; set; }
        public CpVentaItem CpVentaItemParameter { get; set; }
        public List<Socionegociocontacto> SocionegociocontactoList { get; set; }
        public List<Socionegociodireccion> SocionegociodireccionList { get; set; }
        public UserAudit UserAudit { get; set; }
        public int IdPacienteARegistrar { get; set; }
        public int? Idprogramacioncitadet { get; set; }
        public CpventaMntFrmClaro(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CpventaFrm formParent) 
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
        public CpventaMntFrmClaro(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CpventaFrm formParent, int idPacienteARegistrar, int? idprogramacioncitadet)
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

            IdPacienteARegistrar = idPacienteARegistrar;
            Idprogramacioncitadet = idprogramacioncitadet;

        }   
        private void CpventaMntFrmClaro_Load(object sender, EventArgs e)
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
            iIdimpuesto.EditValue = SessionApp.EmpresaSel.Idimpuestopordefecto;
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
                const string nombreTipodocMov = "CPVENTA";
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
                    VwCpventaMnt = new VwCpventa();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    CargarSocioNegocioPaciente();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();                    
                    iIdvendedor.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaCaja();
                    EstadoReferenciaNotaCredito();
                    EstadoReferenciaSalidaAlmacen();
                    if (iAnulado.Checked)
                    {
                        HabilitarBotonesMnt(false);
                        CamposSoloLectura(true);
                        gvDetalle.OptionsBehavior.ReadOnly = true;
                    }
                    break;
            }           
        }

        private void EstadoReferenciaSalidaAlmacen()
        {

            if (Service.CpVentaTieneReferenciaSalidaAlmacen(IdEntidadMnt))
            {
                XtraMessageBox.Show("Comprobante de venta tiene referencias en salida de almacén", "Atención",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
                EstadoBuscadorSocioNegocio();
                //EstadoBuscadorEmpresaTransporte(false);

            }
        }

        private void CargarSocioNegocioPaciente()
        {

            if (IdPacienteARegistrar > 0)
            {
                VwSocionegocio vwSocionegocio = Service.GetVwSocionegocio(IdPacienteARegistrar);
                if (vwSocionegocio != null)
                {
                    CargarDatosSocioNegocio(vwSocionegocio);
                }
            }
        }

        private void EstadoReferenciaCaja()
        {
            var idTipoCp = (int) iIdtipocp.EditValue;
            var serieTipoCp = (string) rSeriecpventa.EditValue;
            var numeroTipoCp = (string) rNumerocpventa.EditValue;

            if (Service.CpVentaTieneReferenciaCaja(idTipoCp, serieTipoCp, numeroTipoCp))
            {
                XtraMessageBox.Show("El Comprobante de venta tiene Recibo de Caja", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void EstadoReferenciaNotaCredito()
        {


            if (Service.CpVentaTieneNotacredito(IdEntidadMnt))
            {
                XtraMessageBox.Show("El Comprobante de venta tiene Nota de Credito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {
            //string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPVENTA", UsuarioAutenticado.SucursalSel.Idsucursal);
            //VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "CPVENTA"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();
            
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPVENTA", UsuarioAutenticado.SucursalSel.Idsucursal);
            //VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");

            VwCptooperacionList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "CPVENTA"
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

            iIdvendedor.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdvendedor.Properties.DisplayMember = "Razonsocial";
            iIdvendedor.Properties.ValueMember = "Idempleado";
            iIdvendedor.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            rIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            rIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            rIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = CacheObjects.VwSucursalList;//Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereProyecto = string.Format("idsucursal = '{0}'", UsuarioAutenticado.SucursalSel.Idsucursal);
            //iIdproyecto.Properties.DataSource = Service.GetAllVwProyecto(whereProyecto,"Nombreproyecto");
            //iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            //iIdproyecto.Properties.ValueMember = "Idproyecto";
            //iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipolista.Properties.DataSource = CacheObjects.TipolistaList; //Service.GetAllTipolista();
            rIdtipolista.Properties.DisplayMember = "Nombretipolista";
            rIdtipolista.Properties.ValueMember = "Idtipolista";
            rIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            iIdperiodo.Properties.DataSource = CacheObjects.VwPeriodoList; //Service.GetAllVwPeriodo("periodo");
            iIdperiodo.Properties.DisplayMember = "Periodo";
            iIdperiodo.Properties.ValueMember = "Idperiodo";
            iIdperiodo.Properties.BestFitMode = BestFitMode.BestFit;
           
        }
        private void TraerDatos()
        {
            try
            {

                VwCpventaMnt = Service.GetVwCpventa(IdEntidadMnt);      
          
                rIdsucursal.EditValue = VwCpventaMnt.Idsucursal;
                iIdtipocp.EditValue = VwCpventaMnt.Idtipocp;
                iIdcptooperacion.EditValue = VwCpventaMnt.Idcptooperacion;
                rSeriecpventa.EditValue = VwCpventaMnt.Seriecpventa;
                rNumerocpventa.EditValue = VwCpventaMnt.Numerocpventa;

                iIdcliente.EditValue = VwCpventaMnt.Idcliente;
                beSocioNegocio.EditValue = VwCpventaMnt.Razonsocialcliente;
                CargarReferenciasCliente(VwCpventaMnt.Idcliente);

                iFechaemision.EditValue = VwCpventaMnt.Fechaemision;
                iIdperiodo.EditValue = VwCpventaMnt.Idperiodo;
                iFechavencimiento.EditValue = VwCpventaMnt.Fechavencimiento;
                iAnulado.EditValue = VwCpventaMnt.Anulado;
                iFechaanulado.EditValue = VwCpventaMnt.Fechaanulado;
                iIdvendedor.EditValue = VwCpventaMnt.Idvendedor;
                rIdtipocondicion.EditValue = VwCpventaMnt.Idtipocondicion;
                iTipocambio.EditValue = VwCpventaMnt.Tipocambio;
                iIdtipomoneda.EditValue = VwCpventaMnt.Idtipomoneda;
                rTotalbruto.EditValue = VwCpventaMnt.Totalbruto;
                rTotalgravado.EditValue = VwCpventaMnt.Totalgravado;
                rTotalinafecto.EditValue = VwCpventaMnt.Totalinafecto;
                rtotalexonerado.EditValue = VwCpventaMnt.Totalexonerado;
                rTotalimpuesto.EditValue = VwCpventaMnt.Totalimpuesto;
                rImportetotal.EditValue = VwCpventaMnt.Importetotal;
                rPorcentajepercepcion.EditValue = VwCpventaMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = VwCpventaMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = VwCpventaMnt.Totaldocumento;
                iGlosacpventa.EditValue = VwCpventaMnt.Glosacpventa;
                iIdimpuesto.EditValue = VwCpventaMnt.Idimpuesto;
                rIncluyeimpuestoitems.EditValue = VwCpventaMnt.Incluyeimpuestoitems;
                rIdtipolista.EditValue = VwCpventaMnt.Idtipolista;
                iIddireccionfacturacion.EditValue = VwCpventaMnt.Iddireccionfacturacion;

                iListadoordenventaref.EditValue = VwCpventaMnt.Listadoordenventaref;
                iListadoguiaremref.EditValue = VwCpventaMnt.Listadoguiaremref;

                UserAudit.Createdby = VwCpventaMnt.Createdby;
                UserAudit.Creationdate = VwCpventaMnt.Creationdate;
                UserAudit.Modifiedby = VwCpventaMnt.Modifiedby;
                UserAudit.Lastmodified = VwCpventaMnt.Lastmodified;

                iHoratransaccion.EditValue = VwCpventaMnt.Horatransaccion;

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
            //gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            //string where = string.Format("idcpventa = '{0}'", IdEntidadMnt);
            //gcDetalle.BeginUpdate();
            //VwCpventadetList = Service.GetAllVwCpventadet(where, "numeroitem");
            //gcDetalle.DataSource = VwCpventadetList;            
            //SumarTotales();            
            //gcDetalle.EndUpdate();

            Cursor = Cursors.WaitCursor;
            gcDetalle.BeginUpdate();
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idcpventa = '{0}'", IdEntidadMnt);

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwCpventadetList = new List<VwCpventadet>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwCpventadetList = Service.GetAllVwCpventadet(where, "numeroitem");
                    break;
            }

            gcDetalle.DataSource = VwCpventadetList;
            SumarTotales();
            gcDetalle.EndUpdate();
            Cursor = Cursors.Default;

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            Cpventa cpventaMnt = new Cpventa();
            cpventaMnt.Idcpventa = (int)pkIdEntidad.EditValue;
            cpventaMnt.Idsucursal = (int?)rIdsucursal.EditValue;
            cpventaMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            cpventaMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            cpventaMnt.Seriecpventa = rSeriecpventa.Text.Trim();
            cpventaMnt.Numerocpventa = rNumerocpventa.Text.Trim();
            cpventaMnt.Idcliente = (int)iIdcliente.EditValue;

            cpventaMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            cpventaMnt.Idperiodo = (int?)iIdperiodo.EditValue;
            cpventaMnt.Fechavencimiento = (DateTime)iFechavencimiento.EditValue;
            cpventaMnt.Anulado = (bool)iAnulado.EditValue;
            cpventaMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            cpventaMnt.Idvendedor = (int?)iIdvendedor.EditValue;
            cpventaMnt.Idtipocondicion = (int?)rIdtipocondicion.EditValue;
            cpventaMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            cpventaMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;

            cpventaMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            cpventaMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            cpventaMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            cpventaMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            cpventaMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            cpventaMnt.Importetotal = (decimal)rImportetotal.EditValue;
            cpventaMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            cpventaMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            cpventaMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            cpventaMnt.Glosacpventa = iGlosacpventa.Text.Trim();
            cpventaMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;
            cpventaMnt.Incluyeimpuestoitems = (bool)rIncluyeimpuestoitems.EditValue;
            cpventaMnt.Idtipolista = (int) rIdtipolista.EditValue;
            cpventaMnt.Iddireccionfacturacion = (int)iIddireccionfacturacion.EditValue;

            cpventaMnt.Listadoordenventaref = iListadoordenventaref.Text.Trim();
            cpventaMnt.Listadoguiaremref = iListadoguiaremref.Text.Trim();

            //Guardar la programacion de cita
            cpventaMnt.Idprogramacioncitadet = Idprogramacioncitadet;

            cpventaMnt.Horatransaccion = (DateTime) iHoratransaccion.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    cpventaMnt.Createdby = IdUsuario;
                    cpventaMnt.Creationdate = DateTime.Now;
                    cpventaMnt.Modifiedby = UserAudit.Modifiedby;
                    cpventaMnt.Lastmodified = UserAudit.Lastmodified;

                    break;
                case TipoMantenimiento.Modificar:
                    cpventaMnt.Createdby = UserAudit.Createdby;
                    cpventaMnt.Creationdate = UserAudit.Creationdate;
                    cpventaMnt.Modifiedby = IdUsuario;
                    cpventaMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                    if (Service.GuardarCpVenta(TipoMnt, cpventaMnt, VwCpventadetList, VwGuiaremisiondetimpcpventadetImpList))
                    {
                        IdEntidadMnt = cpventaMnt.Idcpventa;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarCpVenta(TipoMnt, cpventaMnt, VwCpventadetList, VwGuiaremisiondetimpcpventadetImpList);
                    break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriecpventa.Text.Trim(),rNumerocpventa.Text.Trim());
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
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdvendedor.EditValue;
            const string nombreTipodocMov = "CPVENTA";
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

            var itemsCantidadInvalida = VwCpventadetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwCpventadetList.Where(x => x.Preciounitario <= 0);
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
            string numeroSerie = rSeriecpventa.Text.Trim();
            string numeroViaje = rNumerocpventa.Text.Trim();

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

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio(x => x.Idsocionegocio == (int)iIdcliente.EditValue);

            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();

                    TipoMnt =TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    VwCpventaMnt = null;
                    VwCpventaMnt = new VwCpventa();

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
                        VwCpventaMnt = null;
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
                        //ImpresionFormato.FormatoCpVenta(VwCpventaMnt);
                    }
                    break;
                case "btnOrdenventa":
                    if (ValidarDatosImportacion()) return;
                    CpventaImpOrdenventaFrm cpventaImpOrdenventaFrm = new CpventaImpOrdenventaFrm(VwCpventadetList, vwSocionegocioSel);
                    cpventaImpOrdenventaFrm.ShowDialog();

                    if (cpventaImpOrdenventaFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdendeventa vwOrdendeventaSelImp = cpventaImpOrdenventaFrm.VwOrdendeventaSel;
                        if (vwOrdendeventaSelImp != null)
                        {
                            iIdcliente.EditValue = vwOrdendeventaSelImp.Idcliente;
                            iIdtipomoneda.EditValue = vwOrdendeventaSelImp.Idtipomoneda;
                            rIdtipocondicion.EditValue = vwOrdendeventaSelImp.Idtipocondicion;
                            rIncluyeimpuestoitems.EditValue = vwOrdendeventaSelImp.Incluyeimpuestoitems;

                        }
                        foreach (var item in VwCpventadetList.Where(x=>x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();


                        iIdcliente.Enabled = false;
                    }
                    break;
                case "btnGuiaDeRemision":
                    if (ValidarDatosImportacion()) return;

                    CpVentaImpGuiaRemisionFrm cpVentaImpGuiaRemisionFrm = new CpVentaImpGuiaRemisionFrm(VwCpventadetList, vwSocionegocioSel);
                    cpVentaImpGuiaRemisionFrm.ShowDialog();
                    if (cpVentaImpGuiaRemisionFrm.DialogResult == DialogResult.OK
                        && cpVentaImpGuiaRemisionFrm.VwSocionegocioSel != null
                        && cpVentaImpGuiaRemisionFrm.VwGuiaremisiondetimpcpventadetList != null)
                    {

                        CargarDatosSocioNegocio(cpVentaImpGuiaRemisionFrm.VwSocionegocioSel);
                        VwGuiaremisiondetimpcpventadetImpList =cpVentaImpGuiaRemisionFrm.VwGuiaremisiondetimpcpventadetList;
                        foreach (var item in VwCpventadetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();
                        ListarDocumentosReferencia();
                        EstadoMenuImportacion();
                        DeshabilitarEdicionImpGuiaRemision();
                    }
                    break;
                case "btnValorizacion":
                    if (ValidarDatosImportacion()) return;
                    CpventaImpValorizacionFrm cpventaImpValorizacionFrm = new CpventaImpValorizacionFrm(VwCpventadetList, vwSocionegocioSel);
                    cpventaImpValorizacionFrm.ShowDialog();

                    if (cpventaImpValorizacionFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizacion vwValorizacionSelImp = cpventaImpValorizacionFrm.VwValorizacionSel;
                        if (vwValorizacionSelImp != null)
                        {
                            rIncluyeimpuestoitems.Checked = false;
                            rIncluyeimpuestoitems.Enabled = false;
                            iIdcliente.EditValue = vwValorizacionSelImp.Idsocionegocio;
                            iIdtipomoneda.EditValue = vwValorizacionSelImp.Idtipomoneda;
                           // iIdtipocondicion.EditValue = vwValorizacionSelImp.Idtipocondicion;

                        }
                        foreach (var item in VwCpventadetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();


                        iIdcliente.Enabled = false;
                    }
                    break;
            }
        }
        private void DeshabilitarEdicionImpGuiaRemision()
        {
            btnAddItem.Enabled = false;
            btnEditItem.Enabled = false;
            btnDelItem.Enabled = false;
            gvDetalle.OptionsBehavior.ReadOnly = true;
            btnImportar.Enabled = false;
        }
        private void EstadoMenuImportacion()
        {
            if (iListadoguiaremref.Text.Trim().Length > 0)
            {
                btnGuiaDeRemision.Enabled = false;
                btnOrdenventa.Enabled = false;
                gcNumeroOrden.Visible = false;
            }

            if (iListadoordenventaref.Text.Trim().Length > 0)
            {
                btnGuiaDeRemision.Enabled = false;
                btnOrdenventa.Enabled = true;
                gcNumeroOrden.Visible = true;
            }

            if (iListadoguiaremref.Text.Trim().Length == 0 && iListadoordenventaref.Text.Trim().Length == 0)
            {
                btnGuiaDeRemision.Enabled = true;
                btnOrdenventa.Enabled = true;
                gcNumeroOrden.Visible = false;
            }


        }
        private void EstadoBuscadorSocioNegocio()
        {
            bool estado = gvDetalle.RowCount == 0;
            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = estado;
            }
        }
        private void ListarDocumentosReferencia()
        {
            ListarGuiasDeRemisionReferencia();
            ListarOrdenesDeVentaReferencia();
        }
        private void ListarOrdenesDeVentaReferencia()
        {
            //List<string> listadoNumeroOrdenes = new List<string>();
            //List<string> serieNumeroOrdenList = VwGuiaremisiondetList
            //    .Where(
            //    x => x.DataEntityState != DataEntityState.Deleted
            //    && !string.IsNullOrEmpty(x.Serienumeroordenventa))
            //    .Select(p => p.Serienumeroordenventa).Distinct().ToList();

            //if (serieNumeroOrdenList.Count > 0)
            //{
            //    foreach (string serieNumeroOrden in serieNumeroOrdenList)
            //    {
            //        string[] splitSerieNumerioOrden = serieNumeroOrden.Split('-');
            //        if (splitSerieNumerioOrden.Count() == 2)
            //        {
            //            string numeroOvRef = string.Format("{0}-{1}"
            //                , Convert.ToInt32(splitSerieNumerioOrden[0])
            //                , Convert.ToInt32(splitSerieNumerioOrden[1]));
            //            listadoNumeroOrdenes.Add(numeroOvRef);
            //        }
            //    }
            //    string listadoOrdenVenta = listadoNumeroOrdenes.Aggregate(String.Empty,
            //        (current, numeroOrden) => current + numeroOrden + ",");
            //    iListadoordenventaref.Text = listadoOrdenVenta.Trim().Length == 0
            //        ? string.Empty
            //        : listadoOrdenVenta.Substring(0, listadoOrdenVenta.Length - 1);
            //}
            //else
            //{
            //    iListadoordenventaref.Text = string.Empty;
            //}
        }
        private void ListarGuiasDeRemisionReferencia()
        {
            //List<string> listadoNumeroGuiRem = new List<string>();

            //List<string> serieNumeroGuiRemList = VwGuiaremisiondetimpcpventadetImpList.Where(x=>x.Itemseleccionado && x.DataEntityState != DataEntityState.Deleted)
            //    .Where(
            //    x => x.DataEntityState != DataEntityState.Deleted
            //    && !string.IsNullOrEmpty(x.Serienumeroguiaremision))
            //    .Select(p => p.Serienumeroguiaremision).Distinct().ToList();

            //if (serieNumeroGuiRemList.Count > 0)
            //{
            //    foreach (string serieNumeroGuiRem in serieNumeroGuiRemList)
            //    {
            //        string[] splitSerieNumeroGuiRem = serieNumeroGuiRem.Split('-');
            //        if (splitSerieNumeroGuiRem.Count() == 2)
            //        {
            //            string numeroOvRef = string.Format("{0}-{1}"
            //                , Convert.ToInt32(splitSerieNumeroGuiRem[0])
            //                , Convert.ToInt32(splitSerieNumeroGuiRem[1]));
            //            listadoNumeroGuiRem.Add(numeroOvRef);
            //        }
            //    }
            //    string listadoGuiRem = listadoNumeroGuiRem.Aggregate(String.Empty,
            //        (current, numeroGuiRem) => current + numeroGuiRem + ",");
            //    iListadoguiaremref.Text = listadoGuiRem.Trim().Length == 0
            //        ? string.Empty
            //        : listadoGuiRem.Substring(0, listadoGuiRem.Length - 1);
            //}
            //else
            //{
            //    iListadoguiaremref.Text = string.Empty;
            //}
        }
        private bool ValidarDatosImportacion()
        {
            var idClienteSel = iIdcliente.EditValue;
            if (idClienteSel == null)
            {
                XtraMessageBox.Show("Seleccione el Cliente.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                iIdcliente.Select();
                return true;
            }
            return false;
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
        private void CpventaMntFrmClaro_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CpventaMntFrmClaro_FormClosing(object sender, FormClosingEventArgs e)
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
        private bool ValidacionItems()
        {
          
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCpVenta, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCpVenta;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidacionItems())
            {
                return;
            }

            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            CpventaMntItemFrmClaro cpventaMntItemFrmclaro;
            VwCpventadet vwCpventadetMntItem;


            if (CpVentaItemParameter == null)
            {
                CpVentaItemParameter = new CpVentaItem();
            }


            if (VwSucursalSel == null)
            {
                VwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)rIdsucursal.EditValue);
            }

            if (VwSucursalSel != null)
            {
                CpVentaItemParameter.IdSucursalConsulta = VwSucursalSel.Idsucursal;
                CpVentaItemParameter.IdAlmacenConsulta = VwSucursalSel.Idalmacendefecto;
            }

            CpVentaItemParameter.IdTipoListaConsulta = (int)rIdtipolista.EditValue;
            CpVentaItemParameter.IdTipoMonedaConsulta = (int)iIdtipomoneda.EditValue;
            CpVentaItemParameter.IdTipoCondicion = (int)rIdtipocondicion.EditValue;
            CpVentaItemParameter.IdCliente = (int)iIdcliente.EditValue;
            CpVentaItemParameter.Incluyeimpuestoitems = (bool) rIncluyeimpuestoitems.EditValue;
            Impuesto impuesto = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int) iIdimpuesto.EditValue);
            CpVentaItemParameter.Porcentajeimpuesto = impuesto == null ?  0.00m : impuesto.Porcentajeimpuesto ;

            if (gvDetalle.RowCount == 0)
            {
                VwEmpleado vwEmpleadoSel = CacheObjects.VwEmpleadoList.FirstOrDefault(x => x.Idempleado == (int)iIdvendedor.EditValue);
                VwSocionegocioproyecto vwSocionegocioproyectoDefecto = CacheObjects.VwSocionegocioproyectoList.FirstOrDefault(x => x.Idsocionegocio == (int)iIdcliente.EditValue && x.Proyectopordefecto);
                if (vwEmpleadoSel != null && vwSocionegocioproyectoDefecto != null)
                {
                    CpVentaItemParameter.IdAreaEmpleado = vwEmpleadoSel.Idarea;
                    CpVentaItemParameter.IdProyectoCliente = vwSocionegocioproyectoDefecto.Idproyecto;
                    CpVentaItemParameter.IdCentroBeneficio = SessionApp.SucursalSel.Idcentrobeneficioventadefecto;
                }
            }

     
            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (!ValidarCantidadMaximaDeItems()) return;

                    //Asignar el siguiente item
                    vwCpventadetMntItem = new VwCpventadet();

                    //Asignar el siguiente item
                    VwCpventadet sgtItem = VwCpventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwCpventadetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    cpventaMntItemFrmclaro = new CpventaMntItemFrmClaro(tipoMantenimientoItem, vwCpventadetMntItem, VwCpventadetList, CpVentaItemParameter);
                    cpventaMntItemFrmclaro.ShowDialog();

                    if (cpventaMntItemFrmclaro.DialogResult == DialogResult.OK)
                    {
                        VwCpventadetList.Add(vwCpventadetMntItem);

                        //Agregar items de detalle compuesto
                        if (cpventaMntItemFrmclaro.VwCpventadetdetComponenteList != null && cpventaMntItemFrmclaro.VwCpventadetdetComponenteList .Count > 0)
                        {
                            foreach (var itemDetCompuesto in cpventaMntItemFrmclaro.VwCpventadetdetComponenteList)
                            {
                                VwCpventadetList.Add(itemDetCompuesto);
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

                    
                    vwCpventadetMntItem = (VwCpventadet)gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    cpventaMntItemFrmclaro = new CpventaMntItemFrmClaro(tipoMantenimientoItem, vwCpventadetMntItem, VwCpventadetList, CpVentaItemParameter);
                    cpventaMntItemFrmclaro.ShowDialog();
                    if (cpventaMntItemFrmclaro.DialogResult == DialogResult.OK)
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

                        vwCpventadetMntItem = (VwCpventadet)gvDetalle.GetFocusedRow();
                        vwCpventadetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }
                        ListarDocumentosReferencia();
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

                    vwCpventadetMntItem = (VwCpventadet)gvDetalle.GetFocusedRow();
                    CpVentaDetSerieMntFrm cpVentaDetSerieMntFrm = new CpVentaDetSerieMntFrm(TipoMantenimiento.Modificar, vwCpventadetMntItem, string.Empty);
                    cpVentaDetSerieMntFrm.ShowDialog();

                    break;
            }
            
        }
        private bool ValidarCantidadMaximaDeItems()
        {
            if (gvDetalle.RowCount >= VwTipocpSel.Maxnumeroitems)
            {
                XtraMessageBox.Show(string.Format("Exedio el número de maximo de items ({0})",VwTipocpSel.Maxnumeroitems), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();


            var totalbruto = VwCpventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalgravado = VwCpventadetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rTotalgravado.EditValue = totalgravado;

            var totalinafecto = VwCpventadetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rTotalinafecto.EditValue = totalinafecto;

            var totalexonerado = VwCpventadetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem && !w.Bonificacion).Sum(s => s.Importetotal);
            rtotalexonerado.EditValue = totalexonerado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null)
            {
                var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);
                //
              
                //Calculo percepcion
                decimal totalValorPercepcion = VwCpventadetList.Where(
                    w=>w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));
             
                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                //
                rImportetotalpercepcion.EditValue = decimal.Round(rIncluyeimpuestoitems.Checked ? totalValorPercepcion : totalValorPercepcion * factorImpuesto, 2);
                rTotalgravado.EditValue = decimal.Round(rIncluyeimpuestoitems.Checked ? totalgravado / factorImpuesto : totalgravado, 2);
                rTotalinafecto.EditValue = decimal.Round(rIncluyeimpuestoitems.Checked ? totalinafecto / factorImpuesto : totalinafecto, 2);
                rtotalexonerado.EditValue = decimal.Round(rIncluyeimpuestoitems.Checked ? totalexonerado / factorImpuesto : totalexonerado, 2);

                rTotalimpuesto.EditValue = decimal.Round(rIncluyeimpuestoitems.Checked ? totalgravado - (decimal)rTotalgravado.EditValue : totalgravado * porcentajeImpuesto / 100, 2);
                rImportetotal.EditValue = (decimal)rTotalgravado.EditValue + (decimal)rTotalinafecto.EditValue + (decimal)rtotalexonerado.EditValue +(decimal)rTotalimpuesto.EditValue;
                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rImportetotalpercepcion.EditValue;


            }

            gvDetalle.EndDataUpdate();

            gvDetalle.BestFitColumns(true);

            //Validaciones de referencias de documentos
            EstadoBuscadorSocioNegocio();
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
                VwTipocpSel = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriecpventa.EditValue = vwTipocp.Seriecp;
                        rNumerocpventa.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocpventa.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocpventa.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerocpventa.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocpventa.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocpventa.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriecpventa.EditValue = @"0000";
                rNumerocpventa.EditValue = 0;
            }
        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpventadet item = (VwCpventadet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idcpventadet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
        private void CalculaItem1(VwCpventadet item)
        {
            //VwOrdendeventadet item = (VwOrdendeventadet)gvDetalle.GetFocusedRow();

            decimal precioUnitarioNeto = item.Preciounitario * (1 - item.Descuento1 / 100) * (1 - item.Descuento2 / 100) *
                                      (1 - item.Descuento3 / 100) * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwCpventadet item)
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
            btnSeries.Enabled = !enabled;

            BarMntItems.EndUpdate();

        }

        private void ObtenerTipoDeCambioVentaSunat()
        {
            DateTime fechaEmision = (DateTime)iFechaemision.EditValue;
            Tipocambio tipocambio = Service.GetTipocambio(x => x.Fechatipocambio == fechaEmision);
            if (tipocambio != null)
            {
                iTipocambio.EditValue = tipocambio.Valorcomprasunat;
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

            //VwSocionegocioSel = Service.GetVwSocionegocio(idSocioNegocio);

            //if (VwSocionegocioSel != null)
            //{
            //    beSocioNegocio.Text = VwSocionegocioSel.Razonsocial.Trim();
            //    iIdcliente.EditValue = VwSocionegocioSel.Idsocionegocio;
            //    rIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
            //    rIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
            //    rIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
            //    iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
            //    CargarDirecciones();
            //}
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

        private void CargarReferenciasCliente(int idSocioNegocio)
        {

            CargarDireccionesCliente(idSocioNegocio);
            CargarContactosCliente(idSocioNegocio);
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                int idDireccionPrincipal = Service.GetIdDireccionPrincipal(idSocioNegocio);
                if (idDireccionPrincipal > 0)
                {
                    iIddireccionfacturacion.EditValue = idDireccionPrincipal;
                    //iIddireccionentrega.EditValue = idDireccionPrincipal;
                }
            }
        }

        private void CargarContactosCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociocontactoList = Service.GetAllSocionegociocontacto(whereSocioNegocio, "Nombrecontacto");
            //iPersonacontacto.Properties.DataSource = SocionegociocontactoList;
            //iPersonacontacto.Properties.DisplayMember = "Nombrecontacto";
            //iPersonacontacto.Properties.ValueMember = "Idsocionegociocontacto";
            //iPersonacontacto.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void CargarDireccionesCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociodireccionList = Service.GetAllSocionegociodireccion(whereSocioNegocio, "Direccionsocionegocio");

            iIddireccionfacturacion.Properties.DataSource = SocionegociodireccionList;
            iIddireccionfacturacion.Properties.DisplayMember = "Direccionsocionegocio";
            iIddireccionfacturacion.Properties.ValueMember = "Idsocionegociodireccion";
            iIddireccionfacturacion.Properties.BestFitMode = BestFitMode.BestFit;

            //iIddireccionentrega.Properties.DataSource = SocionegociodireccionList;
            //iIddireccionentrega.Properties.DisplayMember = "Direccionsocionegocio";
            //iIddireccionentrega.Properties.ValueMember = "Idsocionegociodireccion";
            //iIddireccionentrega.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void iFechaemision_EditValueChanged(object sender, EventArgs e)
        {
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                ObtenerTipoDeCambioVentaSunat();
            }
        }
    }

  
}