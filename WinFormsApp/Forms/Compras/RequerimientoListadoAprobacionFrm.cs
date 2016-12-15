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
    public partial class RequerimientoListadoAprobacionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private static readonly IService Service = new Service();
        public VwRequerimientodet VwRequerimientodet { get; set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        private List<VwSucursal> VwSucursalList { get; set; }
        public RequerimientoListadoAprobacionFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }
        private void RequerimientoListadoAprobacionFrm_Load(object sender, EventArgs e)
        {
            CargarSucursales();
        }
        private void CargarSucursales()
        {
            VwSucursalList = Service.GetAllVwSucursal("Nombresucursal");
            VwSucursal vwSucursalTodos = new VwSucursal
            {
                Idsucursal = 0,
                Nombresucursal = "(TODAS LAS SUCURSALES)",
                Codigosucursal = "000"

            };

            VwSucursalList.Add(vwSucursalTodos);

            iIdsucursal.Properties.DataSource = VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //iIdsucursal.EditValue = UsuarioAutenticado.SucursalSel.Idsucursal;
            iIdsucursal.EditValue = 0;
            cboEstado.SelectedIndex = 0;
            
            //ConsultarRequerimientos();
        }
        private void ConsultarRequerimientos()
        {
            var idSucursalSel = iIdsucursal.EditValue;

            //if (idSucursalSel == null)
            //{
            //    XtraMessageBox.Show("Seleccione una sucursal", "Atención", MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    iIdsucursal.Select();
            //    return;
            //}

            string whereEstado = string.Empty;

            string whereSucursal = (int) idSucursalSel > 0
                ? string.Format("and idsucursal = {0}", (int) idSucursalSel)
                : string.Empty;

            //Console.WriteLine(whereSucursal);

            switch (cboEstado.SelectedIndex)
            {
                case 0: //Pendiente de aprobaccion 
                        //2:pendiente de aprobacion, 5: aprobacion parcial

                    whereEstado = string.Format("idestadoreq in(2,5) {0} and idempleadoaprueba = {1} ",
                        whereSucursal,
                        (SessionApp.EmpleadoSel == null ? 0 : SessionApp.EmpleadoSel.Idempleado));
                    break;
                case 1: //Aprobados

                    whereEstado = string.Format("idestadoreq = 3 {0} and idempleadoaprueba = {1} ",
                        whereSucursal,
                        (SessionApp.EmpleadoSel == null ? 0 : SessionApp.EmpleadoSel.Idempleado));

                    break;
            }

            gcConsulta.BeginUpdate();
            //
            gcConsulta.DataSource = Service.GetAllVwRequerimientosaaprobar(whereEstado,
                "nombrearea,nombreproyecto,idpersona");
            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();

        }
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información verique.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;

            }
            return true;
        }
        private void RequerimientoListadoAprobacionFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) (Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ConsultarRequerimientos();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Continuar();
        }
        private void Continuar()
        {
            if (!Validaciones())
            {
                return;
            }

            VwRequerimientosaaprobar itemSel = (VwRequerimientosaaprobar)gvConsulta.GetFocusedRow();

            ParametrosRequerimiento parametros = new ParametrosRequerimiento
            {
                IdSucursal = itemSel.Idsucursal,
                IdArea = itemSel.Idarea,
                IdProyecto = itemSel.Idproyecto,
                IdEmpleado = itemSel.Idempleado,
                IdEstadoReq = itemSel.Idestadoreq,
                TipoConsultaReq = cboEstado.SelectedIndex,
                IdEmpleadoLogeado = SessionApp.EmpleadoSel.Idempleado,
                Idtipodocmov = 3, //Requerimiento
                Idcptooperacion = 0

            };

            RequerimientoAprobacionFrm requerimientoAprobacionFrm = new RequerimientoAprobacionFrm(parametros);
            requerimientoAprobacionFrm.ShowDialog();
            ConsultarRequerimientos();
        }
        private void cboEstado_EditValueChanged(object sender, EventArgs e)
        {
            ConsultarRequerimientos();
        }
        private void gcConsulta_DoubleClick(object sender, EventArgs e)
        {
            Continuar();
        }
    }
    public class ParametrosRequerimiento
    {
        public int IdSucursal { get; set; }
        public int IdArea { get; set; }
        public int IdProyecto { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEstadoReq { get; set; }
        public int TipoConsultaReq { get; set; }
        public int IdEmpleadoLogeado { get; set; }
        public int Idtipodocmov { get; set; }
        public int Idcptooperacion { get; set; }

    }
}