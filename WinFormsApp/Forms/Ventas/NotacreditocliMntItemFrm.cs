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
    public partial class NotacreditocliMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwNotacreditoclidet VwNotacreditoclidet { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public NotacreditocliMntItemFrm(TipoMantenimiento tipoMnt, VwNotacreditoclidet vwCpventadetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwNotacreditoclidet = vwCpventadetMnt;

        }
        private void NotacreditocliMntItemFrm_Load(object sender, EventArgs e)
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
                    //BuscarArticulo();
                    iIdalmacen.Select();
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
            iNumeroitem.EditValue = VwNotacreditoclidet.Numeroitem;

            ////Centro de costo por defecto
            if (VwAreaList != null && VwAreaList.Count == 1)
            {
                VwArea vwAreaPorDefecto = VwAreaList.FirstOrDefault();
                if (vwAreaPorDefecto != null)
                    iIdarea.EditValue = vwAreaPorDefecto.Idarea;
            }

            ////Centro de costo por defecto
            if (VwCentrodecostoList != null && VwCentrodecostoList.Count == 1)
            {
                VwCentrodecosto vwCentrodecostoPorDefecto = VwCentrodecostoList.FirstOrDefault();
                if (vwCentrodecostoPorDefecto != null)
                    iIdcentrodecosto.EditValue = vwCentrodecostoPorDefecto.Idcentrodecosto;
            }

            ////Centro de costo por defecto
            if (VwProyectoList != null && VwProyectoList.Count == 1)
            {
                VwProyecto vwProyectoList = VwProyectoList.FirstOrDefault();
                if (vwProyectoList != null)
                    iIdproyecto.EditValue = vwProyectoList.Idproyecto;
            }
        }
        private void TraerDatos()
        {
            iIdalmacen.EditValue = VwNotacreditoclidet.Idalmacen;
            iNumeroitem.EditValue = VwNotacreditoclidet.Numeroitem;
            iIdarticulo.EditValue = VwNotacreditoclidet.Idarticulo;
            iEspecificacion.EditValue = VwNotacreditoclidet.Especificacion;
            iCantidad.EditValue = VwNotacreditoclidet.Cantidad;
            iPreciounitario.EditValue = VwNotacreditoclidet.Preciounitario;
            iImportetotal.EditValue = VwNotacreditoclidet.Importetotal;
            iIdtipoafectacionigv.EditValue = VwNotacreditoclidet.Idtipoafectacionigv;
            iIdcentrodecosto.EditValue = VwNotacreditoclidet.Idcentrodecosto;
            iIdarea.EditValue = VwNotacreditoclidet.Idarea;
            iIdproyecto.EditValue = VwNotacreditoclidet.Idproyecto;
            nPorcentajepercepcion.EditValue = VwNotacreditoclidet.Porcentajepercepcion;
        }
        private void CargarReferencias()
        {

            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("nombreunidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacen.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            TipoafectacionigvList = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DataSource = TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

            string whereCentroCosto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwCentrodecostoList = Service.GetAllVwCentrodecosto(whereCentroCosto, "descripcioncentrodecosto");
            iIdcentrodecosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereArea = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwAreaList = Service.GetAllVwArea(whereArea, "Codigoarea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            string whereProyecto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwProyectoList = Service.GetAllVwProyecto(whereProyecto, "codigoproyecto");
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

			        VwNotacreditoclidet.Numeroitem = (int)iNumeroitem.EditValue;
			        VwNotacreditoclidet.Idarticulo = (int)iIdarticulo.EditValue;
			        VwNotacreditoclidet.Codigoarticulo = iCodigoarticulo.Text.Trim();
			        VwNotacreditoclidet.Codigoproveedor = iCodigoproveedor.Text.Trim();
			        VwNotacreditoclidet.Idunidadmedida = (int)iIdunidadmedida.EditValue;
			        VwNotacreditoclidet.Nombremarca = iMarcaarticulo.Text.Trim();
			        VwNotacreditoclidet.Nombrearticulo = beArticulo.Text.Trim();
			        VwNotacreditoclidet.Cantidad = (decimal)iCantidad.EditValue;
			        VwNotacreditoclidet.Abrunidadmedida = iIdunidadmedida.Text.Trim();
			        VwNotacreditoclidet.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwNotacreditoclidet.Especificacion = iEspecificacion.Text.Trim();
			        VwNotacreditoclidet.Descuento1 = (decimal)iDescuento1.EditValue;
			        VwNotacreditoclidet.Descuento2 = (decimal)iDescuento2.EditValue;
			        VwNotacreditoclidet.Descuento3 = 0m;
			        VwNotacreditoclidet.Descuento4 = 0m;
			        VwNotacreditoclidet.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
			        VwNotacreditoclidet.Importetotal = (decimal)iImportetotal.EditValue;
                    VwNotacreditoclidet.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwNotacreditoclidet.Idalmacen = (int) iIdalmacen.EditValue;
                    VwNotacreditoclidet.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwNotacreditoclidet.Gravado = VwArticuloSel.Gravado;
                    VwNotacreditoclidet.Exonerado = VwArticuloSel.Exonerado;
                    VwNotacreditoclidet.Inafecto = VwArticuloSel.Inafecto;
                    VwNotacreditoclidet.Exportacion = VwArticuloSel.Exportacion;
                    VwNotacreditoclidet.Idarea = (int)iIdarea.EditValue;
                    VwNotacreditoclidet.Nombrearea = iIdarea.Text.Trim();
                    VwNotacreditoclidet.Idproyecto = (int)iIdproyecto.EditValue;
                    VwNotacreditoclidet.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwNotacreditoclidet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwNotacreditoclidet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwNotacreditoclidet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;

                    if (VwNotacreditoclidet.Idcpventadet == null)
                    {
                        VwNotacreditoclidet.Idcpventadet = null;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            //VwOrdendeventadetalleMnt.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetalleMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            //VwOrdendeventadetalleMnt.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetalleMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwNotacreditoclidet.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwNotacreditoclidet.DataEntityState = DataEntityState.Modified;                            
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
        private void NotacreditocliMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
                iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
                nPorcentajepercepcion.EditValue = VwArticuloSel.Aplicapercepcion ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;
                
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iIdtipoafectacionigv.EditValue = null;
                nPorcentajepercepcion.EditValue = 0m;
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
            var idAlmacen = iIdalmacen.EditValue;
            if (idAlmacen == null)
            {
                XtraMessageBox.Show("Seleccione el almacen", Resources.titAtencion, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                iIdalmacen.Select();
                return;
            }
            BuscadorArticuloFrm buscadorArticuloFrm = new BuscadorArticuloFrm(
                IdSucursalConsulta,
                IdAlmacenConsulta,
                IdTipoListaConsulta);
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                //Asignar al edit value del campo id foraneo               
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Idarticulo;
            }
        }
    }
}