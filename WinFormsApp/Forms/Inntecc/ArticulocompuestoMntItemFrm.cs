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
    public partial class ArticulocompuestoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticulocompuesto VwArticulocompuestoMnt { get; set; }
        public List<VwArticulodetalleunidad> VwArticulodetalleunidadList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public ArticulocompuestoMntItemFrm(int idEntidadMnt, TipoMantenimiento tipoMnt,  VwArticulocompuesto vwArticulocompuestoMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwArticulocompuestoMnt = vwArticulocompuestoMnt;
            IdEntidadMnt = idEntidadMnt;

         
        }

        private void ArticulocompuestoMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
        }

        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            rNombreArticulo.EditValue = VwArticulocompuestoMnt.Nombrearticulo;
            iIdtipomoneda.EditValue = 1; //Nuevos Soles

        }

        private void TraerDatos()
        {
            //rNombreArticulo.EditValue = VwArticulocompuestoMnt.Nombrearticulo;
            //iIdunidadmedida.EditValue = VwArticulocompuestoMnt.Idunidadmedida;
            iIdarticulo.EditValue = VwArticulocompuestoMnt.Idarticulo;
            iIdunidadmedida.EditValue = VwArticulocompuestoMnt.Idunidadinventario;
            iCantidad.EditValue = VwArticulocompuestoMnt.Cantidaddetalle;
            iValorUnitario.EditValue = VwArticulocompuestoMnt.Valorunitario;
            iIdtipomoneda.EditValue = VwArticulocompuestoMnt.Idtipomoneda;
        }

        private void CargarReferencias()
        {
            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("codigounidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    //VwArticulocompuestoMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwArticulocompuestoMnt.Idarticulo = IdEntidadMnt;
                    VwArticulocompuestoMnt.Idunidadinventario = (int)iIdunidadmedida.EditValue;
                    VwArticulocompuestoMnt.Cantidaddetalle = (decimal)iCantidad.EditValue;
                    VwArticulocompuestoMnt.Valorunitario = (decimal)iValorUnitario.EditValue;
                    VwArticulocompuestoMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
                    VwArticulocompuestoMnt.Idarticulodetalle = (int)iIdarticulo.EditValue;


                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ArticulocompuestoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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
            BuscadorArticuloFrmBase buscadorArticuloFrm = new BuscadorArticuloFrmBase();
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticuloSel.Idarticulo;

            }
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
                iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
            } 
        }
    }
}