using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class InventarioDetSerieMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwInventariostock VwInventariostock { get; set; }
        public List<VwInventariostock> VwInventariostockList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwInventariostockdetserie> VwInventariostockdetserieList { get; set; }
        public string UbicacionSeleccionada { get; set; }
        public InventarioDetSerieMntFrm(TipoMantenimiento tipoMnt, VwInventariostock vwInventariostock, string ubicacionSeleccionada)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwInventariostock = vwInventariostock;
            UbicacionSeleccionada = ubicacionSeleccionada;
            IdEntidadMnt = vwInventariostock.Idinventariostock;


        }
        private void InventarioDetSerieMntFrm_Load(object sender, EventArgs e)
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
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    rUbicacion.EditValue = UbicacionSeleccionada;
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:
                    rUbicacion.EditValue = UbicacionSeleccionada;
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }
        }

        private void CargarDetalle()
        {
            Cursor = Cursors.WaitCursor;
            gcDetalle.BeginUpdate();
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idinventariostock = '{0}'", IdEntidadMnt);

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwInventariostockdetserieList = new List<VwInventariostockdetserie>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwInventariostockdetserieList = Service.GetAllVwInventariostockdetserie(where, "idinventariostockdetserie");
                    break;
            }

            gcDetalle.DataSource = VwInventariostockdetserieList;
            gcDetalle.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
           
            iIdinventariostock.EditValue = VwInventariostock.Idinventariostock;
            iCodigoarticulo.EditValue = VwInventariostock.Codigoarticulo;
            iCodigoproveedor.EditValue = VwInventariostock.Codigoproveedor;
            iCodigodebarra.EditValue = VwInventariostock.Codigodebarra;
            beArticulo.EditValue = VwInventariostock.Nombrearticulo;
            iMarcaarticulo.EditValue = VwInventariostock.Nombremarca;
            iAbrunidad.EditValue = VwInventariostock.Abrunidadmedida;

        }
        private void CargarDatosForaneos()
        {


           

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    
                    VwInventariostock.Idinventariostock = (int)iIdinventariostock.EditValue;
                    VwInventariostock.Codigoarticulo = (string) iCodigoarticulo.EditValue;
                    VwInventariostock.Nombrearticulo = beArticulo.Text.Trim();
                    VwInventariostock.Abrunidadmedida = iAbrunidad.Text.Trim();
                    VwInventariostock.Nombremarca = iMarcaarticulo.Text.Trim();


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
        private void InventarioDetSerieMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void bmSeries_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            InventarioDetSerieMntItemDinamicoFrm inventarioDetSerieMntItemDinamicoFrm;
            VwInventariostockdetserie vwInventariostockdetserie;
            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }


                    vwInventariostockdetserie = new VwInventariostockdetserie();

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    inventarioDetSerieMntItemDinamicoFrm = new InventarioDetSerieMntItemDinamicoFrm(tipoMantenimientoItem, VwInventariostock, vwInventariostockdetserie);
                    inventarioDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (inventarioDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Inventariostockdetserie inventariostockdetserie = AsignarInventariostockdetserie(vwInventariostockdetserie);
                        int idinventariostockdetserie = Service.SaveInventariostockdetserie(inventariostockdetserie);
                        if (idinventariostockdetserie > 0)
                        {
                            vwInventariostockdetserie.Idinventariostockdetserie = idinventariostockdetserie;
                            VwInventariostockdetserieList.Add(vwInventariostockdetserie);
                            ActualizarDetalle();
                            if (!gvDetalle.IsLastRow)
                            {
                                gvDetalle.MoveLastVisible();
                                gvDetalle.Focus();
                            }
                        }
                    }
                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    vwInventariostockdetserie = (VwInventariostockdetserie) gvDetalle.GetFocusedRow();
                    inventarioDetSerieMntItemDinamicoFrm = new InventarioDetSerieMntItemDinamicoFrm(TipoMantenimiento.Modificar, VwInventariostock, vwInventariostockdetserie);
                    inventarioDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (inventarioDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Inventariostockdetserie inventariostockdetserie = AsignarInventariostockdetserie(vwInventariostockdetserie);
                        if (inventariostockdetserie.Idinventariostockdetserie > 0)
                        {
                            Service.UpdateInventariostockdetserie(inventariostockdetserie);
                            ActualizarDetalle();
                        }
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwInventariostockdetserie = (VwInventariostockdetserie)gvDetalle.GetFocusedRow();
                        if (vwInventariostockdetserie != null && vwInventariostockdetserie.Idinventariostockdetserie > 0)
                        {
                            Service.DeleteInventariostockdetserie(vwInventariostockdetserie.Idinventariostockdetserie);
                            vwInventariostockdetserie.DataEntityState = DataEntityState.Deleted;
                            if (!gvDetalle.IsFirstRow)
                            {
                                gvDetalle.MovePrev();
                            }
                            ActualizarDetalle();
                        }
                    }
                    break;
            }
        }

        private void ActualizarDetalle()
        {
            gvDetalle.BeginUpdate();
            gvDetalle.RefreshData();
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        private Inventariostockdetserie AsignarInventariostockdetserie(VwInventariostockdetserie vwInventariostockdetserie)
        {
            Inventariostockdetserie inventariostockdetserie = new Inventariostockdetserie();
            inventariostockdetserie.Idinventariostockdetserie = vwInventariostockdetserie.Idinventariostockdetserie;
            inventariostockdetserie.Idinventariostock = vwInventariostockdetserie.Idinventariostock;
            inventariostockdetserie.Idseriearticulo = vwInventariostockdetserie.Idseriearticulo;
            return inventariostockdetserie;
        }
    }
}