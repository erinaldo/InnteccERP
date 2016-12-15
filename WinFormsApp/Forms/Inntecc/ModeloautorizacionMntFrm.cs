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
    public partial class ModeloautorizacionMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ModeloautorizacionFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Modeloautorizacion ModeloautorizacionMnt { get; set; }   

        //Detalle
        public List<VwModeloautorizacionetapa> VwModeloautorizacionetapaList { get; set; }
        public List<VwModeloautorizacioncondicion> VwModeloautorizacioncondicionList { get; set; }

        public ModeloautorizacionMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ModeloautorizacionFrm formParent) 
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
        private void ModeloautorizacionMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iEsactivo.Checked = true;
            iTodoslosautores.Checked = true;
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
                    ModeloautorizacionMnt = new Modeloautorizacion();                    
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargaOperaciones();
                    CargarDetalle();
                    break;
            }           
        }
        private void CargarReferencias()
        {
            iIdtipodocmov.Properties.DataSource = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;


            rIdempresa.Properties.DataSource = Service.GetAllEmpresa();
            rIdempresa.Properties.DisplayMember = "Razonsocial";
            rIdempresa.Properties.ValueMember = "Idempresa";
            rIdempresa.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                ModeloautorizacionMnt = Service.GetModeloautorizacion(IdEntidadMnt);

                iNombremodelo.EditValue = ModeloautorizacionMnt.Nombremodelo;
                iEsactivo.EditValue = ModeloautorizacionMnt.Esactivo;
                iTodoslosautores.EditValue = ModeloautorizacionMnt.Todoslosautores;
                iIdtipodocmov.EditValue = ModeloautorizacionMnt.Idtipodocmov;
                rIdempresa.EditValue = ModeloautorizacionMnt.Idempresa;
                iIdcptooperacion.EditValue = ModeloautorizacionMnt.Idcptooperacion;
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
            string where = string.Format("idmodeloautorizacion = '{0}'", IdEntidadMnt);
            gcDetEtapa.BeginUpdate();
            VwModeloautorizacionetapaList = Service.GetAllVwModeloautorizacionetapa(where, "idmodeloautorizacionetapa");
            gcDetEtapa.DataSource = VwModeloautorizacionetapaList;
            gvDetEtapa.BestFitColumns();
            gcDetEtapa.EndUpdate();


        }

        private void CargarCondiciones()
        {
            VwModeloautorizacionetapa vwModeloautorizacionetapa = (VwModeloautorizacionetapa)gvDetEtapa.GetFocusedRow();
            if (vwModeloautorizacionetapa != null)
            {
                string whereunidad = string.Format("idmodeloautorizacionetapa = '{0}'", vwModeloautorizacionetapa.Idmodeloautorizacionetapa);
                gcDetCondiciones.BeginUpdate();
                VwModeloautorizacioncondicionList = Service.GetAllVwModeloautorizacioncondicion(whereunidad,"idmodeloautorizacioncondicion");
                gcDetCondiciones.DataSource = VwModeloautorizacioncondicionList;
                gvDetCondiciones.BestFitColumns();
                gcDetCondiciones.EndUpdate();
            }
            else
            {
                VwModeloautorizacioncondicionList.Clear();
                gcDetCondiciones.RefreshDataSource();
            }
        }

        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            ModeloautorizacionMnt.Nombremodelo = iNombremodelo.Text.Trim();
            ModeloautorizacionMnt.Esactivo = (bool)iEsactivo.EditValue;
            ModeloautorizacionMnt.Todoslosautores = (bool)iTodoslosautores.EditValue;
            ModeloautorizacionMnt.Idtipodocmov = (int?)iIdtipodocmov.EditValue;
            ModeloautorizacionMnt.Idempresa = (int?)rIdempresa.EditValue;
            ModeloautorizacionMnt.Idcptooperacion = (int?)iIdcptooperacion.EditValue;

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
                    IdEntidadMnt = Service.SaveModeloautorizacion(ModeloautorizacionMnt);
                    ModeloautorizacionMnt.Idmodeloautorizacion  = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateModeloautorizacion(ModeloautorizacionMnt);
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
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpModelo, _errorProvider))
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

                    ModeloautorizacionMnt = null;
                    ModeloautorizacionMnt = new Modeloautorizacion();

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
                        ModeloautorizacionMnt = null;
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
        private void ModeloautorizacionMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ModeloautorizacionMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void ItemsEtapas_ItemClick(object sender, EventArgs e)
        {
            SimpleButton simpleButton = (SimpleButton) sender;
            string nameButton = null;
            if (simpleButton != null)
            {
                nameButton = simpleButton.Name;
            }            
            TipoMantenimiento tipoMantenimientoItem;
            VwModeloautorizacionetapa vwModeloautorizacionetapaMnt = new VwModeloautorizacionetapa();

            switch (nameButton)
            {
                case "btnAddEtapa":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ModeloautorizacionEtapaMntItemFrm modeloautorizacionEtapaMntItemFrm = new ModeloautorizacionEtapaMntItemFrm(tipoMantenimientoItem, vwModeloautorizacionetapaMnt);
                    modeloautorizacionEtapaMntItemFrm.ShowDialog();

                    if (modeloautorizacionEtapaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwModeloautorizacionetapaList.Add(vwModeloautorizacionetapaMnt);

                        Modeloautorizacionetapa modeloautorizacionetapaMnt = new Modeloautorizacionetapa
                        {
                            Idmodeloautorizacion = IdEntidadMnt,
                            Idetapaautorizacion = vwModeloautorizacionetapaMnt.Idetapaautorizacion
                        };
                        Service.SaveModeloautorizacionetapa(modeloautorizacionetapaMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnEditEtapa":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwModeloautorizacionetapaMnt = (VwModeloautorizacionetapa)gvDetEtapa.GetFocusedRow();

                    if (vwModeloautorizacionetapaMnt == null) 
                    {
                        break;
                    }

                    modeloautorizacionEtapaMntItemFrm = new ModeloautorizacionEtapaMntItemFrm(tipoMantenimientoItem, vwModeloautorizacionetapaMnt);
                    modeloautorizacionEtapaMntItemFrm.ShowDialog();

                    if (modeloautorizacionEtapaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Modeloautorizacionetapa modeloautorizacionetapaMnt = new Modeloautorizacionetapa
                        {
                            Idmodeloautorizacionetapa = vwModeloautorizacionetapaMnt.Idmodeloautorizacionetapa,
                            Idmodeloautorizacion = IdEntidadMnt,
                            Idetapaautorizacion = vwModeloautorizacionetapaMnt.Idetapaautorizacion                                                        
                        };

                        Service.UpdateModeloautorizacionetapa(modeloautorizacionetapaMnt);
                        CargarDetalle();

                    }

                    break;

                case "btnDelEtapa":
                    int idmodeloautorizacionetapa = Convert.ToInt32(gvDetEtapa.GetRowCellValue(gvDetEtapa.FocusedRowHandle, "Idmodeloautorizacionetapa"));

                    if (idmodeloautorizacionetapa > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            Service.DeleteModeloautorizacionetapa(idmodeloautorizacionetapa);
                            CargarDetalle();
                            CargarCondiciones();
                        }
                    }
                    break;
            }
        }
        private void Condiciones_ItemClick(object sender, EventArgs e)
        {
            int idmodeloautorizacionetapa = 0;
            VwModeloautorizacionetapa vwModeloautorizacionetapaSel = (VwModeloautorizacionetapa)gvDetEtapa.GetFocusedRow();

            if (vwModeloautorizacionetapaSel != null)
            {
                idmodeloautorizacionetapa = vwModeloautorizacionetapaSel.Idmodeloautorizacionetapa;
            }

            if (idmodeloautorizacionetapa <= 0)
            {
                return;
            }

            SimpleButton simpleButton = sender as SimpleButton;
            string nameButton = null;
            if (simpleButton != null)
            {
                nameButton = simpleButton.Name;
            }
            
            TipoMantenimiento tipoMantenimientoItem;
            VwModeloautorizacioncondicion vwModeloautorizacioncondicionMnt = new VwModeloautorizacioncondicion();            

            switch (nameButton)
            {
                case "btnAddCondicion":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ModeloautorizacionCondicionMntItemFrm modeloautorizacionCondicionMntItemFrm = new ModeloautorizacionCondicionMntItemFrm(tipoMantenimientoItem, vwModeloautorizacioncondicionMnt);
                    modeloautorizacionCondicionMntItemFrm.ShowDialog();

                    if (modeloautorizacionCondicionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwModeloautorizacioncondicionList.Add(vwModeloautorizacioncondicionMnt);

                        Modeloautorizacioncondicion modeloautorizacioncondicion = new Modeloautorizacioncondicion
                        {
                            Idmodeloautorizacionetapa = idmodeloautorizacionetapa,
                            Idautorizaciontipocondicion = vwModeloautorizacioncondicionMnt.Idautorizaciontipocondicion,
                            Idtiporatio = vwModeloautorizacioncondicionMnt.Idtiporatio,
                            Valor1 = vwModeloautorizacioncondicionMnt.Valor1,
                            Valor2 = vwModeloautorizacioncondicionMnt.Valor2
                        };

                        Service.SaveModeloautorizacioncondicion(modeloautorizacioncondicion);
                        CargarCondiciones();
                    }

                    break;

                case "btnEditCondicion":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwModeloautorizacioncondicionMnt = (VwModeloautorizacioncondicion)gvDetCondiciones.GetFocusedRow();
                    if (vwModeloautorizacioncondicionMnt == null)
                    {
                        break;
                    }
                    modeloautorizacionCondicionMntItemFrm = new ModeloautorizacionCondicionMntItemFrm(tipoMantenimientoItem, vwModeloautorizacioncondicionMnt);
                    modeloautorizacionCondicionMntItemFrm.ShowDialog();
                    if (modeloautorizacionCondicionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Modeloautorizacioncondicion modeloautorizacioncondicion = new Modeloautorizacioncondicion
                        {
                            Idmodeloautorizacioncondicion = vwModeloautorizacioncondicionMnt.Idmodeloautorizacioncondicion,
                            Idmodeloautorizacionetapa = idmodeloautorizacionetapa,
                            Idautorizaciontipocondicion = vwModeloautorizacioncondicionMnt.Idautorizaciontipocondicion,
                            Idtiporatio = vwModeloautorizacioncondicionMnt.Idtiporatio,
                            Valor1 = vwModeloautorizacioncondicionMnt.Valor1,
                            Valor2 = vwModeloautorizacioncondicionMnt.Valor2
                        };

                        Service.UpdateModeloautorizacioncondicion(modeloautorizacioncondicion);
                        CargarCondiciones();

                    }

                    break;

                case "btnDelCondicion":
                    var idmodeloautorizacioncondicion = Convert.ToInt32(gvDetCondiciones.GetRowCellValue(gvDetCondiciones.FocusedRowHandle, "Idmodeloautorizacioncondicion"));
                    if (idmodeloautorizacioncondicion > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            Service.DeleteModeloautorizacioncondicion(idmodeloautorizacioncondicion);
                            CargarCondiciones();
                        }
                    }
                    break;
            }
        }
        private void gvDetEtapa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CargarCondiciones();
        }

        private void iIdtipodocmov_EditValueChanged(object sender, EventArgs e)
        {
            CargaOperaciones();
        }

        private void CargaOperaciones()
        {
            string whereTipoOpe = string.Format("idtipodocmov = '{0}' and idsucursal = '{1}'", iIdtipodocmov.EditValue,
                SessionApp.SucursalSel.Idsucursal);

            iIdcptooperacion.Properties.DataSource = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
        }
    }
}