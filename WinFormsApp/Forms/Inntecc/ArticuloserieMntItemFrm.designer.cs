namespace WinFormsApp
{
    partial class ArticuloserieMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloserieMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager();
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iIdseriearticulo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rNombreArticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigointernoitem = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iMarca = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iUnidad = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdseriearticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNombreArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigointernoitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iUnidad.Properties)).BeginInit();
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
            toolTipTitleItem7.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnGrabarItem.SuperTip = superToolTip7;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Caption = "Cancelar";
            this.btnCancelarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelarItem.Glyph")));
            this.btnCancelarItem.Id = 1;
            this.btnCancelarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCancelarItem.Name = "btnCancelarItem";
            toolTipTitleItem8.Text = "Cancelar y cerrar ventana (Ctrl + S)";
            superToolTip8.Items.Add(toolTipTitleItem8);
            this.btnCancelarItem.SuperTip = superToolTip8;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 150);
            this.barDockControlBottom.Size = new System.Drawing.Size(585, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 119);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(585, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 119);
            // 
            // iIdseriearticulo
            // 
            this.iIdseriearticulo.Location = new System.Drawing.Point(106, 91);
            this.iIdseriearticulo.Name = "iIdseriearticulo";
            this.iIdseriearticulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdseriearticulo.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdseriearticulo.Properties.View = this.gridView3;
            this.iIdseriearticulo.Size = new System.Drawing.Size(440, 20);
            this.iIdseriearticulo.TabIndex = 1;
            this.iIdseriearticulo.Tag = "Seleccione Unidad de Medida";
            this.iIdseriearticulo.EditValueChanged += new System.EventHandler(this.iIdseriearticulo_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn1});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Id.";
            this.gridColumn10.FieldName = "Idseriearticulo";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nº de serie";
            this.gridColumn11.FieldName = "Numeroserieitem";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Serie";
            // 
            // rNombreArticulo
            // 
            this.rNombreArticulo.Location = new System.Drawing.Point(106, 38);
            this.rNombreArticulo.MenuManager = this.bmMntItems;
            this.rNombreArticulo.Name = "rNombreArticulo";
            this.rNombreArticulo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rNombreArticulo.Properties.Appearance.Options.UseFont = true;
            this.rNombreArticulo.Properties.ReadOnly = true;
            this.rNombreArticulo.Size = new System.Drawing.Size(440, 20);
            this.rNombreArticulo.TabIndex = 0;
            this.rNombreArticulo.TabStop = false;
            this.rNombreArticulo.Tag = "Seleccione Articulo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Articulo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 120);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Código interno";
            // 
            // iCodigointernoitem
            // 
            this.iCodigointernoitem.Location = new System.Drawing.Point(106, 117);
            this.iCodigointernoitem.MenuManager = this.bmMntItems;
            this.iCodigointernoitem.Name = "iCodigointernoitem";
            this.iCodigointernoitem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iCodigointernoitem.Properties.Appearance.Options.UseFont = true;
            this.iCodigointernoitem.Properties.ReadOnly = true;
            this.iCodigointernoitem.Size = new System.Drawing.Size(180, 20);
            this.iCodigointernoitem.TabIndex = 9;
            this.iCodigointernoitem.TabStop = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código interno";
            this.gridColumn1.FieldName = "Codigointernoitem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Marca";
            // 
            // iMarca
            // 
            this.iMarca.Location = new System.Drawing.Point(106, 64);
            this.iMarca.MenuManager = this.bmMntItems;
            this.iMarca.Name = "iMarca";
            this.iMarca.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iMarca.Properties.Appearance.Options.UseFont = true;
            this.iMarca.Properties.ReadOnly = true;
            this.iMarca.Size = new System.Drawing.Size(180, 20);
            this.iMarca.TabIndex = 15;
            this.iMarca.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(303, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Unidad";
            // 
            // iUnidad
            // 
            this.iUnidad.Location = new System.Drawing.Point(366, 64);
            this.iUnidad.MenuManager = this.bmMntItems;
            this.iUnidad.Name = "iUnidad";
            this.iUnidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iUnidad.Properties.Appearance.Options.UseFont = true;
            this.iUnidad.Properties.ReadOnly = true;
            this.iUnidad.Size = new System.Drawing.Size(180, 20);
            this.iUnidad.TabIndex = 17;
            this.iUnidad.TabStop = false;
            // 
            // ArticuloserieMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 150);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iUnidad);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iMarca);
            this.Controls.Add(this.iCodigointernoitem);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.rNombreArticulo);
            this.Controls.Add(this.iIdseriearticulo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArticuloserieMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Articulo - Unidades de Medida";
            this.Load += new System.EventHandler(this.ArticuloserieMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ArticuloserieMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdseriearticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNombreArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigointernoitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iUnidad.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SearchLookUpEdit iIdseriearticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit rNombreArticulo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iCodigointernoitem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iUnidad;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iMarca;
    }
}