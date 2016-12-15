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
    public partial class PlantillahistoriaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public PlantillahistoriaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Plantillahistoria PlantillahistoriaMnt { get; set; }

        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwPlantillahistoriadet> VwPlantillahistoriadetList { get; set; }
        public PlantillahistoriaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, PlantillahistoriaFrm formParent) 
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

        private void PlantillahistoriaMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
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
                    PlantillahistoriaMnt = new Plantillahistoria();
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


            iIdtipohistoria.Properties.DataSource = Service.GetAllTipohistoria("Nombretipohistoria");
            iIdtipohistoria.Properties.DisplayMember = "Nombretipohistoria";
            iIdtipohistoria.Properties.ValueMember = "Idtipohistoria";
            iIdtipohistoria.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void TraerDatos()
        {
            try
            {
                PlantillahistoriaMnt = Service.GetPlantillahistoria(IdEntidadMnt);


                iIdtipohistoria.EditValue = PlantillahistoriaMnt.Idtipohistoria;

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
            string where = string.Format("idplantillahistoria = '{0}'", IdEntidadMnt);
            gvDetalle.BeginUpdate();

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwPlantillahistoriadetList = new List<VwPlantillahistoriadet>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwPlantillahistoriadetList = Service.GetAllVwPlantillahistoriadet(where, "Nombrecategoriaitem,Ordenitemhistoria");
                    break;
            }

            gcDetalle.DataSource = VwPlantillahistoriadetList;
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            PlantillahistoriaMnt.Idtipohistoria = (int?)iIdtipohistoria.EditValue;

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
                    IdEntidadMnt = Service.SavePlantillahistoria(PlantillahistoriaMnt);
                    PlantillahistoriaMnt.Idplantillahistoria = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdatePlantillahistoria(PlantillahistoriaMnt);
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
                        Service.DeletePlantillahistoria(IdEntidadMnt);
                        SeEliminoObjeto = true;
                        Close();
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

                    PlantillahistoriaMnt = null;
                    PlantillahistoriaMnt = new Plantillahistoria(); 

                    btnGrabar.Enabled = true;
                    btnGrabarCerrar.Enabled = true;
                    btnGrabarNuevo.Enabled = true;      

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);
                    break;

                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        btnGrabar.Enabled = true;
                        btnGrabarCerrar.Enabled = true;
                        btnGrabarNuevo.Enabled = true;
                        TipoMnt = TipoMantenimiento.Modificar;

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
                        Close();
                    }                    
                    break;
                case "btnGrabarNuevo":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        LimpiarCampos();
                        TipoMnt = TipoMantenimiento.Nuevo;
                        pkIdEntidad.EditValue = 0;
                        IdEntidadMnt = 0;

                        btnEliminar.Enabled = false;
                        btnActualizar.Enabled = false;

                        ValoresPorDefecto();

                        PlantillahistoriaMnt = null;
                        PlantillahistoriaMnt = new Plantillahistoria();
                    }

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);

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
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        Close();
                    }
                    else
                    {
                        PlantillahistoriaMnt = null;
                        Close();
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

        private void PlantillahistoriaMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ValoresPorDefecto()
        {
            
        }

        private void PlantillahistoriaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bmItemsPlantilla_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            PlantillahistoriaMntItemFrm plantillahistoriaMntItemFrm;
            VwPlantillahistoriadet vwPlantillahistoriadet;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }

                    //Asignar el siguiente item
                    VwPlantillahistoriadet sgtItem = VwPlantillahistoriadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Ordenitemplantilla)
                        .FirstOrDefault();


                    vwPlantillahistoriadet = new VwPlantillahistoriadet();
                    vwPlantillahistoriadet.Idplantillahistoria = IdEntidadMnt;
                    vwPlantillahistoriadet.Ordenitemplantilla = sgtItem == null ? 1 : sgtItem.Ordenitemplantilla + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    plantillahistoriaMntItemFrm = new PlantillahistoriaMntItemFrm(tipoMantenimientoItem, vwPlantillahistoriadet);
                    plantillahistoriaMntItemFrm.ShowDialog();

                    if (plantillahistoriaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Plantillahistoriadet plantillahistoriadet = AsignarPlantillahistoriadet(vwPlantillahistoriadet);
                        int idPlantillahistoriadet = Service.SavePlantillahistoriadet(plantillahistoriadet);
                        if (idPlantillahistoriadet > 0)
                        {
                            vwPlantillahistoriadet.Idplantillahistoriadet = idPlantillahistoriadet;
                            VwPlantillahistoriadetList.Add(vwPlantillahistoriadet);
                            ActualizarDetalle();
                            if (!gvDetalle.IsLastRow)
                            {
                                gvDetalle.MoveLastVisible();
                                gvDetalle.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    vwPlantillahistoriadet = (VwPlantillahistoriadet)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    plantillahistoriaMntItemFrm = new PlantillahistoriaMntItemFrm(tipoMantenimientoItem, vwPlantillahistoriadet);
                    plantillahistoriaMntItemFrm.ShowDialog();

                    if (plantillahistoriaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Plantillahistoriadet plantillahistoriadet = AsignarPlantillahistoriadet(vwPlantillahistoriadet);
                        if (plantillahistoriadet.Idplantillahistoriadet > 0)
                        {
                            Service.UpdatePlantillahistoriadet(plantillahistoriadet);
                            ActualizarDetalle();
                        }
                    }


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
                        vwPlantillahistoriadet = (VwPlantillahistoriadet)gvDetalle.GetFocusedRow();
                        if (vwPlantillahistoriadet != null && vwPlantillahistoriadet.Idplantillahistoriadet > 0)
                        {
                            Service.DeletePlantillahistoriadet(vwPlantillahistoriadet.Idplantillahistoriadet);
                            vwPlantillahistoriadet.DataEntityState = DataEntityState.Deleted;
                            if (!gvDetalle.IsFirstRow)
                            {
                                gvDetalle.MovePrev();
                            }
                            ActualizarDetalle();
                        }
                    }
                    break;
                case "btnAddCategoria":
                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    PlantillahistoriaCategoriaMntItemFrm plantillahistoriaCategoriaMntItemFrm = new PlantillahistoriaCategoriaMntItemFrm(TipoMantenimiento.Nuevo,  VwPlantillahistoriadetList, this);
                    plantillahistoriaCategoriaMntItemFrm.ShowDialog(this);

                    break;
            }
        }

        public void ActualizarDetalle()
        {

            gvDetalle.BeginUpdate();
            gvDetalle.RefreshData();
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        public Plantillahistoriadet AsignarPlantillahistoriadet(VwPlantillahistoriadet vwPlantillahistoriadet)
        {

            Plantillahistoriadet plantillahistoriadet = new Plantillahistoriadet
            {
			    Idplantillahistoriadet = vwPlantillahistoriadet.Idplantillahistoriadet,
			    Idplantillahistoria = vwPlantillahistoriadet.Idplantillahistoria,
			    Iditemhistoria = vwPlantillahistoriadet.Iditemhistoria,
                Ordenitemplantilla = vwPlantillahistoriadet.Ordenitemplantilla

            };
            return plantillahistoriadet;
        }




    }
}