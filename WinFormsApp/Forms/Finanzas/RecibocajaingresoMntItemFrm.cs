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
    public partial class RecibocajaingresoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRecibocajaingresodet VwRecibocajadetMnt { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajadetList { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<Tipomediopago> TipomediopagoList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public RecibocajaingresoMntItemFrm(TipoMantenimiento tipoMnt, VwRecibocajaingresodet vwRecibocajadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwRecibocajadetMnt = vwRecibocajadet;


        }
        private void RecibocajaingresoMntItemFrm_Load(object sender, EventArgs e)
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            iNumeroitem.Select();
        }
        private void ValoresPorDefecto()
        {
            iIdmediopago.EditValue = 9; //Efectivo
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;

            iIdtipodocmov.EditValue = VwRecibocajadetMnt.Idtipodocmov;
            iIdtipocp.EditValue = VwRecibocajadetMnt.Idtipocp;
            iSerietipocp.EditValue = VwRecibocajadetMnt.Serietipocp;
            iNumerotipocp.EditValue = VwRecibocajadetMnt.Numerotipocp;
            iImportepago.EditValue = VwRecibocajadetMnt.Importepago;
            iIdmediopago.EditValue = VwRecibocajadetMnt.Idmediopago;
            iNumeromediopago.EditValue = VwRecibocajadetMnt.Numeromediopago;
            iComentario.EditValue = VwRecibocajadetMnt.Comentario;
            iImportepago.EditValue = VwRecibocajadetMnt.Importepago;
            iIdcpventa.EditValue = VwRecibocajadetMnt.Idcpventa;
            iIdnotacreditocli.EditValue = VwRecibocajadetMnt.Idnotacreditocli;
            iImporteNotaCredito.EditValue = VwRecibocajadetMnt.Importenc;

            SumarTotales();
        }

        private void SumarTotales()
        {
            iImporteTotal.EditValue = (decimal) iImportepago.EditValue + (decimal) iImporteNotaCredito.EditValue;
        }

        private void CargarReferencias()
        {

            TipodocmovList = Service.GetAllTipodocmov("nombretipodocmov");
            iIdtipodocmov.Properties.DataSource = TipodocmovList;
            iIdtipodocmov.Properties.DisplayMember = "Nombretipodocmov";
            iIdtipodocmov.Properties.ValueMember = "Idtipodocmov";
            iIdtipodocmov.Properties.BestFitMode = BestFitMode.BestFit;

            iIdmediopago.Properties.DataSource = Service.GetAllTipomediopago("idmediopago");
            iIdmediopago.Properties.DisplayMember = "Nombremediopago";
            iIdmediopago.Properties.ValueMember = "Idmediopago";
            iIdmediopago.Properties.BestFitMode = BestFitMode.BestFit;


        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwRecibocajadetMnt.Numeroitem = (int)iNumeroitem.EditValue;

                    VwRecibocajadetMnt.Idtipodocmov = (int?)iIdtipodocmov.EditValue;
                    VwRecibocajadetMnt.Idtipocp = (int?)iIdtipocp.EditValue;
                    VwRecibocajadetMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRecibocajadetMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRecibocajadetMnt.Importepago = (decimal)iImportepago.EditValue;
                    VwRecibocajadetMnt.Idmediopago = (int)iIdmediopago.EditValue;
                    VwRecibocajadetMnt.Numeromediopago = iNumeromediopago.Text.Trim();
                    VwRecibocajadetMnt.Comentario = iComentario.Text.Trim();
                    VwRecibocajadetMnt.Idcpventa = (int?)iIdcpventa.EditValue;
                    VwRecibocajadetMnt.Idnotacreditocli = (int?) iIdnotacreditocli.EditValue;
                    VwRecibocajadetMnt.Importenc = (decimal) iImporteNotaCredito.EditValue;

                    if (VwRecibocajadetMnt.Idtipodocmov == null)
                    {
                        VwRecibocajadetMnt.Idtipodocmov = null;
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
        private void RecibocajaingresoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void iIdtipodocmov_EditValueChanged(object sender, EventArgs e)
        {
            var idtipodocmov = iIdtipodocmov.EditValue;
            if (idtipodocmov != null)
            {
                Tipodocmov tipodocmovSel = TipodocmovList.FirstOrDefault(x => x.Idtipodocmov == (int)idtipodocmov);
                if (tipodocmovSel != null)
                {
                    string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", tipodocmovSel.Nombretipodocmov, SessionApp.SucursalSel.Idsucursal);
                    VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
                    iIdtipocp.Properties.DataSource = null;
                    iIdtipocp.Properties.DataSource = VwTipocpList;
                    iIdtipocp.Properties.DisplayMember = "Nombretipocp";
                    iIdtipocp.Properties.ValueMember = "Idtipocp";
                    iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
                }
            }
        }

        private void btnImportarNC_Click(object sender, EventArgs e)
        {
            var idCpventa = iIdcpventa.EditValue;
            if (idCpventa != null)
            {
                RecibocajaingresoImpNotaCreditoFrm recibocajaingresoImpNotaCreditoFrm = new RecibocajaingresoImpNotaCreditoFrm((int)idCpventa);
                if (recibocajaingresoImpNotaCreditoFrm.ShowDialog() == DialogResult.OK)
                {
                    if (recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp != null)
                    {
                        //rNumeroNc.EditValue =
                        //    string.Format(
                        //        "{0}-{1}",
                        //        recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp.Serienotacredito,
                        //        recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp.Numeronotacredito);

                        //rFechaNc.EditValue =
                        //    recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp.Fechaemision;

                        //iImporteNotaCredito.EditValue =
                        //    recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp.Saldoaimportar;

                        iIdnotacreditocli.EditValue = recibocajaingresoImpNotaCreditoFrm.VwNotacreditoclireciboingresoimp.Idnotacreditocli;
                        SumarTotales();
                    }
                }
            }
        }

        private void iIdnotacreditocli_EditValueChanged(object sender, EventArgs e)
        {
            var idNotaCreditoCli = iIdnotacreditocli.EditValue;
            if (idNotaCreditoCli != null)
            {
                VwNotacreditocli vwNotacreditocli = Service.GetVwNotacreditocli((int)idNotaCreditoCli);
                if (vwNotacreditocli != null)
                {
                    rNumeroNc.EditValue =
                        string.Format(
                            "{0}-{1}",
                            vwNotacreditocli.Serienotacredito,
                            vwNotacreditocli.Numeronotacredito);

                    rFechaNc.EditValue =
                        vwNotacreditocli.Fechaemision;

                }

            }
        }
    }
}