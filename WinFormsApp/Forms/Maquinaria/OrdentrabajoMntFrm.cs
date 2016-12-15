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
    public partial class OrdentrabajoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public OrdentrabajoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Ordentrabajo OrdentrabajoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<Mantenimientoimagen> MantenimientoimagenList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public string RutaArchivoServidor { get; set; }
        public OrdentrabajoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, OrdentrabajoFrm formParent) 
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
        private void OrdentrabajoMntFrm_Load(object sender, EventArgs e)
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

            iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
            //iIdempleado.Enabled = false;

            iFecharegistro.EditValue = SessionApp.DateServer;
            iFechainicial.EditValue = SessionApp.DateServer;
            iFechafinal.EditValue = SessionApp.DateServer;

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "ORDENTRABAJO";
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
                    OrdentrabajoMnt = new Ordentrabajo();                    
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
            var serieTipoCp = (string) rSerieordentrabajo.EditValue;
            var numeroTipoCp = (string) rNumeroordentrabajo.EditValue;

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
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENTRABAJO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENTRABAJO", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
            
            iIdresponsable.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = CacheObjects.VwSucursalList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            VwCentrodecostoList = CacheObjects.VwCentrodecostoList; //Service.GetAllVwCentrodecosto("descripcioncentrodecosto");
            iIdcentrocosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrocosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrocosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrocosto.Properties.BestFitMode = BestFitMode.BestFit;
           
        }        
        private void TraerDatos()
        {
            try
            {
                OrdentrabajoMnt = Service.GetOrdentrabajo(IdEntidadMnt);

                rIdsucursal.EditValue = OrdentrabajoMnt.Idsucursal;
                iIdtipocp.EditValue = OrdentrabajoMnt.Idtipocp;
                iIdcptooperacion.EditValue = OrdentrabajoMnt.Idcptooperacion;
                rSerieordentrabajo.EditValue = OrdentrabajoMnt.Serieordentrabajo;
                rNumeroordentrabajo.EditValue = OrdentrabajoMnt.Numeroordentrabajo;
                iFecharegistro.EditValue = OrdentrabajoMnt.Fecharegistro;
                iFechainicial.EditValue = OrdentrabajoMnt.Fechainicial;
                iFechafinal.EditValue = OrdentrabajoMnt.Fechafinal;
                iOtterminada.EditValue = OrdentrabajoMnt.Otterminada;
                iProgramacion.EditValue = OrdentrabajoMnt.Programacion;
                iEjecutado.EditValue = OrdentrabajoMnt.Ejecutado;
                iObservacion.EditValue = OrdentrabajoMnt.Observacion;
                iAnulado.EditValue = OrdentrabajoMnt.Anulado;
                iFechaanulado.EditValue = OrdentrabajoMnt.Fechaanulado;
                iIdresponsable.EditValue = OrdentrabajoMnt.Idresponsable;
                iDescripcionot.EditValue = OrdentrabajoMnt.Descripcionot;
                iIdcentrocosto.EditValue = OrdentrabajoMnt.Idcentrodecosto;

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


            OrdentrabajoMnt.Idsucursal = (int)rIdsucursal.EditValue;
            OrdentrabajoMnt.Idtipocp = (int)iIdtipocp.EditValue;
            OrdentrabajoMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            OrdentrabajoMnt.Serieordentrabajo = rSerieordentrabajo.Text.Trim();
            OrdentrabajoMnt.Numeroordentrabajo = rNumeroordentrabajo.Text.Trim();
            OrdentrabajoMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            OrdentrabajoMnt.Fechainicial = (DateTime)iFechainicial.EditValue;
            OrdentrabajoMnt.Fechafinal = (DateTime)iFechafinal.EditValue;
            OrdentrabajoMnt.Otterminada = (bool)iOtterminada.EditValue;
            OrdentrabajoMnt.Programacion = iProgramacion.Text.Trim();
            OrdentrabajoMnt.Ejecutado = iEjecutado.Text.Trim();
            OrdentrabajoMnt.Observacion = iObservacion.Text.Trim();
            OrdentrabajoMnt.Anulado = (bool?)iAnulado.EditValue;
            OrdentrabajoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            OrdentrabajoMnt.Idresponsable = (int)iIdresponsable.EditValue;
            OrdentrabajoMnt.Descripcionot = iDescripcionot.Text.Trim();
            OrdentrabajoMnt.Idcentrodecosto = (int?) iIdcentrocosto.EditValue;

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
                        IdEntidadMnt = Service.SaveOrdentrabajo(OrdentrabajoMnt);
                        pkIdEntidad.EditValue = IdEntidadMnt;

                        if (IdEntidadMnt > 0 && VwTipocpSel.Numeracionauto
                        && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumeroordentrabajo.EditValue)))
                        {
                            iIdtipocp.ReadOnly = true;
                            iIdcptooperacion.ReadOnly = true;
                        }

                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateOrdentrabajo(OrdentrabajoMnt);
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerieordentrabajo.Text.Trim(), rNumeroordentrabajo.Text.Trim());
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
            const string nombreTipodocMov = "ORDENTRABAJO";
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
            string numeroSerie = rSerieordentrabajo.Text.Trim();
            string numeroViaje = rNumeroordentrabajo.Text.Trim();

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

                    OrdentrabajoMnt = null;
                    OrdentrabajoMnt = new Ordentrabajo();

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
                        OrdentrabajoMnt = null;
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
        private void OrdentrabajoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void OrdentrabajoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
                        rSerieordentrabajo.EditValue = vwTipocp.Seriecp;
                        rNumeroordentrabajo.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroordentrabajo.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroordentrabajo.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroordentrabajo.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroordentrabajo.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroordentrabajo.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieordentrabajo.EditValue = @"0000";
                rNumeroordentrabajo.EditValue = 0;
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