namespace WinFormsApp
{
    partial class CambiarPasswordFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPasswordFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.iIdusuario = new DevExpress.XtraEditors.TextEdit();
            this.txtBeforePassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdusuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeforePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(238, 88);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(148, 88);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Cambiar Contraseña";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnAceptar.SuperTip = superToolTip1;
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // iIdusuario
            // 
            this.iIdusuario.EditValue = 0;
            this.iIdusuario.Location = new System.Drawing.Point(12, 90);
            this.iIdusuario.Name = "iIdusuario";
            this.iIdusuario.Properties.AllowFocused = false;
            this.iIdusuario.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdusuario.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdusuario.Properties.ReadOnly = true;
            this.iIdusuario.Size = new System.Drawing.Size(56, 20);
            this.iIdusuario.TabIndex = 33;
            this.iIdusuario.TabStop = false;
            this.iIdusuario.Visible = false;
            // 
            // txtBeforePassword
            // 
            this.txtBeforePassword.Location = new System.Drawing.Point(120, 12);
            this.txtBeforePassword.Name = "txtBeforePassword";
            this.txtBeforePassword.Properties.MaxLength = 15;
            this.txtBeforePassword.Properties.PasswordChar = '*';
            this.txtBeforePassword.Size = new System.Drawing.Size(205, 20);
            this.txtBeforePassword.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 13);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "Contraseña Anterior";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 13);
            this.labelControl2.TabIndex = 39;
            this.labelControl2.Text = "Nueva Contraseña";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 65);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 13);
            this.labelControl4.TabIndex = 40;
            this.labelControl4.Text = "Confirmar Contraseña";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(120, 37);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.MaxLength = 15;
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(205, 20);
            this.txtNewPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(120, 62);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.MaxLength = 15;
            this.txtConfirmPassword.Properties.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(205, 20);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // CambiarPasswordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(332, 117);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBeforePassword);
            this.Controls.Add(this.iIdusuario);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambiarPasswordFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contrseña";
            this.Load += new System.EventHandler(this.CambiarPasswordFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CambiarPasswordFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iIdusuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeforePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit iIdusuario;
        private DevExpress.XtraEditors.TextEdit txtBeforePassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
    }
}