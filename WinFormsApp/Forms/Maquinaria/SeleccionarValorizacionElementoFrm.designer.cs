namespace WinFormsApp
{
    partial class SeleccionarValorizacionElementoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarValorizacionElementoFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnImportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cboBuscarPor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.iNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rSerie = new DevExpress.XtraEditors.TextEdit();
            this.iIdtipocp = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iIdsucursal = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuscarPor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
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
            this.btnImportar,
            this.btnCancelarItem,
            this.btnConsultar,
            this.btnCerrar});
            this.bmMntItems.MaxItemId = 5;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImportar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelarItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnConsultar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCerrar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMntItems.OptionsBar.UseWholeRow = true;
            this.barMntItems.Text = "Tools";
            // 
            // btnImportar
            // 
            this.btnImportar.Caption = "Seleccionar";
            this.btnImportar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImportar.Glyph")));
            this.btnImportar.Id = 0;
            this.btnImportar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnImportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImportar.LargeGlyph")));
            this.btnImportar.Name = "btnImportar";
            toolTipTitleItem1.Text = "Seleccionar (Ctrl + Enter)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnImportar.SuperTip = superToolTip1;
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
            // btnConsultar
            // 
            this.btnConsultar.Caption = "Consultar";
            this.btnConsultar.Glyph = global::WinFormsApp.Properties.Resources.Action_Search;
            this.btnConsultar.Id = 3;
            this.btnConsultar.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.btnConsultar.Name = "btnConsultar";
            toolTipTitleItem3.Text = "Consultar (F3)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnConsultar.SuperTip = superToolTip3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCerrar.Caption = "Salir";
            this.btnCerrar.Glyph = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnCerrar.Id = 4;
            this.btnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCerrar.Name = "btnCerrar";
            toolTipTitleItem4.Text = "Salir de la venta";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnCerrar.SuperTip = superToolTip4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1075, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 403);
            this.barDockControlBottom.Size = new System.Drawing.Size(1075, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 372);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1075, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 372);
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.Location = new System.Drawing.Point(308, 37);
            this.cboBuscarPor.MenuManager = this.bmMntItems;
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBuscarPor.Properties.Items.AddRange(new object[] {
            "TODO",
            "N° DE VALORIZACION"});
            this.cboBuscarPor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBuscarPor.Size = new System.Drawing.Size(187, 20);
            this.cboBuscarPor.TabIndex = 5;
            this.cboBuscarPor.SelectedIndexChanged += new System.EventHandler(this.cboBuscarPor_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(251, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Buscar por";
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Location = new System.Drawing.Point(12, 63);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit4,
            this.riDocumento,
            this.tiTotal});
            this.gcConsulta.Size = new System.Drawing.Size(1051, 327);
            this.gcConsulta.TabIndex = 18;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn22,
            this.gridColumn17});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsCustomization.AllowGroup = false;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            this.gvConsulta.OptionsView.ShowGroupPanel = false;
            this.gvConsulta.OptionsView.ShowViewCaption = true;
            this.gvConsulta.ViewCaption = "Listado de valorizaciones";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Id.";
            this.gridColumn11.FieldName = "Idvalorizacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 67;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tipo";
            this.gridColumn12.FieldName = "Nombretipoformato";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "N° Registro";
            this.gridColumn14.ColumnEdit = this.riDocumento;
            this.gridColumn14.FieldName = "Numerovalorizacion";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // riDocumento
            // 
            this.riDocumento.AutoHeight = false;
            this.riDocumento.Mask.EditMask = "d8";
            this.riDocumento.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riDocumento.Name = "riDocumento";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Fecha";
            this.gridColumn15.FieldName = "Fechavalorizacion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Cliente";
            this.gridColumn16.FieldName = "Razonsocial";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Total";
            this.gridColumn22.ColumnEdit = this.tiTotal;
            this.gridColumn22.FieldName = "Totaldocumento";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 6;
            // 
            // tiTotal
            // 
            this.tiTotal.AutoHeight = false;
            this.tiTotal.Mask.EditMask = "n2";
            this.tiTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tiTotal.Name = "tiTotal";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Moneda";
            this.gridColumn17.FieldName = "Simbolomoneda";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // iNumero
            // 
            this.iNumero.EditValue = "0";
            this.iNumero.Location = new System.Drawing.Point(869, 37);
            this.iNumero.Name = "iNumero";
            this.iNumero.Properties.Mask.EditMask = "d8";
            this.iNumero.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iNumero.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iNumero.Size = new System.Drawing.Size(66, 20);
            this.iNumero.TabIndex = 41;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(744, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 13);
            this.labelControl3.TabIndex = 39;
            this.labelControl3.Text = "Serie y número";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(501, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Tipo doc.";
            // 
            // rSerie
            // 
            this.rSerie.EditValue = "0";
            this.rSerie.Location = new System.Drawing.Point(822, 37);
            this.rSerie.Name = "rSerie";
            this.rSerie.Properties.Appearance.Options.UseTextOptions = true;
            this.rSerie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rSerie.Properties.Mask.EditMask = "d4";
            this.rSerie.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rSerie.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rSerie.Properties.ReadOnly = true;
            this.rSerie.Size = new System.Drawing.Size(41, 20);
            this.rSerie.TabIndex = 40;
            // 
            // iIdtipocp
            // 
            this.iIdtipocp.Location = new System.Drawing.Point(551, 37);
            this.iIdtipocp.Name = "iIdtipocp";
            this.iIdtipocp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipocp.Properties.View = this.searchLookUpEdit1View;
            this.iIdtipocp.Size = new System.Drawing.Size(187, 20);
            this.iIdtipocp.TabIndex = 38;
            this.iIdtipocp.Tag = "Seleccione el tipo de documento";
            this.iIdtipocp.EditValueChanged += new System.EventHandler(this.iIdtipocp_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn29});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id.";
            this.gridColumn7.FieldName = "Idtipocp";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tipo doc.";
            this.gridColumn8.FieldName = "Nombretipocp";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Serie";
            this.gridColumn29.FieldName = "Seriecp";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 1;
            // 
            // iIdsucursal
            // 
            this.iIdsucursal.Location = new System.Drawing.Point(58, 37);
            this.iIdsucursal.Name = "iIdsucursal";
            this.iIdsucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdsucursal.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdsucursal.Properties.View = this.gridView8;
            this.iIdsucursal.Size = new System.Drawing.Size(187, 20);
            this.iIdsucursal.TabIndex = 61;
            this.iIdsucursal.TabStop = false;
            this.iIdsucursal.EditValueChanged += new System.EventHandler(this.iIdsucursal_EditValueChanged);
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41});
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Id.";
            this.gridColumn39.FieldName = "Idsucursal";
            this.gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Código";
            this.gridColumn40.FieldName = "Codigosucursal";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 0;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "Sucursal";
            this.gridColumn41.FieldName = "Nombresucursal";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 1;
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(12, 40);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(40, 13);
            this.labelControl26.TabIndex = 62;
            this.labelControl26.Text = "Sucursal";
            // 
            // SeleccionarValorizacionElementoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 403);
            this.Controls.Add(this.iIdsucursal);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.iNumero);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.rSerie);
            this.Controls.Add(this.iIdtipocp);
            this.Controls.Add(this.gcConsulta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboBuscarPor);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarValorizacionElementoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar valorización";
            this.Load += new System.EventHandler(this.SeleccionarValorizacionElementoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SeleccionarValorizacionElementoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuscarPor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipocp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmMntItems;
        private DevExpress.XtraBars.Bar barMntItems;
        private DevExpress.XtraBars.BarButtonItem btnImportar;
        private DevExpress.XtraBars.BarButtonItem btnCancelarItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboBuscarPor;
        private DevExpress.XtraBars.BarButtonItem btnConsultar;
        private DevExpress.XtraBars.BarButtonItem btnCerrar;
        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tiTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.TextEdit iNumero;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit rSerie;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipocp;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdsucursal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}