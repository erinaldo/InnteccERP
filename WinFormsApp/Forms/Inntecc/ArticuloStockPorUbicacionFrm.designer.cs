namespace WinFormsApp
{
    partial class ArticuloStockPorUbicacionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloStockPorUbicacionFrm));
            this.rNombreArticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcStockUbicacion = new DevExpress.XtraGrid.GridControl();
            this.gvStockUbicacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ri1Numerico4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoproveedor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.iIdunidadinventario = new DevExpress.XtraEditors.TextEdit();
            this.iIdmarca = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rNombreArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri1Numerico4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoproveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdunidadinventario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmarca.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rNombreArticulo
            // 
            this.rNombreArticulo.Location = new System.Drawing.Point(104, 35);
            this.rNombreArticulo.Name = "rNombreArticulo";
            this.rNombreArticulo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rNombreArticulo.Properties.Appearance.Options.UseFont = true;
            this.rNombreArticulo.Properties.ReadOnly = true;
            this.rNombreArticulo.Size = new System.Drawing.Size(440, 20);
            this.rNombreArticulo.TabIndex = 5;
            this.rNombreArticulo.TabStop = false;
            this.rNombreArticulo.Tag = "Seleccione Articulo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Articulo";
            // 
            // gcStockUbicacion
            // 
            this.gcStockUbicacion.Location = new System.Drawing.Point(12, 113);
            this.gcStockUbicacion.MainView = this.gvStockUbicacion;
            this.gcStockUbicacion.Name = "gcStockUbicacion";
            this.gcStockUbicacion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ri1Numerico4});
            this.gcStockUbicacion.Size = new System.Drawing.Size(532, 267);
            this.gcStockUbicacion.TabIndex = 10;
            this.gcStockUbicacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStockUbicacion});
            // 
            // gvStockUbicacion
            // 
            this.gvStockUbicacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn22,
            this.gridColumn1});
            this.gvStockUbicacion.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvStockUbicacion.GridControl = this.gcStockUbicacion;
            this.gvStockUbicacion.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvStockUbicacion.Name = "gvStockUbicacion";
            this.gvStockUbicacion.OptionsBehavior.Editable = false;
            this.gvStockUbicacion.OptionsBehavior.ReadOnly = true;
            this.gvStockUbicacion.OptionsView.ColumnAutoWidth = false;
            this.gvStockUbicacion.OptionsView.ShowFooter = true;
            this.gvStockUbicacion.OptionsView.ShowGroupPanel = false;
            this.gvStockUbicacion.OptionsView.ShowViewCaption = true;
            this.gvStockUbicacion.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvStockUbicacion.ViewCaption = "Ubicaciones";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Nombre almacen";
            this.gridColumn14.FieldName = "nombrealmacen";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 126;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Stock";
            this.gridColumn22.ColumnEdit = this.ri1Numerico4;
            this.gridColumn22.FieldName = "stock";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            this.gridColumn22.Width = 74;
            // 
            // ri1Numerico4
            // 
            this.ri1Numerico4.AutoHeight = false;
            this.ri1Numerico4.Mask.EditMask = "n4";
            this.ri1Numerico4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ri1Numerico4.Mask.UseMaskAsDisplayFormat = true;
            this.ri1Numerico4.Name = "ri1Numerico4";
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(207, 13);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(85, 13);
            this.labelControl16.TabIndex = 2;
            this.labelControl16.Text = "Código fabricante";
            // 
            // iCodigoproveedor
            // 
            this.iCodigoproveedor.Location = new System.Drawing.Point(298, 9);
            this.iCodigoproveedor.Name = "iCodigoproveedor";
            this.iCodigoproveedor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoproveedor.Properties.MaxLength = 35;
            this.iCodigoproveedor.Properties.ReadOnly = true;
            this.iCodigoproveedor.Size = new System.Drawing.Size(99, 20);
            this.iCodigoproveedor.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Código";
            // 
            // iCodigoarticulo
            // 
            this.iCodigoarticulo.Location = new System.Drawing.Point(104, 9);
            this.iCodigoarticulo.Name = "iCodigoarticulo";
            this.iCodigoarticulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoarticulo.Properties.MaxLength = 10;
            this.iCodigoarticulo.Properties.ReadOnly = true;
            this.iCodigoarticulo.Size = new System.Drawing.Size(99, 20);
            this.iCodigoarticulo.TabIndex = 1;
            this.iCodigoarticulo.TabStop = false;
            this.iCodigoarticulo.Tag = "Ingrese el código";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 64);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(84, 13);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Unidad inventario";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(12, 90);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(29, 13);
            this.labelControl18.TabIndex = 8;
            this.labelControl18.Text = "Marca";
            // 
            // iIdunidadinventario
            // 
            this.iIdunidadinventario.Location = new System.Drawing.Point(104, 61);
            this.iIdunidadinventario.Name = "iIdunidadinventario";
            this.iIdunidadinventario.Properties.NullText = "[EditValue is null]";
            this.iIdunidadinventario.Properties.ReadOnly = true;
            this.iIdunidadinventario.Size = new System.Drawing.Size(440, 20);
            this.iIdunidadinventario.TabIndex = 7;
            this.iIdunidadinventario.Tag = "Seleccione la unidad minima de inventario";
            // 
            // iIdmarca
            // 
            this.iIdmarca.Location = new System.Drawing.Point(104, 87);
            this.iIdmarca.Name = "iIdmarca";
            this.iIdmarca.Properties.NullText = "[EditValue is null]";
            this.iIdmarca.Properties.ReadOnly = true;
            this.iIdmarca.Size = new System.Drawing.Size(443, 20);
            this.iIdmarca.TabIndex = 9;
            this.iIdmarca.Tag = "Seleccione la marca";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ubicación";
            this.gridColumn1.FieldName = "nombreubicacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // ArticuloStockPorUbicacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 392);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.iCodigoproveedor);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iCodigoarticulo);
            this.Controls.Add(this.gcStockUbicacion);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.rNombreArticulo);
            this.Controls.Add(this.iIdunidadinventario);
            this.Controls.Add(this.iIdmarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArticuloStockPorUbicacionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock por Ubicación";
            this.Load += new System.EventHandler(this.ArticuloStockPorUbicacionFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rNombreArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStockUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ri1Numerico4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoproveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdunidadinventario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmarca.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit rNombreArticulo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcStockUbicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStockUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ri1Numerico4;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit iCodigoproveedor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iCodigoarticulo;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit iIdunidadinventario;
        private DevExpress.XtraEditors.TextEdit iIdmarca;
    }
}