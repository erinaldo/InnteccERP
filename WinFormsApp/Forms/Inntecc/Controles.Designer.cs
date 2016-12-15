namespace WinFormsApp
{
    partial class Controles
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.beSocioNegocio = new DevExpress.XtraEditors.ButtonEdit();
            this.iIdsocionegocio = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Asignar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // beSocioNegocio
            // 
            this.beSocioNegocio.EditValue = "";
            this.beSocioNegocio.Location = new System.Drawing.Point(12, 51);
            this.beSocioNegocio.Name = "beSocioNegocio";
            toolTipTitleItem1.Text = "Buscar Registro (F3)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            toolTipTitleItem2.Text = "Nuevo Registro (Ctrl + Ins)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            toolTipTitleItem3.Text = "Modificar Registro (Ctrl + M)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.beSocioNegocio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject1, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.add, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)), serializableAppearanceObject2, "", null, superToolTip2, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Edit_12x12, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)), serializableAppearanceObject3, "", null, superToolTip3, true)});
            this.beSocioNegocio.Properties.ReadOnly = true;
            this.beSocioNegocio.Size = new System.Drawing.Size(429, 22);
            this.beSocioNegocio.TabIndex = 10;
            this.beSocioNegocio.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // iIdsocionegocio
            // 
            this.iIdsocionegocio.EditValue = 0;
            this.iIdsocionegocio.Location = new System.Drawing.Point(12, 79);
            this.iIdsocionegocio.Name = "iIdsocionegocio";
            this.iIdsocionegocio.Properties.AllowFocused = false;
            this.iIdsocionegocio.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdsocionegocio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdsocionegocio.Properties.ReadOnly = true;
            this.iIdsocionegocio.Size = new System.Drawing.Size(56, 20);
            this.iIdsocionegocio.TabIndex = 11;
            this.iIdsocionegocio.TabStop = false;
            this.iIdsocionegocio.EditValueChanged += new System.EventHandler(this.iIdsocionegocio_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 105);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(114, 23);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "Cuando se modifica";
            // 
            // Asignar
            // 
            this.Asignar.Location = new System.Drawing.Point(12, 134);
            this.Asignar.Name = "Asignar";
            this.Asignar.Size = new System.Drawing.Size(114, 23);
            this.Asignar.TabIndex = 13;
            this.Asignar.Text = "Asginar";
            this.Asignar.Click += new System.EventHandler(this.Asignar_Click);
            // 
            // Controles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 315);
            this.Controls.Add(this.Asignar);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.iIdsocionegocio);
            this.Controls.Add(this.beSocioNegocio);
            this.Name = "Controles";
            this.Text = "Controles";
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit beSocioNegocio;
        private DevExpress.XtraEditors.TextEdit iIdsocionegocio;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton Asignar;
    }
}