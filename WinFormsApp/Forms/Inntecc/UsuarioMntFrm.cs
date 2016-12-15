using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class UsuarioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public UsuarioFrm FormParent { get; set; }
        public List<VwUsuario> VwUsuarioList { get; set; }
        public List<VwGrupousuarioitem> VwGrupousurioitemsList { get; set; }
        public List<VwAccesoform> VwAccesoformList { get; set; }
        public List<VwAccesoform> VwAccesoformFaltantesList { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Usuario UsuarioMnt { get; set; }
        public UsuarioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, UsuarioFrm formParent)
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
        private void UsuarioMntFrm_Load(object sender, EventArgs e)
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
                    UsuarioMnt = new Usuario();
                    CargarItemsGrupoUsuario();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }
        }
        private void CargarItemsGrupoUsuario()
        {
            Cursor = Cursors.WaitCursor;
            string condicion = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwGrupousurioitemsList = Service.GetAllVwGrupousuarioitem(condicion, "Tituloform");
            gcDetDato.DataSource = VwGrupousurioitemsList;
            gvDetDato.BestFitColumns(true);
            Cursor = Cursors.Default;
        }
        private void CargarReferencias()
        {

            string condicionGrupoUsuario = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdgrupousuario.Properties.DataSource = Service.GetAllGrupousuario(condicionGrupoUsuario, "Nombregrupo");
            iIdgrupousuario.Properties.DisplayMember = "Nombregrupo";
            iIdgrupousuario.Properties.ValueMember = "Idgrupousuario";
            iIdgrupousuario.Properties.BestFitMode = BestFitMode.BestFit;

            string condicionEmpleado = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado(condicionEmpleado, "razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempresa.Properties.DataSource = Service.GetAllEmpresa();
            iIdempresa.Properties.DisplayMember = "Razonsocial";
            iIdempresa.Properties.ValueMember = "Idempresa";
            iIdempresa.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                UsuarioMnt = Service.GetUsuario(IdEntidadMnt);
                iIdgrupousuario.EditValue = UsuarioMnt.Idgrupousuario;
                iNombreusuario.EditValue = UsuarioMnt.Nombreusuario;
                iDescripcionusuario.EditValue = UsuarioMnt.Descripcionusuario;
                iPwdusuario.EditValue = Cryptography.DecryptStringAes(UsuarioMnt.Pwdusuario);
                iSuspendido.EditValue = UsuarioMnt.Suspendido;
                rFecharegistro.EditValue = UsuarioMnt.Fecharegistro;
                iIdempleado.EditValue = UsuarioMnt.Idempleado;
                iIdempresa.EditValue = UsuarioMnt.Idempresa;
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
            gcDetDato.BeginUpdate();
            string where = string.Format("idusuario = {0} ", IdEntidadMnt);
            VwAccesoformList = Service.GetAllVwAccesoform(where, "Tituloform");
            gcDetDato.DataSource = VwAccesoformList;
            gcDetDato.EndUpdate();
            gvDetDato.BestFitColumns();
            gvDetDato.RefreshData();
        }
        private bool Guardar()
        {

            if (!Validaciones()) return false;


            UsuarioMnt.Idgrupousuario = (int)iIdgrupousuario.EditValue;
            UsuarioMnt.Nombreusuario = iNombreusuario.Text.Trim();
            UsuarioMnt.Descripcionusuario = iDescripcionusuario.Text.Trim();
            UsuarioMnt.Pwdusuario = Cryptography.EncryptStringAes(iPwdusuario.Text.Trim());
            UsuarioMnt.Suspendido = (bool)iSuspendido.EditValue;
            UsuarioMnt.Fecharegistro = (DateTime)rFecharegistro.EditValue;
            UsuarioMnt.Idempleado = (int?)iIdempleado.EditValue;
            UsuarioMnt.Idempresa = (int?)iIdempresa.EditValue;

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
                        IdEntidadMnt = Service.SaveUsuario(UsuarioMnt);
                        UsuarioMnt.Idusuario = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        if (IdEntidadMnt > 0)
                        {
                            GuardarDetalle();
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateUsuario(UsuarioMnt);
                        if (IdEntidadMnt > 0)
                        {
                            ActualizarDetalle();
                        }
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
            foreach (var item in VwGrupousurioitemsList)
            {
                Accesoform accesoform = new Accesoform();
                accesoform.Idaccesoform = 0;
                accesoform.Idusuario = IdEntidadMnt;
                accesoform.Idgrupoitem = item.Idgrupoitem;
                accesoform.Permitir = item.Permitir;
                accesoform.Buscar = item.Buscar;
                accesoform.Nuevo = item.Nuevo;
                accesoform.Editar = item.Editar;
                accesoform.Eliminar = item.Eliminar;
                accesoform.Imprimir = item.Imprimir;
                accesoform.Anular = item.Anular;
                Service.SaveAccesoform(accesoform);
            }
        }
        private void ActualizarDetalle()
        {
            gvDetDato.RefreshData();
            foreach (var item in VwAccesoformList.Where(x=>x.DataEntityState == DataEntityState.Modified))
            {
                if (item.Idaccesoform > 0)
                {
                    Accesoform accesoform = Service.GetAccesoform(item.Idaccesoform);
                    accesoform.Permitir = item.Permitir;
                    accesoform.Buscar = item.Buscar;
                    accesoform.Nuevo = item.Nuevo;
                    accesoform.Editar = item.Editar;
                    accesoform.Eliminar = item.Eliminar;
                    accesoform.Imprimir = item.Imprimir;
                    accesoform.Anular = item.Anular;
                    Service.UpdateAccesoform(accesoform);
                }
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
            if (iNombreusuario.Text.Trim().Equals("ADMIN"))
            {
                XtraMessageBox.Show("El nombre de usuario no está permitido.", Resources.titAtencion, MessageBoxButtons.OK,
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
                        Service.DeleteUsuario(IdEntidadMnt);
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
                    TipoMnt = TipoMantenimiento.Nuevo;
                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    UsuarioMnt = null;
                    UsuarioMnt = new Usuario();

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

                        UsuarioMnt = null;
                        UsuarioMnt = new Usuario();
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
                        UsuarioMnt = null;
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
        private void UsuarioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            rFecharegistro.EditValue = DateTime.Now;
            iIdempresa.EditValue = SessionApp.EmpresaSel.Idempresa;
        }
        private void UsuarioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void riSeleccionado_EditValueChanged(object sender, EventArgs e)
        {
            gvDetDato.PostEditor();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CambiarPasswordFrm cambiarPasswordFrm = new CambiarPasswordFrm(IdEntidadMnt);
            cambiarPasswordFrm.ShowDialog();
        }
        private void gvDetDato_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (TipoMnt == TipoMantenimiento.Modificar)
            {
                VwAccesoform vwAccesoformSel = (VwAccesoform)gvDetDato.GetFocusedRow();
                if (vwAccesoformSel != null)
                {
                    vwAccesoformSel.DataEntityState = DataEntityState.Modified;
                }
            }
        }
    }
}