using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Utilities;

namespace WinFormsApp
{
    public partial class CpcompracostoFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        public List<VwCpcompradet> VwCpcompradetList { get; set; }

        private Cpcompra CpcompraSel { get; set; }

        public CpcompracostoFrm(int idcpcompra)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            CargarOrdeneDeCompra(idcpcompra);

        }
        private void CpcompracostoFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

        }
        private void CargarReferencias()
        {

            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarOrdeneDeCompra(int idcpcompra)
        {
            CpcompraSel = Service.GetCpcompra(x => x.Idcpcompra == idcpcompra);
            iIdtipomoneda.EditValue = CpcompraSel.Idtipomoneda;
            iTipocambio.EditValue = CpcompraSel.Tipocambio;
        }

        private void CpcompracostoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}