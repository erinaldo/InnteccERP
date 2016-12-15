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
    public partial class CotizacionclienteMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public VwCotizacionclientedet VwCotizacionclientedetMnt { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public Tipoafectacionigv TipoafectacionigvSel { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public List<VwCotizacionclientedet> VwCotizacionclientedetComponenteList { get; set; }
        public List<VwCotizacionclientedet> VwCotizacionclientedetList { get; set; }
        public CotizacionVentaItem CotizacionVentaItemParameter { get; set; }
        public UserAudit UserAudit { get; set; }
        public List<VwArticuloubicacion> VwArticuloubicacionList { get; set; }
        public List<Almacen> AlmacenList { get; set; }
        public List<VwUbicacion> UbicacionList { get; set; }
        public CotizacionclienteMntItemFrm(TipoMantenimiento tipoMnt, VwCotizacionclientedet vwCotizacionclientedetMnt, List<VwCotizacionclientedet> vwCotizacionclientedetList, CotizacionVentaItem cotizacionVentaItemParameter)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCotizacionclientedetMnt = vwCotizacionclientedetMnt;
            VwCotizacionclientedetList = vwCotizacionclientedetList;
            CotizacionVentaItemParameter = cotizacionVentaItemParameter;
            UserAudit = new UserAudit();
        }
        private void CotizacionclienteMntItemFrm_Load(object sender, EventArgs e)
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
                    var idAlmacen = iIdalmacen.EditValue;
                    if (idAlmacen != null)
                    {
                        BuscarArticulo();
                        //iIdcentrodecosto.Select();
                    }
                    else
                    {
                        iIdalmacen.Select();
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    TraerDatos();
                    break;
            }
            iCantidad.Select();
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwCotizacionclientedetMnt.Numeroitem;
            iDiasdeentrega.EditValue = 1;
            iIdalmacen.EditValue = CotizacionVentaItemParameter.IdAlmacenConsulta;

            if (VwCotizacionclientedetList.Count(x => x.DataEntityState != DataEntityState.Deleted) == 0)
            {
                iIdcentrodecosto.EditValue = CotizacionVentaItemParameter.IdCentroBeneficio;
            }
            else
            {
                VwCotizacionclientedet vwCotizacionclientedetUltimo = VwCotizacionclientedetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);
                if (vwCotizacionclientedetUltimo != null)
                {
                    iIdcentrodecosto.EditValue = vwCotizacionclientedetUltimo.Idcentrodecosto;
                }
            }

            Almacen almacen = AlmacenList.FirstOrDefault(x => x.Idalmacen == (int) iIdalmacen.EditValue);
            if (almacen != null)
            {
                iIdubicacion.EditValue = almacen.Idubicaciondefecto;
            }
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwCotizacionclientedetMnt.Numeroitem;
            iIdarticulo.EditValue = VwCotizacionclientedetMnt.Idarticulo;
            iCodigoarticulo.EditValue = VwCotizacionclientedetMnt.Codigoarticulo;
            iCodigoproveedor.EditValue = VwCotizacionclientedetMnt.Codigoproveedor;
            iIdunidadmedida.EditValue = VwCotizacionclientedetMnt.Idunidadinventario;
            iNombremarca.EditValue = VwCotizacionclientedetMnt.Nombremarca;
            iNombrearticulo.Text = VwCotizacionclientedetMnt.Nombrearticulo;
            iDiasdeentrega.EditValue = VwCotizacionclientedetMnt.Diasdeentrega;
            iIdunidadmedida.EditValue = VwCotizacionclientedetMnt.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwCotizacionclientedetMnt.Abrunidadmedida;
            iIdimpuesto.EditValue = VwCotizacionclientedetMnt.Idimpuesto;
            iEspecificacion.Text = VwCotizacionclientedetMnt.Especificacion;
            iCantidad.EditValue = VwCotizacionclientedetMnt.Cantidad;
            iPreciounitario.EditValue = VwCotizacionclientedetMnt.Preciounitario;
            iDescuento1.EditValue = VwCotizacionclientedetMnt.Descuento1;
            iDescuento2.EditValue = VwCotizacionclientedetMnt.Descuento2;
            iPreciounitarioneto.EditValue = VwCotizacionclientedetMnt.Preciounitarioneto;
            iImportetotal.EditValue = VwCotizacionclientedetMnt.Importetotal;
            nPorcentajepercepcion.EditValue = VwCotizacionclientedetMnt.Porcentajepercepcion;
            iIdtipoafectacionigv.EditValue = VwCotizacionclientedetMnt.Idtipoafectacionigv;
            iGravado.EditValue = VwCotizacionclientedetMnt.Gravado;
            iExonerado.EditValue = VwCotizacionclientedetMnt.Exonerado;
            iInafecto.EditValue = VwCotizacionclientedetMnt.Inafecto;
            iExportacion.EditValue = VwCotizacionclientedetMnt.Exportacion;
            iIdcentrodecosto.EditValue = VwCotizacionclientedetMnt.Idcentrodecosto;
            iIdalmacen.EditValue = VwCotizacionclientedetMnt.Idalmacen;
            iCalcularitem.EditValue = VwCotizacionclientedetMnt.Calcularitem;
            iBonificacion.EditValue = VwCotizacionclientedetMnt.Bonificacion;
            iIdubicacion.EditValue = VwCotizacionclientedetMnt.Idubicacion;

            UserAudit.Createdby = VwCotizacionclientedetMnt.Createdby;
            UserAudit.Creationdate = VwCotizacionclientedetMnt.Creationdate;
            UserAudit.Modifiedby = VwCotizacionclientedetMnt.Modifiedby;
            UserAudit.Lastmodified = VwCotizacionclientedetMnt.Lastmodified;
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

            VwCentrodecostoList = CacheObjects.VwCentrodecostoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdcentrodecosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            AlmacenList = CacheObjects.AlmacenList.Where(x => x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            UbicacionList = Service.GetAllVwUbicacion(x => x.Idalmacen == CotizacionVentaItemParameter.IdAlmacenConsulta);
            iIdubicacion.Properties.DataSource = UbicacionList;
            iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
            iIdubicacion.Properties.ValueMember = "Idubicacion";
            iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwCotizacionclientedetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwCotizacionclientedetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwCotizacionclientedetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwCotizacionclientedetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwCotizacionclientedetMnt.Idunidadinventario = (int?)iIdunidadmedida.EditValue;
                    VwCotizacionclientedetMnt.Nombremarca = iNombremarca.Text.Trim();
                    VwCotizacionclientedetMnt.Nombrearticulo = iNombrearticulo.Text.Trim();
                    VwCotizacionclientedetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwCotizacionclientedetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwCotizacionclientedetMnt.Abrunidadmedida = iAbrunidadmedida.Text.Trim();
                    VwCotizacionclientedetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwCotizacionclientedetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwCotizacionclientedetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
                    VwCotizacionclientedetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
                    VwCotizacionclientedetMnt.Descuento3 = 0m;
                    VwCotizacionclientedetMnt.Descuento4 = 0m;
                    VwCotizacionclientedetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
                    VwCotizacionclientedetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwCotizacionclientedetMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;
                    VwCotizacionclientedetMnt.Diasdeentrega = (int)iDiasdeentrega.EditValue;
                    VwCotizacionclientedetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwCotizacionclientedetMnt.Gravado = (bool)iGravado.EditValue;
                    VwCotizacionclientedetMnt.Exonerado = (bool)iExonerado.EditValue;
                    VwCotizacionclientedetMnt.Inafecto = (bool)iInafecto.EditValue;
                    VwCotizacionclientedetMnt.Exportacion = (bool)iExportacion.EditValue;
                    VwCotizacionclientedetMnt.Idcentrodecosto = (int?)iIdcentrodecosto.EditValue;
                    VwCotizacionclientedetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwCotizacionclientedetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwCotizacionclientedetMnt.Idalmacen = (int)iIdalmacen.EditValue;
                    VwCotizacionclientedetMnt.Idubicacion = (int)iIdubicacion.EditValue;
                    //Los items por defecto se calculan
                    VwCotizacionclientedetMnt.Calcularitem = true;
                    VwCotizacionclientedetMnt.Bonificacion = (bool)iBonificacion.EditValue;


                    //Si es un articulo compuesto agregar detalle
                    if ((bool)iCalcularitem.EditValue)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwCotizacionclientedetMnt.Idarticulo);
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwCotizacionclientedetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwCotizacionclientedetMnt.Creationdate = SessionApp.DateServer;
                            VwCotizacionclientedetMnt.Modifiedby = UserAudit.Modifiedby;
                            VwCotizacionclientedetMnt.Lastmodified = UserAudit.Lastmodified;

                            break;
                        case TipoMantenimiento.Modificar:
                            VwCotizacionclientedetMnt.Createdby = UserAudit.Createdby;
                            VwCotizacionclientedetMnt.Creationdate = UserAudit.Creationdate;
                            VwCotizacionclientedetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwCotizacionclientedetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwCotizacionclientedetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwCotizacionclientedetMnt.DataEntityState = DataEntityState.Modified;
                            break;
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
            VwCotizacionclientedetComponenteList = new List<VwCotizacionclientedet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwCotizacionclientedet vwCotizacionclientedet = new VwCotizacionclientedet();

                vwCotizacionclientedet.Numeroitem = numeroItem;
                vwCotizacionclientedet.Idarticulo = item.Idarticulodetalle;
                vwCotizacionclientedet.Codigoarticulo = item.Codigoarticulo;
                vwCotizacionclientedet.Codigoproveedor = item.Codigoproveedor;
                vwCotizacionclientedet.Idunidadinventario = item.Idunidadinventario;
                vwCotizacionclientedet.Nombremarca = item.Nombremarca;
                vwCotizacionclientedet.Nombrearticulo = item.Nombrearticulo;
                vwCotizacionclientedet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwCotizacionclientedet.Idunidadmedida = item.Idunidadinventario;
                vwCotizacionclientedet.Abrunidadmedida = item.Abrunidadmedida;
                vwCotizacionclientedet.Preciounitario = 0m;
                vwCotizacionclientedet.Especificacion = string.Empty;
                vwCotizacionclientedet.Descuento1 = 0m;
                vwCotizacionclientedet.Descuento2 = 0m;
                vwCotizacionclientedet.Descuento3 = 0m;
                vwCotizacionclientedet.Descuento4 = 0m;
                vwCotizacionclientedet.Preciounitarioneto = 0m;
                vwCotizacionclientedet.Importetotal = 0m;
                vwCotizacionclientedet.Idimpuesto = item.Idimpuesto;
                vwCotizacionclientedet.Diasdeentrega = 0;
                vwCotizacionclientedet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwCotizacionclientedet.Gravado = item.Gravado;
                vwCotizacionclientedet.Exonerado = item.Exonerado;
                vwCotizacionclientedet.Inafecto = item.Inafecto;
                vwCotizacionclientedet.Exportacion = item.Exportacion;
                vwCotizacionclientedet.Idcentrodecosto = (int?)iIdcentrodecosto.EditValue;
                vwCotizacionclientedet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwCotizacionclientedet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                vwCotizacionclientedet.Idalmacen = (int)iIdalmacen.EditValue;
                VwCotizacionclientedetMnt.Idubicacion = (int)iIdubicacion.EditValue;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        VwCotizacionclientedetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                        VwCotizacionclientedetMnt.Creationdate = SessionApp.DateServer;
                        VwCotizacionclientedetMnt.Modifiedby = UserAudit.Modifiedby;
                        VwCotizacionclientedetMnt.Lastmodified = UserAudit.Lastmodified;

                        break;
                    case TipoMantenimiento.Modificar:
                        VwCotizacionclientedetMnt.Createdby = UserAudit.Createdby;
                        VwCotizacionclientedetMnt.Creationdate = UserAudit.Creationdate;
                        VwCotizacionclientedetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        VwCotizacionclientedetMnt.Lastmodified = DateTime.Now;
                        break;
                }
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCotizacionclientedet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCotizacionclientedet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                //Se estable a false no se calcula el item
                vwCotizacionclientedet.Calcularitem = false;
                vwCotizacionclientedet.Bonificacion = false;

                VwCotizacionclientedetComponenteList.Add(vwCotizacionclientedet);
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
            return true;
        }
        private void CotizacionclienteMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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

            iPreciounitarioneto.EditValue = decimal.Round(preciounitarioneto, 2);
            iImportetotal.EditValue = importeTotal;
        }
        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ArticuloMntFrm articuloMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
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
            CotizacionVentaItemParameter.IdSucursalConsulta,
            CotizacionVentaItemParameter.IdAlmacenConsulta,
            CotizacionVentaItemParameter.IdTipoListaConsulta,
            CotizacionVentaItemParameter.IdTipoMonedaConsulta,
            CotizacionVentaItemParameter.IdTipoCondicion);
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                CargarDatosArticuloSeleccionado(buscadorArticuloFrm.VwArticulounidadSel);
                iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                
                //iCantidad.Select();
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
                iNombrearticulo.Text = string.Empty;
                iNombremarca.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iAbrunidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
                nPorcentajepercepcion.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;

                iBonificacion.EditValue = false;
                iExonerado.EditValue = false;
                iInafecto.EditValue = false;
                iExportacion.EditValue = false;
                iCalcularitem.EditValue = false;
            }
        }

        
        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            //var idArticuloSel = iIdarticulo.EditValue;

            //if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            //VwArticuloSel = Service.GetVwArticulo(((int)idArticuloSel));
            //if (VwArticuloSel != null)
            //{
            //    //Cargar datos a controles
            //    iCodigoarticulo.EditValue = VwArticuloSel.Codigoarticulo;
            //    iCodigoproveedor.EditValue = VwArticuloSel.Codigoproveedor;
            //    iNombrearticulo.Text = VwArticuloSel.Nombrearticulo.Trim();
            //    iNombremarca.EditValue = VwArticuloSel.Nombremarca;
            //    iIdimpuesto.EditValue = VwArticuloSel.Idimpuesto;
            //    iAbrunidadmedida.EditValue = VwArticuloSel.Abrunidadmedida;
            //    iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
            //    iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
            //    nPorcentajepercepcion.EditValue = VwArticuloSel.Aplicapercepcion ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;
            //    iEspecificacion.Text = VwArticuloSel.Caracteristicas;
            //}

            //else
            //{
            //    iCodigoarticulo.EditValue = string.Empty;
            //    iCodigoproveedor.EditValue = string.Empty;
            //    iNombrearticulo.Text = string.Empty;
            //    iNombremarca.EditValue = string.Empty;
            //    iIdimpuesto.EditValue = null;
            //    iIdtipoafectacionigv.EditValue = null;
            //    nPorcentajepercepcion.EditValue = 0m;
            //    iAbrunidadmedida.EditValue = string.Empty;
            //    iIdunidadmedida.EditValue = 0;
            //}
        }
    }
}