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
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class CptooperacionMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CptooperacionFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cptooperacion CptooperacionMnt { get; set; }
        public List<Tipoformato> TipoformatoList { get; set; }

        public CptooperacionMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CptooperacionFrm formParent) 
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

        private void CptooperacionMntFrm_Load(object sender, EventArgs e)
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
                    CptooperacionMnt = new Cptooperacion();
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


            iIdtipodocmov.Properties.DataSource = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipooperacion.Properties.DataSource = Service.GetAllTipooperacion("Nombretipooperacion");
            iIdtipooperacion.Properties.DisplayMember = "Nombretipooperacion";
            iIdtipooperacion.Properties.ValueMember = "Idtipooperacion";
            iIdtipooperacion.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                CptooperacionMnt = Service.GetCptooperacion(IdEntidadMnt);
                iIdsucursal.EditValue = CptooperacionMnt.Idsucursal;
                rCodigocptooperacion.EditValue = CptooperacionMnt.Codigocptooperacion;
                iIdtipodocmov.EditValue = CptooperacionMnt.Idtipodocmov;
                iNombrecptooperacion.EditValue = CptooperacionMnt.Nombrecptooperacion;
                iIdtipooperacion.EditValue = CptooperacionMnt.Idtipooperacion;
                iGenerasalida.EditValue = CptooperacionMnt.Generasalida;
                iTienecpcaja.EditValue = CptooperacionMnt.Tienecpcaja;
                iTienecpcobrarpagar.EditValue = CptooperacionMnt.Tienecpcobrarpagar;
                iEsactivo.EditValue = CptooperacionMnt.Esactivo;
                iTieneordenservicio.EditValue = CptooperacionMnt.Tieneordenservicio;
                iEscajachica.EditValue = CptooperacionMnt.Escajachica;
                iGeneradevolucion.EditValue = CptooperacionMnt.Generadevolucion;
                iValidarvalorunitario.EditValue = CptooperacionMnt.Validarvalorunitario;
                iValidarstock.EditValue = CptooperacionMnt.Validarstock;
                iGeneratrasladoentrealmacenes.EditValue = CptooperacionMnt.Generatrasladoentrealmacenes;
                iGeneraentrada.EditValue = CptooperacionMnt.Generaentrada;
                iTieneordencompra.EditValue = CptooperacionMnt.Tieneordencompra;
                iBuscarsoloitemservicio.EditValue = CptooperacionMnt.Buscarsoloitemservicio;
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

            CptooperacionMnt.Idsucursal = (int)iIdsucursal.EditValue;
            CptooperacionMnt.Codigocptooperacion = rCodigocptooperacion.Text.Trim();
            CptooperacionMnt.Idtipodocmov = (int)iIdtipodocmov.EditValue;
            CptooperacionMnt.Nombrecptooperacion = iNombrecptooperacion.Text.Trim();
            CptooperacionMnt.Idtipooperacion = (int?)iIdtipooperacion.EditValue;
            CptooperacionMnt.Tienecpcaja = (bool)iTienecpcaja.EditValue;
            CptooperacionMnt.Generasalida = (bool)iGenerasalida.EditValue;
            CptooperacionMnt.Tienecpcobrarpagar = (bool)iTienecpcobrarpagar.EditValue;
            CptooperacionMnt.Esactivo = (bool)iEsactivo.EditValue;
            CptooperacionMnt.Tieneordenservicio = (bool)iTieneordenservicio.EditValue;
            CptooperacionMnt.Escajachica = (bool)iEscajachica.EditValue;
            CptooperacionMnt.Generadevolucion = (bool)iGeneradevolucion.EditValue;
            CptooperacionMnt.Validarvalorunitario = (bool)iValidarvalorunitario.EditValue;
            CptooperacionMnt.Validarstock = (bool)iValidarstock.EditValue;
            CptooperacionMnt.Generatrasladoentrealmacenes = (bool) iGeneratrasladoentrealmacenes.EditValue;
            CptooperacionMnt.Generaentrada = (bool)iGeneraentrada.EditValue;
            CptooperacionMnt.Tieneordencompra = (bool)iTieneordencompra.EditValue;
            CptooperacionMnt.Buscarsoloitemservicio = (bool)iBuscarsoloitemservicio.EditValue;

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
                    IdEntidadMnt = Service.SaveCptooperacion(CptooperacionMnt);
                    CptooperacionMnt.Idcptooperacion = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateCptooperacion(CptooperacionMnt);
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

            if (Service.CodigoCptooperacionExiste(rCodigocptooperacion.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
           {
                rCodigocptooperacion.EditValue = Service.GetSiguienteCodigoCptooperacion();
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
                        Service.DeleteCptooperacion(IdEntidadMnt);
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

                    CptooperacionMnt = null;
                    CptooperacionMnt = new Cptooperacion();

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

                        CptooperacionMnt = null;
                        CptooperacionMnt = new Cptooperacion();
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
                        CptooperacionMnt = null;
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
        private void CptooperacionMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            rCodigocptooperacion.EditValue = Service.GetSiguienteCodigoCptooperacion();
            iEsactivo.Checked = true;
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
        }
        private void CptooperacionMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
       

    }
}