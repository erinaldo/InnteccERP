namespace WinFormsApp
{
    partial class BuscadorPersonaFrm
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.gcPersona = new DevExpress.XtraGrid.GridControl();
            this.gvPersona = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatoABuscar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoBusqueda = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBusqueda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPersona
            // 
            this.gcPersona.Location = new System.Drawing.Point(13, 64);
            this.gcPersona.MainView = this.gvPersona;
            this.gcPersona.Name = "gcPersona";
            this.gcPersona.Size = new System.Drawing.Size(651, 395);
            this.gcPersona.TabIndex = 4;
            this.gcPersona.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersona});
            // 
            // gvPersona
            // 
            this.gvPersona.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn5});
            this.gvPersona.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvPersona.GridControl = this.gcPersona;
            this.gvPersona.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvPersona.Name = "gvPersona";
            this.gvPersona.OptionsBehavior.ReadOnly = true;
            this.gvPersona.OptionsView.ColumnAutoWidth = false;
            this.gvPersona.OptionsView.ShowGroupPanel = false;
            this.gvPersona.OptionsView.ShowViewCaption = true;
            this.gvPersona.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvPersona.ViewCaption = "Personas";
            this.gvPersona.ShownEditor += new System.EventHandler(this.gvPersona_ShownEditor);
            this.gvPersona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvSocioNegocio_KeyPress);
            this.gvPersona.DoubleClick += new System.EventHandler(this.gvSocioNegocio_DoubleClick);
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
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tipo Doc.";
            this.gridColumn4.FieldName = "Abreviaturadocentidad";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "N° Documento";
            this.gridColumn3.FieldName = "Nrodocentidad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 89;
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
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(580, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(490, 465);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Seleccionar registro";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSeleccionar.SuperTip = superToolTip1;
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtDatoABuscar
            // 
            this.txtDatoABuscar.Location = new System.Drawing.Point(81, 38);
            this.txtDatoABuscar.Name = "txtDatoABuscar";
            this.txtDatoABuscar.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatoABuscar.Size = new System.Drawing.Size(583, 20);
            toolTipTitleItem2.Text = "Digite un valor a buscar (Razon, N° Documento)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.txtDatoABuscar.SuperTip = superToolTip2;
            this.txtDatoABuscar.TabIndex = 3;
            this.txtDatoABuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatoABuscar_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "&Dato a buscar";
            // 
            // btnNuevoRegistro
            // 
            this.btnNuevoRegistro.Image = global::WinFormsApp.Properties.Resources.Action_Inline_New;
            this.btnNuevoRegistro.Location = new System.Drawing.Point(12, 465);
            this.btnNuevoRegistro.Name = "btnNuevoRegistro";
            this.btnNuevoRegistro.Size = new System.Drawing.Size(99, 23);
            toolTipTitleItem3.Text = "Crear nuevo registro";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnNuevoRegistro.SuperTip = superToolTip3;
            this.btnNuevoRegistro.TabIndex = 7;
            this.btnNuevoRegistro.Text = "Nuevo registro";
            this.btnNuevoRegistro.Click += new System.EventHandler(this.btnNuevoRegistro_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Buscar por";
            // 
            // cboTipoBusqueda
            // 
            this.cboTipoBusqueda.Location = new System.Drawing.Point(81, 12);
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
            // 
            // BuscadorPersonaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(671, 494);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboTipoBusqueda);
            this.Controls.Add(this.btnNuevoRegistro);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDatoABuscar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcPersona);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorPersonaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Personas";
            this.Load += new System.EventHandler(this.BuscadorPersonaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBusqueda.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPersona;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersona;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.TextEdit txtDatoABuscar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoBusqueda;
    }
}