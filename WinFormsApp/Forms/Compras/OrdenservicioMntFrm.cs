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
    public partial class OrdenservicioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public OrdenservicioFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Ordenservicio OrdenservicioMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwOrdenserviciodet> VwOrdenserviciodetList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public OrdenservicioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, OrdenservicioFrm formParent) 
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
        private void OrdenservicioMntFrm_Load(object sender, EventArgs e)
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

            iFechaordencompra.EditValue = SessionApp.DateServer;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
            iIdempleado.Enabled = false;

            iFechaordencompra.EditValue = SessionApp.DateServer;

            iIdprioridad.EditValue = 3; //Muy urgente

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "ORDENSERVICIO";
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
                    OrdenservicioMnt = new Ordenservicio();                    
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaCpCompra();
                    EstadoRegistroOrden();
                    break;
            }           
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
        private void EstadoReferenciaCpCompra()
        {
            if (Service.OrdenServicioTieneReferenciaCpCompra(IdEntidadMnt))
            {
                XtraMessageBox.Show("La orden de servicio tiene referencias en comprobante de compra", "Atención",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENSERVICIO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENSERVICIO", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoEmpresaTransporte = string.Format("idtiposocio = '{0}'", "2");
            iIdEmpresatransporte.Properties.DataSource = Service.GetAllVwSocionegocio(whereTipoEmpresaTransporte, "razonsocial");
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

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
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

            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursalentrega.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
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

                OrdenservicioMnt = Service.GetOrdenservicio(IdEntidadMnt);

                iIdtipocp.EditValue = OrdenservicioMnt.Idtipocp;
			    iIdcptooperacion.EditValue = OrdenservicioMnt.Idcptooperacion;
			    rSerieorden.EditValue = OrdenservicioMnt.Serieorden;
			    rNumeroorden.EditValue = OrdenservicioMnt.Numeroorden;
			    iFechaordencompra.EditValue = OrdenservicioMnt.Fechaordenservicio;
			    iAnulado.EditValue = OrdenservicioMnt.Anulado;
			    iFechaanulado.EditValue = OrdenservicioMnt.Fechaanulado;
			    iIdempleado.EditValue = OrdenservicioMnt.Idempleado;                
			    iIdproveedor.EditValue = OrdenservicioMnt.Idproveedor;
                CargarDatosSocioNegocio(OrdenservicioMnt.Idproveedor);
                iPersonacontacto.EditValue = OrdenservicioMnt.Idproveedor;

                rTotalbruto.EditValue = OrdenservicioMnt.Totalbruto;
                rTotalgravado.EditValue = OrdenservicioMnt.Totalgravado;
                rTotalinafecto.EditValue = OrdenservicioMnt.Totalinafecto;
                rtotalexonerado.EditValue = OrdenservicioMnt.Totalexonerado;
                rTotalimpuesto.EditValue = OrdenservicioMnt.Totalimpuesto;
                rImportetotal.EditValue = OrdenservicioMnt.Importetotal;
                rPorcentajepercepcion.EditValue = OrdenservicioMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = OrdenservicioMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = OrdenservicioMnt.Totaldocumento;

			    iIdprioridad.EditValue = OrdenservicioMnt.Idprioridad;
			    iTipocambio.EditValue = OrdenservicioMnt.Tipocambio;
			    iIdtipomoneda.EditValue = OrdenservicioMnt.Idtipomoneda;
			    iIdtipocondicion.EditValue = OrdenservicioMnt.Idtipocondicion;
			    iGlosaordencompra.EditValue = OrdenservicioMnt.Glosaordenservicio;
			    iFechaentrega.EditValue = OrdenservicioMnt.Fechaentrega;
			    iAprobado.EditValue = OrdenservicioMnt.Aprobado;
			    iFechaapobacion.EditValue = OrdenservicioMnt.Fechaapobacion;			    
			    iIdimpuesto.EditValue = OrdenservicioMnt.Idimpuesto;
			    rIdsucursal.EditValue = OrdenservicioMnt.Idsucursal;
                iIncluyeimpuestoitems.EditValue = OrdenservicioMnt.Incluyeimpuestoitems;
                iIdsucursalentrega.EditValue = OrdenservicioMnt.Idsucursalentrega;
                iIdEmpresatransporte.EditValue = OrdenservicioMnt.Idempresatransporte;
                iIdestadopago.EditValue = OrdenservicioMnt.Idestadopago;
                iNropedidoproveedor.EditValue = OrdenservicioMnt.Nropedidoproveedor;
                iPersonacontacto.EditValue = OrdenservicioMnt.Personacontacto;
                iIdtiporegistroorden.EditValue = OrdenservicioMnt.Tiporegistroorden;

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

            string where = string.Format("idordenservicio = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwOrdenserviciodetList = Service.GetAllVwOrdenserviciodet(where, "numeroitem");
            gcDetalle.DataSource = VwOrdenserviciodetList;            
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            OrdenservicioMnt.Idtipocp = (int)iIdtipocp.EditValue;
            OrdenservicioMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            OrdenservicioMnt.Serieorden = rSerieorden.Text.Trim();
            OrdenservicioMnt.Numeroorden = rNumeroorden.Text.Trim();
            OrdenservicioMnt.Fechaordenservicio = (DateTime)iFechaordencompra.EditValue;
            OrdenservicioMnt.Anulado = (bool)iAnulado.EditValue;
            OrdenservicioMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            OrdenservicioMnt.Idempleado = (int)iIdempleado.EditValue;
            OrdenservicioMnt.Idproveedor = (int)iIdproveedor.EditValue;
            OrdenservicioMnt.Idprioridad = (int)iIdprioridad.EditValue;
            OrdenservicioMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            OrdenservicioMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            OrdenservicioMnt.Idtipocondicion = (int)iIdtipocondicion.EditValue;

            OrdenservicioMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            OrdenservicioMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            OrdenservicioMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            OrdenservicioMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            OrdenservicioMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            OrdenservicioMnt.Importetotal = (decimal)rImportetotal.EditValue;
            OrdenservicioMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            OrdenservicioMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            OrdenservicioMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            OrdenservicioMnt.Glosaordenservicio = iGlosaordencompra.Text.Trim();
            OrdenservicioMnt.Fechaentrega = (DateTime?)iFechaentrega.EditValue;
            OrdenservicioMnt.Aprobado = (bool)iAprobado.EditValue;
            OrdenservicioMnt.Fechaapobacion = (DateTime?)iFechaapobacion.EditValue;
            OrdenservicioMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            OrdenservicioMnt.Idsucursal = (int)rIdsucursal.EditValue;
            OrdenservicioMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            OrdenservicioMnt.Idsucursalentrega = (int)iIdsucursalentrega.EditValue;
            OrdenservicioMnt.Idempresatransporte = (int?) iIdEmpresatransporte.EditValue;
            OrdenservicioMnt.Idestadopago = (int)iIdestadopago.EditValue;
            OrdenservicioMnt.Nropedidoproveedor = (string)iNropedidoproveedor.EditValue;
            OrdenservicioMnt.Personacontacto = (int?)iPersonacontacto.EditValue;
            OrdenservicioMnt.Tiporegistroorden = (int) iIdtiporegistroorden.EditValue;
            
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    OrdenservicioMnt.Createdby = IdUsuario;
                    OrdenservicioMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    OrdenservicioMnt.Modifiedby = IdUsuario;
                    OrdenservicioMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                    if (Service.GuardarOrdenDeServicio(TipoMnt,OrdenservicioMnt, VwOrdenserviciodetList))
                    {
                        IdEntidadMnt = OrdenservicioMnt.Idordenservicio;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarOrdenDeServicio(TipoMnt, OrdenservicioMnt, VwOrdenserviciodetList);
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
            const string nombreTipodocMov = "ORDENSERVICIO";
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

            var itemsCantidadInvalida = VwOrdenserviciodetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwOrdenserviciodetList.Where(x => x.Preciounitario <= 0);
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
            string numeroSerie = rSerieorden.Text.Trim();
            string numeroViaje = rNumeroorden.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroOrdenCompraExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
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
                        Service.DeleteOrdencompra(IdEntidadMnt);
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

                    TipoMnt =TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    OrdenservicioMnt = null;
                    OrdenservicioMnt = new Ordenservicio();

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
                        OrdenservicioMnt = null;
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
                        ImpresionFormato.FormatoOrdenDeServicio(OrdenservicioMnt);
                    }
                    break;
                case "btnRequerimiento":

                    OrdenservicioMntImpReqFrm ordenservicioMntImpReqFrm = new OrdenservicioMntImpReqFrm(VwOrdenserviciodetList);
                    ordenservicioMntImpReqFrm.ShowDialog();
                    if (ordenservicioMntImpReqFrm.DialogResult == DialogResult.OK)
                    {

                        VwOrdenserviciodet vwOrdenserviciodet = VwOrdenserviciodetList.LastOrDefault(x=>x.DataEntityState != DataEntityState.Deleted && x.Nombrecptooperacion != null);

                        if (vwOrdenserviciodet != null && vwOrdenserviciodet.Nombrecptooperacion.Substring(0, 6) == "PEDIDO")
                        {
                            iIdprioridad.EditValue = 3;
                        }
                        else
                        {
                            iIdprioridad.EditValue = 1;
                        }
                        VwRequerimiento vwRequerimientoSel = ordenservicioMntImpReqFrm.VwRequerimientoSel;
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
                        foreach (var item in VwOrdenserviciodetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();
                    }


                    break;
                case "btnCuadroComparativo":
                    OrdenservicioMntImpCuadroCcFrm ordenservicioMntImpCuadroCcFrm = new OrdenservicioMntImpCuadroCcFrm(VwOrdenserviciodetList);
                    ordenservicioMntImpCuadroCcFrm.ShowDialog();
                    if (ordenservicioMntImpCuadroCcFrm.DialogResult == DialogResult.OK)
                    {
                        foreach (var item in VwOrdenserviciodetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }
                        SumarTotales();
                        VwOrdenserviciodet vwOrdenserviciodet = VwOrdenserviciodetList.LastOrDefault(x=>x.DataEntityState != DataEntityState.Deleted && x.Nombrecptooperacion != null);

                        if (vwOrdenserviciodet != null && vwOrdenserviciodet.Nombrecptooperacion.Substring(0, 6) == "PEDIDO")
                        {
                            iIdprioridad.EditValue = 3;
                        }
                        else
                        {
                            iIdprioridad.EditValue = 1;
                        }

                        //Asignar datos desde el cuadro comparativo
                        VwCuadrocomparativoprv vwCuadrocomparativoprv = ordenservicioMntImpCuadroCcFrm.VwCuadrocomparativoprv;
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
        private void OrdenservicioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void OrdenservicioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            OrdenservicioMntItemFrm ordenservicioMntItemFrm;
            VwOrdenserviciodet vwOrdenserviciodetMntItem;
            VwOrdenserviciodet itemSel;

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
                    vwOrdenserviciodetMntItem = new VwOrdenserviciodet();

                    //Asignar el siguiente item
                    var sgtItem = VwOrdenserviciodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwOrdenserviciodetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ordenservicioMntItemFrm = new OrdenservicioMntItemFrm(tipoMantenimientoItem, vwOrdenserviciodetMntItem, vwTipocpSel, vwCptooperacionSel);
                    ordenservicioMntItemFrm.ShowDialog();
                  
                    if (ordenservicioMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdenserviciodetList.Add(vwOrdenserviciodetMntItem);
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


                    itemSel = (VwOrdenserviciodet)gvDetalle.GetFocusedRow();
                    if (itemSel.Idordenserviciodet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(itemSel.Idordenserviciodet) > 0)
                    {
                        XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    vwOrdenserviciodetMntItem = (VwOrdenserviciodet) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    ordenservicioMntItemFrm = new OrdenservicioMntItemFrm(tipoMantenimientoItem, vwOrdenserviciodetMntItem, vwTipocpSel, vwCptooperacionSel);
                    ordenservicioMntItemFrm.ShowDialog();
                    if (ordenservicioMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    itemSel = (VwOrdenserviciodet)gvDetalle.GetFocusedRow();
                    if (itemSel.Idordenserviciodet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(itemSel.Idordenserviciodet) > 0)
                    {
                        XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwOrdenserviciodetMntItem = (VwOrdenserviciodet)gvDetalle.GetFocusedRow();
                        vwOrdenserviciodetMntItem.DataEntityState = DataEntityState.Deleted;

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
            decimal totalbruto = VwOrdenserviciodetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            decimal totalgravado = VwOrdenserviciodetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            decimal totalinafecto = VwOrdenserviciodetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            decimal totalexonerado = VwOrdenserviciodetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            if (impuestoSel != null)
            {
                decimal porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto/100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwOrdenserviciodetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Gravado).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

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
            VwOrdenserviciodet item = (VwOrdenserviciodet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idordenserviciodet  <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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

            if (gvDetalle.FocusedColumn.FieldName == "Cantidad" && item.Idordenserviciodet > 0)
            {
                VwOrdenserviciodet vwOrdencompradet = Service.GetVwOrdenserviciodet(x => x.Idordenserviciodet == item.Idordenserviciodet);
                decimal cantidadAnterior = vwOrdencompradet.Cantidad;
                if (item.Idordenserviciodet > 0
                    && Service.CantidadReferenciasItemOrdenCompra(item.Idordenserviciodet) > 0)
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
        private void CalculaItem1(VwOrdenserviciodet item)
        {
            //VwOrdencompradet item = (VwOrdencompradet)gvDetalle.GetFocusedRow();

            decimal precioUnitarioNeto = item.Preciounitario * (1 - item.Descuento1 / 100) * (1 - item.Descuento2 / 100) *
                                      (1 - item.Descuento3 / 100) * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem2(VwOrdenserviciodet item)
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
            if (impuestoSel != null && VwOrdenserviciodetList != null)
            {
                SumarTotales();
            }   
        }
    }    
}