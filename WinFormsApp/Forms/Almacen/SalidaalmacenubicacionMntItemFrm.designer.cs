namespace WinFormsApp
{
    partial class SalidaalmacenubicacionMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalidaalmacenubicacionMntItemFrm));
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.rStock = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iNombresucursal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iNombrealmacen = new DevExpress.XtraEditors.TextEdit();
            this.iIdubicacion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.iIdarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.iCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigodebarra = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoproveedor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iMarcaarticulo = new DevExpress.XtraEditors.TextEdit();
            this.iUnidad = new DevExpress.XtraEditors.TextEdit();
            this.beArticulo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombresucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrealmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdubicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigodebarra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoproveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMarcaarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArticulo.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(596, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 281);
            this.barDockControlBottom.Size = new System.Drawing.Size(596, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 250);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(596, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 250);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(596, 250);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.labelControl6);
            this.tpProducto.Controls.Add(this.rStock);
            this.tpProducto.Controls.Add(this.labelControl3);
            this.tpProducto.Controls.Add(this.iNombresucursal);
            this.tpProducto.Controls.Add(this.labelControl4);
            this.tpProducto.Controls.Add(this.iNombrealmacen);
            this.tpProducto.Controls.Add(this.iIdubicacion);
            this.tpProducto.Controls.Add(this.labelControl9);
            this.tpProducto.Controls.Add(this.iIdarticulo);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Controls.Add(this.labelControl10);
            this.tpProducto.Controls.Add(this.iCantidad);
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.labelControl18);
            this.tpProducto.Controls.Add(this.labelControl17);
            this.tpProducto.Controls.Add(this.iCodigodebarra);
            this.tpProducto.Controls.Add(this.labelControl16);
            this.tpProducto.Controls.Add(this.iCodigoproveedor);
            this.tpProducto.Controls.Add(this.labelControl2);
            this.tpProducto.Controls.Add(this.iCodigoarticulo);
            this.tpProducto.Controls.Add(this.labelControl8);
            this.tpProducto.Controls.Add(this.iMarcaarticulo);
            this.tpProducto.Controls.Add(this.iUnidad);
            this.tpProducto.Controls.Add(this.beArticulo);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(590, 222);
            this.tpProducto.Text = "Item Salida Almacen";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(205, 198);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Stock";
            // 
            // rStock
            // 
            this.rStock.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rStock.Location = new System.Drawing.Point(254, 195);
            this.rStock.Name = "rStock";
            this.rStock.Properties.Appearance.Options.UseTextOptions = true;
            this.rStock.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rStock.Properties.DisplayFormat.FormatString = "n4";
            this.rStock.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rStock.Properties.EditFormat.FormatString = "n4";
            this.rStock.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rStock.Properties.Mask.EditMask = "n4";
            this.rStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rStock.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rStock.Properties.ReadOnly = true;
            this.rStock.Size = new System.Drawing.Size(99, 20);
            this.rStock.TabIndex = 24;
            this.rStock.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 146);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Sucursal";
            // 
            // iNombresucursal
            // 
            this.iNombresucursal.Location = new System.Drawing.Point(94, 143);
            this.iNombresucursal.MenuManager = this.bmMntItems;
            this.iNombresucursal.Name = "iNombresucursal";
            this.iNombresucursal.Properties.ReadOnly = true;
            this.iNombresucursal.Size = new System.Drawing.Size(486, 20);
            this.iNombresucursal.TabIndex = 18;
            this.iNombresucursal.TabStop = false;
            this.iNombresucursal.Tag = "Seleccione Articulo";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 172);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Almacen";
            // 
            // iNombrealmacen
            // 
            this.iNombrealmacen.Location = new System.Drawing.Point(94, 169);
            this.iNombrealmacen.MenuManager = this.bmMntItems;
            this.iNombrealmacen.Name = "iNombrealmacen";
            this.iNombrealmacen.Properties.ReadOnly = true;
            this.iNombrealmacen.Size = new System.Drawing.Size(486, 20);
            this.iNombrealmacen.TabIndex = 20;
            this.iNombrealmacen.TabStop = false;
            this.iNombrealmacen.Tag = "Seleccione Articulo";
            // 
            // iIdubicacion
            // 
            this.iIdubicacion.Location = new System.Drawing.Point(94, 117);
            this.iIdubicacion.Name = "iIdubicacion";
            this.iIdubicacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdubicacion.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdubicacion.Properties.View = this.gridView1;
            this.iIdubicacion.Size = new System.Drawing.Size(486, 20);
            this.iIdubicacion.TabIndex = 16;
            this.iIdubicacion.Tag = "Seleccione la ubicacion";
            this.iIdubicacion.AddNewValue += new DevExpress.XtraEditors.Controls.AddNewValueEventHandler(this.iIdubicacion_AddNewValue);
            this.iIdubicacion.EditValueChanged += new System.EventHandler(this.iIdubicacion_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idubicacion";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ubicacion";
            this.gridColumn2.FieldName = "Nombreubicacion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Almacen";
            this.gridColumn5.FieldName = "Nombrealmacen";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Sucursal";
            this.gridColumn6.FieldName = "Nombresucursal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(11, 120);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(45, 13);
            this.labelControl9.TabIndex = 15;
            this.labelControl9.Text = "Ubicación";
            // 
            // iIdarticulo
            // 
            this.iIdarticulo.EditValue = 0;
            this.iIdarticulo.Location = new System.Drawing.Point(524, 12);
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
            this.labelControl13.Location = new System.Drawing.Point(11, 18);
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
            this.iNumeroitem.TabIndex = 1;
            this.iNumeroitem.TabStop = false;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(11, 198);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(43, 13);
            this.labelControl10.TabIndex = 21;
            this.labelControl10.Text = "Cantidad";
            // 
            // iCantidad
            // 
            this.iCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iCantidad.Location = new System.Drawing.Point(94, 195);
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.Properties.Appearance.Options.UseTextOptions = true;
            this.iCantidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iCantidad.Properties.DisplayFormat.FormatString = "n4";
            this.iCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iCantidad.Properties.EditFormat.FormatString = "n4";
            this.iCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.iCantidad.Properties.Mask.EditMask = "n4";
            this.iCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iCantidad.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iCantidad.Size = new System.Drawing.Size(99, 20);
            this.iCantidad.TabIndex = 22;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(296, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Unidad";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(11, 93);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(29, 13);
            this.labelControl18.TabIndex = 11;
            this.labelControl18.Text = "Marca";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(392, 41);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(77, 13);
            this.labelControl17.TabIndex = 7;
            this.labelControl17.Text = "Código de barra";
            // 
            // iCodigodebarra
            // 
            this.iCodigodebarra.Location = new System.Drawing.Point(478, 38);
            this.iCodigodebarra.Name = "iCodigodebarra";
            this.iCodigodebarra.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigodebarra.Properties.MaxLength = 50;
            this.iCodigodebarra.Properties.ReadOnly = true;
            this.iCodigodebarra.Size = new System.Drawing.Size(104, 20);
            this.iCodigodebarra.TabIndex = 8;
            this.iCodigodebarra.TabStop = false;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(197, 41);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(85, 13);
            this.labelControl16.TabIndex = 5;
            this.labelControl16.Text = "Código fabricante";
            // 
            // iCodigoproveedor
            // 
            this.iCodigoproveedor.Location = new System.Drawing.Point(288, 38);
            this.iCodigoproveedor.Name = "iCodigoproveedor";
            this.iCodigoproveedor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoproveedor.Properties.MaxLength = 35;
            this.iCodigoproveedor.Properties.ReadOnly = true;
            this.iCodigoproveedor.Size = new System.Drawing.Size(99, 20);
            this.iCodigoproveedor.TabIndex = 6;
            this.iCodigoproveedor.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Código";
            // 
            // iCodigoarticulo
            // 
            this.iCodigoarticulo.Location = new System.Drawing.Point(94, 38);
            this.iCodigoarticulo.Name = "iCodigoarticulo";
            this.iCodigoarticulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoarticulo.Properties.MaxLength = 10;
            this.iCodigoarticulo.Properties.ReadOnly = true;
            this.iCodigoarticulo.Size = new System.Drawing.Size(99, 20);
            this.iCodigoarticulo.TabIndex = 4;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 69);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 13);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "Artículo";
            // 
            // iMarcaarticulo
            // 
            this.iMarcaarticulo.EditValue = "";
            this.iMarcaarticulo.Location = new System.Drawing.Point(94, 90);
            this.iMarcaarticulo.Name = "iMarcaarticulo";
            this.iMarcaarticulo.Properties.NullText = "[EditValue is null]";
            this.iMarcaarticulo.Properties.ReadOnly = true;
            this.iMarcaarticulo.Size = new System.Drawing.Size(196, 20);
            this.iMarcaarticulo.TabIndex = 12;
            this.iMarcaarticulo.TabStop = false;
            // 
            // iUnidad
            // 
            this.iUnidad.EditValue = "";
            this.iUnidad.Location = new System.Drawing.Point(335, 90);
            this.iUnidad.Name = "iUnidad";
            this.iUnidad.Properties.NullText = "[EditValue is null]";
            this.iUnidad.Properties.ReadOnly = true;
            this.iUnidad.Size = new System.Drawing.Size(148, 20);
            this.iUnidad.TabIndex = 14;
            this.iUnidad.TabStop = false;
            // 
            // beArticulo
            // 
            this.beArticulo.EditValue = "";
            this.beArticulo.Location = new System.Drawing.Point(93, 63);
            this.beArticulo.Name = "beArticulo";
            this.beArticulo.Properties.ReadOnly = true;
            this.beArticulo.Size = new System.Drawing.Size(489, 20);
            this.beArticulo.TabIndex = 10;
            this.beArticulo.Tag = "Seleccione el Articulo";
            // 
            // SalidaalmacenubicacionMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 281);
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
            this.Name = "SalidaalmacenubicacionMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de ubicación de salida de almacen";
            this.Load += new System.EventHandler(this.SalidaalmacenubicacionMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalidaalmacenubicacionMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombresucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrealmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdubicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigodebarra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoproveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMarcaarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArticulo.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit iCodigodebarra;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit iCodigoproveedor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iCodigoarticulo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit iMarcaarticulo;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit iCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit iNumeroitem;
        private DevExpress.XtraEditors.TextEdit iIdarticulo;
        private DevExpress.XtraEditors.TextEdit iUnidad;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdubicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit beArticulo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iNombresucursal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iNombrealmacen;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit rStock;
    }
}