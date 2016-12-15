namespace WinFormsApp
{
    partial class ValorizacionproveedorMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValorizacionproveedorMntItemFrm));
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.iIdcentrodecosto = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.iDiastrabajo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.iHorometrominimo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iHorometrorealdia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.iDescuentohorometro = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.iHorometrodia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iHorometrofinal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iTurno = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.iHorometroinicio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdcentrodecosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiastrabajo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrominimo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrorealdia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescuentohorometro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrodia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrofinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTurno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometroinicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(593, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 221);
            this.barDockControlBottom.Size = new System.Drawing.Size(593, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 190);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(593, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 190);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(593, 190);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.labelControl3);
            this.tpProducto.Controls.Add(this.iObservaciones);
            this.tpProducto.Controls.Add(this.iIdcentrodecosto);
            this.tpProducto.Controls.Add(this.labelControl16);
            this.tpProducto.Controls.Add(this.labelControl14);
            this.tpProducto.Controls.Add(this.iDiastrabajo);
            this.tpProducto.Controls.Add(this.labelControl11);
            this.tpProducto.Controls.Add(this.iHorometrominimo);
            this.tpProducto.Controls.Add(this.labelControl8);
            this.tpProducto.Controls.Add(this.iHorometrorealdia);
            this.tpProducto.Controls.Add(this.labelControl7);
            this.tpProducto.Controls.Add(this.iDescuentohorometro);
            this.tpProducto.Controls.Add(this.labelControl6);
            this.tpProducto.Controls.Add(this.iHorometrodia);
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.iHorometrofinal);
            this.tpProducto.Controls.Add(this.labelControl2);
            this.tpProducto.Controls.Add(this.iTurno);
            this.tpProducto.Controls.Add(this.labelControl5);
            this.tpProducto.Controls.Add(this.iFecha);
            this.tpProducto.Controls.Add(this.labelControl17);
            this.tpProducto.Controls.Add(this.iHorometroinicio);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(587, 162);
            this.tpProducto.Text = "Item Cotizacion";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 116);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 64;
            this.labelControl3.Text = "Obsevaciones";
            // 
            // iObservaciones
            // 
            this.iObservaciones.Location = new System.Drawing.Point(94, 112);
            this.iObservaciones.Name = "iObservaciones";
            this.iObservaciones.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iObservaciones.Size = new System.Drawing.Size(483, 40);
            this.iObservaciones.TabIndex = 11;
            // 
            // iIdcentrodecosto
            // 
            this.iIdcentrodecosto.Location = new System.Drawing.Point(94, 86);
            this.iIdcentrodecosto.Name = "iIdcentrodecosto";
            this.iIdcentrodecosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdcentrodecosto.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdcentrodecosto.Properties.View = this.gridView1;
            this.iIdcentrodecosto.Size = new System.Drawing.Size(483, 20);
            this.iIdcentrodecosto.TabIndex = 10;
            this.iIdcentrodecosto.Tag = "Seleccione el centro de costo";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idcentrodecosto";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Código";
            this.gridColumn2.FieldName = "Codigocentrodecosto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "Descripcioncentrodecosto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(11, 89);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(77, 13);
            this.labelControl16.TabIndex = 62;
            this.labelControl16.Text = "Centro de costo";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(289, 67);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(51, 13);
            this.labelControl14.TabIndex = 60;
            this.labelControl14.Text = "D. Trabajo";
            // 
            // iDiastrabajo
            // 
            this.iDiastrabajo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iDiastrabajo.Enabled = false;
            this.iDiastrabajo.Location = new System.Drawing.Point(345, 63);
            this.iDiastrabajo.Name = "iDiastrabajo";
            this.iDiastrabajo.Properties.Appearance.Options.UseTextOptions = true;
            this.iDiastrabajo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iDiastrabajo.Properties.Mask.EditMask = "n";
            this.iDiastrabajo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iDiastrabajo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iDiastrabajo.Size = new System.Drawing.Size(70, 20);
            this.iDiastrabajo.TabIndex = 9;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(168, 67);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(34, 13);
            this.labelControl11.TabIndex = 58;
            this.labelControl11.Text = "H. Min.";
            // 
            // iHorometrominimo
            // 
            this.iHorometrominimo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iHorometrominimo.Location = new System.Drawing.Point(214, 64);
            this.iHorometrominimo.Name = "iHorometrominimo";
            this.iHorometrominimo.Properties.Appearance.Options.UseTextOptions = true;
            this.iHorometrominimo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHorometrominimo.Properties.Mask.EditMask = "n";
            this.iHorometrominimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iHorometrominimo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iHorometrominimo.Size = new System.Drawing.Size(70, 20);
            this.iHorometrominimo.TabIndex = 8;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 65);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(32, 13);
            this.labelControl8.TabIndex = 56;
            this.labelControl8.Text = "H. real";
            // 
            // iHorometrorealdia
            // 
            this.iHorometrorealdia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iHorometrorealdia.Enabled = false;
            this.iHorometrorealdia.Location = new System.Drawing.Point(94, 62);
            this.iHorometrorealdia.Name = "iHorometrorealdia";
            this.iHorometrorealdia.Properties.Appearance.Options.UseTextOptions = true;
            this.iHorometrorealdia.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHorometrorealdia.Properties.Mask.EditMask = "n";
            this.iHorometrorealdia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iHorometrorealdia.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iHorometrorealdia.Size = new System.Drawing.Size(70, 20);
            this.iHorometrorealdia.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(406, 41);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 54;
            this.labelControl7.Text = "H. Desc.";
            // 
            // iDescuentohorometro
            // 
            this.iDescuentohorometro.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iDescuentohorometro.Location = new System.Drawing.Point(452, 38);
            this.iDescuentohorometro.Name = "iDescuentohorometro";
            this.iDescuentohorometro.Properties.Appearance.Options.UseTextOptions = true;
            this.iDescuentohorometro.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iDescuentohorometro.Properties.Mask.EditMask = "n";
            this.iDescuentohorometro.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iDescuentohorometro.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iDescuentohorometro.Size = new System.Drawing.Size(70, 20);
            this.iDescuentohorometro.TabIndex = 6;
            this.iDescuentohorometro.EditValueChanged += new System.EventHandler(this.CalcularTotal);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(296, 40);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 13);
            this.labelControl6.TabIndex = 52;
            this.labelControl6.Text = "H. dia";
            // 
            // iHorometrodia
            // 
            this.iHorometrodia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iHorometrodia.Enabled = false;
            this.iHorometrodia.Location = new System.Drawing.Point(327, 37);
            this.iHorometrodia.Name = "iHorometrodia";
            this.iHorometrodia.Properties.Appearance.Options.UseTextOptions = true;
            this.iHorometrodia.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHorometrodia.Properties.Mask.EditMask = "n";
            this.iHorometrodia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iHorometrodia.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iHorometrodia.Size = new System.Drawing.Size(70, 20);
            this.iHorometrodia.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(168, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 50;
            this.labelControl1.Text = "H. Final";
            // 
            // iHorometrofinal
            // 
            this.iHorometrofinal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iHorometrofinal.Location = new System.Drawing.Point(214, 38);
            this.iHorometrofinal.Name = "iHorometrofinal";
            this.iHorometrofinal.Properties.Appearance.Options.UseTextOptions = true;
            this.iHorometrofinal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHorometrofinal.Properties.Mask.EditMask = "n";
            this.iHorometrofinal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iHorometrofinal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iHorometrofinal.Size = new System.Drawing.Size(70, 20);
            this.iHorometrofinal.TabIndex = 4;
            this.iHorometrofinal.EditValueChanged += new System.EventHandler(this.CalcularTotal);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(294, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 47;
            this.labelControl2.Text = "Turno";
            // 
            // iTurno
            // 
            this.iTurno.Location = new System.Drawing.Point(324, 11);
            this.iTurno.Name = "iTurno";
            this.iTurno.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.iTurno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iTurno.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Turno", "Turno", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DescripcionTurno", "Descripción")});
            this.iTurno.Properties.NullText = "";
            this.iTurno.Properties.ShowFooter = false;
            this.iTurno.Properties.ShowHeader = false;
            this.iTurno.Size = new System.Drawing.Size(135, 20);
            this.iTurno.TabIndex = 2;
            this.iTurno.Tag = "Seleccione el sexo";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(159, 14);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 13);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Fecha";
            // 
            // iFecha
            // 
            this.iFecha.EditValue = null;
            this.iFecha.Location = new System.Drawing.Point(192, 12);
            this.iFecha.Name = "iFecha";
            this.iFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFecha.Size = new System.Drawing.Size(97, 20);
            this.iFecha.TabIndex = 1;
            this.iFecha.Tag = "Ingrese la fecha del documento";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(11, 41);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(41, 13);
            this.labelControl17.TabIndex = 23;
            this.labelControl17.Text = "H. Inicial";
            // 
            // iHorometroinicio
            // 
            this.iHorometroinicio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iHorometroinicio.Location = new System.Drawing.Point(94, 38);
            this.iHorometroinicio.Name = "iHorometroinicio";
            this.iHorometroinicio.Properties.Appearance.Options.UseTextOptions = true;
            this.iHorometroinicio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHorometroinicio.Properties.Mask.EditMask = "n";
            this.iHorometroinicio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iHorometroinicio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iHorometroinicio.Size = new System.Drawing.Size(70, 20);
            this.iHorometroinicio.TabIndex = 3;
            this.iHorometroinicio.EditValueChanged += new System.EventHandler(this.CalcularTotal);
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
            this.iNumeroitem.Location = new System.Drawing.Point(94, 12);
            this.iNumeroitem.Name = "iNumeroitem";
            this.iNumeroitem.Properties.AllowFocused = false;
            this.iNumeroitem.Properties.Appearance.Options.UseTextOptions = true;
            this.iNumeroitem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iNumeroitem.Properties.ReadOnly = true;
            this.iNumeroitem.Size = new System.Drawing.Size(59, 20);
            this.iNumeroitem.TabIndex = 0;
            this.iNumeroitem.TabStop = false;
            // 
            // ValorizacionproveedorMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 221);
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
            this.Name = "ValorizacionproveedorMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de Valorizacion Proveedor Horometro";
            this.Load += new System.EventHandler(this.ValorizacionproveedorMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValorizacionproveedorMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdcentrodecosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDiastrabajo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrominimo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrorealdia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDescuentohorometro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrodia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometrofinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTurno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHorometroinicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit iHorometroinicio;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit iFecha;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit iTurno;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit iDiastrabajo;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit iHorometrominimo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit iHorometrorealdia;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit iDescuentohorometro;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit iHorometrodia;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit iHorometrofinal;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdcentrodecosto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit iObservaciones;
    }
}