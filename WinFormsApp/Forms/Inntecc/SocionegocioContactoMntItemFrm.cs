using System;
using System.Drawing;
using System.Windows.Forms;
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
    public partial class SocionegocioContactoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        public Socionegociocontacto SocionegociocontactoMnt { get; set; }
        public SocionegocioContactoMntItemFrm(TipoMantenimiento tipoMnt, Socionegociocontacto socionegociocontacto)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            SocionegociocontactoMnt = socionegociocontacto;

         
        }
        private void SocionegocioContactoMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
        }
        private void TraerDatos()
        {
            iNombrecontacto.EditValue = SocionegociocontactoMnt.Nombrecontacto;
            iArea.EditValue = SocionegociocontactoMnt.Area;
            iDireccion.EditValue = SocionegociocontactoMnt.Direccion;
            iTelefono.EditValue = SocionegociocontactoMnt.Telefono;
            iMovil.EditValue = SocionegociocontactoMnt.Movil;
            iEmail.EditValue = SocionegociocontactoMnt.Email;
            iObservaciones.EditValue = SocionegociocontactoMnt.Observaciones;
            iCargo.EditValue = SocionegociocontactoMnt.Cargo;
			iFechanacimiento.EditValue = SocionegociocontactoMnt.Fechanacimiento;
			iFechaaniversario.EditValue = SocionegociocontactoMnt.Fechaaniversario;
			iNombreconyugue.EditValue = SocionegociocontactoMnt.Nombreconyugue;
			iFoto.EditValue = SocionegociocontactoMnt.Foto;
            iNumeroanexo.EditValue = SocionegociocontactoMnt.Numeroanexo;
        }
        private void CargarReferencias()
        {

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;                    

			        SocionegociocontactoMnt.Nombrecontacto = iNombrecontacto.Text.Trim();
			        SocionegociocontactoMnt.Area = iArea.Text.Trim();
			        SocionegociocontactoMnt.Direccion = iDireccion.Text.Trim();
			        SocionegociocontactoMnt.Telefono = iTelefono.Text.Trim();
			        SocionegociocontactoMnt.Movil = iMovil.Text.Trim();
			        SocionegociocontactoMnt.Email = iEmail.Text.Trim();
			        SocionegociocontactoMnt.Observaciones = iObservaciones.Text.Trim();
                    SocionegociocontactoMnt.Cargo = iCargo.Text.Trim();
			        SocionegociocontactoMnt.Fechanacimiento = (DateTime ?)iFechanacimiento.EditValue;
			        SocionegociocontactoMnt.Fechaaniversario = (DateTime ?)iFechaaniversario.EditValue;
			        SocionegociocontactoMnt.Nombreconyugue = iNombreconyugue.Text.Trim();
			        SocionegociocontactoMnt.Foto = (byte[])iFoto.EditValue;
                    SocionegociocontactoMnt.Numeroanexo = iNumeroanexo.Text.Trim();

                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

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
        private void SocionegocioContactoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmdAbriImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.tif;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                byte[] data = ByteImageConverter.ToByteArray(img, img.RawFormat);
                iFoto.EditValue = data;
            }
        }
    }
}