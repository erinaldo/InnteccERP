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
    public partial class RecibocajaingresoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public RecibocajaingresoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Recibocajaingreso RecibocajaMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }

        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajadetList { get; set; }
        public List<VwRecibocajaingresoimprevisto> VwRecibocajaimprevistosList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public int IdsocionegocioPaciente { get; set; }
        public int IdcpventaCita { get; set; }
        public RecibocajaingresoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, RecibocajaingresoFrm formParent)
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

        public RecibocajaingresoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, RecibocajaingresoFrm formParent, int idsocionegocioPaciente, int idcpventaCita)
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

            IdsocionegocioPaciente = idsocionegocioPaciente;
            IdcpventaCita = idcpventaCita;
        }

        private void RecibocajaingresoMntFrm_Load(object sender, EventArgs e)
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
            iIdtiporecibo.EditValue = 1;
            iIdtiporecibo.Enabled = false;


            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "RECIBO-INGRESO";
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
                    RecibocajaMnt = new Recibocajaingreso();
                    CargarDetalle();
                    CargarDatosSocioNegocioCita();

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
                    SumarTotales(false);
                    break;
            }
        }

        private void CargarDatosSocioNegocioCita()
        {

            if (IdsocionegocioPaciente > 0)
            {
                iIdsocionegocio.EditValue = IdsocionegocioPaciente;
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

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "RECIBO-INGRESO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "RECIBO-INGRESO", SessionApp.SucursalSel.Idsucursal);
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
        private void TraerDatos()
        {
            try
            {
                RecibocajaMnt = Service.GetRecibocajaingreso(IdEntidadMnt);

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
            string where = string.Format("idrecibocajaingreso = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwRecibocajadetList = Service.GetAllVwRecibocajaingresodet(where, "numeroitem");
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
                        IdEntidadMnt = Service.SaveRecibocajaingreso(RecibocajaMnt);
                        RecibocajaMnt.Idrecibocajaingreso = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;

                        if (IdEntidadMnt > 0
                            && TipoCpMnt.Numeracionauto
                            && Service.ActualizarCorrelativo((int)iIdtipocp.EditValue, Convert.ToInt32(rNumerorecibo.EditValue)))
                        {
                            iIdtipocp.ReadOnly = true;
                            iIdcptooperacion.ReadOnly = true;
                        }

                        if (IdcpventaCita > 0)
                        {
                            VwCpventa vwCpventa = Service.GetVwCpventa(IdcpventaCita);
                            if (vwCpventa != null)
                            {
                                VwRecibocajaingresodet vwRecibocajaingresodet = new VwRecibocajaingresodet();
                                vwRecibocajaingresodet.Numeroitem = 1;

                                vwRecibocajaingresodet.Idtipodocmov = vwCpventa.Idtipodocmov;
                                vwRecibocajaingresodet.Idtipocp = vwCpventa.Idtipocp;
                                vwRecibocajaingresodet.Serietipocp = vwCpventa.Seriecpventa;
                                vwRecibocajaingresodet.Numerotipocp = vwCpventa.Numerocpventa;
                                vwRecibocajaingresodet.Importepago = vwCpventa.Importetotal;
                                vwRecibocajaingresodet.Idmediopago = 9; //Efectivo
                                vwRecibocajaingresodet.Numeromediopago = string.Empty;
                                vwRecibocajaingresodet.Comentario = string.Empty;
                                vwRecibocajaingresodet.Idcpventa = IdcpventaCita;

                                Recibocajaingresodet recibocajadet = AsignarRecibocajaDetalle(vwRecibocajaingresodet);

                                int idrecibocajadet = Service.SaveRecibocajaingresodet(recibocajadet);
                                if (idrecibocajadet > 0)
                                {
                                    //vwRecibocajaingresodet.Idrecibocajaingresodet = idrecibocajadet;
                                    //VwRecibocajadetList.Add(vwRecibocajaingresodet);

                                    //Enfocar el id generado
                                    if (idrecibocajadet > 0)
                                    {
                                        CargarDetalle();
                                        var rowHandle = gvDetalle.LocateByValue("Idrecibocajaingresodet", idrecibocajadet);
                                        if (rowHandle != GridControl.InvalidRowHandle)
                                        {
                                            gvDetalle.FocusedRowHandle = rowHandle;
                                        }                                       
                                        
                                    }

                                    gvDetalle.RefreshData();
                                    gvDetalle.BestFitColumns(true);

                                }
                                CargarDetalleImprevistos();
                                SumarTotales(true);

                            }

                        }

                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateRecibocajaingreso(RecibocajaMnt);
                        if (RecibocajaMnt.Anulado)
                        {
                            // Service.AnularReferenciaEntradaOrdenCompraDet(RecibocajaMnt.Idrecibocaja);
                        }
                        break;
                }
                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();


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
                    RecibocajaMnt = new Recibocajaingreso();

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


                    List<VwRecibocajaingresodet> vwRecibocajadetMntList = new List<VwRecibocajaingresodet>();

                    RecibocajaImpCtacteClienteFrm recibocajaImpCtacteClienteFrm = new RecibocajaImpCtacteClienteFrm(vwRecibocajadetMntList, VwSocionegocioSel,(int)iIdtipomoneda.EditValue);
                    recibocajaImpCtacteClienteFrm.ShowDialog();

                    if (recibocajaImpCtacteClienteFrm.DialogResult == DialogResult.OK)
                    {
                        VwRecibocajaingreso vwRecibocajaSelImp = recibocajaImpCtacteClienteFrm.VwRecibocajaSel;
                        if (vwRecibocajaSelImp != null)
                        {
                            iIdsocionegocio.EditValue = vwRecibocajaSelImp.Idsocionegocio;
                            iIdtipomoneda.EditValue = vwRecibocajaSelImp.Idtipomoneda;
                        }

                        foreach (var item in vwRecibocajadetMntList)
                        {
                            Recibocajaingresodet recibocajadet = new Recibocajaingresodet();
                            recibocajadet.Idrecibocajaingreso = IdEntidadMnt;
                            recibocajadet.Idrecibocajaingresodet = item.Idrecibocajaingresodet;
                            recibocajadet.Numeroitem = item.Numeroitem;
                            recibocajadet.Importepago = item.Importepago;
                            recibocajadet.Idmediopago = item.Idmediopago;
                            recibocajadet.Numeromediopago = item.Numeromediopago;
                            recibocajadet.Comentario = item.Comentario;
                            recibocajadet.Idcpventa = item.Idcpventa;
                            Service.SaveRecibocajaingresodet(recibocajadet);
                        }

                        //Asignar la moneda
                        

                        CargarDetalle();
                        CargarDetalleImprevistos();
                        SumarTotales(true);
                    }
                    break;
                case "btnImprimir":
                    //if (EntradaalmacenImpresion == null)
                    //{
                    //    EntradaalmacenImpresion = new EntradaalmacenImpresion();
                    //}
                    //if (IdEntidadMnt > 0)
                    //{
                    //    EntradaalmacenImpresion.VistaPrevia(IdEntidadMnt);
                    //}
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
        private void RecibocajaingresoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void RecibocajaingresoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            RecibocajaingresoMntItemFrm recibocajaMntItemFrm;
            VwRecibocajaingresodet vwRecibocajadetMnt = new VwRecibocajaingresodet();
            Recibocajaingresodet recibocajadet;
            const string nombreIdDetalle = "Idrecibocajaingresodet";

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

                    recibocajaMntItemFrm = new RecibocajaingresoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetMnt);
                    recibocajaMntItemFrm.ShowDialog();

                    if (recibocajaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        recibocajadet = AsignarRecibocajaDetalle(vwRecibocajadetMnt);

                        int idrecibocajadet = Service.SaveRecibocajaingresodet(recibocajadet);
                        if (idrecibocajadet > 0)
                        {
                            vwRecibocajadetMnt.Idrecibocajaingresodet = idrecibocajadet;
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
                    vwRecibocajadetMnt = (VwRecibocajaingresodet)gvDetalle.GetFocusedRow();
                    if (vwRecibocajadetMnt == null)
                    {
                        break;
                    }
                    recibocajaMntItemFrm = new RecibocajaingresoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetMnt);
                    recibocajaMntItemFrm.ShowDialog();

                    if (recibocajaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        recibocajadet = AsignarRecibocajaDetalle(vwRecibocajadetMnt);
                        Service.UpdateRecibocajaingresodet(recibocajadet);
                        gvDetalle.RefreshData();
                        SumarTotales(true);
                    }

                    break;

                case "btnDelItem":
                    int idRecibpcajadetSel = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, nombreIdDetalle));
                    if (idRecibpcajadetSel > 0)
                    {
                        int cantidadRefImprevistos = VwRecibocajaimprevistosList.Count(x => x.Idrecibocajaingresodet == idRecibpcajadetSel);
                        if (cantidadRefImprevistos > 0)
                        {
                            XtraMessageBox.Show("No puede eliminar tiene referencia en Pagos Relacionados al Documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar Detalle", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            VwRecibocajaingresodet vwRecibocajadet = (VwRecibocajaingresodet)gvDetalle.GetFocusedRow();
                            if (VwRecibocajadetList.Remove(vwRecibocajadet))
                            {
                                Service.DeleteRecibocajaingresodet(idRecibpcajadetSel);
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
            VwRecibocajaingresodet recibocajadet = (VwRecibocajaingresodet)gvDetalle.GetFocusedRow();
            if (recibocajadet != null)
            {
                string condicion = string.Format("idrecibocajaingresodet ={0}", recibocajadet.Idrecibocajaingresodet);
                const string orden = "idrecibocajaingresoimprevisto";
                VwRecibocajaimprevistosList = Service.GetAllVwRecibocajaingresoimprevisto(condicion, orden);
                gcImprevistoDet.DataSource = VwRecibocajaimprevistosList;
                gvImprevistoDet.BestFitColumns();

            }
        }
        private void SumarTotales(bool actualizar)
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();

            Recibocajaingreso recibocaja = new Recibocajaingreso();
            
            if (VwRecibocajadetList.Count > 0)
            {
                decimal totalbruto = VwRecibocajadetList.Sum(s => s.Importepago);
                decimal totalOtros = VwRecibocajaimprevistosList.Sum(s => s.Importepago);

                rTotaldocumento.EditValue = totalbruto + totalOtros;

                recibocaja.Idrecibocajaingreso = IdEntidadMnt;
                recibocaja.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            }
            else
            {
                rTotaldocumento.EditValue = 0m;

                recibocaja.Idrecibocajaingreso = IdEntidadMnt;
                recibocaja.Totaldocumento = 0m;
            }

            if (actualizar)
            {

                Service.ActualizarTotalesReciboCajaIngreso(recibocaja);
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private Recibocajaingresodet AsignarRecibocajaDetalle(VwRecibocajaingresodet vwRecibocajadet)
        {
            Recibocajaingresodet recibocajadetMnt = new Recibocajaingresodet
            {
                Idrecibocajaingreso = IdEntidadMnt,
                Idrecibocajaingresodet = vwRecibocajadet.Idrecibocajaingresodet,
                Numeroitem = vwRecibocajadet.Numeroitem,
                Importepago = vwRecibocajadet.Importepago,
                Idmediopago = vwRecibocajadet.Idmediopago,
                Numeromediopago = vwRecibocajadet.Numeromediopago,
                Comentario = vwRecibocajadet.Comentario,
                Idcpventa = vwRecibocajadet.Idcpventa,
                Idnotacreditocli = vwRecibocajadet.Idnotacreditocli,
                Importenc = vwRecibocajadet.Importenc

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
            const string nombreTipodocMov = "RECIBO-INGRESO";
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
            RecibocajaingresoimprevistoMntItemFrm recibocajaimprevistosMntItemFrm;
            const string nombreidrecibocajaimprevito = "Idrecibocajaingresoimprevisto";
            VwRecibocajaingresodet vwRecibocajadetRef = (VwRecibocajaingresodet)gvDetalle.GetFocusedRow();
            VwRecibocajaingresoimprevisto vwRecibocajaimprevistosMnt;

            if (vwRecibocajadetRef == null)
            {
                return;
            }


            switch (e.Item.Name)
            {
                case "cmdAddImprevisto":
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwRecibocajaimprevistosMnt = new VwRecibocajaingresoimprevisto();
                    recibocajaimprevistosMntItemFrm = new RecibocajaingresoimprevistoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetRef, vwRecibocajaimprevistosMnt);

                    recibocajaimprevistosMntItemFrm.ShowDialog();

                    if (recibocajaimprevistosMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Recibocajaingresoimprevisto recibocajaimprevistos = AsignarRecibocajaimprevisto(vwRecibocajaimprevistosMnt);

                        int idrecibocajaimprevisto = Service.SaveRecibocajaingresoimprevisto(recibocajaimprevistos);
                        if (idrecibocajaimprevisto > 0)
                        {
                            vwRecibocajaimprevistosMnt.Idrecibocajaingresoimprevisto = idrecibocajaimprevisto;
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
                    vwRecibocajaimprevistosMnt = (VwRecibocajaingresoimprevisto)gvImprevistoDet.GetFocusedRow();
                    recibocajaimprevistosMntItemFrm = new RecibocajaingresoimprevistoMntItemFrm(tipoMantenimientoItem, vwRecibocajadetRef, vwRecibocajaimprevistosMnt);

                    recibocajaimprevistosMntItemFrm.ShowDialog();
                    if (recibocajaimprevistosMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Recibocajaingresoimprevisto recibocajaimprevistos = AsignarRecibocajaimprevisto(vwRecibocajaimprevistosMnt);

                        Service.UpdateRecibocajaingresoimprevisto(recibocajaimprevistos);
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
                            VwRecibocajaingresoimprevisto vwRecibocajaimprevistosSel = (VwRecibocajaingresoimprevisto)gvImprevistoDet.GetFocusedRow();
                            if (VwRecibocajaimprevistosList.Remove(vwRecibocajaimprevistosSel))
                            {
                                Service.DeleteRecibocajaingresoimprevisto(idrecibocajaimprevistoSel);
                                gvImprevistoDet.RefreshData();
                                SumarTotales(true);
                            }

                        }
                    }
                    break;
            }
        }
        private Recibocajaingresoimprevisto AsignarRecibocajaimprevisto(VwRecibocajaingresoimprevisto vwRecibocajaimprevistosMnt)
        {
            Recibocajaingresoimprevisto recibocajaimprevistos = new Recibocajaingresoimprevisto();
            recibocajaimprevistos.Idrecibocajaingresoimprevisto = vwRecibocajaimprevistosMnt.Idrecibocajaingresoimprevisto;
            recibocajaimprevistos.Idrecibocajaingresodet = vwRecibocajaimprevistosMnt.Idrecibocajaingresodet;
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