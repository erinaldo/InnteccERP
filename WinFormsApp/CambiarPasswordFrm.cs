using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class CambiarPasswordFrm : XtraForm
    {
        public VwUsuario Usuariosel { get; set; }
        public Usuario UsuarioMnt { get; set; }

        static readonly IService Service = new Service();

       static readonly HelperDb HelperDb = new HelperDb();
       
        public CambiarPasswordFrm(int idUsuario)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            iIdusuario.EditValue = idUsuario;
            
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Usuariosel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void CargarReferencias()
        {
         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtBeforePassword.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Ingrese Contraseña anterior", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                   txtBeforePassword.Select();
                return;

            }
            if (txtNewPassword.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Ingrese Contraseña Nueva", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                txtNewPassword.Select();
                return;

            }
            if (txtConfirmPassword.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Confirme Contraseña", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                txtConfirmPassword.Select();
                return;

            }

            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                XtraMessageBox.Show("Contraseña Confirmada no coincide con la Nueva contraseña", "Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                txtConfirmPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtNewPassword.Select();
                return;

            }
            string claveanterior = Cryptography.EncryptStringAes(txtBeforePassword.Text.Trim());
            
            
            UsuarioMnt = Service.GetUsuario(x => x.Idusuario == (int) iIdusuario.EditValue);
            if (UsuarioMnt.Pwdusuario != claveanterior)
            {
                XtraMessageBox.Show("Contraseña Anterior no es Correcta", "Atención", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
                txtBeforePassword.Text = string.Empty;
                txtBeforePassword.Select();
                return;
            }

            UsuarioMnt.Pwdusuario = Cryptography.EncryptStringAes(txtConfirmPassword.Text.Trim());
           Service.UpdateUsuario(UsuarioMnt);
           XtraMessageBox.Show("Contraseña Cambiada con exito", "Atención", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;


        }

        private void CambiarPasswordFrm_Load(object sender, EventArgs e)
        {

          
            CargarReferencias();
        }

        private void CambiarPasswordFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}