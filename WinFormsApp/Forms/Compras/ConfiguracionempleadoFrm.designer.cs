namespace WinFormsApp
{
    partial class ConfiguracionempleadoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionempleadoFrm));
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.gcArea = new DevExpress.XtraGrid.GridControl();
            this.gvArea = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iIdarea = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.iIdproyecto = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddArea = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelArea = new DevExpress.XtraEditors.SimpleButton();
            this.iIdempleado = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProyecto = new DevExpress.XtraGrid.GridControl();
            this.gvProyecto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelProyecto = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddProyecto = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdproyecto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(22, 12);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(46, 13);
            this.labelControl26.TabIndex = 60;
            this.labelControl26.Text = "Empleado";
            // 
            // gcArea
            // 
            this.gcArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcArea.Location = new System.Drawing.Point(22, 88);
            this.gcArea.MainView = this.gvArea;
            this.gcArea.Name = "gcArea";
            this.gcArea.Size = new System.Drawing.Size(428, 325);
            this.gcArea.TabIndex = 61;
            this.gcArea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArea});
            // 
            // gvArea
            // 
            this.gvArea.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn5});
            this.gvArea.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvArea.GridControl = this.gcArea;
            this.gvArea.Name = "gvArea";
            this.gvArea.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvArea.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvArea.OptionsBehavior.Editable = false;
            this.gvArea.OptionsCustomization.AllowGroup = false;
            this.gvArea.OptionsFind.AllowFindPanel = false;
            this.gvArea.OptionsView.ColumnAutoWidth = false;
            this.gvArea.OptionsView.ShowGroupPanel = false;
            this.gvArea.OptionsView.ShowViewCaption = true;
            this.gvArea.ViewCaption = "Áreas Asignadas";
            this.gvArea.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvArea_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idempleadoarea";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
            this.gridColumn1.Width = 67;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Código Área";
            this.gridColumn10.FieldName = "Codigoarea";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Área";
            this.gridColumn5.FieldName = "Nombrearea";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 104;
            // 
            // iIdarea
            // 
            this.iIdarea.Location = new System.Drawing.Point(74, 36);
            this.iIdarea.Name = "iIdarea";
            this.iIdarea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdarea.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdarea.Properties.View = this.gridView4;
            this.iIdarea.Size = new System.Drawing.Size(328, 20);
            this.iIdarea.TabIndex = 65;
            this.iIdarea.Tag = "Seleccione el Área";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id.";
            this.gridColumn7.FieldName = "Idarea";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Código";
            this.gridColumn8.FieldName = "Codigoarea";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Área";
            this.gridColumn9.FieldName = "Nombrearea";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(407, 38);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(43, 13);
            this.labelControl11.TabIndex = 66;
            this.labelControl11.Text = "Proyecto";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(22, 39);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(23, 13);
            this.labelControl10.TabIndex = 64;
            this.labelControl10.Text = "Área";
            // 
            // iIdproyecto
            // 
            this.iIdproyecto.Location = new System.Drawing.Point(456, 36);
            this.iIdproyecto.Name = "iIdproyecto";
            this.iIdproyecto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdproyecto.Properties.View = this.gridView5;
            this.iIdproyecto.Size = new System.Drawing.Size(420, 20);
            this.iIdproyecto.TabIndex = 67;
            this.iIdproyecto.Tag = "Seleccione el proyecto";
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn19});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Idproyecto";
            this.gridColumn6.FieldName = "Idproyecto";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Código";
            this.gridColumn11.FieldName = "Codigoproyecto";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Nombre proyecto";
            this.gridColumn12.FieldName = "Nombreproyecto";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Sucursal";
            this.gridColumn19.FieldName = "Nombresucursal";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            // 
            // btnAddArea
            // 
            this.btnAddArea.Image = global::WinFormsApp.Properties.Resources.Action_Inline_New;
            this.btnAddArea.Location = new System.Drawing.Point(22, 59);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(119, 23);
            this.btnAddArea.TabIndex = 69;
            this.btnAddArea.Text = "Agregar área";
            this.btnAddArea.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelArea
            // 
            this.btnDelArea.Image = global::WinFormsApp.Properties.Resources.Action_Delete_12x12;
            this.btnDelArea.Location = new System.Drawing.Point(147, 59);
            this.btnDelArea.Name = "btnDelArea";
            this.btnDelArea.Size = new System.Drawing.Size(119, 23);
            this.btnDelArea.TabIndex = 71;
            this.btnDelArea.Text = "Eliminar área";
            this.btnDelArea.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // iIdempleado
            // 
            this.iIdempleado.Location = new System.Drawing.Point(74, 9);
            this.iIdempleado.Name = "iIdempleado";
            this.iIdempleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdempleado.Properties.View = this.gridView3;
            this.iIdempleado.Size = new System.Drawing.Size(328, 20);
            this.iIdempleado.TabIndex = 74;
            this.iIdempleado.Tag = "Seleccione el empleado";
            this.iIdempleado.EditValueChanged += new System.EventHandler(this.iIdempleado_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Id.";
            this.gridColumn15.FieldName = "Idempleado";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Nombre";
            this.gridColumn16.FieldName = "Razonsocial";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "N° Doc. entidad";
            this.gridColumn17.FieldName = "Nrodocentidad";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 1;
            // 
            // gcProyecto
            // 
            this.gcProyecto.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProyecto.Location = new System.Drawing.Point(456, 88);
            this.gcProyecto.MainView = this.gvProyecto;
            this.gcProyecto.Name = "gcProyecto";
            this.gcProyecto.Size = new System.Drawing.Size(428, 325);
            this.gcProyecto.TabIndex = 75;
            this.gcProyecto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProyecto});
            // 
            // gvProyecto
            // 
            this.gvProyecto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn20,
            this.gridColumn21});
            this.gvProyecto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvProyecto.GridControl = this.gcProyecto;
            this.gvProyecto.Name = "gvProyecto";
            this.gvProyecto.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvProyecto.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvProyecto.OptionsBehavior.Editable = false;
            this.gvProyecto.OptionsCustomization.AllowGroup = false;
            this.gvProyecto.OptionsView.ColumnAutoWidth = false;
            this.gvProyecto.OptionsView.ShowGroupPanel = false;
            this.gvProyecto.OptionsView.ShowViewCaption = true;
            this.gvProyecto.ViewCaption = "Proyectos Asignados";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id.";
            this.gridColumn3.FieldName = "Idempleadoareaproyecto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
            this.gridColumn3.Width = 67;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Código Proyecto";
            this.gridColumn20.FieldName = "Codigoproyecto";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Proyecto";
            this.gridColumn21.FieldName = "Nombreproyecto";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 1;
            // 
            // btnDelProyecto
            // 
            this.btnDelProyecto.Image = global::WinFormsApp.Properties.Resources.Action_Delete_12x12;
            this.btnDelProyecto.Location = new System.Drawing.Point(579, 59);
            this.btnDelProyecto.Name = "btnDelProyecto";
            this.btnDelProyecto.Size = new System.Drawing.Size(119, 23);
            this.btnDelProyecto.TabIndex = 77;
            this.btnDelProyecto.Text = "Eliminar proyecto";
            this.btnDelProyecto.Click += new System.EventHandler(this.btnDelProyecto_Click);
            // 
            // btnAddProyecto
            // 
            this.btnAddProyecto.Image = global::WinFormsApp.Properties.Resources.Action_Inline_New;
            this.btnAddProyecto.Location = new System.Drawing.Point(454, 59);
            this.btnAddProyecto.Name = "btnAddProyecto";
            this.btnAddProyecto.Size = new System.Drawing.Size(119, 23);
            this.btnAddProyecto.TabIndex = 76;
            this.btnAddProyecto.Text = "Agregar proyecto";
            this.btnAddProyecto.Click += new System.EventHandler(this.btnAddProyecto_Click);
            // 
            // ConfiguracionempleadoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 414);
            this.Controls.Add(this.btnDelProyecto);
            this.Controls.Add(this.btnAddProyecto);
            this.Controls.Add(this.gcProyecto);
            this.Controls.Add(this.iIdempleado);
            this.Controls.Add(this.btnDelArea);
            this.Controls.Add(this.btnAddArea);
            this.Controls.Add(this.iIdarea);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.iIdproyecto);
            this.Controls.Add(this.gcArea);
            this.Controls.Add(this.labelControl26);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracionempleadoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de filtro para requerimientos";
            this.Load += new System.EventHandler(this.ConfiguracionempleadoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConfiguracionempleadoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gcArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdproyecto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraGrid.GridControl gcArea;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArea;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdarea;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdproyecto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnAddArea;
        private DevExpress.XtraEditors.SimpleButton btnDelArea;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdempleado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.GridControl gcProyecto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProyecto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.SimpleButton btnDelProyecto;
        private DevExpress.XtraEditors.SimpleButton btnAddProyecto;

    }
}