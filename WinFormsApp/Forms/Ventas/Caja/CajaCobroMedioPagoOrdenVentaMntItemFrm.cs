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
    public partial class CajaCobroMedioPagoOrdenVentaMntItemFrm : XtraForm
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
        public VwTipocp VwTipoCpVenta { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajaingresodetListMnt { get; set; }
        public CajaCobroMedioPagoOrdenVentaMntItemFrm(TipoMantenimiento tipoMnt, VwRecibocajaingresodet vwRecibocajadet, VwTipocp vwTipoCpVenta, List<VwRecibocajaingresodet> vwRecibocajaingresodetListMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwRecibocajadetMnt = vwRecibocajadet;
            VwTipoCpVenta = vwTipoCpVenta;
            VwRecibocajaingresodetListMnt = vwRecibocajaingresodetListMnt;
        }
        private void CajaCobroMedioPagoOrdenVentaMntItemFrm_Load(object sender, EventArgs e)
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
            iIdmediopago.Select();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;
                    CargarDatosCpVenta();   
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            iNumeroitem.Select();
        }
        private void CargarDatosCpVenta()
        {
            iTipoCp.EditValue = VwTipoCpVenta.Nombretipocp;
            iSerietipocp.EditValue = VwTipoCpVenta.Seriecp;
            iNumerotipocp.EditValue = VwTipoCpVenta.Numerocorrelativocp;
        }
        private void ValoresPorDefecto()
        {
            iIdmediopago.EditValue = 9; //Efectivo
            iImportepago.EditValue = VwRecibocajadetMnt.ImportePendiente;                    
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;

            iTipoCp.EditValue = VwTipoCpVenta.Nombretipocp;
            iSerietipocp.EditValue = VwTipoCpVenta.Seriecp;
            iNumerotipocp.EditValue = VwTipoCpVenta.Numerocorrelativocp;            
            iIdmediopago.EditValue = VwRecibocajadetMnt.Idmediopago;
            iNumeromediopago.EditValue = VwRecibocajadetMnt.Numeromediopago;
            iComentario.EditValue = VwRecibocajadetMnt.Comentario;          
            iImportepago.EditValue = VwRecibocajadetMnt.Importepago;                                          
        }
        private void CargarReferencias()
        {


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
                    VwRecibocajadetMnt.Idtipodocmov = VwTipoCpVenta.Idtipodocmov;
                    VwRecibocajadetMnt.Idtipocp = VwTipoCpVenta.Idtipocp;
                    VwRecibocajadetMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRecibocajadetMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRecibocajadetMnt.Importepago = (decimal)iImportepago.EditValue;
                    VwRecibocajadetMnt.Idmediopago = (int)iIdmediopago.EditValue;
                    VwRecibocajadetMnt.Nombremediopago = iIdmediopago.Text;
                    VwRecibocajadetMnt.Numeromediopago = iNumeromediopago.Text.Trim();
                    VwRecibocajadetMnt.Comentario = iComentario.Text.Trim();

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwRecibocajadetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwRecibocajadetMnt.DataEntityState = DataEntityState.Modified;
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
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            decimal totalMedioPago = VwRecibocajaingresodetListMnt.Where(x => x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Importepago);
            if (totalMedioPago == 0)
            {
            }

            return true;
        }
        private void CajaCobroMedioPagoOrdenVentaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}