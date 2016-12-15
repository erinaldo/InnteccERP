namespace WinFormsApp
{
    partial class GrupousuarioMntFrm
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrupousuarioMntFrm));
            this.bmMantenimiento = new DevExpress.XtraBars.BarManager(this.components);
            this.BarMnt = new DevExpress.XtraBars.Bar();
            this.btnGrabarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabarNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnLimpiarCampos = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iNombregrupo = new DevExpress.XtraEditors.TextEdit();
            this.pkIdEntidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpItemspagina = new DevExpress.XtraTab.XtraTabPage();
            this.gcDetDato = new DevExpress.XtraGrid.GridControl();
            this.gvDetDato = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.iIdempresa = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombregrupo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tpItemspagina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetDato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetDato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // bmMantenimiento
            // 
            this.bmMantenimiento.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarMnt});
            this.bmMantenimiento.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Mantenimiento", new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5")),
            new DevExpress.XtraBars.BarManagerCategory("Navegación", new System.Guid("914e515b-0bf8-4995-97b2-cce8dc1d7479"))});
            this.bmMantenimiento.DockControls.Add(this.barDockControlTop);
            this.bmMantenimiento.DockControls.Add(this.barDockControlBottom);
            this.bmMantenimiento.DockControls.Add(this.barDockControlLeft);
            this.bmMantenimiento.DockControls.Add(this.barDockControlRight);
            this.bmMantenimiento.Form = this;
            this.bmMantenimiento.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNuevo,
            this.btnGrabar,
            this.btnGrabarCerrar,
            this.btnGrabarNuevo,
            this.btnLimpiarCampos,
            this.btnEliminar,
            this.btnCerrar,
            this.btnActualizar});
            this.bmMantenimiento.MaxItemId = 84;
            this.bmMantenimiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmMantenimiento_ItemClick);
            // 
            // BarMnt
            // 
            this.BarMnt.BarName = "Tools Mantenimiento";
            this.BarMnt.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)(((((DevExpress.XtraBars.BarCanDockStyle.Left | DevExpress.XtraBars.BarCanDockStyle.Top) 
            | DevExpress.XtraBars.BarCanDockStyle.Right) 
            | DevExpress.XtraBars.BarCanDockStyle.Bottom) 
            | DevExpress.XtraBars.BarCanDockStyle.Standalone)));
            this.BarMnt.DockCol = 0;
            this.BarMnt.DockRow = 0;
            this.BarMnt.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMnt.FloatLocation = new System.Drawing.Point(376, 165);
            this.BarMnt.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabarCerrar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCerrar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMnt.OptionsBar.UseWholeRow = true;
            this.BarMnt.Text = "Barra de herramientas";
            // 
            // btnGrabarCerrar
            // 
            this.btnGrabarCerrar.Caption = "Grabar y cerrar";
            this.btnGrabarCerrar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnGrabarCerrar.Glyph = global::WinFormsApp.Properties.Resources.Action_Save_Close;
            this.btnGrabarCerrar.Id = 79;
            this.btnGrabarCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnGrabarCerrar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Save_Close_32x32;
            this.btnGrabarCerrar.Name = "btnGrabarCerrar";
            toolTipTitleItem1.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnGrabarCerrar.SuperTip = superToolTip1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Caption = "Salir";
            this.btnCerrar.CategoryGuid = new System.Guid("914e515b-0bf8-4995-97b2-cce8dc1d7479");
            this.btnCerrar.Glyph = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnCerrar.Id = 75;
            this.btnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCerrar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Close_32x32;
            this.btnCerrar.Name = "btnCerrar";
            toolTipTitleItem2.Text = "Salir de ventana (Ctrl + S)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnCerrar.SuperTip = superToolTip2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(729, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 410);
            this.barDockControlBottom.Size = new System.Drawing.Size(729, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 379);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(729, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 379);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnNuevo.Glyph = global::WinFormsApp.Properties.Resources.Action_New;
            this.btnNuevo.Id = 55;
            this.btnNuevo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNuevo.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_New_32x32;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ShortcutKeyDisplayString = "Ctrl +N";
            toolTipTitleItem3.Text = "Nuevo (Ctrl + N)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnNuevo.SuperTip = superToolTip3;
            this.btnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Caption = "Grabar";
            this.btnGrabar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnGrabar.Glyph = global::WinFormsApp.Properties.Resources.Action_Save;
            this.btnGrabar.Id = 78;
            this.btnGrabar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G));
            this.btnGrabar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Save_32x32;
            this.btnGrabar.Name = "btnGrabar";
            toolTipTitleItem4.Text = "Grabar (Ctrl + G)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnGrabar.SuperTip = superToolTip4;
            this.btnGrabar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnGrabarNuevo
            // 
            this.btnGrabarNuevo.Caption = "Grabar y nuevo";
            this.btnGrabarNuevo.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnGrabarNuevo.Glyph = global::WinFormsApp.Properties.Resources.Action_Save_New;
            this.btnGrabarNuevo.Id = 80;
            this.btnGrabarNuevo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert));
            this.btnGrabarNuevo.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Save_New_32x32;
            this.btnGrabarNuevo.Name = "btnGrabarNuevo";
            toolTipTitleItem5.Text = "Grabar y Nuevo (Ctrl + Ins)";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnGrabarNuevo.SuperTip = superToolTip5;
            this.btnGrabarNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Caption = "Limpiar campos";
            this.btnLimpiarCampos.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnLimpiarCampos.Id = 82;
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnEliminar.Glyph = global::WinFormsApp.Properties.Resources.Action_Delete;
            this.btnEliminar.Id = 57;
            this.btnEliminar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnEliminar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Delete_32x32;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ShortcutKeyDisplayString = "Ctrl + E";
            toolTipTitleItem6.Text = "Eliminar (Ctrl + E)\r\n";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnEliminar.SuperTip = superToolTip6;
            this.btnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnActualizar.Glyph = global::WinFormsApp.Properties.Resources.Action_Refresh;
            this.btnActualizar.Id = 77;
            this.btnActualizar.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnActualizar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Refresh_32x32;
            this.btnActualizar.Name = "btnActualizar";
            toolTipTitleItem7.Text = "Actualizar (F5)";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnActualizar.SuperTip = superToolTip7;
            this.btnActualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 66);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Nombre Grupo";
            // 
            // iNombregrupo
            // 
            this.iNombregrupo.Location = new System.Drawing.Point(125, 63);
            this.iNombregrupo.MenuManager = this.bmMantenimiento;
            this.iNombregrupo.Name = "iNombregrupo";
            this.iNombregrupo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iNombregrupo.Properties.MaxLength = 50;
            this.iNombregrupo.Size = new System.Drawing.Size(459, 20);
            this.iNombregrupo.TabIndex = 3;
            this.iNombregrupo.Tag = "Ingrese el nombre del grupo";
            // 
            // pkIdEntidad
            // 
            this.pkIdEntidad.EditValue = "0";
            this.pkIdEntidad.Location = new System.Drawing.Point(125, 39);
            this.pkIdEntidad.MenuManager = this.bmMantenimiento;
            this.pkIdEntidad.Name = "pkIdEntidad";
            this.pkIdEntidad.Properties.AllowFocused = false;
            this.pkIdEntidad.Properties.Appearance.Options.UseTextOptions = true;
            this.pkIdEntidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.pkIdEntidad.Properties.ReadOnly = true;
            this.pkIdEntidad.Size = new System.Drawing.Size(59, 20);
            this.pkIdEntidad.TabIndex = 1;
            this.pkIdEntidad.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Id.";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(10, 118);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpItemspagina;
            this.xtraTabControl1.Size = new System.Drawing.Size(719, 286);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpItemspagina});
            // 
            // tpItemspagina
            // 
            this.tpItemspagina.Controls.Add(this.gcDetDato);
            this.tpItemspagina.Name = "tpItemspagina";
            this.tpItemspagina.Size = new System.Drawing.Size(713, 258);
            this.tpItemspagina.Text = "Permisos de Grupo";
            // 
            // gcDetDato
            // 
            this.gcDetDato.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDetDato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetDato.Location = new System.Drawing.Point(0, 0);
            this.gcDetDato.MainView = this.gvDetDato;
            this.gcDetDato.MenuManager = this.bmMantenimiento;
            this.gcDetDato.Name = "gcDetDato";
            this.gcDetDato.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riActivo});
            this.gcDetDato.Size = new System.Drawing.Size(713, 258);
            this.gcDetDato.TabIndex = 0;
            this.gcDetDato.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetDato});
            // 
            // gvDetDato
            // 
            this.gvDetDato.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn22,
            this.gridColumn19,
            this.gridColumn1});
            this.gvDetDato.GridControl = this.gcDetDato;
            this.gvDetDato.GroupCount = 1;
            this.gvDetDato.Name = "gvDetDato";
            this.gvDetDato.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvDetDato.OptionsView.ColumnAutoWidth = false;
            this.gvDetDato.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvDetDato.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDetDato.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetDato_CellValueChanged);
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Id.";
            this.gridColumn23.FieldName = "Idpaginaitem";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 43;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Pagina";
            this.gridColumn22.FieldName = "Titulopagina";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Item Pagina";
            this.gridColumn19.FieldName = "Titulopaginaitem";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Seleccionar";
            this.gridColumn1.ColumnEdit = this.riActivo;
            this.gridColumn1.FieldName = "Activo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // riActivo
            // 
            this.riActivo.AutoHeight = false;
            this.riActivo.Name = "riActivo";
            this.riActivo.EditValueChanged += new System.EventHandler(this.riActivo_EditValueChanged);
            // 
            // iIdempresa
            // 
            this.iIdempresa.Enabled = false;
            this.iIdempresa.Location = new System.Drawing.Point(125, 89);
            this.iIdempresa.MenuManager = this.bmMantenimiento;
            this.iIdempresa.Name = "iIdempresa";
            this.iIdempresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdempresa.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdempresa.Properties.View = this.gridView3;
            this.iIdempresa.Size = new System.Drawing.Size(459, 20);
            this.iIdempresa.TabIndex = 5;
            this.iIdempresa.Tag = "Seleccione la empresa";
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
            this.gridColumn10.FieldName = "Idempresa";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Empresa";
            this.gridColumn11.FieldName = "Razonsocial";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 92);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Empresa";
            // 
            // GrupousuarioMntFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 410);
            this.Controls.Add(this.iIdempresa);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.iNombregrupo);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.pkIdEntidad);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "GrupousuarioMntFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de grupos de usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GrupousuarioMntFrm_FormClosing);
            this.Load += new System.EventHandler(this.GrupousuarioMntFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrupousuarioMntFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombregrupo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tpItemspagina.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetDato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetDato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmMantenimiento;
        private DevExpress.XtraBars.Bar BarMnt;
        private DevExpress.XtraBars.BarButtonItem btnNuevo;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.BarButtonItem btnCerrar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnGrabar;
        private DevExpress.XtraBars.BarButtonItem btnGrabarCerrar;
        private DevExpress.XtraBars.BarButtonItem btnGrabarNuevo;
        private DevExpress.XtraBars.BarButtonItem btnLimpiarCampos;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iNombregrupo;
        private DevExpress.XtraEditors.TextEdit pkIdEntidad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpItemspagina;
        private DevExpress.XtraGrid.GridControl gcDetDato;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetDato;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riActivo;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdempresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LabelControl labelControl4;

    }
}