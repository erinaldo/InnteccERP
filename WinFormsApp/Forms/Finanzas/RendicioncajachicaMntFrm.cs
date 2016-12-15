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
    public partial class RendicioncajachicaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public RendicioncajachicaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Rendicioncajachica RendicioncajachicaMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }        
        public List<Impuesto> ImpuestoList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwRendicioncajachicadet> VwRendicioncajachicadetList { get; set; }

        public RendicioncajachicaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, RendicioncajachicaFrm formParent) 
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
        private void RendicioncajachicaMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFecharendicioncaja.EditValue = SessionApp.DateServer;

            if (SessionApp.EmpleadoSel == null)
            {
                iIdempleado.EditValue = null;
                iIdempleado.Enabled = true;
            }
            else
            {
                iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdempleado.Enabled = false;
            }


            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;


           
            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "CAJA-CHICA";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
                }

            }

            iIdtipomoneda.EditValue = 1;//Nuevos Soles


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
                    RendicioncajachicaMnt = new Rendicioncajachica();
                    CargarDetalle();

                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    
                    CargarDetalle();
                   
                    if (iAnulado.Checked)
                    {
                        DeshabilitarModificacion();
                    }
                    if (iRendicionterminada.Checked)
                    {
                        BarMntItems.BeginUpdate();
                        foreach (BarItem item in bmItems.Items)
                        {
                            item.Enabled = false;
                        }
                        BarMntItems.EndUpdate();
                    }
                    SumarTotales(false);
                    btnBuscarRecibo.Enabled = false;
                    iIdempleado.Enabled = false;
                    break;
            }          
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
            //BarMntItems.BeginUpdate();
            //foreach (BarItem item in bmItems.Items)
            //{
            //    item.Enabled = enabled;
            //}
            //BarMntItems.EndUpdate();
           
        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CAJA-CHICA", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CAJA-CHICA", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
            
            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoDocCotizacion = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "RECIBO-EGRESO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoDocCotizacion, "nombretipocp");
            iIdTipoDocRecibo.Properties.DataSource = VwTipocpList;
            iIdTipoDocRecibo.Properties.DisplayMember = "Nombretipocp";
            iIdTipoDocRecibo.Properties.ValueMember = "Idtipocp";
            iIdTipoDocRecibo.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarDatosReciboCajaEgreso()
        {
            //int idTipoCp = (int)iIdTipoDocCotizacion.EditValue;
            //int idSucursal = (int)rIdsucursal.EditValue;
            //string serieCotizacion = (string)rSerieCotizacion.EditValue;
            //string numeroCotizacion = (string)iNumeroCotizacion.EditValue;

            Recibocajaegreso recibocaja = Service.GetRecibocajaegreso(x => x.Idrecibocajaegreso == (int)iIdrecibocaja.EditValue);

            if (recibocaja != null)
            {
                iIdTipoDocRecibo.EditValue = recibocaja.Idtipocp;
                //rSerieCotizacion.EditValue = cotizacionprv.Sericotizacionprv;
                iNumeroTipocp.EditValue = recibocaja.Numerorecibo;
                rImporterecibo.EditValue = recibocaja.Totaldocumento;
                rFecharecibo.EditValue = recibocaja.Fecharecibo;
            }

        }
        private void TraerDatos()
        {
            try
            {
                RendicioncajachicaMnt = Service.GetRendicioncajachica(IdEntidadMnt);

                iIdsucursal.EditValue = RendicioncajachicaMnt.Idsucursal;
                iIdtipocp.EditValue = RendicioncajachicaMnt.Idtipocp;
                iIdcptooperacion.EditValue = RendicioncajachicaMnt.Idcptooperacion;
                rSerierendicioncaja.EditValue = RendicioncajachicaMnt.Serierendicioncaja;
                rNumerorendicioncaja.EditValue = RendicioncajachicaMnt.Numerorendicioncaja;
                iIdempleado.EditValue = RendicioncajachicaMnt.Idempleado;
                iIdrecibocaja.EditValue = RendicioncajachicaMnt.Idrecibocaja;
                iFecharendicioncaja.EditValue = RendicioncajachicaMnt.Fecharendicioncaja;
                iAnulado.EditValue = RendicioncajachicaMnt.Anulado;
                iFechaanulado.EditValue = RendicioncajachicaMnt.Fechaanulado;
                iComentario.EditValue = RendicioncajachicaMnt.Comentario;
                rTotaldocumento.EditValue = RendicioncajachicaMnt.Totaldocumento;
                iRendicionterminada.EditValue = RendicioncajachicaMnt.Rendicionterminada;
                iIdtipomoneda.EditValue = RendicioncajachicaMnt.Idtipomoneda;
                CargarDatosReciboCajaEgreso();
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        public void CargarDetalle()
        {
            string where = string.Format("idrendicioncajachica = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwRendicioncajachicadetList = Service.GetAllVwRendicioncajachicadet(where, "numeroitem");
            gcDetalle.DataSource = VwRendicioncajachicadetList;
            gcDetalle.EndUpdate();
         
        }
        public bool Guardar()
        {
 
            if (!Validaciones()) return false;

            RendicioncajachicaMnt.Idsucursal = (int)iIdsucursal.EditValue;
            RendicioncajachicaMnt.Idtipocp = (int)iIdtipocp.EditValue;
            RendicioncajachicaMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            RendicioncajachicaMnt.Serierendicioncaja = rSerierendicioncaja.Text.Trim();
            RendicioncajachicaMnt.Numerorendicioncaja = rNumerorendicioncaja.Text.Trim();
            RendicioncajachicaMnt.Idempleado = (int)iIdempleado.EditValue;
            RendicioncajachicaMnt.Fecharendicioncaja = (DateTime)iFecharendicioncaja.EditValue;
            RendicioncajachicaMnt.Anulado = (bool)iAnulado.EditValue;
            RendicioncajachicaMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
          
            RendicioncajachicaMnt.Comentario = iComentario.Text.Trim();
            RendicioncajachicaMnt.Idrecibocaja = (int)iIdrecibocaja.EditValue;
            RendicioncajachicaMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            RendicioncajachicaMnt.Rendicionterminada = (bool)iRendicionterminada.EditValue;
            RendicioncajachicaMnt.Idtipomoneda = (int?) iIdtipomoneda.EditValue;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //RecibocajaMnt.Createdby = IdUsuario;
                    //RecibocajaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //RecibocajaMnt.Modifiedby = IdUsuario;
                    //RecibocajaMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveRendicioncajachica(RendicioncajachicaMnt);
                    RendicioncajachicaMnt.Idrecibocaja = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;

                    if (IdEntidadMnt > 0
                        && TipoCpMnt.Numeracionauto
                        && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerorendicioncaja.EditValue)))
                    {
                        iIdtipocp.ReadOnly = true;
                        iIdcptooperacion.ReadOnly = true;
                    }

                        
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateRendicioncajachica(RendicioncajachicaMnt);
                    if (RendicioncajachicaMnt.Anulado)
                    {
                       // Service.AnularReferenciaEntradaOrdenCompraDet(RecibocajaMnt.Idrecibocaja);
                    }
                    break;
                }
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                Cursor = Cursors.Default;
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        public bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
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

                    RendicioncajachicaMnt = null;
                    RendicioncajachicaMnt = new Rendicioncajachica();

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
                        RendicioncajachicaMnt = null;
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
                        ImpresionFormato.FormatoRendicionCajaChica(RendicioncajachicaMnt);
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
        private void RendicioncajachicaMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            //XtraFormUtils.ReadOnlyFields(this, readOnly);
            WinFormUtils.ReadOnlyFields(tpDatos, readOnly);
            
        }
        private void RendicioncajachicaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            RendicioncajachicaMntItemFrm rendicioncajachicaMntItemFrm;
            VwRendicioncajachicadet vwRendicioncajachicadetMnt = new VwRendicioncajachicadet();
            Rendicioncajachicadet rendicioncajachicadet;
            const string nombreIdDetalle = "Idrendicioncajachicadet";

         
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
                    vwRendicioncajachicadetMnt.Numeroitem = VwRendicioncajachicadetList.Count + 1;

                    rendicioncajachicaMntItemFrm = new RendicioncajachicaMntItemFrm(tipoMantenimientoItem, vwRendicioncajachicadetMnt);
                    rendicioncajachicaMntItemFrm.Saldoarendir = (decimal)rPorrendir.EditValue;
                    rendicioncajachicaMntItemFrm.Idrecibocaja = (int) iIdrecibocaja.EditValue;    

                    rendicioncajachicaMntItemFrm.ShowDialog();

                    if (rendicioncajachicaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        rendicioncajachicadet = AsignarRendicioncajachicaDetalle(vwRendicioncajachicadetMnt);

                        int idrendicioncajachicadet = Service.SaveRendicioncajachicadet(rendicioncajachicadet);
                        if (idrendicioncajachicadet > 0)
                        {
                            vwRendicioncajachicadetMnt.Idrendicioncajachicadet = idrendicioncajachicadet;
                            VwRendicioncajachicadetList.Add(vwRendicioncajachicadetMnt);
                            CargarDetalle();
                            //Enfocar el id generado
                            if (idrendicioncajachicadet > 0)
                            {
                                gvDetalle.BeginUpdate();
                                var rowHandle = gvDetalle.LocateByValue(nombreIdDetalle, idrendicioncajachicadet);
                                if (rowHandle == GridControl.InvalidRowHandle)
                                {
                                    gvDetalle.EndUpdate();
                                    return;
                                }
                                gvDetalle.EndUpdate();
                                gvDetalle.FocusedRowHandle = rowHandle;
                            }

                            gvDetalle.RefreshData();
                            gvDetalle.BestFitColumns(true);

                        }
                       // CargarDetalle();
                      
                        SumarTotales(true);
                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwRendicioncajachicadetMnt = (VwRendicioncajachicadet)gvDetalle.GetFocusedRow();
                    if (vwRendicioncajachicadetMnt == null)
                    {
                        break;
                    }
                    rendicioncajachicaMntItemFrm = new RendicioncajachicaMntItemFrm(tipoMantenimientoItem, vwRendicioncajachicadetMnt);
                    rendicioncajachicaMntItemFrm.Saldoarendir = (decimal)rPorrendir.EditValue;
                    rendicioncajachicaMntItemFrm.Idrecibocaja = (int) iIdrecibocaja.EditValue;   
                    rendicioncajachicaMntItemFrm.ShowDialog();

                    if (rendicioncajachicaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        rendicioncajachicadet = AsignarRendicioncajachicaDetalle(vwRendicioncajachicadetMnt);
                        Service.UpdateRendicioncajachicadet(rendicioncajachicadet);
                        gvDetalle.RefreshData();
                        SumarTotales(true);
                    }
                   
                    break;

                case "btnDelItem":
                     int idRecibpcajadetSel = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));
                    if (idRecibpcajadetSel > 0)
                    {
                       

                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar Detalle", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwRendicioncajachicadet vwRendicioncajachicadet = (VwRendicioncajachicadet)gvDetalle.GetFocusedRow();
                            if (VwRendicioncajachicadetList.Remove(vwRendicioncajachicadet))
                            {
                                Service.DeleteRendicioncajachicadet(idRecibpcajadetSel);
                                gvDetalle.RefreshData();
                                if (!gvDetalle.IsFirstRow)
                                {
                                    gvDetalle.MovePrev();
                                }

                               
                                SumarTotales(true);
                            }
                        }
                    }
                    break;


            }         
        }
        public void EstadoModificacionImportacion()
        {
         
        }
    
        private void SumarTotales(bool actualizar)
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            rPorrendir.EditValue = rImporterecibo.EditValue;

            if (VwRendicioncajachicadetList.Count > 0)
            {
                decimal totalgasto = VwRendicioncajachicadetList.Sum(s => s.Importepago);
                decimal totalRecibo = (decimal)rImporterecibo.EditValue;
                rTotaldocumento.EditValue = totalgasto;
                rPorrendir.EditValue = totalRecibo - totalgasto;

                if (actualizar)
                {
                    Rendicioncajachica rendicioncajachica = new Rendicioncajachica();
                    rendicioncajachica.Idrendicioncajachica = IdEntidadMnt;
                    rendicioncajachica.Totaldocumento = (decimal)rTotaldocumento.EditValue;
                    Service.ActualizarTotalesRendicionCajaChica(rendicioncajachica);
                }
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private Rendicioncajachicadet AsignarRendicioncajachicaDetalle(VwRendicioncajachicadet vwRendicioncajachicadet)
        {
            Rendicioncajachicadet rendicioncajachicadet = new Rendicioncajachicadet
            {
                Idrendicioncajachica = IdEntidadMnt,
                Idrendicioncajachicadet = vwRendicioncajachicadet.Idrendicioncajachicadet,
                Idsocionegocio = vwRendicioncajachicadet.Idsocionegocio,
                Numeroitem = vwRendicioncajachicadet.Numeroitem,
                Idtipocp = vwRendicioncajachicadet.Idtipocp,
                Serietipocp = vwRendicioncajachicadet.Serietipocp,
                Numerotipocp = vwRendicioncajachicadet.Numerotipocp,
                Importepago = vwRendicioncajachicadet.Importepago,
                Fechatipocp = vwRendicioncajachicadet.Fechatipocp,
                Descripciongasto = vwRendicioncajachicadet.Descripciongasto,
                Idcpcompra = vwRendicioncajachicadet.Idcpcompra
                                           
            };
            return rendicioncajachicadet;
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
                        rSerierendicioncaja.EditValue = vwTipocp.Seriecp;
                        rNumerorendicioncaja.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerorendicioncaja.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerorendicioncaja.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerorendicioncaja.EditValue = vwTipocp.Seriecp;
                        rNumerorendicioncaja.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerorendicioncaja.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerierendicioncaja.EditValue = @"0000";
                rNumerorendicioncaja.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "CAJA-CHICA";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;

            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        public void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
            gvDetalle.OptionsBehavior.ReadOnly = true;
            HabilitarBotonesMnt(false);

           
        }
        public void CargarDocumentoReferencia()
        {
           
        }
        private void CargarInfoCorrelativoCotizacion()
        {
            var idTipoCpCotizacion = iIdTipoDocRecibo.EditValue;
            if (idTipoCpCotizacion != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipoCpCotizacion);
                rSerieTipocp.EditValue = vwTipocp.Seriecp;
            }
            else
            {
                rSerieTipocp.EditValue = @"0000";
                iNumeroTipocp.EditValue = 0;
            }
        }       
        private void btnBuscarRecibo_Click(object sender, EventArgs e)
        {
            var idTipoCp = iIdTipoDocRecibo.EditValue;
            if (idTipoCp == null)
            {
                XtraMessageBox.Show("Seleccione el tipo de documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdTipoDocRecibo.Select();
                return;
            }

            //var idEmpleado = iIdempleado.EditValue;


            int idSucursal = (int)iIdsucursal.EditValue;
            string serieCotizacion = (string)rSerieTipocp.EditValue;
            string numeroCotizacion = (string)iNumeroTipocp.EditValue;
            

            VwRecibocajaegreso recibocaja = Service.GetVwRecibocajaegreso(
                x => x.Idtipocp == (int)idTipoCp
                     && x.Idsucursal == idSucursal
                     && x.Serierecibo == serieCotizacion.Trim()
                     && x.Numerorecibo == numeroCotizacion.Trim()
                     && !x.Anulado
                     && x.Idresponsable == (int)iIdempleado.EditValue
                );
            //
            if (recibocaja != null)
            {
                //Verificar si tiene items la cotizacion
                long cantidadItemsCotizacion = Service.CountRecibocajaegresodet(x => x.Idrecibocajaegreso == recibocaja.Idrecibocajaegreso);
                if (cantidadItemsCotizacion <= 0)
                {
                    XtraMessageBox.Show("El comprobante no tiene items, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumeroTipocp.Text = @"0";
                    iNumeroTipocp.Focus();
                    iNumeroTipocp.Select();
                    iNumeroTipocp.SelectAll();
                    return;
                }


                //Verificar si el recibo tiene cuadro rendicion
                Rendicioncajachica rendicioncajachica = Service.GetRendicioncajachica(
                    x => x.Idrecibocaja == recibocaja.Idrecibocajaegreso
                    && !x.Anulado);

                if (rendicioncajachica != null)
                {
                    string numeroDocCc = string.Format("{0}-{1}", rendicioncajachica.Serierendicioncaja.Trim(), rendicioncajachica.Numerorendicioncaja);
                    XtraMessageBox.Show(string.Format("Recibo ya fue importada en la Rendicion N°: {0}", numeroDocCc), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumeroTipocp.Text = @"0";
                    iNumeroTipocp.Focus();
                    iNumeroTipocp.Select();
                    iNumeroTipocp.SelectAll();
                    return;
                }

                iIdrecibocaja.EditValue = recibocaja.Idrecibocajaegreso;
                rImporterecibo.EditValue = recibocaja.Totaldocumento;
                rFecharecibo.EditValue = recibocaja.Fecharecibo;
                XtraMessageBox.Show("Recibo de Caja encontrado con exito", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscarRecibo.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("No se encontró el número de Recibo de Caja para el empleado seleccionado, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdrecibocaja.EditValue = 0;
                iNumeroTipocp.EditValue = @"00000000";
                iNumeroTipocp.Focus();
                iNumeroTipocp.Select();
                iNumeroTipocp.SelectAll();
            }
        }
        private void iIdTipoDocRecibo_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativoCotizacion();
        }
        
    }
}