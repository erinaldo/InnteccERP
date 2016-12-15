namespace WinFormsApp
{
    partial class CentrodecostoMntFrm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CentrodecostoMntFrm));
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iDescripcioncentrodecosto = new DevExpress.XtraEditors.TextEdit();
            this.pkIdEntidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.iCodigocentrodecosto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iEsactivo = new DevExpress.XtraEditors.CheckEdit();
            this.iIdempresa = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iEscentrodecosto = new DevExpress.XtraEditors.CheckEdit();
            this.iEscentrodebeneficio = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescripcioncentrodecosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigocentrodecosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEsactivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEscentrodecosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEscentrodebeneficio.Properties)).BeginInit();
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 169);
            this.barDockControlBottom.Size = new System.Drawing.Size(729, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 138);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(729, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 138);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 120);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(132, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Descripción centro de costo";
            // 
            // iDescripcioncentrodecosto
            // 
            this.iDescripcioncentrodecosto.Location = new System.Drawing.Point(151, 117);
            this.iDescripcioncentrodecosto.MenuManager = this.bmMantenimiento;
            this.iDescripcioncentrodecosto.Name = "iDescripcioncentrodecosto";
            this.iDescripcioncentrodecosto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iDescripcioncentrodecosto.Properties.MaxLength = 100;
            this.iDescripcioncentrodecosto.Size = new System.Drawing.Size(459, 20);
            this.iDescripcioncentrodecosto.TabIndex = 8;
            this.iDescripcioncentrodecosto.Tag = "Ingrese el nombre del tipo de formato";
            // 
            // pkIdEntidad
            // 
            this.pkIdEntidad.EditValue = "0";
            this.pkIdEntidad.Location = new System.Drawing.Point(151, 39);
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
            // iCodigocentrodecosto
            // 
            this.iCodigocentrodecosto.Location = new System.Drawing.Point(151, 91);
            this.iCodigocentrodecosto.MenuManager = this.bmMantenimiento;
            this.iCodigocentrodecosto.Name = "iCodigocentrodecosto";
            this.iCodigocentrodecosto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigocentrodecosto.Properties.MaxLength = 15;
            this.iCodigocentrodecosto.Size = new System.Drawing.Size(150, 20);
            this.iCodigocentrodecosto.TabIndex = 6;
            this.iCodigocentrodecosto.Tag = "Ingrese el código";
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.iCodigocentrodecosto, conditionValidationRule1);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Código";
            // 
            // iEsactivo
            // 
            this.iEsactivo.Location = new System.Drawing.Point(216, 39);
            this.iEsactivo.MenuManager = this.bmMantenimiento;
            this.iEsactivo.Name = "iEsactivo";
            this.iEsactivo.Properties.Caption = "Activo";
            this.iEsactivo.Size = new System.Drawing.Size(75, 19);
            this.iEsactivo.TabIndex = 2;
            // 
            // iIdempresa
            // 
            this.iIdempresa.Enabled = false;
            this.iIdempresa.Location = new System.Drawing.Point(151, 65);
            this.iIdempresa.MenuManager = this.bmMantenimiento;
            this.iIdempresa.Name = "iIdempresa";
            this.iIdempresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdempresa.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdempresa.Properties.View = this.gridView3;
            this.iIdempresa.Size = new System.Drawing.Size(459, 20);
            this.iIdempresa.TabIndex = 4;
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
            this.labelControl4.Location = new System.Drawing.Point(12, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Empresa";
            // 
            // iEscentrodecosto
            // 
            this.iEscentrodecosto.Location = new System.Drawing.Point(151, 143);
            this.iEscentrodecosto.MenuManager = this.bmMantenimiento;
            this.iEscentrodecosto.Name = "iEscentrodecosto";
            this.iEscentrodecosto.Properties.Caption = "Centro de costo";
            this.iEscentrodecosto.Size = new System.Drawing.Size(118, 19);
            this.iEscentrodecosto.TabIndex = 9;
            // 
            // iEscentrodebeneficio
            // 
            this.iEscentrodebeneficio.Location = new System.Drawing.Point(287, 143);
            this.iEscentrodebeneficio.MenuManager = this.bmMantenimiento;
            this.iEscentrodebeneficio.Name = "iEscentrodebeneficio";
            this.iEscentrodebeneficio.Properties.Caption = "Centro de beneficio";
            this.iEscentrodebeneficio.Size = new System.Drawing.Size(118, 19);
            this.iEscentrodebeneficio.TabIndex = 10;
            // 
            // CentrodecostoMntFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 169);
            this.Controls.Add(this.iEscentrodebeneficio);
            this.Controls.Add(this.iEscentrodecosto);
            this.Controls.Add(this.iIdempresa);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iEsactivo);
            this.Controls.Add(this.iCodigocentrodecosto);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iDescripcioncentrodecosto);
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
            this.Name = "CentrodecostoMntFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Centros de costo / Beneficio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CentrodecostoMntFrm_FormClosing);
            this.Load += new System.EventHandler(this.CentrodecostoMntFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CentrodecostoMntFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescripcioncentrodecosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkIdEntidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigocentrodecosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEsactivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEscentrodecosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEscentrodebeneficio.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit iDescripcioncentrodecosto;
        private DevExpress.XtraEditors.TextEdit pkIdEntidad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit iCodigocentrodecosto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit iEsactivo;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdempresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit iEscentrodebeneficio;
        private DevExpress.XtraEditors.CheckEdit iEscentrodecosto;

    }
}