namespace WinFormsApp
{
    partial class ValorizacionegresoproveedorMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValorizacionegresoproveedorMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager();
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iIdtipoegresovalorizacion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rNumeroValorizacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.iImportetotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.iPreciounitario = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.iCantidad = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipoegresovalorizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNumeroValorizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportetotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPreciounitario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCantidad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bmMntItems
            // 
            this.bmMntItems.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMntItems});
            this.bmMntItems.DockControls.Add(this.barDockControlTop);
            this.bmMntItems.DockControls.Add(this.barDockControlBottom);
            this.bmMntItems.DockControls.Add(this.barDockControlLeft);
            this.bmMntItems.DockControls.Add(this.barDockControlRight);
            this.bmMntItems.Form = this;
            this.bmMntItems.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnGrabarItem,
            this.btnCancelarItem});
            this.bmMntItems.MaxItemId = 3;
            this.bmMntItems.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmMntItems_ItemClick);
            // 
            // barMntItems
            // 
            this.barMntItems.BarName = "Tools";
            this.barMntItems.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMntItems.DockCol = 0;
            this.barMntItems.DockRow = 0;
            this.barMntItems.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMntItems.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabarItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelarItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMntItems.OptionsBar.UseWholeRow = true;
            this.barMntItems.Text = "Tools";
            // 
            // btnGrabarItem
            // 
            this.btnGrabarItem.Caption = "Grabar";
            this.btnGrabarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGrabarItem.Glyph")));
            this.btnGrabarItem.Id = 0;
            this.btnGrabarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnGrabarItem.Name = "btnGrabarItem";
            toolTipTitleItem1.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnGrabarItem.SuperTip = superToolTip1;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Caption = "Cancelar";
            this.btnCancelarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelarItem.Glyph")));
            this.btnCancelarItem.Id = 1;
            this.btnCancelarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCancelarItem.Name = "btnCancelarItem";
            toolTipTitleItem2.Text = "Cancelar y cerrar ventana (Ctrl + S)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnCancelarItem.SuperTip = superToolTip2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(585, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 128);
            this.barDockControlBottom.Size = new System.Drawing.Size(585, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 97);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(585, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 97);
            // 
            // iIdtipoegresovalorizacion
            // 
            this.iIdtipoegresovalorizacion.Location = new System.Drawing.Point(106, 64);
            this.iIdtipoegresovalorizacion.Name = "iIdtipoegresovalorizacion";
            this.iIdtipoegresovalorizacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipoegresovalorizacion.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipoegresovalorizacion.Properties.View = this.gridView3;
            this.iIdtipoegresovalorizacion.Size = new System.Drawing.Size(440, 20);
            this.iIdtipoegresovalorizacion.TabIndex = 1;
            this.iIdtipoegresovalorizacion.Tag = "Seleccione el tipo de comprobante";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Id.";
            this.gridColumn10.FieldName = "Idtipoegresovalorizacion";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tipo Egreso";
            this.gridColumn11.FieldName = "Nombretipoegresovaloriza";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(20, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Tipo";
            // 
            // rNumeroValorizacion
            // 
            this.rNumeroValorizacion.Location = new System.Drawing.Point(106, 38);
            this.rNumeroValorizacion.MenuManager = this.bmMntItems;
            this.rNumeroValorizacion.Name = "rNumeroValorizacion";
            this.rNumeroValorizacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rNumeroValorizacion.Properties.Appearance.Options.UseFont = true;
            this.rNumeroValorizacion.Properties.ReadOnly = true;
            this.rNumeroValorizacion.Size = new System.Drawing.Size(440, 20);
            this.rNumeroValorizacion.TabIndex = 0;
            this.rNumeroValorizacion.TabStop = false;
            this.rNumeroValorizacion.Tag = "Ingrese un número de DNI";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Socio Negocio";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(316, 91);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(24, 13);
            this.labelControl10.TabIndex = 45;
            this.labelControl10.Text = "Total";
            // 
            // iImportetotal
            // 
            this.iImportetotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iImportetotal.Enabled = false;
            this.iImportetotal.Location = new System.Drawing.Point(346, 87);
            this.iImportetotal.Name = "iImportetotal";
            this.iImportetotal.Properties.Appearance.Options.UseTextOptions = true;
            this.iImportetotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iImportetotal.Properties.Mask.EditMask = "n";
            this.iImportetotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iImportetotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iImportetotal.Properties.ReadOnly = true;
            this.iImportetotal.Size = new System.Drawing.Size(87, 20);
            this.iImportetotal.TabIndex = 4;
            this.iImportetotal.TabStop = false;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(184, 90);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(49, 13);
            this.labelControl15.TabIndex = 44;
            this.labelControl15.Text = "V. unitario";
            // 
            // iPreciounitario
            // 
            this.iPreciounitario.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iPreciounitario.Location = new System.Drawing.Point(240, 87);
            this.iPreciounitario.Name = "iPreciounitario";
            this.iPreciounitario.Properties.Appearance.Options.UseTextOptions = true;
            this.iPreciounitario.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iPreciounitario.Properties.Mask.EditMask = "n";
            this.iPreciounitario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iPreciounitario.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iPreciounitario.Size = new System.Drawing.Size(70, 20);
            this.iPreciounitario.TabIndex = 3;
            this.iPreciounitario.EditValueChanged += new System.EventHandler(this.CalcularTotal);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(14, 90);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(43, 13);
            this.labelControl17.TabIndex = 43;
            this.labelControl17.Text = "Cantidad";
            // 
            // iCantidad
            // 
            this.iCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iCantidad.Location = new System.Drawing.Point(106, 87);
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.Properties.Appearance.Options.UseTextOptions = true;
            this.iCantidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iCantidad.Properties.Mask.EditMask = "n";
            this.iCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iCantidad.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iCantidad.Size = new System.Drawing.Size(70, 20);
            this.iCantidad.TabIndex = 2;
            this.iCantidad.EditValueChanged += new System.EventHandler(this.CalcularTotal);
            // 
            // ValorizacionegresoproveedorMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 128);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.iImportetotal);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.iPreciounitario);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.iCantidad);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.rNumeroValorizacion);
            this.Controls.Add(this.iIdtipoegresovalorizacion);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValorizacionegresoproveedorMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Items Egreso valorización proveedor";
            this.Load += new System.EventHandler(this.ValorizacionegresoproveedorMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValorizacionegresoproveedorMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipoegresovalorizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNumeroValorizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportetotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPreciounitario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCantidad.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmMntItems;
        private DevExpress.XtraBars.Bar barMntItems;
        private DevExpress.XtraBars.BarButtonItem btnGrabarItem;
        private DevExpress.XtraBars.BarButtonItem btnCancelarItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipoegresovalorizacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit rNumeroValorizacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit iImportetotal;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit iPreciounitario;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit iCantidad;
    }
}