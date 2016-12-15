using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
    public partial class CuadrocomparativoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CuadrocomparativoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cuadrocomparativo CuadrocomparativoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwCuadrocomparativoprv> VwCuadrocomparativoprvList { get; set; }
        public List<VwCuadrocomparativoarticulo> VwCuadrocomparativoarticuloList { get; set; }
        public List<VwCuadrocomparativoarticulo> VwCuadrocomparativoarticuloAllList { get; set; }
        public Impuesto ImpuestoSelCotizacionPrv { get; set; }
        public CuadrocomparativoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CuadrocomparativoFrm formParent) 
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
        private void CuadrocomparativoMntFrm_Load(object sender, EventArgs e)
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
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
            iIdresponsable.Enabled = false;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "CUADROCC";
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
                    CuadrocomparativoMnt = new Cuadrocomparativo();                    
                    CargarDetalle();
                    iIdtipocp.Select();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();

                    iIdresponsable.Enabled = IdUsuario <= 0;
                    CargarDetalle();

                    break;
            }           
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CUADROCC", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CUADROCC", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;



            iIdresponsable.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;


            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                   
                    iIdestadocuadrocomparativo.Properties.DataSource = Service.GetAllEstadoreq(x => x.Estadoinicial);;
                    iIdestadocuadrocomparativo.Properties.DisplayMember = "Nombreestadoreq";
                    iIdestadocuadrocomparativo.Properties.ValueMember = "Idestadoreq";
                    iIdestadocuadrocomparativo.Properties.BestFitMode = BestFitMode.BestFit;

                    break;
                case TipoMantenimiento.Modificar:
                    if (!Service.CuadrocomparativoAprobado(IdEntidadMnt))
                    {
                        iIdestadocuadrocomparativo.Properties.DataSource = Service.GetAllEstadoreq(x => x.Estadoinicial);
                        iIdestadocuadrocomparativo.Properties.DisplayMember = "Nombreestadoreq";
                        iIdestadocuadrocomparativo.Properties.ValueMember = "Idestadoreq";
                        iIdestadocuadrocomparativo.Properties.BestFitMode = BestFitMode.BestFit;
                    }
                    else
                    {

                        iIdestadocuadrocomparativo.Properties.DataSource = Service.GetAllEstadoreq(x => x.Estadoinicial == false);
                        iIdestadocuadrocomparativo.Properties.DisplayMember = "Nombreestadoreq";
                        iIdestadocuadrocomparativo.Properties.ValueMember = "Idestadoreq";
                        iIdestadocuadrocomparativo.Properties.BestFitMode = BestFitMode.BestFit;
                    }

                    break;
            }



            string whereTipoDocCotizacion = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-PROVEEDOR", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoDocCotizacion, "nombretipocp");
            iIdTipoDocCotizacion.Properties.DataSource = VwTipocpList;
            iIdTipoDocCotizacion.Properties.DisplayMember = "Nombretipocp";
            iIdTipoDocCotizacion.Properties.ValueMember = "Idtipocp";
            iIdTipoDocCotizacion.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                CuadrocomparativoMnt = Service.GetCuadrocomparativo(IdEntidadMnt);
                rIdsucursal.EditValue = CuadrocomparativoMnt.Idsucursal;
                iIdtipocp.EditValue = CuadrocomparativoMnt.Idtipocp;
                iIdcptooperacion.EditValue = CuadrocomparativoMnt.Idcptooperacion;
                rSeriecc.EditValue = CuadrocomparativoMnt.Seriecc;
                rNumerocc.EditValue = CuadrocomparativoMnt.Numerocc;
                iFechaemision.EditValue = CuadrocomparativoMnt.Fechaemision;
                iIdresponsable.EditValue = CuadrocomparativoMnt.Idresponsable;
                iCulminado.EditValue = CuadrocomparativoMnt.Culminado;
                iFechaculminacion.EditValue = CuadrocomparativoMnt.Fechaculminacion;
                iAnulado.EditValue = CuadrocomparativoMnt.Anulado;
                iFechaanulado.EditValue = CuadrocomparativoMnt.Fechaanulado;
                iObservacion.EditValue = CuadrocomparativoMnt.Observacion;
                iIdcotizacionprv.EditValue = CuadrocomparativoMnt.Idcotizacionprv;
                iIdestadocuadrocomparativo.EditValue = CuadrocomparativoMnt.Idestadocuadrocomparativo;
                rTotalbuenapro.EditValue = CuadrocomparativoMnt.Totalbuenapro;


                CargarDatosCotizacionProveedor();
        
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
            gvProveedorDet.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            string where = string.Format("idcuadrocomparativo = '{0}'", IdEntidadMnt);
            gvProveedorDet.BeginUpdate();
            VwCuadrocomparativoprvList = Service.GetAllVwCuadrocomparativoprv(where, "idcuadrocomparativoprv");
            gcProveedorDet.DataSource = VwCuadrocomparativoprvList;
            gvProveedorDet.EndUpdate();                    
            gvProveedorDet.BestFitColumns(true);
            EstadoControlesCotizacion();
        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            CuadrocomparativoMnt.Idsucursal = (int)rIdsucursal.EditValue;
            CuadrocomparativoMnt.Idtipocp = (int)iIdtipocp.EditValue;
            CuadrocomparativoMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            CuadrocomparativoMnt.Seriecc = rSeriecc.Text.Trim();
            CuadrocomparativoMnt.Numerocc = rNumerocc.Text.Trim();
            CuadrocomparativoMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            CuadrocomparativoMnt.Idresponsable = (int?)iIdresponsable.EditValue;
            CuadrocomparativoMnt.Culminado = (bool)iCulminado.EditValue;
            CuadrocomparativoMnt.Fechaculminacion = (DateTime?)iFechaculminacion.EditValue;
            CuadrocomparativoMnt.Anulado = (bool)iAnulado.EditValue;
            CuadrocomparativoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            CuadrocomparativoMnt.Observacion = iObservacion.Text.Trim();
            CuadrocomparativoMnt.Idcotizacionprv = (int)iIdcotizacionprv.EditValue;
            CuadrocomparativoMnt.Idestadocuadrocomparativo = (int)iIdestadocuadrocomparativo.EditValue;
            CuadrocomparativoMnt.Totalbuenapro = (Decimal)rTotalbuenapro.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //CuadrocomparativoMnt.Createdby = IdUsuario;
                    //CuadrocomparativoMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //CuadrocomparativoMnt.Modifiedby = IdUsuario;
                    //CuadrocomparativoMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveCuadrocomparativo(CuadrocomparativoMnt);
                    CuadrocomparativoMnt.Idcuadrocomparativo = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;

                    if (IdEntidadMnt > 0
                        && TipoCpMnt.Numeracionauto
                        && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerocc.EditValue)))
                    {
                        iIdtipocp.ReadOnly = true;
                        iIdcptooperacion.ReadOnly = true;
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateCuadrocomparativo(CuadrocomparativoMnt);
                    if (CuadrocomparativoMnt.Anulado)
                    {
                        //Service.AnularReferenciaEntradaOrdenCompraDet(EntradaalmacenMnt.Identradaalmacen);
                    }

                    break;
                }

                RegistrarValoresPorDefecto();

                //var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriecc.Text.Trim(),iNumerocc.Text.Trim());
                Cursor = Cursors.Default;
                //XtraMessageBox.Show("Se guardo correctamente el documento "+numeroDoc, "Atención",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
            int idEmpleado = (int)iIdresponsable.EditValue;
            const string nombreTipodocMov = "CUADROCC";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCuadroComparativo, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if ((int) iIdcotizacionprv.EditValue == 0)
            {
                XtraMessageBox.Show("Ingrese la cotizacion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iNumeroCotizacion.Select();
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

                    CuadrocomparativoMnt = null;
                    CuadrocomparativoMnt = new Cuadrocomparativo();

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
                        CuadrocomparativoMnt = null;
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
                       ImpresionFormato.FormatoCuadroComparativoPrv(CuadrocomparativoMnt);
                    }
                    break;
            }
        }
        private void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvProveedorDet.OptionsBehavior.ReadOnly = true;
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
        private void CuadrocomparativoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpCuadroComparativo, readOnly);
            WinFormUtils.ReadOnlyFields(tpObservacion, readOnly);
            //XtraFormUtils.ReadOnlyFields(gcDatosCosto, readOnly);       
        }
        private void CuadrocomparativoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            CuadrocomparativoItemMntFrm cuadrocomparativoItemMntFrm;
            VwCuadrocomparativoprv vwCuadrocomparativoprvMnt;

            switch (e.Item.Name)
            {
                case "btnAddProveedor":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwCuadrocomparativoprvMnt = new VwCuadrocomparativoprv();
                    vwCuadrocomparativoprvMnt.Idcuadrocomparativo = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    cuadrocomparativoItemMntFrm = new CuadrocomparativoItemMntFrm(tipoMantenimientoItem, vwCuadrocomparativoprvMnt);
                    cuadrocomparativoItemMntFrm.ShowDialog();

                    if (cuadrocomparativoItemMntFrm.DialogResult == DialogResult.OK)
                    {
                        Cuadrocomparativoprv cuadrocomparativoprv = AsignarDatosSocioNegocio(vwCuadrocomparativoprvMnt);
                        int idcuadrocomparativoprv = Service.SaveCuadrocomparativoprv(cuadrocomparativoprv);
                        if (idcuadrocomparativoprv > 0)
                        {
                            vwCuadrocomparativoprvMnt.Idcuadrocomparativoprv = idcuadrocomparativoprv;
                            VwCuadrocomparativoprvList.Add(vwCuadrocomparativoprvMnt);
                            ActualizarDetalleProveedor();
                            if (!gvProveedorDet.IsLastRow)
                            {
                                gvProveedorDet.MoveLastVisible();
                                gvProveedorDet.Focus();

                            }

                            EstadoControlesCotizacion();
                            GuardarItemsCotizacion(idcuadrocomparativoprv);
                        }
                    }
                    break;

                case "btnEditProveedor":
                    if (gvProveedorDet.RowCount == 0)
                    {
                        break;
                    }
                    vwCuadrocomparativoprvMnt = (VwCuadrocomparativoprv)gvProveedorDet.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    cuadrocomparativoItemMntFrm = new CuadrocomparativoItemMntFrm(tipoMantenimientoItem, vwCuadrocomparativoprvMnt);
                    cuadrocomparativoItemMntFrm.ShowDialog();

                    if (cuadrocomparativoItemMntFrm.DialogResult == DialogResult.OK)
                    {
                        var cuadrocomparativoprv = AsignarDatosSocioNegocio(vwCuadrocomparativoprvMnt);
                        if (cuadrocomparativoprv.Idcuadrocomparativoprv > 0)
                        {
                            Service.UpdateCuadrocomparativoprv(cuadrocomparativoprv);
                            ActualizarDetalleProveedor();
                        }
                    }


                    break;

                case "btnDelProveedor":
                    if (gvProveedorDet.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwCuadrocomparativoprvMnt = (VwCuadrocomparativoprv)gvProveedorDet.GetFocusedRow();
                        if (vwCuadrocomparativoprvMnt.Idcuadrocomparativoprv > 0)
                        {
                            Service.DeleteCuadrocomparativoprv(vwCuadrocomparativoprvMnt.Idcuadrocomparativoprv);
                            vwCuadrocomparativoprvMnt.DataEntityState = DataEntityState.Deleted;
                            if (!gvProveedorDet.IsFirstRow)
                            {
                                gvProveedorDet.MovePrev();
                            }
                            ActualizarDetalleProveedor();
                            gcCotizacionDet.DataSource = null;
                            //SumarTotales();
                            VwCuadrocomparativoprv cuadrocomparativoprv = (VwCuadrocomparativoprv) gvProveedorDet.GetFocusedRow();
                            if (cuadrocomparativoprv != null)
                            {
                                CargarItemsCotizacion(cuadrocomparativoprv.Idcuadrocomparativoprv);
                            }

                            if (gvProveedorDet.RowCount == 0)
                            {
                                rTotalbruto.EditValue = 0m;
                                rTotalgravado.EditValue = 0m;
                                rTotalinafecto.EditValue = 0m;
                                rtotalexonerado.EditValue = 0m;
                                rTotalimpuesto.EditValue = 0m;
                                rImportetotal.EditValue = 0m;
                                rPorcentajepercepcion.EditValue = 0m;
                                rImportetotalpercepcion.EditValue = 0m;
                                rTotaldocumento.EditValue = 0m;
                                AnularReferenciaCotizacionPrvCuadroCc();

                            }
                            EstadoControlesCotizacion();
                        }
                    }
                    break;
                case "btnGrabarItems":
                    VwCuadrocomparativoprv vwCuadrocomparativoprv = (VwCuadrocomparativoprv)gvProveedorDet.GetFocusedRow();
                    if (vwCuadrocomparativoprv != null)
                    {
                        ActualizarItemsCotizacion(vwCuadrocomparativoprv.Idcuadrocomparativoprv);
                    }                    
                    break;
                case "btnComparar":
                    CompararItems();
                    break;
            }   
            
        }
        private void AnularReferenciaCotizacionPrvCuadroCc()
        {
            Service.AnularReferenciaCotizacionPrvCuadroComparativo(IdEntidadMnt);
            iIdcotizacionprv.EditValue = 0;
            iNumeroCotizacion.EditValue = @"00000000";
            iNumeroCotizacion.Focus();
            iNumeroCotizacion.Select();
            iNumeroCotizacion.SelectAll();
        }
        private void CompararItems()
        {
            if (gvProveedorDet.RowCount == 0)
            {
                return;
            }

            VwCuadrocomparativoprv cuadrocomparativoprvBuenaPro  = VwCuadrocomparativoprvList.OrderBy(s => s.Totaldocumento).FirstOrDefault();
            if (cuadrocomparativoprvBuenaPro != null && cuadrocomparativoprvBuenaPro.Idcuadrocomparativoprv > 0)
            {
                if (gvProveedorDet.RowCount > 0)
                {
                    gvProveedorDet.BeginUpdate();
                    var rowHandle = gvProveedorDet.LocateByValue("Idcuadrocomparativoprv", cuadrocomparativoprvBuenaPro.Idcuadrocomparativoprv);
                    if (rowHandle == GridControl.InvalidRowHandle)
                    {
                        gvProveedorDet.EndUpdate();
                        return;
                    }
                    gvProveedorDet.EndUpdate();
                    gvProveedorDet.FocusedRowHandle = rowHandle;

                    if (Service.ActualizarItemBuenaProCuadroComparativoPrv(
                        cuadrocomparativoprvBuenaPro.Idcuadrocomparativoprv, true))
                    {
                        foreach (var itemc in VwCuadrocomparativoarticuloList)
                        {
                            itemc.Buenapro = true;
                        }
                        gvCotizacionDet.BeginDataUpdate();
                        gvCotizacionDet.RefreshData();
                        gvCotizacionDet.EndDataUpdate();
                    }

                }
                XtraMessageBox.Show(
                    string.Format("Se comparó y se dio la buena pro al proveedor {0}", cuadrocomparativoprvBuenaPro.Nombresocionegocio),
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void EstadoControlesCotizacion()
        {
            if (gvProveedorDet.RowCount > 0)
            {
                iIdTipoDocCotizacion.ReadOnly = true;
                iNumeroCotizacion.ReadOnly = true;
                btnBuscarCotizacion.Enabled = false;
            }
            else
            {
                iIdTipoDocCotizacion.ReadOnly = false;
                iNumeroCotizacion.ReadOnly = false;
                btnBuscarCotizacion.Enabled = true;
            }
        }
        private void ActualizarItemsCotizacion(int idcuadrocomparativoprv)
        {
            foreach (var itemc in VwCuadrocomparativoarticuloList)
            {
                Cuadrocomparativoarticulo cuadrocomparativoarticulo = new Cuadrocomparativoarticulo();
                cuadrocomparativoarticulo.Idcuadrocomparativoarticulo = itemc.Idcuadrocomparativoarticulo;
                cuadrocomparativoarticulo.Idcuadrocomparativoprv = idcuadrocomparativoprv;
                cuadrocomparativoarticulo.Idcotizacionprvdet = itemc.Idcotizacionprvdet;
                cuadrocomparativoarticulo.Preciounitario = itemc.Preciounitario;
                cuadrocomparativoarticulo.Cantidad = itemc.Cantidad;
                cuadrocomparativoarticulo.Descuento1 = itemc.Descuento1;
                cuadrocomparativoarticulo.Descuento2 = itemc.Descuento2;
                cuadrocomparativoarticulo.Descuento3 = itemc.Descuento3;
                cuadrocomparativoarticulo.Descuento4 = itemc.Descuento4;
                cuadrocomparativoarticulo.Porcentajepercepcion = itemc.Porcentajepercepcion;
                cuadrocomparativoarticulo.Preciounitarioneto = itemc.Preciounitarioneto;
                cuadrocomparativoarticulo.Importetotal = itemc.Importetotal;
                cuadrocomparativoarticulo.Diasdeentrega = itemc.Diasdeentrega;
                cuadrocomparativoarticulo.Justificacion = itemc.Justificacion;
                cuadrocomparativoarticulo.Buenapro = itemc.Buenapro;

                Service.UpdateCuadrocomparativoarticulo(cuadrocomparativoarticulo);
            }

            decimal totalCotizacionProveedor = (decimal)rTotaldocumento.EditValue;

            if (totalCotizacionProveedor > 0 && Service.ActualizarTotalCuadroComparativoPrv(idcuadrocomparativoprv, totalCotizacionProveedor))
            {
                VwCuadrocomparativoprv cuadrocomparativoprv = (VwCuadrocomparativoprv) gvProveedorDet.GetFocusedRow();
                cuadrocomparativoprv.Totaldocumento = totalCotizacionProveedor;
                gvProveedorDet.RefreshData();
                gvProveedorDet.BestFitColumns(true);
            }


            XtraMessageBox.Show("Items grabados correctamente", "Atencio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GuardarItemsCotizacion(int idcuadrocomparativoprv)
        {
            var idCotizacionPrv = iIdcotizacionprv.EditValue;

            if (idCotizacionPrv == null)
            {
                XtraMessageBox.Show("Ingrese la cotizacion de proveedor", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            List<Cotizacionprvdet> cotizacionprvdetList = Service.GetAllCotizacionprvdet(x => x.Idcotizacionprv == (int)idCotizacionPrv);

            if (cotizacionprvdetList != null)
            {
                foreach (var itemc in cotizacionprvdetList)
                {
                    Cuadrocomparativoarticulo cuadrocomparativoarticulo = new Cuadrocomparativoarticulo();
                    cuadrocomparativoarticulo.Idcuadrocomparativoprv = idcuadrocomparativoprv;
                    cuadrocomparativoarticulo.Idcotizacionprvdet = itemc.Idcotizacionprvdet;
                    cuadrocomparativoarticulo.Preciounitario = 0m;
                    cuadrocomparativoarticulo.Cantidad = itemc.Cantidad;
                    cuadrocomparativoarticulo.Descuento1 = 0m;
                    cuadrocomparativoarticulo.Descuento2 = 0m;
                    cuadrocomparativoarticulo.Descuento3 = 0m;
                    cuadrocomparativoarticulo.Descuento4 = 0m;
                    cuadrocomparativoarticulo.Porcentajepercepcion = 0m;
                    cuadrocomparativoarticulo.Preciounitarioneto = 0;
                    cuadrocomparativoarticulo.Importetotal = 0m;
                    cuadrocomparativoarticulo.Diasdeentrega = 0;
                    cuadrocomparativoarticulo.Justificacion = string.Empty;
                    cuadrocomparativoarticulo.Buenapro = false;
                    Service.SaveCuadrocomparativoarticulo(cuadrocomparativoarticulo);
                }
            }

            //CargarItemsCotizacion(idcuadrocomparativoprv);
            CargarItemsCotizacion(idcuadrocomparativoprv);
        }        
        private void ActualizarDetalleProveedor()
        {
            gvProveedorDet.BeginUpdate();
            gvProveedorDet.RefreshData();
            gvProveedorDet.EndUpdate();
            gvProveedorDet.BestFitColumns(true);
        }
        private Cuadrocomparativoprv AsignarDatosSocioNegocio(VwCuadrocomparativoprv vwCuadrocomparativoprvMnt)
        {
            Cuadrocomparativoprv cuadrocomparativoprv = new Cuadrocomparativoprv();           
            cuadrocomparativoprv.Idcuadrocomparativoprv = vwCuadrocomparativoprvMnt.Idcuadrocomparativoprv;
            cuadrocomparativoprv.Idcuadrocomparativo = IdEntidadMnt;
            cuadrocomparativoprv.Idsocionegocio = vwCuadrocomparativoprvMnt.Idsocionegocio;
            cuadrocomparativoprv.Incluyeimpuestoitems = vwCuadrocomparativoprvMnt.Incluyeimpuestoitems;
            cuadrocomparativoprv.Formadepago = vwCuadrocomparativoprvMnt.Formadepago;
            cuadrocomparativoprv.Diasvalidez = vwCuadrocomparativoprvMnt.Diasvalidez;
            cuadrocomparativoprv.Fechacotizacionrecepcion = vwCuadrocomparativoprvMnt.Fechacotizacionrecepcion;
            return cuadrocomparativoprv;
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
                VwTipocp vwTipocp = Service.GetVwTipocp((int) idTipocp);
                TipoCpMnt = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriecc.EditValue = vwTipocp.Seriecp;
                        rNumerocc.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocc.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocc.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerocc.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocc.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocc.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriecc.EditValue = @"0000";
                rNumerocc.EditValue = 0;
            }
        }
        private void CargarInfoCorrelativoCotizacion()
        {
            var idTipoCpCotizacion = iIdTipoDocCotizacion.EditValue;
            if (idTipoCpCotizacion != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipoCpCotizacion);
                rSerieCotizacion.EditValue = vwTipocp.Seriecp;
            }
            else
            {
                rSeriecc.EditValue = @"0000";
                rNumerocc.EditValue = 0;
            }
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

            //BarMntItems.BeginUpdate();
            //foreach (BarItem item in bmItems.Items)
            //{
            //    item.Enabled = enabled;
            //}
            //BarMntItems.EndUpdate();

        }
        private void iIdTipoDocCotizacion_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativoCotizacion();
        }
        private void btnBuscarCotizacion_Click(object sender, EventArgs e)
        {
            var idTipoCp = iIdTipoDocCotizacion.EditValue;
            if (idTipoCp == null)
            {
                XtraMessageBox.Show("Seleccione el tipo de documento","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                iIdTipoDocCotizacion.Select();
                return;
            }


            int idSucursal = (int) rIdsucursal.EditValue;
            string serieCotizacion = (string) rSerieCotizacion.EditValue;
            string numeroCotizacion = (string) iNumeroCotizacion.EditValue;

            Cotizacionprv cotizacionprv = Service.GetCotizacionprv(
                x => x.Idtipocp == (int)idTipoCp
                     && x.Idsucursal == idSucursal
                     && x.Seriecotizacionprv == serieCotizacion.Trim()
                     && x.Numerocotizacionprv == numeroCotizacion.Trim()
                     && !x.Anulado
                );

            if (cotizacionprv != null)
            {
                //Verificar si tiene items la cotizacion
                long cantidadItemsCotizacion = Service.CountCotizacionprvdet(x => x.Idcotizacionprv == cotizacionprv.Idcotizacionprv);
                if (cantidadItemsCotizacion <= 0)
                {
                    XtraMessageBox.Show("La cotización no tiene items, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumeroCotizacion.Text = @"0";
                    iNumeroCotizacion.Focus();
                    iNumeroCotizacion.Select();
                    iNumeroCotizacion.SelectAll();
                    return;
                }


                //Verificar si la cotizacion tiene cuadro comparativo
                Cuadrocomparativo cuadrocomparativo =Service.GetCuadrocomparativo(
                    x => x.Idcotizacionprv == cotizacionprv.Idcotizacionprv
                    && !x.Anulado);

                if (cuadrocomparativo != null)
                {
                    string numeroDocCc = string.Format("{0}-{1}", cuadrocomparativo.Seriecc.Trim(), cuadrocomparativo.Numerocc);
                    XtraMessageBox.Show(string.Format("Cotizacion ya fue importada en el cuadro comparativo N°: {0}",numeroDocCc), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumeroCotizacion.Text = @"0";
                    iNumeroCotizacion.Focus();
                    iNumeroCotizacion.Select();
                    iNumeroCotizacion.SelectAll();
                    return;
                }

                iIdcotizacionprv.EditValue = cotizacionprv.Idcotizacionprv;
                XtraMessageBox.Show("Cotización encontrada con exito", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("No se encontró el número de cotización, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdcotizacionprv.EditValue = 0;
                iNumeroCotizacion.EditValue = @"00000000";
                iNumeroCotizacion.Focus();
                iNumeroCotizacion.Select();
                iNumeroCotizacion.SelectAll();
            }
        }
        private void CargarDatosCotizacionProveedor()
        {
            //int idTipoCp = (int)iIdTipoDocCotizacion.EditValue;
            //int idSucursal = (int)rIdsucursal.EditValue;
            //string serieCotizacion = (string)rSerieCotizacion.EditValue;
            //string numeroCotizacion = (string)iNumeroCotizacion.EditValue;

            Cotizacionprv cotizacionprv = Service.GetCotizacionprv(x => x.Idcotizacionprv == (int)iIdcotizacionprv.EditValue);

            if (cotizacionprv != null)
            {
                iIdTipoDocCotizacion.EditValue = cotizacionprv.Idtipocp;
                //rSerieCotizacion.EditValue = cotizacionprv.Sericotizacionprv;
                iNumeroCotizacion.EditValue = cotizacionprv.Numerocotizacionprv;
            }

        }
        private void gvProveedorDet_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            VwCuadrocomparativoprv vwCuadrocomparativoprv = (VwCuadrocomparativoprv) gvProveedorDet.GetFocusedRow();
            if (vwCuadrocomparativoprv != null)
            {
                CargarItemsCotizacion(vwCuadrocomparativoprv.Idcuadrocomparativoprv);
            }
        }
        private void gvCotizacionDet_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCuadrocomparativoarticulo item = (VwCuadrocomparativoarticulo)gvCotizacionDet.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idcuadrocomparativoprv <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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
                    item.DataEntityState = DataEntityState.Modified;
                    SumarTotales();
                    break;
                case "Buenapro":
                    SumarTotales();
                    break;
                case "Justificacion":
                case "Diasdeentrega":                    
                    item.DataEntityState = DataEntityState.Modified;
                    break;
            }
        }
        private void CalculaItem2(VwCuadrocomparativoarticulo item)
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
        private void SumarTotales()
        {
            gvCotizacionDet.BeginDataUpdate();
            gvCotizacionDet.RefreshData();

            // CALCULO TOTALES POR PROVEEDOR
            SumarTotalesProveedor();
            // CALCULO TOTAL BUENA PRO
            SumarTotalesBuenapro();
            gvCotizacionDet.EndDataUpdate();

            gvCotizacionDet.BestFitColumns(true);
        }
        private void SumarTotalesProveedor()
        {
            var totalbruto =
                VwCuadrocomparativoarticuloList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Cantidad*s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalgravado =
                VwCuadrocomparativoarticuloList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
            rTotalgravado.EditValue = totalgravado;

            var totalinafecto =
                VwCuadrocomparativoarticuloList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
            rTotalinafecto.EditValue = totalinafecto;

            var totalexonerado =
                VwCuadrocomparativoarticuloList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
            rtotalexonerado.EditValue = totalexonerado;

            if (ImpuestoSelCotizacionPrv == null)
            {
                ImpuestoSelCotizacionPrv =
                    Service.GetImpuesto(x => x.Idimpuesto == SessionApp.EmpresaSel.Idimpuestopordefecto);
            }

            if (ImpuestoSelCotizacionPrv != null)
            {
                var porcentajeImpuesto = ImpuestoSelCotizacionPrv.Porcentajeimpuesto;
                decimal totalImpuesto = decimal.Round(totalgravado*(porcentajeImpuesto/100), 2);
                rTotalimpuesto.EditValue = decimal.Round(totalgravado*(porcentajeImpuesto/100), 2);
                rImportetotal.EditValue = totalgravado + totalinafecto + totalexonerado + totalImpuesto;

                //Calculo percepcion
                decimal totalValorPercepcion = VwCuadrocomparativoarticuloList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                         && w.Porcentajepercepcion > 0).Sum(s => s.Importetotal*(s.Porcentajepercepcion/100));
                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0
                    ? SessionApp.EmpresaSel.Porcentajepercepcion
                    : 0m;

                decimal importetotalpercepcion = Math.Round(totalValorPercepcion*(1 + porcentajeImpuesto/100), 2);
                rImportetotalpercepcion.EditValue = importetotalpercepcion;
                //fin calculo percepcion

                rTotaldocumento.EditValue = (decimal) rImportetotal.EditValue +
                                            (decimal) rImportetotalpercepcion.EditValue;
            }
        }
        private void SumarTotalesBuenapro()
        {
            var totalbruto =
               VwCuadrocomparativoarticuloAllList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Buenapro )
                   .Sum(s => s.Cantidad * s.Preciounitario);
            

            var totalgravado =
                VwCuadrocomparativoarticuloAllList.Where(w => w.Gravado && w.Buenapro && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
           

            var totalinafecto =
                VwCuadrocomparativoarticuloAllList.Where(w => w.Inafecto && w.Buenapro && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
           

            var totalexonerado =
                VwCuadrocomparativoarticuloAllList.Where(w => w.Exonerado && w.Buenapro && w.DataEntityState != DataEntityState.Deleted)
                    .Sum(s => s.Importetotal);
        

            if (ImpuestoSelCotizacionPrv == null)
            {
                ImpuestoSelCotizacionPrv =
                    Service.GetImpuesto(x => x.Idimpuesto == SessionApp.EmpresaSel.Idimpuestopordefecto);
            }

            if (ImpuestoSelCotizacionPrv != null)
            {
                var porcentajeImpuesto = ImpuestoSelCotizacionPrv.Porcentajeimpuesto;
                decimal totalImpuesto = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
               
                decimal importetotal = totalgravado + totalinafecto + totalexonerado + totalImpuesto;

                //Calculo percepcion
                decimal totalValorPercepcion = VwCuadrocomparativoarticuloAllList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                         && w.Buenapro && w.Porcentajepercepcion > 0).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));
                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0
                    ? SessionApp.EmpresaSel.Porcentajepercepcion
                    : 0m;

                decimal importetotalpercepcion = Math.Round(totalValorPercepcion * (1 + porcentajeImpuesto / 100), 2);
              
                //fin calculo percepcion

                rTotalbuenapro.EditValue = importetotal +
                                            importetotalpercepcion;
            }
        }

        private void CalculaItem1(VwCuadrocomparativoarticulo item)
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
        private void CargarItemsCotizacion(int idcuadrocomparativoprv)
        {
            //VwCuadrocomparativoprv cuadrocomparativoprv = (VwCuadrocomparativoprv) gvCotizacionDet.DataSource;
            if (idcuadrocomparativoprv > 0)
            {
                string whereDetalle = string.Format("idcuadrocomparativoprv = {0}", idcuadrocomparativoprv);
                string wherecc = string.Format("idcuadrocomparativo = '{0}'", IdEntidadMnt);
                VwCuadrocomparativoarticuloList = Service.GetAllVwCuadrocomparativoarticulo(whereDetalle, "numeroitem");
                VwCuadrocomparativoarticuloAllList = Service.GetAllVwCuadrocomparativoarticulo(wherecc,"numeroitem");
                gvCotizacionDet.BeginDataUpdate();
                gcCotizacionDet.DataSource = VwCuadrocomparativoarticuloList;
                gvCotizacionDet.EndDataUpdate();
                gvCotizacionDet.BestFitColumns(true);                
            }
            SumarTotales();            
        }
        private void riBoleano_EditValueChanged(object sender, EventArgs e)
        {
            gvCotizacionDet.PostEditor();
        }
        private void iNumeroCotizacion_Enter(object sender, EventArgs e)
        {
            iNumeroCotizacion.SelectAll();
        }

        private void iCulminado_EditValueChanged(object sender, EventArgs e)
        {
            iFechaculminacion.EditValue = iCulminado.Checked ? (object)DateTime.Now : null;
        }
    }    
}