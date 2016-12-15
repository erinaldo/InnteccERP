using System;
using System.Collections.Generic;
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
    public partial class ValorizaciondanioelementoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ValorizaciondanioelementoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Valorizaciondanioelemento ValorizaciondanioelementoMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<VwValorizacionelemento> VwValorizacionelementoList { get; set; }
        public List<VwValorizaciondanio> VwValorizaciondanioList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public ImpresionFormato ImpresionFormato { get; set; }
        public string RutaArchivoServidor { get; set; }
        public ValorizaciondanioelementoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ValorizaciondanioelementoFrm formParent)
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
        private void ValorizaciondanioelementoMntFrm_Load(object sender, EventArgs e)
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

            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "VALORIZACIONELEMENTO";
                //Valores por defecto
                Valorpordefecto valorpordefecto = Service.ObtenerObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov);
                if (valorpordefecto != null)
                {
                    iIdtipocp.EditValue = valorpordefecto.Idtipocp;
                }

            }

            if (SessionApp.EmpresaSel.Idarticulodanio != null &&
                SessionApp.EmpresaSel.Idarticuloelementodesgaste != null)
            {
                iIdarticulodanio.EditValue = (int)SessionApp.EmpresaSel.Idarticulodanio;
                iIdarticuloelementodesgaste.EditValue = (int)SessionApp.EmpresaSel.Idarticuloelementodesgaste;

                CargarArticuloDanio((int)iIdarticulodanio.EditValue);
                CargarArticuloElemento((int)iIdarticuloelementodesgaste.EditValue);
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
                    ValorizaciondanioelementoMnt = new Valorizaciondanioelemento();
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdresponsable.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    EstadoReferenciaCpVenta();

                    break;
            }
        }

        private void EstadoReferenciaCpVenta()
        {
            if (Service.ValorizaciondanioelementoTieneReferenciaCpVenta(
                ValorizaciondanioelementoMnt.Idvalorizacion,
                ValorizaciondanioelementoMnt.Idarticulodanio,
                ValorizaciondanioelementoMnt.Idarticuloelementodesgaste))
            {
                XtraMessageBox.Show("El registro tiene referencia en comprobante de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.Editable = false;
            }
        }

        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "VALORIZACIONELEMENTO", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "VALORIZACIONELEMENTO", SessionApp.SucursalSel.Idsucursal);
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




        }
        private void TraerDatos()
        {
            try
            {

                ValorizaciondanioelementoMnt = Service.GetValorizaciondanioelemento(IdEntidadMnt);

                iIdtipocp.EditValue = ValorizaciondanioelementoMnt.Idtipocp;
                iIdcptooperacion.EditValue = ValorizaciondanioelementoMnt.Idcptooperacion;
                iIdvalorizacion.EditValue = ValorizaciondanioelementoMnt.Idvalorizacion;
                rIdsucursal.EditValue = ValorizaciondanioelementoMnt.Idsucursal;
                iIdresponsable.EditValue = ValorizaciondanioelementoMnt.Idresponsable;
                iFecharegistro.EditValue = ValorizaciondanioelementoMnt.Fecharegistro;
                iIdarticulodanio.EditValue = ValorizaciondanioelementoMnt.Idarticulodanio;
                iIdarticuloelementodesgaste.EditValue = ValorizaciondanioelementoMnt.Idarticuloelementodesgaste;
                iComentario.EditValue = ValorizaciondanioelementoMnt.Comentario;
                iAnulado.EditValue = ValorizaciondanioelementoMnt.Anulado;
                iFechaanulado.EditValue = ValorizaciondanioelementoMnt.Fechaanulado;
                rSeriede.EditValue = ValorizaciondanioelementoMnt.Seriede;
                rNumerode.EditValue = ValorizaciondanioelementoMnt.Numerode;
                rTotaldanio.EditValue = ValorizaciondanioelementoMnt.Totaldanio;
                rTotalelemento.EditValue = ValorizaciondanioelementoMnt.Totalelemento;
                rTotaldocumento.EditValue = ValorizaciondanioelementoMnt.Totaldocumento;

                CargarDatosValorizacion(ValorizaciondanioelementoMnt.Idvalorizacion);
                CargarArticuloDanio(ValorizaciondanioelementoMnt.Idarticulodanio);
                CargarArticuloElemento(ValorizaciondanioelementoMnt.Idarticuloelementodesgaste);
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private void CargarArticuloElemento(int idarticuloelementodesgaste)
        {
            VwArticulo vwArticulo = Service.GetVwArticulo(idarticuloelementodesgaste);
            if (vwArticulo != null)
            {
                iIdarticuloelementodesgaste.EditValue = vwArticulo.Idarticulo;
                beArticuloDesgaste.Text = vwArticulo.Nombrearticulo;
                iMarcaarticuloDesgaste.EditValue = vwArticulo.Nombremarca;
                iUnidadmedidaDesgaste.EditValue = vwArticulo.Abrunidadmedida;
            }
        }
        private void CargarArticuloDanio(int idarticulodanio)
        {
            VwArticulo vwArticulo = Service.GetVwArticulo(idarticulodanio);
            if (vwArticulo != null)
            {
                iIdarticulodanio.EditValue = vwArticulo.Idarticulo;
                beArticuloDanio.Text = vwArticulo.Nombrearticulo;
                iMarcaarticuloDanio.EditValue = vwArticulo.Nombremarca;
                iUnidadmedidaDanio.EditValue = vwArticulo.Abrunidadmedida;

            }
        }
        private void CargarDatosValorizacion(int idvalorizacion)
        {
            VwValorizacion vwValorizacion = Service.GetVwValorizacion(idvalorizacion);
            if (vwValorizacion != null)
            {
                rNumeroValorizacion.EditValue = vwValorizacion.Numerovalorizacion;
                rCliente.EditValue = vwValorizacion.Razonsocial;
                rMoneda.EditValue = vwValorizacion.Nombretipomoneda;
                rTotalvalorizacion.EditValue = vwValorizacion.Totaldocumento;
                rProyecto.EditValue = vwValorizacion.Nombreproyecto;
                rEquipo.EditValue = vwValorizacion.Nombreequipo;
                iIdvalorizacion.EditValue = vwValorizacion.Idvalorizacion;
            }
        }
        private void CargarDetalle()
        {
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string whereElemento = string.Format("idvalorizaciondanioelemento = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwValorizacionelementoList = Service.GetAllVwValorizacionelemento(whereElemento, "numeroitem");
            gcDetalle.DataSource = VwValorizacionelementoList;
            gcDetalle.EndUpdate();

            gvDetalle2.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string whereDanio = string.Format("idvalorizaciondanioelemento = '{0}'", IdEntidadMnt);
            gcDetalle2.BeginUpdate();
            VwValorizaciondanioList = Service.GetAllVwValorizaciondanio(whereDanio, "numeroitem");
            gcDetalle2.DataSource = VwValorizaciondanioList;
            gcDetalle2.EndUpdate();

            SumarTotales();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            ValorizaciondanioelementoMnt.Idtipocp = (int)iIdtipocp.EditValue;
            ValorizaciondanioelementoMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            ValorizaciondanioelementoMnt.Idvalorizacion = (int)iIdvalorizacion.EditValue;
            ValorizaciondanioelementoMnt.Idsucursal = (int)rIdsucursal.EditValue;
            ValorizaciondanioelementoMnt.Idresponsable = (int)iIdresponsable.EditValue;
            ValorizaciondanioelementoMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            ValorizaciondanioelementoMnt.Idarticulodanio = (int)iIdarticulodanio.EditValue;
            ValorizaciondanioelementoMnt.Idarticuloelementodesgaste = (int)iIdarticuloelementodesgaste.EditValue;
            ValorizaciondanioelementoMnt.Comentario = iComentario.Text.Trim();
            ValorizaciondanioelementoMnt.Anulado = (bool)iAnulado.EditValue;
            ValorizaciondanioelementoMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            ValorizaciondanioelementoMnt.Seriede = rSeriede.Text.Trim();
            ValorizaciondanioelementoMnt.Numerode = rNumerode.Text.Trim();
            ValorizaciondanioelementoMnt.Totaldanio = (decimal)rTotaldanio.EditValue;
            ValorizaciondanioelementoMnt.Totalelemento = (decimal)rTotalelemento.EditValue;
            ValorizaciondanioelementoMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;
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

                        //IdEntidadMnt = Service.SaveValorizaciondanioelemento(ValorizaciondanioelementoMnt);
                        //ValorizaciondanioelementoMnt.Idvalorizaciondanioelemento = IdEntidadMnt;
                        //pkIdEntidad.EditValue = IdEntidadMnt;

                        if (Service.GuardarValorizacionDanioElemento(TipoMnt, ValorizaciondanioelementoMnt, VwValorizacionelementoList, VwValorizaciondanioList))
                        {
                            IdEntidadMnt = ValorizaciondanioelementoMnt.Idvalorizaciondanioelemento;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        //Service.GuardarMantenimiento(TipoMnt, ValorizaciondanioelementoMnt, MantenimientoimagenList, RutaArchivoServidor);
                        if (Service.GuardarValorizacionDanioElemento(TipoMnt, ValorizaciondanioelementoMnt, VwValorizacionelementoList, VwValorizaciondanioList))
                        {
                            IdEntidadMnt = ValorizaciondanioelementoMnt.Idvalorizaciondanioelemento;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSeriede.Text.Trim(), rNumerode.Text.Trim());
                Cursor = Cursors.Default;


                if (IdEntidadMnt > 0)
                    RegistrarValoresPorDefecto();

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
            const string nombreTipodocMov = "VALORIZACIONELEMENTO";
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

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpConfiguracion, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (gvDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("Ingrese items de elementos de desgaste.", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (gvDetalle2.RowCount == 0)
            {
                XtraMessageBox.Show("Ingrese items de daño.", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSeriede.Text.Trim();
            string numeroViaje = rNumerode.Text.Trim();

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

                    TipoMnt = TipoMantenimiento.Nuevo;

                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    ValorizaciondanioelementoMnt = null;
                    ValorizaciondanioelementoMnt = new Valorizaciondanioelemento();

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
                        ValorizaciondanioelementoMnt = null;
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
                        var idValorizacion = iIdvalorizacion.EditValue;
                        if (idValorizacion != null)
                        {
                            Valorizacion valorizacionMnt = Service.GetValorizacion((int)idValorizacion);
                            ImpresionFormato.FormatoElementoDesgasteDanio(valorizacionMnt);
                        }
                    }
                    break;
                case "btnSeleccionarValorizacion":
                    SeleccionarValorizacionElementoFrm seleccionarValorizacionElementoFrm = new SeleccionarValorizacionElementoFrm();
                    seleccionarValorizacionElementoFrm.ShowDialog();
                    if (seleccionarValorizacionElementoFrm.VwValorizacionSel != null)
                    {
                        rNumeroValorizacion.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Numerovalorizacion;
                        rCliente.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Razonsocial;
                        rMoneda.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Nombretipomoneda;
                        rTotalvalorizacion.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Totaldocumento;
                        rProyecto.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Nombreproyecto;
                        rEquipo.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Nombreequipo;
                        iIdvalorizacion.EditValue = seleccionarValorizacionElementoFrm.VwValorizacionSel.Idvalorizacion;
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
        private void ValorizaciondanioelementoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ValorizaciondanioelementoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            VwValorizacionelemento vwValorizacionelementoMnt;
            ValorizacionelementoMntItemFrm valorizacionelementoMntItemFrm;

            switch (e.Item.Name)
            {
                case "btnAddItem":


                    vwValorizacionelementoMnt = new VwValorizacionelemento();
                    var sgtItem = VwValorizacionelementoList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwValorizacionelementoMnt.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    valorizacionelementoMntItemFrm = new ValorizacionelementoMntItemFrm(tipoMantenimientoItem, vwValorizacionelementoMnt, VwValorizacionelementoList);
                    valorizacionelementoMntItemFrm.ShowDialog();

                    if (valorizacionelementoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizacionelementoList.Add(vwValorizacionelementoMnt);

                        SumarTotales();
                        if (!gvDetalle.IsLastRow)
                        {
                            gvDetalle.MoveLastVisible();
                            gvDetalle.Focus();
                        }
                    }

                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    vwValorizacionelementoMnt = (VwValorizacionelemento)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    valorizacionelementoMntItemFrm = new ValorizacionelementoMntItemFrm(tipoMantenimientoItem, vwValorizacionelementoMnt, VwValorizacionelementoList);
                    valorizacionelementoMntItemFrm.ShowDialog();

                    if (valorizacionelementoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
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

                        vwValorizacionelementoMnt = (VwValorizacionelemento)gvDetalle.GetFocusedRow();
                        vwValorizacionelementoMnt.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }
                    }
                    break;
            }

        }
        private void SumarTotales()
        {

            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();

            decimal totalDanio = VwValorizaciondanioList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Subtotal);
            decimal totalElemento = VwValorizacionelementoList.Where(w => w.DataEntityState != DataEntityState.Deleted).Sum(s => s.Subtotal);
            decimal totalDocumento = totalDanio + totalElemento;

            rTotaldanio.EditValue = totalDanio;
            rTotalelemento.EditValue = totalElemento;
            rTotaldocumento.EditValue = totalDocumento;

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);


            gvDetalle2.BeginDataUpdate();
            gvDetalle2.RefreshData();

            gvDetalle2.EndDataUpdate();
            gvDetalle2.BestFitColumns(true);
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
                        rSeriede.EditValue = vwTipocp.Seriecp;
                        rNumerode.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerode.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerode.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerode.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerode.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerode.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriede.EditValue = @"0000";
                rNumerode.EditValue = 0;
            }
        }
        private void iAnulado_CheckedChanged(object sender, EventArgs e)
        {
            iFechaanulado.EditValue = iAnulado.Checked ? (object)DateTime.Now : null;
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
        private void beArticuloDesgaste_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticuloElemento();
                    break;
            }
        }
        private void BuscarArticuloElemento()
        {
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();

            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticuloelementodesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;
                beArticuloDesgaste.Text = buscadorArticuloInventarioFrm.VwArticuloSel.Nombrearticulo;
                iMarcaarticuloDesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Nombremarca;
                iUnidadmedidaDesgaste.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Abrunidadmedida;

            }
        }
        private void beArticuloDanio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticuloDanio();
                    break;
            }
        }
        private void BuscarArticuloDanio()
        {
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();

            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulodanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;
                beArticuloDanio.Text = buscadorArticuloInventarioFrm.VwArticuloSel.Nombrearticulo;
                iMarcaarticuloDanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Nombremarca;
                iUnidadmedidaDanio.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Abrunidadmedida;

            }

        }
        private void bmItems2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            VwValorizaciondanio vwValorizaciondanioMnt;
            ValorizaciondanioMntItemFrm valorizaciondanioMntItemFrmMntItemFrm;

            switch (e.Item.Name)
            {
                case "btnAddItem2":


                    vwValorizaciondanioMnt = new VwValorizaciondanio();
                    var sgtItem = VwValorizaciondanioList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwValorizaciondanioMnt.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    valorizaciondanioMntItemFrmMntItemFrm = new ValorizaciondanioMntItemFrm(tipoMantenimientoItem, vwValorizaciondanioMnt, VwValorizaciondanioList);
                    valorizaciondanioMntItemFrmMntItemFrm.ShowDialog();

                    if (valorizaciondanioMntItemFrmMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwValorizaciondanioList.Add(vwValorizaciondanioMnt);

                        SumarTotales();
                        if (!gvDetalle2.IsLastRow)
                        {
                            gvDetalle2.MoveLastVisible();
                            gvDetalle2.Focus();
                        }
                    }

                    break;

                case "btnEditItem2":
                    if (gvDetalle2.RowCount == 0)
                    {
                        break;
                    }

                    vwValorizaciondanioMnt = (VwValorizaciondanio)gvDetalle2.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    valorizaciondanioMntItemFrmMntItemFrm = new ValorizaciondanioMntItemFrm(tipoMantenimientoItem, vwValorizaciondanioMnt, VwValorizaciondanioList);
                    valorizaciondanioMntItemFrmMntItemFrm.ShowDialog();

                    if (valorizaciondanioMntItemFrmMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }
                    break;
                case "btnDelItem2":
                    if (gvDetalle2.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwValorizaciondanioMnt = (VwValorizaciondanio)gvDetalle2.GetFocusedRow();
                        vwValorizaciondanioMnt.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle2.IsFirstRow)
                        {
                            gvDetalle2.MovePrev();
                        }

                        SumarTotales();

                    }
                    break;
            }
        }
    }
}