using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;

namespace WinFormsApp
{
    public partial class FiltroFormConsultaFrm : XtraForm
    {
        static readonly IService Service = new Service();
        public string FechaInicialConsulta { get; set; }
        public string FechaFinalConsulta { get; set; }
        public string DescripcionFiltroFecha { get; set; }

        public FiltroFormConsultaFrm()
        {
            InitializeComponent();
        }

        private void cboTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstablecerTipoDeFiltro();
        }

        private void EstablecerTipoDeFiltro()
        {
            cboMes.Enabled = false;
            deFechaInicial.Enabled = false;
            deFechaFinal.Enabled = false;
            cboMes.EditValue = null;
            deFechaInicial.EditValue = null;
            deFechaFinal.EditValue = null;

            switch (cboTipoFiltro.SelectedIndex)
            {
                case 0: //todos
                    break;
                case 1: //Mes
                    cboMes.Enabled = true;
                    CargarMeses();
                    break;
                case 2: //Rango de fecha
                    deFechaInicial.Enabled = true;
                    deFechaFinal.Enabled = true;
                    EstablecerFechaActual();
                    break;
            }
        }

        private void FiltroFormConsultaFrm_Load(object sender, EventArgs e)
        {
            cboTipoFiltro.SelectedIndex = 2;
            EstablecerTipoDeFiltro();
            CargarReferencias();
            cboEjercicio.EditValue = SessionApp.EjercicioActual;
        }

        private void CargarReferencias()
        {
            string whereEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            cboEjercicio.Properties.DataSource = Service.GetAllEjercicio(whereEmpresa,"anioejercicio");
            cboEjercicio.Properties.DisplayMember = "Anioejercicio";
            cboEjercicio.Properties.ValueMember = "Anioejercicio";
        }

        private void cboEjercicio_EditValueChanged(object sender, EventArgs e)
        {
            CargarMeses();
        }

        private void CargarMeses()
        {
            if (cboTipoFiltro.SelectedIndex == 1) //Mes
            {
                string whereEjercicio = string.Format("idempresa = {0} and anioejercicio = {1}",
                SessionApp.EmpresaSel.Idempresa, cboEjercicio.EditValue);
                cboMes.Properties.DataSource = Service.GetAllVwPeriodo(whereEjercicio, "mes");
                cboMes.Properties.DisplayMember = "Nombremes";
                cboMes.Properties.ValueMember = "Mes";

                string mesActual = SessionApp.DateServer.Month.ToString("D2");
                cboMes.EditValue = mesActual;
            }
            else
            {
                cboMes.EditValue = null;
            }
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            EstablecerFechaActual();
        }

        private void EstablecerFechaActual()
        {
            deFechaInicial.EditValue = SessionApp.DateServer;
            deFechaFinal.EditValue = SessionApp.DateServer;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string descripcionFiltro = null;
            string ejercicio = cboEjercicio.EditValue.ToString();
            string mes = null;

            if (cboMes.EditValue != null)
            {
                mes = cboMes.EditValue.ToString();
            }

            DateTime fechaInicial = new DateTime();
            DateTime fechaFinal = new DateTime();

            if (deFechaInicial.EditValue != null)
            {
                fechaInicial = (DateTime)deFechaInicial.EditValue;
            }

            if (deFechaFinal.EditValue != null)
            {
                fechaFinal = (DateTime)deFechaFinal.EditValue;
            }

            string fechaInicialConsulta = null;
            string fechaFinalConsulta = null;

            switch (cboTipoFiltro.SelectedIndex)
            {
                case 0: //todos
                    descripcionFiltro = string.Format("TODO DEL EJERCICIO {0}", ejercicio);
                    fechaInicialConsulta = string.Format("{0}-01-01", ejercicio);
                    DateTime mesFinalEjercicio = new DateTime(Convert.ToInt32(ejercicio), 12, 1);
                    fechaFinalConsulta = mesFinalEjercicio.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    break;
                case 1: //Mes
                    descripcionFiltro = string.Format("EJERCICIO {0} MES {1}", ejercicio, mes);
                    fechaInicialConsulta = string.Format("{0}-{1}-01", ejercicio, mes);
                    DateTime fechaMesConsulta = new DateTime(Convert.ToInt32(ejercicio), Convert.ToInt32(mes), 1);
                    fechaFinalConsulta = fechaMesConsulta.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    break;
                case 2: //Rango de fecha
                    if (fechaInicial == fechaFinal)
                    {
                        descripcionFiltro = fechaInicial != SessionApp.DateServer 
                            ? string.Format("DESDE {0} HASTA {1}", fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy")) 
                            : string.Format("HOY {0}", fechaInicial.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        descripcionFiltro = string.Format("DESDE {0} HASTA {1}", fechaInicial.ToString("dd/MM/yyyy"), fechaFinal.ToString("dd/MM/yyyy"));
                    }
                    

                    fechaInicialConsulta = fechaInicial.ToString("yyyy-MM-dd");
                    fechaFinalConsulta = fechaFinal.ToString("yyyy-MM-dd");

                    break;
            }

            //XtraMessageBox.Show(string.Format("{0} {1} {2}", descripcionFiltro, fechaInicialConsulta, fechaFinalConsulta));

            DescripcionFiltroFecha = descripcionFiltro;
            FechaInicialConsulta = fechaInicialConsulta;
            FechaFinalConsulta = fechaFinalConsulta;

            DialogResult = DialogResult.OK;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}