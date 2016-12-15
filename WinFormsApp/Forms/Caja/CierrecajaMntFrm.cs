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
    public partial class CierrecajaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CierrecajaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cierrecaja CierrecajaMnt { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public List<VwCierrecajadet> VwCierrecajadetList { get; set; }
        private List<VwReciboresumen> VwReciboresumenList { get; set; }
        public DataEntityState DataEntityState { get; set; }
        public CierrecajaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CierrecajaFrm formParent)
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
        private void CierrecajaMntFrm_Load(object sender, EventArgs e)
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            rFecharegistro.EditValue = SessionApp.DateServer;
            iFechacierre.EditValue = SessionApp.DateServer;
            iIdtipomoneda.EditValue = 1; //soles


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


            rFecharegistro.Enabled = false;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            Ejercicio ejercicio = Service.GetEjercicio(x => x.Anioejercicio == SessionApp.EjercicioActual);
            if (ejercicio != null)
            {
                rIdejercicio.EditValue = ejercicio.Idejercicio;
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
                    CierrecajaMnt = new Cierrecaja();
                    CargarDetalle();

                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iFechacierre.Enabled = false;
                    btnImportar.Enabled = false;
                    CargarDetalle();


                    SumarTotales();
                    break;
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
            bsiImportar.Enabled = !enabled;
            btnCtacteCliente.Enabled = !enabled;

            //BarMntItems.BeginUpdate();
            //foreach (BarItem item in bmItems.Items)
            //{
            //    item.Enabled = enabled;
            //}
            //BarMntItems.EndUpdate();

        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            rIdejercicio.Properties.DataSource = Service.GetAllEjercicio("anioejercicio");
            rIdejercicio.Properties.DisplayMember = "Anioejercicio";
            rIdejercicio.Properties.ValueMember = "Idejercicio";
            rIdejercicio.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void TraerDatos()
        {
            try
            {
                CierrecajaMnt = Service.GetCierrecaja(IdEntidadMnt);

                rIdejercicio.EditValue = CierrecajaMnt.Idejercicio;
                rFecharegistro.EditValue = CierrecajaMnt.Fecharegistro;
                iFechacierre.EditValue = CierrecajaMnt.Fechacierre;
                iIdempleado.EditValue = CierrecajaMnt.Idempleado;
                iComentario.EditValue = CierrecajaMnt.Comentario;
                rTotalcierrecaja.EditValue = CierrecajaMnt.Totalcierrecaja;
                rIdejercicio.EditValue = CierrecajaMnt.Idejercicio;
                iIdsucursal.EditValue = CierrecajaMnt.Idsucursal;
                iIdtipomoneda.EditValue = CierrecajaMnt.Idtipomoneda;
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
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            string where = string.Format("idcierrecaja = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwCierrecajadetList = Service.GetAllVwCierrecajadet(where, "idcierrecajadet");
            gcDetalle.DataSource = VwCierrecajadetList;
            gcDetalle.EndUpdate();
            gvDetalle.BestFitColumns();

        }
        public bool Guardar()
        {

            if (!Validaciones()) return false;

            CierrecajaMnt.Fecharegistro = (DateTime)rFecharegistro.EditValue;
            CierrecajaMnt.Fechacierre = (DateTime)iFechacierre.EditValue;
            CierrecajaMnt.Idempleado = (int)iIdempleado.EditValue;
            CierrecajaMnt.Comentario = iComentario.Text.Trim();
            CierrecajaMnt.Totalcierrecaja = (decimal)rTotalcierrecaja.EditValue;
            CierrecajaMnt.Idejercicio = (int)rIdejercicio.EditValue;
            CierrecajaMnt.Idsucursal = (int)iIdsucursal.EditValue;
            CierrecajaMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //RecibocajaMnt.Createdby = IdUsuario;
                    //RecibocajaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //RecibocajaMnt.Modifiedby = IdUsuario;
                    //RecibocajaMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:

                        if (Service.GuardarCierrecaja(TipoMnt, CierrecajaMnt, VwCierrecajadetList))
                        {
                            IdEntidadMnt = CierrecajaMnt.Idcierrecaja;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                            CierrecajaMnt.Idcierrecaja = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }




                        break;
                    case TipoMantenimiento.Modificar:
                        if (Service.GuardarCierrecaja(TipoMnt, CierrecajaMnt, VwCierrecajadetList))
                        {
                            IdEntidadMnt = CierrecajaMnt.Idcierrecaja;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
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
                        Service.DeleteCierrecaja(IdEntidadMnt);
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


                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;

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

                    CierrecajaMnt = null;
                    CierrecajaMnt = new Cierrecaja();

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
                case "btnImportar":
                    if (!Validaciones()) break;
                    CargarResumen();
                    break;

                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        CierrecajaMnt = null;
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
                        ImpresionFormato.FormatoCierreCaja(CierrecajaMnt);
                    }

                    break;
                case "btnImprimirDetalle":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoCierreCajaDetalle(CierrecajaMnt);
                    }

                    break;

                    
            }
        }
        private void CargarResumen()
        {

            DateTime fechacierre = (DateTime)iFechacierre.EditValue;
            var responsable = iIdempleado.EditValue;

            if (fechacierre != null && responsable != null)
            {
                // Cursor = Cursors.WaitCursor;
                const string wherePendientes = @" and fecharecibo 
                                               not in (select a.fechacierre
                                               from caja.vwcierrecaja a)";
                string where =
                    string.Format("fecharecibo = '{0}' and idempleado = {1} and idsucursal = {2} {3}", fechacierre.ToString("yyyy-MM-dd"), (int)iIdempleado.EditValue, (int)iIdsucursal.EditValue, wherePendientes);
                VwReciboresumenList = Service.GetAllVwReciboresumen(where, "idmediopago");
                var cantidadRegistro = VwReciboresumenList.Count();
                if (cantidadRegistro == 0)
                {
                    XtraMessageBox.Show("No hay información para la fecha seleccionada, verifique", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                    iFechacierre.Select();
                    return;
                }

                foreach (var itemRec in VwReciboresumenList)
                {
                    VwCierrecajadet vwCierrecajadet = new VwCierrecajadet();
                    vwCierrecajadet.Fecharegistro = (DateTime)rFecharegistro.EditValue;
                    vwCierrecajadet.Fechacierre = (DateTime)iFechacierre.EditValue;
                    vwCierrecajadet.Idmediopago = itemRec.Idmediopago;
                    vwCierrecajadet.Nombremediopago = itemRec.Nombremediopago;
                    vwCierrecajadet.Idcptooperacion = itemRec.Idcptooperacion;
                    vwCierrecajadet.Nombrecptooperacion = itemRec.Nombrecptooperacion;
                    vwCierrecajadet.Importe = itemRec.Subtotal;
                    VwCierrecajadetList.Add(vwCierrecajadet);

                }
                SumarTotales();
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
        private void CierrecajaMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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

        }
        private void CierrecajaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormParent != null)
            {
                if (SeEliminoObjeto)
                {
                    FormParent.CargarDatosConsulta(FormParent.FiltroConsulta);
                }
                if (SeGuardoObjeto)
                {
                    FormParent.IdEntidadMnt = IdEntidadMnt;
                    FormParent.CargarDatosConsulta(FormParent.FiltroConsulta);
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
            VwCierrecajadet vwRecibodetMnt;
            RecibocajaingresoMntItemFrm recibocajaingresoMntItemFrm;



            switch (e.Item.Name)
            {
                case "btnAddItem":



                    break;

                case "btnEditItem":


                    break;
                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwRecibodetMnt = (VwCierrecajadet)gvDetalle.GetFocusedRow();
                        vwRecibodetMnt.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }
                        SumarTotales();
                    }
                    break;
            }
        }
        public void EstadoModificacionImportacion()
        {

        }
        private void CargarDetalleImprevistos()
        {

        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();

            decimal totalrecibo = VwCierrecajadetList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Importe);
            rTotalcierrecaja.EditValue = totalrecibo;

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);

        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto

        }
        public void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);



        }
        public void CargarDocumentoReferencia()
        {

        }
        private void gvDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleImprevistos();
        }
        public static class ParametrosSocioNegocio
        {
            public static int Idsocionegocio { get; set; }
        }
    }
}