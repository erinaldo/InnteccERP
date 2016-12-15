namespace WinFormsApp
{
    partial class RpOrdenCompraFrm
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
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RpOrdenCompraFrm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.iFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.iFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beSocioNegocio = new DevExpress.XtraEditors.ButtonEdit();
            this.lcProveedor = new DevExpress.XtraEditors.LabelControl();
            this.iIdsocionegocio = new DevExpress.XtraEditors.TextEdit();
            this.rgOpcionReporte = new DevExpress.XtraEditors.RadioGroup();
            this.lbOptions = new DevExpress.XtraEditors.ListBoxControl();
            this.lcArea = new DevExpress.XtraEditors.LabelControl();
            this.iIdarea = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iIdtipomoneda = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(335, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(245, 228);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem4.Text = "Seleccionar registro";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnSeleccionar.SuperTip = superToolTip4;
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
            // beSocioNegocio
            // 
            this.beSocioNegocio.EditValue = "Todos los proveedores";
            this.beSocioNegocio.Location = new System.Drawing.Point(74, 147);
            this.beSocioNegocio.Name = "beSocioNegocio";
            toolTipTitleItem5.Text = "Buscar Registro (F3)";
            superToolTip5.Items.Add(toolTipTitleItem5);
            toolTipTitleItem6.Text = "Borrar dato";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.beSocioNegocio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject3, "", null, superToolTip5, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("beSocioNegocio.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, superToolTip6, true)});
            this.beSocioNegocio.Properties.ReadOnly = true;
            this.beSocioNegocio.Size = new System.Drawing.Size(345, 22);
            this.beSocioNegocio.TabIndex = 11;
            this.beSocioNegocio.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beSocioNegocio_ButtonClick);
            // 
            // lcProveedor
            // 
            this.lcProveedor.Location = new System.Drawing.Point(13, 151);
            this.lcProveedor.Name = "lcProveedor";
            this.lcProveedor.Size = new System.Drawing.Size(50, 13);
            this.lcProveedor.TabIndex = 12;
            this.lcProveedor.Text = "Proveedor";
            // 
            // iIdsocionegocio
            // 
            this.iIdsocionegocio.Location = new System.Drawing.Point(12, 231);
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
            this.rgOpcionReporte.Location = new System.Drawing.Point(74, 228);
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
            this.lbOptions.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
            this.lbOptions.Items.AddRange(new object[] {
            "ORDENES DE COMPRA RESUMIDO",
            "ORDENES DE COMPRA DETALLADO",
            "ORDEN DE COMPRA POR AREAS"});
            this.lbOptions.Location = new System.Drawing.Point(12, 38);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(405, 102);
            this.lbOptions.TabIndex = 15;
            this.lbOptions.SelectedIndexChanged += new System.EventHandler(this.lbOptions_SelectedIndexChanged);
            // 
            // lcArea
            // 
            this.lcArea.Location = new System.Drawing.Point(13, 204);
            this.lcArea.Name = "lcArea";
            this.lcArea.Size = new System.Drawing.Size(23, 13);
            this.lcArea.TabIndex = 17;
            this.lcArea.Text = "Area";
            // 
            // iIdarea
            // 
            this.iIdarea.Location = new System.Drawing.Point(74, 201);
            this.iIdarea.Name = "iIdarea";
            this.iIdarea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdarea.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdarea.Properties.View = this.gridView4;
            this.iIdarea.Size = new System.Drawing.Size(343, 20);
            this.iIdarea.TabIndex = 23;
            this.iIdarea.Tag = "Seleccione el Área";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id.";
            this.gridColumn7.FieldName = "Idarea";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Código";
            this.gridColumn8.FieldName = "Codigoarea";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Área";
            this.gridColumn9.FieldName = "Nombrearea";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // iIdtipomoneda
            // 
            this.iIdtipomoneda.Location = new System.Drawing.Point(74, 175);
            this.iIdtipomoneda.Name = "iIdtipomoneda";
            this.iIdtipomoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipomoneda.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipomoneda.Properties.View = this.gridView2;
            this.iIdtipomoneda.Size = new System.Drawing.Size(345, 20);
            this.iIdtipomoneda.TabIndex = 25;
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
            this.labelControl8.Location = new System.Drawing.Point(12, 178);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "Moneda";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sucursal";
            this.gridColumn1.FieldName = "Nombresucursal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // RpOrdenCompraFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(426, 259);
            this.Controls.Add(this.iIdtipomoneda);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.iIdarea);
            this.Controls.Add(this.lcArea);
            this.Controls.Add(this.lbOptions);
            this.Controls.Add(this.rgOpcionReporte);
            this.Controls.Add(this.iIdsocionegocio);
            this.Controls.Add(this.lcProveedor);
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
            this.Name = "RpOrdenCompraFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de compra ";
            this.Load += new System.EventHandler(this.RpOrdenCompraFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lcProveedor;
        private DevExpress.XtraEditors.TextEdit iIdsocionegocio;
        private DevExpress.XtraEditors.RadioGroup rgOpcionReporte;
        private DevExpress.XtraEditors.ListBoxControl lbOptions;
        private DevExpress.XtraEditors.LabelControl lcArea;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdarea;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipomoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}