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
    public partial class NotacreditoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public NotacreditoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Notacredito NotacreditoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        //Detalle
        public List<VwNotacreditodet> VwNotacreditodetList { get; set; }
        public NotacreditoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, NotacreditoFrm formParent) 
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
        private void NotacreditoMntFrm_Load(object sender, EventArgs e)
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

            iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
            //iIdempleado.Enabled = false;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "NC-PROVEEDOR";
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
                    NotacreditoMnt = new Notacredito();                    
                    CargarDetalle();
                    iIdtipocp.Select();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();

                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();

                    break;
            }           
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "NC-PROVEEDOR", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "NC-PROVEEDOR", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereTipoSocio = string.Format("idtiposocio = '{0}'", "2");
            //VwSocionegocioList = Service.GetAllVwSocionegocio(whereTipoSocio, "razonsocial");
            //iIdproveedor.Properties.DataSource = VwSocionegocioList;
            //iIdproveedor.Properties.DisplayMember = "Razonsocial";
            //iIdproveedor.Properties.ValueMember = "Idsocionegocio";
            //iIdproveedor.Properties.BestFitMode = BestFitMode.BestFit;


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

            string wherePeriodo = string.Format("anioejercicio = '{0}'", SessionApp.EjercicioActual);
            iIdperiodo.Properties.DataSource = Service.GetAllVwPeriodo(wherePeriodo,"periodo");
            iIdperiodo.Properties.DisplayMember = "Periodo";
            iIdperiodo.Properties.ValueMember = "Idperiodo";
            iIdperiodo.Properties.BestFitMode = BestFitMode.BestFit;

            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;




        }
        private void TraerDatos()
        {
            try
            {

                NotacreditoMnt = Service.GetNotacredito(IdEntidadMnt);

                iIdtipocp.EditValue = NotacreditoMnt.Idtipocp;
                iIdcptooperacion.EditValue = NotacreditoMnt.Idcptooperacion;
                rIdsucursal.EditValue = NotacreditoMnt.Idsucursal;
                iSerienotacredito.EditValue = NotacreditoMnt.Serienotacredito;
                iNumeronotacredito.EditValue = NotacreditoMnt.Numeronotacredito;
                iFechaemision.EditValue = NotacreditoMnt.Fechaemision;
                iFecharecepcion.EditValue = NotacreditoMnt.Fecharecepcion;
                iIdproveedor.EditValue = NotacreditoMnt.Idproveedor;

                CargarDatosSocioNegocio(NotacreditoMnt.Idproveedor);
                iAnulado.EditValue = NotacreditoMnt.Anulado;
                iFechaanulado.EditValue = NotacreditoMnt.Fechaanulado;
                iIdempleado.EditValue = NotacreditoMnt.Idempleado;
                iTipocambio.EditValue = NotacreditoMnt.Tipocambio;
                iIdtipomoneda.EditValue = NotacreditoMnt.Idtipomoneda;
                rTotalbruto.EditValue = NotacreditoMnt.Totalbruto;
                rBaseimponible.EditValue = NotacreditoMnt.Baseimponible;
                rTotalimpuesto.EditValue = NotacreditoMnt.Totalimpuesto;
                rTotalneto.EditValue = NotacreditoMnt.Totalneto;
                rTotalpercepcion.EditValue = NotacreditoMnt.Totalpercepcion;
                rTotaldocumento.EditValue = NotacreditoMnt.Totaldocumento;
                iGlosanotacredito.EditValue = NotacreditoMnt.Glosanotacredito;
                iIdimpuesto.EditValue = NotacreditoMnt.Idimpuesto;
                iIncluyeimpuestoitems.EditValue = NotacreditoMnt.Incluyeimpuestoitems;
                iFecharegistro.EditValue = NotacreditoMnt.Fecharegistro;
                iIdperiodo.EditValue = NotacreditoMnt.Idperiodo;

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

            string where = string.Format("idNotacredito = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwNotacreditodetList = Service.GetAllVwNotacreditodet(where, "numeroitem");
            gcDetalle.DataSource = VwNotacreditodetList;            
            SumarTotales();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            NotacreditoMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            NotacreditoMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            NotacreditoMnt.Idsucursal = (int?)rIdsucursal.EditValue;
            NotacreditoMnt.Serienotacredito = iSerienotacredito.Text.Trim();
            NotacreditoMnt.Numeronotacredito = iNumeronotacredito.Text.Trim();
            NotacreditoMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            NotacreditoMnt.Fecharecepcion = (DateTime?)iFecharecepcion.EditValue;
            NotacreditoMnt.Idproveedor = (int)iIdproveedor.EditValue;
            NotacreditoMnt.Anulado = (bool)iAnulado.EditValue;
            NotacreditoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            NotacreditoMnt.Idempleado = (int)iIdempleado.EditValue;
            NotacreditoMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            NotacreditoMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            NotacreditoMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            NotacreditoMnt.Baseimponible = (decimal)rBaseimponible.EditValue;
            NotacreditoMnt.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
            NotacreditoMnt.Totalneto = (decimal)rTotalneto.EditValue;
            NotacreditoMnt.Totalpercepcion = (decimal)rTotalpercepcion.EditValue;
            NotacreditoMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
            NotacreditoMnt.Glosanotacredito = iGlosanotacredito.Text.Trim();
            NotacreditoMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            NotacreditoMnt.Incluyeimpuestoitems = (bool)iIncluyeimpuestoitems.EditValue;
            NotacreditoMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            NotacreditoMnt.Idperiodo = (int)iIdperiodo.EditValue;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    NotacreditoMnt.Createdby = IdUsuario;
                    NotacreditoMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    NotacreditoMnt.Modifiedby = IdUsuario;
                    NotacreditoMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                    if (Service.GuardarNotacredito(TipoMnt,NotacreditoMnt, VwNotacreditodetList))
                    {
                        IdEntidadMnt = NotacreditoMnt.Idnotacredito ;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarNotacredito(TipoMnt, NotacreditoMnt, VwNotacreditodetList);
                    break;
                }

                RegistrarValoresPorDefecto();

                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), iSerienotacredito.Text.Trim(),iNumeronotacredito.Text.Trim());
                Cursor = Cursors.Default;
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
            const string nombreTipodocMov = "Notacredito";
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

            if (iSerienotacredito.Text.Trim() == "0000")
            {
                XtraMessageBox.Show("El número de serie no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iSerienotacredito.Focus();
                return false;
            }

            if (iNumeronotacredito.Text.Trim() == "00000000")
            {
                XtraMessageBox.Show("El número de comprobante no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iNumeronotacredito.Focus();
                return false;
            }

            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwNotacreditodetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwNotacreditodetList.Where(x => x.Preciounitario <= 0);
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
            //string numeroSerie = rSerieNotacredito.Text.Trim();
            //string numeroViaje = rNumeroNotacredito.Text.Trim();

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
                        Service.DeleteNotacredito(IdEntidadMnt);
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

                    NotacreditoMnt = null;
                    NotacreditoMnt = new Notacredito();

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
                        NotacreditoMnt = null;
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
                        
                    }
                    break;
                case "btnImportarCp":
                    int idProveedorSel = (int)iIdproveedor.EditValue;
                    if (idProveedorSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el proveedor.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        iIdproveedor.Select();
                        return;
                    }

                    //var vwSocionegocioSel = VwSocionegocioList.FirstOrDefault(x => x.Idsocionegocio == (int) iIdproveedor.EditValue);

                    NotacreditoImpCpCompraFrm notacreditoImpCpCompra = new NotacreditoImpCpCompraFrm(VwNotacreditodetList, VwSocionegocioSel);
                    notacreditoImpCpCompra.ShowDialog();

                    if (notacreditoImpCpCompra.DialogResult == DialogResult.OK)
                    {
                        VwCpcompra vwCpcompraSelImp = notacreditoImpCpCompra.VwCpcompraSel;
                        if (vwCpcompraSelImp != null)
                        {
                            iIdproveedor.EditValue = vwCpcompraSelImp.Idproveedor;
                            iIdtipomoneda.EditValue = vwCpcompraSelImp.Idtipomoneda;
                            iTipocambio.EditValue = vwCpcompraSelImp.Tipocambio;
                            iIdtipomoneda.Enabled = false;
                        }
                        foreach (var item in VwNotacreditodetList.Where(x=>x.DataEntityState != DataEntityState.Deleted))
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
        private void NotacreditoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        }
        private void NotacreditoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            NotacreditoMntItemFrm ordencompraMntItemFrm;
            VwNotacreditodet vwNotacreditodetMntItem;


            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Asignar el siguiente item
                    vwNotacreditodetMntItem = new VwNotacreditodet();

                    //Asignar el siguiente item
                    var sgtItem = VwNotacreditodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwNotacreditodetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ordencompraMntItemFrm = new NotacreditoMntItemFrm(tipoMantenimientoItem, vwNotacreditodetMntItem);
                    ordencompraMntItemFrm.ShowDialog();
                  
                    if (ordencompraMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwNotacreditodetList.Add(vwNotacreditodetMntItem);
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
                    vwNotacreditodetMntItem = (VwNotacreditodet)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    ordencompraMntItemFrm = new NotacreditoMntItemFrm(tipoMantenimientoItem, vwNotacreditodetMntItem);
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

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwNotacreditodetMntItem = (VwNotacreditodet)gvDetalle.GetFocusedRow();
                        vwNotacreditodetMntItem.DataEntityState = DataEntityState.Deleted;

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

            //Percepcion
            var totalItemPercepcion =
                VwNotacreditodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Porcentajepercepcion);

            rPorcentajepercepcion.EditValue = totalItemPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0;
            //

            var totalbruto = VwNotacreditodetList.Where(w => !w.Exoneradoimpuesto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalneto = VwNotacreditodetList.Where(w => !w.Exoneradoimpuesto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotalneto.EditValue = totalneto;

            var totalexonerado = VwNotacreditodetList.Where(w => w.Exoneradoimpuesto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rTotalexonerado.EditValue = totalexonerado;

            var totalGravado = VwNotacreditodetList.Where(w => !w.Exoneradoimpuesto && w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importetotal);
            rBaseimponible.EditValue = totalGravado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);

            decimal porcentajeImpuesto = 0;
            if (impuestoSel != null)
            {
                porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                rTotalimpuesto.EditValue = decimal.Round(totalGravado * (porcentajeImpuesto / 100), 2);
            }

            decimal importePecepcionGravado = VwNotacreditodetList.Where(w => !w.Exoneradoimpuesto && w.DataEntityState != DataEntityState.Deleted && w.Porcentajepercepcion > 0).Sum(s => s.Importetotal * (s.Porcentajepercepcion/100));
            //Calculo percepcion

            rTotalpercepcion.EditValue = importePecepcionGravado* ( 1 + porcentajeImpuesto/100);

            rImportetotal.EditValue = ((decimal)rBaseimponible.EditValue + (decimal)rTotalimpuesto.EditValue);

            rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rTotalpercepcion.EditValue;
            gvDetalle.EndDataUpdate();

            gvDetalle.BestFitColumns(true);
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {

        }
        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwNotacreditodet item = (VwNotacreditodet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idnotacreditodet  <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
                case "Importetotal":
                    CalculaItem2(item);
                    SumarTotales();
                    break;
            }            
            
        }
        private void CalculaItem2(VwNotacreditodet item)
        {
            item.Preciounitarioneto = item.Cantidad == 0 ? 0 : item.Importetotal/item.Cantidad;
            decimal precioUnitario = item.Preciounitarioneto*100/(100 - item.Descuento4);
            precioUnitario = precioUnitario*100/(100 - item.Descuento3);
            precioUnitario = precioUnitario*100/(100 - item.Descuento2);
            precioUnitario = precioUnitario*100/(100 - item.Descuento1);
            item.Preciounitario = precioUnitario;
            item.Importetotal = Decimal.Round(item.Cantidad*item.Preciounitario, 2);
            item.DataEntityState = DataEntityState.Modified;
        }
        private void CalculaItem1(VwNotacreditodet item)
        {
            decimal precioUnitarioNeto = item.Preciounitario*(1 - item.Descuento1/100)*(1 - item.Descuento2/100)*
                                         (1 - item.Descuento3/100)*(1 - item.Descuento4/100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad*precioUnitarioNeto, 2);
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
        private void iIncluyeimpuestoitems_CheckedChanged(object sender, EventArgs e)
        {

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
                //iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                //iIdtipolista.EditValue = VwSocionegocioSel.Idtipolista;
                //iIdtipocondicion.EditValue = VwSocionegocioSel.Idtipocondicion;
                iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
              //  CargarDirecciones();
            }

        }
    }    
}