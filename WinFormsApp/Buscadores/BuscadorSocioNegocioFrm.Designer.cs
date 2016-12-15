namespace WinFormsApp
{
    partial class BuscadorSocioNegocioFrm
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
            this.gcSocioNegocio = new DevExpress.XtraGrid.GridControl();
            this.gvSocioNegocio = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatoABuscar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoBusqueda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcSocioNegocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSocioNegocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBusqueda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSocioNegocio
            // 
            this.gcSocioNegocio.Location = new System.Drawing.Point(5, 64);
            this.gcSocioNegocio.MainView = this.gvSocioNegocio;
            this.gcSocioNegocio.Name = "gcSocioNegocio";
            this.gcSocioNegocio.Size = new System.Drawing.Size(654, 436);
            this.gcSocioNegocio.TabIndex = 4;
            this.gcSocioNegocio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSocioNegocio});
            // 
            // gvSocioNegocio
            // 
            this.gvSocioNegocio.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn3});
            this.gvSocioNegocio.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvSocioNegocio.GridControl = this.gcSocioNegocio;
            this.gvSocioNegocio.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvSocioNegocio.Name = "gvSocioNegocio";
            this.gvSocioNegocio.OptionsBehavior.ReadOnly = true;
            this.gvSocioNegocio.OptionsView.ColumnAutoWidth = false;
            this.gvSocioNegocio.OptionsView.ShowGroupPanel = false;
            this.gvSocioNegocio.OptionsView.ShowViewCaption = true;
            this.gvSocioNegocio.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvSocioNegocio.ViewCaption = "Socios de Negocio";
            this.gvSocioNegocio.ShownEditor += new System.EventHandler(this.gvSocioNegocio_ShownEditor);
            this.gvSocioNegocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvSocioNegocio_KeyPress);
            this.gvSocioNegocio.DoubleClick += new System.EventHandler(this.gvSocioNegocio_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idsocionegocio";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Razón Social";
            this.gridColumn2.FieldName = "Razonsocial";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 250;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nombre Comercial";
            this.gridColumn5.FieldName = "Nombrecomercial";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 200;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tipo Doc.";
            this.gridColumn4.FieldName = "Abreviaturadocentidad";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 78;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "N° Documento";
            this.gridColumn3.FieldName = "Nrodocentidadprincipal";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 89;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(575, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(485, 506);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtDatoABuscar
            // 
            this.txtDatoABuscar.Location = new System.Drawing.Point(78, 38);
            this.txtDatoABuscar.Name = "txtDatoABuscar";
            this.txtDatoABuscar.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatoABuscar.Size = new System.Drawing.Size(573, 20);
            this.txtDatoABuscar.TabIndex = 3;
            this.txtDatoABuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatoABuscar_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "&Dato a buscar";
            // 
            // cboTipoBusqueda
            // 
            this.cboTipoBusqueda.Location = new System.Drawing.Point(78, 12);
            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
            this.cboTipoBusqueda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoBusqueda.Properties.Items.AddRange(new object[] {
            "RAZON SOCIAL",
            "NOMBRE COMERCIAL",
            "Nº DOCUMENTO"});
            this.cboTipoBusqueda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoBusqueda.Size = new System.Drawing.Size(235, 20);
            this.cboTipoBusqueda.TabIndex = 1;
            this.cboTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.cboTipoBusqueda_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Buscar por";
            // 
            // BuscadorSocioNegocioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(665, 538);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboTipoBusqueda);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDatoABuscar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcSocioNegocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorSocioNegocioFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar socio de negocio";
            this.Load += new System.EventHandler(this.BuscadorSocioNegocioFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSocioNegocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSocioNegocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBusqueda.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSocioNegocio;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSocioNegocio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.TextEdit txtDatoABuscar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoBusqueda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}