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
    public partial class SucursalMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public SucursalFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Sucursal SucursalMnt { get; set; }
        public List<VwCptooperacion> VwCptooperacionOrdenServicioList { get; set; }
        public List<VwCptooperacion> VwCptooperacionOrdenOrdenCompraList { get; set; }
        public SucursalMntFrm(Sucursal sucursalMnt, int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, SucursalFrm formParent) 
        {
            if (tipoMnt == TipoMantenimiento.SinEspecificar && idEntidadMnt <= 0)
            {
                throw new ArgumentException("El valor primario de la entidad no contiene un valor valido.");
            }

            InitializeComponent();

            SucursalMnt = sucursalMnt;

            IdEntidadMnt = idEntidadMnt;
            TipoMnt = tipoMnt;
            SeEliminoObjeto = false;
            GridParent = gridParent;
            FormParent = formParent;


            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;            

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
            Cursor = Cursors.WaitCursor;

            rIdempresa.Properties.DataSource = Service.GetAllEmpresa();
            rIdempresa.Properties.DisplayMember = "Razonsocial";
            rIdempresa.Properties.ValueMember = "Idempresa";
            rIdempresa.Properties.BestFitMode = BestFitMode.BestFit;

            iIddistrito.Properties.DataSource = Service.GetAllVwUbigeo();
            iIddistrito.Properties.DisplayMember = "Nombreubigeo";
            iIddistrito.Properties.ValueMember = "Iddistrito";
            iIddistrito.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleadoaprueba.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleadoaprueba.Properties.DisplayMember = "Razonsocial";
            iIdempleadoaprueba.Properties.ValueMember = "Idempleado";
            iIdempleadoaprueba.Properties.BestFitMode = BestFitMode.BestFit;

            //if (SessionApp.SucursalSel != null)
            //{
            //    string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            //    iIdalmacendefecto.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            //    iIdalmacendefecto.Properties.DisplayMember = "Nombrealmacen";
            //    iIdalmacendefecto.Properties.ValueMember = "Idalmacen";
            //    iIdalmacendefecto.Properties.BestFitMode = BestFitMode.BestFit;
            //}

            string whereAlmacen = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdalmacendefecto.Properties.DataSource = Service.GetAllVwAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacendefecto.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacendefecto.Properties.ValueMember = "Idalmacen";
            iIdalmacendefecto.Properties.BestFitMode = BestFitMode.BestFit;
            



            iIdtipolistadefecto.Properties.DataSource = Service.GetAllTipolista();
            iIdtipolistadefecto.Properties.DisplayMember = "Nombretipolista";
            iIdtipolistadefecto.Properties.ValueMember = "Idtipolista";
            iIdtipolistadefecto.Properties.BestFitMode = BestFitMode.BestFit;

            if (SessionApp.SucursalSel != null)
            {
                string whereTipoOpeServicio = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPCOMPRA", SessionApp.SucursalSel.Idsucursal);
                VwCptooperacionOrdenServicioList = Service.GetAllVwCptooperacion(whereTipoOpeServicio, "nombrecptooperacion");
                iIdcptooperacionordenservicio.Properties.DataSource = VwCptooperacionOrdenServicioList;
                iIdcptooperacionordenservicio.Properties.DisplayMember = "Nombrecptooperacion";
                iIdcptooperacionordenservicio.Properties.ValueMember = "Idcptooperacion";
                iIdcptooperacionordenservicio.Properties.BestFitMode = BestFitMode.BestFit;
            }

            if (SessionApp.SucursalSel != null)
            {
                string whereTipoOpeOrden = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'","CPCOMPRA",SessionApp.SucursalSel.Idsucursal);
                VwCptooperacionOrdenOrdenCompraList = Service.GetAllVwCptooperacion(whereTipoOpeOrden,"nombrecptooperacion");
                iIdcptooperacionordencompra.Properties.DataSource = VwCptooperacionOrdenOrdenCompraList;
                iIdcptooperacionordencompra.Properties.DisplayMember = "Nombrecptooperacion";
                iIdcptooperacionordencompra.Properties.ValueMember = "Idcptooperacion";
                iIdcptooperacionordencompra.Properties.BestFitMode = BestFitMode.BestFit;
            }

            iIdcentrobeneficioventadefecto.Properties.DataSource = CacheObjects.VwCentrodecostoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdcentrobeneficioventadefecto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrobeneficioventadefecto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrobeneficioventadefecto.Properties.BestFitMode = BestFitMode.BestFit;

            Cursor = Cursors.Default;
        }
        private void TraerDatos()
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                iCodigosucursal.EditValue = SucursalMnt.Codigosucursal.Trim();
                iNombresucursal.EditValue = SucursalMnt.Nombresucursal.Trim();
                iIddistrito.EditValue = SucursalMnt.Iddistrito;
                iDireccionsucursal.EditValue = SucursalMnt.Direccionsucursal.Trim();
                rIdempresa.EditValue = SucursalMnt.Idempresa;
                iIdempleadoaprueba.EditValue = SucursalMnt.Idempleadoaprueba;
                iIdalmacendefecto.EditValue = SucursalMnt.Idalmacendefecto;
                iIdtipolistadefecto.EditValue = SucursalMnt.Idtipolistadefecto;
                iIdcptooperacionordenservicio.EditValue = SucursalMnt.Idcptooperacionordenservicio;
                iIdcptooperacionordencompra.EditValue = SucursalMnt.Idcptooperacionordencompra;
                iIdcentrobeneficioventadefecto.EditValue = SucursalMnt.Idcentrobeneficioventadefecto;
                Cursor = Cursors.Default;

            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                Cursor = Cursors.Default;
                throw;
            }
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            SucursalMnt.Codigosucursal = iCodigosucursal.Text.Trim();
            SucursalMnt.Nombresucursal = iNombresucursal.Text.Trim();
            SucursalMnt.Iddistrito = (int)iIddistrito.EditValue;
            SucursalMnt.Direccionsucursal = iDireccionsucursal.Text.Trim();
            SucursalMnt.Idempresa = (int)rIdempresa.EditValue;
            SucursalMnt.Idempleadoaprueba = (int?)iIdempleadoaprueba.EditValue;
            SucursalMnt.Idalmacendefecto = (int?)iIdalmacendefecto.EditValue;
            SucursalMnt.Idtipolistadefecto = (int) iIdtipolistadefecto.EditValue;
            SucursalMnt.Idcptooperacionordenservicio = (int?)iIdcptooperacionordenservicio.EditValue;
            SucursalMnt.Idcptooperacionordencompra = (int?) iIdcptooperacionordencompra.EditValue;
            SucursalMnt.Idcentrobeneficioventadefecto = (int?)iIdcentrobeneficioventadefecto.EditValue;

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
                        IdEntidadMnt = Service.SaveSucursal(SucursalMnt);
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateSucursal(SucursalMnt);
                        break;
                }

                //Actualizar la sucursal al usuario autenticado
                if (SucursalMnt != null)
                {
                    SessionApp.SucursalSel = SucursalMnt;
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
            //if (TipoMnt == TipoMantenimiento.Nuevo && Service.CodigoSucursalExiste(iCodigosucursal.Text.Trim()))
            //{
            //    iCodigosucursal.EditValue = Service.GetSiguienteCodigoEmpleado();
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
                        Service.DeleteSucursal(IdEntidadMnt);
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

                    SucursalMnt = null;
                    SucursalMnt = new Sucursal();

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
                        DialogResult = DialogResult.OK;
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

                        SucursalMnt = null;
                        SucursalMnt = new Sucursal();
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
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        SucursalMnt = null;
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
        private void SucursalMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            rIdempresa.EditValue = SessionApp.EmpresaSel.Idempresa;
            if (SessionApp.SucursalSel != null)
            {
                iIdalmacendefecto.EditValue = SessionApp.SucursalSel.Idalmacendefecto;
            }
        }

        private void SucursalMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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