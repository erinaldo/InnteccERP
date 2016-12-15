using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Utilities;

namespace WinFormsApp
{
    public partial class SaldosFisicosRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        private List<Articuloclasificacion> ArticuloclasificacionList { get; set; }
        private List<Marca> MarcaList { get; set; }
        public SaldosFisicosRpFrm()
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void Reporte()
        {
            string nombreAlmacen = iIdalmacen.Text.Trim();
            DateTime fechaInicio = (DateTime)iFechaInicio.EditValue;
            DateTime fechaFinal = (DateTime)iFechaFinal.EditValue;


            var idAlmacen = iIdalmacen.EditValue;
            if (idAlmacen == null)
            {
                XtraMessageBox.Show("Seleccione el almacén", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdalmacen.Select();
                return;
            }

            const string sqlQuery = "reportes.fn_saldosfisicos";
            object[] parametrosConsulta = {
                fechaInicio,
                fechaFinal,
                (int)iIdalmacen.EditValue,
                rgTipoReporte.SelectedIndex,
                (int?)iIdarticuloclasificacion.EditValue,
                (int?)iIdmarca.EditValue,
            };

            DataSet ds = new DataSet
            {                
                DataSetName = "rp"
            };


            DataTable dtEmpresa = HelperDb.SqlConsulta("inntecc.vwsucursal",string.Format("idsucursal = {0}",SessionApp.SucursalSel.Idsucursal),null,"*");
            DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);


            DataTable dtSaldos = dt.Copy();
            dtSaldos.TableName = "saldos";

            DataTable dtEmpresaSel = dtEmpresa.Copy();
            dtEmpresaSel.TableName = "empresa";

            ds.Tables.Add(dtSaldos);
            ds.Tables.Add(dtEmpresaSel);

            string fileNameReport = "saldosfisicos.repx";
            string filaName = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Almacen\\{0}", fileNameReport));

            //Parametros
            object[] parametrosReporte = {                
                fechaInicio,
                fechaFinal,
                nombreAlmacen
            };

            ReportHelper3 reportHelper3 = new ReportHelper3(filaName, ds, parametrosReporte,null);
            reportHelper3.ShowDialog();

        }    

        private void SaldosFisicosRpFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            //iFechaInicio.EditValue = UsuarioAutenticado.FechaServidor;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iIdalmacen.EditValue = SessionApp.SucursalSel.Idalmacendefecto;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            rgOpcionReporte.SelectedIndex = 0;
            EstablecerFechasIniciales();
            rgTipoReporte.SelectedIndex = 1;
        }

        private void CargarReferencias()
        {
            string whereAlmacen = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdalmacen.Properties.DataSource = Service.GetAllVwAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            ArticuloclasificacionList = Service.GetAllArticuloclasificacion("Nombreclasificacion");
            iIdarticuloclasificacion.Properties.DataSource = ArticuloclasificacionList;
            iIdarticuloclasificacion.Properties.DisplayMember = "Nombreclasificacion";
            iIdarticuloclasificacion.Properties.ValueMember = "Idarticuloclasificacion";
            iIdarticuloclasificacion.Properties.BestFitMode = BestFitMode.BestFit;

            MarcaList = Service.GetAllMarca("nombremarca");
            iIdmarca.Properties.DataSource = MarcaList;
            iIdmarca.Properties.DisplayMember = "Nombremarca";
            iIdmarca.Properties.ValueMember = "Idmarca";
            iIdmarca.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void rgOpcionReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rgOpcionReporte.SelectedIndex)
            {
                case 0: //Todos los reportes
                    //iIdarticuloclasificacion.Enabled = false;
                    //iIdmarca.Enabled = false;
                    chkClasificacion.Enabled = false;
                    chkMarca.Enabled = false;

                    iIdarticuloclasificacion.EditValue = null;
                    iIdmarca.EditValue = null;

                    chkClasificacion.Checked = false;
                    chkMarca.Checked = false;


                    break;
                case 1: //Agrupado en 
                    //iIdarticuloclasificacion.Enabled = true;
                    //iIdmarca.Enabled = true;
                    chkClasificacion.Enabled = true;
                    chkMarca.Enabled = true;
                    break;
            }
        }

        private void chkClasificacion_CheckedChanged(object sender, EventArgs e)
        {
            iIdarticuloclasificacion.Enabled = chkClasificacion.Checked;
            if (!chkClasificacion.Checked)
            {
                iIdarticuloclasificacion.EditValue = null;
            }
        }

        private void chkMarca_CheckedChanged(object sender, EventArgs e)
        {
            iIdmarca.Enabled = chkMarca.Checked;
            if (!chkMarca.Checked)
            {
                iIdmarca.EditValue = null;
            }
        }

        private void EstablecerFechasIniciales()
        {
            string condicion = string.Format("idsucursal = '{0}' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";
            var inventarioList = Service.GetAllInventario(condicion, orden);
            if (inventarioList != null)
            {
                Inventario inventario = inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    iFechaInicio.EditValue = inventario.Fechainventario;
                }
            }
        }
    }
}