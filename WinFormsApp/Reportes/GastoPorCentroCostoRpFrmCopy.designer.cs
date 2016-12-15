namespace WinFormsApp
{
    partial class GastoPorCentroCostoRpFrmCopy
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GastoPorCentroCostoRpFrmCopy));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.iFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.iFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beCentroCosto = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIdCentroCosto = new DevExpress.XtraEditors.TextEdit();
            this.rgOpcionReporte = new DevExpress.XtraEditors.RadioGroup();
            this.lbOptions = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCentroCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdCentroCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(330, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(240, 362);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Seleccionar registro";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSeleccionar.SuperTip = superToolTip1;
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Aceptar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // iFechaInicio
            // 
            this.iFechaInicio.EditValue = null;
            this.iFechaInicio.Location = new System.Drawing.Point(74, 12);
            this.iFechaInicio.Name = "iFechaInicio";
            this.iFechaInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.iFechaInicio.TabIndex = 5;
            // 
            // iFechaFinal
            // 
            this.iFechaFinal.EditValue = null;
            this.iFechaFinal.Location = new System.Drawing.Point(230, 12);
            this.iFechaFinal.Name = "iFechaFinal";
            this.iFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.iFechaFinal.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Fecha inicio";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(180, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Fecha fin";
            // 
            // beCentroCosto
            // 
            this.beCentroCosto.EditValue = "Todos los Centro de Costo";
            this.beCentroCosto.Location = new System.Drawing.Point(69, 334);
            this.beCentroCosto.Name = "beCentroCosto";
            toolTipTitleItem2.Text = "Buscar Registro (F3)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            toolTipTitleItem3.Text = "Borrar dato";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.beCentroCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject1, "", null, superToolTip2, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("beSocioNegocio.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip3, true)});
            this.beCentroCosto.Properties.ReadOnly = true;
            this.beCentroCosto.Size = new System.Drawing.Size(345, 22);
            this.beCentroCosto.TabIndex = 11;
            this.beCentroCosto.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beCentroCosto_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 338);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "C. Costo";
            // 
            // iIdCentroCosto
            // 
            this.iIdCentroCosto.Location = new System.Drawing.Point(7, 365);
            this.iIdCentroCosto.Name = "iIdCentroCosto";
            this.iIdCentroCosto.Properties.AllowFocused = false;
            this.iIdCentroCosto.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdCentroCosto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdCentroCosto.Properties.ReadOnly = true;
            this.iIdCentroCosto.Size = new System.Drawing.Size(56, 20);
            this.iIdCentroCosto.TabIndex = 13;
            this.iIdCentroCosto.TabStop = false;
            this.iIdCentroCosto.Visible = false;
            // 
            // rgOpcionReporte
            // 
            this.rgOpcionReporte.Location = new System.Drawing.Point(69, 362);
            this.rgOpcionReporte.Name = "rgOpcionReporte";
            this.rgOpcionReporte.Properties.Columns = 2;
            this.rgOpcionReporte.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Vista previa"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Diseño")});
            this.rgOpcionReporte.Size = new System.Drawing.Size(161, 23);
            this.rgOpcionReporte.TabIndex = 14;
            // 
            // lbOptions
            // 
            this.lbOptions.Items.AddRange(new object[] {
            "CENTRO DE COSTO POR ARTICULO Y AREA",
            "CENTRO DE COSTO POR COMPROBANTE"});
            this.lbOptions.Location = new System.Drawing.Point(13, 38);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(401, 290);
            this.lbOptions.TabIndex = 15;
            // 
            // GastoPorCentroCostoRpFrmCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(426, 408);
            this.Controls.Add(this.lbOptions);
            this.Controls.Add(this.rgOpcionReporte);
            this.Controls.Add(this.iIdCentroCosto);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.beCentroCosto);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iFechaFinal);
            this.Controls.Add(this.iFechaInicio);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GastoPorCentroCostoRpFrmCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes por Centro Costo";
            this.Load += new System.EventHandler(this.GastoPorCentroCostoRpFrmCopy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCentroCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdCentroCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.DateEdit iFechaInicio;
        private DevExpress.XtraEditors.DateEdit iFechaFinal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beCentroCosto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iIdCentroCosto;
        private DevExpress.XtraEditors.RadioGroup rgOpcionReporte;
        private DevExpress.XtraEditors.ListBoxControl lbOptions;
    }
}