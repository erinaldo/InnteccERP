namespace WinFormsApp
{
    partial class StockMinimoRpFrm
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMinimoRpFrm));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.iFechaInicio = new DevExpress.XtraEditors.DateEdit();
            this.iFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rgOpcionReporte = new DevExpress.XtraEditors.RadioGroup();
            this.iIdempresa = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.iIdmarca = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iIdarticuloclasificacion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkClasificacion = new DevExpress.XtraEditors.CheckEdit();
            this.chkMarca = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticuloclasificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClasificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(490, 199);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(400, 199);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Seleccionar registro";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSeleccionar.SuperTip = superToolTip1;
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Aceptar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // iFechaInicio
            // 
            this.iFechaInicio.EditValue = null;
            this.iFechaInicio.Enabled = false;
            this.iFechaInicio.Location = new System.Drawing.Point(96, 8);
            this.iFechaInicio.Name = "iFechaInicio";
            this.iFechaInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.iFechaInicio.TabIndex = 5;
            // 
            // iFechaFinal
            // 
            this.iFechaFinal.EditValue = null;
            this.iFechaFinal.Location = new System.Drawing.Point(261, 8);
            this.iFechaFinal.Name = "iFechaFinal";
            this.iFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.iFechaFinal.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Inventario inicial";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(202, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Fecha final";
            // 
            // rgOpcionReporte
            // 
            this.rgOpcionReporte.EditValue = 0;
            this.rgOpcionReporte.Location = new System.Drawing.Point(52, 47);
            this.rgOpcionReporte.Name = "rgOpcionReporte";
            this.rgOpcionReporte.Properties.Columns = 1;
            this.rgOpcionReporte.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Todos los productos"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Todos los productos agrupados en")});
            this.rgOpcionReporte.Size = new System.Drawing.Size(210, 49);
            this.rgOpcionReporte.TabIndex = 14;
            this.rgOpcionReporte.SelectedIndexChanged += new System.EventHandler(this.rgOpcionReporte_SelectedIndexChanged);
            // 
            // iIdempresa
            // 
            this.iIdempresa.Location = new System.Drawing.Point(52, 24);
            this.iIdempresa.Name = "iIdempresa";
            this.iIdempresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdempresa.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdempresa.Properties.View = this.gridView4;
            this.iIdempresa.Size = new System.Drawing.Size(501, 20);
            this.iIdempresa.TabIndex = 87;
            this.iIdempresa.Tag = "Seleccione la empresa";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Id.";
            this.gridColumn7.FieldName = "Idempresa";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Empresa";
            this.gridColumn1.FieldName = "Razonsocial";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(6, 28);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(41, 13);
            this.labelControl20.TabIndex = 88;
            this.labelControl20.Text = "Empresa";
            // 
            // iIdmarca
            // 
            this.iIdmarca.Enabled = false;
            this.iIdmarca.Location = new System.Drawing.Point(138, 122);
            this.iIdmarca.Name = "iIdmarca";
            this.iIdmarca.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdmarca.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdmarca.Properties.View = this.gridView2;
            this.iIdmarca.Size = new System.Drawing.Size(415, 20);
            this.iIdmarca.TabIndex = 93;
            this.iIdmarca.Tag = "Seleccione la marca";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Id.";
            this.gridColumn6.FieldName = "Idmarca";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Marca";
            this.gridColumn2.FieldName = "Nombremarca";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // iIdarticuloclasificacion
            // 
            this.iIdarticuloclasificacion.Enabled = false;
            this.iIdarticuloclasificacion.Location = new System.Drawing.Point(138, 100);
            this.iIdarticuloclasificacion.Name = "iIdarticuloclasificacion";
            this.iIdarticuloclasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdarticuloclasificacion.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdarticuloclasificacion.Properties.View = this.gridView1;
            this.iIdarticuloclasificacion.Size = new System.Drawing.Size(415, 20);
            this.iIdarticuloclasificacion.TabIndex = 91;
            this.iIdarticuloclasificacion.Tag = "Seleccione la clasificación";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn16});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Id.";
            this.gridColumn4.FieldName = "Idarticuloclasificacion";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Código";
            this.gridColumn5.FieldName = "Codigoclasificacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Nombre clasifiación";
            this.gridColumn16.FieldName = "Nombreclasificacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // chkClasificacion
            // 
            this.chkClasificacion.Location = new System.Drawing.Point(52, 101);
            this.chkClasificacion.Name = "chkClasificacion";
            this.chkClasificacion.Properties.Caption = "Clasificación";
            this.chkClasificacion.Size = new System.Drawing.Size(80, 19);
            this.chkClasificacion.TabIndex = 95;
            this.chkClasificacion.CheckedChanged += new System.EventHandler(this.chkClasificacion_CheckedChanged);
            // 
            // chkMarca
            // 
            this.chkMarca.Location = new System.Drawing.Point(52, 123);
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Properties.Caption = "Marca";
            this.chkMarca.Size = new System.Drawing.Size(80, 19);
            this.chkMarca.TabIndex = 96;
            this.chkMarca.CheckedChanged += new System.EventHandler(this.chkMarca_CheckedChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rgOpcionReporte);
            this.groupControl2.Controls.Add(this.chkMarca);
            this.groupControl2.Controls.Add(this.labelControl20);
            this.groupControl2.Controls.Add(this.chkClasificacion);
            this.groupControl2.Controls.Add(this.iIdempresa);
            this.groupControl2.Controls.Add(this.iIdarticuloclasificacion);
            this.groupControl2.Controls.Add(this.iIdmarca);
            this.groupControl2.Location = new System.Drawing.Point(10, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(564, 148);
            this.groupControl2.TabIndex = 97;
            this.groupControl2.Text = "Consultar saldos de:";
            // 
            // StockMinimoRpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(582, 231);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iFechaFinal);
            this.Controls.Add(this.iFechaInicio);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockMinimoRpFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de stock minimo";
            this.Load += new System.EventHandler(this.StockMinimoRpFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcionReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdempresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticuloclasificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClasificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.DateEdit iFechaInicio;
        private DevExpress.XtraEditors.DateEdit iFechaFinal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup rgOpcionReporte;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdempresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdmarca;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdarticuloclasificacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.CheckEdit chkClasificacion;
        private DevExpress.XtraEditors.CheckEdit chkMarca;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}