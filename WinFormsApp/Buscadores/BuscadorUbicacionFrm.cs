using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorUbicacionFrm : XtraForm
    {
        public VwUbicacion VwUbicacionSel { get; set; }

        static readonly IService Service = new Service();
        public int IdAlmacen { get; set; }
        public BuscadorUbicacionFrm(int idAlmacen)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            IdAlmacen = idAlmacen;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            VwUbicacionSel = null;
            DialogResult = DialogResult.Cancel;
        }
        private void BuscarUbicacionPorNombre()
        {
            gcUbicacion.BeginUpdate();
            string nombreUbicacionUnSoloEspacio =  Regex.Replace(txtDatoABuscar.Text.Trim(), @"\s+", " ").Trim();
            string[] palabrasArticulo = nombreUbicacionUnSoloEspacio.Split(' ');
            string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " nombreubicacion LIKE '%" + palabra + "%' AND "); 
            whereDinamico = string.Format("{0} and idalmacen = {1}",whereDinamico.Substring(0, whereDinamico.Length - 5),IdAlmacen);
            gcUbicacion.DataSource = Service.GetAllVwUbicacion(whereDinamico, "nombreubicacion");
            gcUbicacion.EndUpdate();
            gvUbicacion.BestFitColumns();
        }
        private void txtDatoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) (Keys.Enter)) return;
            e.Handled = true;
            BuscarUbicacionPorNombre();
            gvUbicacion.Focus();
        }
        private void gvSocioNegocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            VwUbicacionSel = (VwUbicacion)gvUbicacion.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }
        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            VwUbicacionSel = (VwUbicacion)gvUbicacion.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (gvUbicacion.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            VwUbicacionSel = (VwUbicacion)gvUbicacion.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }
        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            ArticuloMntFrm articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            articuloMntFrm.ShowDialog();

            if (articuloMntFrm.DialogResult != DialogResult.OK || articuloMntFrm.IdEntidadMnt <= 0) return;

            VwUbicacionSel = Service.GetVwUbicacion(articuloMntFrm.IdEntidadMnt);
            DialogResult = DialogResult.OK;
        }
    }
}