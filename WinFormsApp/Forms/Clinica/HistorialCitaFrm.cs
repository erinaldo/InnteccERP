using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.Design;

namespace WinFormsApp
{
    public partial class HistorialCitaFrm : DevExpress.XtraEditors.XtraForm
    {
        private static readonly Service Service = new Service();
        public VwProgramacioncitadet VwProgramacioncitadet { get; set; }

        public HistorialCitaFrm(VwProgramacioncitadet vwProgramacioncitadet)
        {
            InitializeComponent();
            VwProgramacioncitadet = vwProgramacioncitadet;

        }

        private void HistorialCitaFrm_Load(object sender, System.EventArgs e)
        {
            CargarDatosCita();
            CargarDetalleHistorial();
        }

        private void CargarDetalleHistorial()
        {
            Cursor = Cursors.WaitCursor;
            gvCitas.BeginUpdate();

            string condicion = string.Format("idprogramacioncitadet = {0}", VwProgramacioncitadet.Idprogramacioncitadet);
            gcCitas.DataSource = Service.GetAllVwProgramacioncitadethistorial(condicion, "fechahorahistorial");
            gvCitas.BestFitColumns(true);
            gvCitas.EndDataUpdate();
            Cursor = Cursors.Default;
        }

        private void CargarDatosCita()
        {
            iIdservicio.EditValue = VwProgramacioncitadet.Nombrearticulo;
            iCodigoarticulo.EditValue = VwProgramacioncitadet.Codigoarticulo;
            iIdmedico.EditValue = VwProgramacioncitadet.Razonsocialmedico;
            iFechaprogramacion.EditValue = VwProgramacioncitadet.Fechaprogramacion;
            iHoraprogramacion.EditValue = VwProgramacioncitadet.Horaprogramacion;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }


}