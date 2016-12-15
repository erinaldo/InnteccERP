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
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class OrdendeventaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwOrdendeventadet VwOrdendeventadetMnt { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        private List<Almacen> AlmacenList { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public List<VwEquipo> VwEquipoList { get; set; }
        private List<VwSocionegocioproyecto> VwProyectoList { get; set; }
        public List<VwOrdendeventadet> VwOrdendeventadetComponenteList { get; set; }
        public List<VwOrdendeventadet> VwOrdendeventadetList { get; set; }
        OrdenVentaItem OrdenVentaItemParameter { get; set; }
        public OrdendeventaMntItemFrm(TipoMantenimiento tipoMnt, VwOrdendeventadet vwOrdendeventadetMnt, List<VwOrdendeventadet> vwOrdendeventadetList, OrdenVentaItem ordenVentaItemParameter)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwOrdendeventadetMnt = vwOrdendeventadetMnt;
            VwOrdendeventadetList = vwOrdendeventadetList;
            OrdenVentaItemParameter = ordenVentaItemParameter;

        }
        private void OrdendeventaMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    BuscarArticulo();

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    TraerDatos();

                    break;
            }
            // beArticulo.Select();
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwOrdendeventadetMnt.Numeroitem;
            iDiasdeentrega.EditValue = 1;
            iIdalmacen.EditValue = OrdenVentaItemParameter.IdAlmacenConsulta; 

            if (VwOrdendeventadetList.Count(x => x.DataEntityState != DataEntityState.Deleted) == 0)
            {
                iIdcentrodecosto.EditValue = OrdenVentaItemParameter.IdCentroBeneficio;
                iIdproyecto.EditValue = OrdenVentaItemParameter.IdProyectoCliente;
                iIdarea.EditValue = OrdenVentaItemParameter.IdAreaEmpleado;
            }
            else
            {
                VwOrdendeventadet vwOrdendeventadetUltimo = VwOrdendeventadetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);
                if (vwOrdendeventadetUltimo != null)
                {
                    iIdcentrodecosto.EditValue = vwOrdendeventadetUltimo.Idcentrodecosto;
                    iIdproyecto.EditValue = vwOrdendeventadetUltimo.Idproyecto;
                    iIdarea.EditValue = vwOrdendeventadetUltimo.Idarea;
                }
            }
        }
        private void TraerDatos()
        {

            iNumeroitem.EditValue = VwOrdendeventadetMnt.Numeroitem;
            iIdarticulo.EditValue = VwOrdendeventadetMnt.Idarticulo;
            iCodigoarticulo.EditValue = VwOrdendeventadetMnt.Codigoarticulo;
            iCodigoproveedor.EditValue = VwOrdendeventadetMnt.Codigoproveedor;
            iIdunidadmedida.EditValue = VwOrdendeventadetMnt.Idunidadinventario;
            iNombremarca.EditValue = VwOrdendeventadetMnt.Nombremarca;
            iNombrearticulo.EditValue = VwOrdendeventadetMnt.Nombrearticulo;
            iDiasdeentrega.EditValue = VwOrdendeventadetMnt.Diasdeentrega;
            iIdunidadmedida.EditValue = VwOrdendeventadetMnt.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwOrdendeventadetMnt.Abrunidadmedida;
            iIdimpuesto.EditValue = VwOrdendeventadetMnt.Idimpuesto;
            iEspecificacion.Text = VwOrdendeventadetMnt.Especificacion;
            iCantidad.EditValue = VwOrdendeventadetMnt.Cantidad;
            iPreciounitario.EditValue = VwOrdendeventadetMnt.Preciounitario;
            iDescuento1.EditValue = VwOrdendeventadetMnt.Descuento1;
            iDescuento2.EditValue = VwOrdendeventadetMnt.Descuento2;
            //iDescuento3.EditValue = VwOrdendeventadetMnt.Descuento3;
            //iDescuento4.EditValue = VwOrdendeventadetMnt.Descuento4;
            iPreciounitarioneto.EditValue = VwOrdendeventadetMnt.Preciounitarioneto;
            iImportetotal.EditValue = VwOrdendeventadetMnt.Importetotal;
            iIdtipoafectacionigv.EditValue = VwOrdendeventadetMnt.Idtipoafectacionigv;
            iGravado.EditValue = VwOrdendeventadetMnt.Gravado;
            iExonerado.EditValue = VwOrdendeventadetMnt.Exonerado;
            iInafecto.EditValue = VwOrdendeventadetMnt.Inafecto;
            iExportacion.EditValue = VwOrdendeventadetMnt.Exportacion;
            iIdalmacen.EditValue = VwOrdendeventadetMnt.Idalmacen;
            iIdcentrodecosto.EditValue = VwOrdendeventadetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwOrdendeventadetMnt.Idarea;
            iIdproyecto.EditValue = VwOrdendeventadetMnt.Idproyecto;
            iIdequipo.EditValue = VwOrdendeventadetMnt.Idequipo;
            iCalcularitem.EditValue = VwOrdendeventadetMnt.Calcularitem;
            iNumeromeses.EditValue = VwOrdendeventadetMnt.Numeromeses;

        }
        private void CargarReferencias()
        {

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            TipoafectacionigvList = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DataSource = TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

            AlmacenList = CacheObjects.AlmacenList.Where(x => x.Idsucursal == OrdenVentaItemParameter.IdSucursalConsulta).ToList();
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            VwCentrodecostoList = CacheObjects.VwCentrodecostoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdcentrodecosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            VwAreaList = CacheObjects.VwAreaList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            VwProyectoList = CacheObjects.VwSocionegocioproyectoList.Where(x => x.Idsocionegocio == OrdenVentaItemParameter.IdCliente).ToList();
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;


            VwEquipoList = CacheObjects.VwEquipoList;
            iIdequipo.Properties.DataSource = VwEquipoList;
            iIdequipo.Properties.DisplayMember = "Nombreequipo";
            iIdequipo.Properties.ValueMember = "Idequipo";
            iIdequipo.Properties.BestFitMode = BestFitMode.BestFit;


        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwOrdendeventadetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwOrdendeventadetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwOrdendeventadetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwOrdendeventadetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwOrdendeventadetMnt.Idunidadinventario = (int?)iIdunidadmedida.EditValue;
                    VwOrdendeventadetMnt.Nombremarca = iNombremarca.Text.Trim();
                    VwOrdendeventadetMnt.Nombrearticulo = iNombrearticulo.Text.Trim();
                    VwOrdendeventadetMnt.Diasdeentrega = (int)iDiasdeentrega.EditValue;
                    VwOrdendeventadetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwOrdendeventadetMnt.Abrunidadmedida = iAbrunidadmedida.Text.Trim();
                    VwOrdendeventadetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwOrdendeventadetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwOrdendeventadetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwOrdendeventadetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwOrdendeventadetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwOrdendeventadetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
                    VwOrdendeventadetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
                    //VwOrdendeventadetMnt.Descuento3 = (decimal)iDescuento3.EditValue;
                    //VwOrdendeventadetMnt.Descuento4 = (decimal)iDescuento4.EditValue;
                    VwOrdendeventadetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
                    VwOrdendeventadetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwOrdendeventadetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwOrdendeventadetMnt.Gravado = (bool)iGravado.EditValue;
                    VwOrdendeventadetMnt.Exonerado = (bool)iExonerado.EditValue;
                    VwOrdendeventadetMnt.Inafecto = (bool)iInafecto.EditValue;
                    VwOrdendeventadetMnt.Exportacion = (bool)iExportacion.EditValue;
                    VwOrdendeventadetMnt.Idalmacen = (int)iIdalmacen.EditValue;
                    VwOrdendeventadetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwOrdendeventadetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwOrdendeventadetMnt.Idarea = (int)iIdarea.EditValue;
                    VwOrdendeventadetMnt.Nombrearea = iIdarea.Text.Trim();
                    VwOrdendeventadetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwOrdendeventadetMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    if (VwOrdendeventadetMnt.Idcotizacionclientedet == null)
                    {
                        VwOrdendeventadetMnt.Idcotizacionclientedet = null;
                        VwOrdendeventadetMnt.Serienumerocotizacion = string.Empty;
                    }
                    VwOrdendeventadetMnt.Idequipo = (int?)iIdequipo.EditValue;

                    VwOrdendeventadetMnt.Calcularitem = (bool)iCalcularitem.EditValue;
                    VwOrdendeventadetMnt.Numeromeses = (int?)iNumeromeses.EditValue;


                    if (VwOrdendeventadetMnt.Idcotizacionclientedet == null)
                    {
                        VwOrdendeventadetMnt.Idcotizacionclientedet = null;
                        VwOrdendeventadetMnt.Serienumerocotizacion = string.Empty;
                    }
                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            //VwOrdendeventadetMnt.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            //VwOrdendeventadetMnt.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwOrdendeventadetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwOrdendeventadetMnt.DataEntityState = DataEntityState.Modified;
                            break;
                    }

                    //Si es un articulo compuesto agregar detalle
                    if ((bool)iCalcularitem.EditValue)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwOrdendeventadetMnt.Idarticulo);
                    }

                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private void AsignarDetalleDeArticulosCompuestos(int idarticulo)
        {
            VwOrdendeventadetComponenteList = new List<VwOrdendeventadet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwOrdendeventadet vwOrdendeventadet = new VwOrdendeventadet();


                vwOrdendeventadet.Numeroitem = numeroItem;
                vwOrdendeventadet.Idarticulo = item.Idarticulodetalle;
                vwOrdendeventadet.Codigoarticulo = item.Codigoarticulo;
                vwOrdendeventadet.Codigoproveedor = item.Codigoproveedor;
                vwOrdendeventadet.Idunidadinventario = item.Idunidadinventario;
                vwOrdendeventadet.Nombremarca = item.Nombremarca;
                vwOrdendeventadet.Nombrearticulo = item.Nombrearticulo;
                vwOrdendeventadet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwOrdendeventadet.Idunidadmedida = item.Idunidadinventario;
                vwOrdendeventadet.Abrunidadmedida = item.Abrunidadmedida;
                vwOrdendeventadet.Preciounitario = 0m;
                vwOrdendeventadet.Especificacion = string.Empty;
                vwOrdendeventadet.Descuento1 = 0m;
                vwOrdendeventadet.Descuento2 = 0m;
                vwOrdendeventadet.Descuento3 = 0m;
                vwOrdendeventadet.Descuento4 = 0m;
                vwOrdendeventadet.Preciounitarioneto = 0m;
                vwOrdendeventadet.Importetotal = 0m;
                vwOrdendeventadet.Idimpuesto = item.Idimpuesto;
                vwOrdendeventadet.Diasdeentrega = (int)iDiasdeentrega.EditValue;
                vwOrdendeventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwOrdendeventadet.Gravado = item.Gravado;
                vwOrdendeventadet.Exonerado = item.Exonerado;
                vwOrdendeventadet.Inafecto = item.Inafecto;
                vwOrdendeventadet.Exportacion = item.Exportacion;
                vwOrdendeventadet.Idalmacen = (int)iIdalmacen.EditValue;
                vwOrdendeventadet.Idarea = (int)iIdarea.EditValue;
                vwOrdendeventadet.Nombrearea = iIdarea.Text.Trim();
                vwOrdendeventadet.Idproyecto = (int)iIdproyecto.EditValue;
                vwOrdendeventadet.Nombreproyecto = iIdproyecto.Text.Trim();
                vwOrdendeventadet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwOrdendeventadet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwOrdendeventadet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        //vwOrdendeventadet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwOrdendeventadet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        //vwOrdendeventadet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwOrdendeventadet.Lastmodified = DateTime.Now;
                        break;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwOrdendeventadet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwOrdendeventadet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                //Se estable a false no se calcula el item
                vwOrdendeventadet.Calcularitem = false;
                VwOrdendeventadetComponenteList.Add(vwOrdendeventadet);
            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpProducto, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            var idEquipoSel = (int?)iIdequipo.EditValue;
            var numeroMesAlq = (int?)iNumeromeses.EditValue;
            if (idEquipoSel != null && numeroMesAlq == 0)
            {
                XtraMessageBox.Show("Ingrese Cantidad de Meses de Alquiler", Resources.titAtencion, MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                iNumeromeses.Select();
                return false;
            }

            return true;
        }
        private void OrdendeventaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal)iCantidad.EditValue;
            var precioUniatario = (decimal)iPreciounitario.EditValue;
            var descuento1 = (decimal)iDescuento1.EditValue;
            var descuento2 = (decimal)iDescuento2.EditValue;
            const decimal descuento3 = 0m;
            const decimal descuento4 = 0m;

            decimal preciounitarioneto = precioUniatario
                                         * (1 - descuento1 / 100)
                                         * (1 - descuento2 / 100)
                                         * (1 - descuento3 / 100)
                                         * (1 - descuento4 / 100);

            var importeTotal = Decimal.Round(cantidad * preciounitarioneto, 2);

            iPreciounitarioneto.EditValue = decimal.Round(preciounitarioneto, 4);
            iImportetotal.EditValue = importeTotal;
        }
        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ArticuloMntFrm articuloMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
                    iCantidad.Select();
                    break;
                case 1: //Nuevo registro
                    articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    articuloMntFrm.ShowDialog();

                    if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                    {
                        iIdarticulo.EditValue = 0;
                        iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idArticuloMnt = iIdarticulo.EditValue;
                    if (idArticuloMnt != null && (int)idArticuloMnt > 0)
                    {
                        articuloMntFrm = new ArticuloMntFrm((int)idArticuloMnt, TipoMantenimiento.Modificar, null, null);
                        articuloMntFrm.ShowDialog();
                        if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                        {
                            iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }
        }
        private void BuscarArticulo()
        {
            BuscadorArticuloCondicionFrm buscadorArticuloFrm = new BuscadorArticuloCondicionFrm(
                OrdenVentaItemParameter.IdSucursalConsulta,
                OrdenVentaItemParameter.IdAlmacenConsulta,
                OrdenVentaItemParameter.IdTipoListaConsulta,
                OrdenVentaItemParameter.IdTipoMonedaConsulta,
                OrdenVentaItemParameter.IdTipoCondicion);
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                CargarDatosArticuloSeleccionado(buscadorArticuloFrm.VwArticulounidadSel);
                iStock.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Stock;
                iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                iCantidad.Select();
            }

        }
        private void iIdequipo_EditValueChanged(object sender, EventArgs e)
        {
            var idEquipoSel = iIdequipo.EditValue;
            if (idEquipoSel != null)
            {
                VwEquipo vwEquipoSel = VwEquipoList.FirstOrDefault(x => x.Idequipo == (int)idEquipoSel);
                if (vwEquipoSel != null)
                {
                    iCodigoequipo.EditValue = vwEquipoSel.Codigoequipo;
                    iNombremarcaequipo.EditValue = vwEquipoSel.Nombremarcaequipo;
                    iNombremodeloequipo.EditValue = vwEquipoSel.Nombremodeloequipo;
                    iColorequipo.EditValue = vwEquipoSel.Colorequipo;
                    iCapacidadequipo.EditValue = vwEquipoSel.Capacidadequipo;
                    iNumeroserieequipo.EditValue = vwEquipoSel.Numeroserieequipo;
                    iPlacaequipo.EditValue = vwEquipoSel.Placaequipo;
                    iIdcentrodecosto.EditValue = vwEquipoSel.Idcentrocosto;
                    iIdcentrodecosto.Enabled = false;
                }
                else
                {
                    iIdcentrodecosto.EditValue = null;
                    iIdcentrodecosto.Enabled = true;
                }
            }


        }
        private void iIdproyecto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            var socionegocioMntFrm = new SocionegocioMntFrm(OrdenVentaItemParameter.IdCliente, TipoMantenimiento.Modificar, null, null);
            socionegocioMntFrm.ShowDialog();
            if (socionegocioMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Socionegocio socionegociooyecto = socionegocioMntFrm.SocionegocioMnt;
                if (socionegociooyecto.Idsocionegocio > 0)
                {

                    string whereProyecto = string.Format("idsucursal = {0} and idsocionegocio = {1} ", OrdenVentaItemParameter.IdSucursalConsulta, OrdenVentaItemParameter.IdCliente);
                    VwProyectoList = Service.GetAllVwSocionegocioproyecto(whereProyecto, "codigoproyecto");
                    iIdproyecto.Properties.DataSource = VwProyectoList;
                    iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
                    iIdproyecto.Properties.ValueMember = "Idproyecto";
                    iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

                }
            }
        }
        private void CargarDatosArticuloSeleccionado(VwArticulounidad vwArticulounidad)
        {

            if (vwArticulounidad != null)
            {
                //Cargar datos a controles
                iIdarticulo.EditValue = vwArticulounidad.Idarticulo;
                iCodigoarticulo.EditValue = vwArticulounidad.Codigoarticulo;
                iCodigoproveedor.EditValue = vwArticulounidad.Codigoproveedor;
                //iCodigodebarra.EditValue = vwArticulounidad.Codigodebarra;
                iNombrearticulo.Text = vwArticulounidad.Nombrearticulo.Trim();
                iNombremarca.EditValue = vwArticulounidad.Nombremarca;
                iIdimpuesto.EditValue = vwArticulounidad.Idimpuesto;
                iAbrunidadmedida.EditValue = vwArticulounidad.Abrunidadmedida;
                iIdunidadmedida.EditValue = vwArticulounidad.Idunidadinventario;
                nPorcentajepercepcion.EditValue = vwArticulounidad.Aplicapercepcion
                    ? SessionApp.EmpresaSel.Porcentajepercepcion
                    : 0m;
                iIdtipoafectacionigv.EditValue = vwArticulounidad.Idtipoafectacionigv;

                iGravado.EditValue = vwArticulounidad.Gravado;
                iExonerado.EditValue = vwArticulounidad.Exonerado;
                iInafecto.EditValue = vwArticulounidad.Inafecto;
                iExportacion.EditValue = vwArticulounidad.Exportacion;
                iCalcularitem.EditValue = true;
            }

            else
            {
                iIdarticulo.EditValue = 0;
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                //iCodigodebarra.EditValue = string.Empty;
                iNombrearticulo.Text = string.Empty;
                iNombremarca.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iAbrunidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
                nPorcentajepercepcion.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;

                iGravado.EditValue = false;
                iExonerado.EditValue = false;
                iInafecto.EditValue = false;
                iExportacion.EditValue = false;
                iCalcularitem.EditValue = false;
            }
        }
    }
}