namespace WinFormsApp
{
    partial class PlantillahistoriaMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantillahistoriaMntItemFrm));
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIditemhistoria = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iOrdenitemplantilla = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iNombrecategoriaitem = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIditemhistoria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iOrdenitemplantilla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrecategoriaitem.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(601, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 121);
            this.barDockControlBottom.Size = new System.Drawing.Size(601, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 90);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(601, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 90);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Item de historia";
            // 
            // iIditemhistoria
            // 
            this.iIditemhistoria.Location = new System.Drawing.Point(101, 63);
            this.iIditemhistoria.MenuManager = this.bmMntItems;
            this.iIditemhistoria.Name = "iIditemhistoria";
            this.iIditemhistoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIditemhistoria.Properties.View = this.gridView1;
            this.iIditemhistoria.Size = new System.Drawing.Size(488, 20);
            this.iIditemhistoria.TabIndex = 3;
            this.iIditemhistoria.TabStop = false;
            this.iIditemhistoria.EditValueChanged += new System.EventHandler(this.iIditemhistoria_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id.";
            this.gridColumn3.FieldName = "Iditemhistoria";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Item de historia";
            this.gridColumn4.FieldName = "Nombreitemhistoria";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 92);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Categoria";
            // 
            // iOrdenitemplantilla
            // 
            this.iOrdenitemplantilla.EditValue = 0;
            this.iOrdenitemplantilla.Location = new System.Drawing.Point(101, 37);
            this.iOrdenitemplantilla.Name = "iOrdenitemplantilla";
            this.iOrdenitemplantilla.Properties.Appearance.Options.UseTextOptions = true;
            this.iOrdenitemplantilla.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iOrdenitemplantilla.Properties.Mask.EditMask = "n0";
            this.iOrdenitemplantilla.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iOrdenitemplantilla.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iOrdenitemplantilla.Size = new System.Drawing.Size(55, 20);
            this.iOrdenitemplantilla.TabIndex = 1;
            this.iOrdenitemplantilla.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Orden";
            // 
            // iNombrecategoriaitem
            // 
            this.iNombrecategoriaitem.Location = new System.Drawing.Point(101, 89);
            this.iNombrecategoriaitem.MenuManager = this.bmMntItems;
            this.iNombrecategoriaitem.Name = "iNombrecategoriaitem";
            this.iNombrecategoriaitem.Properties.ReadOnly = true;
            this.iNombrecategoriaitem.Size = new System.Drawing.Size(488, 20);
            this.iNombrecategoriaitem.TabIndex = 5;
            this.iNombrecategoriaitem.TabStop = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Categoría";
            this.gridColumn1.FieldName = "Nombrecategoriaitem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // PlantillahistoriaMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 121);
            this.Controls.Add(this.iNombrecategoriaitem);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iOrdenitemplantilla);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iIditemhistoria);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlantillahistoriaMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de plantilla de historia";
            this.Load += new System.EventHandler(this.PlantillahistoriaMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlantillahistoriaMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIditemhistoria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iOrdenitemplantilla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrecategoriaitem.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SearchLookUpEdit iIditemhistoria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit iNombrecategoriaitem;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iOrdenitemplantilla;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}