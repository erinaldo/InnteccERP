using System;
using System.Collections.Generic;
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
    public partial class InventarioMoverUbicacionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwInventariostock VwInventariostock { get; set; }
        public List<VwInventariostock> VwInventariostockList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public int IdAlmacenSel { get; set; }
        public List<VwUbicacion> VwUbicacionList { get; set; }
        public int IdUbicacionDestino { get; set; }
        public InventarioMoverUbicacionMntItemFrm(TipoMantenimiento tipoMnt, VwInventariostock vwInventariostock, int idAlmacenSel)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwInventariostock = vwInventariostock;
            IdAlmacenSel = idAlmacenSel;
        }
        private void InventarioMoverUbicacionMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Mover " + Text;
                    break;

            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    BuscarArticulo();
                    iCantidadinventario.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
           
            iIdarticulo.EditValue = VwInventariostock.Idarticulo;
            iCantidadinventario.EditValue = VwInventariostock.Cantidadinventario;            
            iCantidadajuste.EditValue = VwInventariostock.Cantidadajuste;
            rCantidadTotal.EditValue = VwInventariostock.Cantidadtotal;
            iCostounisoles.EditValue = VwInventariostock.Costounisoles;
            iCostototsoles.EditValue = VwInventariostock.Costototsoles;
            iCostounidolares.EditValue = VwInventariostock.Costounidolares;
            iCostototdolares.EditValue = VwInventariostock.Costototdolares;
            iTipocambio.EditValue = VwInventariostock.Tipocambio;
        }
        private void CargarDatosForaneos()
        {

            //Registro desde entrada
            string where = string.Format("idalmacen = {0}", IdAlmacenSel);
            VwUbicacionList = Service.GetAllVwUbicacion(where, "idubicacion");
            iIdubicacion.Properties.DataSource = VwUbicacionList;
            iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
            iIdubicacion.Properties.ValueMember = "Idubicacion";
            iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

           

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    
                    VwInventariostock.Idarticulo = (int)iIdarticulo.EditValue;
                    VwInventariostock.Codigoarticulo = (string) iCodigoarticulo.EditValue;
                    VwInventariostock.Nombrearticulo = beArticulo.Text.Trim();
                    VwInventariostock.Abrunidadmedida = iAbrunidad.Text.Trim();
                    VwInventariostock.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwInventariostock.Cantidadinventario = (decimal)iCantidadinventario.EditValue;
                    VwInventariostock.Cantidadajuste = (decimal)iCantidadajuste.EditValue;
                    VwInventariostock.Cantidadtotal = (decimal) rCantidadTotal.EditValue;
                    VwInventariostock.Costounisoles = (decimal)iCostounisoles.EditValue;
                    VwInventariostock.Costototsoles = (decimal)iCostototsoles.EditValue;
                    VwInventariostock.Costounidolares = (decimal)iCostounidolares.EditValue;
                    VwInventariostock.Costototdolares = (decimal)iCostototdolares.EditValue;
                    VwInventariostock.Tipocambio = (decimal)iTipocambio.EditValue;
                    IdUbicacionDestino = (int) iIdubicacion.EditValue;

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                        //    VwInventariostock.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //    VwInventariostock.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                        //    VwInventariostock.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //    VwInventariostock.Lastmodified = DateTime.Now;
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
        private void InventarioMoverUbicacionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CalculoTotalSoles()
        {
            var cantidad = (decimal)iCantidadinventario.EditValue;
            var precioUniatario = (decimal)iCostounisoles.EditValue;
            var importeTotal = Decimal.Round(cantidad * precioUniatario, 2);
            iCostototsoles.EditValue = importeTotal;
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
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();

            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;

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
                iAbrunidad.EditValue = articulosel.Idunidadinventario;
                iAbrunidad.EditValue = articulosel.Abrunidadmedida;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iAbrunidad.EditValue = string.Empty;


            }
        }

        private void iCostounidolares_EditValueChanged(object sender, EventArgs e)
        {
            var cantidad = (decimal)iCantidadinventario.EditValue;
            var precioUnitario = (decimal)iCostounidolares.EditValue;
            var importeTotal = Decimal.Round(cantidad * precioUnitario, 2);
            iCostototdolares.EditValue = importeTotal;
        }

        private void iTipocambio_EditValueChanged(object sender, EventArgs e)
        {
            iCostounisoles.EditValue = Decimal.Round((decimal)iCostounidolares.EditValue * (decimal)iTipocambio.EditValue, 2);
            CalculoTotalSoles();
        }

        private void iCostounisoles_EditValueChanged(object sender, EventArgs e)
        {
            CalculoTotalSoles();
        }

        private void CalcularCantidadTotal_EditValueChanged(object sender, EventArgs e)
        {
            rCantidadTotal.EditValue = (decimal) iCantidadinventario.EditValue + (decimal)iCantidadajuste.EditValue;
        }

        private void iIdubicacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            UbicacionMntFrm ubicacionMntFrm = new UbicacionMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            ubicacionMntFrm.ShowDialog();
            if (ubicacionMntFrm.IdEntidadMnt > 0)
            {
                VwUbicacion vwUbicacion = Service.GetVwUbicacion(ubicacionMntFrm.IdEntidadMnt);
                if (vwUbicacion != null)
                {
                    VwUbicacionList.Add(vwUbicacion);
                    e.Cancel = false;
                    e.NewValue = vwUbicacion.Idubicacion;
                }
            }
        }
    }
}