namespace WinFormsApp.Buscadores
{
    partial class Form1
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
            this.gcArticulo = new DevExpress.XtraGrid.GridControl();
            this.gvArticulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcContado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPreciocreditodia1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPreciocreditodia2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPublico = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).BeginInit();
            this.SuspendLayout();
            // 
            // gcArticulo
            // 
            this.gcArticulo.Location = new System.Drawing.Point(12, 12);
            this.gcArticulo.MainView = this.gvArticulo;
            this.gcArticulo.Name = "gcArticulo";
            this.gcArticulo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerico4});
            this.gcArticulo.Size = new System.Drawing.Size(959, 418);
            this.gcArticulo.TabIndex = 7;
            this.gcArticulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulo});
            // 
            // gvArticulo
            // 
            this.gvArticulo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn8,
            this.gcContado,
            this.gcPreciocreditodia1,
            this.gcPreciocreditodia2,
            this.gcPublico});
            this.gvArticulo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvArticulo.GridControl = this.gcArticulo;
            this.gvArticulo.Name = "gvArticulo";
            this.gvArticulo.OptionsBehavior.ReadOnly = true;
            this.gvArticulo.OptionsView.ColumnAutoWidth = false;
            this.gvArticulo.OptionsView.ShowGroupPanel = false;
            this.gvArticulo.OptionsView.ShowViewCaption = true;
            this.gvArticulo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvArticulo.ViewCaption = "Articulos";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idarticulo";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cod. Int.";
            this.gridColumn2.FieldName = "Codigoarticulo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 54;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cod. Prov.";
            this.gridColumn7.FieldName = "Codigoproveedor";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 91;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nombre Articulo";
            this.gridColumn4.FieldName = "Nombrearticulo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 310;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Marca";
            this.gridColumn3.FieldName = "Nombremarca";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 82;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unidad";
            this.gridColumn5.FieldName = "Abrunidadmedida";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 68;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Stock";
            this.gridColumn8.ColumnEdit = this.riNumerico4;
            this.gridColumn8.FieldName = "Stock";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 55;
            // 
            // riNumerico4
            // 
            this.riNumerico4.AutoHeight = false;
            this.riNumerico4.DisplayFormat.FormatString = "n4";
            this.riNumerico4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.EditFormat.FormatString = "n4";
            this.riNumerico4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.Mask.EditMask = "n4";
            this.riNumerico4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico4.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico4.Name = "riNumerico4";
            // 
            // gcContado
            // 
            this.gcContado.Caption = "Contado";
            this.gcContado.ColumnEdit = this.riNumerico4;
            this.gcContado.FieldName = "Preciocontado";
            this.gcContado.Name = "gcContado";
            this.gcContado.Visible = true;
            this.gcContado.VisibleIndex = 6;
            this.gcContado.Width = 55;
            // 
            // gcPreciocreditodia1
            // 
            this.gcPreciocreditodia1.Caption = "Credito";
            this.gcPreciocreditodia1.ColumnEdit = this.riNumerico4;
            this.gcPreciocreditodia1.FieldName = "Preciocreditoopcion1";
            this.gcPreciocreditodia1.Name = "gcPreciocreditodia1";
            this.gcPreciocreditodia1.Visible = true;
            this.gcPreciocreditodia1.VisibleIndex = 7;
            this.gcPreciocreditodia1.Width = 55;
            // 
            // gcPreciocreditodia2
            // 
            this.gcPreciocreditodia2.Caption = "Credito";
            this.gcPreciocreditodia2.ColumnEdit = this.riNumerico4;
            this.gcPreciocreditodia2.FieldName = "Preciocreditoopcion1";
            this.gcPreciocreditodia2.Name = "gcPreciocreditodia2";
            this.gcPreciocreditodia2.Visible = true;
            this.gcPreciocreditodia2.VisibleIndex = 8;
            this.gcPreciocreditodia2.Width = 55;
            // 
            // gcPublico
            // 
            this.gcPublico.Caption = "Público";
            this.gcPublico.ColumnEdit = this.riNumerico4;
            this.gcPublico.FieldName = "Preciosugerido";
            this.gcPublico.Name = "gcPublico";
            this.gcPublico.Visible = true;
            this.gcPublico.VisibleIndex = 9;
            this.gcPublico.Width = 55;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 461);
            this.Controls.Add(this.gcArticulo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico4;
        private DevExpress.XtraGrid.Columns.GridColumn gcContado;
        private DevExpress.XtraGrid.Columns.GridColumn gcPreciocreditodia1;
        private DevExpress.XtraGrid.Columns.GridColumn gcPreciocreditodia2;
        private DevExpress.XtraGrid.Columns.GridColumn gcPublico;
    }
}