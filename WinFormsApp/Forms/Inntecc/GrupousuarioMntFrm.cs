using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
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
    public partial class GrupousuarioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public GrupousuarioFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Grupousuario GrupousuarioMnt { get; set; }
        
        //Detalle
        public List<VwPaginaitem> VwPaginaitemList { get; set; }

        public List<VwGrupousuarioitem> VwGrupousurioitemsList { get; set; }
        
        public GrupousuarioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, GrupousuarioFrm formParent) 
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

        private void GrupousuarioMntFrm_Load(object sender, EventArgs e)
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
                    GrupousuarioMnt = new Grupousuario();
                    CargarDetallePlantilla();
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

            iIdempresa.Properties.DataSource = Service.GetAllEmpresa();
            iIdempresa.Properties.DisplayMember = "Razonsocial";
            iIdempresa.Properties.ValueMember = "Idempresa";
            iIdempresa.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void TraerDatos()
        {
            try
            {
                GrupousuarioMnt = Service.GetGrupousuario(IdEntidadMnt);
                iNombregrupo.Text = GrupousuarioMnt.Nombregrupo;
                iIdempresa.EditValue = GrupousuarioMnt.Idempresa;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }

        private void CargarDetallePlantilla()
        {
            gcDetDato.BeginUpdate();
            VwPaginaitemList = Service.GetAllVwPaginaitem("idpagina,idpaginaitem");
            gcDetDato.DataSource = VwPaginaitemList;
            gcDetDato.EndUpdate();
            gvDetDato.BestFitColumns();
        }

        private void CargarDetalle()
        {
            gcDetDato.BeginUpdate();
            string where = string.Format("idgrupousuario = {0} ", IdEntidadMnt); 
            VwGrupousurioitemsList = Service.GetAllVwGrupousuarioitem(where,"idpagina");
            gcDetDato.DataSource = VwGrupousurioitemsList;
            gcDetDato.EndUpdate();
            gvDetDato.BestFitColumns();
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            GrupousuarioMnt.Nombregrupo = iNombregrupo.Text.Trim();
            GrupousuarioMnt.Idempresa = (int?) iIdempresa.EditValue;

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
                    IdEntidadMnt = Service.SaveGrupousuario(GrupousuarioMnt);
                    GrupousuarioMnt.Idgrupousuario = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                        if (IdEntidadMnt > 0)
                        {
                            GuardarDetalle();
                        }
                       

                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateGrupousuario(GrupousuarioMnt);
                    ActualizarDetalle();
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

        private void GuardarDetalle()
        {
            foreach (var item in VwPaginaitemList)
            {
                Grupousuarioitem grupousuarioitem = new Grupousuarioitem();
                grupousuarioitem.Idgrupousuario = IdEntidadMnt;
                grupousuarioitem.Idpaginaitem = item.Idpaginaitem;
                grupousuarioitem.Activo = item.Activo;

                Service.SaveGrupousuarioitem(grupousuarioitem);
            }
        }

        private void ActualizarDetalle()
        {
            gvDetDato.RefreshData();
            foreach (var item in VwGrupousurioitemsList)
            {
                Grupousuarioitem grupousuarioitem = Service.GetGrupousuarioitem(item.Idgrupoitem);
               
                grupousuarioitem.Activo = item.Activo;
                Service.UpdateGrupousuarioitem(grupousuarioitem);
            }
        }


        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (iNombregrupo.Text.Trim().Equals("ADMINISTRADORES DEL SISTEMA"))
            {
                XtraMessageBox.Show("El nombre de grupo de usuario no está permitido.", Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                iNombregrupo.Enabled = false;
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
                        Service.DeleteGrupousuario(IdEntidadMnt);
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

                    GrupousuarioMnt = null;
                    GrupousuarioMnt = new Grupousuario(); 

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
                        btnGrabar.Enabled = false;
                        btnGrabarCerrar.Enabled = false;
                        btnGrabarNuevo.Enabled = false;
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

                        GrupousuarioMnt = null;
                        GrupousuarioMnt = new Grupousuario();
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
                        GrupousuarioMnt = null;
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

        private void GrupousuarioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            iIdempresa.EditValue = SessionApp.EmpresaSel.Idempresa;
        }


        private void GrupousuarioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void riActivo_EditValueChanged(object sender, EventArgs e)
        {
            gvDetDato.PostEditor();
        }

        private void gvDetDato_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
          //  VwGrupousuarioitem item = (VwGrupousuarioitem) gvDetDato.GetFocusedRow();
            switch (e.Column.FieldName)
            {
                case "Activo":
                    gvDetDato.UpdateCurrentRow();
                    break;
            }
        }


/*
        private void HabilitarBotonesMnt(bool enabled)
        {
            BarMnt.BeginUpdate();
            foreach (BarItem item in bmMantenimiento.Items)
            {
                item.Enabled = enabled;
            }
            BarMnt.EndUpdate();
            btnCerrar.Enabled = true;
        }
*/

    }
}