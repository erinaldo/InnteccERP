using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ConfiguracionempleadoFrm : XtraForm
    {
        static readonly IService Service = new Service();
        public List<VwEmpleadoarea> VwEmpleadoareaList { get; set; }
        public List<VwEmpleadoareaproyecto> VwEmpleadoareaproyectoList { get; set; }
        public ConfiguracionempleadoFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }
        private void ConfiguracionempleadoFrm_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarDatosReferencias();            
        }
        private void CargarDatosReferencias()
        {

            string whereArea = string.Format("idempresa = '{0}'", SessionApp.EmpresaSel.Idempresa);
            iIdarea.Properties.DataSource = Service.GetAllVwArea(whereArea,"Nombrearea");
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            string whereProj = string.Format("idempresa = '{0}'", SessionApp.EmpresaSel.Idempresa);
            iIdproyecto.Properties.DataSource = Service.GetAllVwProyecto(whereProj,"codigoproyecto");
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void CargarEmpleados()
        {
            string whereSucursalActual = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado(whereSucursalActual,"razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void ConfiguracionempleadoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CargarAreas()
        {
            string where = string.Format("idempleado = {0}", (int) iIdempleado.EditValue);
            VwEmpleadoareaList = Service.GetAllVwEmpleadoarea(where, "codigoarea");
            gcArea.BeginUpdate();
            gcArea.DataSource = VwEmpleadoareaList;            
            gcArea.EndUpdate();
            gvArea.BestFitColumns();
        }
        private void CargarProyectos()
        {
            gcProyecto.DataSource = null;

            VwEmpleadoarea vwEmpleadoareaSel = (VwEmpleadoarea)gvArea.GetFocusedRow();
            if (vwEmpleadoareaSel != null)
            {
                string where = string.Format("idempleadoarea = {0}", vwEmpleadoareaSel.Idempleadoarea);
                VwEmpleadoareaproyectoList = Service.GetAllVwEmpleadoareaproyecto(where, "codigoarea");
                gcProyecto.BeginUpdate();
                gcProyecto.DataSource = VwEmpleadoareaproyectoList;
                gcProyecto.EndUpdate();
                gvProyecto.BestFitColumns(true);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var idEmpladoSel = iIdempleado.EditValue;
            if (idEmpladoSel == null)
            {
                XtraMessageBox.Show("Seleccione el empleado", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                iIdempleado.Focus();
                return;
            }

            var idArea =  iIdarea.EditValue;

            if (idArea == null)
            {
                XtraMessageBox.Show("Seleccione el Area", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                iIdarea.Focus();
                return;
            }

            int countEmpleadoArea = VwEmpleadoareaList.Count(x => x.Idempleado == (int) idEmpladoSel && x.Idarea == (int) idArea);
            if (countEmpleadoArea > 0)
            {
                XtraMessageBox.Show("Ya se agregó el área seleccionada","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            Empleadoarea empleadoarea = new Empleadoarea()
            {
                Idempleado = (int)iIdempleado.EditValue,
                Idarea = (int)iIdarea.EditValue
            };

            int idGenerado = Service.SaveEmpleadoarea(empleadoarea);

            if (idGenerado > 0)
            {
                CargarAreas();
                if (gvArea.RowCount > 0)
                {
                    gvArea.BeginDataUpdate();
                    var rowHandle = gvArea.LocateByValue("Idempleadoarea", idGenerado);
                    if (rowHandle == GridControl.InvalidRowHandle)
                    {
                        gvArea.EndDataUpdate();
                        return;
                    }
                    gvArea.EndDataUpdate();
                    gvArea.FocusedRowHandle = rowHandle;
                }
            }


        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gvArea.RowCount == 0)
            {
                return;
            }

            var itemDet = (VwEmpleadoarea)gvArea.GetFocusedRow();

            int cntReferenciasProyecto = VwEmpleadoareaproyectoList.Count(x => x.Idempleadoarea == itemDet.Idempleadoarea);
            if (cntReferenciasProyecto > 0)
            {
                XtraMessageBox.Show("El item tiene referencias, verifique.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DialogResult.No == XtraMessageBox.Show(Resources.msgEliminarRegistro,
                Resources.titPregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)) return;

            
            if (itemDet.Idempleadoarea <= 0) return;
            Service.DeleteEmpleadoarea(itemDet.Idempleadoarea);
            CargarAreas();
        }
        private void btnAddProyecto_Click(object sender, EventArgs e)
        {
            var idEmpladoSel = iIdempleado.EditValue;

            if (idEmpladoSel == null)
            {
                XtraMessageBox.Show("Seleccione el empleado", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                iIdempleado.Focus();
                return;
            }

            VwEmpleadoarea vwEmpleadoareaSel = (VwEmpleadoarea) gvArea.GetFocusedRow();


            if (vwEmpleadoareaSel == null)
            {
                XtraMessageBox.Show("Seleccione el Area", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                gvArea.Focus();
                return;
            }

            var idProyecto = iIdproyecto.EditValue;

            if (idProyecto == null)
            {
                XtraMessageBox.Show("Seleccione el Proyecto", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                iIdproyecto.Focus();
                return;
            }

            int countEmpleadoAreaProyecto = VwEmpleadoareaproyectoList.Count(x => x.Idempleadoarea == vwEmpleadoareaSel.Idempleadoarea && x.Idproyecto == (int)idProyecto);
            if (countEmpleadoAreaProyecto > 0)
            {
                XtraMessageBox.Show("Ya se agregó el proyecto seleccionado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Empleadoareaproyecto empleadoareaproyecto = new Empleadoareaproyecto()
            {
                Idempleadoarea = vwEmpleadoareaSel.Idempleadoarea,
                Idproyecto = (int)iIdproyecto.EditValue
            };

            int idGenerado = Service.SaveEmpleadoareaproyecto(empleadoareaproyecto);

            if (idGenerado <= 0) return;

            CargarProyectos();

            if (gvProyecto.RowCount > 0)
            {
                gvProyecto.BeginDataUpdate();
                var rowHandle = gvProyecto.LocateByValue("Idempleadoareaproyecto", idGenerado);
                if (rowHandle == GridControl.InvalidRowHandle)
                {
                    gvProyecto.EndDataUpdate();
                    return;
                }
                gvProyecto.EndDataUpdate();
                gvProyecto.FocusedRowHandle = rowHandle;
            }
        }
        private void btnDelProyecto_Click(object sender, EventArgs e)
        {
            if (gvProyecto.RowCount == 0)
            {
                return;
            }

            if (DialogResult.No == XtraMessageBox.Show(Resources.msgEliminarRegistro,
            Resources.titPregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1)) return;

            var itemDet = (VwEmpleadoareaproyecto)gvProyecto.GetFocusedRow();
            if (itemDet.Idempleadoareaproyecto <= 0) return;
            Service.DeleteEmpleadoareaproyecto(itemDet.Idempleadoareaproyecto);
            CargarProyectos();
        }
        private void gvArea_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarProyectos();
        }
        private void iIdempleado_EditValueChanged(object sender, EventArgs e)
        {
            gcArea.DataSource = null;
            gcProyecto.DataSource = null;

            var idEmpladoSel = iIdempleado.EditValue;
            if (idEmpladoSel != null)
            {
                //XtraMessageBox.Show("Seleccione el empleado", "Atención", MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);
                //return;
                CargarAreas();
            }

           
        }
    }

}