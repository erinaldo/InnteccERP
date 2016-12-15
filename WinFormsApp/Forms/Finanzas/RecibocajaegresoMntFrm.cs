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
using DevExpress.XtraGrid.Views.Base;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class RecibocajaegresoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public RecibocajaegresoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Recibocajaegreso RecibocajaMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }

        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwRecibocajaegresodet> VwRecibocajadetList { get; set; }
        public List<VwRecibocajaegresoimprevisto> VwRecibocajaimprevistosList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public RecibocajaegresoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, RecibocajaegresoFrm formParent)
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
        private void RecibocajaegresoMntFrm_Load(object sender, EventArgs e)
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFecharecibo.EditValue = SessionApp.DateServer;
            iFechapago.EditValue = SessionApp.DateServer;
            iIdtipomoneda.EditValue = 1;

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
            iIdtiporecibo.EditValue = 2;
            iIdtiporecibo.Enabled = false;


            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "RECIBO-EGRESO";
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
                    RecibocajaMnt = new Recibocajaegreso();
                    CargarDetalle();

                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();

                    CargarDetalle();
                    EstadoReferenciaCajaChica();
                    if (iAnulado.Checked)
                    {
                        DeshabilitarModificacion();
                    }
                    SumarTotales(false);
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
            bsiImportar.Enabled = !enabled;
            btnCtacteCliente.Enabled = !enabled;

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

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "RECIBO-EGRESO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "RECIBO-EGRESO", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipomoneda.Properties.DataSource = Service.GetAllTipomoneda();
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtiporecibo.Properties.DataSource = Service.GetAllTiporecibocaja("nombretiporecibo");
            iIdtiporecibo.Properties.DisplayMember = "Nombretiporecibo";
            iIdtiporecibo.Properties.ValueMember = "Idtiporecibo";
            iIdtiporecibo.Properties.BestFitMode = BestFitMode.BestFit;


        }
        private void EstadoReferenciaCajaChica()
        {

            if (Service.CajaegresoTieneReferenciaCajaChica(IdEntidadMnt))
            {
                XtraMessageBox.Show("El Recibo de Egreso Tiene Caja Chica", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                BarMntItems.BeginUpdate();
                foreach (BarItem item in bmItems.Items)
                {
                    item.Enabled = false;
                }
                BarMntItems.EndUpdate();
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }
        private void TraerDatos()
        {
            try
            {
                RecibocajaMnt = Service.GetRecibocajaegreso(IdEntidadMnt);

                iIdsucursal.EditValue = RecibocajaMnt.Idsucursal;
                iIdtipocp.EditValue = RecibocajaMnt.Idtipocp;
                iIdcptooperacion.EditValue = RecibocajaMnt.Idcptooperacion;
                rSerierecibo.EditValue = RecibocajaMnt.Serierecibo;
                rNumerorecibo.EditValue = RecibocajaMnt.Numerorecibo;
                iIdempleado.EditValue = RecibocajaMnt.Idempleado;
                iIdsocionegocio.EditValue = RecibocajaMnt.Idsocionegocio;
                iFecharecibo.EditValue = RecibocajaMnt.Fecharecibo;
                iFechapago.EditValue = RecibocajaMnt.Fecharecibo;
                iAnulado.EditValue = RecibocajaMnt.Anulado;
                iFechaanulado.EditValue = RecibocajaMnt.Fechaanulado;
                iTipocambio.EditValue = RecibocajaMnt.Tipocambio;
                iIdtipomoneda.EditValue = RecibocajaMnt.Idtipomoneda;

                iComentario.EditValue = RecibocajaMnt.Comentario;

                iIdtiporecibo.EditValue = RecibocajaMnt.Idtiporecibo;

                rTotaldocumento.EditValue = RecibocajaMnt.Totaldocumento;

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
            string where = string.Format("idrecibocajaegreso = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwRecibocajadetList = Service.GetAllVwRecibocajaegresodet(where, "numeroitem");
            gcDetalle.DataSource = VwRecibocajadetList;
            gcDetalle.EndUpdate();
            gvDetalle.BestFitColumns();

        }
        public bool Guardar()
        {

            if (!Validaciones()) return false;

            RecibocajaMnt.Idsucursal = (int)iIdsucursal.EditValue;
            RecibocajaMnt.Idtipocp = (int)iIdtipocp.EditValue;
            RecibocajaMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            RecibocajaMnt.Serierecibo = rSerierecibo.Text.Trim();
            RecibocajaMnt.Numerorecibo = rNumerorecibo.Text.Trim();
            RecibocajaMnt.Idempleado = (int)iIdempleado.EditValue;
            RecibocajaMnt.Idsocionegocio = (int)iIdsocionegocio.EditValue;
            RecibocajaMnt.Fecharecibo = (DateTime)iFecharecibo.EditValue;
            RecibocajaMnt.Fechapago = (DateTime)iFechapago.EditValue;
            RecibocajaMnt.Anulado = (bool)iAnulado.EditValue;
            RecibocajaMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            RecibocajaMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            RecibocajaMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;

            RecibocajaMnt.Comentario = iComentario.Text.Trim();
            RecibocajaMnt.Idtiporecibo = (int)iIdtiporecibo.EditValue;
            RecibocajaMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
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
                        IdEntidadMnt = Service.SaveRecibocajaegreso(RecibocajaMnt);
                        RecibocajaMnt.Idrecibocajaegreso = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;

                        if (IdEntidadMnt > 0
                            && TipoCpMnt.Numeracionauto
                            && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerorecibo.EditValue)))
                        {
                            iIdtipocp.ReadOnly = true;
                            iIdcptooperacion.ReadOnly = true;
                        }


                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateRecibocajaegreso(RecibocajaMnt);
                        if (RecibocajaMnt.Anulado)
                        {
                            // Service.AnularReferenciaEntradaOrdenCompraDet(RecibocajaMnt.Idrecibocaja);
                        }
                        break;
                }
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

                Cursor = Cursors.Default;

                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerierecibo.Text.Trim(), rNumerorecibo.Text.Trim());
                Cursor = Cursors.Default;

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

                    TipoMnt = TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    RecibocajaMnt = null;
                    RecibocajaMnt = new Recibocajaegreso();

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
                        RecibocajaMnt = null;
                        DialogResult = DialogResult.OK;
                    }
                    break;
                case "btnCtacteCliente":
                    if (!ValidarDatosImportacion()) return;


                    List<VwRecibocajaegresodet> vwRecibocajadetMntList = new List<VwRecibocajaegresodet>();

                    RecibocajaImpCtacteProveedorFrm recibocajaImpCtacteProveedorFrm = new RecibocajaImpCtacteProveedorFrm(vwRecibocajadetMntList, VwSocionegocioSel, (int)iIdtipomoneda.EditValue);
                    recibocajaImpCtacteProveedorFrm.ShowDialog();

                    if (recibocajaImpCtacteProveedorFrm.DialogResult == DialogResult.OK)
                    {
                        VwRecibocajaegreso vwRecibocajaSelImp = recibocajaImpCtacteProveedorFrm.VwRecibocajaSel;
                        if (vwRecibocajaSelImp != null)
                        {
                            iIdsocionegocio.EditValue = vwRecibocajaSelImp.Idsocionegocio;
                            iIdtipomoneda.EditValue = vwRecibocajaSelImp.Idtipomoneda;
                        }

                        foreach (var item in vwRecibocajadetMntList)
                        {
                            Recibocajaegresodet recibocajadet = new Recibocajaegresodet();
                            recibocajadet.Idrecibocajaegreso = IdEntidadMnt;
                            recibocajadet.Idrecibocajaegresodet = item.Idrecibocajaegresodet;
                            recibocajadet.Numeroitem = item.Numeroitem;
                            recibocajadet.Importepago = item.Importepago;
                            recibocajadet.Idmediopago = item.Idmediopago;
                            recibocajadet.Numeromediopago = item.Numeromediopago;
                            recibocajadet.Comentario = item.Comentario;
                            recibocajadet.Idcpcompra = item.Idcpcompra;
                            Service.SaveRecibocajaegresodet(recibocajadet);
                        }


                        CargarDetalle();
                        CargarDetalleImprevistos();
                        SumarTotales(true);
                    }
                    break;
                case "btnImprimir":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        ImpresionFormato.FormatoReciboEgreso(RecibocajaMnt);
                    }
                    break;
            }
        }
        private bool ValidarDatosImportacion()
        {
            int idClienteSel = (int)iIdsocionegocio.EditValue;
            if (idClienteSel == 0)
            {
                XtraMessageBox.Show("Seleccione el Socio de Negocio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                beSocioNegocio.Focus();
                beSocioNegocio.Select();
                return false;
            }

            if ((int)pkIdEntidad.EditValue == 0)
            {
                XtraMessageBox.Show("Grabe la informacion.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
        private void RecibocajaegresoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void RecibocajaegresoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            RecibocajaegresoMntItemFrm recibocajaMntItemFrm;
            VwRecibocajaegresodet vwRecibocajadetMnt = new VwRecibocajaegresodet();
            Recibocajaegresodet recibocajadet;
            const string nombreIdDetalle = "Idrecibocajaegresodet";

            ParametrosSocioNegocio.Idsocionegocio = (int)iIdsocionegocio.EditValue;

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
                    vwRecibocajadetMnt.Numeroitem = VwRecibocajadetList.Count + 1;

                    recibocajaMntItemFrm = new RecibocajaegresoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetMnt);
                    recibocajaMntItemFrm.ShowDialog();

                    if (recibocajaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        recibocajadet = AsignarRecibocajaDetalle(vwRecibocajadetMnt);

                        int idrecibocajadet = Service.SaveRecibocajaegresodet(recibocajadet);
                        if (idrecibocajadet > 0)
                        {
                            vwRecibocajadetMnt.Idrecibocajaegresodet = idrecibocajadet;
                            VwRecibocajadetList.Add(vwRecibocajadetMnt);

                            //Enfocar el id generado
                            if (idrecibocajadet > 0)
                            {
                                gvDetalle.BeginUpdate();
                                CargarDetalle();
                                var rowHandle = gvDetalle.LocateByValue(nombreIdDetalle, idrecibocajadet);
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
                        CargarDetalleImprevistos();
                        SumarTotales(true);
                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwRecibocajadetMnt = (VwRecibocajaegresodet)gvDetalle.GetFocusedRow();
                    if (vwRecibocajadetMnt == null)
                    {
                        break;
                    }
                    recibocajaMntItemFrm = new RecibocajaegresoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetMnt);
                    recibocajaMntItemFrm.ShowDialog();

                    if (recibocajaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        recibocajadet = AsignarRecibocajaDetalle(vwRecibocajadetMnt);
                        Service.UpdateRecibocajaegresodet(recibocajadet);
                        gvDetalle.RefreshData();
                        SumarTotales(true);
                    }

                    break;

                case "btnDelItem":
                    int idRecibpcajadetSel = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));
                    if (idRecibpcajadetSel > 0)
                    {
                        int cantidadRefImprevistos = VwRecibocajaimprevistosList.Count(x => x.Idrecibocajaegresodet == idRecibpcajadetSel);
                        if (cantidadRefImprevistos > 0)
                        {
                            XtraMessageBox.Show("No puede eliminar tiene referencia en Pagos Relacionados al Documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar Detalle", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwRecibocajaegresodet vwRecibocajadet = (VwRecibocajaegresodet)gvDetalle.GetFocusedRow();
                            if (VwRecibocajadetList.Remove(vwRecibocajadet))
                            {
                                Service.DeleteRecibocajaegresodet(idRecibpcajadetSel);
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
        private void CargarDetalleImprevistos()
        {
            VwRecibocajaegresodet recibocajadet = (VwRecibocajaegresodet)gvDetalle.GetFocusedRow();
            if (recibocajadet != null)
            {
                string condicion = string.Format("idrecibocajaegresodet ={0}", recibocajadet.Idrecibocajaegresodet);
                const string orden = "idrecibocajaegresoimprevisto";
                VwRecibocajaimprevistosList = Service.GetAllVwRecibocajaegresoimprevisto(condicion, orden);
                gcImprevistoDet.DataSource = VwRecibocajaimprevistosList;
                gvImprevistoDet.BestFitColumns();

            }
        }
        private void SumarTotales(bool actualizar)
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();

            Recibocajaegreso recibocaja = new Recibocajaegreso();
            
            if (VwRecibocajadetList.Count > 0)
            {
                decimal totalbruto = VwRecibocajadetList.Sum(s => s.Importepago);
                decimal totalOtros = VwRecibocajaimprevistosList.Sum(s => s.Importepago);

                rTotaldocumento.EditValue = totalbruto + totalOtros;

                recibocaja.Idrecibocajaegreso = IdEntidadMnt;
                recibocaja.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            }
            else
            {
                rTotaldocumento.EditValue = 0m;

                recibocaja.Idrecibocajaegreso = IdEntidadMnt;
                recibocaja.Totaldocumento = 0m;
            }

            if (actualizar)
            {

                Service.ActualizarTotalesReciboCajaEgreso(recibocaja);
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private Recibocajaegresodet AsignarRecibocajaDetalle(VwRecibocajaegresodet vwRecibocajadet)
        {
            Recibocajaegresodet recibocajadetMnt = new Recibocajaegresodet
            {
                Idrecibocajaegreso = IdEntidadMnt,
                Idrecibocajaegresodet = vwRecibocajadet.Idrecibocajaegresodet,
                Numeroitem = vwRecibocajadet.Numeroitem,
                Importepago = vwRecibocajadet.Importepago,
                Idmediopago = vwRecibocajadet.Idmediopago,
                Numeromediopago = vwRecibocajadet.Numeromediopago,
                Comentario = vwRecibocajadet.Comentario,
                Idcpcompra = vwRecibocajadet.Idcpcompra

            };
            return recibocajadetMnt;
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
                        rSerierecibo.EditValue = vwTipocp.Seriecp;
                        rNumerorecibo.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerorecibo.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerorecibo.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerorecibo.EditValue = vwTipocp.Seriecp;
                        rNumerorecibo.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerorecibo.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerierecibo.EditValue = @"0000";
                rNumerorecibo.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            VwSocionegocio vwSocionegocioSel;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        vwSocionegocioSel = buscarSocioNegocioFrm.VwSocionegocioSel;

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;

                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdsocionegocio.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                            beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                            iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                        }
                    }
                    break;
            }
        }
        private void iIdsocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioMnt = iIdsocionegocio.EditValue;
            if (idSocioNegocioMnt == null || (int)idSocioNegocioMnt <= 0) return;

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int)idSocioNegocioMnt);
            VwSocionegocioSel = vwSocionegocioSel;
            if (vwSocionegocioSel != null)
            {
                beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;

            }
        }
        private void RegistrarValoresPorDefecto()
        {
            //Registrar valores por defecto
            int idSucursal = (int)iIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "RECIBO-EGRESO";
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

            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = false;
            }

        }
        public void CargarDocumentoReferencia()
        {

        }
        private void gvDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleImprevistos();
        }
        private void bmUbicaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            RecibocajaegresoimprevistoMntItemFrm recibocajaimprevistosMntItemFrm;
            const string nombreidrecibocajaimprevito = "Idrecibocajaegresoimprevisto";
            VwRecibocajaegresodet vwRecibocajadetRef = (VwRecibocajaegresodet)gvDetalle.GetFocusedRow();
            VwRecibocajaegresoimprevisto vwRecibocajaimprevistosMnt;

            if (vwRecibocajadetRef == null)
            {
                return;
            }


            switch (e.Item.Name)
            {
                case "cmdAddImprevisto":
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwRecibocajaimprevistosMnt = new VwRecibocajaegresoimprevisto();
                    recibocajaimprevistosMntItemFrm = new RecibocajaegresoimprevistoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetRef, vwRecibocajaimprevistosMnt);

                    recibocajaimprevistosMntItemFrm.ShowDialog();

                    if (recibocajaimprevistosMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Recibocajaegresoimprevisto recibocajaimprevistos = AsignarRecibocajaimprevisto(vwRecibocajaimprevistosMnt);

                        int idrecibocajaimprevisto = Service.SaveRecibocajaegresoimprevisto(recibocajaimprevistos);
                        if (idrecibocajaimprevisto > 0)
                        {
                            vwRecibocajaimprevistosMnt.Idrecibocajaegresoimprevisto = idrecibocajaimprevisto;
                        }

                        VwRecibocajaimprevistosList.Add(vwRecibocajaimprevistosMnt);
                        gvImprevistoDet.RefreshData();

                        //Enfocar el id generado
                        if (idrecibocajaimprevisto > 0)
                        {
                            gvImprevistoDet.BeginUpdate();
                            var rowHandle = gvImprevistoDet.LocateByValue(nombreidrecibocajaimprevito, idrecibocajaimprevisto);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {
                                gvImprevistoDet.EndUpdate();
                                return;
                            }
                            gvImprevistoDet.EndUpdate();
                            gvImprevistoDet.FocusedRowHandle = rowHandle;
                        }
                        //CargarDetalleImprevistos();
                        SumarTotales(true);
                    }
                    break;
                case "cmdEditImprevisto":

                    if (gvImprevistoDet.RowCount <= 0)
                    {
                        return;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    vwRecibocajaimprevistosMnt = (VwRecibocajaegresoimprevisto)gvImprevistoDet.GetFocusedRow();
                    recibocajaimprevistosMntItemFrm = new RecibocajaegresoimprevistoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetRef, vwRecibocajaimprevistosMnt);

                    recibocajaimprevistosMntItemFrm.ShowDialog();
                    if (recibocajaimprevistosMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Recibocajaegresoimprevisto recibocajaimprevistos = AsignarRecibocajaimprevisto(vwRecibocajaimprevistosMnt);

                        Service.UpdateRecibocajaegresoimprevisto(recibocajaimprevistos);
                        gvImprevistoDet.RefreshData();
                    }
                    //CargarDetalleImprevistos();
                    SumarTotales(true);
                    break;
                case "cmdDelImprevisto":
                    int idrecibocajaimprevistoSel = Convert.ToInt32(gvImprevistoDet.GetRowCellValue(gvImprevistoDet.FocusedRowHandle, nombreidrecibocajaimprevito));
                    if (idrecibocajaimprevistoSel > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwRecibocajaegresoimprevisto vwRecibocajaimprevistosSel = (VwRecibocajaegresoimprevisto)gvImprevistoDet.GetFocusedRow();
                            if (VwRecibocajaimprevistosList.Remove(vwRecibocajaimprevistosSel))
                            {
                                Service.DeleteRecibocajaegresoimprevisto(idrecibocajaimprevistoSel);
                                gvImprevistoDet.RefreshData();
                                SumarTotales(true);
                            }

                        }
                    }
                    break;
            }
        }
        private Recibocajaegresoimprevisto AsignarRecibocajaimprevisto(VwRecibocajaegresoimprevisto vwRecibocajaimprevistosMnt)
        {
            Recibocajaegresoimprevisto recibocajaimprevistos = new Recibocajaegresoimprevisto();
            recibocajaimprevistos.Idrecibocajaegresoimprevisto = vwRecibocajaimprevistosMnt.Idrecibocajaegresoimprevisto;
            recibocajaimprevistos.Idrecibocajaegresodet = vwRecibocajaimprevistosMnt.Idrecibocajaegresodet;
            recibocajaimprevistos.Idtipocp = vwRecibocajaimprevistosMnt.Idtipocp;
            recibocajaimprevistos.Serietipocp = vwRecibocajaimprevistosMnt.Serietipocp;
            recibocajaimprevistos.Numerotipocp = vwRecibocajaimprevistosMnt.Numerotipocp;
            recibocajaimprevistos.Importepago = vwRecibocajaimprevistosMnt.Importepago;
            return recibocajaimprevistos;
        }
        public static class ParametrosSocioNegocio
        {
            public static int Idsocionegocio { get; set; }
        }

    }
}