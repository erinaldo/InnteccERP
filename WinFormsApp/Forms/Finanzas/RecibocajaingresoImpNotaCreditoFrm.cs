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
using DevExpress.XtraGrid.Views.Base;
using Utilities;

namespace WinFormsApp
{
    public partial class RecibocajaingresoImpNotaCreditoFrm : XtraForm
    {
        public int Idcpventa { get; set; }
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwNotacreditoclireciboingresoimp> _vwNotacreditoclireciboingresoimpList;
        public List<VwRecibocajaingresodet> VwRecibocajadetList { get; set; }
        public VwNotacreditoclireciboingresoimp VwNotacreditoclireciboingresoimp { get; set; }
        public RecibocajaingresoImpNotaCreditoFrm(int idcpventa)
        {
            

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            Idcpventa = idcpventa;

        }
        private void RecibocajaingresoImpNotaCreditoFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            ValoresPorDefecto();
        }

        private void ValoresPorDefecto()
        {
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
        }

        private void CargarReferencias()
        {
            iIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarDocumentos()
        {
            gcDocImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string condicion = string.Empty;


            condicion = string.Format("idsucursal = {0} and importesaldo > 0 and idcpventa = {1} and not anulado", (int)iIdsucursal.EditValue, Idcpventa);



            _vwNotacreditoclireciboingresoimpList = Service.GetAllVwNotacreditoclireciboingresoimp(condicion, "abreviaturatipoformato,serienotacredito,numeronotacredito");


            gcDocImp.BeginUpdate();
            gcDocImp.DataSource = _vwNotacreditoclireciboingresoimpList;
            gcDocImp.EndUpdate();
            gvDocImp.BestFitColumns();

            Cursor = Cursors.Default;
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;



            switch (e.Item.Name)
            {
                case "btnImportar":
                    if (gvDocImp.RowCount == 0)
                    {
                        break;
                    }
                    VwNotacreditoclireciboingresoimp = (VwNotacreditoclireciboingresoimp) gvDocImp.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    VwNotacreditoclireciboingresoimp = null;
                    break;
                case "btnConsultar":
                    CargarDocumentos();
                    break;
                case "btnCerrar":
                    VwNotacreditoclireciboingresoimp = null;
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void RecibocajaingresoImpNotaCreditoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwNotacreditoclireciboingresoimp itemSel = (VwNotacreditoclireciboingresoimp)gvDocImp.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Saldoaimportar":                    
                    if (itemSel.Saldoaimportar > itemSel.Importesaldo)
                    {
                        XtraMessageBox.Show("El Monto a importar no es valida", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        itemSel.Saldoaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Itemseleccionado = itemSel.Saldoaimportar > 0;
                    }
                    gvDocImp.RefreshData();
                    break;
                case "Itemseleccionado":

                    if (itemSel.Importesaldo == 0)
                    {
                        itemSel.Saldoaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Saldoaimportar = itemSel.Itemseleccionado ? itemSel.Importesaldo : 0;
                    }
                    gvDocImp.RefreshData();
                    break;
            }
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvDocImp.PostEditor();

        }

        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwNotacreditoclireciboingresoimpList)
            {
                item.Itemseleccionado = (item.Importesaldo > 0 && chkSeleccionarTodo.Checked);
                item.Saldoaimportar = item.Importesaldo > 0 && chkSeleccionarTodo.Checked ? item.Importesaldo : 0;

            }
            gvDocImp.RefreshData();
        }

        private void riNumerico2_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvDocImp.PostEditor();
        }
    }
}