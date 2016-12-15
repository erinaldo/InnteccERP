using System;
using System.Collections.Generic;
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
    public partial class ValorizacionproveedorImpOrdenservicioFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwOrdenservicio> _vwOrdenservicioList;

        private List<VwTipocp> _vwTipocpsList;

        private List<VwOrdendeserviciodetvalorizaimp> _vwOrdendeserviciodetvalorizaimpList;

        public VwOrdendeserviciodetvalorizaimp VwOrdendeserviciodetvalorizaimpSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public ValorizacionproveedorImpOrdenservicioFrm(VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void ValorizacionproveedorImpOrdenservicioFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

            //Valores por defectto
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            cboBuscarPor.SelectedIndex = 0; //Todos
        }
        private void CargarReferencias()
        {
            iIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENSERVICIO", (int)iIdsucursal.EditValue);
            _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
            iIdtipocp.Properties.DataSource = _vwTipocpsList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarCotizaconesDeVenta()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereCot = string.Empty;

            const string whereNoPendientes = @" idordenservicio 
                                               in (select a.idordenservicio
                                               from compras.vwordendeserviciodetvalorizaimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereCot = string.Format("anulado = '0' and idsucursal = {0} and {1} and idproveedor = {2}", (int)iIdsucursal.EditValue, whereNoPendientes, VwSocionegocioSel.Idsocionegocio);
                    break;
                case 1: //Cotizaciones

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereCot = string.Format(@"idtipocp = {0} and serieorden = '{1}'
                        and numeroorden = '{2}' and anulado = '0' and idsucursal = {3} and {4} and idcliente = {5}",
                        (int)iIdtipocp.EditValue,
                        rSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio);
                    break;
            }


            _vwOrdenservicioList = Service.GetAllVwOrdenservicio(whereCot, "abreviaturatipoformato,serieorden,numeroorden");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwOrdenservicioList;
            gcConsulta.EndUpdate();
            gvConsulta.BestFitColumns();

            Cursor = Cursors.Default;
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            
            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                   VwOrdendeserviciodetvalorizaimpSel = (VwOrdendeserviciodetvalorizaimp) gvDetalleImp.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCotizaconesDeVenta();


                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.OK;
                    break;

            }
        }
        private bool ValidacionDatosConsulta()
        {
            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    var idTipoCel = iIdtipocp.EditValue;

                    if (idTipoCel == null)
                    {
                        XtraMessageBox.Show("Seleccion el tipo de documento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iIdtipocp.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(iNumero.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;
                    }
                    break;
            }

            return true;
        }
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0 || gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información requerimientos, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    if (string.IsNullOrEmpty(iNumero.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;                        
                    }      
                    break;
            }

            return true;
        }
        private void ValorizacionproveedorImpOrdenservicioFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwOrdendeserviciodetvalorizaimp itemSel = (VwOrdendeserviciodetvalorizaimp)gvDetalleImp.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Cantidadaimportar":
                    if (itemSel.Cantidadaimportar > itemSel.Saldoaimportar)
                    {
                        XtraMessageBox.Show("Cantidad a importar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Itemseleccionado = itemSel.Cantidadaimportar > 0;
                    }
                    gvDetalleImp.RefreshData();
                    break;
                case "Itemseleccionado":

                    if (itemSel.Saldoaimportar == 0)
                    {
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Cantidadaimportar = itemSel.Itemseleccionado ? itemSel.Saldoaimportar : 0;
                    }
                    gvDetalleImp.RefreshData();
                    break;
            }
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvDetalleImp.PostEditor();

        }
        private void gvConsulta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleOrdenDeVenta();
        }
        private void CargarDetalleOrdenDeVenta()
        {
            VwOrdenservicio vwOrdenservicioSel = (VwOrdenservicio)gvConsulta.GetFocusedRow();

            if (vwOrdenservicioSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idordenservicio = {0} and saldoaimportar >0", vwOrdenservicioSel.Idordenservicio);
                _vwOrdendeserviciodetvalorizaimpList = Service.GetAllVwOrdendeserviciodetvalorizaimp(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwOrdendeserviciodetvalorizaimpList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                rSerie.EditValue = vwTipocp.Seriecp;
                rSerie.Properties.ReadOnly = true;
                iNumero.Focus();
            }
            else
            {
                rSerie.EditValue = @"0000";
                iNumero.EditValue = 0;
            }
        }
        private void iIdsucursal_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipocp.Enabled = false;
            rSerie.Enabled = false;
            iNumero.Enabled = false;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0: //Todos
                    break;
                case 1: //N° Requerimiento de compra
                    iIdtipocp.Enabled = true;
                    rSerie.Enabled = true;
                    iNumero.Enabled = true;
                    iIdtipocp.Focus();
                    break;
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwOrdendeserviciodetvalorizaimpList)
            {
                //item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                //item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}