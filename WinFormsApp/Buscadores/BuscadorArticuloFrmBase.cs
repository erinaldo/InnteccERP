using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorArticuloFrmBase : XtraForm
    {
        public VwArticulo VwArticuloSel { get; set; }

        static readonly IService Service = new Service();

        private readonly string _criterioArticuloServicio;

        const string NombrePropiedadTipoArticulo = "idtipoarticulo";
        public BuscadorArticuloFrmBase()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        public BuscadorArticuloFrmBase(bool buscarSoloItemServicio)
        {
            InitializeComponent();
            _criterioArticuloServicio = buscarSoloItemServicio ? string.Format(" and {0} = 4 ", NombrePropiedadTipoArticulo) : " and " + NombrePropiedadTipoArticulo + " <> 4";
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            VwArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarArticuloPorCodigo()
        {
            Cursor = Cursors.WaitCursor;
            string wherecodigo = string.Format("codigoarticulo LIKE '%{0}%' {1}", txtCodigo.Text.Trim(), _criterioArticuloServicio);
            gcArticulo.DataSource = Service.GetAllVwArticulo(wherecodigo, "nombrearticulo");
            Cursor = Cursors.Default;
        }

        private void BuscarArticuloPorNombre()
        {
            Cursor = Cursors.WaitCursor;
            string nombreArticuloUnSoloEspacio =  Regex.Replace(txtDatoABuscar.Text.Trim(), @"\s+", " ").Trim();
            string[] palabrasArticulo = nombreArticuloUnSoloEspacio.Split(' ');
            string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " nombrearticulo||codigoproveedor LIKE '%" + palabra + "%' AND ");
            //foreach (string palabra in palabrasArticulo)
            //{
            //    whereDinamico = whereDinamico + " nombrearticulo LIKE '%" + palabra + "%' AND ";
            //}  
            whereDinamico = whereDinamico.Substring(0, whereDinamico.Length-5);
            gcArticulo.DataSource = Service.GetAllVwArticulo(whereDinamico + _criterioArticuloServicio, "nombrearticulo");
            Cursor = Cursors.Default;
        }

        private void txtDatoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) (Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorNombre();
            gvArticulo.Focus();
        }

        private void gvSocioNegocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            RetornarArticuloSeleccionado();
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }

        private void RetornarArticuloSeleccionado()
        {
            if (gvArticulo.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            VwArticuloSel = (VwArticulo) gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            ArticuloMntFrm articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            articuloMntFrm.ShowDialog();

            if (articuloMntFrm.DialogResult != DialogResult.OK || articuloMntFrm.IdEntidadMnt <= 0) return;

            VwArticuloSel = Service.GetVwArticulo(articuloMntFrm.IdEntidadMnt);
            DialogResult = DialogResult.OK;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorCodigo();
            gvArticulo.Focus();
        }

        private void gvArticulo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwArticulo vwArticuloSel = (VwArticulo)gvArticulo.GetFocusedRow();
            if (vwArticuloSel != null)
            {
                reCaracteristicas.Text = vwArticuloSel.Caracteristicas;
            }
            else
            {
                reCaracteristicas.Text = string.Empty;
            }
        }

        private void gvArticulo_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvArticulo_CellDoubleClick;
        }

        private void gvArticulo_CellDoubleClick(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }


    }
}