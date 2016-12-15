using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class ListadoTipoCambioFrm : XtraForm
    {

        static readonly IService Service = new Service();

        public TipoCambioSunat TipoCambioSunat { get; set; }
        public DateTime FechaTipoCambio { get; set; }
        List<TipoCambioSunat> TipoCambioSunatList { get; set; }
        public ListadoTipoCambioFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            TipoCambioSunat = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (gvDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información de tipos de cambio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SeleccionarTipoCambio();
        }

        private void CargarReferencias()
        {
            string whereEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            cboEjercicio.Properties.DataSource = Service.GetAllEjercicio(whereEmpresa, "anioejercicio");
            cboEjercicio.Properties.DisplayMember = "Anioejercicio";
            cboEjercicio.Properties.ValueMember = "Anioejercicio";
        }

        private void SeleccionarTipoCambio()
        {

            TipoCambioSunat tipoCambioSunat = (TipoCambioSunat)gvDetalle.GetFocusedRow();
            TipoCambioSunat = tipoCambioSunat;
            FechaTipoCambio = new DateTime((int)cboEjercicio.EditValue, int.Parse(cboMes.EditValue.ToString()), int.Parse(TipoCambioSunat.Dia));
            DialogResult = DialogResult.OK;
        }

        private void ListadoTipoCambioFrm_Load(object sender, EventArgs e)
        {
            cboEjercicio.EditValue = SessionApp.EjercicioActual;
            CargarReferencias();
            CargarTiposDeCambio();
        }
        private void CargarMeses()
        {

            string whereEjercicio = string.Format("idempresa = {0} and anioejercicio = {1}",
            SessionApp.EmpresaSel.Idempresa, cboEjercicio.EditValue);
            cboMes.Properties.DataSource = Service.GetAllVwPeriodo(whereEjercicio, "mes");
            cboMes.Properties.DisplayMember = "Nombremes";
            cboMes.Properties.ValueMember = "Mes";

            string mesActual = SessionApp.DateServer.Month.ToString("D2");
            cboMes.EditValue = mesActual;
        }

        private void cboEjercicio_EditValueChanged(object sender, EventArgs e)
        {
            CargarMeses();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarTiposDeCambio();
        }

        private void CargarTiposDeCambio()
        {
            Cursor = Cursors.WaitCursor;
            TipoCambioSunatList = new TipoCambioSunat().ObtenerPorMes(int.Parse(cboMes.EditValue.ToString()), (int)cboEjercicio.EditValue);
            Cursor = Cursors.Default;
            gcDetalle.DataSource = TipoCambioSunatList;
            gvDetalle.MoveLastVisible();
        }

        private void cboMes_EditValueChanged(object sender, EventArgs e)
        {
            gcDetalle.DataSource = null;
        }

        private void BtnRegistrarMes(object sender, EventArgs e)
        {
            if (DialogResult.Yes == XtraMessageBox.Show("Registrar el mes seleccionado"
                ,"¿Tipo de cambio?"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button1) && gvDetalle.RowCount > 0)
            {
                Cursor = Cursors.WaitCursor;
                foreach (var item in TipoCambioSunatList)
                {
                    DateTime fechaTipoCambio = new DateTime(Convert.ToInt32(item.Anho), Convert.ToInt32(item.Mes), Convert.ToInt32(item.Dia));
                    if (Service.CountTipocambio(x => x.Fechatipocambio == fechaTipoCambio) <= 0)
                    {
                        Tipocambio tipoCambio = new Tipocambio();
                        tipoCambio.Idtipomoneda = 2;
                        tipoCambio.Fechatipocambio = fechaTipoCambio;
                        tipoCambio.Valorcomprasunat = (decimal)item.Compra;
                        tipoCambio.Valorventasunat = (decimal)item.Venta;
                        Service.SaveTipocambio(tipoCambio);
                    }
                }
                XtraMessageBox.Show("Registro terminado","Tipo de cambio",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }
    }
}