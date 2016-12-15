using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class HistorialDocumentosFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();
        public VwRequerimiento VwRequerimiento { get; set; }

        private int Idrequerimiento { get; set; }
        static readonly HelperDb HelperDb = new HelperDb();
       
        public HistorialDocumentosFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        public HistorialDocumentosFrm(int idrequerimiento)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            Idrequerimiento = idrequerimiento;
            AsignarNumeroRequerimiento();
          
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

            if (iSerie.Text.Trim() == "0000")
            {
                XtraMessageBox.Show("El número de serie no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iSerie.Focus();
                return;
            }

            if (iNumero.Text.Trim() == "00000000")
            {
               
                XtraMessageBox.Show("El número de comprobante no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iNumero.Focus();
                return ;
            }
            string nameRelation = null;
            string whereList = null;
            string ordersList = null;
            string fieldsList = null;

            nameRelation = "compras.vwestadorequerimientos";

            switch (cboBuscar.SelectedIndex)
            {
                case 0: //Requerimiento

                  whereList = string.Format(@"seriereq = '{0}'
                  and numeroreq = '{1}' and idsucursal = {2}",
                  iSerie.Text.Trim(),
                  iNumero.Text.Trim(),
                  SessionApp.SucursalSel.Idsucursal);
                  ordersList = "fechareq";
                  fieldsList = "*";
                  break;
                case 1: //Orden Compra

                  whereList = string.Format(@"serieorden = '{0}'
                  and numeroorden = '{1}' and idsucursal = {2}",
                  iSerie.Text.Trim(),
                  iNumero.Text.Trim(),
                  SessionApp.SucursalSel.Idsucursal);
                  ordersList = "fechaordencompra";
                  fieldsList = "*";
                  break;   
            }
            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            gcHistorial.BeginUpdate();
            gcHistorial.DataSource = dt;
            gcHistorial.EndUpdate();
            gvHistorial.BestFitColumns(true);
            
        }

        
        private void HistorialDocumentosFrm_Load(object sender, EventArgs e)
        {
            cboBuscar.SelectedIndex = 0;
            CargarReferencias();
       
        
        }

        private void AsignarNumeroRequerimiento()
        {
            cboBuscar.SelectedIndex = 0;
           
            switch (cboBuscar.SelectedIndex)
            {
                case 0: //Requerimiento

                    if (Idrequerimiento != 0)
                    {
                        VwRequerimiento =
                            Service.GetVwRequerimiento(x => x.Idrequerimiento == Idrequerimiento);
                        iSerie.EditValue = VwRequerimiento.Seriereq;
                        iNumero.EditValue = VwRequerimiento.Numeroreq;
                        Consultar();
                    }
                    break;
            }
        }

        private void HistorialDocumentosFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}