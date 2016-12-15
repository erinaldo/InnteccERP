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
    public partial class OrdencompraMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticulo VwArticuloSel { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwOrdencompradet VwordencompradetMnt { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<Centrodecosto> CentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public List<VwOrdencompradet> VwOrdencompradetComponenteList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public VwCptooperacion VwCptooperacionSel { get; set; }

        public OrdencompraMntItemFrm(TipoMantenimiento tipoMnt, VwOrdencompradet vwordencompradetMnt, VwTipocp vwTipocpSel, VwCptooperacion vwCptooperacionSel)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwordencompradetMnt = vwordencompradetMnt;
            VwTipocpSel = vwTipocpSel;
            VwCptooperacionSel = vwCptooperacionSel;

        }
        private void OrdencompraMntItemFrm_Load(object sender, EventArgs e)
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
                    iCantidad.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    //ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            beArticulo.Select();
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwordencompradetMnt.Numeroitem;

            ////Area por defecto
            if (VwAreaList != null && VwAreaList.Count == 1)
            {
                VwArea vwAreaPorDefecto = VwAreaList.FirstOrDefault();
                if (vwAreaPorDefecto != null)
                    iIdarea.EditValue = vwAreaPorDefecto.Idarea;
            }

            ////Centro de costo por defecto
            if (CentrodecostoList != null && CentrodecostoList.Count == 1)
            {
                Centrodecosto centrodecostoPorDefecto = CentrodecostoList.FirstOrDefault();
                if (centrodecostoPorDefecto != null)
                    iIdcentrodecosto.EditValue = centrodecostoPorDefecto.Idcentrodecosto;
            }

            ////Proyecto por defecto
            if (VwProyectoList != null && VwProyectoList.Count == 1)
            {
                VwProyecto vwProyectoList = VwProyectoList.FirstOrDefault();
                if (vwProyectoList != null)
                    iIdproyecto.EditValue = vwProyectoList.Idproyecto;
            }

            Ordencompradet ordencompradet = Service.UltimoRegistroOrdenCompraDet();
            if (ordencompradet != null)
            {
                iIdarea.EditValue = ordencompradet.Idarea;
            }
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwordencompradetMnt.Numeroitem;
            iIdarticulo.EditValue = VwordencompradetMnt.Idarticulo;
            iIdcentrodecosto.EditValue = VwordencompradetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwordencompradetMnt.Idarea;
            iIdproyecto.EditValue = VwordencompradetMnt.Idproyecto;
            iEspecificacion.EditValue = VwordencompradetMnt.Especificacion;
            iCantidad.EditValue = VwordencompradetMnt.Cantidad;
            iPreciounitario.EditValue = VwordencompradetMnt.Preciounitario;
            iImportetotal.EditValue = VwordencompradetMnt.Importetotal;
            iPorcentajepercepcion.EditValue = VwordencompradetMnt.Porcentajepercepcion;
            iFechaentrega.EditValue = VwordencompradetMnt.Fechaentrega;
        }
        private void CargarReferencias()
        {

            iIdunidadmedida.Properties.DataSource = CacheObjects.UnidadmedidaList;
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            CentrodecostoList = CacheObjects.CentrodecostoList.Where(x => x.Idempresa == SessionApp.SucursalSel.Idsucursal).ToList();
            iIdcentrodecosto.Properties.DataSource = CentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            
            VwAreaList = CacheObjects.VwAreaList;
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombreareasucursal";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            VwProyectoList =CacheObjects.VwProyectoList.Where(x => x.Idempresa == SessionApp.SucursalSel.Idsucursal).ToList();
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            TipoafectacionigvList = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DataSource = TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

			        VwordencompradetMnt.Numeroitem = (int)iNumeroitem.EditValue;
			        VwordencompradetMnt.Idarticulo = (int)iIdarticulo.EditValue;
			        VwordencompradetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
			        VwordencompradetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
			        VwordencompradetMnt.Idunidadinventario = (int?)iIdunidadmedida.EditValue;
			        VwordencompradetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
			        VwordencompradetMnt.Nombrearticulo = beArticulo.Text.Trim();
			        VwordencompradetMnt.Cantidad = (decimal)iCantidad.EditValue;
			        VwordencompradetMnt.Idunidadmedida = (int?)iIdunidadmedida.EditValue;
			        VwordencompradetMnt.Abrunidadmedida = iIdunidadmedida.Text.Trim();
			        VwordencompradetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwordencompradetMnt.Especificacion = iEspecificacion.Text.Trim();
			        VwordencompradetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
			        VwordencompradetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
			        VwordencompradetMnt.Descuento3 = (decimal)iDescuento3.EditValue;
			        VwordencompradetMnt.Descuento4 = (decimal)iDescuento4.EditValue;
			        VwordencompradetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
			        VwordencompradetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwordencompradetMnt.Pesoarticulo = (decimal) rPesoarticulo.EditValue;
                    VwordencompradetMnt.Pesototalkg = Math.Round(VwordencompradetMnt.Cantidad*VwordencompradetMnt.Pesoarticulo,2);
			        VwordencompradetMnt.Idimpuesto = (int?)iIdimpuesto.EditValue;

                    VwordencompradetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwordencompradetMnt.Gravado = VwArticuloSel.Gravado;
                    VwordencompradetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwordencompradetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwordencompradetMnt.Exportacion = VwArticuloSel.Exportacion;

			        VwordencompradetMnt.Idcentrodecosto = (int?)iIdcentrodecosto.EditValue;
			        VwordencompradetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
			        VwordencompradetMnt.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
			        VwordencompradetMnt.Idarea = (int?)iIdarea.EditValue;
                    VwordencompradetMnt.Nombrearea = iIdarea.Text.Trim();
			        VwordencompradetMnt.Idproyecto = (int?)iIdproyecto.EditValue;
                    VwordencompradetMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwordencompradetMnt.Idtipoafectacionigv = (int) iIdtipoafectacionigv.EditValue;
                    VwordencompradetMnt.Fechaentrega = (DateTime?) iFechaentrega.EditValue;

                    if (VwordencompradetMnt.Idrequerimientodet == null)
                    {
                        VwordencompradetMnt.Idrequerimientodet = null;
                        VwordencompradetMnt.Serienumeroreq = string.Empty;
                    }

                    //Los items por defecto se calculan
                    VwordencompradetMnt.Calcularitem = true;
                    
                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {                        
                        AsignarDetalleDeArticulosCompuestos(VwordencompradetMnt.Idarticulo);
                    }
                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwordencompradetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwordencompradetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwordencompradetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwordencompradetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwordencompradetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwordencompradetMnt.DataEntityState = DataEntityState.Modified;                            
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
            VwOrdencompradetComponenteList = new List<VwOrdencompradet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwOrdencompradet vwOrdencompradet = new VwOrdencompradet();
                vwOrdencompradet.Numeroitem = numeroItem;
                vwOrdencompradet.Idarticulo = item.Idarticulodetalle;
                vwOrdencompradet.Codigoarticulo = item.Codigoarticulo;
                vwOrdencompradet.Codigoproveedor = item.Codigoproveedor;
                vwOrdencompradet.Idunidadinventario = item.Idunidadinventario;
                vwOrdencompradet.Nombremarca = item.Nombremarca;
                vwOrdencompradet.Nombrearticulo = item.Nombrearticulo;
                vwOrdencompradet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwOrdencompradet.Idunidadmedida = item.Idunidadinventario;
                vwOrdencompradet.Abrunidadmedida = item.Abrunidadmedida;
                vwOrdencompradet.Preciounitario = 0m;
                vwOrdencompradet.Especificacion = string.Empty;
                vwOrdencompradet.Descuento1 = 0m;
                vwOrdencompradet.Descuento2 = 0m;
                vwOrdencompradet.Descuento3 = 0m;
                vwOrdencompradet.Descuento4 = 0m;
                vwOrdencompradet.Preciounitarioneto = 0m;
                vwOrdencompradet.Importetotal = 0m;
                vwOrdencompradet.Pesoarticulo = 0m;
                vwOrdencompradet.Pesototalkg = 0m;
                vwOrdencompradet.Idimpuesto = item.Idimpuesto;

                vwOrdencompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwOrdencompradet.Gravado = item.Gravado;
                vwOrdencompradet.Exonerado = item.Exonerado;
                vwOrdencompradet.Inafecto = item.Inafecto;
                vwOrdencompradet.Exportacion = item.Exportacion;

                vwOrdencompradet.Idcentrodecosto = (int?)iIdcentrodecosto.EditValue;
                vwOrdencompradet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwOrdencompradet.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
                vwOrdencompradet.Idarea = (int?)iIdarea.EditValue;
                vwOrdencompradet.Nombrearea = iIdarea.Text.Trim();
                vwOrdencompradet.Idproyecto = (int?)iIdproyecto.EditValue;
                vwOrdencompradet.Nombreproyecto = iIdproyecto.Text.Trim();

                if (vwOrdencompradet.Idrequerimientodet == null)
                {
                    vwOrdencompradet.Idrequerimientodet = null;
                    vwOrdencompradet.Serienumeroreq = string.Empty;
                }

                //Se estable a false no se calcula el item
                vwOrdencompradet.Calcularitem = false;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwOrdencompradet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwOrdencompradet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwOrdencompradet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwOrdencompradet.Lastmodified = DateTime.Now;
                        break;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwOrdencompradet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwOrdencompradet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                VwOrdencompradetComponenteList.Add(vwOrdencompradet);
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
        private void OrdencompraMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            var descuento3 = (decimal)iDescuento3.EditValue;
            var descuento4 = (decimal)iDescuento4.EditValue;

            var preciounitarioneto = Decimal.Round(precioUniatario 
                * (1 - descuento1 / 100) 
                * (1 - descuento2 / 100) 
                * (1 - descuento3 / 100)
                * (1 - descuento4 / 100), 4);

            var importeTotal = Decimal.Round(cantidad * preciounitarioneto, 2);

            iPreciounitarioneto.EditValue = preciounitarioneto;
            iImportetotal.EditValue = importeTotal;
        }
        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;

            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            VwArticuloSel = Service.GetVwArticulo(((int)idArticuloSel));
            if (VwArticuloSel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = VwArticuloSel.Codigoarticulo;
                iCodigoproveedor.EditValue = VwArticuloSel.Codigoproveedor;
                beArticulo.Text = VwArticuloSel.Nombrearticulo.Trim();
                iMarcaarticulo.EditValue = VwArticuloSel.Nombremarca;
                iIdimpuesto.EditValue = VwArticuloSel.Idimpuesto;
                iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
                rPesoarticulo.EditValue = VwArticuloSel.Pesoarticulo;
                iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                rPesoarticulo.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;
            }
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
            var buscadorArticuloFrm = new BuscadorArticuloFrmBase(VwCptooperacionSel.Buscarsoloitemservicio);
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticuloSel.Idarticulo;

            }
        }
    }
}