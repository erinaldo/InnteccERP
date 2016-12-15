namespace WinFormsApp
{
    partial class BuscadorArticuloInventarioFrm
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
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            this.gcArticulo = new DevExpress.XtraGrid.GridControl();
            this.gvArticulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatoABuscar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.reCaracteristicas = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reCaracteristicas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcArticulo
            // 
            this.gcArticulo.Location = new System.Drawing.Point(13, 36);
            this.gcArticulo.MainView = this.gvArticulo;
            this.gcArticulo.Name = "gcArticulo";
            this.gcArticulo.Size = new System.Drawing.Size(835, 328);
            this.gcArticulo.TabIndex = 2;
            this.gcArticulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulo});
            // 
            // gvArticulo
            // 
            this.gvArticulo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn7});
            this.gvArticulo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvArticulo.GridControl = this.gcArticulo;
            this.gvArticulo.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvArticulo.Name = "gvArticulo";
            this.gvArticulo.OptionsBehavior.ReadOnly = true;
            this.gvArticulo.OptionsView.ColumnAutoWidth = false;
            this.gvArticulo.OptionsView.ShowGroupPanel = false;
            this.gvArticulo.OptionsView.ShowViewCaption = true;
            this.gvArticulo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvArticulo.ViewCaption = "Articulos";
            this.gvArticulo.ShownEditor += new System.EventHandler(this.gvArticulo_ShownEditor);
            this.gvArticulo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvArticulo_FocusedRowChanged);
            this.gvArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvSocioNegocio_KeyPress);
            this.gvArticulo.DoubleClick += new System.EventHandler(this.gvSocioNegocio_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idarticulo";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Codigo";
            this.gridColumn2.FieldName = "Codigoarticulo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 47;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Clasificación";
            this.gridColumn6.FieldName = "Nombreclasificacion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nombre Articulo";
            this.gridColumn4.FieldName = "Nombrearticulo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 359;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Marca";
            this.gridColumn3.FieldName = "Nombremarca";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "N° de Serie";
            this.gridColumn8.FieldName = "Numerodeserie";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 129;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unidad";
            this.gridColumn5.FieldName = "Abrunidadmedida";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 42;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cod. Prov.";
            this.gridColumn7.FieldName = "Codigoproveedor";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 61;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(763, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(673, 465);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem5.Text = "Seleccionar registro";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnSeleccionar.SuperTip = superToolTip5;
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtDatoABuscar
            // 
            this.txtDatoABuscar.Location = new System.Drawing.Point(194, 10);
            this.txtDatoABuscar.Name = "txtDatoABuscar";
            this.txtDatoABuscar.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatoABuscar.Size = new System.Drawing.Size(653, 20);
            toolTipTitleItem6.Text = "Digite parte del nombre del articulo a buscar.";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.txtDatoABuscar.SuperTip = superToolTip6;
            this.txtDatoABuscar.TabIndex = 1;
            this.txtDatoABuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatoABuscar_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Dato a buscar";
            // 
            // btnNuevoRegistro
            // 
            this.btnNuevoRegistro.Image = global::WinFormsApp.Properties.Resources.Action_Inline_New;
            this.btnNuevoRegistro.Location = new System.Drawing.Point(12, 465);
            this.btnNuevoRegistro.Name = "btnNuevoRegistro";
            this.btnNuevoRegistro.Size = new System.Drawing.Size(99, 23);
            toolTipTitleItem2.Text = "Crear nuevo registro";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnNuevoRegistro.SuperTip = superToolTip2;
            this.btnNuevoRegistro.TabIndex = 5;
            this.btnNuevoRegistro.Text = "Nuevo registro";
            this.btnNuevoRegistro.Click += new System.EventHandler(this.btnNuevoRegistro_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(86, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Size = new System.Drawing.Size(102, 20);
            toolTipTitleItem7.Text = "Digite parte del código a buscar";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.txtCodigo.SuperTip = superToolTip7;
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 370);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Características";
            // 
            // reCaracteristicas
            // 
            this.reCaracteristicas.Location = new System.Drawing.Point(12, 389);
            this.reCaracteristicas.Name = "reCaracteristicas";
            this.reCaracteristicas.Properties.ReadOnly = true;
            this.reCaracteristicas.Size = new System.Drawing.Size(835, 70);
            this.reCaracteristicas.TabIndex = 9;
            this.reCaracteristicas.TabStop = false;
            // 
            // BuscadorArticuloInventarioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(852, 494);
            this.Controls.Add(this.reCaracteristicas);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnNuevoRegistro);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDatoABuscar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcArticulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorArticuloInventarioFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reCaracteristicas.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.TextEdit txtDatoABuscar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit reCaracteristicas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}