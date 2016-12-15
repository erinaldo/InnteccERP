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
    public partial class RequerimientoListadoFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();
        public VwRequerimientodet VwRequerimientodet { get; set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwRequerimiento VwRequerimientoSel { get; set; }
        public ParametrosRequerimiento Parametros { get; set; }
        public RequerimientoListadoFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
           

        }
        private void RequerimientoListadoFrm_Load(object sender, EventArgs e)
        {
            CargarRequerimientos();
            CargarReferencias();

           
        }
        private void CargarRequerimientos()
        {
            

            Cursor = Cursors.WaitCursor;
            gcConsulta.DataSource = null;
            gcDetalle.DataSource = null;
            gcConsulta.BeginUpdate();

            //idestadoreq = 2 (pendientes de aprobacion)

            string where = string.Format("idempresa = {0} ",
                SessionApp.EmpresaSel.Idempresa);

            var resul = Service.GetAllVwRequerimiento(where, "nombretipoformato,seriereq,numeroreq");
            gcConsulta.DataSource = resul;

            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();

            Cursor = Cursors.Default; 
        }
        private void CargarReferencias()
        {
           
        }

        private void gvConsulta_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwRequerimiento vwRequerimiento = (VwRequerimiento) gvConsulta.GetRow(e.FocusedRowHandle);
            if (vwRequerimiento != null)
            {
                VwRequerimientoSel = vwRequerimiento;
               
                CargarDetalle(vwRequerimiento.Idrequerimiento);
            }

        }
        private void CargarDetalle(int idRequerimiento)
        {
            string where = string.Format("idrequerimiento = '{0}'", idRequerimiento);
            gcDetalle.BeginUpdate();
            VwRequerimientodetList = Service.GetAllVwRequerimientodet(where, "numeroitem");
            gcDetalle.DataSource = VwRequerimientodetList;
           
            gvDetalle.BestFitColumns();
            gcDetalle.EndUpdate();

        }

        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwRequerimientodet vwRequerimientodet = (VwRequerimientodet) gvDetalle.GetFocusedRow();
            switch (e.Column.FieldName)
            {
                case "Cantidad":
                case "Preciounitario":                
                    var cantidad = vwRequerimientodet.Cantidad;
                    var precioUniatario = vwRequerimientodet.Preciounitario;
                    var importeTotal = Decimal.Round(cantidad * precioUniatario, 2);
                    vwRequerimientodet.Importetotal = importeTotal;
                    vwRequerimientodet.Itemseleccionado = vwRequerimientodet.Cantidad != 0;
                    vwRequerimientodet.DataEntityState = DataEntityState.Modified;
                    break;
                case "Itemseleccionado":
                    vwRequerimientodet.DataEntityState = DataEntityState.Modified;
                    gvDetalle.UpdateCurrentRow();                    
                    break;
            }
           
            
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            gvDetalle.PostEditor();
        }

        private void RequerimientoListadoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}