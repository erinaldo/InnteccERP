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
    public partial class OrdencompraMntFrm : XtraForm
    {
        public DataEntityState DataEntityState { get; set; }
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }

        public GridControl GridParent { get; set; }
        public OrdencompraFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Ordencompra OrdencompraMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwOrdencompradet> VwOrdencompradetList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public OrdencompraMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, OrdencompraFrm formParent) 
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
        private void OrdencompraMntFrm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

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

            Cursor = Cursors.Default;
        }
        private void ValoresPorDefecto()
        {

            iFechaordencompra.EditValue = SessionApp.DateServer;

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

            iFechaordencompra.EditValue = SessionApp.DateServer;

            iIdprioridad.EditValue = 3; //Muy urgente

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "ORDENCOMPRA";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

            //Establecer el tipo de registro
            iIdtiporegistroorden.EditValue = 3;  // REGISTRO MANUAL

            //Establecer el estado de pago
            iIdestadopago.EditValue = 2; //Pendiente de pago

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
                    OrdencompraMnt = new Ordencompra();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaEntradaAlmacen();
                    EstadoRegistroOrden();
                    if (iAnulado.Checked)
                    {
                        CamposSoloLectura(true);
                        gvDetalle.OptionsBehavior.ReadOnly = true;
                        HabilitarBotonesMnt(false);
                    }
                    break;
            }
            UseWaitCursor = false;
        }
        private void EstadoRegistroOrden()
        {
            int idtiporegistroorden = (int) iIdtiporegistroorden.EditValue;
            switch (idtiporegistroorden)
            {
                case 1: //Requerimiento
                    btnAddItem.Enabled = false;
                    btnEditItem.Enabled = false;
                    btnDelItem.Enabled = true;
                    btnCuadroComparativo.Enabled = false;
                    break;
                case 2: //Cuadro comparativo
                    btnAddItem.Enabled = false;
                    btnEditItem.Enabled = false;
                    btnDelItem.Enabled = false;
                    bsiImportar.Enabled = false;
                    break;
                case 3: //Registro manual
                    bsiImportar.Enabled = false;
                    break;
            }
        }
        private void EstadoReferenciaEntradaAlmacen()
        {
            if (Service.OrdenCompraTieneReferenciaEntradaAlmacen(IdEntidadMnt))
            {
                XtraMessageBox.Show("La orden de compra tiene referencias en entrada de almacen", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "ORDENCOMPRA"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            VwCptooperacionList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "ORDENCOMPRA"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereTipoEmpresaTransporte = string.Format("idtiposocio = '{0}'", "2");
            //iIdEmpresatransporte.Properties.DataSource = Service.GetAllVwSocionegocio(whereTipoEmpresaTransporte, "razonsocial");
            iIdEmpresatransporte.Properties.DataSource = CacheObjects.VwSocionegocioList.Where(x => x.Idtiposocio == 2).ToList();

            iIdEmpresatransporte.Properties.DisplayMember = "Razonsocial";
            iIdEmpresatransporte.Properties.ValueMember = "Idsocionegocio";
            iIdEmpresatransporte.Properties.BestFitMode = BestFitMode.BestFit;

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

            iIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            iIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            iIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            iIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdprioridad.Properties.DataSource = CacheObjects.PrioridadList;
            iIdprioridad.Properties.DisplayMember = "Nombreprioridad";
            iIdprioridad.Properties.ValueMember = "Idprioridad";
            iIdprioridad.Properties.BestFitMode = BestFitMode.BestFit;

            rIdsucursal.Properties.DataSource = CacheObjects.VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursalentrega.Properties.DataSource = CacheObjects.VwSucursalList;
            iIdsucursalentrega.Properties.DisplayMember = "Nombresucursal";
            iIdsucursalentrega.Properties.ValueMember = "Idsucursal";
            iIdsucursalentrega.Properties.BestFitMode = BestFitMode.BestFit;

            iIdestadopago.Properties.DataSource = CacheObjects.EstadopagoList;
            iIdestadopago.Properties.DisplayMember = "Nombreestadopago";
            iIdestadopago.Properties.ValueMember = "Idestadopago";
            iIdestadopago.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtiporegistroorden.Properties.DataSource = CacheObjects.TiporegistroordenList;
            iIdtiporegistroorden.Properties.DisplayMember = "Nombretiporegistroorden";
            iIdtiporegistroorden.Properties.ValueMember = "Idtiporegistroorden";
            iIdtiporegistroorden.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                OrdencompraMnt = Service.GetOrdencompra(IdEntidadMnt);

                iIdimpuesto.EditValue = OrdencompraMnt.Idimpuesto;
                iIdtipocp.EditValue = OrdencompraMnt.Idtipocp;
			    iIdcptooperacion.EditValue = OrdencompraMnt.Idcptooperacion;
			    rSerieorden.EditValue = OrdencompraMnt.Serieorden;
			    rNumeroorden.EditValue = OrdencompraMnt.Numeroorden;
			    iFechaordencompra.EditValue = OrdencompraMnt.Fechaordencompra;
			    iAnulado.EditValue = OrdencompraMnt.Anulado;
			    iFechaanulado.EditValue = OrdencompraMnt.Fechaanulado;
			    iIdempleado.EditValue = OrdencompraMnt.Idempleado;                
			    iIdproveedor.EditValue = OrdencompraMnt.Idproveedor;

                CargarDatosSocioNegocio(OrdencompraMnt.Idproveedor);

                iPersonacontacto.EditValue = OrdencompraMnt.Idproveedor;

                rTotalbruto.EditValue = OrdencompraMnt.Totalbruto;
                rTotalgravado.EditValue = OrdencompraMnt.Totalgravado;
                rTotalinafecto.EditValue = OrdencompraMnt.Totalinafecto;
                rtotalexonerado.EditValue = OrdencompraMnt.Totalexonerado;
                rTotalimpuesto.EditValue = OrdencompraMnt.Totalimpuesto;
                rImportetotal.EditValue = OrdencompraMnt.Importetotal;
                rPorcentajepercepcion.EditValue = OrdencompraMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = OrdencompraMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = OrdencompraMnt.Totaldocumento;

			    iIdprioridad.EditValue = OrdencompraMnt.Idprioridad;
			    iTipocambio.EditValue = OrdencompraMnt.Tipocambio;
			    iIdtipomoneda.EditValue = OrdencompraMnt.Idtipomoneda;
			    iIdtipocondicion.EditValue = OrdencompraMnt.Idtipocondicion;
			    iGlosaordencompra.EditValue = OrdencompraMnt.Glosaordencompra;
			    iFechaentrega.EditValue = OrdencompraMnt.Fechaentrega;
			    iAprobado.EditValue = OrdencompraMnt.Aprobado;
			    iFechaapobacion.EditValue = OrdencompraMnt.Fechaapobacion;			    
			    
			    rIdsucursal.EditValue = OrdencompraMnt.Idsucursal;
                iIncluyeimpuestoitems.EditValue = OrdencompraMnt.Incluyeimpuestoitems;
                iIdsucursalentrega.EditValue = OrdencompraMnt.Idsucursalentrega;
                iIdEmpresatransporte.EditValue = OrdencompraMnt.Idempresatransporte;
                iIdestadopago.EditValue = OrdencompraMnt.Idestadopago;
                iNropedidoproveedor.EditValue = OrdencompraMnt.Nropedidoproveedor;
                iPersonacontacto.EditValue = OrdencompraMnt.Personacontacto;
                iIdtiporegistroorden.EditValue = OrdencompraMnt.Tiporegistroorden;

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

            string where = string.Format("idordencompra = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwOrdencompradetList = Service.GetAllVwOrdencompradet(where, "numeroitem");
            gcDetalle.DataSource = VwOrdencompradetList;            
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            OrdencompraMnt.Idtipocp = (int)iIdtipocp.EditValue;
            OrdencompraMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            OrdencompraMnt.Serieorden = rSerieorden.Text.Trim();
            OrdencompraMnt.Numeroorden = rNumeroorden.Text.Trim();
            OrdencompraMnt.Fechaordencompra = (DateTime)iFechaordencompra.EditValue;
            OrdencompraMnt.Anulado = (bool)iAnulado.EditValue;
            OrdencompraMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            OrdencompraMnt.Idempleado = (int)iIdempleado.EditValue;
            OrdencompraMnt.Idproveedor = (int)iIdproveedor.EditValue;
            OrdencompraMnt.Idprioridad = (int)iIdprioridad.EditValue;
            OrdencompraMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            OrdencompraMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            OrdencompraMnt.Idtipocondicion = (int)iIdtipocondicion.EditValue;

            OrdencompraMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            OrdencompraMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            OrdencompraMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            OrdencompraMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            OrdencompraMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            OrdencompraMnt.Importetotal = (decimal)rImportetotal.EditValue;
            OrdencompraMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            OrdencompraMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            OrdencompraMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            OrdencompraMnt.Glosaordencompra = iGlosaordencompra.Text.Trim();
            OrdencompraMnt.Fechaentrega = (DateTime?)iFechaentrega.EditValue;
            OrdencompraMnt.Aprobado = (bool)iAprobado.EditValue;
            OrdencompraMnt.Fechaapobacion = (DateTime?)iFechaapobacion.EditValue;
            OrdencompraMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            OrdencompraMnt.Idsucursal = (int)rIdsucursal.EditValue;
            OrdencompraMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            OrdencompraMnt.Idsucursalentrega = (int)iIdsucursalentrega.EditValue;
            OrdencompraMnt.Idempresatransporte = (int?) iIdEmpresatransporte.EditValue;
            OrdencompraMnt.Idestadopago = (int)iIdestadopago.EditValue;
            OrdencompraMnt.Nropedidoproveedor = (string)iNropedidoproveedor.EditValue;
            OrdencompraMnt.Personacontacto = (int?)iPersonacontacto.EditValue;
            OrdencompraMnt.Tiporegistroorden = (int) iIdtiporegistroorden.EditValue;
            
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    OrdencompraMnt.Createdby = IdUsuario;
                    OrdencompraMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    OrdencompraMnt.Modifiedby = IdUsuario;
                    OrdencompraMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                    if (Service.GuardarOrdenDeCompra(TipoMnt,OrdencompraMnt, VwOrdencompradetList))
                    {
                        IdEntidadMnt = OrdencompraMnt.Idordencompra;
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
                    Service.GuardarOrdenDeCompra(TipoMnt, OrdencompraMnt, VwOrdencompradetList);
                    DataEntityState = DataEntityState.Modified;
                    break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerieorden.Text.Trim(),rNumeroorden.Text.Trim());
                Cursor = Cursors.Default;

                if (tcOrdenDeCompra.SelectedTabPage == tpLogistica)
                {
                    tcOrdenDeCompra.SelectedTabPage = tpOrdenCompra;
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
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "ORDENCOMPRA";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpOrdenCompra, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpLogistica, _errorProvider))
            {
                tcOrdenDeCompra.SelectedTabPage = tpLogistica;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }


            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwOrdencompradetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwOrdencompradetList.Where(x => x.Preciounitario <= 0);
            string msgItemPreUni = itemsPrecioUniInvalido.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemPreUni))
            {
                XtraMessageBox.Show("Existe items con precio unitario cero verifique: \n\n" + msgItemPreUni, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }        


            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSerieorden.Text.Trim();
            string numeroViaje = rNumeroorden.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroOrdenCompraExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
            {
                CargarInfoCorrelativo();
                return true;
            }

            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            decimal tipoCambio = (decimal)iTipocambio.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            {
                XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iTipocambio.Select();
                return false;
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
                        DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
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

                    TipoMnt = TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    OrdencompraMnt = null;
                    OrdencompraMnt = new Ordencompra();

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
                    OrdencompraMnt = null;
                    DialogResult = DialogResult.OK;

                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoOrdenDeCompra(OrdencompraMnt);
                    }
                    break;
                case "btnRequerimiento":

                    OrdencompraMntImpReqFrm ordencompraMntImpReqFrm = new OrdencompraMntImpReqFrm(VwOrdencompradetList);
                    ordencompraMntImpReqFrm.ShowDialog();
                    if (ordencompraMntImpReqFrm.DialogResult == DialogResult.OK)
                    {

                        VwOrdencompradet vwOrdencompradet = VwOrdencompradetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted && x.Nombrecptooperacion != null);

                        if (vwOrdencompradet != null && vwOrdencompradet.Nombrecptooperacion.Substring(0, 6) == "PEDIDO")
                        {
                            iIdprioridad.EditValue = 3;
                        }
                        else
                        {
                            iIdprioridad.EditValue = 1;
                        }
                        VwRequerimiento vwRequerimientoSel = ordencompraMntImpReqFrm.VwRequerimientoSel;
                        if (vwRequerimientoSel != null)
                        {
                            iIncluyeimpuestoitems.EditValue = vwRequerimientoSel.Incluyeimpuestoitems;
                            iIdsucursalentrega.EditValue = vwRequerimientoSel.Idsucursal;
                            iIdtipomoneda.EditValue = vwRequerimientoSel.Idtipomoneda;
                            iIncluyeimpuestoitems.EditValue = vwRequerimientoSel.Incluyeimpuestoitems;
                        }

                        //Establecer el tipo de registro de orden
                        iIdtiporegistroorden.EditValue = 1;
                        EstadoRegistroOrden();

                        //Calcular los items y sumar
                        foreach (var item in VwOrdencompradetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();
                    }


                    break;
                case "btnCuadroComparativo":
                    OrdencompraMntImpCuadroCcFrm ordencompraMntImpCuadroCcFrm = new OrdencompraMntImpCuadroCcFrm(VwOrdencompradetList);
                    ordencompraMntImpCuadroCcFrm.ShowDialog();
                    if (ordencompraMntImpCuadroCcFrm.DialogResult == DialogResult.OK)
                    {
                        foreach (var item in VwOrdencompradetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();
                        VwOrdencompradet vwOrdencompradet = VwOrdencompradetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted && x.Nombrecptooperacion != null);

                        if (vwOrdencompradet != null && vwOrdencompradet.Nombrecptooperacion.Substring(0, 6) == "PEDIDO")
                        {
                            iIdprioridad.EditValue = 3;
                        }
                        else
                        {
                            iIdprioridad.EditValue = 1;
                        }

                        //Asignar datos desde el cuadro comparativo
                        VwCuadrocomparativoprv vwCuadrocomparativoprv = ordencompraMntImpCuadroCcFrm.VwCuadrocomparativoprv;
                        if (vwCuadrocomparativoprv != null)
                        {
                            iIdsucursalentrega.EditValue = vwCuadrocomparativoprv.Idsucursal;

                            iIdproveedor.EditValue = vwCuadrocomparativoprv.Idsocionegocio;
                            CargarDatosSocioNegocio(vwCuadrocomparativoprv.Idsocionegocio);

                            //for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
                            //{
                            //    beSocioNegocio.Properties.Buttons[i].Enabled = false;
                            //}
                            beSocioNegocio.Enabled = false;
                            gvDetalle.OptionsBehavior.ReadOnly = true;
                        }

                        //Establecer el tipo de registro de orden
                        iIdtiporegistroorden.EditValue = 2;
                        EstadoRegistroOrden();
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
        private void OrdencompraMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpOrdenCompra, readOnly);
            WinFormUtils.ReadOnlyFields(tpLogistica, readOnly);
        }        
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            OrdencompraMntItemFrm ordencompraMntItemFrm;
            VwOrdencompradet vwOrdencompradetMntItem;
            VwOrdencompradet itemSel;
            VwTipocp vwTipocpSel = null;

            var idTipoCpSel = iIdtipocp.EditValue;
            if (idTipoCpSel != null)
            {
                vwTipocpSel = VwTipocpList.FirstOrDefault(x => x.Idtipocp == (int)idTipoCpSel);
            }

            VwCptooperacion vwCptooperacionSel = null;
            var idCptoOperacionSel = iIdcptooperacion.EditValue;
            if (idCptoOperacionSel != null)
            {
                vwCptooperacionSel = VwCptooperacionList.FirstOrDefault(x => x.Idcptooperacion == (int)idCptoOperacionSel);
            }

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Asignar el siguiente item
                    vwOrdencompradetMntItem = new VwOrdencompradet();

                    //Asignar el siguiente item
                    var sgtItem = VwOrdencompradetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwOrdencompradetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ordencompraMntItemFrm = new OrdencompraMntItemFrm(tipoMantenimientoItem, vwOrdencompradetMntItem, vwTipocpSel, vwCptooperacionSel);
                    ordencompraMntItemFrm.ShowDialog();
                  
                    if (ordencompraMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdencompradetList.Add(vwOrdencompradetMntItem);

                        //Agregar items de detalle compuesto
                        if (ordencompraMntItemFrm.VwOrdencompradetComponenteList != null && ordencompraMntItemFrm.VwOrdencompradetComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in ordencompraMntItemFrm.VwOrdencompradetComponenteList)
                            {
                                VwOrdencompradetList.Add(itemDetCompuesto);
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


                    itemSel = (VwOrdencompradet)gvDetalle.GetFocusedRow();

                    if (!itemSel.Calcularitem)
                    {
                        XtraMessageBox.Show("No se puede modificar un item que pertenece a un artículo compuesto", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (itemSel.Idordencompradet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(itemSel.Idordencompradet) > 0)
                    {
                        XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    vwOrdencompradetMntItem = (VwOrdencompradet) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    ordencompraMntItemFrm = new OrdencompraMntItemFrm(tipoMantenimientoItem, vwOrdencompradetMntItem, vwTipocpSel, vwCptooperacionSel);
                    ordencompraMntItemFrm.ShowDialog();
                    if (ordencompraMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    itemSel = (VwOrdencompradet)gvDetalle.GetFocusedRow();

                    if (!itemSel.Calcularitem)
                    {
                        XtraMessageBox.Show("No se puede eliminar un item que pertenece a un artículo compuesto", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (itemSel.Idordencompradet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(itemSel.Idordencompradet) > 0)
                    {
                        XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwOrdencompradetMntItem = (VwOrdencompradet)gvDetalle.GetFocusedRow();
                        vwOrdencompradetMntItem.DataEntityState = DataEntityState.Deleted;

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
            decimal totalbruto = VwOrdencompradetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwOrdencompradetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwOrdencompradetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalexonerado = VwOrdencompradetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto/100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwOrdencompradetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Gravado 
                    && w.Calcularitem) .Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

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
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                TipoCpMnt = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSerieorden.EditValue = vwTipocp.Seriecp;
                        rNumeroorden.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroorden.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroorden.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroorden.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroorden.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroorden.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieorden.EditValue = @"0000";
                rNumeroorden.EditValue = 0;
            }
        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwOrdencompradet item = (VwOrdencompradet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idordencompradet  <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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

            if (gvDetalle.FocusedColumn.FieldName == "Cantidad" && item.Idordencompradet > 0)
            {
                VwOrdencompradet vwOrdencompradet = Service.GetVwOrdencompradet(x => x.Idordencompradet == item.Idordencompradet);
                decimal cantidadAnterior = vwOrdencompradet.Cantidad;
                if (item.Idordencompradet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(item.Idordencompradet) > 0)
                {
                    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    item.Cantidad = cantidadAnterior;
                    gvDetalle.RefreshRowCell(gvDetalle.FocusedRowHandle, gvDetalle.FocusedColumn);
                    CalculaItem1(item);
                    SumarTotales();
                    //gvDetalle.RefreshRowCell(gvDetalle.FocusedRowHandle, gvDetalle.FocusedColumn);
                }
            }
        }
        private void CalculaItem1(VwOrdencompradet item)
        {
            //VwOrdencompradet item = (VwOrdencompradet)gvDetalle.GetFocusedRow();

            decimal precioUnitarioNeto = item.Preciounitario * (1 - item.Descuento1 / 100) * (1 - item.Descuento2 / 100) *
                                      (1 - item.Descuento3 / 100) * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwOrdencompradet item)
        {
            //VwOrdencompradet item = (VwOrdencompradet)gvDetalle.GetFocusedRow();

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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //VwOrdencompradet vwOrdencompradet = (VwOrdencompradet)gvDetalle.GetFocusedRow();
            //if (vwOrdencompradet != null)
            //{
            //    CpcostoshistorialFrm cpcostoshistorialFrm = new CpcostoshistorialFrm(vwOrdencompradet.Idarticulo);
            //    cpcostoshistorialFrm.ShowDialog();
            //}
        }
        private void ObtenerTipoDeCambioVentaSunat()
        {
            DateTime fechaEmision = (DateTime)iFechaordencompra.EditValue;
            Tipocambio tipocambio = Service.GetTipocambio(x=>x.Fechatipocambio == fechaEmision);
            iTipocambio.EditValue = tipocambio != null ? tipocambio.Valorventasunat : 0m;
            
        }
        private void CargarEntradasAlmacenReferencia()
        {
            UseWaitCursor = true;
            gcEntradas.BeginUpdate();
            string condicion = string.Format(@"identradaalmacen IN (
                              select distinct b.identradaalmacen
                              from almacen.entradaalmacendet b
                                   LEFT JOIN compras.ordencompradet c ON
                                     b.idordencompradet = c.idordencompradet
                                   LEFT Join compras.ordencompra d ON
                                     c.idordencompra = c.idordencompra
                              where c.idordencompra = {0})", IdEntidadMnt);
            const string orden = "nombresucursal,nombretipoformato,serienumeroentrada";
            gcEntradas.DataSource = Service.GetAllVwEntradaalmacen(condicion,orden);
            gcEntradas.EndUpdate();
            gvEntradas.BestFitColumns(true);
            UseWaitCursor = false;
        }
        private void btnConsultarReferencias_Click(object sender, EventArgs e)
        {
            CargarEntradasAlmacenReferencia();
        }
        private void gvEntradas_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            VwEntradaalmacen vwEntradaalmacenSel = (VwEntradaalmacen)gvEntradas.GetFocusedRow();

            if (vwEntradaalmacenSel != null)
            {
                string where = string.Format("idEntradaalmacen = '{0}'", vwEntradaalmacenSel.Identradaalmacen);
                gcEntradasDet.BeginUpdate();
                gcEntradasDet.DataSource = Service.GetAllVwEntradaalmacendet(where, "numeroitem");
                gcEntradasDet.EndUpdate();
                gvEntradasDet.BestFitColumns(); 
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
                CargarContactosSocioNegocio();
            }
        }
        private void CargarContactosSocioNegocio()
        {
            if (VwSocionegocioSel != null)
            {
                string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", VwSocionegocioSel.Idsocionegocio);
                iPersonacontacto.Properties.DataSource = Service.GetAllSocionegociocontacto(whereSocioNegocio,"Nombrecontacto");
                iPersonacontacto.Properties.DisplayMember = "Nombrecontacto";
                iPersonacontacto.Properties.ValueMember = "Idsocionegociocontacto";
                iPersonacontacto.Properties.BestFitMode = BestFitMode.BestFit;
            }
        }
        private void iIncluyeimpuestoitems_EditValueChanged(object sender, EventArgs e)
        {
            //Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            //if (impuestoSel != null && VwOrdencompradetList != null)
            //{
            //    foreach (var item in VwOrdencompradetList)
            //    {
            //        item.Preciounitario = iIncluyeimpuestoitems.Checked
            //            ? Decimal.Round(item.Preciounitario * (1 + impuestoSel.Porcentajeimpuesto / 100), 4, MidpointRounding.AwayFromZero)
            //            : Decimal.Round(item.Preciounitario / (1 + impuestoSel.Porcentajeimpuesto / 100), 4, MidpointRounding.AwayFromZero);
            //        CalculaItem1(item);
            //    }
            //    SumarTotales();
            //}

         
        }
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null && VwOrdencompradetList != null)
            {
                SumarTotales();
            }   
        }
        private void iFechaordencompra_EditValueChanged(object sender, EventArgs e)
        {           
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                ObtenerTipoDeCambioVentaSunat();
            }
        }
    }    
}