namespace WinFormsApp
{
    partial class CpcompracostoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpcompracostoFrm));
            this.gcDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riCantidad = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riValorUnitario = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNeto4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iIdtipomoneda = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iTipocambio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.rTotalbruto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riValorUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNeto4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipocambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTotalbruto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDetalle
            // 
            this.gcDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDetalle.Location = new System.Drawing.Point(2, 59);
            this.gcDetalle.MainView = this.gvDetalle;
            this.gcDetalle.Name = "gcDetalle";
            this.gcDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riCantidad,
            this.riValorUnitario,
            this.tiTotal,
            this.riNumerico2,
            this.riNeto4});
            this.gcDetalle.Size = new System.Drawing.Size(1057, 331);
            this.gcDetalle.TabIndex = 67;
            this.gcDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetalle});
            // 
            // gvDetalle
            // 
            this.gvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn22,
            this.gridColumn19,
            this.gridColumn18,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn7,
            this.gridColumn27,
            this.gridColumn8,
            this.gridColumn28,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn31,
            this.gridColumn42,
            this.gridColumn32,
            this.gridColumn33});
            this.gvDetalle.GridControl = this.gcDetalle;
            this.gvDetalle.Name = "gvDetalle";
            this.gvDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.gvDetalle.OptionsCustomization.AllowFilter = false;
            this.gvDetalle.OptionsCustomization.AllowGroup = false;
            this.gvDetalle.OptionsCustomization.AllowSort = false;
            this.gvDetalle.OptionsMenu.EnableColumnMenu = false;
            this.gvDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvDetalle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvDetalle.OptionsView.ShowGroupPanel = false;
            this.gvDetalle.OptionsView.ShowViewCaption = true;
            this.gvDetalle.ViewCaption = "Detalle Items de compra";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Id.";
            this.gridColumn23.FieldName = "Idordencompradet";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 43;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "N°";
            this.gridColumn22.FieldName = "Numeroitem";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 35;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Código";
            this.gridColumn19.FieldName = "Codigoarticulo";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 48;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Código proveedor";
            this.gridColumn18.FieldName = "Codigoproveedor";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 94;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Artículo";
            this.gridColumn20.FieldName = "Nombrearticulo";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 3;
            this.gridColumn20.Width = 51;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Marca";
            this.gridColumn21.FieldName = "Nombremarca";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            this.gridColumn21.Width = 43;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Cantidad";
            this.gridColumn24.ColumnEdit = this.riCantidad;
            this.gridColumn24.FieldName = "Cantidad";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 5;
            this.gridColumn24.Width = 52;
            // 
            // riCantidad
            // 
            this.riCantidad.AutoHeight = false;
            this.riCantidad.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.riCantidad.Mask.EditMask = "n4";
            this.riCantidad.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riCantidad.Mask.UseMaskAsDisplayFormat = true;
            this.riCantidad.Name = "riCantidad";
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "V. Unitario";
            this.gridColumn25.ColumnEdit = this.riValorUnitario;
            this.gridColumn25.FieldName = "Preciounitario";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            this.gridColumn25.Width = 57;
            // 
            // riValorUnitario
            // 
            this.riValorUnitario.AutoHeight = false;
            this.riValorUnitario.DisplayFormat.FormatString = "n4";
            this.riValorUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riValorUnitario.Mask.EditMask = "n4";
            this.riValorUnitario.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riValorUnitario.Name = "riValorUnitario";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Sub Total";
            this.gridColumn26.ColumnEdit = this.tiTotal;
            this.gridColumn26.FieldName = "Importetotal";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 10;
            this.gridColumn26.Width = 52;
            // 
            // tiTotal
            // 
            this.tiTotal.AutoHeight = false;
            this.tiTotal.DisplayFormat.FormatString = "n2";
            this.tiTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tiTotal.Mask.EditMask = "n2";
            this.tiTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tiTotal.Name = "tiTotal";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Area";
            this.gridColumn7.FieldName = "Nombrearea";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 12;
            this.gridColumn7.Width = 40;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Centro de costo";
            this.gridColumn27.FieldName = "Descripcioncentrodecosto";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 13;
            this.gridColumn27.Width = 45;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Proyecto";
            this.gridColumn8.FieldName = "Nombreproyecto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 14;
            this.gridColumn8.Width = 48;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Estado";
            this.gridColumn28.FieldName = "DataEntityState";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Width = 42;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "% Dcto 1";
            this.gridColumn9.ColumnEdit = this.riNumerico2;
            this.gridColumn9.FieldName = "Descuento1";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 52;
            // 
            // riNumerico2
            // 
            this.riNumerico2.AutoHeight = false;
            this.riNumerico2.DisplayFormat.FormatString = "n2";
            this.riNumerico2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico2.Mask.EditMask = "n2";
            this.riNumerico2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico2.Name = "riNumerico2";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "% Dcto 2";
            this.gridColumn11.ColumnEdit = this.riNumerico2;
            this.gridColumn11.FieldName = "Descuento2";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 56;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "% Dcto 3";
            this.gridColumn12.ColumnEdit = this.riNumerico2;
            this.gridColumn12.FieldName = "Descuento3";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 53;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "% Dcto 4";
            this.gridColumn31.ColumnEdit = this.riNumerico2;
            this.gridColumn31.FieldName = "Descuento4";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Width = 53;
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "V. Uni. Neto";
            this.gridColumn42.ColumnEdit = this.riNeto4;
            this.gridColumn42.FieldName = "Preciounitarioneto";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.ReadOnly = true;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 9;
            this.gridColumn42.Width = 64;
            // 
            // riNeto4
            // 
            this.riNeto4.AutoHeight = false;
            this.riNeto4.DisplayFormat.FormatString = "n4";
            this.riNeto4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNeto4.Mask.EditMask = "n4";
            this.riNeto4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNeto4.Name = "riNeto4";
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "% Percepción";
            this.gridColumn32.ColumnEdit = this.riNumerico2;
            this.gridColumn32.FieldName = "Porcentajepercepcion";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 11;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "N° Orden compra";
            this.gridColumn33.FieldName = "Serienumeroorden";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.ReadOnly = true;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 15;
            // 
            // iIdtipomoneda
            // 
            this.iIdtipomoneda.Location = new System.Drawing.Point(121, 10);
            this.iIdtipomoneda.Name = "iIdtipomoneda";
            this.iIdtipomoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdtipomoneda.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdtipomoneda.Properties.ReadOnly = true;
            this.iIdtipomoneda.Properties.View = this.gridView2;
            this.iIdtipomoneda.Size = new System.Drawing.Size(151, 20);
            this.iIdtipomoneda.TabIndex = 68;
            this.iIdtipomoneda.Tag = "Seleccione el tipo de moneda";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Id.";
            this.gridColumn5.FieldName = "Idtipomoneda";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "Nombretipomoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(3, 13);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(91, 13);
            this.labelControl8.TabIndex = 69;
            this.labelControl8.Text = "Moneda de compra";
            // 
            // iTipocambio
            // 
            this.iTipocambio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.iTipocambio.Location = new System.Drawing.Point(353, 10);
            this.iTipocambio.Name = "iTipocambio";
            this.iTipocambio.Properties.Appearance.Options.UseTextOptions = true;
            this.iTipocambio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iTipocambio.Properties.Mask.EditMask = "n3";
            this.iTipocambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iTipocambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iTipocambio.Properties.ReadOnly = true;
            this.iTipocambio.Size = new System.Drawing.Size(70, 20);
            this.iTipocambio.TabIndex = 70;
            this.iTipocambio.TabStop = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(278, 13);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 13);
            this.labelControl6.TabIndex = 71;
            this.labelControl6.Text = "Tipo cambio";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(3, 35);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(112, 13);
            this.labelControl21.TabIndex = 101;
            this.labelControl21.Text = "Flete S/. (Sin impuesto)";
            // 
            // rTotalbruto
            // 
            this.rTotalbruto.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rTotalbruto.Location = new System.Drawing.Point(121, 32);
            this.rTotalbruto.Name = "rTotalbruto";
            this.rTotalbruto.Properties.Appearance.Options.UseTextOptions = true;
            this.rTotalbruto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rTotalbruto.Properties.Mask.EditMask = "n";
            this.rTotalbruto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rTotalbruto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rTotalbruto.Size = new System.Drawing.Size(70, 20);
            this.rTotalbruto.TabIndex = 102;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(197, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(150, 13);
            this.labelControl1.TabIndex = 103;
            this.labelControl1.Text = "Otros gastos S/. (Sin impuesto)";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textEdit1.Location = new System.Drawing.Point(353, 32);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEdit1.Properties.Mask.EditMask = "n";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEdit1.Size = new System.Drawing.Size(70, 20);
            this.textEdit1.TabIndex = 104;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(971, 30);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 23);
            this.btnSeleccionar.TabIndex = 105;
            this.btnSeleccionar.Text = "Seleccionar";
            // 
            // CpcompracostoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 477);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.rTotalbruto);
            this.Controls.Add(this.iTipocambio);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.iIdtipomoneda);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.gcDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CpcompracostoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar items desde comprobante de compra";
            this.Load += new System.EventHandler(this.CpcompracostoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CpcompracostoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riValorUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNeto4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdtipomoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipocambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTotalbruto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gcDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riValorUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tiTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNeto4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdtipomoneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit iTipocambio;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit rTotalbruto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
    }
}