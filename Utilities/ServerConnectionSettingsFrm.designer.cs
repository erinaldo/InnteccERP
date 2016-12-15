namespace Utilities
{
    partial class ServerConnectionSettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConnectionSettingsFrm));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.connectionPasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.connectionUsernameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.connectionServerTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.connectionDatabaseTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cmdAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSalir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionPasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionUsernameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionServerTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionDatabaseTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(91, 73);
            this.pictureEdit1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(109, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(362, 73);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(240, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Cambiar la conexion al servidor Postgresql";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.connectionPasswordTextEdit);
            this.groupControl1.Controls.Add(this.connectionUsernameTextEdit);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.connectionServerTextEdit);
            this.groupControl1.Controls.Add(this.connectionDatabaseTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(12, 91);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(459, 161);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Configuracion Actual";
            // 
            // connectionPasswordTextEdit
            // 
            this.connectionPasswordTextEdit.Location = new System.Drawing.Point(102, 126);
            this.connectionPasswordTextEdit.Name = "connectionPasswordTextEdit";
            this.connectionPasswordTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.connectionPasswordTextEdit.Properties.Appearance.Options.UseFont = true;
            this.connectionPasswordTextEdit.Properties.PasswordChar = '*';
            this.connectionPasswordTextEdit.Size = new System.Drawing.Size(173, 20);
            this.connectionPasswordTextEdit.TabIndex = 7;
            this.connectionPasswordTextEdit.Tag = "Ingrese la contraseña";
            // 
            // connectionUsernameTextEdit
            // 
            this.connectionUsernameTextEdit.Location = new System.Drawing.Point(102, 96);
            this.connectionUsernameTextEdit.Name = "connectionUsernameTextEdit";
            this.connectionUsernameTextEdit.Size = new System.Drawing.Size(173, 20);
            this.connectionUsernameTextEdit.TabIndex = 6;
            this.connectionUsernameTextEdit.Tag = "Ingrese el usuario";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Contraseña";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 99);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Usuario";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Base de datos";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Servidor";
            // 
            // connectionServerTextEdit
            // 
            this.connectionServerTextEdit.EditValue = "";
            this.connectionServerTextEdit.Location = new System.Drawing.Point(102, 36);
            this.connectionServerTextEdit.Name = "connectionServerTextEdit";
            this.connectionServerTextEdit.Properties.NullText = "[EditValue is null]";
            this.connectionServerTextEdit.Size = new System.Drawing.Size(173, 20);
            this.connectionServerTextEdit.TabIndex = 2;
            this.connectionServerTextEdit.Tag = "Ingrese el servidor";
            // 
            // connectionDatabaseTextEdit
            // 
            this.connectionDatabaseTextEdit.EditValue = "";
            this.connectionDatabaseTextEdit.Location = new System.Drawing.Point(102, 66);
            this.connectionDatabaseTextEdit.Name = "connectionDatabaseTextEdit";
            this.connectionDatabaseTextEdit.Properties.NullText = "[EditValue is null]";
            this.connectionDatabaseTextEdit.Size = new System.Drawing.Size(173, 20);
            this.connectionDatabaseTextEdit.TabIndex = 3;
            this.connectionDatabaseTextEdit.Tag = "Ingrese la base de datos";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(315, 258);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 3;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Location = new System.Drawing.Point(396, 258);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(75, 23);
            this.cmdSalir.TabIndex = 4;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // ServerConnectionSettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 285);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerConnectionSettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Connection Settings";
            this.Load += new System.EventHandler(this.ServerConnectionSettingsFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerConnectionSettingsFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionPasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionUsernameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionServerTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectionDatabaseTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit connectionPasswordTextEdit;
        private DevExpress.XtraEditors.TextEdit connectionUsernameTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton cmdAceptar;
        private DevExpress.XtraEditors.SimpleButton cmdSalir;
        private DevExpress.XtraEditors.TextEdit connectionServerTextEdit;
        private DevExpress.XtraEditors.TextEdit connectionDatabaseTextEdit;

    }
}