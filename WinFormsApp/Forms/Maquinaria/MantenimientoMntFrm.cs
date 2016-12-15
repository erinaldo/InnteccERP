using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class MantenimientoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public MantenimientoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Mantenimiento MantenimientoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<Mantenimientoimagen> MantenimientoimagenList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        private List<VwEquipo> VwEquipoList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public string RutaArchivoServidor { get; set; }

        public MantenimientoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, MantenimientoFrm formParent) 
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

            RutaArchivoServidor = SessionApp.EmpresaSel.Rutaarchivos;
        }        
        private void MantenimientoMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Crear " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void ValoresPorDefecto()
        {

            iFecharegistro.EditValue = SessionApp.DateServer;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdregistrador.EditValue = SessionApp.EmpleadoSel.Idempleado;
            //iIdempleado.Enabled = false;

            iFecharegistro.EditValue = SessionApp.DateServer;
            iFechamantenimiento.EditValue = SessionApp.DateServer;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "MANTENIMIENTO-EQMAQ";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                }

            }

            iIdtipocp.Select();
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
                    MantenimientoMnt = new Mantenimiento();                    
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoReferenciaCaja();
                    iIdregistrador.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaNotaCredito();
                  

                    break;
            }           
        }
        private void EstadoReferenciaCaja()
        {
            //var idTipoCp = (int) iIdtipocp.EditValue;
            //var serieTipoCp = (string) rSeriemantenimiento.EditValue;
            //var numeroTipoCp = (string) rNumeromantenimiento.EditValue;

            //if (Service.CpVentaTieneReferenciaCaja(idTipoCp, serieTipoCp, numeroTipoCp))
            //{
            //    XtraMessageBox.Show("El Comprobante de venta tiene Recibo de Caja", "Atención",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    HabilitarBotonesMnt(false);
            //    CamposSoloLectura(true);
            //    gvDetalle.OptionsBehavior.Editable = false;
            //}
        }
        private void EstadoReferenciaNotaCredito()
        {


            //if (Service.CpVentaTieneNotacredito(IdEntidadMnt))
            //{
            //    XtraMessageBox.Show("El Comprobante de venta tiene Nota de Credito", "Atención",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    HabilitarBotonesMnt(false);
            //    CamposSoloLectura(true);
            //    gvDetalle.OptionsBehavior.Editable = false;
            //}
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "MANTENIMIENTO-EQMAQ", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "MANTENIMIENTO-EQMAQ", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
            
            iIdregistrador.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdregistrador.Properties.DisplayMember = "Razonsocial";
            iIdregistrador.Properties.ValueMember = "Idempleado";
            iIdregistrador.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = CacheObjects.VwSucursalList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereEquipo = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            VwEquipoList = Service.GetAllVwEquipo(whereEquipo, "nombreequipo");
            iIdequipo.Properties.DataSource = VwEquipoList;
            iIdequipo.Properties.DisplayMember = "Nombreequipo";
            iIdequipo.Properties.ValueMember = "Idequipo";
            iIdequipo.Properties.BestFitMode = BestFitMode.BestFit;

           
        }
        private void TraerDatos()
        {
            try
            {

                MantenimientoMnt = Service.GetMantenimiento(IdEntidadMnt);

                rIdsucursal.EditValue = MantenimientoMnt.Idsucursal;
                iIdtipocp.EditValue = MantenimientoMnt.Idtipocp;
                iIdcptooperacion.EditValue = MantenimientoMnt.Idcptooperacion;
                rSeriemantenimiento.EditValue = MantenimientoMnt.Seriemantenimiento;
                rNumeromantenimiento.EditValue = MantenimientoMnt.Numeromantenimiento;
                iFechamantenimiento.EditValue = MantenimientoMnt.Fechamantenimiento;
                iIdregistrador.EditValue = MantenimientoMnt.Idregistrador;
                iTrabajorealizado.EditValue = MantenimientoMnt.Trabajorealizado;
                iAnulado.EditValue = MantenimientoMnt.Anulado;
                iFechaanulado.EditValue = MantenimientoMnt.Fechaanulado;
                iFecharegistro.EditValue = MantenimientoMnt.Fecharegistro;
                iIdequipo.EditValue = MantenimientoMnt.Idequipo;
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
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            string where = string.Format("idmantenimiento = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            MantenimientoimagenList = Service.GetAllMantenimientoimagen(where, "numeroitem");
            gcDetalle.DataSource = MantenimientoimagenList;            
            RefrescarEstadoItem();            
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;


            MantenimientoMnt.Idsucursal = (int)rIdsucursal.EditValue;
            MantenimientoMnt.Idtipocp = (int)iIdtipocp.EditValue;
            MantenimientoMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            MantenimientoMnt.Seriemantenimiento = rSeriemantenimiento.Text.Trim();
            MantenimientoMnt.Numeromantenimiento = rNumeromantenimiento.Text.Trim();
            MantenimientoMnt.Fechamantenimiento = (DateTime)iFechamantenimiento.EditValue;
            MantenimientoMnt.Idregistrador = (int)iIdregistrador.EditValue;
            MantenimientoMnt.Trabajorealizado = iTrabajorealizado.Text.Trim();
            MantenimientoMnt.Anulado = (bool)iAnulado.EditValue;
            MantenimientoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            MantenimientoMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            MantenimientoMnt.Idequipo = (int)iIdequipo.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //OrdendeventaMnt.Createdby = IdUsuario;
                    //OrdendeventaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                  //  OrdendeventaMnt.Modifiedby = IdUsuario;
                   // OrdendeventaMnt.Lastmodified = DateTime.Now;
                    break;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:

                    if (Service.GuardarMantenimiento(TipoMnt, MantenimientoMnt, MantenimientoimagenList, RutaArchivoServidor))
                    {
                        IdEntidadMnt = MantenimientoMnt.Idmantenimiento;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    Service.GuardarMantenimiento(TipoMnt, MantenimientoMnt, MantenimientoimagenList, RutaArchivoServidor);
                    break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriemantenimiento.Text.Trim(),rNumeromantenimiento.Text.Trim());
                Cursor = Cursors.Default;


                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                XtraMessageBox.Show("Se guardo correctamente el documento "+numeroDoc, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        private void RegistrarValoresPorDefecto()
        {
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdregistrador.EditValue;
            const string nombreTipodocMov = "MANTENIMIENTO-EQMAQ";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;
            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpMantenimiento, _errorProvider))
            {                
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSeriemantenimiento.Text.Trim();
            string numeroViaje = rNumeromantenimiento.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroMantenimientoExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
            {
                CargarInfoCorrelativo();
                return true;
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
                        Service.DeleteMantenimiento(IdEntidadMnt);
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
                    iAnulado.Enabled = Permisos.Anular;
                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    iAnulado.Enabled = Permisos.Anular;
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

                    MantenimientoMnt = null;
                    MantenimientoMnt = new Mantenimiento();

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
                        //
                        DeshabilitarModificacion();
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
                        MantenimientoMnt = null;
                        DialogResult = DialogResult.OK;
                    }                    
                    break;
                case "btnImprimir":
                    //if (ImpresionFormato == null)
                    //{
                    //    ImpresionFormato = new ImpresionFormato();
                    //}
                    //if (IdEntidadMnt > 0)
                    //{
                    //    ImpresionFormato.FormatoCpVenta(MantenimientoMnt);
                    //}
                    break;
           
            }
        }
        private void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);
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
        private void MantenimientoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpMantenimiento, readOnly);
            //XtraFormUtils.ReadOnlyFields(tpLogistica, readOnly);        
        }
        private void MantenimientoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            MantenimientoMntItemFrm mantenimientoMntItemFrm;
            Mantenimientoimagen mantenimientoimagen;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (!ValidarCantidadMaximaDeItems()) return;

                    //Asignar el siguiente item
                    mantenimientoimagen = new Mantenimientoimagen();

                    //Asignar el siguiente item
                    var sgtItem = MantenimientoimagenList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    mantenimientoimagen.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;
                    mantenimientoimagen.Idmantenimiento = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    mantenimientoMntItemFrm = new MantenimientoMntItemFrm(tipoMantenimientoItem, mantenimientoimagen, RutaArchivoServidor);

                    mantenimientoMntItemFrm.ShowDialog();
                  
                    if (mantenimientoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        MantenimientoimagenList.Add(mantenimientoimagen);
                        RefrescarEstadoItem();
                        if (!gvDetalle.IsLastRow)
                        {
                            gvDetalle.MoveLastVisible();
                            gvDetalle.Focus();
                            gvDetalle.FocusedColumn = gvDetalle.Columns["Cantidad"];
                        }  
                    }


                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    mantenimientoimagen = (Mantenimientoimagen) gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    mantenimientoMntItemFrm = new MantenimientoMntItemFrm(tipoMantenimientoItem, mantenimientoimagen, RutaArchivoServidor);
                    mantenimientoMntItemFrm.ShowDialog();
                    if (mantenimientoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        RefrescarEstadoItem();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        mantenimientoimagen = (Mantenimientoimagen)gvDetalle.GetFocusedRow();
                        mantenimientoimagen.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }

                        RefrescarEstadoItem();
                                              
                    }
                    break;
            }
            
        }
        private bool ValidarCantidadMaximaDeItems()
        {
            //int cntItems = VwCpventadetList.Count(x => x.DataEntityState != DataEntityState.Deleted);
            if (gvDetalle.RowCount >= VwTipocpSel.Maxnumeroitems)
            {
                XtraMessageBox.Show(string.Format("Exedio el número de maximo de items ({0})",VwTipocpSel.Maxnumeroitems), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void RefrescarEstadoItem()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();         
            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                VwTipocpSel = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriemantenimiento.EditValue = vwTipocp.Seriecp;
                        rNumeromantenimiento.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeromantenimiento.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeromantenimiento.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeromantenimiento.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeromantenimiento.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeromantenimiento.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriemantenimiento.EditValue = @"0000";
                rNumeromantenimiento.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object) DateTime.Now : null;
        }
        private void HabilitarBotonesMnt(bool enabled)
        {
            BarMnt.BeginUpdate();
            foreach (BarItem item in bmMantenimiento.Items)
            {
                item.Enabled = enabled;
            }
            BarMnt.EndUpdate();
            btnCerrar.Enabled = !enabled;
            btnImprimir.Enabled = !enabled;
            btnActualizar.Enabled = !enabled;

            BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            BarMntItems.EndUpdate();

        }
    }    
}