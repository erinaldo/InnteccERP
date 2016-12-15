using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Utilities;

namespace WinFormsApp
{
    public partial class DetraccionClienteSelCpVentaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpventa> _vwCpVentaList;

        private List<VwTipocp> _vwTipocpsList;
        public VwCpventa VwCpventaSel { get; set; }
        public DetraccionClienteSelCpVentaFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }
        private void DetraccionClienteSelCpVentaFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

            //Valores por defectto
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            cboBuscarPor.SelectedIndex = 0; //Todos
        }
        private void CargarReferencias()
        {
            iIdsucursal.Properties.DataSource = CacheObjects.VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPVENTA", (int)iIdsucursal.EditValue);
            _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
            iIdtipocp.Properties.DataSource = _vwTipocpsList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarCpVenta()
        {
            gcConsulta.DataSource = null;
            Cursor = Cursors.WaitCursor;
            string whereCot = string.Empty;

            const string condicionNoDetraccion = @" and idcpventa 
                                                           not in (select a.idcpventa
                                                           from ventas.detraccioncliente a 
                                                           where a.anulado = '0')";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereCot = string.Format("anulado = '0' and idsucursal = {0} {1}", (int)iIdsucursal.EditValue, condicionNoDetraccion);
                    break;
                case 1: //Cotizaciones

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereCot = string.Format(@"idtipocp = {0} and seriecpventa = '{1}'
                        and numerocpventa = '{2}' and anulado = '0' and idsucursal = {3} {4}",
                        (int)iIdtipocp.EditValue,
                        rSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        condicionNoDetraccion
                        );
                    break;
            }


            _vwCpVentaList = Service.GetAllVwCpventa(whereCot, "abreviaturatipoformato,seriecpventa,numerocpventa");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwCpVentaList;
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

                    VwCpventaSel = (VwCpventa)gvConsulta.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCpVenta();
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
                        XtraMessageBox.Show("Ingrese el numero de Orden de trabajo.", "Atención", MessageBoxButtons.OK,
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
            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información de valorización, verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    if (string.IsNullOrEmpty(iNumero.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de valorización.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;
                    }
                    break;
            }

            return true;
        }
        private void DetraccionClienteSelCpVentaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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
    }
}