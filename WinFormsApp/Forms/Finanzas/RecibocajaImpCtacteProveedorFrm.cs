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
    public partial class RecibocajaImpCtacteProveedorFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();       

        private List<VwCtacteproveedor> _vwCtacteproveedorList;
        public List<VwRecibocajaegresodet> VwRecibocajadetList { get; set; }
        public VwRecibocajaegreso VwRecibocajaSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public int IdTipoMoneda { get; set; }
        public RecibocajaImpCtacteProveedorFrm(List<VwRecibocajaegresodet> vwRecibocajadetList, VwSocionegocio vwSocionegocioSel, int idTipoMoneda)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwRecibocajadetList = vwRecibocajadetList;
            VwSocionegocioSel = vwSocionegocioSel;
            IdTipoMoneda = idTipoMoneda;
        }
        private void RecibocajaImpCtacteProveedorFrm_Load(object sender, EventArgs e)
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

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPCOMPRA", (int)iIdsucursal.EditValue);
            iIdtipocp.Properties.DataSource = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
            
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarCuentaCorriente()
        {
            gcDocImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereCot = string.Empty;

            const string whereNoPendientes = @" totalsaldo > 0";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereCot = string.Format("idsucursal = {0} and {1} and idsocionegocio = {2} and idtipomoneda = {3}", (int)iIdsucursal.EditValue, whereNoPendientes, VwSocionegocioSel.Idsocionegocio, IdTipoMoneda);
                    break;
                case 1: //Cotizaciones

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereCot = string.Format(@"idtipocp = {0} and serietipocp = '{1}'
                        and numerotipocp = '{2}' and idsucursal = {3} and {4} and idsocionegocio = {5} and idtipomoneda = {6}",
                        (int)iIdtipocp.EditValue,
                        rSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio,
                        IdTipoMoneda);
                    break;
            }


            _vwCtacteproveedorList = Service.GetAllVwCtacteproveedor(whereCot, "abreviaturatipoformato,serietipocp,numerotipocp");


            gcDocImp.BeginUpdate();
            gcDocImp.DataSource = _vwCtacteproveedorList;
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

                    if (!Validaciones()) return;

                    var maxItem = VwRecibocajadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCtacteproveedorList.Where(x => x.Itemseleccionado))
                    {
                        VwRecibocajaegresodet vwRecibocajadet = new VwRecibocajaegresodet();
                        vwRecibocajadet.Numeroitem = sgtItem;
                        vwRecibocajadet.Idtipodocmov = item.Idtipodocmov;
                        vwRecibocajadet.Idtipocp = item.Idtipocp;
                        vwRecibocajadet.Serietipocp = item.Serietipocp;
                        vwRecibocajadet.Numerotipocp = item.Numerotipocp;
                        vwRecibocajadet.Importepago = item.Saldoaimportar;
                        vwRecibocajadet.Idmediopago = 9;
                        vwRecibocajadet.Numeromediopago = "";
                        vwRecibocajadet.Comentario = "";
                        vwRecibocajadet.Idcpcompra = item.Idcpcompra;
                        
                        vwRecibocajadet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwRecibocajadet.Idrecibocajaegresodet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                //vwOrdendeventadet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                                //vwOrdendeventadet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                //vwOrdendeventadet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                                //vwOrdendeventadet.Lastmodified = DateTime.Now;
                                break;
                        }

                        sgtItem++;
                        VwRecibocajadetList.Add(vwRecibocajadet);
                    }

                   // VwRecibocajaSel = (VwRecibocaja) gvDocImp.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCuentaCorriente();


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
            if (gvDocImp.RowCount == 0 || gvDocImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información Cuenta Corriente, verifique", "Atención", MessageBoxButtons.OK,
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
                        XtraMessageBox.Show("Ingrese el numero de Cuenta Corriente.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;                        
                    }      
                    break;
            }

            return true;
        }
        private void RecibocajaImpCtacteProveedorFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCtacteproveedor itemSel = (VwCtacteproveedor)gvDocImp.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Saldoaimportar":
                    //itemSel.Cantidadaimportar > itemSel.Saldoaimportar
                    if (itemSel.Saldoaimportar > itemSel.Totalsaldo)
                    {
                        XtraMessageBox.Show("El Monto a importar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
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

                    if (itemSel.Totalsaldo == 0)
                    {
                        itemSel.Saldoaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Saldoaimportar = itemSel.Itemseleccionado ? itemSel.Totalsaldo : 0;
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
        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCtacteproveedorList)
            {
                item.Itemseleccionado = (item.Totalsaldo > 0 && chkSeleccionarTodo.Checked);
                item.Saldoaimportar = item.Totalsaldo > 0 && chkSeleccionarTodo.Checked ? item.Totalsaldo : 0;

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