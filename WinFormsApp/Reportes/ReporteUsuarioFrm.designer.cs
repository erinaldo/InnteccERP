namespace WinFormsApp
{
    partial class ReporteUsuarioFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteUsuarioFrm));
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.riDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tiTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConsulta.Location = new System.Drawing.Point(0, 0);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.riDocumento,
            this.tiTotal});
            this.gcConsulta.Size = new System.Drawing.Size(1025, 515);
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
            this.gridColumn2});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.GroupCount = 1;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            this.gvConsulta.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvConsulta.ViewCaption = "Requerimientos";
            this.gvConsulta.ShownEditor += new System.EventHandler(this.gvConsulta_ShownEditor);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idreporteusuario";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idreporteusuario", "Nº {0}")});
            this.gridColumn1.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tipo";
            this.gridColumn3.FieldName = "Titulopagina";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nombre Repote";
            this.gridColumn4.FieldName = "Nombrereporte";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // riDocumento
            // 
            this.riDocumento.AutoHeight = false;
            this.riDocumento.Mask.EditMask = "d8";
            this.riDocumento.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riDocumento.Name = "riDocumento";
            // 
            // tiTotal
            // 
            this.tiTotal.AutoHeight = false;
            this.tiTotal.Mask.EditMask = "n2";
            this.tiTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tiTotal.Name = "tiTotal";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripcion Reporte";
            this.gridColumn2.FieldName = "Descripcionreporte";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // ReporteUsuarioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 515);
            this.Controls.Add(this.gcConsulta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteUsuarioFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Usuarios";
            this.Load += new System.EventHandler(this.ReporteUsuarioFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReporteUsuarioFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riDocumento;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tiTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;


    }
}