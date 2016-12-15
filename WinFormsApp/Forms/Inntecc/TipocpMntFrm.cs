using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class TipocpMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public TipocpFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Tipocp TipocpMnt { get; set; }
        public List<Tipoformato> TipoformatoList { get; set; }

        public TipocpMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, TipocpFrm formParent) 
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

        private void TipocpMntFrm_Load(object sender, EventArgs e)
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
                    TipocpMnt = new Tipocp();
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

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;


            iIdimpuesto.Properties.DataSource = Service.GetAllImpuesto();
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;


            TipoformatoList = Service.GetAllTipoformato("Nombretipoformato");
            iIdtipoformato.Properties.DataSource = TipoformatoList;
            iIdtipoformato.Properties.DisplayMember = "Nombretipoformato";
            iIdtipoformato.Properties.ValueMember = "Idtipoformato";
            iIdtipoformato.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipocppago.Properties.DataSource = Service.GetAllTipocppago("Nombretipocppago");
            iIdtipocppago.Properties.DisplayMember = "Nombretipocppago";
            iIdtipocppago.Properties.ValueMember = "Idtipocppago";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipodocmov.Properties.DataSource = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                iNumeracionauto.EditValue = null;

                TipocpMnt = Service.GetTipocp(IdEntidadMnt);
                iIdsucursal.EditValue = TipocpMnt.Idsucursal;
                rCodigotipocp.EditValue = TipocpMnt.Codigotipocp;
                iIdtipoformato.EditValue = TipocpMnt.Idtipoformato;
                iTieneimpuesto.EditValue = TipocpMnt.Tieneimpuesto;
                iIdimpuesto.EditValue = TipocpMnt.Idimpuesto;
                iIdtipocppago.EditValue = TipocpMnt.Idtipocppago;
                iIdtipodocmov.EditValue = TipocpMnt.Idtipodocmov;
                iSeriecp.EditValue = TipocpMnt.Seriecp;
                eNumerocorrelativocp.EditValue = TipocpMnt.Numerocorrelativocp;
                iNumeracionauto.EditValue = TipocpMnt.Numeracionauto;
                eMaxnumeroitems.EditValue = TipocpMnt.Maxnumeroitems;
                iEsactivo.EditValue = TipocpMnt.Esactivo;
                iNombrereporte.EditValue = TipocpMnt.Nombrereporte.Trim();
                iTiporeporteador.SelectedIndex = TipocpMnt.Tiporeporteador;
                iEnumerarporsocionegocio.EditValue = TipocpMnt.Enumerarporsocionegocio;
                iRequierenumerorucvalido.EditValue = TipocpMnt.Requierenumerorucvalido;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            TipocpMnt.Idsucursal = (int)iIdsucursal.EditValue;
            TipocpMnt.Codigotipocp = rCodigotipocp.Text.Trim();
            TipocpMnt.Idtipoformato = (int?)iIdtipoformato.EditValue;
            TipocpMnt.Tieneimpuesto = (bool)iTieneimpuesto.EditValue;
            TipocpMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            TipocpMnt.Idtipocppago = (int?)iIdtipocppago.EditValue;
            TipocpMnt.Idtipodocmov = (int)iIdtipodocmov.EditValue;
            TipocpMnt.Seriecp = iSeriecp.Text.Trim();
            TipocpMnt.Numerocorrelativocp = (int)eNumerocorrelativocp.EditValue;
            TipocpMnt.Numeracionauto = (bool)iNumeracionauto.EditValue;
            TipocpMnt.Maxnumeroitems = (int)eMaxnumeroitems.EditValue;
            TipocpMnt.Esactivo = (bool)iEsactivo.EditValue;
            TipocpMnt.Nombrereporte = iNombrereporte.Text.Trim();
            TipocpMnt.Tiporeporteador = iTiporeporteador.SelectedIndex;
            TipocpMnt.Enumerarporsocionegocio = (bool)iEnumerarporsocionegocio.EditValue;
            TipocpMnt.Requierenumerorucvalido = (bool) iRequierenumerorucvalido.EditValue;
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
                    IdEntidadMnt = Service.SaveTipocp(TipocpMnt);
                    TipocpMnt.Idtipocppago = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateTipocp(TipocpMnt);
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

            if (Service.CodigoTipoCpExiste(rCodigotipocp.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                rCodigotipocp.EditValue = Service.GetSiguienteCodigoTipoCp();
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
                        Service.DeleteTipocp(IdEntidadMnt);
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

                    TipocpMnt = null;
                    TipocpMnt = new Tipocp();

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

                        TipocpMnt = null;
                        TipocpMnt = new Tipocp();
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
                        TipocpMnt = null;
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
        private void TipocpMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            rCodigotipocp.EditValue = Service.GetSiguienteCodigoTipoCp();
            iEsactivo.Checked = true;
            iTieneimpuesto.Checked = true;
            iIdimpuesto.EditValue = 1;
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iNumeracionauto.EditValue = null;
            iNumeracionauto.EditValue = false;
            //eSeriecp.Enabled = false;
            //eNumerocorrelativocp.Enabled = false;

            iTiporeporteador.SelectedIndex = 0; //FastReport

        }
        private void TipocpMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void iTieneimpuesto_CheckedChanged(object sender, EventArgs e)
        {
            iIdimpuesto.Enabled = iTieneimpuesto.Checked;
        }
        private void iIdtipoformato_EditValueChanged(object sender, EventArgs e)
        {
            var idTipoFormatoSel = (int?)iIdtipoformato.EditValue;
            if (idTipoFormatoSel != null)
            {
                var tipoFormatoSel = TipoformatoList.FirstOrDefault(t => t.Idtipoformato.Equals(idTipoFormatoSel));
                rAbreviaturaFormato.EditValue = tipoFormatoSel != null ? tipoFormatoSel.Abreviaturatipoformato : string.Empty;
            }
            else
            {
                rAbreviaturaFormato.EditValue = string.Empty;
            }
        }
        private void iIdtipoformato_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            var tipoFormatoMntFrm = new TipoformatoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            tipoFormatoMntFrm.ShowDialog();
            if (tipoFormatoMntFrm.IdEntidadMnt > 0)
            {
                Tipoformato tipoFormato = tipoFormatoMntFrm.TipoformatoMnt;
                if (tipoFormato.Idtipoformato > 0)
                {
                    TipoformatoList.Add(tipoFormato);
                    e.Cancel = false;
                    e.NewValue = tipoFormato.Idtipoformato;
                }
            }
        }
        private void iNombrereporte_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = DialogResult.None;
            switch (iTiporeporteador.SelectedIndex)
            {
                case 0: //FastReport
                    openFile.Filter = @"Archivos de reporte (.frx)|*.frx";
                    openFile.FilterIndex = 1;
                    openFile.Title = @"Seleccionar el archivo de reporte";
                    result = openFile.ShowDialog();
                    break;
                case 1: //DevExpress
                    openFile.Filter = @"Archivos de reporte (.repx)|*.repx";
                    openFile.FilterIndex = 1;
                    openFile.Title = @"Seleccionar el archivo de reporte";
                    result = openFile.ShowDialog();
                    break;
            }

            if (result == DialogResult.OK)
            {
                iNombrereporte.EditValue = Path.GetFileName(openFile.FileName);
            }


        }
        private void iNumeracionauto_EditValueChanged(object sender, EventArgs e)
        {
            var estado = iNumeracionauto.EditValue;
            if (estado != null)
            {
                iSeriecp.Enabled = (bool)estado;
                eNumerocorrelativocp.Enabled = (bool)estado;

            }
        }


    }
}