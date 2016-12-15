namespace WinFormsApp
{
    partial class RecibocajaegresoMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecibocajaegresoMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
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
            this.iIdcpcompra = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iIdtipodocmov = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeromediopago = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.iComentario = new DevExpress.XtraEditors.MemoEdit();
            this.iNumerotipocp = new DevExpress.XtraEditors.TextEdit();
            this.iSerietipocp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIdmediopago = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iIdtipocp = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iImportepago = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iIdcpcompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipodocmov.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeromediopago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmediopago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).BeginInit();
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
            toolTipTitleItem3.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnGrabarItem.SuperTip = superToolTip3;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Caption = "Cancelar";
            this.btnCancelarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelarItem.Glyph")));
            this.btnCancelarItem.Id = 1;
            this.btnCancelarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCancelarItem.Name = "btnCancelarItem";
            toolTipTitleItem4.Text = "Cancelar y cerrar ventana (Ctrl + S)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnCancelarItem.SuperTip = superToolTip4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(637, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 279);
            this.barDockControlBottom.Size = new System.Drawing.Size(637, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 248);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(637, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 248);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(637, 248);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.iIdcpcompra);
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.iIdtipodocmov);
            this.tpProducto.Controls.Add(this.labelControl21);
            this.tpProducto.Controls.Add(this.iNumeromediopago);
            this.tpProducto.Controls.Add(this.labelControl6);
            this.tpProducto.Controls.Add(this.iComentario);
            this.tpProducto.Controls.Add(this.iNumerotipocp);
            this.tpProducto.Controls.Add(this.iSerietipocp);
            this.tpProducto.Controls.Add(this.labelControl3);
            this.tpProducto.Controls.Add(this.iIdmediopago);
            this.tpProducto.Controls.Add(this.labelControl7);
            this.tpProducto.Controls.Add(this.labelControl2);
            this.tpProducto.Controls.Add(this.iIdtipocp);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Controls.Add(this.labelControl4);
            this.tpProducto.Controls.Add(this.iImportepago);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(631, 220);
            this.tpProducto.Text = "Item Recibo";
            // 
            // iIdcpcompra
            // 
            this.iIdcpcompra.Location = new System.Drawing.Point(331, 91);
            this.iIdcpcompra.Name = "iIdcpcompra";
            this.iIdcpcompra.Properties.AllowFocused = false;
            this.iIdcpcompra.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdcpcompra.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdcpcompra.Properties.ReadOnly = true;
            this.iIdcpcompra.Size = new System.Drawing.Size(59, 20);
            this.iIdcpcompra.TabIndex = 17;
            this.iIdcpcompra.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tipo";
            // 
            // iIdtipodocmov
            // 
            this.iIdtipodocmov.Location = new System.Drawing.Point(138, 39);
            this.iIdtipodocmov.Name = "iIdtipodocmov";
            this.iIdtipodocmov.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipodocmov.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iIdtipodocmov.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Idtipodocmov", "Id.", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombretipodocmov", "Tipo")});
            this.iIdtipodocmov.Properties.MaxLength = 50;
            this.iIdtipodocmov.Properties.NullText = "";
            this.iIdtipodocmov.Properties.PopupSizeable = false;
            this.iIdtipodocmov.Properties.ReadOnly = true;
            this.iIdtipodocmov.Size = new System.Drawing.Size(187, 20);
            this.iIdtipodocmov.TabIndex = 3;
            this.iIdtipodocmov.EditValueChanged += new System.EventHandler(this.iIdtipodocmov_EditValueChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(10, 145);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(120, 13);
            this.labelControl21.TabIndex = 13;
            this.labelControl21.Text = "N° operación Medio Pago";
            // 
            // iNumeromediopago
            // 
            this.iNumeromediopago.Location = new System.Drawing.Point(138, 143);
            this.iNumeromediopago.Name = "iNumeromediopago";
            this.iNumeromediopago.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iNumeromediopago.Properties.MaxLength = 100;
            this.iNumeromediopago.Size = new System.Drawing.Size(483, 20);
            this.iNumeromediopago.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 171);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Comentario";
            // 
            // iComentario
            // 
            this.iComentario.Location = new System.Drawing.Point(138, 169);
            this.iComentario.Name = "iComentario";
            this.iComentario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iComentario.Size = new System.Drawing.Size(483, 40);
            this.iComentario.TabIndex = 16;
            // 
            // iNumerotipocp
            // 
            this.iNumerotipocp.EditValue = "0";
            this.iNumerotipocp.Location = new System.Drawing.Point(474, 63);
            this.iNumerotipocp.Name = "iNumerotipocp";
            this.iNumerotipocp.Properties.Mask.EditMask = "d8";
            this.iNumerotipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iNumerotipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iNumerotipocp.Properties.ReadOnly = true;
            this.iNumerotipocp.Size = new System.Drawing.Size(93, 20);
            this.iNumerotipocp.TabIndex = 8;
            // 
            // iSerietipocp
            // 
            this.iSerietipocp.EditValue = "0";
            this.iSerietipocp.Location = new System.Drawing.Point(412, 63);
            this.iSerietipocp.Name = "iSerietipocp";
            this.iSerietipocp.Properties.Appearance.Options.UseTextOptions = true;
            this.iSerietipocp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iSerietipocp.Properties.Mask.EditMask = "d4";
            this.iSerietipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iSerietipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iSerietipocp.Properties.ReadOnly = true;
            this.iSerietipocp.Size = new System.Drawing.Size(56, 20);
            this.iSerietipocp.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(331, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Serie y número";
            // 
            // iIdmediopago
            // 
            this.iIdmediopago.Location = new System.Drawing.Point(138, 117);
            this.iIdmediopago.Name = "iIdmediopago";
            this.iIdmediopago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdmediopago.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdmediopago.Properties.View = this.gridView2;
            this.iIdmediopago.Size = new System.Drawing.Size(483, 20);
            this.iIdmediopago.TabIndex = 12;
            this.iIdmediopago.Tag = "Seleccione el medio de pago";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id.";
            this.gridColumn3.FieldName = "Idmediopago";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Medio Pago";
            this.gridColumn4.FieldName = "Nombremediopago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 119);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(55, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Medio Pago";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tipo Comprobante";
            // 
            // iIdtipocp
            // 
            this.iIdtipocp.Location = new System.Drawing.Point(138, 65);
            this.iIdtipocp.Name = "iIdtipocp";
            this.iIdtipocp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipocp.Properties.ReadOnly = true;
            this.iIdtipocp.Properties.View = this.searchLookUpEdit1View;
            this.iIdtipocp.Size = new System.Drawing.Size(187, 20);
            this.iIdtipocp.TabIndex = 5;
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
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(10, 16);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(37, 13);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "N° Item";
            // 
            // iNumeroitem
            // 
            this.iNumeroitem.EditValue = 0;
            this.iNumeroitem.Location = new System.Drawing.Point(138, 13);
            this.iNumeroitem.Name = "iNumeroitem";
            this.iNumeroitem.Properties.AllowFocused = false;
            this.iNumeroitem.Properties.Appearance.Options.UseTextOptions = true;
            this.iNumeroitem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iNumeroitem.Properties.ReadOnly = true;
            this.iNumeroitem.Size = new System.Drawing.Size(59, 20);
            this.iNumeroitem.TabIndex = 1;
            this.iNumeroitem.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Importe de pago";
            // 
            // iImportepago
            // 
            this.iImportepago.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iImportepago.Location = new System.Drawing.Point(138, 91);
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
            this.iImportepago.Size = new System.Drawing.Size(187, 20);
            this.iImportepago.TabIndex = 10;
            // 
            // RecibocajaegresoMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 279);
            this.Controls.Add(this.tcProductos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecibocajaegresoMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de Recibo de Caja";
            this.Load += new System.EventHandler(this.RecibocajaegresoMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecibocajaegresoMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iIdcpcompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipodocmov.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeromediopago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmediopago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit iNumeroitem;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iImportepago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.SearchLookUpEdit iIdtipocp;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdmediopago;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit iNumerotipocp;
        public DevExpress.XtraEditors.TextEdit iSerietipocp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit iComentario;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit iNumeromediopago;
        private DevExpress.XtraEditors.LookUpEdit iIdtipodocmov;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit iIdcpcompra;
    }
}