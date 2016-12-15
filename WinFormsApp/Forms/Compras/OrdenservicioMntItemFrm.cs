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
    public partial class OrdenservicioMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticulo VwArticuloSel { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwOrdenserviciodet VwordenserviciodetMnt { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<Centrodecosto> CentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public VwCptooperacion VwCptooperacionSel { get; set; }
        public OrdenservicioMntItemFrm(TipoMantenimiento tipoMnt, VwOrdenserviciodet vwordenserviciodetMnt, VwTipocp vwTipocpSel, VwCptooperacion vwCptooperacionSel)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwordenserviciodetMnt = vwordenserviciodetMnt;
            VwTipocpSel = vwTipocpSel;
            VwCptooperacionSel = vwCptooperacionSel;
        }
        private void OrdenservicioMntItemFrm_Load(object sender, EventArgs e)
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
            iNumeroitem.EditValue = VwordenserviciodetMnt.Numeroitem;

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

            ////Centro de costo por defecto
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
            iNumeroitem.EditValue = VwordenserviciodetMnt.Numeroitem;
            iIdarticulo.EditValue = VwordenserviciodetMnt.Idarticulo;
            iIdcentrodecosto.EditValue = VwordenserviciodetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwordenserviciodetMnt.Idarea;
            iIdproyecto.EditValue = VwordenserviciodetMnt.Idproyecto;
            iEspecificacion.EditValue = VwordenserviciodetMnt.Especificacion;
            iCantidad.EditValue = VwordenserviciodetMnt.Cantidad;
            iPreciounitario.EditValue = VwordenserviciodetMnt.Preciounitario;
            iImportetotal.EditValue = VwordenserviciodetMnt.Importetotal;
            iPorcentajepercepcion.EditValue = VwordenserviciodetMnt.Porcentajepercepcion;
        }
        private void CargarReferencias()
        {

            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("nombreunidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = Service.GetAllImpuesto("nombreimpuesto");
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;


            string whereCentroCosto = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            CentrodecostoList = Service.GetAllCentrodecosto(whereCentroCosto,"descripcioncentrodecosto");
            iIdcentrodecosto.Properties.DataSource = CentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereArea = string.Format("idsucursal = {0}", UsuarioAutenticado.SucursalSel.Idsucursal);
            //VwAreaList = Service.GetAllVwArea(whereArea, "nombresucursal,nombrearea");
            VwAreaList = Service.GetAllVwArea("nombresucursal,nombrearea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombreareasucursal";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            string whereProyecto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwProyectoList = Service.GetAllVwProyecto(whereProyecto,"codigoproyecto");
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

			        VwordenserviciodetMnt.Numeroitem = (int)iNumeroitem.EditValue;
			        VwordenserviciodetMnt.Idarticulo = (int)iIdarticulo.EditValue;
			        VwordenserviciodetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
			        VwordenserviciodetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
			        VwordenserviciodetMnt.Idunidadinventario = (int?)iIdunidadmedida.EditValue;
			        VwordenserviciodetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
			        VwordenserviciodetMnt.Nombrearticulo = beArticulo.Text.Trim();
			        VwordenserviciodetMnt.Cantidad = (decimal)iCantidad.EditValue;
			        VwordenserviciodetMnt.Idunidadmedida = (int?)iIdunidadmedida.EditValue;
			        VwordenserviciodetMnt.Abrunidadmedida = iIdunidadmedida.Text.Trim();
			        VwordenserviciodetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwordenserviciodetMnt.Especificacion = iEspecificacion.Text.Trim();
			        VwordenserviciodetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
			        VwordenserviciodetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
			        VwordenserviciodetMnt.Descuento3 = (decimal)iDescuento3.EditValue;
			        VwordenserviciodetMnt.Descuento4 = (decimal)iDescuento4.EditValue;
			        VwordenserviciodetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
			        VwordenserviciodetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwordenserviciodetMnt.Pesoarticulo = (decimal) rPesoarticulo.EditValue;
                    VwordenserviciodetMnt.Pesototalkg = Math.Round(VwordenserviciodetMnt.Cantidad*VwordenserviciodetMnt.Pesoarticulo,2);
			        VwordenserviciodetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;

                    VwordenserviciodetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwordenserviciodetMnt.Gravado = VwArticuloSel.Gravado;
                    VwordenserviciodetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwordenserviciodetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwordenserviciodetMnt.Exportacion = VwArticuloSel.Exportacion;

			        VwordenserviciodetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
			        VwordenserviciodetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
			        VwordenserviciodetMnt.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
			        VwordenserviciodetMnt.Idarea = (int?)iIdarea.EditValue;
                    VwordenserviciodetMnt.Nombrearea = iIdarea.Text.Trim();
			        VwordenserviciodetMnt.Idproyecto = (int?)iIdproyecto.EditValue;
                    VwordenserviciodetMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwordenserviciodetMnt.Idtipoafectacionigv = (int) iIdtipoafectacionigv.EditValue;

                    if (VwordenserviciodetMnt.Idrequerimientodet == null)
                    {
                        VwordenserviciodetMnt.Idrequerimientodet = null;
                        VwordenserviciodetMnt.Serienumeroreq = string.Empty;
                    }


                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwordenserviciodetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwordenserviciodetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwordenserviciodetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwordenserviciodetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwordenserviciodetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwordenserviciodetMnt.DataEntityState = DataEntityState.Modified;                            
                            break;
                    }
                                        
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

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
        private void OrdenservicioMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
                * (1 - descuento4 / 100), 2);

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