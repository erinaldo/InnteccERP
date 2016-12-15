using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;
using CorpTeg.Utilidades;
using DevExpress.XtraEditors;
using Tesseract;
using Utilities;

namespace WinFormsApp
{

    public partial class ConsultaReniecFrm : XtraForm
    {
        private ConsultaReniec ConsultaReniec { get; set; }
        public Persona PersonaReniec { get; set; }
        public string Dni { get; set; }

        IntRange red = new IntRange(0, 255);
        IntRange green = new IntRange(0, 255);
        IntRange blue = new IntRange(0, 255);

        public ConsultaReniecFrm()
        {
            InitializeComponent();
            ConsultaReniec = new ConsultaReniec();
            ConsultaReniec.Inicializar();

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void CargarReferencias()
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            
            if (iDni.Text.Length == 0)
            {
                XtraMessageBox.Show("Ingrese un N° DNI valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iDni.Select();
                return;
            }

            if (PersonaReniec != null)
            {
                DialogResult = DialogResult.OK;
                Dni = iDni.Text.Trim();
            }
        }

        private void btnRefrescarCaptcha_Click(object sender, EventArgs e)
        {
            ObtenerCaptcha();
            AplicacionFiltros();
            LeerCaptchaReniec();
        }

        private void ConsultaReniecFrm_Load(object sender, EventArgs e)
        {
            if (ConsultaReniec.EstadoConsulta  == EstadoConsulta.ErrorConexion)
            {
                XtraMessageBox.Show("Error en la conexion al servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ObtenerCaptcha();
            AplicacionFiltros();
            LeerCaptchaReniec();

            CargarReferencias();
            //iCaptcha.Select();
            iDni.Select();
        }

        private void AplicacionFiltros()
        {
            Cursor = Cursors.WaitCursor;
            Bitmap bmp = new Bitmap(peCaptcha.Image);
            FiltroInvertir(bmp);
            ColorFiltros();
            Bitmap bmp1 = new Bitmap(peCaptcha.Image);
            FiltroInvertir(bmp1);
            Bitmap bmp2 = new Bitmap(peCaptcha.Image);
            FiltroSharpen(bmp2);
            Cursor = Cursors.Default;
        }
        private void FiltroInvertir(Bitmap bmp)
        {
            IFilter filtro = new Invert();
            Bitmap xImage = filtro.Apply(bmp);
            peCaptcha.Image = xImage;
        }
        private void ColorFiltros()
        {
            //Red Min - MAX
            red.Min = Math.Min(red.Max, byte.Parse("229"));
            red.Max = Math.Max(red.Min, byte.Parse("255"));
            //Verde Min - MAX
            green.Min = Math.Min(green.Max, byte.Parse("0"));
            green.Max = Math.Max(green.Min, byte.Parse("255"));
            //Azul Min - MAX
            blue.Min = Math.Min(blue.Max, byte.Parse("0"));
            blue.Max = Math.Max(blue.Min, byte.Parse("130"));
            ActualizarFiltro();
        }
        private void ActualizarFiltro()
        {
            ColorFiltering filtroColor = new ColorFiltering();
            filtroColor.Red = red;
            filtroColor.Green = green;
            filtroColor.Blue = blue;
            IFilter filtro = filtroColor;
            Bitmap bmp = new Bitmap(peCaptcha.Image);
            Bitmap xImage = filtro.Apply(bmp);
            peCaptcha.Image = xImage;
        }
        private void FiltroSharpen(Bitmap bmp)
        {
            IFilter filtro = new Sharpen();
            Bitmap xImage = filtro.Apply(bmp);
            peCaptcha.Image = xImage;
        }

        private void LeerCaptchaReniec()
        {
            Cursor = Cursors.WaitCursor;

            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var image = new Bitmap(peCaptcha.Image))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            //var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                            page.GetMeanConfidence();
                            string captchaTexto = page.GetText();
                            char[] eliminarChars = { '\n', ' ' };
                            captchaTexto = captchaTexto.TrimEnd(eliminarChars);
                            captchaTexto = captchaTexto.Replace(" ", string.Empty);
                            captchaTexto = Regex.Replace(captchaTexto, "[^a-zA-Z0-9]+", string.Empty);
                            if (captchaTexto != string.Empty & captchaTexto.Length == 4)
                            {
                                iCaptcha.Text = captchaTexto.ToUpper();
                            }
                            else
                            {
                                ObtenerCaptcha();
                                AplicacionFiltros();
                                LeerCaptchaReniec();
                            }
                        }
                    }
                }

            }
            Cursor = Cursors.Default;
        }

        private void ObtenerCaptcha()
        {
           
            if (ConsultaReniec.EstadoConsulta  == EstadoConsulta.ErrorConexion)
            {
                XtraMessageBox.Show("Error en la conexion al servicio ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ConsultaReniec != null)
            {
                Cursor = Cursors.WaitCursor;
                peCaptcha.EditValue = ConsultaReniec.ObtenerCapcha();
                Cursor = Cursors.Default;
            }
        }

        private void ConsultaDatosSunat(string dni, string captcha)
        {

            Cursor = Cursors.WaitCursor;
            PersonaReniec = ConsultaReniec.ConsultarDatos(dni, captcha);
            Cursor = Cursors.Default;

            if (PersonaReniec != null)
            {
                iPaterno.EditValue = PersonaReniec.ApePaterno;
                iMaterno.EditValue = PersonaReniec.ApeMaterno;
                iNombres.EditValue = PersonaReniec.Nombres;
                //ObtenerCaptcha();
                btnImportar.Focus();
                btnImportar.Select();
            }
            switch (ConsultaReniec.EstadoConsulta)
            {
                case EstadoConsulta.ErrorTextoCapcha:
                    XtraMessageBox.Show("Codigo captcha incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iCaptcha.Select();
                    iCaptcha.SelectAll();
                    break;
                case EstadoConsulta.NoResultado :
                    XtraMessageBox.Show("Numero de DNI invalido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iDni.Select();
                    iDni.SelectAll();
                    break;
                case EstadoConsulta.Error:
                    XtraMessageBox.Show("Error no especificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EstadoConsulta.ErrorConexion:
                    XtraMessageBox.Show("Error en la conexion al servicio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (iCaptcha.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Ingrese el codigo código captcha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iCaptcha.Select();
                iCaptcha.SelectAll();
                return;
            }

            if (iDni.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Ingrese el N° de RUC.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iDni.SelectAll();
                return;
            }

            ConsultaDatosSunat(iDni.Text.Trim(), iCaptcha.Text.Trim());
        }

        private void chkCorregirRazonSocial_CheckedChanged(object sender, EventArgs e)
        {
            iPaterno.ReadOnly = chkCorregirRazonSocial.Checked;
            iMaterno.ReadOnly = chkCorregirRazonSocial.Checked;
        }

        private void iCaptcha_Validating(object sender, CancelEventArgs e)
        {

        }

        private void ConsultaReniecFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnConsultar_Enter(object sender, EventArgs e)
        {
            btnConsultar.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }

        private void btnConsultar_Leave(object sender, EventArgs e)
        {
            btnConsultar.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
        }
    }
}