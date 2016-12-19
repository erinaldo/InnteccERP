namespace WinFormsApp
{
    partial class BuscadorArticuloCondicionFrm
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
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNombreArticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.txtCodigoInterno = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigoBarra = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcArticulo = new DevExpress.XtraGrid.GridControl();
            this.gvArticulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riMemoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcPreciolista = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPublico = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoInterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riMemoEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(887, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(797, 465);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Seleccionar registro";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSeleccionar.SuperTip = superToolTip1;
            this.btnSeleccionar.TabIndex = 8;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Location = new System.Drawing.Point(480, 9);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreArticulo.Size = new System.Drawing.Size(491, 20);
            toolTipTitleItem2.Text = "Digite parte del nombre del articulo a buscar.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.txtNombreArticulo.SuperTip = superToolTip2;
            this.txtNombreArticulo.TabIndex = 5;
            this.txtNombreArticulo.Enter += new System.EventHandler(this.txtDatoABuscar_Enter);
            this.txtNombreArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatoABuscar_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Código interno";
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
            this.btnNuevoRegistro.Visible = false;
            this.btnNuevoRegistro.Click += new System.EventHandler(this.btnNuevoRegistro_Click);
            // 
            // txtCodigoInterno
            // 
            this.txtCodigoInterno.Location = new System.Drawing.Point(88, 9);
            this.txtCodigoInterno.Name = "txtCodigoInterno";
            this.txtCodigoInterno.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoInterno.Size = new System.Drawing.Size(64, 20);
            toolTipTitleItem4.Text = "Digite parte del código a buscar";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.txtCodigoInterno.SuperTip = superToolTip4;
            this.txtCodigoInterno.TabIndex = 1;
            this.txtCodigoInterno.Enter += new System.EventHandler(this.txtCodigoInterno_Enter);
            this.txtCodigoInterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(241, 9);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarra.Size = new System.Drawing.Size(137, 20);
            toolTipTitleItem5.Text = "Digite parte del código a buscar";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.txtCodigoBarra.SuperTip = superToolTip5;
            this.txtCodigoBarra.TabIndex = 3;
            this.txtCodigoBarra.Enter += new System.EventHandler(this.txtCodigoBarra_Enter);
            this.txtCodigoBarra.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoBarra_Validating);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(158, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Código de &barra";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(382, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(91, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "&Nombre de Artículo";
            // 
            // gcArticulo
            // 
            this.gcArticulo.Location = new System.Drawing.Point(12, 35);
            this.gcArticulo.MainView = this.gvArticulo;
            this.gcArticulo.Name = "gcArticulo";
            this.gcArticulo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerico4,
            this.riMemoEdit});
            this.gcArticulo.Size = new System.Drawing.Size(960, 424);
            this.gcArticulo.TabIndex = 10;
            this.gcArticulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvArticulo});
            // 
            // gvArticulo
            // 
            this.gvArticulo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gcPreciolista,
            this.gcPublico});
            this.gvArticulo.GridControl = this.gcArticulo;
            this.gvArticulo.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvArticulo.Name = "gvArticulo";
            this.gvArticulo.OptionsBehavior.ReadOnly = true;
            this.gvArticulo.OptionsMenu.EnableColumnMenu = false;
            this.gvArticulo.OptionsMenu.EnableFooterMenu = false;
            this.gvArticulo.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvArticulo.OptionsView.ColumnAutoWidth = false;
            this.gvArticulo.OptionsView.RowAutoHeight = true;
            this.gvArticulo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvArticulo.ShownEditor += new System.EventHandler(this.gvArticulo_ShownEditor);
            this.gvArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvArticulo_KeyPress);
            this.gvArticulo.DoubleClick += new System.EventHandler(this.gvArticulo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cod. Int.";
            this.gridColumn1.FieldName = "Codigoarticulo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 64;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cod. Prov.";
            this.gridColumn2.FieldName = "Codigoproveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 86;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nombre Articulo";
            this.gridColumn3.ColumnEdit = this.riMemoEdit;
            this.gridColumn3.FieldName = "Nombrearticulo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 380;
            // 
            // riMemoEdit
            // 
            this.riMemoEdit.Name = "riMemoEdit";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Marca";
            this.gridColumn4.FieldName = "Nombremarca";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unidad";
            this.gridColumn5.FieldName = "Abrunidadmedida";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Stock";
            this.gridColumn6.ColumnEdit = this.riNumerico4;
            this.gridColumn6.FieldName = "Stock";
            this.gridColumn6.MaxWidth = 65;
            this.gridColumn6.MinWidth = 65;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 65;
            // 
            // riNumerico4
            // 
            this.riNumerico4.Appearance.Options.UseTextOptions = true;
            this.riNumerico4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.riNumerico4.DisplayFormat.FormatString = "n2";
            this.riNumerico4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.EditFormat.FormatString = "n2";
            this.riNumerico4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.Mask.EditMask = "n2";
            this.riNumerico4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico4.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico4.Name = "riNumerico4";
            // 
            // gcPreciolista
            // 
            this.gcPreciolista.Caption = "Precio Lista";
            this.gcPreciolista.ColumnEdit = this.riNumerico4;
            this.gcPreciolista.FieldName = "Preciocreditoopcion2";
            this.gcPreciolista.MaxWidth = 65;
            this.gcPreciolista.MinWidth = 65;
            this.gcPreciolista.Name = "gcPreciolista";
            this.gcPreciolista.Visible = true;
            this.gcPreciolista.VisibleIndex = 6;
            this.gcPreciolista.Width = 65;
            // 
            // gcPublico
            // 
            this.gcPublico.Caption = "Publico";
            this.gcPublico.ColumnEdit = this.riNumerico4;
            this.gcPublico.FieldName = "Preciosugerido";
            this.gcPublico.MaxWidth = 65;
            this.gcPublico.MinWidth = 65;
            this.gcPublico.Name = "gcPublico";
            this.gcPublico.Visible = true;
            this.gcPublico.VisibleIndex = 7;
            this.gcPublico.Width = 65;
            // 
            // BuscadorArticuloCondicionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(984, 494);
            this.Controls.Add(this.gcArticulo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCodigoInterno);
            this.Controls.Add(this.btnNuevoRegistro);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNombreArticulo);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorArticuloCondicionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Artículos";
            this.Load += new System.EventHandler(this.BuscadorArticuloCondicionFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoInterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riMemoEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.TextEdit txtNombreArticulo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoRegistro;
        private DevExpress.XtraEditors.TextEdit txtCodigoInterno;
        private DevExpress.XtraEditors.TextEdit txtCodigoBarra;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcPreciolista;
        private DevExpress.XtraGrid.Columns.GridColumn gcPublico;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico4;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit riMemoEdit;
    }
}