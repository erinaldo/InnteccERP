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
    public partial class NotacreditoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwNotacreditodet VwNotacreditodetMnt { get; set; }

        private List<VwArea> VwAreaList { get; set; }
        private List<Centrodecosto> CentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public NotacreditoMntItemFrm(TipoMantenimiento tipoMnt, VwNotacreditodet vwNotacreditodetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwNotacreditodetMnt = vwNotacreditodetMnt;

        }

        private void NotacreditoMntItemFrm_Load(object sender, EventArgs e)
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
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            beArticulo.Select();
        }

        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwNotacreditodetMnt.Numeroitem;

            ////Centro de costo por defecto
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
        }

        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwNotacreditodetMnt.Numeroitem;
            iIdarticulo.EditValue = VwNotacreditodetMnt.Idarticulo;
            iIdcentrodecosto.EditValue = VwNotacreditodetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwNotacreditodetMnt.Idarea;
            iIdproyecto.EditValue = VwNotacreditodetMnt.Idproyecto;
            iEspecificacion.EditValue = VwNotacreditodetMnt.Especificacion;
            iCantidad.EditValue = VwNotacreditodetMnt.Cantidad;
            iPreciounitario.EditValue = VwNotacreditodetMnt.Preciounitario;
            iImportetotal.EditValue = VwNotacreditodetMnt.Importetotal;
        }

        private void CargarReferencias()
        {
            VwArticuloList = Service.GetAllVwArticulo("nombrearticulo,nombremarca");


            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("nombreunidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = Service.GetAllImpuesto("nombreimpuesto");
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereCentroCosto = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            CentrodecostoList = Service.GetAllCentrodecosto(whereCentroCosto, "descripcioncentrodecosto");
            iIdcentrodecosto.Properties.DataSource = CentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereArea = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
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


                    VwNotacreditodetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwNotacreditodetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwNotacreditodetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwNotacreditodetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwNotacreditodetMnt.Idunidadinventario = (int)iIdunidadmedida.EditValue;
                    VwNotacreditodetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwNotacreditodetMnt.Nombrearticulo = beArticulo.Text.Trim();
                    VwNotacreditodetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwNotacreditodetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwNotacreditodetMnt.Abrunidadmedida = iIdunidadmedida.Text.Trim();
                    VwNotacreditodetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwNotacreditodetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwNotacreditodetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
                    VwNotacreditodetMnt.Descuento2 = 0m;
                    VwNotacreditodetMnt.Descuento3 = 0m;
                    VwNotacreditodetMnt.Descuento4 = 0m;
                    VwNotacreditodetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
                    VwNotacreditodetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwNotacreditodetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwNotacreditodetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwNotacreditodetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwNotacreditodetMnt.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
                    VwNotacreditodetMnt.Idarea = (int)iIdarea.EditValue;
                    VwNotacreditodetMnt.Nombrearea = iIdarea.Text.Trim();
                    VwNotacreditodetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwNotacreditodetMnt.Nombreproyecto = iIdproyecto.Text.Trim();

                    if (VwNotacreditodetMnt.Idcpcompradet == null)
                    {
                        VwNotacreditodetMnt.Idcpcompradet = null;
                        VwNotacreditodetMnt.Serienumerocpcompra = string.Empty;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwNotacreditodetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwNotacreditodetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwNotacreditodetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwNotacreditodetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwNotacreditodetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwNotacreditodetMnt.DataEntityState = DataEntityState.Modified;                            
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

        private void NotacreditoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            var descuento2 = 0m;
            var descuento3 = 0m;
            var descuento4 = 0m;

            var preciounitarioneto = Decimal.Round(precioUniatario 
                * (1 - descuento1 / 100) 
                * (1 - descuento2 / 100) 
                * (1 - descuento3 / 100)
                * (1 - descuento4 / 100), 2);

            var importeTotal = Decimal.Round(cantidad * preciounitarioneto, 2);

            iPreciounitarioneto.EditValue = preciounitarioneto;
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
            var buscadorArticuloFrmBase = new BuscadorArticuloFrmBase();
            buscadorArticuloFrmBase.ShowDialog();

            if (buscadorArticuloFrmBase.DialogResult == DialogResult.OK &&
                buscadorArticuloFrmBase.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloFrmBase.VwArticuloSel.Idarticulo;

            }
        }

        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;

            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            VwArticulo articulosel = Service.GetVwArticulo(((int)idArticuloSel));
            if (articulosel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = articulosel.Codigoarticulo;
                iCodigoproveedor.EditValue = articulosel.Codigoproveedor;
                beArticulo.Text = articulosel.Nombrearticulo.Trim();
                iMarcaarticulo.EditValue = articulosel.Nombremarca;
                iIdimpuesto.EditValue = articulosel.Idimpuesto;
                iIdunidadmedida.EditValue = articulosel.Idunidadinventario;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;

            }
        }
    }
}