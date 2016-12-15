namespace WinFormsApp
{
    partial class TipocambioMntFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipocambioMntFrm));
            this.bmMantenimiento = new DevExpress.XtraBars.BarManager(this.components);
            this.BarMnt = new DevExpress.XtraBars.Bar();
            this.btnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrabarNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnLimpiarCampos = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pkIdEntidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.rIdtipomoneda = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iFechatipocambio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.nValorcomprasunat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.nValorventaventa = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultaTcSunat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionarTc = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIdtipomoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechatipocambio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechatipocambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValorcomprasunat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValorventaventa.Properties)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNuevo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabarCerrar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabarNuevo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLimpiarCampos, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnActualizar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCerrar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMnt.OptionsBar.UseWholeRow = true;
            this.BarMnt.Text = "Barra de herramientas";
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
            toolTipTitleItem1.Text = "Nuevo (Ctrl + N)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnNuevo.SuperTip = superToolTip1;
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
            toolTipTitleItem2.Text = "Grabar (Ctrl + G)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnGrabar.SuperTip = superToolTip2;
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
            toolTipTitleItem3.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnGrabarCerrar.SuperTip = superToolTip3;
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
            toolTipTitleItem4.Text = "Grabar y Nuevo (Ctrl + Ins)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnGrabarNuevo.SuperTip = superToolTip4;
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
            toolTipTitleItem5.Text = "Eliminar (Ctrl + E)\r\n";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnEliminar.SuperTip = superToolTip5;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Caption = "Limpiar campos";
            this.btnLimpiarCampos.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnLimpiarCampos.Id = 82;
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
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
            toolTipTitleItem6.Text = "Actualizar (F5)";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnActualizar.SuperTip = superToolTip6;
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
            toolTipTitleItem7.Text = "Salir de ventana (Ctrl + S)";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnCerrar.SuperTip = superToolTip7;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 183);
            this.barDockControlBottom.Size = new System.Drawing.Size(729, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 152);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(729, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 152);
            // 
            // pkIdEntidad
            // 
            this.pkIdEntidad.EditValue = "0";
            this.pkIdEntidad.Location = new System.Drawing.Point(91, 39);
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
            // rIdtipomoneda
            // 
            this.rIdtipomoneda.Location = new System.Drawing.Point(91, 91);
            this.rIdtipomoneda.MenuManager = this.bmMantenimiento;
            this.rIdtipomoneda.Name = "rIdtipomoneda";
            this.rIdtipomoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rIdtipomoneda.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.rIdtipomoneda.Properties.ReadOnly = true;
            this.rIdtipomoneda.Properties.View = this.gridView10;
            this.rIdtipomoneda.Size = new System.Drawing.Size(278, 20);
            this.rIdtipomoneda.TabIndex = 5;
            this.rIdtipomoneda.Tag = "Seleccione el tipo de moneda";
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn46,
            this.gridColumn47});
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Id.";
            this.gridColumn46.FieldName = "Idtipomoneda";
            this.gridColumn46.Name = "gridColumn46";
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "Moneda";
            this.gridColumn47.FieldName = "Nombretipomoneda";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 0;
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(12, 94);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(38, 13);
            this.labelControl22.TabIndex = 4;
            this.labelControl22.Text = "Moneda";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Fecha Doc.";
            // 
            // iFechatipocambio
            // 
            this.iFechatipocambio.EditValue = null;
            this.iFechatipocambio.Location = new System.Drawing.Point(91, 65);
            this.iFechatipocambio.MenuManager = this.bmMantenimiento;
            this.iFechatipocambio.Name = "iFechatipocambio";
            this.iFechatipocambio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechatipocambio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechatipocambio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.iFechatipocambio.Size = new System.Drawing.Size(97, 20);
            this.iFechatipocambio.TabIndex = 3;
            this.iFechatipocambio.Tag = "Ingrese la fecha del documento";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(9, 120);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(67, 13);
            this.labelControl15.TabIndex = 6;
            this.labelControl15.Text = "Compra sunat";
            // 
            // nValorcomprasunat
            // 
            this.nValorcomprasunat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nValorcomprasunat.Location = new System.Drawing.Point(91, 117);
            this.nValorcomprasunat.Name = "nValorcomprasunat";
            this.nValorcomprasunat.Properties.Appearance.Options.UseTextOptions = true;
            this.nValorcomprasunat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.nValorcomprasunat.Properties.Mask.EditMask = "n3";
            this.nValorcomprasunat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.nValorcomprasunat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.nValorcomprasunat.Size = new System.Drawing.Size(70, 20);
            this.nValorcomprasunat.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 146);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Venta sunat";
            // 
            // nValorventaventa
            // 
            this.nValorventaventa.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nValorventaventa.Location = new System.Drawing.Point(91, 143);
            this.nValorventaventa.Name = "nValorventaventa";
            this.nValorventaventa.Properties.Appearance.Options.UseTextOptions = true;
            this.nValorventaventa.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.nValorventaventa.Properties.Mask.EditMask = "n3";
            this.nValorventaventa.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.nValorventaventa.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.nValorventaventa.Size = new System.Drawing.Size(70, 20);
            this.nValorventaventa.TabIndex = 9;
            // 
            // btnConsultaTcSunat
            // 
            this.btnConsultaTcSunat.Location = new System.Drawing.Point(194, 63);
            this.btnConsultaTcSunat.Name = "btnConsultaTcSunat";
            this.btnConsultaTcSunat.Size = new System.Drawing.Size(135, 23);
            this.btnConsultaTcSunat.TabIndex = 17;
            this.btnConsultaTcSunat.TabStop = false;
            this.btnConsultaTcSunat.Text = "Tipo de cambio por Fecha";
            this.btnConsultaTcSunat.Click += new System.EventHandler(this.btnConsultaTcSunat_Click);
            // 
            // btnSeleccionarTc
            // 
            this.btnSeleccionarTc.Location = new System.Drawing.Point(335, 63);
            this.btnSeleccionarTc.Name = "btnSeleccionarTc";
            this.btnSeleccionarTc.Size = new System.Drawing.Size(135, 23);
            this.btnSeleccionarTc.TabIndex = 27;
            this.btnSeleccionarTc.TabStop = false;
            this.btnSeleccionarTc.Text = " Seleccionar Tipo Cambio";
            this.btnSeleccionarTc.Click += new System.EventHandler(this.btnSeleccionarTc_Click);
            // 
            // TipocambioMntFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 183);
            this.Controls.Add(this.btnSeleccionarTc);
            this.Controls.Add(this.btnConsultaTcSunat);
            this.Controls.Add(this.nValorventaventa);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.nValorcomprasunat);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iFechatipocambio);
            this.Controls.Add(this.rIdtipomoneda);
            this.Controls.Add(this.labelControl22);
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
            this.Name = "TipocambioMntFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de cambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TipocambioMntFrm_FormClosing);
            this.Load += new System.EventHandler(this.TipocambioMntFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TipocambioMntFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIdtipomoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechatipocambio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechatipocambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValorcomprasunat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nValorventaventa.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit pkIdEntidad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SearchLookUpEdit rIdtipomoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit iFechatipocambio;
        private DevExpress.XtraEditors.TextEdit nValorventaventa;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit nValorcomprasunat;
        private DevExpress.XtraEditors.SimpleButton btnConsultaTcSunat;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionarTc;

    }
}