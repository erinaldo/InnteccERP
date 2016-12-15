using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CorpTeg.Utilidades;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Tesseract;
using Utilities;

namespace WinFormsApp
{

    public partial class ConsultaSunatFrm : XtraForm
    {
        private ConsultaRuc ConsultaRuc { get; set; }
        public Contribuyente Contribuyente { get; set; }
        public int IdDistrito { get; set; }
        public int TipoNombreImportacion { get; set; }

        public ConsultaSunatFrm()
        {
            InitializeComponent();
            ConsultaRuc = new ConsultaRuc();
            ConsultaRuc.Inicializar();

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void CargarReferencias()
        {
            iIddistrito.Properties.DataSource = CacheObjects.UbigeoList;
            iIddistrito.Properties.DisplayMember = "Nombreubigeo";
            iIddistrito.Properties.ValueMember = "Iddistrito";
            iIddistrito.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            var idDistrito = iIddistrito.EditValue;
            if (idDistrito == null)
            {
                XtraMessageBox.Show("Seleccione el ubigeo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIddistrito.Select();
                return;
            }

            if (Contribuyente != null)
            {
                IdDistrito = (int)iIddistrito.EditValue;
                Contribuyente.Direccion = iDireccionFiscal.Text.Trim();                
                DialogResult = DialogResult.OK;
            }
        }

        private void btnRefrescarCaptcha_Click(object sender, EventArgs e)
        {
            ObtenerCaptcha();
            LeerCaptchaSunat();
        }

        private void ConsultaSunatFrm_Load(object sender, EventArgs e)
        {
            if (ConsultaRuc.EstadoConsultaSunat == EstadoConsultaSunat.ErrorConexion)
            {
                XtraMessageBox.Show(string.Format("Error en la conexion al servicio{0}", ConsultaRuc.MensajeError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ObtenerCaptcha();
            LeerCaptchaSunat();
            CargarReferencias();
            //iCaptcha.Select();
            iRuc.Select();
        }

        private void ObtenerCaptcha()
        {
            if (ConsultaRuc.EstadoConsultaSunat == EstadoConsultaSunat.ErrorConexion)
            {
                XtraMessageBox.Show(string.Format("Error en la conexion al servicio {0}", ConsultaRuc.MensajeError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ConsultaRuc.EstadoConsultaSunat == EstadoConsultaSunat.Resultado)
            {
                peCaptcha.EditValue = ConsultaRuc.ObtenerCapcha();
            }
        }

        private void LeerCaptchaSunat()
        {
            Cursor = Cursors.WaitCursor;
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))            
            {
                using (var image = new System.Drawing.Bitmap(peCaptcha.Image))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            page.GetMeanConfidence();
                            string captchaTexto = page.GetText();
                            char[] eliminarChars = { '\n', ' ' };
                            captchaTexto = captchaTexto.TrimEnd(eliminarChars);
                            captchaTexto = captchaTexto.Replace(" ", string.Empty);
                            captchaTexto = Regex.Replace(captchaTexto, "[^a-zA-Z]+", string.Empty);
                            if (captchaTexto != string.Empty & captchaTexto.Length == 4)
                            {
                                iCaptcha.Text = captchaTexto.ToUpper();
                            }
                            else
                            {
                                ObtenerCaptcha();
                                LeerCaptchaSunat();
                            }
                        }
                    }
                }

            }
            Cursor = Cursors.Default;
        }

        private void ConsultaDatosSunat(string ruc, string captcha)
        {

            Cursor = Cursors.WaitCursor;
            Contribuyente = ConsultaRuc.BuscarContribuyente(ruc, captcha);
            Cursor = Cursors.Default;

            if (Contribuyente != null)
            {
                iRazonSocial.EditValue = Contribuyente.RazonSocial;
                iNombreComercial.EditValue = Contribuyente.NombreComercial;
                iEstado.EditValue = Contribuyente.Estado;
                iCondicion.EditValue = Contribuyente.Situacion;
                iDireccionFiscal.EditValue = Contribuyente.Direccion;
                iReferencia.EditValue = Contribuyente.ReferenciaDireccion;
                iIddistrito.Select();
            }
            switch (ConsultaRuc.EstadoConsultaSunat)
            {
                case EstadoConsultaSunat.ErrorTextoCapcha:
                    XtraMessageBox.Show("Codigo captcha incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iCaptcha.Select();
                    iCaptcha.SelectAll();
                    break;
                case EstadoConsultaSunat.NumeroRucNoValido:
                    XtraMessageBox.Show("Numero de ruc invalido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iRuc.Select();
                    iRuc.SelectAll();
                    break;
                case EstadoConsultaSunat.Error:
                    XtraMessageBox.Show("Error no especificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EstadoConsultaSunat.ErrorConexion:
                    XtraMessageBox.Show("Error en la conexion al servicio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
            ObtenerCaptcha();
            LeerCaptchaSunat();
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

            if (iRuc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Ingrese el N° de RUC.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iRuc.SelectAll();
                return;
            }

            ConsultaDatosSunat(iRuc.Text.Trim(), iCaptcha.Text.Trim());
        }

        private void chkCorregirRazonSocial_CheckedChanged(object sender, EventArgs e)
        {
            iRazonSocial.ReadOnly = chkCorregirRazonSocial.Checked;
            iNombreComercial.ReadOnly = chkCorregirRazonSocial.Checked;
        }

        private void iCaptcha_Validating(object sender, CancelEventArgs e)
        {

        }

        private void ConsultaSunatFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnConsultar_Enter(object sender, EventArgs e)
        {
            btnConsultar.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        }

        private void btnConsultar_Leave(object sender, EventArgs e)
        {
            btnConsultar.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
        }
    }
}