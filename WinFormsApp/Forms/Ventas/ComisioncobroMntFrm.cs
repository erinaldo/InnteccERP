using System;
using System.Collections.Generic;
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
    public partial class ComisioncobroMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ComisioncobroFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Comisioncobro ComisioncobroMnt { get; set; }   

        //Detalle
        public List<Comisioncobrodet> ComisioncobrodetList { get; set; }

        public ComisioncobroMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ComisioncobroFrm formParent) 
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
        private void ComisioncobroMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
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
                    ComisioncobroMnt = new Comisioncobro();                    
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }           
        }
        private void CargarReferencias()
        {
            iIdtipocomisioncobro.Properties.DataSource = Service.GetAllTipocomisioncobro("nombretipocomisioncobro");
            iIdtipocomisioncobro.Properties.DisplayMember = "Nombretipocomisioncobro";
            iIdtipocomisioncobro.Properties.ValueMember = "Idtipocomisioncobro";
            iIdtipocomisioncobro.Properties.BestFitMode = BestFitMode.BestFit;

            rIdsucursal.Properties.DataSource = CacheObjects.VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void TraerDatos()
        {
            try
            {
                ComisioncobroMnt = Service.GetComisioncobro(IdEntidadMnt);

                rIdsucursal.EditValue = ComisioncobroMnt.Idsucursal;
                iIdtipocomisioncobro.EditValue = ComisioncobroMnt.Idtipocomisioncobro;
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
            gvDetComision.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string whereDetalle = string.Format("idcomisioncobro = '{0}'", IdEntidadMnt);
            ComisioncobrodetList = Service.GetAllComisioncobrodet(whereDetalle, "idcomisioncobrodet");
            gcDetComision.DataSource = ComisioncobrodetList;
        }

        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            ComisioncobroMnt.Idsucursal = (int)rIdsucursal.EditValue;
            ComisioncobroMnt.Idtipocomisioncobro = (int)iIdtipocomisioncobro.EditValue;


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
                    if (Service.GuardarComisionCobro(TipoMnt, ComisioncobroMnt, ComisioncobrodetList))
                    {
                        IdEntidadMnt = ComisioncobroMnt.Idcomisioncobro;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarComisionCobro(TipoMnt, ComisioncobroMnt, ComisioncobrodetList);
                    //Service.UpdateComisioncobro(ComisioncobroMnt);
                    break;
                }
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

            //if (Service.CodigoArticuloExiste(iCodigoarticulo.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            //{
            //    iCodigoarticulo.EditValue = Service.GetSiguienteCodigoArticulo();
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

                    TipoMnt =TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    ComisioncobroMnt = null;
                    ComisioncobroMnt = new Comisioncobro();

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
                        ComisioncobroMnt = null;
                        DialogResult = DialogResult.OK;
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
        private void ComisioncobroMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ComisioncobroMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bmItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            ComisioncobroMntItemFrm comisioncobroMntItemFrm;
            Comisioncobrodet comisioncobrodetMnt;



            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Asignar el siguiente item
                    comisioncobrodetMnt = new Comisioncobrodet();

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    comisioncobroMntItemFrm = new ComisioncobroMntItemFrm(tipoMantenimientoItem, comisioncobrodetMnt);
   

                    comisioncobroMntItemFrm.ShowDialog();

                    if (comisioncobroMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        ComisioncobrodetList.Add(comisioncobrodetMnt);
                        SumarTotales();
                        if (!gvDetComision.IsLastRow)
                        {
                            gvDetComision.MoveLastVisible();
                            gvDetComision.Focus();
                        }
                    }


                    break;

                case "btnEditItem":
                    if (gvDetComision.RowCount == 0)
                    {
                        break;
                    }


                    comisioncobrodetMnt = (Comisioncobrodet)gvDetComision.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    comisioncobroMntItemFrm = new ComisioncobroMntItemFrm(tipoMantenimientoItem, comisioncobrodetMnt);
                    comisioncobroMntItemFrm.ShowDialog();
                    if (comisioncobroMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetComision.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        comisioncobrodetMnt = (Comisioncobrodet)gvDetComision.GetFocusedRow();
                        comisioncobrodetMnt.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetComision.IsFirstRow)
                        {
                            gvDetComision.MovePrev();
                        }

                        SumarTotales();

                    }
                    break;
            }
            
        }

        private void SumarTotales()
        {
            gvDetComision.RefreshData();
        }
    }
}