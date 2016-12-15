using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    public partial class BaseMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public BaseFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Persona PersonaMnt { get; set; }

        //Detalle
        public List<VwPersonacontacto> VwPersonacontactoList { get; set; }
        public BaseMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, BaseFrm formParent)
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
            WinFormUtils.SetEnterMoveNextControl(tpPersona, true);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;
        }
        private void BaseMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iIdtipodocent.EditValue = 2;//RUC
            iIdtipodocent2.EditValue = 2;//DNI
            iSexo.EditValue = @"N";
            iIdpais.EditValue = 604; //Perú
            iNrodocentidad2.EditValue = @"00000000";
            iNrodocentidad.EditValue = @"00000000";
            iIddistrito.EditValue = 331; //Arequipa

            iDireccionfiscal.EditValue = @"-";
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
                    PersonaMnt = new Persona();
                    CargarDetalle();
                    iApepaterno.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    btnConsultaRuc.Visible = false;
                    btnConsultaReniec.Visible = false;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();

                    break;
            }
            iApepaterno.Focus();
        }
        private void CargarReferencias()
        {

            iIdtipodocent.Properties.DataSource = CacheObjects.TipodocentidadList;
            iIdtipodocent.Properties.DisplayMember = "Nombretipodocentidad";
            iIdtipodocent.Properties.ValueMember = "Idtipodocent";
            iIdtipodocent.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipodocent2.Properties.DataSource = CacheObjects.TipodocentidadList;
            iIdtipodocent2.Properties.DisplayMember = "Nombretipodocentidad";
            iIdtipodocent2.Properties.ValueMember = "Idtipodocent";
            iIdtipodocent2.Properties.BestFitMode = BestFitMode.BestFit;

            iSexo.Properties.DataSource = CacheObjects.SexoPersonaList;
            iSexo.Properties.DisplayMember = "DescripcionTipoSexo";
            iSexo.Properties.ValueMember = "TipoSexo";

            iIddistrito.Properties.DataSource = CacheObjects.UbigeoList;
            iIddistrito.Properties.DisplayMember = "Nombreubigeo";
            iIddistrito.Properties.ValueMember = "Iddistrito";
            iIddistrito.Properties.BestFitMode = BestFitMode.BestFit;

            iIdpais.Properties.DataSource = CacheObjects.PaisList;
            iIdpais.Properties.DisplayMember = "Nombrepais";
            iIdpais.Properties.ValueMember = "Idpais";
            iIdpais.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                PersonaMnt = Service.GetPersona(IdEntidadMnt);

                //iCodigo.EditValue = PersonaMnt.Codigo.Trim();
                iApepaterno.EditValue = PersonaMnt.Apepaterno.Trim();
                iApematerno.EditValue = PersonaMnt.Apematerno.Trim();
                iNombrespersona.EditValue = PersonaMnt.Nombrespersona.Trim();
                rRazonsocial.EditValue = PersonaMnt.Razonsocial.Trim();
                iIdtipodocent.EditValue = PersonaMnt.Idtipodocent;
                iNrodocentidad.EditValue = PersonaMnt.Nrodocentidad.Trim();
                iIddistrito.EditValue = PersonaMnt.Iddistrito;
                iDireccionfiscal.EditValue = PersonaMnt.Direccionfiscal.Trim();
                iTelefono.EditValue = PersonaMnt.Telefono.Trim();
                iMovil.EditValue = PersonaMnt.Movil.Trim();
                iEmailcliente.EditValue = PersonaMnt.Email.Trim();
                //iFechanacimiento.EditValue = PersonaMnt.Fechanacimiento;
                iComentario.EditValue = PersonaMnt.Comentario.Trim();
                iSexo.EditValue = PersonaMnt.Sexo;
                iReferencia.EditValue = PersonaMnt.Referencia.Trim();
                iIdpais.EditValue = PersonaMnt.Idpais;
                iNombrecomercial.EditValue = PersonaMnt.Nombrecomercial;

                iIdtipodocent2.EditValue = PersonaMnt.Idtipodocent2;
                iNrodocentidad2.EditValue = PersonaMnt.Nrodocentidad2;
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
            string where = string.Format("idpersona = '{0}'", IdEntidadMnt);
            gcDetDato.BeginUpdate();
            VwPersonacontactoList = Service.GetAllVwPersonacontacto(where, "idpersonacontacto");
            gcDetDato.DataSource = VwPersonacontactoList;
            gvDetDato.BestFitColumns();
            gcDetDato.EndUpdate();
        }
        private bool Guardar()
        {

            if (!Validaciones()) return false;

            PersonaMnt.Codigo = null;//iCodigo.Text.Trim();
            PersonaMnt.Apepaterno = iApepaterno.Text.Trim();
            PersonaMnt.Apematerno = iApematerno.Text.Trim();
            PersonaMnt.Nombrespersona = iNombrespersona.Text.Trim();
            PersonaMnt.Razonsocial = rRazonsocial.Text.Trim();
            PersonaMnt.Idtipodocent = (int)iIdtipodocent.EditValue;
            PersonaMnt.Nrodocentidad = iNrodocentidad.Text.Trim();
            PersonaMnt.Iddistrito = (int)iIddistrito.EditValue;
            PersonaMnt.Direccionfiscal = iDireccionfiscal.Text.Trim();
            PersonaMnt.Telefono = iTelefono.Text.Trim();
            PersonaMnt.Movil = iMovil.Text.Trim();
            PersonaMnt.Email = iEmailcliente.Text.Trim();
            PersonaMnt.Fechanacimiento = null;//(DateTime)iFechanacimiento.EditValue;
            PersonaMnt.Comentario = iComentario.Text.Trim();
            PersonaMnt.Sexo = (string)iSexo.EditValue;
            PersonaMnt.Referencia = iReferencia.Text.Trim();
            PersonaMnt.Idpais = (int)iIdpais.EditValue;
            PersonaMnt.Nombrecomercial = iNombrecomercial.Text.Trim();
            PersonaMnt.Idtipodocent2 = (int?)iIdtipodocent2.EditValue;
            PersonaMnt.Nrodocentidad2 = iNrodocentidad2.Text.Trim();

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
                        IdEntidadMnt = Service.SavePersona(PersonaMnt);
                        PersonaMnt.Idpersona = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;

                        //Crea conflicto en crear socio
                        //GuardarSocioDeNegocio(IdEntidadMnt);

                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdatePersona(PersonaMnt);
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

        private void GuardarSocioDeNegocio(int idPersona)
        {
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(
                0,
                TipoMantenimiento.Nuevo,
                null,
                null,
                Convert.ToInt32(idPersona));


            SuspendLayout();

            socionegocioMntFrm.SuspendLayout();
            socionegocioMntFrm.WindowState = FormWindowState.Minimized;
            socionegocioMntFrm.Show();
            
            socionegocioMntFrm.Hide();
            socionegocioMntFrm.ResumeLayout();

            if (socionegocioMntFrm.Guardar())
            {
                int idSocioNegocioRegistrado = socionegocioMntFrm.IdEntidadMnt;
                if (idSocioNegocioRegistrado > 0)
                {
                    socionegocioMntFrm.Close();
                }
            }

            ResumeLayout();

        }

        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpPersona, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!iNrodocentidad.Text.Trim().Equals("00000000"))
            {
                int idPersona = TipoMnt == TipoMantenimiento.Nuevo ? 0 : IdEntidadMnt;

                if (Service.NroDocumentoPersonaExiste(iNrodocentidad.Text.Trim(), idPersona))
                {
                    XtraMessageBox.Show("El nombre ó Número de documento ya existe, verifique.", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNrodocentidad.Focus();
                    return false;
                }
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

                    PersonaMnt = null;
                    PersonaMnt = new Persona();

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
                        PersonaMnt = null;
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
        private void BaseMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }
        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }
        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(this, readOnly);
        }
        private void EstablecerRazonSocial()
        {
            string nombreCompleto = string.Format("{0} {1} {2}", iApepaterno.Text.Trim(), iApematerno.Text.Trim(), iNombrespersona.Text.Trim());
            rRazonsocial.Text = Regex.Replace(nombreCompleto, @"\s+", " ").Trim();
        }
        private void iPatPer_EditValueChanged(object sender, EventArgs e)
        {
            EstablecerRazonSocial();
        }
        private void iMatPer_EditValueChanged(object sender, EventArgs e)
        {
            EstablecerRazonSocial();
        }
        private void iNomPer_EditValueChanged(object sender, EventArgs e)
        {
            EstablecerRazonSocial();
        }
        private void BaseMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bmItemsDatoContacto_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            BaseMntItemFrm baseMntItemFrm;
            var vwPersonacontactoMnt = new VwPersonacontacto();

            Personacontacto personacontactoMnt;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwPersonacontactoMnt.Nombrepersona = rRazonsocial.Text;

                    baseMntItemFrm = new BaseMntItemFrm(tipoMantenimientoItem, vwPersonacontactoMnt);
                    baseMntItemFrm.ShowDialog();

                    if (baseMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwPersonacontactoList.Add(vwPersonacontactoMnt);

                        personacontactoMnt = new Personacontacto
                        {
                            Idpersona = IdEntidadMnt,
                            Idtipocontacto = vwPersonacontactoMnt.Idtipocontacto,
                            Datocontacto = vwPersonacontactoMnt.Datocontacto
                        };

                        Service.SavePersonacontacto(personacontactoMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwPersonacontactoMnt = (VwPersonacontacto)gvDetDato.GetFocusedRow();

                    if (vwPersonacontactoMnt == null)
                    {
                        break;
                    }
                    vwPersonacontactoMnt.Nombrepersona = rRazonsocial.Text;
                    baseMntItemFrm = new BaseMntItemFrm(tipoMantenimientoItem, vwPersonacontactoMnt);
                    baseMntItemFrm.ShowDialog();

                    if (baseMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        personacontactoMnt = new Personacontacto
                        {
                            Idpersonacontacto = vwPersonacontactoMnt.Idpersonacontacto,
                            Idpersona = IdEntidadMnt,
                            Idtipocontacto = vwPersonacontactoMnt.Idtipocontacto,
                            Datocontacto = vwPersonacontactoMnt.Datocontacto
                        };

                        Service.UpdatePersonacontacto(personacontactoMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnDelItem":
                    int idpersonacontacto = Convert.ToInt32(gvDetDato.GetRowCellValue(gvDetDato.FocusedRowHandle, "Idpersonacontacto"));

                    if (idpersonacontacto > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeletePersonacontacto(idpersonacontacto);

                            CargarDetalle();
                        }
                    }
                    break;
            }
        }
        private void btnConsultaRuc_Click(object sender, EventArgs e)
        {


            ConsultaSunatFrm consultaSunatFrm = new ConsultaSunatFrm();
            consultaSunatFrm.ShowDialog();
            if (consultaSunatFrm.DialogResult == DialogResult.OK && consultaSunatFrm.Contribuyente != null)
            {
                iApepaterno.EditValue = string.Empty;
                iApematerno.EditValue = string.Empty;
                iNombrespersona.EditValue = string.Empty;

                //TipoNombreImportacion:1 Apellidos o razon social
                //TipoNombreImportacion:2 Nombre comercial

                iNombrespersona.EditValue = consultaSunatFrm.Contribuyente.RazonSocial.Trim();
                iNombrecomercial.EditValue = consultaSunatFrm.Contribuyente.NombreComercial.Trim();
                iNrodocentidad.EditValue = consultaSunatFrm.Contribuyente.Ruc;
                iDireccionfiscal.EditValue = consultaSunatFrm.Contribuyente.Direccion;
                iReferencia.EditValue = consultaSunatFrm.Contribuyente.ReferenciaDireccion;
                iIddistrito.EditValue = consultaSunatFrm.IdDistrito;
                iIdtipodocent.EditValue = 4; //Ruc
            }
        }
        private void btnConsultaReniec_Click(object sender, EventArgs e)
        {
            ConsultaReniecFrm consultaReniecFrm = new ConsultaReniecFrm();
            consultaReniecFrm.ShowDialog();
            if (consultaReniecFrm.DialogResult == DialogResult.OK && consultaReniecFrm.PersonaReniec != null)
            {
                iApepaterno.EditValue = string.Empty;
                iApematerno.EditValue = string.Empty;
                iNombrespersona.EditValue = string.Empty;

                iApepaterno.EditValue = consultaReniecFrm.PersonaReniec.ApePaterno;
                iApematerno.EditValue = consultaReniecFrm.PersonaReniec.ApeMaterno;
                iNombrespersona.EditValue = consultaReniecFrm.PersonaReniec.Nombres;
                iNrodocentidad.EditValue = consultaReniecFrm.Dni;
                iIdtipodocent.EditValue = 2; //DNI
                //iDireccionfiscal.EditValue = string.Empty;
                //iIddistrito.EditValue = null;
                iSexo.Select();
                iSexo.Focus();
            }
        }
        private void btnConsultaReniec2_Click(object sender, EventArgs e)
        {
            ConsultaReniecFrm consultaReniecFrm = new ConsultaReniecFrm();
            consultaReniecFrm.ShowDialog();
            if (consultaReniecFrm.DialogResult == DialogResult.OK && consultaReniecFrm.PersonaReniec != null)
            {

                iApepaterno.EditValue = consultaReniecFrm.PersonaReniec.ApePaterno;
                iApematerno.EditValue = consultaReniecFrm.PersonaReniec.ApeMaterno;
                iNombrespersona.EditValue = consultaReniecFrm.PersonaReniec.Nombres;
                iNrodocentidad2.EditValue = consultaReniecFrm.Dni;
                iIdtipodocent2.EditValue = 2; //DNI
                iIdpais.Select();
            }
        }

    }
}