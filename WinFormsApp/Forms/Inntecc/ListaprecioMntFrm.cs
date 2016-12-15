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
    public partial class ListaprecioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ListaprecioFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Listaprecio ListaprecioMnt { get; set; }
        public List<Tipoformato> TipoformatoList { get; set; }
        public List<Tipocondicion> TipocondicionList { get; set; }

        public ListaprecioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ListaprecioFrm formParent) 
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

        private void ListaprecioMntFrm_Load(object sender, EventArgs e)
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
                    ListaprecioMnt = new Listaprecio();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();

                    iIdtipolista.Enabled = false;
                    iIdtipomoneda.Enabled = false;
                    iIdcondicioncreditoopcion1.Enabled = false;
                    iIdcondicioncreditoopcion2.Enabled = false;
                    iAgregararticuloauto.Enabled = false;
                    iListaprecioincluyeimpuesto.Enabled = false;

                    break;
            }           
        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipomoneda.Properties.DataSource = Service.GetAllTipomoneda();
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            TipocondicionList = Service.GetAllTipocondicion(x=>x.Diascondicion > 0);

            iIdcondicioncreditoopcion1.Properties.DataSource = TipocondicionList;
            iIdcondicioncreditoopcion1.Properties.DisplayMember = "Nombrecondicion";
            iIdcondicioncreditoopcion1.Properties.ValueMember = "Idtipocondicion";
            iIdcondicioncreditoopcion1.Properties.BestFitMode = BestFitMode.BestFit;

            iIdcondicioncreditoopcion2.Properties.DataSource = TipocondicionList;
            iIdcondicioncreditoopcion2.Properties.DisplayMember = "Nombrecondicion";
            iIdcondicioncreditoopcion2.Properties.ValueMember = "Idtipocondicion";
            iIdcondicioncreditoopcion2.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                ListaprecioMnt = Service.GetListaprecio(IdEntidadMnt);
                iIdsucursal.EditValue = ListaprecioMnt.Idsucursal;
                iIdtipolista.EditValue = ListaprecioMnt.Idtipolista;
                iIdtipomoneda.EditValue = ListaprecioMnt.Idtipomoneda;
                iAgregararticuloauto.EditValue = ListaprecioMnt.Agregararticuloauto;
                iIdcondicioncreditoopcion1.EditValue = ListaprecioMnt.Idcondicioncreditoopcion1;
                iIdcondicioncreditoopcion2.EditValue = ListaprecioMnt.Idcondicioncreditoopcion2;
                iListaprecioincluyeimpuesto.EditValue = ListaprecioMnt.Listaprecioincluyeimpuesto;

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

            ListaprecioMnt.Idsucursal = (int)iIdsucursal.EditValue;
            ListaprecioMnt.Idtipolista = (int)iIdtipolista.EditValue;
            ListaprecioMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            ListaprecioMnt.Agregararticuloauto = (bool)iAgregararticuloauto.EditValue;
            ListaprecioMnt.Idcondicioncreditoopcion1 = (int)iIdcondicioncreditoopcion1.EditValue;
            ListaprecioMnt.Idcondicioncreditoopcion2 = (int)iIdcondicioncreditoopcion2.EditValue;
            ListaprecioMnt.Listaprecioincluyeimpuesto = (bool)iListaprecioincluyeimpuesto.EditValue;

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
                        IdEntidadMnt = Service.GuardarListaprecio(TipoMnt, ListaprecioMnt);
                        ListaprecioMnt.Idlistaprecio = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        break;
                    case TipoMantenimiento.Modificar:
                        IdEntidadMnt = Service.GuardarListaprecio(TipoMnt, ListaprecioMnt);
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
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;

            }

            if (WinFormUtils.MessageQuestion("¿Está seguro de registrar la lista de precio, no se podrá modificar después de guardar los cambios?", "Pregunta") == DialogResult.No)
            {
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
                        Service.DeleteListaprecio(IdEntidadMnt);
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

                    ListaprecioMnt = null;
                    ListaprecioMnt = new Listaprecio();

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

                        ListaprecioMnt = null;
                        ListaprecioMnt = new Listaprecio();
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
                        ListaprecioMnt = null;
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
        private void ListaprecioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            iIdtipomoneda.EditValue = 1; //SOLES
            iIdtipomoneda.Enabled = false;
            iAgregararticuloauto.Checked = true;

            iListaprecioincluyeimpuesto.EditValue = SessionApp.EmpresaSel.Listaprecioincluyeimpuesto;
        }
        private void ListaprecioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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