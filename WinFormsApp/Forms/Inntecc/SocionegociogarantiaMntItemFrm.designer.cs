namespace WinFormsApp
{
    partial class SocionegociogarantiaMntItemFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SocionegociogarantiaMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iImporte = new DevExpress.XtraEditors.TextEdit();
            this.iIdtipomoneda = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iIdtipogarantia = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iIdentfinaciera = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.iVencimiento = new DevExpress.XtraEditors.DateEdit();
            this.iDescripicion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipogarantia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdentfinaciera.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVencimiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVencimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescripicion.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(537, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 243);
            this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 212);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(537, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 212);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 118);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Importe";
            // 
            // iImporte
            // 
            this.iImporte.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iImporte.Location = new System.Drawing.Point(94, 115);
            this.iImporte.Name = "iImporte";
            this.iImporte.Properties.Appearance.Options.UseTextOptions = true;
            this.iImporte.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iImporte.Properties.Mask.EditMask = "n";
            this.iImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iImporte.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iImporte.Size = new System.Drawing.Size(70, 20);
            this.iImporte.TabIndex = 7;
            // 
            // iIdtipomoneda
            // 
            this.iIdtipomoneda.Location = new System.Drawing.Point(94, 89);
            this.iIdtipomoneda.Name = "iIdtipomoneda";
            this.iIdtipomoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipomoneda.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipomoneda.Properties.View = this.gridView2;
            this.iIdtipomoneda.Size = new System.Drawing.Size(422, 20);
            this.iIdtipomoneda.TabIndex = 5;
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
            this.labelControl8.Location = new System.Drawing.Point(10, 92);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Moneda";
            // 
            // iIdtipogarantia
            // 
            this.iIdtipogarantia.Location = new System.Drawing.Point(94, 37);
            this.iIdtipogarantia.Name = "iIdtipogarantia";
            this.iIdtipogarantia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipogarantia.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipogarantia.Properties.View = this.gridView1;
            this.iIdtipogarantia.Size = new System.Drawing.Size(422, 20);
            this.iIdtipogarantia.TabIndex = 1;
            this.iIdtipogarantia.Tag = "Seleccione el tipo de garantía";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idtipogarantia";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo garantía";
            this.gridColumn2.FieldName = "Nombretipogarantia";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tipo garantía";
            // 
            // iIdentfinaciera
            // 
            this.iIdentfinaciera.Location = new System.Drawing.Point(94, 63);
            this.iIdentfinaciera.Name = "iIdentfinaciera";
            this.iIdentfinaciera.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdentfinaciera.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdentfinaciera.Properties.View = this.gridView3;
            this.iIdentfinaciera.Size = new System.Drawing.Size(422, 20);
            this.iIdentfinaciera.TabIndex = 3;
            this.iIdentfinaciera.Tag = "Seleccione el banco";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id.";
            this.gridColumn3.FieldName = "Identfinaciera";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Código";
            this.gridColumn4.FieldName = "Codentidadfinaciera";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Nombre";
            this.gridColumn7.FieldName = "Nombreentidadfinanciera";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Sunat";
            this.gridColumn8.FieldName = "Essunat";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Banco";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(10, 144);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(57, 13);
            this.labelControl16.TabIndex = 8;
            this.labelControl16.Text = "Vencimiento";
            // 
            // iVencimiento
            // 
            this.iVencimiento.EditValue = null;
            this.iVencimiento.Location = new System.Drawing.Point(94, 141);
            this.iVencimiento.Name = "iVencimiento";
            this.iVencimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iVencimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iVencimiento.Size = new System.Drawing.Size(100, 20);
            this.iVencimiento.TabIndex = 9;
            this.iVencimiento.Tag = "Ingrese la fecha de vencimiento";
            // 
            // iDescripicion
            // 
            this.iDescripicion.Location = new System.Drawing.Point(94, 167);
            this.iDescripicion.MenuManager = this.bmMntItems;
            this.iDescripicion.Name = "iDescripicion";
            this.iDescripicion.Size = new System.Drawing.Size(422, 64);
            this.iDescripicion.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 170);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Descripción";
            // 
            // SocionegociogarantiaMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 243);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iDescripicion);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.iVencimiento);
            this.Controls.Add(this.iIdentfinaciera);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iIdtipogarantia);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iIdtipomoneda);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iImporte);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SocionegociogarantiaMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garantía socio de negocio";
            this.Load += new System.EventHandler(this.SocionegociogarantiaMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SocionegociogarantiaMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipogarantia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdentfinaciera.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVencimiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iVencimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescripicion.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iImporte;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipomoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipogarantia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdentfinaciera;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit iDescripicion;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.DateEdit iVencimiento;
    }
}