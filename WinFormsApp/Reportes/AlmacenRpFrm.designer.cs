namespace WinFormsApp
{
    partial class AlmacenRpFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlmacenRpFrm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.iFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.iFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beSocioNegocio = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIdsocionegocio = new DevExpress.XtraEditors.TextEdit();
            this.rgOpcionReporte = new DevExpress.XtraEditors.RadioGroup();
            this.lbOptions = new DevExpress.XtraEditors.ListBoxControl();
            this.iIdtipomoneda = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(330, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 11;
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
            this.btnSeleccionar.TabIndex = 10;
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
            this.iFechaInicio.TabIndex = 1;
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
            this.iFechaFinal.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha inicio";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(180, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Fecha fin";
            // 
            // beSocioNegocio
            // 
            this.beSocioNegocio.EditValue = "Todos los proveedores";
            this.beSocioNegocio.Location = new System.Drawing.Point(69, 310);
            this.beSocioNegocio.Name = "beSocioNegocio";
            toolTipTitleItem2.Text = "Buscar Registro (F3)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            toolTipTitleItem3.Text = "Borrar dato";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.beSocioNegocio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject1, "", null, superToolTip2, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("beSocioNegocio.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip3, true)});
            this.beSocioNegocio.Properties.ReadOnly = true;
            this.beSocioNegocio.Size = new System.Drawing.Size(345, 22);
            this.beSocioNegocio.TabIndex = 6;
            this.beSocioNegocio.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beSocioNegocio_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 314);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Proveedor";
            // 
            // iIdsocionegocio
            // 
            this.iIdsocionegocio.Location = new System.Drawing.Point(7, 365);
            this.iIdsocionegocio.Name = "iIdsocionegocio";
            this.iIdsocionegocio.Properties.AllowFocused = false;
            this.iIdsocionegocio.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdsocionegocio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdsocionegocio.Properties.ReadOnly = true;
            this.iIdsocionegocio.Size = new System.Drawing.Size(56, 20);
            this.iIdsocionegocio.TabIndex = 13;
            this.iIdsocionegocio.TabStop = false;
            this.iIdsocionegocio.Visible = false;
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
            this.rgOpcionReporte.TabIndex = 9;
            // 
            // lbOptions
            // 
            this.lbOptions.Items.AddRange(new object[] {
            "ENTRADAS A ALMACEN RESUMIDO",
            "ENTRADAS A ALMACEN DETALLADO"});
            this.lbOptions.Location = new System.Drawing.Point(13, 38);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(401, 266);
            this.lbOptions.TabIndex = 4;
            // 
            // iIdtipomoneda
            // 
            this.iIdtipomoneda.Location = new System.Drawing.Point(69, 338);
            this.iIdtipomoneda.Name = "iIdtipomoneda";
            this.iIdtipomoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipomoneda.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipomoneda.Properties.View = this.gridView2;
            this.iIdtipomoneda.Size = new System.Drawing.Size(345, 20);
            this.iIdtipomoneda.TabIndex = 8;
            this.iIdtipomoneda.Tag = "Seleccione el tipo de moneda";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Id.";
            this.gridColumn5.FieldName = "Idtipomoneda";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "Nombretipomoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(13, 341);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Moneda";
            // 
            // AlmacenRpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(423, 393);
            this.Controls.Add(this.iIdtipomoneda);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lbOptions);
            this.Controls.Add(this.rgOpcionReporte);
            this.Controls.Add(this.iIdsocionegocio);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.beSocioNegocio);
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
            this.Name = "AlmacenRpFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas a Almacen";
            this.Load += new System.EventHandler(this.AlmacenRpFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private DevExpress.XtraEditors.ButtonEdit beSocioNegocio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iIdsocionegocio;
        private DevExpress.XtraEditors.RadioGroup rgOpcionReporte;
        private DevExpress.XtraEditors.ListBoxControl lbOptions;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipomoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}