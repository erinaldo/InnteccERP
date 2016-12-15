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
    public partial class EtapaautorizacionMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public EtapaautorizacionFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Etapaautorizacion EtapaautorizacionMnt { get; set; }   

        //Detalle
        public List<VwEtapaautorizacion> VwEtapaautorizacionList { get; set; }
        public List<VwEtapaautorizaciondetalle> VwEtapaautorizaciondetalleList { get; set; }
        public EtapaautorizacionMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EtapaautorizacionFrm formParent) 
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
        private void EtapaautorizacionMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            rIdempresa.EditValue = SessionApp.EmpresaSel.Idempresa;
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
                    EtapaautorizacionMnt = new Etapaautorizacion();                    
                    CargarDetalle();
                    iNombreetapaautorizacion.Select();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }
            iNombreetapaautorizacion.Focus();
        }
        private void CargarReferencias()
        {
            rIdempresa.Properties.DataSource = Service.GetAllEmpresa();
            rIdempresa.Properties.DisplayMember = "Razonsocial";
            rIdempresa.Properties.ValueMember = "Idempresa";
            rIdempresa.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                EtapaautorizacionMnt = Service.GetEtapaautorizacion(IdEntidadMnt);

                //iCodigo.EditValue = EtapaautorizacionMnt.Codigo.Trim();
                iNombreetapaautorizacion.EditValue = EtapaautorizacionMnt.Nombreetapaautorizacion.Trim();
                iCantautorizacionesreq.EditValue = EtapaautorizacionMnt.Cantautorizacionesreq;
                rIdempresa.EditValue = EtapaautorizacionMnt.Idempresa;
                
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
            string where = string.Format("idetapaautorizacion = '{0}'", IdEntidadMnt);
            gcDetDato.BeginUpdate();
            VwEtapaautorizaciondetalleList = Service.GetAllVwEtapaautorizaciondetalle(where, "ordenautorizacion");
            gcDetDato.DataSource = VwEtapaautorizaciondetalleList;
            gvDetDato.BestFitColumns();
            gcDetDato.EndUpdate();
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            
            EtapaautorizacionMnt.Nombreetapaautorizacion = iNombreetapaautorizacion.Text.Trim();
            EtapaautorizacionMnt.Cantautorizacionesreq = (int) iCantautorizacionesreq.EditValue;
            EtapaautorizacionMnt.Idempresa = (int)rIdempresa.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //EtapaautorizacionMnt.Createdby = IdUsuario;
                    //EtapaautorizacionMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //EtapaautorizacionMnt.Modifiedby = IdUsuario;
                    //EtapaautorizacionMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveEtapaautorizacion(EtapaautorizacionMnt);
                    EtapaautorizacionMnt.Idetapaautorizacion = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateEtapaautorizacion(EtapaautorizacionMnt);
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
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpEtapa, _errorProvider))
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
                        Service.DeleteEtapaautorizacion(IdEntidadMnt);
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

                    EtapaautorizacionMnt = null;
                    EtapaautorizacionMnt = new Etapaautorizacion ();

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
                        EtapaautorizacionMnt = null;
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
        private void EtapaautorizacionMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void iPatPer_EditValueChanged(object sender, EventArgs e)
        {
            

        }

        private void EtapaautorizacionMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            EtapaautorizacionMntItemFrm EtapaautorizacionMntItemFrm;
            var vwEtapaautorizacioncondetalleMnt = new VwEtapaautorizaciondetalle();

            Etapaautorizaciondetalle EtapaautorizaciondetalleMnt;
            
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


                    EtapaautorizacionMntItemFrm = new EtapaautorizacionMntItemFrm(tipoMantenimientoItem, vwEtapaautorizacioncondetalleMnt);
                    EtapaautorizacionMntItemFrm.ShowDialog();

                    if (EtapaautorizacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwEtapaautorizaciondetalleList.Add(vwEtapaautorizacioncondetalleMnt);

                        EtapaautorizaciondetalleMnt = new Etapaautorizaciondetalle
                        {
                            Idetapaautorizacion = IdEntidadMnt,
                            Idempleado = vwEtapaautorizacioncondetalleMnt.Idempleado,
                            Ordenautorizacion = vwEtapaautorizacioncondetalleMnt.Ordenautorizacion,
                            Requiereautorizacion = vwEtapaautorizacioncondetalleMnt.Requiereautorizacion,
                        };

                        Service.SaveEtapaautorizaciondetalle(EtapaautorizaciondetalleMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwEtapaautorizacioncondetalleMnt = (VwEtapaautorizaciondetalle) gvDetDato.GetFocusedRow();

                    if (vwEtapaautorizacioncondetalleMnt == null) 
                    {
                        break;
                    }

                    EtapaautorizacionMntItemFrm = new EtapaautorizacionMntItemFrm(tipoMantenimientoItem, vwEtapaautorizacioncondetalleMnt);
                    EtapaautorizacionMntItemFrm.ShowDialog();

                    if (EtapaautorizacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        EtapaautorizaciondetalleMnt = new Etapaautorizaciondetalle
                        {
                            Idetapaautorizaciondetalle = vwEtapaautorizacioncondetalleMnt.Idetapaautorizaciondetalle,
                            Idetapaautorizacion = IdEntidadMnt,
                            Idempleado = vwEtapaautorizacioncondetalleMnt.Idempleado,
                            Ordenautorizacion = vwEtapaautorizacioncondetalleMnt.Ordenautorizacion,
                            Requiereautorizacion = vwEtapaautorizacioncondetalleMnt.Requiereautorizacion,
                        };

                        Service.UpdateEtapaautorizaciondetalle(EtapaautorizaciondetalleMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnDelItem":
                    int idEtapaautorizacioncontacto = Convert.ToInt32(gvDetDato.GetRowCellValue(gvDetDato.FocusedRowHandle, "Idetapaautorizaciondetalle"));

                    if (idEtapaautorizacioncontacto > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteEtapaautorizaciondetalle(idEtapaautorizacioncontacto);

                            CargarDetalle();
                        }
                    }
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