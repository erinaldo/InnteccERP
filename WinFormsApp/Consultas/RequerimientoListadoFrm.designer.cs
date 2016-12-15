namespace WinFormsApp
{
    partial class RequerimientoListadoFrm
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
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riEntero = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riCantidad = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riValorUnitario = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riItemseleccionado = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riEntero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riValorUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riItemseleccionado)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Location = new System.Drawing.Point(8, 8);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.riDocumento,
            this.tiTotal});
            this.gcConsulta.Size = new System.Drawing.Size(1005, 287);
            this.gcConsulta.TabIndex = 1;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            this.gvConsulta.OptionsView.ShowViewCaption = true;
            this.gvConsulta.ViewCaption = "Requerimientos";
            this.gvConsulta.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvConsulta_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idrequerimiento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
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
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Serie";
            this.gridColumn4.FieldName = "Seriereq";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Documento";
            this.gridColumn5.ColumnEdit = this.riDocumento;
            this.gridColumn5.FieldName = "Numeroreq";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // riDocumento
            // 
            this.riDocumento.AutoHeight = false;
            this.riDocumento.Mask.EditMask = "d8";
            this.riDocumento.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riDocumento.Name = "riDocumento";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fechareq";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Empleado";
            this.gridColumn6.FieldName = "Nombrepersonaempleado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Área";
            this.gridColumn7.FieldName = "Nombrearea";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 43;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Proyecto";
            this.gridColumn8.FieldName = "Nombreproyecto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.ColumnEdit = this.tiTotal;
            this.gridColumn9.FieldName = "Totaldocumento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            // 
            // tiTotal
            // 
            this.tiTotal.AutoHeight = false;
            this.tiTotal.Mask.EditMask = "n2";
            this.tiTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tiTotal.Name = "tiTotal";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Concepto";
            this.gridColumn11.FieldName = "Nombrecptooperacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Estado";
            this.gridColumn12.FieldName = "Nombreestadoreq";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Sucursal";
            this.gridColumn13.FieldName = "Nombresucursal";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gcDetalle
            // 
            this.gcDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDetalle.Location = new System.Drawing.Point(8, 300);
            this.gcDetalle.MainView = this.gvDetalle;
            this.gcDetalle.Name = "gcDetalle";
            this.gcDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riCantidad,
            this.riValorUnitario,
            this.riTotal,
            this.riItemseleccionado,
            this.riEntero});
            this.gcDetalle.Size = new System.Drawing.Size(1005, 211);
            this.gcDetalle.TabIndex = 2;
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
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn10});
            this.gvDetalle.GridControl = this.gcDetalle;
            this.gvDetalle.Name = "gvDetalle";
            this.gvDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.ReadOnly = true;
            this.gvDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.gvDetalle.OptionsCustomization.AllowFilter = false;
            this.gvDetalle.OptionsCustomization.AllowGroup = false;
            this.gvDetalle.OptionsCustomization.AllowSort = false;
            this.gvDetalle.OptionsMenu.EnableColumnMenu = false;
            this.gvDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvDetalle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvDetalle.OptionsView.ShowGroupPanel = false;
            this.gvDetalle.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetalle_CellValueChanged);
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Id.";
            this.gridColumn23.FieldName = "Idrequerimientodet";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 43;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "N°";
            this.gridColumn22.ColumnEdit = this.riEntero;
            this.gridColumn22.FieldName = "Numeroitem";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 54;
            // 
            // riEntero
            // 
            this.riEntero.AutoHeight = false;
            this.riEntero.Mask.EditMask = "n0";
            this.riEntero.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riEntero.Name = "riEntero";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Código interno";
            this.gridColumn19.FieldName = "Codigoarticulo";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 84;
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
            this.gridColumn20.Width = 94;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Marca";
            this.gridColumn21.FieldName = "Nombremarca";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            this.gridColumn21.Width = 94;
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
            this.gridColumn24.Width = 94;
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
            this.gridColumn25.Caption = "V. unitario";
            this.gridColumn25.ColumnEdit = this.riValorUnitario;
            this.gridColumn25.FieldName = "Preciounitario";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            this.gridColumn25.Width = 94;
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
            this.gridColumn26.Caption = "Total";
            this.gridColumn26.ColumnEdit = this.riTotal;
            this.gridColumn26.FieldName = "Importetotal";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 7;
            this.gridColumn26.Width = 94;
            // 
            // riTotal
            // 
            this.riTotal.AutoHeight = false;
            this.riTotal.DisplayFormat.FormatString = "n2";
            this.riTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riTotal.Mask.EditMask = "n2";
            this.riTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riTotal.Name = "riTotal";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Centro de costo";
            this.gridColumn27.FieldName = "Descripcioncentrodecosto";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 8;
            this.gridColumn27.Width = 86;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Estado";
            this.gridColumn28.FieldName = "DataEntityState";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 9;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Aprobar";
            this.gridColumn10.ColumnEdit = this.riItemseleccionado;
            this.gridColumn10.FieldName = "Aprobado";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            // 
            // riItemseleccionado
            // 
            this.riItemseleccionado.AutoHeight = false;
            this.riItemseleccionado.Name = "riItemseleccionado";
            this.riItemseleccionado.EditValueChanged += new System.EventHandler(this.riItemseleccionado_EditValueChanged);
            // 
            // RequerimientoListadoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 515);
            this.Controls.Add(this.gcDetalle);
            this.Controls.Add(this.gcConsulta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequerimientoListadoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de requerimientos";
            this.Load += new System.EventHandler(this.RequerimientoListadoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RequerimientoListadoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riEntero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riValorUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riItemseleccionado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tiTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riItemseleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riEntero;


    }
}