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
    public partial class DetraccionclienteMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public DetraccionclienteFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Detraccioncliente DetraccionclienteMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public VwCpventa VwCpventaSel { get; set; }
        public DetraccionclienteMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, DetraccionclienteFrm formParent) 
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
        private void DetraccionclienteMntFrm_Load(object sender, EventArgs e)
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

            iFechapago.EditValue = SessionApp.DateServer;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
            //iIdempleado.Enabled = false;

            iFechapago.EditValue = DateTime.Now;


            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "DETRACCION-CLIENTE";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                    iIdcptooperacion.EditValue = valorpordefecto.Idcptooperacion;
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
                    DetraccionclienteMnt = new Detraccioncliente();                    
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    EstadoReferenciaCaja();
                    iIdresponsable.Enabled = IdUsuario <= 0;                
                    break;
            }           
        }
        private void EstadoReferenciaCaja()
        {
            var idTipoCp = (int) iIdtipocp.EditValue;
            var serieTipoCp = (string) rSeriedetraccion.EditValue;
            var numeroTipoCp = (string) rNumerodetraccion.EditValue;

            if (Service.CpVentaTieneReferenciaCaja(idTipoCp, serieTipoCp, numeroTipoCp))
            {
                XtraMessageBox.Show("El Comprobante de venta tiene Recibo de Caja", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
            }
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "DETRACCION-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "DETRACCION-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdresponsable.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = CacheObjects.VwSucursalList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

           
        }        
        private void TraerDatos()
        {
            try
            {
                DetraccionclienteMnt = Service.GetDetraccioncliente(IdEntidadMnt);

                rIdsucursal.EditValue = DetraccionclienteMnt.Idsucursal;
                iIdtipocp.EditValue = DetraccionclienteMnt.Idtipocp;
                iIdcptooperacion.EditValue = DetraccionclienteMnt.Idcptooperacion;
                rSeriedetraccion.EditValue = DetraccionclienteMnt.Seriedetraccion;
                rNumerodetraccion.EditValue = DetraccionclienteMnt.Numerodetraccion;
                iFechapago.EditValue = DetraccionclienteMnt.Fechapago;
                iIdresponsable.EditValue = DetraccionclienteMnt.Idresponsable;
                nPorcentajedetraccion.EditValue = DetraccionclienteMnt.Porcentajedetraccion;
                iIdcpventa.EditValue = DetraccionclienteMnt.Idcpventa;
                rImportedeposito.EditValue = DetraccionclienteMnt.Importedeposito;
                iAnulado.EditValue = DetraccionclienteMnt.Anulado;
                iFechaanulado.EditValue = DetraccionclienteMnt.Fechaanulado;
                iObservacion.EditValue = DetraccionclienteMnt.Observacion;
                nTipocambio.EditValue = DetraccionclienteMnt.Tipocambio;

                CargarDatosComprobante(DetraccionclienteMnt.Idcpventa);

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

            DetraccionclienteMnt.Idsucursal = (int)rIdsucursal.EditValue;
            DetraccionclienteMnt.Idtipocp = (int)iIdtipocp.EditValue;
            DetraccionclienteMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            DetraccionclienteMnt.Seriedetraccion = rSeriedetraccion.Text.Trim();
            DetraccionclienteMnt.Numerodetraccion = rNumerodetraccion.Text.Trim();
            DetraccionclienteMnt.Fechapago = (DateTime)iFechapago.EditValue;
            DetraccionclienteMnt.Idresponsable = (int)iIdresponsable.EditValue;
            DetraccionclienteMnt.Porcentajedetraccion = (decimal)nPorcentajedetraccion.EditValue;
            DetraccionclienteMnt.Idcpventa = (int)iIdcpventa.EditValue;
            DetraccionclienteMnt.Importedeposito = (decimal)rImportedeposito.EditValue;
            DetraccionclienteMnt.Anulado = (bool)iAnulado.EditValue;
            DetraccionclienteMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            DetraccionclienteMnt.Observacion = iObservacion.Text.Trim();
            DetraccionclienteMnt.Tipocambio = (decimal)nTipocambio.EditValue;
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
                        IdEntidadMnt = Service.SaveDetraccioncliente(DetraccionclienteMnt);
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateDetraccioncliente(DetraccionclienteMnt);
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriedetraccion.Text.Trim(), rNumerodetraccion.Text.Trim());
                Cursor = Cursors.Default;


                if (IdEntidadMnt > 0)
                {
                    RegistrarValoresPorDefecto();
                }



                XtraMessageBox.Show("Se guardo correctamente el documento " + numeroDoc, "Atención",
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
            int idEmpleado = (int)iIdresponsable.EditValue;
            const string nombreTipodocMov = "DETRACCION-CLIENTE";
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
            string numeroSerie = rSeriedetraccion.Text.Trim();
            string numeroViaje = rNumerodetraccion.Text.Trim();

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

                    DetraccionclienteMnt = null;
                    DetraccionclienteMnt = new Detraccioncliente();

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
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DetraccionclienteMnt = null;
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
                case "btnSeleccionarCpVenta":
                    DetraccionClienteSelCpVentaFrm seleccionarOrdentrabajoFrm = new DetraccionClienteSelCpVentaFrm();
                    if (seleccionarOrdentrabajoFrm.ShowDialog() == DialogResult.OK && seleccionarOrdentrabajoFrm.VwCpventaSel != null)
                    {
                        CargarDatosComprobante(seleccionarOrdentrabajoFrm.VwCpventaSel.Idcpventa);
                        iIdcpventa.EditValue = seleccionarOrdentrabajoFrm.VwCpventaSel.Idcpventa;
                    }
                    break;
           
            }
        }
        private void CargarDatosComprobante(int idcpventa)
        {
            VwCpventa vwCpventaSel = Service.GetVwCpventa(idcpventa);
            if (vwCpventaSel != null)
            {
                iDocCpVenta.EditValue = string.Format("{0}{1}-{2}", vwCpventaSel.Abreviaturatipoformato.Trim(), vwCpventaSel.Seriecpventa, vwCpventaSel.Numerocpventa);
                iClienteCpVenta.EditValue = vwCpventaSel.Razonsocialcliente;
                iDocEntidadCliente.EditValue = string.Format("{0} {1}", vwCpventaSel.Abreviaturadocentidadcliente, vwCpventaSel.Nrodocprincipalcliente);
                iFechaCpVenta.EditValue = vwCpventaSel.Fechaemision;
                iSimboloMonedaCpVenta.EditValue = vwCpventaSel.Simbolomoneda;
                iTotalCpVenta.EditValue = vwCpventaSel.Totaldocumento;
                nTipocambio.EditValue = ObtenerTipoDeCambioVentaSunat(vwCpventaSel.Fechaemision);
                VwCpventaSel = vwCpventaSel;
            }
        }

        private decimal ObtenerTipoDeCambioVentaSunat(DateTime fechaemision)
        {

            Tipocambio tipocambio = Service.GetTipocambio(x => x.Fechatipocambio == fechaemision);
            if (tipocambio != null)
            {
                return tipocambio.Valorventasunat;
            }
            return 0m;
        }
        private void DeshabilitarModificacion()
        {
            CamposSoloLectura(true);
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
        private void DetraccionclienteMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DetraccionclienteMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
                        rSeriedetraccion.EditValue = vwTipocp.Seriecp;

                        rNumerodetraccion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerodetraccion.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerodetraccion.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerodetraccion.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerodetraccion.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerodetraccion.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriedetraccion.EditValue = @"0000";
                rNumerodetraccion.EditValue = 0;
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

        private void nPorcentajedetraccion_EditValueChanged(object sender, EventArgs e)
        {
            if (VwCpventaSel != null)
            {
                decimal importeCp = VwCpventaSel.Totaldocumento;
                decimal tipoCambio = (decimal)nTipocambio.EditValue;
                decimal porcentajeDetraccion = (decimal)nPorcentajedetraccion.EditValue;
                switch (VwCpventaSel.Idtipomoneda)
                {
                    case 1: //Soles
                        rImportedeposito.EditValue = Math.Round(importeCp * (porcentajeDetraccion / 100), 2);
                        break;
                    case 2: //Dolares
                        rImportedeposito.EditValue = Math.Round((importeCp * tipoCambio) * (porcentajeDetraccion / 100), 2);
                        break;
                }
            }
        }
    }    
}