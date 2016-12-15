namespace WinFormsApp
{
    partial class ProgramacioncitaMntItemVisorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramacioncitaMntItemVisorFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iHoraprogramacion = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bePaciente = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iIdpersona = new DevExpress.XtraEditors.TextEdit();
            this.iIdestadocita = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.riColorEstado = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iIdmotivocita = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iTiempoduracion = new DevExpress.XtraEditors.TimeSpanEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iHoraFin = new DevExpress.XtraEditors.TimeEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraprogramacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePaciente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdpersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdestadocita.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmotivocita.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTiempoduracion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraFin.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(514, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 177);
            this.barDockControlBottom.Size = new System.Drawing.Size(514, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 146);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(514, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 146);
            // 
            // iHoraprogramacion
            // 
            this.iHoraprogramacion.EditValue = new System.DateTime(2016, 8, 30, 0, 0, 0, 0);
            this.iHoraprogramacion.Location = new System.Drawing.Point(81, 46);
            this.iHoraprogramacion.MenuManager = this.bmMntItems;
            this.iHoraprogramacion.Name = "iHoraprogramacion";
            this.iHoraprogramacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iHoraprogramacion.Properties.Appearance.Options.UseFont = true;
            this.iHoraprogramacion.Properties.Appearance.Options.UseTextOptions = true;
            this.iHoraprogramacion.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHoraprogramacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iHoraprogramacion.Properties.Mask.EditMask = "t";
            this.iHoraprogramacion.Size = new System.Drawing.Size(100, 20);
            this.iHoraprogramacion.TabIndex = 1;
            this.iHoraprogramacion.Validating += new System.ComponentModel.CancelEventHandler(this.iHoraprogramacion_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Hora cita ";
            // 
            // bePaciente
            // 
            this.bePaciente.EditValue = "";
            this.bePaciente.Location = new System.Drawing.Point(81, 123);
            this.bePaciente.Name = "bePaciente";
            toolTipTitleItem3.Text = "Buscar Registro (F3)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            toolTipTitleItem4.Text = "Nuevo Registro (Ctrl + Ins)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            toolTipTitleItem5.Text = "Modificar Registro (Ctrl + M)";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.bePaciente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject1, "", null, superToolTip3, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.add, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)), serializableAppearanceObject2, "", null, superToolTip4, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Edit_12x12, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)), serializableAppearanceObject3, "", null, superToolTip5, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("bePaciente.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.bePaciente.Properties.ReadOnly = true;
            this.bePaciente.Size = new System.Drawing.Size(421, 22);
            this.bePaciente.TabIndex = 11;
            this.bePaciente.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bePaciente_ButtonClick);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(12, 127);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(41, 13);
            this.labelControl17.TabIndex = 10;
            this.labelControl17.Text = "Paciente";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Estado cita";
            // 
            // iIdpersona
            // 
            this.iIdpersona.Location = new System.Drawing.Point(81, 151);
            this.iIdpersona.Name = "iIdpersona";
            this.iIdpersona.Properties.AllowFocused = false;
            this.iIdpersona.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdpersona.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdpersona.Properties.ReadOnly = true;
            this.iIdpersona.Size = new System.Drawing.Size(56, 20);
            this.iIdpersona.TabIndex = 12;
            this.iIdpersona.TabStop = false;
            this.iIdpersona.Visible = false;
            this.iIdpersona.EditValueChanged += new System.EventHandler(this.iIdpersona_EditValueChanged);
            // 
            // iIdestadocita
            // 
            this.iIdestadocita.Location = new System.Drawing.Point(81, 72);
            this.iIdestadocita.MenuManager = this.bmMntItems;
            this.iIdestadocita.Name = "iIdestadocita";
            this.iIdestadocita.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdestadocita.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riColorEstado});
            this.iIdestadocita.Properties.View = this.searchLookUpEdit1View;
            this.iIdestadocita.Size = new System.Drawing.Size(421, 20);
            this.iIdestadocita.TabIndex = 7;
            // 
            // riColorEstado
            // 
            this.riColorEstado.AutoHeight = false;
            this.riColorEstado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riColorEstado.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riColorEstado.Name = "riColorEstado";
            this.riColorEstado.ShowWebSafeColors = true;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idestadocita";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Estado";
            this.gridColumn2.FieldName = "Nombreestadocita";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Color";
            this.gridColumn3.ColumnEdit = this.riColorEstado;
            this.gridColumn3.FieldName = "Colorestadocita";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Motivo cita";
            // 
            // iIdmotivocita
            // 
            this.iIdmotivocita.Location = new System.Drawing.Point(81, 97);
            this.iIdmotivocita.MenuManager = this.bmMntItems;
            this.iIdmotivocita.Name = "iIdmotivocita";
            this.iIdmotivocita.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdmotivocita.Properties.View = this.gridView1;
            this.iIdmotivocita.Size = new System.Drawing.Size(421, 20);
            this.iIdmotivocita.TabIndex = 9;
            this.iIdmotivocita.Validating += new System.ComponentModel.CancelEventHandler(this.iIdmotivocita_Validating);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Id.";
            this.gridColumn4.FieldName = "Idarticulo";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Motivo";
            this.gridColumn5.FieldName = "Nombrearticulo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(184, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Duración";
            // 
            // iTiempoduracion
            // 
            this.iTiempoduracion.EditValue = System.TimeSpan.Parse("00:00:00");
            this.iTiempoduracion.Location = new System.Drawing.Point(232, 46);
            this.iTiempoduracion.Name = "iTiempoduracion";
            this.iTiempoduracion.Properties.AllowEditDays = false;
            this.iTiempoduracion.Properties.AllowEditSeconds = false;
            this.iTiempoduracion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iTiempoduracion.Properties.Mask.EditMask = "HH:mm";
            this.iTiempoduracion.Properties.ReadOnly = true;
            this.iTiempoduracion.Size = new System.Drawing.Size(59, 20);
            this.iTiempoduracion.TabIndex = 3;
            this.iTiempoduracion.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(296, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Hora fin";
            // 
            // iHoraFin
            // 
            this.iHoraFin.EditValue = new System.DateTime(2016, 8, 30, 0, 0, 0, 0);
            this.iHoraFin.Location = new System.Drawing.Point(340, 46);
            this.iHoraFin.MenuManager = this.bmMntItems;
            this.iHoraFin.Name = "iHoraFin";
            this.iHoraFin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iHoraFin.Properties.Appearance.Options.UseFont = true;
            this.iHoraFin.Properties.Appearance.Options.UseTextOptions = true;
            this.iHoraFin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHoraFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iHoraFin.Properties.Mask.EditMask = "t";
            this.iHoraFin.Size = new System.Drawing.Size(100, 20);
            this.iHoraFin.TabIndex = 5;
            this.iHoraFin.TabStop = false;
            this.iHoraFin.Validating += new System.ComponentModel.CancelEventHandler(this.iHoraFin_Validating);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Duración";
            this.gridColumn6.FieldName = "Tiempoduracion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // ProgramacioncitaMntItemVisorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 177);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iHoraFin);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iTiempoduracion);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iIdmotivocita);
            this.Controls.Add(this.iIdestadocita);
            this.Controls.Add(this.iIdpersona);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.bePaciente);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iHoraprogramacion);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramacioncitaMntItemVisorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cita";
            this.Load += new System.EventHandler(this.ProgramacioncitaMntItemVisorFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProgramacioncitaMntItemVisorFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraprogramacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePaciente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdpersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdestadocita.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riColorEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmotivocita.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTiempoduracion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraFin.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit iHoraprogramacion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit bePaciente;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.TextEdit iIdpersona;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdestadocita;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit riColorEstado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdmotivocita;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TimeEdit iHoraFin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TimeSpanEdit iTiempoduracion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}