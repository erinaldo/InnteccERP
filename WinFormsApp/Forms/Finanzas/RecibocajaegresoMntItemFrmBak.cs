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
    public partial class RecibocajaegresoMntItemFrmBak : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRecibocajaegresodet VwRecibocajadetMnt { get; set; }
        public List<VwRecibocajaegresodet> VwRecibocajadetList { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<Tipomediopago> TipomediopagoList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public RecibocajaegresoMntItemFrmBak(TipoMantenimiento tipoMnt, VwRecibocajaegresodet vwRecibocajadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwRecibocajadetMnt = vwRecibocajadet;

         
        }
        private void RecibocajaegresoMntItemFrmBak_Load(object sender, EventArgs e)
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
            iImportepago.Select();
        }
        private void ValoresPorDefecto()
        {
            iIdmediopago.EditValue = 9; //Efectivo
            iIdtipodocmov.EditValue = 28; // Caja Chica
           
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
                    VwRecibocajadetMnt.Idtipocp = (int)iIdtipocp.EditValue;
                    VwRecibocajadetMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRecibocajadetMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRecibocajadetMnt.Importepago = (decimal)iImportepago.EditValue;
                    VwRecibocajadetMnt.Idmediopago = (int)iIdmediopago.EditValue;
                    VwRecibocajadetMnt.Numeromediopago = iNumeromediopago.Text.Trim();
                    VwRecibocajadetMnt.Comentario = iComentario.Text.Trim();
                    
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
        private void RecibocajaegresoMntItemFrmBak_KeyPress(object sender, KeyPressEventArgs e)
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
                    VwTipocp vwTipocp = VwTipocpList.FirstOrDefault(x => x.Idtipodocmov == (int)iIdtipodocmov.EditValue);
                    iIdtipocp.EditValue = (int)vwTipocp.Idtipocp;
                    
                }
            }
        }
    }
}