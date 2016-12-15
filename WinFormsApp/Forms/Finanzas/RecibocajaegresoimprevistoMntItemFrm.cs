using System;
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
    public partial class RecibocajaegresoimprevistoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRecibocajaegresodet VwRecibocajadetRef { get; set; }
        public VwRecibocajaegresoimprevisto VwRecibocajaimprevistosMnt { get; set; }
            
        public RecibocajaegresoimprevistoMntItemFrm(TipoMantenimiento tipoMnt, VwRecibocajaegresodet vwRecibocajadetRef, VwRecibocajaegresoimprevisto vwRecibocajaimprevistosMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwRecibocajadetRef = vwRecibocajadetRef;
            VwRecibocajaimprevistosMnt = vwRecibocajaimprevistosMnt;


        }
        private void RecibocajaegresoimprevistoMntItemFrm_Load(object sender, EventArgs e)
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
                    TraerDatos();                    
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();                    
                    TraerDatos();
                    break;
            }
            iIdtipocp.Select();
        }
        private void ValoresPorDefecto()
        {

        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwRecibocajadetRef.Numeroitem;
            iNombretipocp.EditValue = VwRecibocajadetRef.Nombretipoformato;
            rSeriedocumento.EditValue = VwRecibocajadetRef.Serietipocp;
            rNumerodocumento.EditValue = VwRecibocajadetRef.Numerotipocp;

            iIdtipocp.EditValue = VwRecibocajaimprevistosMnt.Idtipocp;
            iSerietipocp.EditValue = VwRecibocajaimprevistosMnt.Serietipocp;
            iNumerotipocp.EditValue = VwRecibocajaimprevistosMnt.Numerotipocp;
            iImportepago.EditValue = VwRecibocajaimprevistosMnt.Importepago;


            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    iImportepago.EditValue = 0m;
                    break;
                case TipoMantenimiento.Modificar:
                    iImportepago.EditValue = VwRecibocajaimprevistosMnt.Importepago;
                    break;
            }

        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CAJA", SessionApp.SucursalSel.Idsucursal);
            iIdtipocp.Properties.DataSource = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp"); 
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;


                    VwRecibocajaimprevistosMnt.Idrecibocajaegresodet = VwRecibocajadetRef.Idrecibocajaegresodet;
                    VwRecibocajaimprevistosMnt.Idtipocp = (int)iIdtipocp.EditValue;
                    VwRecibocajaimprevistosMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRecibocajaimprevistosMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRecibocajaimprevistosMnt.Importepago = (decimal)iImportepago.EditValue;
                    VwRecibocajaimprevistosMnt.Nombretipoformato = iIdtipocp.Text.Trim();
                    
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
        private void RecibocajaegresoimprevistoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}