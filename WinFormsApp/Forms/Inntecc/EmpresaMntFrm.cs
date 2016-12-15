using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class EmpresaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public EmpresaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Empresa EmpresaMnt { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public List<Estadosocionegocio> EstadosocionegocioList { get; set; }
        public EmpresaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EmpresaFrm formParent) 
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
        private void EmpresaMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            //iFechanacimiento.EditValue = DateTime.Now;

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

                    EmpresaMnt = new Empresa();

                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    break;
            }           
        }
        private void CargarReferencias()
        {
            iIdimpuestopordefecto.Properties.DataSource = Service.GetAllImpuesto();
            iIdimpuestopordefecto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuestopordefecto.Properties.ValueMember = "Idimpuesto";
            iIdimpuestopordefecto.Properties.BestFitMode = BestFitMode.BestFit;

            VwProyectoList = CacheObjects.VwProyectoList;
            iIdproyectopordefecto.Properties.DataSource = VwProyectoList;//VwProyectoList.Where(x => x.Idsucursal == UsuarioAutenticado.SucursalSel.Idsucursal).ToList();
            iIdproyectopordefecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyectopordefecto.Properties.ValueMember = "Idproyecto";
            iIdproyectopordefecto.Properties.BestFitMode = BestFitMode.BestFit;

            EstadosocionegocioList = Service.GetAllEstadosocionegocio("Nombreestadosocionegocio");
            iIdestadosocionegocioinactivo.Properties.DataSource = EstadosocionegocioList;
            iIdestadosocionegocioinactivo.Properties.DisplayMember = "Nombreestadosocionegocio";
            iIdestadosocionegocioinactivo.Properties.ValueMember = "Idestadosocionegocio";
            iIdestadosocionegocioinactivo.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void TraerDatos()
        {
            try
            {
                EmpresaMnt = Service.GetEmpresa(IdEntidadMnt);

                iRazonsocial.EditValue = EmpresaMnt.Razonsocial;
                iRuc.EditValue = EmpresaMnt.Ruc;
                iDireccionfiscal.EditValue = EmpresaMnt.Direccionfiscal;
                iTelefono.EditValue = EmpresaMnt.Telefono;
                iPaginaweb.EditValue = EmpresaMnt.Paginaweb;
                nPorcentajepercepcion.EditValue = EmpresaMnt.Porcentajepercepcion;
                nPorcentajeretencion.EditValue = EmpresaMnt.Porcentajeretencion;
                nImporteretencion.EditValue = EmpresaMnt.Importeretencion;
                iIgnorarstock.EditValue = EmpresaMnt.Ignorarstock;
                iAutoenumerararticulos.EditValue = EmpresaMnt.Autoenumerararticulos;
                iAutoenumerarsocionegocio.EditValue = EmpresaMnt.Autoenumerarsocionegocio;
                iRutaarchivos.EditValue = EmpresaMnt.Rutaarchivos;
                iIdimpuestopordefecto.EditValue = EmpresaMnt.Idimpuestopordefecto;
                iLogo.EditValue = EmpresaMnt.Logo;
                iIdproyectopordefecto.EditValue = EmpresaMnt.Idproyectopordefecto;

                iIdarticulodanio.EditValue = EmpresaMnt.Idarticulodanio;
                iIdarticuloelementodesgaste.EditValue = EmpresaMnt.Idarticuloelementodesgaste;

                CargarArticuloDanio(EmpresaMnt.Idarticulodanio);
                CargarArticuloElemento(EmpresaMnt.Idarticuloelementodesgaste);

                eLimitediasinactividadsocio.EditValue = EmpresaMnt.Limitediasinactividadsocio;
                iIdestadosocionegocioinactivo.EditValue = EmpresaMnt.Idestadosocionegocioinactivo;

                eLimitediasinactividadsocio.EditValue = EmpresaMnt.Limitediasinactividadsocio;
                iIdestadosocionegocioinactivo.EditValue = EmpresaMnt.Idestadosocionegocioinactivo;
                iListaprecioincluyeimpuesto.EditValue = EmpresaMnt.Listaprecioincluyeimpuesto;

            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }

        private void CargarArticuloElemento(int? idarticuloelementodesgaste)
        {
            if (idarticuloelementodesgaste != null)
            {
                VwArticulo vwArticulo = Service.GetVwArticulo((int)idarticuloelementodesgaste);
                if (vwArticulo != null)
                {
                    iIdarticuloelementodesgaste.EditValue = vwArticulo.Idarticulo;
                    beArticuloDesgaste.Text = vwArticulo.Nombrearticulo;
                    rMarcaarticuloDesgaste.EditValue = vwArticulo.Nombremarca;
                    rUnidadmedidaDesgaste.EditValue = vwArticulo.Abrunidadmedida;
                }
            }
        }
        private void CargarArticuloDanio(int? idarticulodanio)
        {
            if (idarticulodanio != null)
            {
                VwArticulo vwArticulo = Service.GetVwArticulo((int)idarticulodanio);
                if (vwArticulo != null)
                {
                    iIdarticulodanio.EditValue = vwArticulo.Idarticulo;
                    beArticuloDanio.Text = vwArticulo.Nombrearticulo;
                    rMarcaarticuloDanio.EditValue = vwArticulo.Nombremarca;
                    rUnidadmedidaDanio.EditValue = vwArticulo.Abrunidadmedida;

                }
            }
        }

        private bool Guardar()
        {
 
            if (!Validaciones()) return false;


            EmpresaMnt.Razonsocial = iRazonsocial.Text.Trim();
            EmpresaMnt.Ruc = iRuc.Text.Trim();
            EmpresaMnt.Direccionfiscal = iDireccionfiscal.Text.Trim();
            EmpresaMnt.Telefono = iTelefono.Text.Trim();
            EmpresaMnt.Paginaweb = iPaginaweb.Text.Trim();
            EmpresaMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
            EmpresaMnt.Porcentajeretencion = (decimal)nPorcentajeretencion.EditValue;
            EmpresaMnt.Importeretencion = (decimal)nImporteretencion.EditValue;
            EmpresaMnt.Ignorarstock = (bool)iIgnorarstock.EditValue;
            EmpresaMnt.Autoenumerararticulos = (bool)iAutoenumerararticulos.EditValue;
            EmpresaMnt.Autoenumerarsocionegocio = (bool)iAutoenumerarsocionegocio.EditValue;
            EmpresaMnt.Rutaarchivos = iRutaarchivos.Text.Trim();
            EmpresaMnt.Idimpuestopordefecto = (int)iIdimpuestopordefecto.EditValue;
            EmpresaMnt.Logo = (byte[]) iLogo.EditValue;
            EmpresaMnt.Idproyectopordefecto = (int?) iIdproyectopordefecto.EditValue;

            EmpresaMnt.Idarticulodanio = (int?)iIdarticulodanio.EditValue;
            EmpresaMnt.Idarticuloelementodesgaste = (int?)iIdarticuloelementodesgaste.EditValue;

            EmpresaMnt.Limitediasinactividadsocio = (int)eLimitediasinactividadsocio.EditValue;
            EmpresaMnt.Idestadosocionegocioinactivo = (int?)iIdestadosocionegocioinactivo.EditValue;
            EmpresaMnt.Listaprecioincluyeimpuesto = (bool) iListaprecioincluyeimpuesto.EditValue;

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
                    IdEntidadMnt = Service.SaveEmpresa(EmpresaMnt);
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateEmpresa(EmpresaMnt);
                    break;
                }

                //Actualizar la empresa al usuario autenticado
                if (EmpresaMnt != null)
                {
                    SessionApp.EmpresaSel = EmpresaMnt;
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

            //int idPersona = TipoMnt == TipoMantenimiento.Nuevo ? 0 : IdEntidadMnt;

            //if (Service.NroDocumentoPersonaExiste(iNrodocentidad.Text.Trim(), idPersona))
            //{
            //    XtraMessageBox.Show("Número de documento ya existe.", "Documento de identidad", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    iNrodocentidad.Focus();
            //    return false;
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

                    EmpresaMnt = null;
                    EmpresaMnt = new Empresa();

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

                        EmpresaMnt = null;
                        EmpresaMnt = new Empresa();

                        ValoresPorDefecto();
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
                        EmpresaMnt = null;
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
        private void EmpresaMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void EmpresaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void cmdAbriImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.tif;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                byte[] data = ByteImageConverter.ToByteArray(img, img.RawFormat);
                iLogo.EditValue = data;
            }
        }

        private void iRutaarchivos_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            iRutaarchivos.EditValue = GetDirectory();
        }
        private string GetDirectory()
        {
            const string messageDirectory = "Seleccione la carpeta donde se guardará los archivos";
            string patchDirectory = null;
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = messageDirectory;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    patchDirectory = dlg.SelectedPath;
                }
            }
            return patchDirectory;
        }

        private void beArticuloDesgaste_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticuloElemento();
                    break;
            }
        }

        private void beArticuloDanio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticuloDanio();
                    break;
            }
        }

        private void BuscarArticuloElemento()
        {
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();

            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticuloelementodesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;
                beArticuloDesgaste.Text = buscadorArticuloInventarioFrm.VwArticuloSel.Nombrearticulo;
                rMarcaarticuloDesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Nombremarca;
                rUnidadmedidaDesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Abrunidadmedida;

            }
        }

        private void BuscarArticuloDanio()
        {
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();

            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulodanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;
                beArticuloDanio.Text = buscadorArticuloInventarioFrm.VwArticuloSel.Nombrearticulo;
                rMarcaarticuloDanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Nombremarca;
                rUnidadmedidaDanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Abrunidadmedida;

            }

        }

    }
}