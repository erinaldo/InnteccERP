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
    public partial class OrdendeventaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public OrdendeventaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Ordendeventa OrdendeventaMnt { get; set; }
        public VwOrdendeventa VwOrdendeventaMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public VwSucursal VwSucursalSel { get; set; }
        public List<VwOrdendeventadet> VwOrdendeventadetList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public List<Socionegociodireccion> SocionegociodireccionList { get; set; }
        public List<VwSucursal> VwSucursalList { get; set; }
        public List<VwTipocp> VwTipoCpVentaList { get; set; }
        public List<VwEmpleado> VwEmpleadoList { get; set; }
        public OrdenVentaItem OrdenVentaItemParameter { get; set; }
        public List<Socionegociocontacto> SocionegociocontactoList { get; set; }
        public OrdendeventaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, OrdendeventaFrm formParent)
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
            WinFormUtils.SetEnterMoveNextControl(tpOrdendeventa,true);
            WinFormUtils.SetEnterMoveNextControl(tpLogistica, true);
            WinFormUtils.SetEnterMoveNextControl(tpReferencias, true);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;



        }
        private void OrdendeventaMntFrm_Load(object sender, EventArgs e)
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

            iFechaordenventa.EditValue = SessionApp.DateServer;

            iIdtipomoneda.EditValue = 1;
            iIdimpuesto.EditValue = 1;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;


            iFechaordenventa.EditValue = SessionApp.DateServer;
            iFechaentrega.EditValue = SessionApp.DateServer;


            if (SessionApp.EmpleadoSel == null)
            {
                iIdempleado.EditValue = null;
                iIdempleado.Enabled = true;
            }
            else
            {
                iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdempleado.Enabled = false;
                iIdtipoCpVenta.EditValue = SessionApp.EmpleadoSel.Idtipocpventa;
            }


            if (SessionApp.EmpleadoSel != null)
            {
                int idSucursal = SessionApp.SucursalSel.Idsucursal;
                int idEmpleado = SessionApp.EmpleadoSel.Idempleado;
                const string nombreTipodocMov = "ORDEN-VENTA";
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
                    OrdendeventaMnt = new Ordendeventa();
                    CargarDetalle();
                    ObtenerTipoDeCambioVentaSunat();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdempleado.Enabled = IdUsuario <= 0;
                    CargarDetalle();
                    if (iAnulado.Checked)
                    {
                        HabilitarBotonesMnt(false);
                        CamposSoloLectura(true);
                        gvDetalle.OptionsBehavior.ReadOnly = true;
                    }
                    break;
            }
        }
        private void EstadoReferenciaCpventa()
        {
            if (Service.OrdenVentaTieneReferenciaCpventa(IdEntidadMnt))
            {
                XtraMessageBox.Show("La orden de venta tiene Documento de Venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HabilitarBotonesMnt(false);
                CamposSoloLectura(true);
                gvDetalle.OptionsBehavior.ReadOnly = true;
            }
        }
        private void EstadoReferenciaValorizacion()
        {
            if (Service.OrdenVentaTieneReferenciaValorizacion(IdEntidadMnt))
            {
                XtraMessageBox.Show("La orden de venta ya tiene Valorizacion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //HabilitarBotonesMnt(false);
                //CamposSoloLectura(true);
                //gvDetalle.OptionsBehavior.ReadOnly = true;
            }
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDEN-VENTA", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDEN-VENTA", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionList = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacion.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            ImpuestoList = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DataSource = ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            VwEmpleadoList = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DataSource = VwEmpleadoList;
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            rIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            rIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            rIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            VwSucursalList = CacheObjects.VwSucursalList;
            rIdsucursal.Properties.DataSource = VwSucursalList;
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipolista.Properties.DataSource = Service.GetAllTipolista();
            rIdtipolista.Properties.DisplayMember = "Nombretipolista";
            rIdtipolista.Properties.ValueMember = "Idtipolista";
            rIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            VwTipoCpVentaList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "CPVENTA" && x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdtipoCpVenta.Properties.DataSource = VwTipoCpVentaList;
            iIdtipoCpVenta.Properties.DisplayMember = "Nombretipocp";
            iIdtipoCpVenta.Properties.ValueMember = "Idtipocp";
            iIdtipoCpVenta.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                Cursor = Cursors.WaitCursor;

                VwOrdendeventaMnt = Service.GetVwOrdendeventa(IdEntidadMnt);

                iIdtipocp.EditValue = VwOrdendeventaMnt.Idtipocp;
                rSerieordenventa.EditValue = VwOrdendeventaMnt.Serieordenventa;
                rNumeroordenventa.EditValue = VwOrdendeventaMnt.Numeroordenventa.Trim();
                iFechaordenventa.EditValue = VwOrdendeventaMnt.Fechaordenventa;
                iAnulado.EditValue = VwOrdendeventaMnt.Anulado;
                iFechaanulado.EditValue = VwOrdendeventaMnt.Fechaanulado;
                iIdempleado.EditValue = VwOrdendeventaMnt.Idempleado;
                iIdcliente.EditValue = VwOrdendeventaMnt.Idcliente;
                beSocioNegocio.EditValue = VwOrdendeventaMnt.Razonsocial;

                CargarReferenciasCliente(VwOrdendeventaMnt.Idcliente);

                iPersonacontacto.EditValue = VwOrdendeventaMnt.Personacontacto;
                iPersonadestinario.EditValue = VwOrdendeventaMnt.Personadestinario;
                iIddireccionentrega.EditValue = VwOrdendeventaMnt.Iddireccionentrega;
                iIddireccionfacturacion.EditValue = VwOrdendeventaMnt.Iddireccionfacturacion;

                rIdtipolista.EditValue = VwOrdendeventaMnt.Idtipolista;
                iTipocambio.EditValue = VwOrdendeventaMnt.Tipocambio;
                iIdtipomoneda.EditValue = VwOrdendeventaMnt.Idtipomoneda;
                rIdtipocondicion.EditValue = VwOrdendeventaMnt.Idtipocondicion;

                rTotalbruto.EditValue = VwOrdendeventaMnt.Totalbruto;
                rTotalgravado.EditValue = VwOrdendeventaMnt.Totalgravado;
                rTotalinafecto.EditValue = VwOrdendeventaMnt.Totalinafecto;
                rtotalexonerado.EditValue = VwOrdendeventaMnt.Totalexonerado;
                rTotalimpuesto.EditValue = VwOrdendeventaMnt.Totalimpuesto;
                rImportetotal.EditValue = VwOrdendeventaMnt.Importetotal;
                rPorcentajepercepcion.EditValue = VwOrdendeventaMnt.Porcentajepercepcion;
                rImportetotalpercepcion.EditValue = VwOrdendeventaMnt.Importetotalpercepcion;
                rTotaldocumento.EditValue = VwOrdendeventaMnt.Totaldocumento;


                iGlosaordenventa.EditValue = VwOrdendeventaMnt.Glosaordenventa;
                iFechaentrega.EditValue = VwOrdendeventaMnt.Fechaentrega;
                iIdimpuesto.EditValue = VwOrdendeventaMnt.Idimpuesto;
                rIdsucursal.EditValue = VwOrdendeventaMnt.Idsucursal;
                rIncluyeimpuestoitems.EditValue = VwOrdendeventaMnt.Incluyeimpuestoitems;
                iDocrefcliente.EditValue = VwOrdendeventaMnt.Docrefcliente;
                iIdcptooperacion.EditValue = VwOrdendeventaMnt.Idcptooperacion;

                iIdtipoCpVenta.EditValue = VwOrdendeventaMnt.Idtipocpventa;

                rListadocotref.EditValue = VwOrdendeventaMnt.Listadocotcliref;
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
        private void CargarDetalle()
        {
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);

            string where = string.Format("idordendeventa = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwOrdendeventadetList = Service.GetAllVwOrdendeventadetalle(where, "numeroitem");
            gcDetalle.DataSource = VwOrdendeventadetList;
            SumarTotales();
            gcDetalle.EndUpdate();

        }
        private bool Guardar()
        {
            if (!Validaciones()) return false;

            OrdendeventaMnt = new Ordendeventa();

            OrdendeventaMnt.Idordendeventa = (int)pkIdEntidad.EditValue;
            OrdendeventaMnt.Idtipocp = (int)iIdtipocp.EditValue;
            OrdendeventaMnt.Serieordenventa = rSerieordenventa.Text.Trim();
            OrdendeventaMnt.Numeroordenventa = rNumeroordenventa.Text.Trim();

            OrdendeventaMnt.Fechaordenventa = (DateTime)iFechaordenventa.EditValue;
            OrdendeventaMnt.Anulado = (bool)iAnulado.EditValue;
            OrdendeventaMnt.Fechaanulado = (DateTime?)iFechaanulado.EditValue;
            OrdendeventaMnt.Idempleado = (int)iIdempleado.EditValue;
            OrdendeventaMnt.Idcliente = (int)iIdcliente.EditValue;

            OrdendeventaMnt.Iddireccionentrega = (int)iIddireccionentrega.EditValue;
            OrdendeventaMnt.Iddireccionfacturacion = (int)iIddireccionfacturacion.EditValue;

            OrdendeventaMnt.Personacontacto = (int?)iPersonacontacto.EditValue;
            OrdendeventaMnt.Personadestinario = iPersonadestinario.Text.Trim();
            OrdendeventaMnt.Idtipolista = (int)rIdtipolista.EditValue;
            OrdendeventaMnt.Tipocambio = (decimal)iTipocambio.EditValue;
            OrdendeventaMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
            OrdendeventaMnt.Idtipocondicion = (int)rIdtipocondicion.EditValue;

            OrdendeventaMnt.Totalbruto = (decimal)rTotalbruto.EditValue;
            OrdendeventaMnt.Totalgravado = (decimal)rTotalgravado.EditValue;
            OrdendeventaMnt.Totalinafecto = (decimal)rTotalinafecto.EditValue;
            OrdendeventaMnt.Totalexonerado = (decimal)rtotalexonerado.EditValue;
            OrdendeventaMnt.Importetotal = (decimal)rImportetotal.EditValue;
            OrdendeventaMnt.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
            OrdendeventaMnt.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
            OrdendeventaMnt.Totaldocumento = (decimal)rTotaldocumento.EditValue;

            OrdendeventaMnt.Glosaordenventa = iGlosaordenventa.Text.Trim();
            OrdendeventaMnt.Fechaentrega = (DateTime)iFechaentrega.EditValue;

            OrdendeventaMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            OrdendeventaMnt.Idsucursal = (int)rIdsucursal.EditValue;
            OrdendeventaMnt.Incluyeimpuestoitems = (bool)rIncluyeimpuestoitems.EditValue;
            OrdendeventaMnt.Docrefcliente = (string)iDocrefcliente.EditValue;
            OrdendeventaMnt.Idcptooperacion = (int)iIdcptooperacion.EditValue;
            OrdendeventaMnt.Idtipocpventa = (int?)iIdtipoCpVenta.EditValue;
            OrdendeventaMnt.Listadocotcliref = rListadocotref.Text.Trim();
            //VwOrdendeventadetList


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

                        if (Service.GuardarOrdendeVenta(TipoMnt, OrdendeventaMnt, VwOrdendeventadetList))
                        {
                            IdEntidadMnt = OrdendeventaMnt.Idordendeventa;
                            pkIdEntidad.EditValue = IdEntidadMnt;
                        }
                        else
                        {
                            XtraMessageBox.Show("Error no se puedo terminar la transacción", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.GuardarOrdendeVenta(TipoMnt, OrdendeventaMnt, VwOrdendeventadetList);
                        break;
                }
                var numeroDoc = string.Format("{0} {1}-{2}", iIdtipocp.Text.Trim(), rSerieordenventa.Text.Trim(), rNumeroordenventa.Text.Trim());
                Cursor = Cursors.Default;

                if (tcCotizaCliente.SelectedTabPage == tpLogistica)
                {
                    tcCotizaCliente.SelectedTabPage = tpOrdendeventa;
                }

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
            //Registrar valores por defecto
            int idSucursal = (int)rIdsucursal.EditValue;
            int idEmpleado = (int)iIdempleado.EditValue;
            const string nombreTipodocMov = "ORDEN-VENTA";
            int idTipoCpPorDefecto = (int)iIdtipocp.EditValue;
            int idCptoOperacionPorDefecto = (int)iIdcptooperacion.EditValue;
            Service.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov, idTipoCpPorDefecto,
                idCptoOperacionPorDefecto);
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpOrdendeventa, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpOrdendeventa;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpLogistica, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpLogistica;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCpVenta, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCpVenta;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            //Validar que la cantidad no sea cero

            var itemsCantidadInvalida = VwOrdendeventadetList.Where(x => x.Cantidad <= 0 && x.DataEntityState != DataEntityState.Deleted);
            string msgItemCantidad = itemsCantidadInvalida.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemCantidad))
            {
                XtraMessageBox.Show("Existe items con cantidad cero verifique: \n\n" + msgItemCantidad, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Validar que el precio unitario no sea cero

            var itemsPrecioUniInvalido = VwOrdendeventadetList.Where(x => x.Preciounitario <= 0);
            string msgItemPreUni = itemsPrecioUniInvalido.Aggregate(string.Empty, (current, item) => current + "-" + item.Nombrearticulo + "\n");
            if (!string.IsNullOrEmpty(msgItemPreUni))
            {
                XtraMessageBox.Show("Existe items con precio unitario cero verifique: \n\n" + msgItemPreUni, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            decimal tipoCambio = (decimal)iTipocambio.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2 && tipoCambio == 0m) //Dolares
            {
                XtraMessageBox.Show("Ingrese un tipo de cambio valido", "Tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iTipocambio.Select();
                return false;
            }

            var idTipoCpVentaAgenerarSel = iIdtipoCpVenta.EditValue;
            VwTipocp vwTipocpVentaAgenerarSel = VwTipoCpVentaList.FirstOrDefault(x => x.Idtipocp == (int)idTipoCpVentaAgenerarSel);
            if (vwTipocpVentaAgenerarSel != null)
            {
                if (vwTipocpVentaAgenerarSel.Requierenumerorucvalido)
                {
                    if (VwSocionegocioSel.Nrodocentidadprincipal.Trim().Length != 11)
                    {
                        string razonSocial = VwSocionegocioSel.Razonsocial.Trim();
                        string documentoCliente = string.Format("{0} {1}", VwSocionegocioSel.Abreviaturadocentidad, VwSocionegocioSel.Nrodocentidadprincipal);
                        string documentoVentaAgenerar = string.Format("{0} {1}", vwTipocpVentaAgenerarSel.Nombretipocp, vwTipocpVentaAgenerarSel.Seriecp);
                        WinFormUtils.MessageWarning(string.Format("El cliente: {0}\ntiene un número de documento invalido: {1}\npara el documento: {2}", razonSocial, documentoCliente, documentoVentaAgenerar));
                        return false;
                    }
                }
            }


            if (iAnulado.Checked)
            {
                if (Service.OrdenVentaTieneReferenciaCpventa(IdEntidadMnt))
                {
                    XtraMessageBox.Show("La orden de venta tiene Documento de Venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (Service.OrdenVentaTieneReferenciaValorizacion(IdEntidadMnt))
                {
                    XtraMessageBox.Show("La orden de venta ya tiene Valorizacion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }



            //MessageBox.Show(VwSocionegocioSel.Razonsocial);

            int idSucursal = (int)rIdsucursal.EditValue;
            int idTipoCp = (int)iIdtipocp.EditValue;
            string numeroSerie = rSerieordenventa.Text.Trim();
            string numeroViaje = rNumeroordenventa.Text.Trim();

            if (TipoMnt == TipoMantenimiento.Nuevo && Service.NumeroOrdendeventaExiste(idSucursal, idTipoCp, numeroSerie, numeroViaje))
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
                        Service.DeleteOrdendeventadetalle(IdEntidadMnt);
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

                    OrdendeventaMnt = null;
                    OrdendeventaMnt = new Ordendeventa();

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
                        OrdendeventaMnt = null;
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
                        //ImpresionFormato.VistaPreviaOrdenDeCompra(OrdendeventaMnt);
                    }
                    break;
                case "btnCotizacion":
                    var idClienteSel = iIdcliente.EditValue;
                    if ((int)idClienteSel == 0)
                    {
                        XtraMessageBox.Show("Seleccione el Cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        beSocioNegocio.Select();
                        return;
                    }

                    var vwSocionegocioSel = Service.GetVwSocionegocio(x => x.Idsocionegocio == (int)iIdcliente.EditValue);

                    OrdendeventaImpCotizaFrm ordendeventaImpCotizaFrm = new OrdendeventaImpCotizaFrm(VwOrdendeventadetList, vwSocionegocioSel);
                    ordendeventaImpCotizaFrm.ShowDialog();

                    if (ordendeventaImpCotizaFrm.DialogResult == DialogResult.OK)
                    {
                        VwCotizacioncliente vwCotizacionclienteSelImp = ordendeventaImpCotizaFrm.VwCotizacionclienteSel;
                        if (vwCotizacionclienteSelImp != null)
                        {
                            iIdcliente.EditValue = vwCotizacionclienteSelImp.Idcliente;
                            iIdtipomoneda.EditValue = vwCotizacionclienteSelImp.Idtipomoneda;
                            rIdtipocondicion.EditValue = vwCotizacionclienteSelImp.Idtipocondicion;
                            iPersonacontacto.EditValue = vwCotizacionclienteSelImp.Personacontacto;
                            iPersonadestinario.EditValue = vwCotizacionclienteSelImp.Personadestinario;
                            iDocrefcliente.EditValue = vwCotizacionclienteSelImp.Docrefcliente;
                        }
                        foreach (var item in VwOrdendeventadetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            CalculaItem1(item);
                        }

                        ListarDocumentosReferencia();
                        SumarTotales();


                    }
                    break;
            }
        }
        private void EstadoMenuImportacion()
        {
            if (rListadocotref.Text.Trim().Length == 0)
            {
                btnCotizacion.Enabled = false;
                gcCotizacion.Visible = false;

                btnAddItem.Enabled = true;
                btnEditItem.Enabled = true;

                if (gvDetalle.RowCount == 0)
                {
                    btnCotizacion.Enabled = true;
                    gcCotizacion.Visible = false;
                    btnAddItem.Enabled = true;
                    btnEditItem.Enabled = true;

                }
            }
            else
            {
                btnCotizacion.Enabled = true;
                gcCotizacion.Visible = true;
                btnAddItem.Enabled = false;
                btnEditItem.Enabled = false;
            }
            gvDetalle.BestFitColumns(true);

        }
        private void ListarDocumentosReferencia()
        {
            List<string> listadoNumeroCot = new List<string>();

            List<string> serieNumeroCotList = VwOrdendeventadetList
                .Where(
                x => x.DataEntityState != DataEntityState.Deleted
                && !string.IsNullOrEmpty(x.Serienumerocotizacion))
                .Select(p => p.Serienumerocotizacion).Distinct().ToList();

            if (serieNumeroCotList.Count > 0)
            {
                foreach (string serieNumeroCot in serieNumeroCotList)
                {
                    string[] splitSerieNumeroCot = serieNumeroCot.Split('-');
                    if (splitSerieNumeroCot.Count() == 2)
                    {
                        string numeroCotRef = string.Format("{0}-{1}"
                            , Convert.ToInt32(splitSerieNumeroCot[0])
                            , Convert.ToInt32(splitSerieNumeroCot[1]));
                        listadoNumeroCot.Add(numeroCotRef);
                    }
                }
                string listadoCotCli = listadoNumeroCot.Aggregate(String.Empty,
                    (current, numeroCot) => current + numeroCot + ",");
                rListadocotref.EditValue = listadoCotCli.Trim().Length == 0
                    ? string.Empty
                    : listadoCotCli.Substring(0, listadoCotCli.Length - 1);
            }
            else
            {
                rListadocotref.EditValue = string.Empty;
            }
        }
        private void EstadoBuscadorSocioNegocio()
        {
            bool estado = gvDetalle.RowCount == 0;
            for (int i = 0; i < beSocioNegocio.Properties.Buttons.Count; i++)
            {
                beSocioNegocio.Properties.Buttons[i].Enabled = estado;
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
        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }
        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(tpOrdendeventa, readOnly);
            WinFormUtils.ReadOnlyFields(tpLogistica, readOnly);
            WinFormUtils.ReadOnlyFields(tpObservacion, readOnly);
            WinFormUtils.ReadOnlyFields(tpCpVenta, readOnly);

        }
        private void OrdendeventaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        public ImpresionFormato ImpresionFormato { get; set; }
        private void bmItemsDetalle_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!ValidacionItems())
            {
                return;
            }
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            OrdendeventaMntItemFrm ordendeventaMntItemFrm;
            VwOrdendeventadet vwOrdendeventadetMntItem;


            if (OrdenVentaItemParameter == null)
            {
                OrdenVentaItemParameter = new OrdenVentaItem();
            }


            if (VwSucursalSel == null)
            {
                VwSucursalSel = VwSucursalList.FirstOrDefault(x => x.Idsucursal == (int)rIdsucursal.EditValue);
                if (VwSucursalSel != null)
                {
                    OrdenVentaItemParameter.IdSucursalConsulta = VwSucursalSel.Idsucursal;
                    OrdenVentaItemParameter.IdAlmacenConsulta = VwSucursalSel.Idalmacendefecto;
                }
            }

            OrdenVentaItemParameter.IdTipoListaConsulta = (int)rIdtipolista.EditValue;
            OrdenVentaItemParameter.IdTipoMonedaConsulta = (int)iIdtipomoneda.EditValue;
            OrdenVentaItemParameter.IdTipoCondicion = (int)rIdtipocondicion.EditValue;
            OrdenVentaItemParameter.IdCliente = (int)iIdcliente.EditValue;

            if (gvDetalle.RowCount == 0)
            {
                VwEmpleado vwEmpleadoSel = CacheObjects.VwEmpleadoList.FirstOrDefault(x => x.Idempleado == (int)iIdempleado.EditValue);
                VwSocionegocioproyecto vwSocionegocioproyectoDefecto = CacheObjects.VwSocionegocioproyectoList.FirstOrDefault(x => x.Idsocionegocio == (int)iIdcliente.EditValue && x.Proyectopordefecto);
                if (vwEmpleadoSel != null && vwSocionegocioproyectoDefecto != null)
                {
                    OrdenVentaItemParameter.IdAreaEmpleado = vwEmpleadoSel.Idarea;
                    OrdenVentaItemParameter.IdProyectoCliente = vwSocionegocioproyectoDefecto.Idproyecto;
                    OrdenVentaItemParameter.IdCentroBeneficio = SessionApp.SucursalSel.Idcentrobeneficioventadefecto;
                }
            }

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    //Asignar el siguiente item
                    vwOrdendeventadetMntItem = new VwOrdendeventadet();

                    //Asignar el siguiente item
                    var sgtItem = VwOrdendeventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Numeroitem)
                        .FirstOrDefault();

                    vwOrdendeventadetMntItem.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    ordendeventaMntItemFrm = new OrdendeventaMntItemFrm(tipoMantenimientoItem, vwOrdendeventadetMntItem, VwOrdendeventadetList, OrdenVentaItemParameter);
                    ordendeventaMntItemFrm.ShowDialog();

                    if (ordendeventaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwOrdendeventadetList.Add(vwOrdendeventadetMntItem);

                        //Agregar items de detalle compuesto
                        if (ordendeventaMntItemFrm.VwOrdendeventadetComponenteList != null && ordendeventaMntItemFrm.VwOrdendeventadetComponenteList.Count > 0)
                        {
                            foreach (var itemDetCompuesto in ordendeventaMntItemFrm.VwOrdendeventadetComponenteList)
                            {
                                VwOrdendeventadetList.Add(itemDetCompuesto);
                            }
                        }

                        SumarTotales();

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


                    //itemSel = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdOrdendeventadet > 0
                    //&& Service.CantidadReferenciasItemOrdendeventa(itemSel.IdOrdendeventadet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede modificar el valor.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    vwOrdendeventadetMntItem = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    ordendeventaMntItemFrm = new OrdendeventaMntItemFrm(tipoMantenimientoItem, vwOrdendeventadetMntItem, VwOrdendeventadetList, OrdenVentaItemParameter);
                    ordendeventaMntItemFrm.ShowDialog();
                    if (ordendeventaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        SumarTotales();
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    //itemSel = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                    //if (itemSel.IdOrdendeventadet > 0
                    //&& Service.CantidadReferenciasItemOrdendeventa(itemSel.IdOrdendeventadet) > 0)
                    //{
                    //    XtraMessageBox.Show("El item tiene referencia en salida de almacen no puede eliminar.", "Atención", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {

                        vwOrdendeventadetMntItem = (VwOrdendeventadet)gvDetalle.GetFocusedRow();
                        vwOrdendeventadetMntItem.DataEntityState = DataEntityState.Deleted;

                        if (!gvDetalle.IsFirstRow)
                        {
                            gvDetalle.MovePrev();
                        }
                        ListarDocumentosReferencia();
                        SumarTotales();
                    }
                    break;
                case "btnEliminarTodo":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    if (DialogResult.Yes == XtraMessageBox.Show(
                        "¿Desea eliminar todos los items?",
                        "Eliminar producto",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1))
                    {
                        foreach (var vwOrdendeventadet in VwOrdendeventadetList)
                        {
                            //Validaciones por item
                            vwOrdendeventadet.DataEntityState = DataEntityState.Deleted;
                        }
                        ListarDocumentosReferencia();
                        SumarTotales();
                    }
                    break;
            }

        }
        private bool ValidacionItems()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpOrdendeventa, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpOrdendeventa;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpLogistica, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpLogistica;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!WinFormUtils.ValidateFieldsNotEmpty(tpCpVenta, _errorProvider))
            {
                tcCotizaCliente.SelectedTabPage = tpCpVenta;
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();


            var totalbruto = VwOrdendeventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;

            var totalgravado = VwOrdendeventadetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            rTotalgravado.EditValue = totalgravado;

            var totalinafecto = VwOrdendeventadetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            rTotalinafecto.EditValue = totalinafecto;

            var totalexonerado = VwOrdendeventadetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            rtotalexonerado.EditValue = totalexonerado;

            var impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (impuestoSel != null)
            {
                var porcentajeImpuesto = impuestoSel.Porcentajeimpuesto;
                decimal totalImpuesto = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
                rTotalimpuesto.EditValue = decimal.Round(totalgravado * (porcentajeImpuesto / 100), 2);
                rImportetotal.EditValue = totalgravado + totalinafecto + totalexonerado + totalImpuesto;

                //Calculo percepcion
                decimal totalValorPercepcion = VwOrdendeventadetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));
                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                decimal importetotalpercepcion = Math.Round(totalValorPercepcion * (1 + porcentajeImpuesto / 100), 2);
                rImportetotalpercepcion.EditValue = importetotalpercepcion;
                //fin calculo percepcion

                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue +
                                            (decimal)rImportetotalpercepcion.EditValue;

            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
            EstadoBuscadorSocioNegocio();
            EstadoMenuImportacion();
            EstadoReferenciasDocumentos();
        }
        private void EstadoReferenciasDocumentos()
        {
            EstadoReferenciaCpventa();
            EstadoReferenciaValorizacion();
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
                        rSerieordenventa.EditValue = vwTipocp.Seriecp;
                        rNumeroordenventa.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroordenventa.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroordenventa.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumeroordenventa.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumeroordenventa.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumeroordenventa.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSerieordenventa.EditValue = @"0000";
                rNumeroordenventa.EditValue = 0;
            }
        }
        private void CalculaItem1(VwOrdendeventadet item)
        {
            decimal precioUnitarioNeto = item.Preciounitario
                * (1 - item.Descuento1 / 100)
                * (1 - item.Descuento2 / 100)
                * (1 - item.Descuento3 / 100)
                * (1 - item.Descuento4 / 100);
            item.Preciounitarioneto = precioUnitarioNeto;
            item.Importetotal = Decimal.Round(item.Cantidad * precioUnitarioNeto, 2);
            item.DataEntityState = DataEntityState.Modified;
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

            //BarMntItems.BeginUpdate();
            foreach (BarItem item in bmItems.Items)
            {
                item.Enabled = enabled;
            }
            //BarMntItems.EndUpdate();


        }
        private void ObtenerTipoDeCambioVentaSunat()
        {
            DateTime fechaEmision = (DateTime)iFechaordenventa.EditValue;
            Tipocambio tipocambio = Service.GetTipocambio(x => x.Fechatipocambio == fechaEmision);
            if (tipocambio != null)
            {
                iTipocambio.EditValue = tipocambio.Valorventasunat;
            }
            else
            {
                iTipocambio.EditValue = 0m;
            }
        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        CargarDatosSocioNegocio(buscarSocioNegocioFrm.VwSocionegocioSel);
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        CargarDatosSocioNegocio(socionegocioMntFrm.VwSocionegocio);
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdcliente.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null,null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            CargarDatosSocioNegocio(socionegocioMntFrm.VwSocionegocio);
                        }
                    }
                    break;
            }
        }
        private void CargarDatosSocioNegocio(VwSocionegocio vwSocionegocio)
        {
            if (vwSocionegocio != null)
            {
                beSocioNegocio.Text = vwSocionegocio.Razonsocial.Trim();
                iIdcliente.EditValue = vwSocionegocio.Idsocionegocio;
                rIdtipocondicion.EditValue = vwSocionegocio.Idtipocondicion;
                rIdtipolista.EditValue = vwSocionegocio.Idtipolista;
                rIdtipocondicion.EditValue = vwSocionegocio.Idtipocondicion;
                rIncluyeimpuestoitems.EditValue = vwSocionegocio.Incluyeigvitems;
                VwSocionegocioSel = vwSocionegocio;
                CargarReferenciasCliente(vwSocionegocio.Idsocionegocio);
            }
        }
        private void CargarReferenciasCliente(int idSocioNegocio)
        {
            CargarDireccionesCliente(idSocioNegocio);
            CargarContactosCliente(idSocioNegocio);
            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                int idDireccionPrincipal = Service.GetIdDireccionPrincipal(idSocioNegocio);
                if (idDireccionPrincipal > 0)
                {
                    iIddireccionfacturacion.EditValue = idDireccionPrincipal;
                    iIddireccionentrega.EditValue = idDireccionPrincipal;
                }
            }

        }
        private void CargarDireccionesCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociodireccionList = Service.GetAllSocionegociodireccion(whereSocioNegocio, "Direccionsocionegocio");

            iIddireccionfacturacion.Properties.DataSource = SocionegociodireccionList;
            iIddireccionfacturacion.Properties.DisplayMember = "Direccionsocionegocio";
            iIddireccionfacturacion.Properties.ValueMember = "Idsocionegociodireccion";
            iIddireccionfacturacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIddireccionentrega.Properties.DataSource = SocionegociodireccionList;
            iIddireccionentrega.Properties.DisplayMember = "Direccionsocionegocio";
            iIddireccionentrega.Properties.ValueMember = "Idsocionegociodireccion";
            iIddireccionentrega.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarContactosCliente(int idSocioNegocio)
        {
            string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", idSocioNegocio);
            SocionegociocontactoList = Service.GetAllSocionegociocontacto(whereSocioNegocio, "Nombrecontacto");
            iPersonacontacto.Properties.DataSource = SocionegociocontactoList;
            iPersonacontacto.Properties.DisplayMember = "Nombrecontacto";
            iPersonacontacto.Properties.ValueMember = "Idsocionegociocontacto";
            iPersonacontacto.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void iFechaordenventa_EditValueChanged(object sender, EventArgs e)
        {
            var idTipoMonedaSel = iIdtipomoneda.EditValue;
            if (idTipoMonedaSel != null && (int)idTipoMonedaSel == 2) //Dolares
            {
                ObtenerTipoDeCambioVentaSunat();
            }
        }
        private void iIdtipoCpVenta_EditValueChanged(object sender, EventArgs e)
        {
            var iIdtipocpcajaSel = iIdtipoCpVenta.EditValue;
            if (iIdtipocpcajaSel != null)
            {
                VwTipocp vwTipocpSel = VwTipoCpVentaList.FirstOrDefault(x => x.Idtipocp == (int)iIdtipocpcajaSel);
                if (vwTipocpSel != null)
                {
                    rSerieCpVenta.EditValue = vwTipocpSel.Seriecp;
                    rSucursalTipoCpVenta.EditValue = vwTipocpSel.Nombresucursal;
                }
                else
                {
                    rSerieCpVenta.EditValue = null;
                    rSucursalTipoCpVenta.EditValue = null;

                }
            }
            else
            {
                rSerieCpVenta.EditValue = null;
                rSucursalTipoCpVenta.EditValue = null;
            }
        }
        private void iIdempleado_EditValueChanged(object sender, EventArgs e)
        {
            int? idEmpleado = (int?)iIdempleado.EditValue;
            if (idEmpleado != null)
            {
                VwEmpleado vwEmpleadoSel = VwEmpleadoList.FirstOrDefault(x => x.Idempleado == idEmpleado);
                if (vwEmpleadoSel != null)
                {
                    iIdtipoCpVenta.EditValue = vwEmpleadoSel.Idtipocpventa;
                }
            }
        }
        private void iPersonacontacto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int) iIdcliente.EditValue;

            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpContactos");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0)
            {
                CargarReferenciasCliente(idCliente);
                if (socionegocioMntFrm.IdsocionegociocontactoNuevo > 0)
                {
                    e.Cancel = false;
                    e.NewValue = socionegocioMntFrm.IdsocionegociocontactoNuevo;
                }
            }
        }
        private void iIddireccionfacturacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpDirecciones");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0)
            {
                CargarDireccionesCliente(idCliente);
                if (socionegocioMntFrm.IdsocionegociodireccionNuevo > 0)
                {
                    e.Cancel = false;
                    e.NewValue = socionegocioMntFrm.IdsocionegociodireccionNuevo;
                }
            }
        }
        private void iIddireccionentrega_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            int idCliente = (int)iIdcliente.EditValue;
            SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(idCliente, TipoMantenimiento.Modificar, null, null, "tpDirecciones");
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0)
            {
                CargarDireccionesCliente(idCliente);
                if (socionegocioMntFrm.IdsocionegociodireccionNuevo > 0)
                {
                    e.Cancel = false;
                    e.NewValue = socionegocioMntFrm.IdsocionegociodireccionNuevo;
                }
            }
        }
    }

    public class OrdenVentaItem
    {
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public int IdTipoMonedaConsulta { get; set; }
        public int IdTipoCondicion { get; set; }
        public int? IdAreaEmpleado { get; set; }
        public int? IdProyectoCliente { get; set; }
        public int? IdCentroBeneficio { get; set; }
        public int IdCliente { get; set; }
    }
}