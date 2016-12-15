namespace WinFormsApp
{
    partial class RecibocajaingresoimprevistoMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecibocajaingresoimprevistoMntItemFrm));
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
            this.tcProductos = new DevExpress.XtraTab.XtraTabControl();
            this.tpProducto = new DevExpress.XtraTab.XtraTabPage();
            this.rNumerodocumento = new DevExpress.XtraEditors.TextEdit();
            this.rSeriedocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iNumerotipocp = new DevExpress.XtraEditors.TextEdit();
            this.iSerietipocp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iIdtipocp = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iImportepago = new DevExpress.XtraEditors.TextEdit();
            this.iIdarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iNombretipocp = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rNumerodocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSeriedocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombretipocp.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(630, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 173);
            this.barDockControlBottom.Size = new System.Drawing.Size(630, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 142);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(630, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 142);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(630, 142);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.rNumerodocumento);
            this.tpProducto.Controls.Add(this.rSeriedocumento);
            this.tpProducto.Controls.Add(this.labelControl5);
            this.tpProducto.Controls.Add(this.iNumerotipocp);
            this.tpProducto.Controls.Add(this.iSerietipocp);
            this.tpProducto.Controls.Add(this.labelControl3);
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.iIdtipocp);
            this.tpProducto.Controls.Add(this.labelControl4);
            this.tpProducto.Controls.Add(this.iImportepago);
            this.tpProducto.Controls.Add(this.iIdarticulo);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Controls.Add(this.labelControl2);
            this.tpProducto.Controls.Add(this.iNombretipocp);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(624, 114);
            this.tpProducto.Text = "Contenido";
            // 
            // rNumerodocumento
            // 
            this.rNumerodocumento.EditValue = "0";
            this.rNumerodocumento.Location = new System.Drawing.Point(509, 37);
            this.rNumerodocumento.Name = "rNumerodocumento";
            this.rNumerodocumento.Properties.Mask.EditMask = "d8";
            this.rNumerodocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rNumerodocumento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rNumerodocumento.Properties.ReadOnly = true;
            this.rNumerodocumento.Size = new System.Drawing.Size(108, 20);
            this.rNumerodocumento.TabIndex = 7;
            // 
            // rSeriedocumento
            // 
            this.rSeriedocumento.EditValue = "0";
            this.rSeriedocumento.Location = new System.Drawing.Point(444, 37);
            this.rSeriedocumento.Name = "rSeriedocumento";
            this.rSeriedocumento.Properties.Appearance.Options.UseTextOptions = true;
            this.rSeriedocumento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rSeriedocumento.Properties.Mask.EditMask = "d4";
            this.rSeriedocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rSeriedocumento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rSeriedocumento.Properties.ReadOnly = true;
            this.rSeriedocumento.Size = new System.Drawing.Size(59, 20);
            this.rSeriedocumento.TabIndex = 6;
            this.rSeriedocumento.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(366, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Serie y número";
            // 
            // iNumerotipocp
            // 
            this.iNumerotipocp.EditValue = "0";
            this.iNumerotipocp.Location = new System.Drawing.Point(509, 60);
            this.iNumerotipocp.Name = "iNumerotipocp";
            this.iNumerotipocp.Properties.Mask.EditMask = "d8";
            this.iNumerotipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iNumerotipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iNumerotipocp.Size = new System.Drawing.Size(108, 20);
            this.iNumerotipocp.TabIndex = 12;
            this.iNumerotipocp.Tag = "Ingrese el Número de Documento";
            // 
            // iSerietipocp
            // 
            this.iSerietipocp.EditValue = "0";
            this.iSerietipocp.Location = new System.Drawing.Point(444, 61);
            this.iSerietipocp.Name = "iSerietipocp";
            this.iSerietipocp.Properties.Appearance.Options.UseTextOptions = true;
            this.iSerietipocp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iSerietipocp.Properties.Mask.EditMask = "d4";
            this.iSerietipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iSerietipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iSerietipocp.Size = new System.Drawing.Size(59, 20);
            this.iSerietipocp.TabIndex = 11;
            this.iSerietipocp.Tag = "Ingrese el Número de Serie";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(366, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Serie y número";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Tipo Comprobante";
            // 
            // iIdtipocp
            // 
            this.iIdtipocp.Location = new System.Drawing.Point(106, 64);
            this.iIdtipocp.Name = "iIdtipocp";
            this.iIdtipocp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipocp.Properties.View = this.searchLookUpEdit1View;
            this.iIdtipocp.Size = new System.Drawing.Size(252, 20);
            this.iIdtipocp.TabIndex = 9;
            this.iIdtipocp.Tag = "Seleccione el tipo de documento";
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn9});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idtipocp";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo doc.";
            this.gridColumn2.FieldName = "Nombretipocp";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "N° Serie";
            this.gridColumn9.FieldName = "Seriecp";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Importe";
            // 
            // iImportepago
            // 
            this.iImportepago.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iImportepago.Location = new System.Drawing.Point(106, 90);
            this.iImportepago.Name = "iImportepago";
            this.iImportepago.Properties.Appearance.Options.UseTextOptions = true;
            this.iImportepago.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iImportepago.Properties.DisplayFormat.FormatString = "n2";
            this.iImportepago.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iImportepago.Properties.EditFormat.FormatString = "n2";
            this.iImportepago.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iImportepago.Properties.Mask.EditMask = "n";
            this.iImportepago.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iImportepago.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iImportepago.Size = new System.Drawing.Size(106, 20);
            this.iImportepago.TabIndex = 14;
            // 
            // iIdarticulo
            // 
            this.iIdarticulo.EditValue = 0;
            this.iIdarticulo.Location = new System.Drawing.Point(171, 11);
            this.iIdarticulo.Name = "iIdarticulo";
            this.iIdarticulo.Properties.AllowFocused = false;
            this.iIdarticulo.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdarticulo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdarticulo.Properties.ReadOnly = true;
            this.iIdarticulo.Size = new System.Drawing.Size(56, 20);
            this.iIdarticulo.TabIndex = 2;
            this.iIdarticulo.TabStop = false;
            this.iIdarticulo.Visible = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(11, 14);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(37, 13);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "N° Item";
            // 
            // iNumeroitem
            // 
            this.iNumeroitem.EditValue = 0;
            this.iNumeroitem.Location = new System.Drawing.Point(106, 11);
            this.iNumeroitem.Name = "iNumeroitem";
            this.iNumeroitem.Properties.AllowFocused = false;
            this.iNumeroitem.Properties.Appearance.Options.UseTextOptions = true;
            this.iNumeroitem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iNumeroitem.Properties.ReadOnly = true;
            this.iNumeroitem.Size = new System.Drawing.Size(59, 20);
            this.iNumeroitem.TabIndex = 1;
            this.iNumeroitem.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Documento";
            // 
            // iNombretipocp
            // 
            this.iNombretipocp.Location = new System.Drawing.Point(106, 37);
            this.iNombretipocp.Name = "iNombretipocp";
            this.iNombretipocp.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iNombretipocp.Properties.MaxLength = 10;
            this.iNombretipocp.Properties.ReadOnly = true;
            this.iNombretipocp.Size = new System.Drawing.Size(252, 20);
            this.iNombretipocp.TabIndex = 4;
            // 
            // RecibocajaingresoimprevistoMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 173);
            this.Controls.Add(this.tcProductos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecibocajaingresoimprevistoMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Pagos Relacionados al Documento";
            this.Load += new System.EventHandler(this.RecibocajaingresoimprevistoMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecibocajaingresoimprevistoMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rNumerodocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSeriedocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombretipocp.Properties)).EndInit();
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
        private DevExpress.XtraTab.XtraTabControl tcProductos;
        private DevExpress.XtraTab.XtraTabPage tpProducto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iNombretipocp;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit iNumeroitem;
        private DevExpress.XtraEditors.TextEdit iIdarticulo;
        public DevExpress.XtraEditors.TextEdit iNumerotipocp;
        public DevExpress.XtraEditors.TextEdit iSerietipocp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.SearchLookUpEdit iIdtipocp;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iImportepago;
        public DevExpress.XtraEditors.TextEdit rNumerodocumento;
        public DevExpress.XtraEditors.TextEdit rSeriedocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}