namespace WinFormsApp
{
    partial class ModeloautorizacionEtapaMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeloautorizacionEtapaMntItemFrm));
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
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.iIdetapaautorizacion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdetapaautorizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 68);
            this.barDockControlBottom.Size = new System.Drawing.Size(585, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 37);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(585, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 37);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(10, 39);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(28, 13);
            this.labelControl9.TabIndex = 25;
            this.labelControl9.Text = "Etapa";
            // 
            // iIdetapaautorizacion
            // 
            this.iIdetapaautorizacion.Location = new System.Drawing.Point(74, 37);
            this.iIdetapaautorizacion.Name = "iIdetapaautorizacion";
            this.iIdetapaautorizacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdetapaautorizacion.Properties.View = this.gridView3;
            this.iIdetapaautorizacion.Size = new System.Drawing.Size(381, 20);
            this.iIdetapaautorizacion.TabIndex = 24;
            this.iIdetapaautorizacion.Tag = "Seleccione el empleado";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Id.";
            this.gridColumn15.FieldName = "Idetapaautorizacion";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Etapa";
            this.gridColumn16.FieldName = "Nombreetapaautorizacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            // 
            // ModeloautorizacionEtapaMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 68);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.iIdetapaautorizacion);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeloautorizacionEtapaMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de etapas de autorización";
            this.Load += new System.EventHandler(this.ModeloautorizacionEtapaMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ModeloautorizacionEtapaMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdetapaautorizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdetapaautorizacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}