namespace WinFormsApp
{
    partial class ListadoTipoCambioFrm
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
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoTipoCambioFrm));
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.gcDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.cboEjercicio = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEjercicio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(288, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(198, 411);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem4.Text = "Seleccionar registro";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnSeleccionar.SuperTip = superToolTip4;
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Aceptar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // gcDetalle
            // 
            this.gcDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDetalle.Location = new System.Drawing.Point(12, 35);
            this.gcDetalle.MainView = this.gvDetalle;
            this.gcDetalle.Name = "gcDetalle";
            this.gcDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerico3});
            this.gcDetalle.Size = new System.Drawing.Size(360, 370);
            this.gcDetalle.TabIndex = 8;
            this.gcDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetalle});
            // 
            // gvDetalle
            // 
            this.gvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn22,
            this.gridColumn19});
            this.gvDetalle.GridControl = this.gcDetalle;
            this.gvDetalle.Name = "gvDetalle";
            this.gvDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.Editable = false;
            this.gvDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.gvDetalle.OptionsCustomization.AllowFilter = false;
            this.gvDetalle.OptionsCustomization.AllowGroup = false;
            this.gvDetalle.OptionsCustomization.AllowSort = false;
            this.gvDetalle.OptionsMenu.EnableColumnMenu = false;
            this.gvDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvDetalle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Día";
            this.gridColumn23.FieldName = "Dia";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            this.gridColumn23.Width = 50;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Compra";
            this.gridColumn22.ColumnEdit = this.riNumerico3;
            this.gridColumn22.FieldName = "Compra";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            this.gridColumn22.Width = 100;
            // 
            // riNumerico3
            // 
            this.riNumerico3.AutoHeight = false;
            this.riNumerico3.DisplayFormat.FormatString = "n3";
            this.riNumerico3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico3.EditFormat.FormatString = "n3";
            this.riNumerico3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico3.Mask.EditMask = "n3";
            this.riNumerico3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico3.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico3.Name = "riNumerico3";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Venta";
            this.gridColumn19.ColumnEdit = this.riNumerico3;
            this.gridColumn19.FieldName = "Venta";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            this.gridColumn19.Width = 110;
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(161, 9);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombremes", "Mes")});
            this.cboMes.Size = new System.Drawing.Size(121, 20);
            this.cboMes.TabIndex = 12;
            this.cboMes.EditValueChanged += new System.EventHandler(this.cboMes_EditValueChanged);
            // 
            // cboEjercicio
            // 
            this.cboEjercicio.Location = new System.Drawing.Point(57, 9);
            this.cboEjercicio.Name = "cboEjercicio";
            this.cboEjercicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEjercicio.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Anioejercicio", "Ejercicio")});
            this.cboEjercicio.Size = new System.Drawing.Size(73, 20);
            this.cboEjercicio.TabIndex = 10;
            this.cboEjercicio.EditValueChanged += new System.EventHandler(this.cboEjercicio_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(136, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Mes";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Ejercicio";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnConsultar.Location = new System.Drawing.Point(288, 7);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem5.Text = "Seleccionar registro";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnConsultar.SuperTip = superToolTip5;
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 411);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(180, 23);
            toolTipTitleItem6.Text = "Seleccionar registro";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.simpleButton1.SuperTip = superToolTip6;
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "Registrar el mes seleccionado";
            this.simpleButton1.Click += new System.EventHandler(this.BtnRegistrarMes);
            // 
            // ListadoTipoCambioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(379, 440);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboEjercicio);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gcDetalle);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoTipoCambioFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de cambio";
            this.Load += new System.EventHandler(this.ListadoTipoCambioFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEjercicio.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        public DevExpress.XtraGrid.GridControl gcDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico3;
        private DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraEditors.LookUpEdit cboEjercicio;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}