using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public partial class CpcostoshistorialFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

       static readonly HelperDb HelperDb = new HelperDb();

       private DataTable DtUc { get; set; }
        public CpcostoshistorialFrm(int idArticulo)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            iIdarticulo.EditValue = idArticulo;
            Consultar();
        }

        public CpcostoshistorialFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void CargarReferencias()
        {
         
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Consultar();

        }

        private void Consultar()
        {
            var idArticulo = iIdarticulo.EditValue;
            if ((int)idArticulo == 0)
            {
                XtraMessageBox.Show("Seleccione el producto.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }


            if (iIdarticulo.EditValue != null)
            {

                const string nameRelation = "compras.vwcpcompradetcostos";

                string whereList = string.Format("idarticulo = '{0}' and idsucursal = '{1}'"
                     , iIdarticulo.EditValue
                     , SessionApp.SucursalSel.Idsucursal);
                const string ordersList = "fechaemision desc";
                string fieldsList = string.Format("top {0} *",speTop.Value);
                DtUc = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

                gcCostos.BeginUpdate();
                gcCostos.DataSource = DtUc;
                gcCostos.EndUpdate();
                gvCostos.BestFitColumns(true);
            }
        }

        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
                    break;
            }
        }

        private void BuscarArticulo()
        {
            //var buscadorArticuloFrm = new BuscadorArticuloFrm();
            //buscadorArticuloFrm.ShowDialog();

            //if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
            //    buscadorArticuloFrm.VwArticulounidadSel != null)
            //{
            //    //Asignar al edit value del campo id foraneo
            //    iIdarticulo.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Idarticulo;

            //}
        }

        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;

            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            VwArticulo articulosel = Service.GetVwArticulo(((int)idArticuloSel));
            if (articulosel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = articulosel.Codigoarticulo;
                beArticulo.Text = articulosel.Nombrearticulo.Trim();
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;

                beArticulo.Text = string.Empty;
            }
        }

        private void CpcostoshistorialFrm_Load(object sender, EventArgs e)
        {
            speTop.EditValue = 10;
            CargarReferencias();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

          //  DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            var report = new Report();
            const string nameFileReport = "ultimoscostos.frx";
            string reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", nameFileReport));
            report.Load(reporte);
            report.RegisterData(DtUc, "uc");
            //report.Design();
            report.Show();
            report.Dispose();
                

        }
    }
}