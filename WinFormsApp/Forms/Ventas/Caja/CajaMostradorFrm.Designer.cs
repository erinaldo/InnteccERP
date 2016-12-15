namespace WinFormsApp
{
    partial class CajaMostradorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CajaMostradorFrm));
            this.bmCaja = new DevExpress.XtraBars.BarManager(this.components);
            this.barCaja = new DevExpress.XtraBars.Bar();
            this.btnCobro = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riTotaln2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bmCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotaln2)).BeginInit();
            this.SuspendLayout();
            // 
            // bmCaja
            // 
            this.bmCaja.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barCaja});
            this.bmCaja.DockControls.Add(this.barDockControlTop);
            this.bmCaja.DockControls.Add(this.barDockControlBottom);
            this.bmCaja.DockControls.Add(this.barDockControlLeft);
            this.bmCaja.DockControls.Add(this.barDockControlRight);
            this.bmCaja.Form = this;
            this.bmCaja.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCobro,
            this.btnAnular,
            this.btnActualizar});
            this.bmCaja.MaxItemId = 3;
            this.bmCaja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmCaja_ItemClick);
            // 
            // barCaja
            // 
            this.barCaja.BarName = "Tools";
            this.barCaja.DockCol = 0;
            this.barCaja.DockRow = 0;
            this.barCaja.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barCaja.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCobro, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAnular, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnActualizar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barCaja.OptionsBar.UseWholeRow = true;
            this.barCaja.Text = "Tools";
            // 
            // btnCobro
            // 
            this.btnCobro.Caption = "Cobro";
            this.btnCobro.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCobro.Glyph")));
            this.btnCobro.Id = 0;
            this.btnCobro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCobro.LargeGlyph")));
            this.btnCobro.Name = "btnCobro";
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.Glyph")));
            this.btnAnular.Id = 1;
            this.btnAnular.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnular.LargeGlyph")));
            this.btnAnular.Name = "btnAnular";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Glyph")));
            this.btnActualizar.Id = 2;
            this.btnActualizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnActualizar.LargeGlyph")));
            this.btnActualizar.Name = "btnActualizar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(846, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 377);
            this.barDockControlBottom.Size = new System.Drawing.Size(846, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 346);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(846, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 346);
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConsulta.Location = new System.Drawing.Point(0, 31);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riTotaln2});
            this.gcConsulta.Size = new System.Drawing.Size(846, 346);
            this.gcConsulta.TabIndex = 4;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn10});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idordendeventa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idordendeventa", "Nº {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tipo";
            this.gridColumn3.FieldName = "Nombretipoformato";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Operación";
            this.gridColumn7.FieldName = "Nombrecptooperacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Orden";
            this.gridColumn5.FieldName = "Serienumeroordenventa";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fechaordenventa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ruc";
            this.gridColumn6.FieldName = "Nrodocentidadprincipal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cliente";
            this.gridColumn8.FieldName = "Razonsocial";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Moneda";
            this.gridColumn4.FieldName = "Simbolomoneda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.ColumnEdit = this.riTotaln2;
            this.gridColumn9.FieldName = "Totaldocumento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // riTotaln2
            // 
            this.riTotaln2.AutoHeight = false;
            this.riTotaln2.Mask.EditMask = "n2";
            this.riTotaln2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riTotaln2.Mask.UseMaskAsDisplayFormat = true;
            this.riTotaln2.Name = "riTotaln2";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Condicion";
            this.gridColumn12.FieldName = "Nombrecondicion";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Anulado";
            this.gridColumn10.FieldName = "Anulado";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            // 
            // CajaMostradorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 377);
            this.Controls.Add(this.gcConsulta);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CajaMostradorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de venta pendientes de cobro";
            this.Load += new System.EventHandler(this.CajaMostradorFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bmCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotaln2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmCaja;
        private DevExpress.XtraBars.Bar barCaja;
        private DevExpress.XtraBars.BarButtonItem btnCobro;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riTotaln2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;

    }
}