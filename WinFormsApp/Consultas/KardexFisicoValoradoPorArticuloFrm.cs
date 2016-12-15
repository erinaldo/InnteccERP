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
    public partial class KardexFisicoValoradoPorArticuloFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        readonly HelperDb _helperDb = new HelperDb();
        public KardexFisicoValoradoPorArticuloFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private List<Empresa> EmpresaList { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }
        private void CargarReferencias()
        {
            EmpresaList = Service.GetAllEmpresa("razonsocial");
            iIdempresa.Properties.DataSource = EmpresaList;
            iIdempresa.Properties.DisplayMember = "Razonsocial";
            iIdempresa.Properties.ValueMember = "Idempresa";
            iIdempresa.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Validaciones()) return;

           
            int idArticulo = (int)iIdarticulo.EditValue;


            CargarKardexFisicoValorado(idArticulo, (int)iIdempresa.EditValue);
            

        }
        private bool Validaciones()
        {
            var fechaInicial = iFechaInicio.EditValue;
            if (fechaInicial == null)
            {
                XtraMessageBox.Show("Seleccione la fecha inicial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iFechaInicio.Select();
                return true;
            }

            var fechaFinal = iFechaFinal.EditValue;
            if (fechaFinal == null)
            {
                XtraMessageBox.Show("Seleccione la fecha final", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iFechaFinal.Select();
                return true;
            }

            int idArticulo = (int) iIdarticulo.EditValue;
            if (idArticulo == 0)
            {
                XtraMessageBox.Show("Seleccione el producto.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return true;
            }

            int idAlmacen = (int) iIdempresa.EditValue;
            if (idAlmacen == 0)
            {
                XtraMessageBox.Show("Seleccione el almacen.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return true;
            }

            
            return false;
        }
        private void CargarKardexFisicoValorado(int idArticulo, int idEmpresa)
        {
            const string sqlQuery = "almacen.fnkardexfisicovalorado";
            object[] parametros =
            {
                idArticulo,
                (DateTime) iFechaInicio.EditValue,
                (DateTime) iFechaFinal.EditValue,
                idEmpresa
            };


            DataTable dt = _helperDb.ExecuteStoreProcedure(sqlQuery, parametros);
            gcKardex.DataSource = dt;
        }
        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
                    break;
            }
        }
        private void BuscarArticulo()
        {
            BuscadorArticuloInventarioFrm buscadorArticuloInventarioFrm = new BuscadorArticuloInventarioFrm();
            buscadorArticuloInventarioFrm.ShowDialog();
            if (buscadorArticuloInventarioFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloInventarioFrm.VwArticuloSel != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Idarticulo;
                iUnidadmedida.EditValue = buscadorArticuloInventarioFrm.VwArticuloSel.Abrunidadmedida;
            }
        }
        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;
            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;
            VwArticulo articulosel = Service.GetVwArticulo(((int)idArticuloSel));
            if (articulosel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = articulosel.Codigoarticulo;
                beArticulo.Text = articulosel.Nombrearticulo.Trim();
            }
            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
            }
        }
        private void KardexFisicoValoradoPorArticuloFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            ValoresPorDefecto();
            EstablecerFechasIniciales();
            beArticulo.Select();
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
        private void ValoresPorDefecto()
        {
            iIdempresa.EditValue = SessionApp.EmpresaSel.Idempresa;
            iFechaFinal.EditValue = DateTime.Now; //new DateTime(2015,10,31); //;
        }
    }
}