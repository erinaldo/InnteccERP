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
    public partial class ProgramacionItemDuplicarFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwProgramacioncita VwProgramacioncita { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public ProgramacionItemDuplicarFrm(VwProgramacioncita vwProgramacioncita)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwProgramacioncita = vwProgramacioncita;


        }

        private void ProgramacionItemDuplicarFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            TraerDatos();
            ValoresPorDefecto();
        }

        private void ValoresPorDefecto()
        {
            iHasta.EditValue = SessionApp.DateServer;
        }

        private void TraerDatos()
        {
            //ProgramacioncitaMnt = Service.GetProgramacioncita(IdEntidadMnt);

            iIdservicio.EditValue = VwProgramacioncita.Idservicio;
            iIdmedico.EditValue = VwProgramacioncita.Idmedico;
            iFechaprogramacion.EditValue = VwProgramacioncita.Fechaprogramacion;
            iActivo.EditValue = VwProgramacioncita.Activo;
            rIdsucursal.EditValue = VwProgramacioncita.Idsucursal;

        }

        private void CargarReferencias()
        {
            iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdmedico.Properties.DisplayMember = "Razonsocial";
            iIdmedico.Properties.ValueMember = "Idempleado";
            iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdmedico.Properties.DisplayMember = "Razonsocial";
            iIdmedico.Properties.ValueMember = "Idempleado";
            iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereServicio = "esserviciomedico = '1'";
            VwArticuloList = Service.GetAllVwArticulo(whereServicio, "Nombrearticulo");
            iIdservicio.Properties.DataSource = VwArticuloList;
            iIdservicio.Properties.DisplayMember = "Nombrearticulo";
            iIdservicio.Properties.ValueMember = "Idarticulo";
            iIdservicio.Properties.BestFitMode = BestFitMode.BestFit;

        }



        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            Programacioncita programacioncitaBase = Service.GetProgramacioncita(x => x.Idprogramacioncita == VwProgramacioncita.Idprogramacioncita);
            int idProgramacioncitaBase = programacioncitaBase.Idprogramacioncita;

            DateTime desde = ((DateTime)iFechaprogramacion.EditValue).AddDays(1);
            DateTime hasta = (DateTime)iHasta.EditValue;

            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    Cursor = Cursors.WaitCursor;

                    for (DateTime fechaProceso = desde; fechaProceso <= hasta; fechaProceso = fechaProceso.AddDays(1))
                    {
                        DateTime fecha = fechaProceso;

                        switch (fecha.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                if (iDomingo.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase,fecha,fechaProceso,idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Monday:
                                if (iLunes.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Tuesday:
                                if (iMartes.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Wednesday:
                                if (iMiercoles.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Thursday:
                                if (iJueves.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Friday:
                                if (iVierne.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                            case DayOfWeek.Saturday:
                                if (iSabado.Checked)
                                {
                                    DuplicarProgramacion(programacioncitaBase, fecha, fechaProceso, idProgramacioncitaBase);
                                }
                                break;
                        }
                    }

                    Cursor = Cursors.Default;

                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void DuplicarProgramacion (Programacioncita programacioncitaBase, DateTime fecha, DateTime fechaProceso, int idProgramacioncitaBase)
        {
            Programacioncita programacioncitaVerificacion =
                Service.GetProgramacioncita(
                    x =>
                        x.Idservicio == programacioncitaBase.Idservicio &&
                        x.Idmedico == programacioncitaBase.Idmedico &&
                        x.Fechaprogramacion == fecha &&
                        x.Idsucursal == programacioncitaBase.Idsucursal);

            if (programacioncitaVerificacion != null)
            {
                return;
            }


            Programacioncita programacioncita = new Programacioncita();
            programacioncita.Idprogramacioncita = 0;
            programacioncita.Idservicio = (int)iIdservicio.EditValue;
            programacioncita.Idmedico = (int)iIdmedico.EditValue;
            programacioncita.Fechaprogramacion = fechaProceso;
            programacioncita.Activo = (bool)iActivo.EditValue;
            programacioncita.Idsucursal = (int)rIdsucursal.EditValue;


            int idprogramacioncitaNew = Service.SaveProgramacioncita(programacioncita);
            if (idprogramacioncitaNew > 0)
            {
                programacioncita.Idprogramacioncita = idprogramacioncitaNew;


                List<Programacioncitadet> programacioncitadetList = Service.GetAllProgramacioncitadet(x => x.Idprogramacioncita == idProgramacioncitaBase);
                foreach (Programacioncitadet item in programacioncitadetList)
                {
                    item.Idprogramacioncita = idprogramacioncitaNew;
                    Service.SaveProgramacioncitadet(item);
                }
            }
        }

        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ProgramacionItemDuplicarFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIdservicio_EditValueChanged(object sender, EventArgs e)
        {
            var idServicio = iIdservicio.EditValue;
            if (idServicio != null)
            {
                VwArticulo vwArticuloSel = VwArticuloList.FirstOrDefault(x => x.Idarticulo == (int)idServicio);
                if (vwArticuloSel != null)
                {
                    iCodigoarticulo.EditValue = vwArticuloSel.Codigoarticulo;
                }
            }

        }
    }
}