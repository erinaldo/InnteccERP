namespace WinFormsApp
{
    partial class ConsultaReniecFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaReniecFrm));
            this.btnRefrescarCaptcha = new DevExpress.XtraEditors.SimpleButton();
            this.iDni = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iPaterno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iMaterno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iNombres = new DevExpress.XtraEditors.TextEdit();
            this.peCaptcha = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.iCaptcha = new DevExpress.XtraEditors.TextEdit();
            this.btnImportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.chkCorregirRazonSocial = new DevExpress.XtraEditors.CheckEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.iDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCaptcha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCaptcha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCorregirRazonSocial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefrescarCaptcha
            // 
            this.btnRefrescarCaptcha.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescarCaptcha.Image")));
            this.btnRefrescarCaptcha.Location = new System.Drawing.Point(275, 20);
            this.btnRefrescarCaptcha.Name = "btnRefrescarCaptcha";
            this.btnRefrescarCaptcha.Size = new System.Drawing.Size(120, 23);
            this.btnRefrescarCaptcha.TabIndex = 1;
            this.btnRefrescarCaptcha.Text = "Refrescar captcha";
            this.btnRefrescarCaptcha.Click += new System.EventHandler(this.btnRefrescarCaptcha_Click);
            // 
            // iDni
            // 
            this.iDni.Location = new System.Drawing.Point(137, 82);
            this.iDni.Name = "iDni";
            this.iDni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iDni.Properties.Appearance.Options.UseFont = true;
            this.iDni.Properties.MaxLength = 8;
            this.iDni.Size = new System.Drawing.Size(132, 20);
            this.iDni.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "N° DNI";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Apellido paterno";
            // 
            // iPaterno
            // 
            this.iPaterno.Location = new System.Drawing.Point(137, 108);
            this.iPaterno.Name = "iPaterno";
            this.iPaterno.Properties.ReadOnly = true;
            this.iPaterno.Size = new System.Drawing.Size(553, 20);
            this.iPaterno.TabIndex = 8;
            this.iPaterno.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 137);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Apellido materno";
            // 
            // iMaterno
            // 
            this.iMaterno.Location = new System.Drawing.Point(137, 134);
            this.iMaterno.Name = "iMaterno";
            this.iMaterno.Properties.ReadOnly = true;
            this.iMaterno.Size = new System.Drawing.Size(553, 20);
            this.iMaterno.TabIndex = 10;
            this.iMaterno.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 163);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Nombre";
            // 
            // iNombres
            // 
            this.iNombres.Location = new System.Drawing.Point(137, 160);
            this.iNombres.Name = "iNombres";
            this.iNombres.Properties.ReadOnly = true;
            this.iNombres.Size = new System.Drawing.Size(553, 20);
            this.iNombres.TabIndex = 12;
            this.iNombres.TabStop = false;
            // 
            // peCaptcha
            // 
            this.peCaptcha.Location = new System.Drawing.Point(137, 12);
            this.peCaptcha.Name = "peCaptcha";
            this.peCaptcha.Size = new System.Drawing.Size(132, 38);
            this.peCaptcha.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Código Captcha";
            // 
            // iCaptcha
            // 
            this.iCaptcha.Location = new System.Drawing.Point(137, 56);
            this.iCaptcha.Name = "iCaptcha";
            this.iCaptcha.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iCaptcha.Properties.Appearance.Options.UseFont = true;
            this.iCaptcha.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCaptcha.Properties.MaxLength = 4;
            this.iCaptcha.Size = new System.Drawing.Size(132, 20);
            this.iCaptcha.TabIndex = 3;
            this.iCaptcha.Validating += new System.ComponentModel.CancelEventHandler(this.iCaptcha_Validating);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Location = new System.Drawing.Point(502, 188);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(102, 23);
            this.btnImportar.TabIndex = 23;
            this.btnImportar.Text = "Importar datos";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(610, 188);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 23);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkCorregirRazonSocial
            // 
            this.chkCorregirRazonSocial.Location = new System.Drawing.Point(470, 79);
            this.chkCorregirRazonSocial.Name = "chkCorregirRazonSocial";
            this.chkCorregirRazonSocial.Properties.Caption = "Corregir razón social / Nombre comercial";
            this.chkCorregirRazonSocial.Size = new System.Drawing.Size(220, 19);
            this.chkCorregirRazonSocial.TabIndex = 25;
            this.chkCorregirRazonSocial.TabStop = false;
            this.chkCorregirRazonSocial.CheckedChanged += new System.EventHandler(this.chkCorregirRazonSocial_CheckedChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(275, 54);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar DNI";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnConsultar.Enter += new System.EventHandler(this.btnConsultar_Enter);
            this.btnConsultar.Leave += new System.EventHandler(this.btnConsultar_Leave);
            // 
            // ConsultaReniecFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(702, 218);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.chkCorregirRazonSocial);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.iCaptcha);
            this.Controls.Add(this.peCaptcha);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iNombres);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iMaterno);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iPaterno);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iDni);
            this.Controls.Add(this.btnRefrescarCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ConsultaReniecFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar datos RENIEC";
            this.Load += new System.EventHandler(this.ConsultaReniecFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsultaReniecFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCaptcha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCaptcha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCorregirRazonSocial.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRefrescarCaptcha;
        private DevExpress.XtraEditors.TextEdit iDni;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iPaterno;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iMaterno;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iNombres;
        private DevExpress.XtraEditors.PictureEdit peCaptcha;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit iCaptcha;
        private DevExpress.XtraEditors.SimpleButton btnImportar;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.CheckEdit chkCorregirRazonSocial;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
    }
}