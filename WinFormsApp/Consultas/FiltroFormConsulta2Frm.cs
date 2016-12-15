using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;

namespace WinFormsApp
{
    public partial class FiltroFormConsulta2Frm : XtraForm
    {
        static readonly IService Service = new Service();
        public FiltroConsulta FiltroConsulta { get; set; }
        public FiltroFormConsulta2Frm(FiltroConsulta filtroConsulta)
        {
            InitializeComponent();
            FiltroConsulta = filtroConsulta;

            cboTipoFiltro.EditValue = FiltroConsulta.Tipo;
            cboEjercicio.EditValue = FiltroConsulta.Ejercicio;
            cboMes.EditValue = FiltroConsulta.Mes;
            deFechaInicial.EditValue = FiltroConsulta.FechaInicial;
            deFechaFinal.EditValue = FiltroConsulta.FechaFinal;


            EstablecerTipoDeFiltro();
        }
        private void EstablecerTipoDeFiltro()
        {
            cboMes.Enabled = false;
            deFechaInicial.Enabled = false;
            deFechaFinal.Enabled = false;            

            TipoFiltro tipoFiltroSel = (TipoFiltro)cboTipoFiltro.EditValue;
            switch (tipoFiltroSel)
            {
                case TipoFiltro.Todo: //todos
                    break;
                case TipoFiltro.Mes://Mes
                    cboMes.Enabled = true;
                    break;
                case TipoFiltro.Rango: //Rango de fecha
                    deFechaInicial.Enabled = true;
                    deFechaFinal.Enabled = true;
                    deFechaInicial.EditValue = FiltroConsulta.FechaInicial;
                    deFechaFinal.EditValue = FiltroConsulta.FechaFinal;
                    break;
            }
        }
        private void FiltroFormConsulta2Frm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            
        }
        private void CargarReferencias()
        {
            string whereEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            cboEjercicio.Properties.DataSource = Service.GetAllEjercicio(whereEmpresa, "anioejercicio");
            cboEjercicio.Properties.DisplayMember = "Anioejercicio";
            cboEjercicio.Properties.ValueMember = "Anioejercicio";


            //cboTipoFiltro.Properties.Items.AddRange(Enum.GetValues(typeof(TipoFiltro)));
            Dictionary<int, string> tipoFiltro = Enum.GetValues(typeof(TipoFiltro))
                .Cast<TipoFiltro>().ToDictionary(x => (int)x, x => x.ToString());

            cboTipoFiltro.Properties.DataSource = tipoFiltro;
            cboTipoFiltro.Properties.ValueMember = "Key";
            cboTipoFiltro.Properties.DisplayMember = "Value";

        }
        private void cboEjercicio_EditValueChanged(object sender, EventArgs e)
        {
            var idEjercicio = cboEjercicio.EditValue;
            if (idEjercicio != null)
            {
                CargarMeses();
            }
        }
        private void CargarMeses()
        {
            string whereEjercicio = string.Format("idempresa = {0} and anioejercicio = {1}",
            SessionApp.EmpresaSel.Idempresa, cboEjercicio.EditValue);
            cboMes.Properties.DataSource = Service.GetAllVwPeriodo(whereEjercicio, "mes");
            cboMes.Properties.DisplayMember = "Nombremes";
            cboMes.Properties.ValueMember = "Mes";

            //string mesActual = UsuarioAutenticado.FechaServidor.Month.ToString("D2");
            //cboMes.EditValue = mesActual;
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

            TipoFiltro tipoFiltroSel = (TipoFiltro)cboTipoFiltro.EditValue;

            switch (tipoFiltroSel)
            {
                case TipoFiltro.Todo: //todos
                    descripcionFiltro = string.Format("TODO DEL EJERCICIO {0}", ejercicio);
                    fechaInicialConsulta = string.Format("{0}-01-01", ejercicio);
                    DateTime mesFinalEjercicio = new DateTime(Convert.ToInt32(ejercicio), 12, 1);
                    fechaFinalConsulta = mesFinalEjercicio.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    break;
                case TipoFiltro.Mes: //Mes
                    descripcionFiltro = string.Format("EJERCICIO {0} MES {1}", ejercicio, mes);
                    fechaInicialConsulta = string.Format("{0}-{1}-01", ejercicio, mes);
                    DateTime fechaMesConsulta = new DateTime(Convert.ToInt32(ejercicio), Convert.ToInt32(mes), 1);
                    fechaFinalConsulta = fechaMesConsulta.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                    break;
                case TipoFiltro.Rango: //Rango de fecha
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

            FiltroConsulta filtroConsultaSel = new FiltroConsulta();
            filtroConsultaSel.Tipo = (TipoFiltro)cboTipoFiltro.EditValue;
            filtroConsultaSel.Ejercicio = Convert.ToInt32(ejercicio);
            filtroConsultaSel.Mes = mes;
            filtroConsultaSel.FechaInicial = Convert.ToDateTime(fechaInicialConsulta);
            filtroConsultaSel.FechaFinal = Convert.ToDateTime(fechaFinalConsulta);
            filtroConsultaSel.DescripcionFiltro = descripcionFiltro;

            FiltroConsulta = filtroConsultaSel;

            DialogResult = DialogResult.OK;
        }
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void cboTipoFiltro_EditValueChanged(object sender, EventArgs e)
        {
            EstablecerTipoDeFiltro();
            var idTipoFiltro = cboTipoFiltro.EditValue;
            var idEjercicio = cboEjercicio.EditValue;
            if (idTipoFiltro != null && idEjercicio != null)
            {
                CargarMeses();
            }
        }

    }
}