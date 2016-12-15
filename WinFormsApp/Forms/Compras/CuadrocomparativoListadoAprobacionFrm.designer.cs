namespace WinFormsApp
{
    partial class CuadrocomparativoListadoAprobacionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuadrocomparativoListadoAprobacionFrm));
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.iIdsucursal = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboEstado = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(857, 367);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 23);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // iIdsucursal
            // 
            this.iIdsucursal.Location = new System.Drawing.Point(108, 9);
            this.iIdsucursal.Name = "iIdsucursal";
            this.iIdsucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdsucursal.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdsucursal.Properties.View = this.gridView8;
            this.iIdsucursal.Size = new System.Drawing.Size(378, 20);
            this.iIdsucursal.TabIndex = 59;
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
            this.labelControl26.Location = new System.Drawing.Point(12, 12);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(90, 13);
            this.labelControl26.TabIndex = 60;
            this.labelControl26.Text = "Filtrar por Sucursal";
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Location = new System.Drawing.Point(12, 36);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.Size = new System.Drawing.Size(933, 325);
            this.gcConsulta.TabIndex = 61;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            this.gcConsulta.DoubleClick += new System.EventHandler(this.gcConsulta_DoubleClick);
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn2});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.Editable = false;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn3.Width = 92;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Empleado";
            this.gridColumn6.FieldName = "Nombrepersonaempleado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 104;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Área";
            this.gridColumn7.FieldName = "Nombrearea";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 104;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cantidad CC.";
            this.gridColumn9.FieldName = "Cantcuadrocomparativo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 104;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sucursal";
            this.gridColumn2.FieldName = "Nombresucursal";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::WinFormsApp.Properties.Resources.Action_Refresh;
            this.btnFiltrar.Location = new System.Drawing.Point(735, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(88, 23);
            this.btnFiltrar.TabIndex = 62;
            this.btnFiltrar.Text = "Actualizar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(503, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 64;
            this.labelControl1.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.Location = new System.Drawing.Point(542, 9);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstado.Properties.Items.AddRange(new object[] {
            "PENDIENTES DE APROBACION",
            "APROBADOS"});
            this.cboEstado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboEstado.Size = new System.Drawing.Size(187, 20);
            this.cboEstado.TabIndex = 63;
            this.cboEstado.EditValueChanged += new System.EventHandler(this.cboEstado_EditValueChanged);
            // 
            // CuadrocomparativoListadoAprobacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 398);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.gcConsulta);
            this.Controls.Add(this.iIdsucursal);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.btnSeleccionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuadrocomparativoListadoAprobacionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Estudio de Mercado pendientes de aprobación";
            this.Load += new System.EventHandler(this.CuadrocomparativoListadoAprobacionFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CuadrocomparativoListadoAprobacionFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdsucursal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btnFiltrar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboEstado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}