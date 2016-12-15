namespace WinFormsApp
{
    partial class RecibocajaingresoImpNotaCreditoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecibocajaingresoImpNotaCreditoFrm));
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
            this.gcDocImp = new DevExpress.XtraGrid.GridControl();
            this.gvDocImp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riItemseleccionado = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkSeleccionarTodo = new DevExpress.XtraEditors.CheckEdit();
            this.iIdsucursal = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riItemseleccionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSeleccionarTodo.Properties)).BeginInit();
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
            this.btnImportar.Caption = "Importar";
            this.btnImportar.Glyph = global::WinFormsApp.Properties.Resources.Action_Save_New;
            this.btnImportar.Id = 0;
            this.btnImportar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnImportar.Name = "btnImportar";
            toolTipTitleItem1.Text = "Importar y cerrar (Ctrl + Enter)";
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
            this.barDockControlTop.Size = new System.Drawing.Size(793, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 347);
            this.barDockControlBottom.Size = new System.Drawing.Size(793, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 316);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(793, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 316);
            // 
            // gcDocImp
            // 
            this.gcDocImp.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDocImp.Location = new System.Drawing.Point(12, 59);
            this.gcDocImp.MainView = this.gvDocImp;
            this.gcDocImp.Name = "gcDocImp";
            this.gcDocImp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerico2,
            this.riItemseleccionado});
            this.gcDocImp.Size = new System.Drawing.Size(769, 276);
            this.gcDocImp.TabIndex = 12;
            this.gcDocImp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocImp});
            // 
            // gvDocImp
            // 
            this.gvDocImp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn21,
            this.gridColumn9,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn10});
            this.gvDocImp.GridControl = this.gcDocImp;
            this.gvDocImp.Name = "gvDocImp";
            this.gvDocImp.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDocImp.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDocImp.OptionsCustomization.AllowFilter = false;
            this.gvDocImp.OptionsCustomization.AllowGroup = false;
            this.gvDocImp.OptionsCustomization.AllowSort = false;
            this.gvDocImp.OptionsMenu.EnableColumnMenu = false;
            this.gvDocImp.OptionsView.ColumnAutoWidth = false;
            this.gvDocImp.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvDocImp.OptionsView.ShowGroupPanel = false;
            this.gvDocImp.OptionsView.ShowViewCaption = true;
            this.gvDocImp.ViewCaption = "Notas de credito";
            this.gvDocImp.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetalleImp_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "Abreviaturatipoformato";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 72;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Serie";
            this.gridColumn3.FieldName = "Serienotacredito";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 39;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Numero";
            this.gridColumn21.FieldName = "Numeronotacredito";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 2;
            this.gridColumn21.Width = 52;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Fecha";
            this.gridColumn9.FieldName = "Fechaemision";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 57;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Moneda";
            this.gridColumn2.FieldName = "Nombretipomoneda";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 57;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Imp. Doc.";
            this.gridColumn5.ColumnEdit = this.riNumerico2;
            this.gridColumn5.FieldName = "Totaldocumento";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 68;
            // 
            // riNumerico2
            // 
            this.riNumerico2.AutoHeight = false;
            this.riNumerico2.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.riNumerico2.Mask.EditMask = "n2";
            this.riNumerico2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico2.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico2.Name = "riNumerico2";
            this.riNumerico2.EditValueChanged += new System.EventHandler(this.riNumerico2_EditValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total Importado";
            this.gridColumn6.ColumnEdit = this.riNumerico2;
            this.gridColumn6.FieldName = "Totalncimportado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 90;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Saldo";
            this.gridColumn11.ColumnEdit = this.riNumerico2;
            this.gridColumn11.FieldName = "Importesaldo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Monto Importar";
            this.gridColumn12.ColumnEdit = this.riNumerico2;
            this.gridColumn12.FieldName = "Saldoaimportar";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 88;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Seleccionar";
            this.gridColumn10.ColumnEdit = this.riItemseleccionado;
            this.gridColumn10.FieldName = "Itemseleccionado";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 57;
            // 
            // riItemseleccionado
            // 
            this.riItemseleccionado.AutoHeight = false;
            this.riItemseleccionado.Name = "riItemseleccionado";
            this.riItemseleccionado.EditValueChanged += new System.EventHandler(this.riItemseleccionado_EditValueChanged);
            // 
            // chkSeleccionarTodo
            // 
            this.chkSeleccionarTodo.Location = new System.Drawing.Point(962, 63);
            this.chkSeleccionarTodo.MenuManager = this.bmMntItems;
            this.chkSeleccionarTodo.Name = "chkSeleccionarTodo";
            this.chkSeleccionarTodo.Properties.Caption = "Seleccionar todo";
            this.chkSeleccionarTodo.Size = new System.Drawing.Size(101, 19);
            this.chkSeleccionarTodo.TabIndex = 13;
            this.chkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodo_CheckedChanged);
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
            // RecibocajaingresoImpNotaCreditoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 347);
            this.Controls.Add(this.iIdsucursal);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.chkSeleccionarTodo);
            this.Controls.Add(this.gcDocImp);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecibocajaingresoImpNotaCreditoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas de credito";
            this.Load += new System.EventHandler(this.RecibocajaingresoImpNotaCreditoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecibocajaingresoImpNotaCreditoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riItemseleccionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSeleccionarTodo.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit chkSeleccionarTodo;
        private DevExpress.XtraGrid.GridControl gcDocImp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocImp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraBars.BarButtonItem btnConsultar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riItemseleccionado;
        private DevExpress.XtraBars.BarButtonItem btnCerrar;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdsucursal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}