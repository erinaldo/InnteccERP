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
using DevExpress.XtraGrid.Views.Base;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class InventarioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public InventarioFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Inventario InventarioMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<VwUbicacion> VwUbicacionList { get; set; }
        public List<VwInventarioubicacion> VwInventarioubicacionList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwInventariostock> VwInventariostockList { get; set; }
        public DateTime FechaInicialInventarioAnterior { get; set; }

        static readonly HelperDb HelperDb = new HelperDb();
        public InventarioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, InventarioFrm formParent) 
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

            EstablecerFechasIniciales();
        }
        private void InventarioMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFechainventario.EditValue = SessionApp.DateServer;
            iHoratransaccion.EditValue = DateTime.Now;

            if (SessionApp.EmpleadoSel != null)
            {
                iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdresponsable.Enabled = false;
            }

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "INVENTARIO";
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
                    InventarioMnt = new Inventario();                    
                    CargarDetalle();                    
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    if (!SessionApp.UsuarioSel.Nombreusuario.Equals("ADMIN"))
                    {
                        iIdresponsable.ReadOnly = true;
                    }
                    btnCargarSaldosActuales.Enabled = false;
                    break;
            }           
        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal(x=>x.Idempresa == SessionApp.EmpresaSel.Idempresa);
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "INVENTARIO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "INVENTARIO", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            string condicionEmpresaEmpleado = "idempresa = " + SessionApp.EmpresaSel.Idempresa;
            iIdresponsable.Properties.DataSource = Service.GetAllVwEmpleado(condicionEmpresaEmpleado, "razonsocial");
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacen.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen,"codigoalmacen");
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;


            TipodocmovList = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocimp.DataSource = TipodocmovList;
            iIdtipodocimp.DisplayMember = "Nombretipodocmov";
            iIdtipodocimp.ValueMember = "Idtipodocmov";
            iIdtipodocimp.BestFitMode = BestFitMode.BestFit;

            string condicionEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdinventarioinicial.Properties.DataSource = Service.GetAllVwInventarioinicial(condicionEmpresa, "fechainventarioinicial");
            iIdinventarioinicial.Properties.DisplayMember = "Fechainventarioinicialempresa";
            iIdinventarioinicial.Properties.ValueMember = "Idinventarioinicial";
            iIdinventarioinicial.Properties.BestFitMode = BestFitMode.BestFit;


        }
        private void TraerDatos()
        {
            try
            {
                InventarioMnt = Service.GetInventario(IdEntidadMnt);

                iIdsucursal.EditValue = InventarioMnt.Idsucursal;
                iIdalmacen.EditValue = InventarioMnt.Idalmacen;
                iIdtipocp.EditValue = InventarioMnt.Idtipocp;
                iIdcptooperacion.EditValue = InventarioMnt.Idcptooperacion;
                iIdresponsable.EditValue = InventarioMnt.Idresponsable;
                iNumeroinventario.EditValue = InventarioMnt.Numeroinventario;
                iFechainventario.EditValue = InventarioMnt.Fechainventario;
                iAnulado.EditValue = InventarioMnt.Anulado;
                iFechaanulado.EditValue = InventarioMnt.Fechaanulado;
                iCierreinventario.EditValue = InventarioMnt.Cierreinventario;
                rSerieinventario.EditValue = InventarioMnt.Serieinventario;
                iHoratransaccion.EditValue = InventarioMnt.Horatransaccion;
                iIdinventarioinicial.EditValue = InventarioMnt.Idinventarioinicial;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private void CargarDetalleArticulo(int? idInventarioubicacion)
        {
            string where = string.Format("idinventarioubicacion = '{0}'", idInventarioubicacion);
            gcDetalle.BeginUpdate();
            VwInventariostockList = Service.GetAllVwInventariostock(where, "idinventariostock");
            gcDetalle.DataSource = VwInventariostockList;

            if (IdEntidadMnt > 0)
            {
                ActualizarTotales();
            }

            gcDetalle.EndUpdate();
            gvArticulosDet.BestFitColumns();

            SumarTotales();

        }
        private void SumarTotales()
        {
            decimal totalCantidad = VwInventariostockList.Sum(x => x.Cantidadinventario);
            decimal totalValorado = VwInventariostockList.Sum(x => x.Costototsoles);
            rTotalCantidad.EditValue = totalCantidad;
            rTotalValorado.EditValue = totalValorado;

            gvArticulosDet.BeginDataUpdate();
            gvArticulosDet.RefreshData();
            gvArticulosDet.EndDataUpdate();
            gvArticulosDet.BestFitColumns(true);
        }
        private void CargarDetalle()
        {
            string where = string.Format("idinventario = '{0}'", IdEntidadMnt);
            gcUbicacion.BeginUpdate();
            VwInventarioubicacionList = Service.GetAllVwInventarioubicacion(where, "ubicacion");
            gcUbicacion.DataSource = VwInventarioubicacionList;
            if (IdEntidadMnt > 0)
            {
                ActualizarTotales();
            }

            gcUbicacion.EndUpdate();
            gvUbicacion.BestFitColumns();
            VwInventarioubicacion vwInventarioubicacionSel = (VwInventarioubicacion)gvUbicacion.GetFocusedRow();
            if (vwInventarioubicacionSel != null)
            {
                CargarDetalleArticulo(vwInventarioubicacionSel.Idinventarioubicacion);
            }

            iIdalmacen.Enabled = gvUbicacion.RowCount <= 0;

        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            InventarioMnt.Idsucursal = (int?)iIdsucursal.EditValue;
            InventarioMnt.Idalmacen = (int?)iIdalmacen.EditValue;
            InventarioMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            InventarioMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;
            InventarioMnt.Idresponsable = (int?)iIdresponsable.EditValue;
            InventarioMnt.Numeroinventario = iNumeroinventario.Text.Trim();
            InventarioMnt.Fechainventario = (DateTime)iFechainventario.EditValue;
            InventarioMnt.Anulado = (bool)iAnulado.EditValue;
            InventarioMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            InventarioMnt.Cierreinventario = (bool)iCierreinventario.EditValue;
            InventarioMnt.Serieinventario = rSerieinventario.Text.Trim();
            InventarioMnt.Horatransaccion = (DateTime)iHoratransaccion.EditValue;
            InventarioMnt.Idinventarioinicial = (int?)iIdinventarioinicial.EditValue;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //InventarioMnt.Createdby = IdUsuario;
                    //InventarioMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //InventarioMnt.Modifiedby = IdUsuario;
                    //InventarioMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveInventario(InventarioMnt);
                    InventarioMnt.Idinventario = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    if (IdEntidadMnt > 0
                        && TipoCpMnt.Numeracionauto
                        && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(iNumeroinventario.EditValue)))
                    {
                        iIdtipocp.ReadOnly = true;
                        iIdcptooperacion.ReadOnly = true;
                    }

                        
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateInventario(InventarioMnt);
                    if (InventarioMnt.Anulado)
                    {
                        //Service.AnularReferenciaEntradaOrdenCompraDet(InventarioMnt.IdInventario);
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
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
                        Service.DeleteInventario(IdEntidadMnt);
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

                    InventarioMnt = null;
                    InventarioMnt = new Inventario();

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
                        InventarioMnt = null;
                        DialogResult = DialogResult.OK;
                    }                    
                    break;
                case "btnImprimir":
                    //if (InventarioImpresion == null)
                    //{
                    //    InventarioImpresion = new InventarioImpresion();
                    //}
                    //if (IdEntidadMnt > 0)
                    //{
                    //    InventarioImpresion.VistaPrevia(IdEntidadMnt);
                    //}
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
        private void InventarioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(this, readOnly);           
        }
        private void InventarioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            InventarioMntItemFrm inventarioMntItemFrm;
            VwInventariostock vwInventariostockMntItem = new VwInventariostock();
            //Inventariostock inventariostockMnt;

            const string nombreIdDetalle = "Idinventariostock";
            VwInventarioubicacion vwInventarioubicacionSel = (VwInventarioubicacion)gvUbicacion.GetFocusedRow();

            switch (e.Item.Name)
            {
                case "btnAddItem":
                   
                    if (vwInventarioubicacionSel == null)
                    {
                        XtraMessageBox.Show("Seleccione la Ubicacion", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        gvUbicacion.Focus();
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                   
                    inventarioMntItemFrm = new InventarioMntItemFrm(tipoMantenimientoItem, vwInventariostockMntItem);
                    inventarioMntItemFrm.UbicacionSeleccionada = vwInventarioubicacionSel.Ubicacion;
                    inventarioMntItemFrm.ShowDialog();

                    if (inventarioMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Inventariostock inventariostockMnt = AsignarInventarioStock(vwInventariostockMntItem, vwInventarioubicacionSel.Idinventarioubicacion);
                        int idinventariostock = Service.SaveInventariostock(inventariostockMnt);

                        //CargarDetalle();
                        if (idinventariostock > 0)
                        {
                            //Agregar al articulo la ubicacion por defecto si es que no existe
                            Articuloubicacion articuloubicacionExistente =
                                Service.GetArticuloubicacion(
                                    x =>
                                        x.Idarticulo == inventariostockMnt.Idarticulo &&
                                        x.Idubicacion == vwInventarioubicacionSel.Idubicacion);

                            if (articuloubicacionExistente == null)
                            {
                                Articuloubicacion articuloubicacion = new Articuloubicacion
                                {
                                    Idarticulo = inventariostockMnt.Idarticulo,
                                    Idubicacion = vwInventarioubicacionSel.Idubicacion
                                };
                                Service.SaveArticuloubicacion(articuloubicacion);
                            }

                            //

                            vwInventariostockMntItem.Idinventariostock = idinventariostock;
                            VwInventariostockList.Add(vwInventariostockMntItem);
                            SumarTotales();
                            //Enfocar registro guardado
                            var rowHandle = gvArticulosDet.LocateByValue(nombreIdDetalle, idinventariostock);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {
                                return;
                            }
                            gvArticulosDet.FocusedRowHandle = rowHandle;
                        }

                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwInventariostockMntItem = (VwInventariostock) gvArticulosDet.GetFocusedRow();
                    if (vwInventariostockMntItem == null) 
                    {
                        break;
                    }

                    inventarioMntItemFrm = new InventarioMntItemFrm(tipoMantenimientoItem, vwInventariostockMntItem);
                    inventarioMntItemFrm.UbicacionSeleccionada = vwInventarioubicacionSel.Ubicacion;
                    inventarioMntItemFrm.ShowDialog();

                    if (inventarioMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Inventariostock inventariostockMnt = AsignarInventarioStock(vwInventariostockMntItem,vwInventarioubicacionSel.Idinventarioubicacion);
                        if (inventariostockMnt.Idinventariostock > 0)
                        {
                            Service.UpdateInventariostock(inventariostockMnt);
                            SumarTotales();
                        }
                    }

                    break;

                case "btnDelItem":
                    int idInventariodet = Convert.ToInt32(gvArticulosDet.GetRowCellValue(gvArticulosDet.FocusedRowHandle, nombreIdDetalle));

                    if (idInventariodet > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar item", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            if (idInventariodet > 0)
                            {
                                VwInventariostock vwInventariostock = VwInventariostockList.FirstOrDefault(x => x.Idinventariostock == idInventariodet);
                                if (vwInventariostock != null)
                                {
                                    VwInventariostockList.Remove(vwInventariostock);
                                    Service.DeleteInventariostock(idInventariodet);
                                    SumarTotales();
                                }

                            }
                        }
                    }
                    break;
                case "btnBuscarInventario":
                    BuscadorArticuloEnInventarioFrm buscadorArticuloEnInventarioFrm = new BuscadorArticuloEnInventarioFrm();
                    buscadorArticuloEnInventarioFrm.ShowDialog();
                    if (buscadorArticuloEnInventarioFrm.DialogResult == DialogResult.OK)
                    {
                        //Enfocar la ubicacion
                        if (buscadorArticuloEnInventarioFrm.VwInventariostock.Idinventarioubicacion > 0)
                        {
                            var rowHandle = gvUbicacion.LocateByValue("Idinventarioubicacion", buscadorArticuloEnInventarioFrm.VwInventariostock.Idinventarioubicacion);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {                                
                                return;
                            }
                            gvUbicacion.FocusedRowHandle = rowHandle;
                            gvUbicacion.SelectRow(rowHandle);
                        }

                        //Enfocar el articulo
                        if (buscadorArticuloEnInventarioFrm.VwInventariostock.Idinventariostock> 0)
                        {
                            var rowHandle = gvArticulosDet.LocateByValue("Idinventariostock", buscadorArticuloEnInventarioFrm.VwInventariostock.Idinventariostock);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {
                                return;
                            }
                            gvArticulosDet.FocusedRowHandle = rowHandle;
                            gvArticulosDet.SelectRow(rowHandle);
                        }

                    }
                    break;
                case "btnSeries":
                    vwInventariostockMntItem = (VwInventariostock)gvArticulosDet.GetFocusedRow();
                    InventarioDetSerieMntFrm inventarioDetSerieMntFrm = new InventarioDetSerieMntFrm(TipoMantenimiento.Modificar, vwInventariostockMntItem, vwInventarioubicacionSel.Ubicacion);
                    inventarioDetSerieMntFrm.ShowDialog();
                    break;
            }
        }
        private Inventariostock AsignarInventarioStock(VwInventariostock vwInventariostockMntItem, int idinventarioubicacion)
        {
            Inventariostock inventariostockMnt = new Inventariostock
            {
                Idinventariostock =  vwInventariostockMntItem.Idinventariostock,
                Idinventarioubicacion = idinventarioubicacion,
                Idarticulo = vwInventariostockMntItem.Idarticulo,
                Cantidadinventario = vwInventariostockMntItem.Cantidadinventario,
                Cantidadajuste = vwInventariostockMntItem.Cantidadajuste,
                Costounisoles = vwInventariostockMntItem.Costounisoles,
                Costototsoles = vwInventariostockMntItem.Costototsoles,
                Costounidolares = vwInventariostockMntItem.Costounidolares,
                Costototdolares = vwInventariostockMntItem.Costototdolares,
                Tipocambio = vwInventariostockMntItem.Tipocambio
            };
            return inventariostockMnt;
        }
        private void ActualizarTotales()
        {

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
                        rSerieinventario.EditValue = vwTipocp.Seriecp;
                        iNumeroinventario.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        iNumeroinventario.EditValue = vwTipocp.Numerocorrelativocp;
                        iNumeroinventario.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        iNumeroinventario.EditValue = vwTipocp.Seriecp;
                        iNumeroinventario.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        iNumeroinventario.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieinventario.EditValue = @"0000";
                iNumeroinventario.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void RegistrarValoresPorDefecto()
        {
            if (iIdresponsable.EditValue != null)
            {
                //Registrar valores por defecto
                int idSucursal = (int)iIdsucursal.EditValue;
                int idEmpleado = (int)iIdresponsable.EditValue;
                const string nombreTipodocMov = "INVENTARIO";
                int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
                int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

                Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                    idCptoOperacionPorDefecto);
            }
        }
        private void btnAddUbicacion_Click(object sender, EventArgs e)
        {

            if (IdEntidadMnt == 0)
            {
                XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            var idAlmacenSel = iIdalmacen.EditValue;
            if (idAlmacenSel == null)
            {
                XtraMessageBox.Show("Seleccione el almacen", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                iIdalmacen.Select();
                return;
            }

            var buscadorUbicacionFrm = new BuscadorUbicacionFrm((int)idAlmacenSel);
            buscadorUbicacionFrm.ShowDialog();
            const string nombreIdDetalle = "Idinventarioubicacion";

            if (buscadorUbicacionFrm.DialogResult == DialogResult.OK &&
                buscadorUbicacionFrm.VwUbicacionSel != null)

            {
                //Asignar al edit value del campo id foraneo
                int cantReferenciasItem = VwInventarioubicacionList.Count(x => x.Idubicacion == buscadorUbicacionFrm.VwUbicacionSel.Idubicacion);
              
                if (cantReferenciasItem > 0)
                {
                    string mensaje = string.Format("La Ubicacion {0} ya fue agregada",
                         buscadorUbicacionFrm.VwUbicacionSel.Nombreubicacion);

                    XtraMessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                    return;
                }

                //Guardar la ubicacion seleccionada
                VwUbicacion vwubicacionItem = buscadorUbicacionFrm.VwUbicacionSel;
                Inventarioubicacion inventarioubicacionMnt = new Inventarioubicacion
                {
                    Idinventario = IdEntidadMnt,
                    Idubicacion = vwubicacionItem.Idubicacion,
                };
                //

                int idinventarioubicacion = Service.SaveInventarioubicacion(inventarioubicacionMnt);
                inventarioubicacionMnt.Idinventarioubicacion = idinventarioubicacion;

                if (idinventarioubicacion > 0)
                {
                    VwInventarioubicacion vwInventarioubicacion = new VwInventarioubicacion
                    {
                        Idinventarioubicacion = idinventarioubicacion,
                        Idinventario = IdEntidadMnt,
                        Ambiente = vwubicacionItem.Ambiente,
                        Columna = vwubicacionItem.Columna,
                        Fila = vwubicacionItem.Fila,
                        Ubicacion = vwubicacionItem.Nombreubicacion,
                        Idubicacion = vwubicacionItem.Idubicacion,
                        Numeroinventario = iNumeroinventario.Text.Trim(),
                        Fechainventario = (DateTime?) iFechainventario.EditValue
                    };

                    VwInventarioubicacionList.Add(vwInventarioubicacion);
                    gvUbicacion.RefreshData();
                    gvUbicacion.BestFitColumns(true);
                    
                    //Enfocar el id generado
                    if (vwInventarioubicacion.Idinventarioubicacion > 0)
                    {
                        var rowHandle = gvUbicacion.LocateByValue(nombreIdDetalle, vwInventarioubicacion.Idinventarioubicacion);
                        if (rowHandle == GridControl.InvalidRowHandle)
                        {
                            return;
                        }                        
                        gvUbicacion.FocusedRowHandle = rowHandle;
                    }
                }

            }
        }
        private void gvUbicacion_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            VwInventarioubicacion vwInventarioubicacion = (VwInventarioubicacion)gvUbicacion.GetRow(e.FocusedRowHandle);
            if (vwInventarioubicacion != null)
            {

                CargarDetalleArticulo(vwInventarioubicacion.Idinventarioubicacion);
            }
        }
        private void btnDelUbicacion_Click(object sender, EventArgs e)
        {
            VwInventarioubicacion vwInventarioubicacion = (VwInventarioubicacion)gvUbicacion.GetFocusedRow();
            if (vwInventarioubicacion != null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                    "Eliminar item", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    if (vwInventarioubicacion.Idinventarioubicacion > 0)
                    {
                        Service.DeleteInventarioubicacion(vwInventarioubicacion.Idinventarioubicacion);
                        VwInventarioubicacionList.Remove(vwInventarioubicacion);

                        gvUbicacion.BeginDataUpdate();
                        gvUbicacion.RefreshData();
                        gvUbicacion.EndDataUpdate();
                        gvUbicacion.BestFitColumns(true);
                    }
                }
            }
        }
        private void gvArticulosDet_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            VwInventariostock vwInventariostockSel = (VwInventariostock) gvArticulosDet.GetFocusedRow();
            if (vwInventariostockSel != null)
            {
                reCaracteristicas.Text = vwInventariostockSel.Caracteristicas;
            }
            else
            {
                reCaracteristicas.Text = string.Empty;
            }

        }
        private void btnCargarSaldosActuales_Click(object sender, EventArgs e)
        {
            var idAlmacen = iIdalmacen.EditValue;
            if (idAlmacen == null)
            {
                XtraMessageBox.Show("Seleccione el almacen", "Atencíón", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdalmacen.Select();
                return;
            }


            if (IdEntidadMnt == 0)
            {
                XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            DateTime fechaInventario = FechaInicialInventarioAnterior;
            const string sqlQuery = "reportes.fn_saldosfisicos";
            object[] parametrosConsulta = {
                fechaInventario,
                SessionApp.DateServer,
                (int)iIdalmacen.EditValue,
                2, //Todos los saldos
                null, //Clasificacion
                null, //Marca
                null //EsActivo
            };

            

            DataTable dtSaldos = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            Almacen almacenSel = Service.GetAlmacen((int)idAlmacen);
            //Agregar ubicacion por defecto
            Inventarioubicacion inventarioubicacionMnt = new Inventarioubicacion
            {
                Idinventario = IdEntidadMnt,
                Idubicacion =  almacenSel.Idubicaciondefecto ?? 0
            };
            //

            int idinventarioubicacion = Service.SaveInventarioubicacion(inventarioubicacionMnt);
            inventarioubicacionMnt.Idinventarioubicacion = idinventarioubicacion;
            if (idinventarioubicacion > 0 && dtSaldos.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataRow item in dtSaldos.Rows)
                {
                        Inventariostock inventariostockMnt = new Inventariostock
                        {
                            Idinventariostock =  0,
                            Idinventarioubicacion = idinventarioubicacion,
                            Idarticulo = Convert.ToInt32(item["idarticulo"]),
                            Cantidadinventario = Convert.ToInt32(item["stock"]),
                            Cantidadajuste = 0m,
                            Costounisoles = 0m,
                            Costototsoles = 0m,
                            Costounidolares = 0m,
                            Costototdolares = 0m,
                            Tipocambio = 0m
                        };

                       Service.SaveInventariostock(inventariostockMnt);
                }
                //Refresacar Detalle
                if (IdEntidadMnt > 0)
                {
                    TraerDatos();
                    CargarDetalle();
                }
                Cursor = Cursors.Default;
                XtraMessageBox.Show("Se cargo los saldos actuales", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnCargarSaldosActuales.Enabled = false;
            }

        }
        private void EstablecerFechasIniciales()
        {
            string condicion = string.Format("idsucursal = '{0}' and cierreinventario = '0' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";
            var inventarioList = Service.GetAllInventario(condicion, orden);
            if (inventarioList != null)
            {
                Inventario inventario = inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    FechaInicialInventarioAnterior = inventario.Fechainventario;
                }
            }           
        }

        private void btnMoverOtraUbicacion_Click(object sender, EventArgs e)
        {
            
            TipoMantenimiento tipoMantenimientoItem = TipoMantenimiento.Modificar;
            VwInventariostock vwInventariostockMntItemAMover = (VwInventariostock)gvArticulosDet.GetFocusedRow();

            if (vwInventariostockMntItemAMover == null)
            {
                return;
            }
            
            InventarioMoverUbicacionMntItemFrm inventarioMoverUbicacionMntItemFrm = new InventarioMoverUbicacionMntItemFrm(tipoMantenimientoItem, vwInventariostockMntItemAMover,(int)iIdalmacen.EditValue);
            inventarioMoverUbicacionMntItemFrm.ShowDialog();

            if (inventarioMoverUbicacionMntItemFrm.DialogResult == DialogResult.OK)
            {
                //Guardar la ubicacion de destino
                VwInventarioubicacion vwInventarioubicacionExiste = VwInventarioubicacionList.FirstOrDefault(x => x.Idubicacion == inventarioMoverUbicacionMntItemFrm.IdUbicacionDestino);
                int idinventarioubicacionAMover;
                if (vwInventarioubicacionExiste != null)
                {
                    idinventarioubicacionAMover = vwInventarioubicacionExiste.Idinventarioubicacion;
                }
                else
                {
                    Inventarioubicacion inventarioubicacionMnt = new Inventarioubicacion
                    {
                        Idinventario = IdEntidadMnt,
                        Idubicacion = inventarioMoverUbicacionMntItemFrm.IdUbicacionDestino,
                    };
                    idinventarioubicacionAMover = Service.SaveInventarioubicacion(inventarioubicacionMnt);
                    inventarioubicacionMnt.Idinventarioubicacion = idinventarioubicacionAMover;
                    //

                    VwUbicacion vwubicacionItem = Service.GetVwUbicacion(inventarioubicacionMnt.Idubicacion);
                    if (idinventarioubicacionAMover > 0)
                    {
                        VwInventarioubicacion vwInventarioubicacion = new VwInventarioubicacion
                        {
                            Idinventarioubicacion = idinventarioubicacionAMover,
                            Idinventario = IdEntidadMnt,
                            Ambiente = vwubicacionItem.Ambiente,
                            Columna = vwubicacionItem.Columna,
                            Fila = vwubicacionItem.Fila,
                            Ubicacion = vwubicacionItem.Nombreubicacion,
                            Idubicacion = vwubicacionItem.Idubicacion,
                            Numeroinventario = iNumeroinventario.Text.Trim(),
                            Fechainventario = (DateTime?)iFechainventario.EditValue
                        };
                        VwInventarioubicacionList.Add(vwInventarioubicacion);
                    }
                }

                //Agregar al articulo la ubicacion por defecto si es que no existe
                Articuloubicacion articuloubicacionExistente =
                    Service.GetArticuloubicacion(
                        x =>
                            x.Idarticulo == vwInventariostockMntItemAMover.Idarticulo &&
                            x.Idubicacion == inventarioMoverUbicacionMntItemFrm.IdUbicacionDestino);
                if (articuloubicacionExistente == null)
                {
                    Articuloubicacion articuloubicacion = new Articuloubicacion
                    {
                        Idarticulo = vwInventariostockMntItemAMover.Idarticulo,
                        Idubicacion = inventarioMoverUbicacionMntItemFrm.IdUbicacionDestino
                    };
                    Service.SaveArticuloubicacion(articuloubicacion);
                }
                //

                gvUbicacion.RefreshData();
                gvUbicacion.BestFitColumns(true);

                //Cambiar la ubicacion 
                Inventariostock inventariostockAMover = Service.GetInventariostock(vwInventariostockMntItemAMover.Idinventariostock);
                inventariostockAMover.Idinventarioubicacion = idinventarioubicacionAMover;
                Service.UpdateInventariostock(inventariostockAMover);

                //Enfocar la ubicacion
                if (idinventarioubicacionAMover > 0)
                {
                    var rowHandleUbicacion = gvUbicacion.LocateByValue("Idinventarioubicacion", idinventarioubicacionAMover);
                    if (rowHandleUbicacion == GridControl.InvalidRowHandle)
                    {
                        return;
                    }
                    gvUbicacion.FocusedRowHandle = rowHandleUbicacion;
                }

                //Enfocar el articulo que se movio
                var rowHandleArticuloMovido = gvArticulosDet.LocateByValue("Idinventariostock", vwInventariostockMntItemAMover.Idinventariostock);
                if (rowHandleArticuloMovido == GridControl.InvalidRowHandle)
                {
                    return;
                }
                gvArticulosDet.FocusedRowHandle = rowHandleArticuloMovido;
                
            }
        }
    }
}