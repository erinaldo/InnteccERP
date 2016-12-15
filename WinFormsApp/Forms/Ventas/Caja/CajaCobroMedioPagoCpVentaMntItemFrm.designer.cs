namespace WinFormsApp
{
    partial class CajaCobroMedioPagoCpVentaMntItemFrm
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
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CajaCobroMedioPagoCpVentaMntItemFrm));
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iRecibidomediopago = new DevExpress.XtraEditors.TextEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeromediopago = new DevExpress.XtraEditors.TextEdit();
            this.iNumerotipocp = new DevExpress.XtraEditors.TextEdit();
            this.iSerietipocp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIdmediopago = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iImportepago = new DevExpress.XtraEditors.TextEdit();
            this.iTipoCp = new DevExpress.XtraEditors.TextEdit();
            this.tpObservacion = new DevExpress.XtraTab.XtraTabPage();
            this.iComentario = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iTotalDocumento = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRecibidomediopago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeromediopago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmediopago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipoCp.Properties)).BeginInit();
            this.tpObservacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTotalDocumento.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(612, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 202);
            this.barDockControlBottom.Size = new System.Drawing.Size(612, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 171);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(612, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 171);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(612, 171);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto,
            this.tpObservacion});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.labelControl5);
            this.tpProducto.Controls.Add(this.iTotalDocumento);
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.iRecibidomediopago);
            this.tpProducto.Controls.Add(this.labelControl21);
            this.tpProducto.Controls.Add(this.iNumeromediopago);
            this.tpProducto.Controls.Add(this.iNumerotipocp);
            this.tpProducto.Controls.Add(this.iSerietipocp);
            this.tpProducto.Controls.Add(this.labelControl3);
            this.tpProducto.Controls.Add(this.iIdmediopago);
            this.tpProducto.Controls.Add(this.labelControl7);
            this.tpProducto.Controls.Add(this.labelControl2);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Controls.Add(this.labelControl4);
            this.tpProducto.Controls.Add(this.iImportepago);
            this.tpProducto.Controls.Add(this.iTipoCp);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(606, 143);
            this.tpProducto.Text = "Item Recibo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(306, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Recibido";
            this.labelControl1.Visible = false;
            // 
            // iRecibidomediopago
            // 
            this.iRecibidomediopago.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iRecibidomediopago.Location = new System.Drawing.Point(406, 90);
            this.iRecibidomediopago.Name = "iRecibidomediopago";
            this.iRecibidomediopago.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iRecibidomediopago.Properties.Appearance.Options.UseFont = true;
            this.iRecibidomediopago.Properties.Appearance.Options.UseTextOptions = true;
            this.iRecibidomediopago.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iRecibidomediopago.Properties.DisplayFormat.FormatString = "n2";
            this.iRecibidomediopago.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iRecibidomediopago.Properties.EditFormat.FormatString = "n2";
            this.iRecibidomediopago.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iRecibidomediopago.Properties.Mask.EditMask = "n";
            this.iRecibidomediopago.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iRecibidomediopago.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iRecibidomediopago.Size = new System.Drawing.Size(187, 20);
            this.iRecibidomediopago.TabIndex = 12;
            this.iRecibidomediopago.Visible = false;
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(10, 119);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(87, 13);
            this.labelControl21.TabIndex = 13;
            this.labelControl21.Text = "Número operación";
            // 
            // iNumeromediopago
            // 
            this.iNumeromediopago.Location = new System.Drawing.Point(110, 116);
            this.iNumeromediopago.Name = "iNumeromediopago";
            this.iNumeromediopago.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iNumeromediopago.Properties.MaxLength = 100;
            this.iNumeromediopago.Size = new System.Drawing.Size(483, 20);
            this.iNumeromediopago.TabIndex = 14;
            // 
            // iNumerotipocp
            // 
            this.iNumerotipocp.EditValue = "0";
            this.iNumerotipocp.Location = new System.Drawing.Point(155, 38);
            this.iNumerotipocp.Name = "iNumerotipocp";
            this.iNumerotipocp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iNumerotipocp.Properties.Appearance.Options.UseFont = true;
            this.iNumerotipocp.Properties.Mask.EditMask = "d8";
            this.iNumerotipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iNumerotipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iNumerotipocp.Properties.ReadOnly = true;
            this.iNumerotipocp.Size = new System.Drawing.Size(70, 20);
            this.iNumerotipocp.TabIndex = 6;
            this.iNumerotipocp.Tag = "Ingrese el Número de Documento";
            // 
            // iSerietipocp
            // 
            this.iSerietipocp.EditValue = "0";
            this.iSerietipocp.Location = new System.Drawing.Point(110, 38);
            this.iSerietipocp.Name = "iSerietipocp";
            this.iSerietipocp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iSerietipocp.Properties.Appearance.Options.UseFont = true;
            this.iSerietipocp.Properties.Appearance.Options.UseTextOptions = true;
            this.iSerietipocp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iSerietipocp.Properties.Mask.EditMask = "d4";
            this.iSerietipocp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iSerietipocp.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iSerietipocp.Properties.ReadOnly = true;
            this.iSerietipocp.Size = new System.Drawing.Size(39, 20);
            this.iSerietipocp.TabIndex = 5;
            this.iSerietipocp.Tag = "Ingrese el Número de serie";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Serie y número";
            // 
            // iIdmediopago
            // 
            this.iIdmediopago.Location = new System.Drawing.Point(110, 64);
            this.iIdmediopago.Name = "iIdmediopago";
            this.iIdmediopago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdmediopago.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdmediopago.Properties.View = this.gridView2;
            this.iIdmediopago.Size = new System.Drawing.Size(483, 20);
            this.iIdmediopago.TabIndex = 8;
            this.iIdmediopago.Tag = "Seleccione el medio de pago";
            this.iIdmediopago.EditValueChanged += new System.EventHandler(this.iIdmediopago_EditValueChanged);
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
            this.labelControl7.Location = new System.Drawing.Point(10, 67);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(55, 13);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Medio Pago";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(174, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tipo Comprobante";
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
            this.iNumeroitem.Location = new System.Drawing.Point(110, 12);
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
            this.labelControl4.Size = new System.Drawing.Size(65, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Importe pago";
            // 
            // iImportepago
            // 
            this.iImportepago.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iImportepago.Location = new System.Drawing.Point(110, 90);
            this.iImportepago.Name = "iImportepago";
            this.iImportepago.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iImportepago.Properties.Appearance.Options.UseFont = true;
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
            // iTipoCp
            // 
            this.iTipoCp.EditValue = "";
            this.iTipoCp.Location = new System.Drawing.Point(274, 13);
            this.iTipoCp.Name = "iTipoCp";
            this.iTipoCp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iTipoCp.Properties.Appearance.Options.UseFont = true;
            this.iTipoCp.Properties.NullText = "[EditValue is null]";
            this.iTipoCp.Properties.ReadOnly = true;
            this.iTipoCp.Size = new System.Drawing.Size(187, 20);
            this.iTipoCp.TabIndex = 3;
            this.iTipoCp.Tag = "Seleccione el tipo de documento";
            // 
            // tpObservacion
            // 
            this.tpObservacion.Controls.Add(this.iComentario);
            this.tpObservacion.Name = "tpObservacion";
            this.tpObservacion.Size = new System.Drawing.Size(606, 143);
            this.tpObservacion.Text = "Comentario";
            // 
            // iComentario
            // 
            this.iComentario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iComentario.Location = new System.Drawing.Point(0, 0);
            this.iComentario.Name = "iComentario";
            this.iComentario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iComentario.Size = new System.Drawing.Size(606, 143);
            this.iComentario.TabIndex = 17;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(231, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Importe";
            // 
            // iTotalDocumento
            // 
            this.iTotalDocumento.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iTotalDocumento.Location = new System.Drawing.Point(275, 39);
            this.iTotalDocumento.Name = "iTotalDocumento";
            this.iTotalDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iTotalDocumento.Properties.Appearance.Options.UseFont = true;
            this.iTotalDocumento.Properties.Appearance.Options.UseTextOptions = true;
            this.iTotalDocumento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iTotalDocumento.Properties.DisplayFormat.FormatString = "n2";
            this.iTotalDocumento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iTotalDocumento.Properties.EditFormat.FormatString = "n2";
            this.iTotalDocumento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iTotalDocumento.Properties.Mask.EditMask = "n";
            this.iTotalDocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iTotalDocumento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iTotalDocumento.Properties.ReadOnly = true;
            this.iTotalDocumento.Size = new System.Drawing.Size(104, 20);
            this.iTotalDocumento.TabIndex = 16;
            this.iTotalDocumento.TabStop = false;
            // 
            // CajaCobroMedioPagoCpVentaMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 202);
            this.Controls.Add(this.tcProductos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CajaCobroMedioPagoCpVentaMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de medio de pago";
            this.Load += new System.EventHandler(this.CajaCobroMedioPagoCpVentaMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCobroMedioPagoCpVentaMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRecibidomediopago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeromediopago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumerotipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerietipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmediopago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iImportepago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipoCp.Properties)).EndInit();
            this.tpObservacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTotalDocumento.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SearchLookUpEdit iIdmediopago;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit iNumerotipocp;
        public DevExpress.XtraEditors.TextEdit iSerietipocp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit iNumeromediopago;
        private DevExpress.XtraEditors.TextEdit iTipoCp;
        private DevExpress.XtraTab.XtraTabPage tpObservacion;
        private DevExpress.XtraEditors.MemoEdit iComentario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit iRecibidomediopago;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iTotalDocumento;
    }
}