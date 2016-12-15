using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using Utilities;

namespace WinFormsApp
{
    public partial class ListaprecioActualizacionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private static readonly IService Service = new Service();

        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwArticulolistaprecio> VwArticulolistaprecioList { get; set; }
        public List<VwListaprecio> VwListaprecioList { get; set; }
        public ListaprecioActualizacionFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }
        private void ListaprecioActualizacionFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            iIdsucursal.Enabled = false;
            //rListaprecioincluyeimpuesto.EditValue = SessionApp.EmpresaSel.Listaprecioincluyeimpuesto;
        }
        private void CargarReferencias()
        {
            string whereSucusal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdsucursal.Properties.DataSource = Service.GetAllVwSucursal(whereSucusal, "Nombresucursal");
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereLista = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            VwListaprecioList = Service.GetAllVwListaprecio(whereLista, "Tipolistaprecio");
            iIdlistaprecio.Properties.DataSource = VwListaprecioList;
            iIdlistaprecio.Properties.DisplayMember = "Tipolistaprecio";
            iIdlistaprecio.Properties.ValueMember = "Idlistaprecio";
            iIdlistaprecio.Properties.BestFitMode = BestFitMode.BestFit;


        }

        private void CargarDetalle()
        {
            string whereListaPrecio = string.Format("idlistaprecio = '{0}'", iIdlistaprecio.EditValue);
            gcDetalle.DataSource = null;
            VwArticulolistaprecioList = Service.GetAllVwArticulolistaprecio(whereListaPrecio, "idarticulolistaprecio");
            gcDetalle.DataSource = VwArticulolistaprecioList;

            VwListaprecio vwListaprecio = VwListaprecioList.FirstOrDefault(x => x.Idlistaprecio == (int)iIdlistaprecio.EditValue);
            if (vwListaprecio != null)
            {
                gcMargenCreditoOpcion1.Caption = string.Format("% Margen {0}", vwListaprecio.Diascondicion1);
                gcCreditodia1.Caption = string.Format("Crédito {0} Días", vwListaprecio.Diascondicion1);

                gcMargenCreditoOpcion2.Caption = string.Format("% Margen {0}", vwListaprecio.Diascondicion2);
                gcCreditodia2.Caption = string.Format("Crédito {0} Días", vwListaprecio.Diascondicion2);
            }
            gvDetalle.BestFitColumns();
        }

        private void ListaprecioActualizacionFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var buscadorArticuloFrm = new BuscadorArticuloFrmBase();
            buscadorArticuloFrm.ShowDialog();
            const string nombreIdDetalle = "Idarticulolistaprecio";
            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                // iIdarticulo.EditValue = buscadorArticuloFrm.ArticuloSel.Idarticulo;

                int cantReferenciasItem = VwArticulolistaprecioList.Count(x => x.Idarticulo == buscadorArticuloFrm.VwArticuloSel.Idarticulo && x.Idunidadmedida == buscadorArticuloFrm.VwArticuloSel.Idunidadinventario);

                if (cantReferenciasItem > 0)
                {
                    string mensaje = string.Format("El articulo {0} con presentacion {1} ya fue agregado a la LISTA",
                         buscadorArticuloFrm.VwArticuloSel.Nombrearticulo, buscadorArticuloFrm.VwArticuloSel.Nombreunidadmedida);

                    XtraMessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                    return;
                }

                VwArticulo vwArticulolistaprecioItem = Service.GetVwArticulo(x => x.Idarticulo == buscadorArticuloFrm.VwArticuloSel.Idarticulo && x.Idunidadinventario == buscadorArticuloFrm.VwArticuloSel.Idunidadinventario);

                var articulolistaprecioMnt = new Articulolistaprecio
                {
                    Idarticulo = vwArticulolistaprecioItem.Idarticulo,
                    Idlistaprecio = (int?)iIdlistaprecio.EditValue,
                    Idunidadmedida = vwArticulolistaprecioItem.Idunidadinventario,
                    Costolista = 0m,
                    Porcentajemargencontado = 0m,
                    Lastmodified = null
                };

                articulolistaprecioMnt.Idarticulolistaprecio = Service.SaveArticulolistaprecio(articulolistaprecioMnt);

                if (articulolistaprecioMnt.Idarticulolistaprecio > 0)
                {
                    CargarDetalle();
                    //Enfocar el id generado
                    if (articulolistaprecioMnt.Idarticulolistaprecio > 0 && gvDetalle.RowCount > 0)
                    {
                        gvDetalle.BeginUpdate();
                        var rowHandle = gvDetalle.LocateByValue(nombreIdDetalle, articulolistaprecioMnt.Idarticulolistaprecio);
                        if (rowHandle == GridControl.InvalidRowHandle)
                        {
                            gvDetalle.EndUpdate();
                            return;
                        }
                        gvDetalle.EndUpdate();
                        gvDetalle.FocusedRowHandle = rowHandle;
                    }
                }

            }
        }

        private void iIdlistaprecio_EditValueChanged(object sender, EventArgs e)
        {
            CargarDetalle();
            var idListaPrecio = iIdlistaprecio.EditValue;
            if (idListaPrecio != null)
            {
                VwListaprecio vwListaprecio = VwListaprecioList.FirstOrDefault(x => x.Idlistaprecio == (int) idListaPrecio);
                if (vwListaprecio != null)
                {
                    rListaprecioincluyeimpuesto.EditValue = vwListaprecio.Listaprecioincluyeimpuesto;
                }

            }
        }

        private void gvDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwArticulolistaprecio item = (VwArticulolistaprecio)gvDetalle.GetFocusedRow();
            switch (e.Column.FieldName)
            {
                case "Costolista":
                    CalcularPrecios(item);
                    break;
                case "Porcentajemargencontado":
                    item.Preciocontado = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencontado / 100), 2, MidpointRounding.AwayFromZero);
                    break;
                case "Preciocontado":
                    if (item.Costolista > 0m)
                    {
                        item.Porcentajemargencontado = decimal.Round(((item.Preciocontado * 100) / item.Costolista) - 100, 2, MidpointRounding.AwayFromZero);

                    }
                    break;
                case "Porcentajemargencreditoopcion1":
                    item.Preciocreditoopcion1 = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencreditoopcion1 / 100), 2, MidpointRounding.AwayFromZero);
                    break;
                case "Preciocreditoopcion1":
                    if (item.Costolista > 0m)
                    {
                        item.Porcentajemargencreditoopcion1 = decimal.Round(((item.Preciocreditoopcion1 * 100) / item.Costolista) - 100, 2, MidpointRounding.AwayFromZero);
                    }
                    break;
                case "Porcentajemargencreditoopcion2":
                    item.Preciocreditoopcion2 = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencreditoopcion2 / 100), 2, MidpointRounding.AwayFromZero);
                    break;
                case "Preciocreditoopcion2":
                    if (item.Costolista > 0m)
                    {
                        item.Porcentajemargencreditoopcion2 = decimal.Round(((item.Preciocreditoopcion2 * 100) / item.Costolista) - 100, 2, MidpointRounding.AwayFromZero);

                    }
                    break;
                case "Porcentajemargenpreciosugerido":
                    item.Preciosugerido = Decimal.Round(item.Costolista * (1 + item.Porcentajemargenpreciosugerido / 100), 2, MidpointRounding.AwayFromZero);
                    break;
                case "Preciosugerido":
                    if (item.Costolista > 0m)
                    {
                        item.Porcentajemargenpreciosugerido = decimal.Round(((item.Preciosugerido * 100) / item.Costolista) - 100, 2, MidpointRounding.AwayFromZero);

                    }                 
                    break;

            }
            item.Lastmodified = DateTime.Now;
            item.DataEntityState = DataEntityState.Modified;
            gvDetalle.UpdateCurrentRow();
            gvDetalle.PostEditor();
            gvDetalle.BestFitColumns(true);
        }

        private void CalcularPrecios(VwArticulolistaprecio item)
        {
            item.Preciocontado = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencontado / 100), 2, MidpointRounding.AwayFromZero);
            item.Preciocreditoopcion1 = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencreditoopcion1 / 100), 2, MidpointRounding.AwayFromZero);
            item.Preciocreditoopcion2 = Decimal.Round(item.Costolista * (1 + item.Porcentajemargencreditoopcion2 / 100), 2, MidpointRounding.AwayFromZero);
            item.Preciosugerido = Decimal.Round(item.Costolista * (1 + item.Porcentajemargenpreciosugerido / 100), 2, MidpointRounding.AwayFromZero);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gvDetalle.PostEditor();

            if (DialogResult.Yes == XtraMessageBox.Show("Desea actualizar la Lista de precios",
                                                     "Atención", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {

                foreach (var item in VwArticulolistaprecioList)
                {

                    //Si se modifico la cantidad
                    if (item.DataEntityState == DataEntityState.Modified)
                    {
                        Articulolistaprecio itemRedDet = Service.GetArticulolistaprecio(item.Idarticulolistaprecio);
                        itemRedDet.Costolista = item.Costolista;
                        itemRedDet.Porcentajemargencontado = item.Porcentajemargencontado;
                        itemRedDet.Preciocontado = item.Preciocontado;
                        itemRedDet.Porcentajemargencreditoopcion1 = item.Porcentajemargencreditoopcion1;
                        itemRedDet.Preciocreditoopcion1 = item.Preciocreditoopcion1;
                        itemRedDet.Porcentajemargencreditoopcion2 = item.Porcentajemargencreditoopcion2;
                        itemRedDet.Preciocreditoopcion2 = item.Preciocreditoopcion2;
                        itemRedDet.Porcentajemargenpreciosugerido = item.Porcentajemargenpreciosugerido;
                        itemRedDet.Preciosugerido = item.Preciosugerido;
                        itemRedDet.Lastmodified = item.Lastmodified;

                        Service.UpdateArticulolistaprecio(itemRedDet);
                    }


                }

                VwArticulolistaprecio vwArticulolistaprecio = (VwArticulolistaprecio)gvDetalle.GetFocusedRow();

                if (vwArticulolistaprecio.Idarticulolistaprecio > 0)
                {
                    CargarDetalle();
                    //Enfocar el id generado
                    if (gvDetalle.RowCount > 0)
                    {
                        gvDetalle.BeginUpdate();
                        var rowHandle = gvDetalle.LocateByValue("Idarticulolistaprecio", vwArticulolistaprecio.Idarticulolistaprecio);
                        if (rowHandle == GridControl.InvalidRowHandle)
                        {
                            gvDetalle.EndUpdate();
                            return;
                        }
                        gvDetalle.EndUpdate();
                        gvDetalle.FocusedRowHandle = rowHandle;
                    }
                }
            }
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idarticulolistaprecio = Convert.ToInt32(gvDetalle.GetRowCellValue(gvDetalle.FocusedRowHandle, "Idarticulolistaprecio"));

            if (idarticulolistaprecio > 0)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                    "Eliminar producto", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {

                    Service.DeleteArticulolistaprecio(idarticulolistaprecio);
                    CargarDetalle();
                }
            }
        }

        private void gcDetalle_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                gvDetalle.ShowFindPanel();
            }
        }

        private void riNumerico4_EditValueChanged(object sender, EventArgs e)
        {
            //gvDetalle.PostEditor();
        }

        private void riNumerico2_EditValueChanged(object sender, EventArgs e)
        {
            //gvDetalle.PostEditor();
        }
    }

}