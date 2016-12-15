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
    public partial class CotizacionprvMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public CotizacionprvFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Cotizacionprv CotizacionprvMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwCotizacionprvdet> VwCotizacionprvdetList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public CotizacionprvMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, CotizacionprvFrm formParent) 
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
        private void CotizacionprvMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }        
        private void ValoresPorDefecto()
        {
            iFechaemision.EditValue = SessionApp.DateServer;
            iIdtipomoneda.EditValue = 1;
          
            iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
            iIdresponsable.Enabled = false;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdalmacenentrega.EditValue = SessionApp.SucursalSel.Idalmacendefecto;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "COTIZA-PROVEEDOR";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

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
                    CotizacionprvMnt = new Cotizacionprv();                    
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    EstadoReferenciaCuadroComparativo();
                    break;
            }           
        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-PROVEEDOR", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-PROVEEDOR", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

         

            iIdtipomoneda.Properties.DataSource = Service.GetAllTipomoneda();
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

         
            iIdresponsable.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacenentrega.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen,"codigoalmacen");
            iIdalmacenentrega.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacenentrega.Properties.ValueMember = "Idalmacen";
            iIdalmacenentrega.Properties.BestFitMode = BestFitMode.BestFit;


            TipodocmovList = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocimp.DataSource = TipodocmovList;
            iIdtipodocimp.DisplayMember = "Nombretipodocmov";
            iIdtipodocimp.ValueMember = "Idtipodocmov";
            iIdtipodocimp.BestFitMode = BestFitMode.BestFit;


        }
        private void TraerDatos()
        {
            try
            {
                CotizacionprvMnt = Service.GetCotizacionprv(IdEntidadMnt);

                iIdsucursal.EditValue = CotizacionprvMnt.Idsucursal;
                iIdalmacenentrega.EditValue = CotizacionprvMnt.Idalmacenentrega;
                iIdtipocp.EditValue = CotizacionprvMnt.Idtipocp;
                iIdcptooperacion.EditValue = CotizacionprvMnt.Idcptooperacion;
                rSeriecotizacionprv.EditValue = CotizacionprvMnt.Seriecotizacionprv;
                rNumerocotizacionprv.EditValue = CotizacionprvMnt.Numerocotizacionprv;
                iIdresponsable.EditValue = CotizacionprvMnt.Idresponsable;
                iFechaemision.EditValue = CotizacionprvMnt.Fechaemision;
                iAnulado.EditValue = CotizacionprvMnt.Anulado;
                iFechaanulado.EditValue = CotizacionprvMnt.Fechaanulado;
                iIdtipomoneda.EditValue = CotizacionprvMnt.Idtipomoneda;
                iObservacion.EditValue = CotizacionprvMnt.Observacion;
               
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private void EstadoReferenciaCuadroComparativo()
        {
            if (Service.CotizacionPrvTieneReferenciaCuadroComparativo(IdEntidadMnt))
            {
                XtraMessageBox.Show("La cotizacion de proveedor tiene referencias en cuadro comparativo.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);

                gvDetalle.OptionsBehavior.Editable = false;
                gvDetalle.OptionsBehavior.ReadOnly = true;
                bsiImportar.Enabled = false;
                btnDelItem.Enabled = false;
            }
        }
        private void CargarDetalle()
        {
            string where = string.Format("idcotizacionprv = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwCotizacionprvdetList = Service.GetAllVwCotizacionprvdet(where, "numeroitem");
            gcDetalle.DataSource = VwCotizacionprvdetList;
            if (IdEntidadMnt > 0)
            {
                ActualizarTotales();
            }

            gcDetalle.EndUpdate();
            gvDetalle.BestFitColumns();            

        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            CotizacionprvMnt.Idsucursal = (int?)iIdsucursal.EditValue;
            CotizacionprvMnt.Idalmacenentrega = (int?)iIdalmacenentrega.EditValue;
            CotizacionprvMnt.Idtipocp = (int)iIdtipocp.EditValue;
            CotizacionprvMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            CotizacionprvMnt.Seriecotizacionprv = rSeriecotizacionprv.Text.Trim();
            CotizacionprvMnt.Numerocotizacionprv = rNumerocotizacionprv.Text.Trim();
            CotizacionprvMnt.Idresponsable = (int?)iIdresponsable.EditValue;
            CotizacionprvMnt.Fechaemision = (DateTime)iFechaemision.EditValue;
            CotizacionprvMnt.Anulado = (bool)iAnulado.EditValue;
            CotizacionprvMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            CotizacionprvMnt.Idtipomoneda = (int?)iIdtipomoneda.EditValue;
            CotizacionprvMnt.Observacion = iObservacion.Text.Trim();
            

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //CotizacionprvMnt.Createdby = IdUsuario;
                    //CotizacionprvMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //CotizacionprvMnt.Modifiedby = IdUsuario;
                    //CotizacionprvMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveCotizacionprv(CotizacionprvMnt);
                    CotizacionprvMnt.Idcotizacionprv = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    if (IdEntidadMnt > 0
                        && TipoCpMnt.Numeracionauto
                        && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerocotizacionprv.EditValue)))
                    {
                        iIdtipocp.ReadOnly = true;
                        iIdcptooperacion.ReadOnly = true;
                    }

                        
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateCotizacionprv(CotizacionprvMnt);
                    if (CotizacionprvMnt.Anulado)
                    {
                       // Service.AnularReferenciaEntradaOrdenCompraDet(CotizacionprvMnt.Idcotizacionprv);
                    }
                        break;
                }
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                string numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriecotizacionprv.Text.Trim(), rNumerocotizacionprv.Text.Trim());
                Cursor = Cursors.Default;
                XtraMessageBox.Show("Se guardo correctamente el documento " + numeroDoc, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpReferencias, _errorProvider))
            {
                tcRequerimiento.SelectedTabPage = tpReferencias;
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
                        Service.DeleteCotizacionprv(IdEntidadMnt);
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

                    CotizacionprvMnt = null;
                    CotizacionprvMnt = new Cotizacionprv();

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
                        DeshabilitarModificacion();
                    }                    
                    break;
                case "btnImportarReq":
                    ImportarItems();
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
                        CotizacionprvMnt = null;
                        DialogResult = DialogResult.OK;
                    }                    
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoCotizacionPrv(CotizacionprvMnt);
                    }
                    break;
            }
        }
        private void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);
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
            bsiImportar.Enabled = !enabled;
            btnImportarReq.Enabled = !enabled;
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
        private void CotizacionprvMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            WinFormUtils.ReadOnlyFields(tpDatos, readOnly);
            WinFormUtils.ReadOnlyFields(tpReferencias, readOnly);
            WinFormUtils.ReadOnlyFields(tpObservaciones, readOnly);
        }
        private void CotizacionprvMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            
            const string nombreIdDetalle = "Idcotizacionprvdet";

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    break;

                case "btnEditDato":
    
                    break;

                case "btnDelItem":
                    int idCotizacionprvdet = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));

                    if (idCotizacionprvdet > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar item", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteCotizacionprvdet(idCotizacionprvdet);
                            CargarDetalle();
                            ListarDocumentosReferencias();
                        }
                    }
                    break;
            }
        }
        private void ActualizarTotales()
        {

            
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
                TipoCpMnt = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriecotizacionprv.EditValue = vwTipocp.Seriecp;
                        rNumerocotizacionprv.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocotizacionprv.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerocotizacionprv.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerocotizacionprv.EditValue = vwTipocp.Seriecp;
                        rNumerocotizacionprv.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerocotizacionprv.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriecotizacionprv.EditValue = @"0000";
                rNumerocotizacionprv.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void ImportarItems()
        {
            if (IdEntidadMnt == 0)
            {
                XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (gvDetalle.RowCount > 0)
            {
                XtraMessageBox.Show("Ya se ha agregado items.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                //return;

            }


            CotizacionprvImpReqFrm cotizacionprvImpReqFrm = new CotizacionprvImpReqFrm(IdEntidadMnt, VwCotizacionprvdetList);
            cotizacionprvImpReqFrm.ShowDialog();

            if (cotizacionprvImpReqFrm.DialogResult == DialogResult.OK)
            {

                VwRequerimiento vwRequerimientoSel = cotizacionprvImpReqFrm.VwRequerimientoSel;
                if (vwRequerimientoSel != null)
                {
                    CargarDetalle();
                }
            }

        }
        private void ListarDocumentosReferencias()
        {
            List<string> listadoDoc = VwCotizacionprvdetList
                    .Select(itemEnt =>
                    Service.GetVwCotizacionprvdet(x => x.Idcotizacionprvdet == itemEnt.Idcotizacionprvdet))
                    .Select(ordencompraRef => string.Format("{0}-{1}",
                        Convert.ToInt32(ordencompraRef.Seriecotizacionprv),
                        Convert.ToInt32(ordencompraRef.Numerocotizacionprv))).Distinct().ToList();

            string docsReferencia = listadoDoc
                .Aggregate(string.Empty
                ,(current, item) => current + item + ",");

            docsReferencia = docsReferencia.Trim().Length == 0 ? string.Empty : docsReferencia.Substring(0, docsReferencia.Length - 1);
            
           
        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdresponsable.EditValue;
            const string nombreTipodocMov = "COTIZA-PROVEEDOR";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
    }
}