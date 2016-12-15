namespace WinFormsApp
{
    partial class BuscadorUbicacionFrm
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.gcUbicacion = new DevExpress.XtraGrid.GridControl();
            this.gvUbicacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDatoABuscar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoRegistro = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUbicacion
            // 
            this.gcUbicacion.Location = new System.Drawing.Point(11, 35);
            this.gcUbicacion.MainView = this.gvUbicacion;
            this.gcUbicacion.Name = "gcUbicacion";
            this.gcUbicacion.Size = new System.Drawing.Size(675, 274);
            this.gcUbicacion.TabIndex = 2;
            this.gcUbicacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUbicacion});
            // 
            // gvUbicacion
            // 
            this.gvUbicacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn3});
            this.gvUbicacion.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvUbicacion.GridControl = this.gcUbicacion;
            this.gvUbicacion.Name = "gvUbicacion";
            this.gvUbicacion.OptionsBehavior.Editable = false;
            this.gvUbicacion.OptionsBehavior.ReadOnly = true;
            this.gvUbicacion.OptionsView.ColumnAutoWidth = false;
            this.gvUbicacion.OptionsView.ShowGroupPanel = false;
            this.gvUbicacion.OptionsView.ShowViewCaption = true;
            this.gvUbicacion.ViewCaption = "Ubicacion";
            this.gvUbicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvSocioNegocio_KeyPress);
            this.gvUbicacion.DoubleClick += new System.EventHandler(this.gvSocioNegocio_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idubicacion";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ambiente";
            this.gridColumn2.FieldName = "Ambiente";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Columna";
            this.gridColumn6.FieldName = "Columna";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fila";
            this.gridColumn4.FieldName = "Fila";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Almacen";
            this.gridColumn3.FieldName = "Nombrealmacen";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(604, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnSeleccionar.Location = new System.Drawing.Point(514, 315);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem4.Text = "Seleccionar registro";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnSeleccionar.SuperTip = superToolTip4;
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtDatoABuscar
            // 
            this.txtDatoABuscar.Location = new System.Drawing.Point(86, 10);
            this.txtDatoABuscar.Name = "txtDatoABuscar";
            this.txtDatoABuscar.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatoABuscar.Size = new System.Drawing.Size(600, 20);
            toolTipTitleItem5.Text = "Digite parte del nombre del articulo a buscar.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.txtDatoABuscar.SuperTip = superToolTip5;
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
            this.btnNuevoRegistro.Location = new System.Drawing.Point(13, 315);
            this.btnNuevoRegistro.Name = "btnNuevoRegistro";
            this.btnNuevoRegistro.Size = new System.Drawing.Size(99, 23);
            toolTipTitleItem2.Text = "Crear nuevo registro";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnNuevoRegistro.SuperTip = superToolTip2;
            this.btnNuevoRegistro.TabIndex = 5;
            this.btnNuevoRegistro.Text = "Nuevo registro";
            this.btnNuevoRegistro.Click += new System.EventHandler(this.btnNuevoRegistro_Click);
            // 
            // BuscadorUbicacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(692, 342);
            this.Controls.Add(this.btnNuevoRegistro);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDatoABuscar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcUbicacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscadorUbicacionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de Ubicacion";
            ((System.ComponentModel.ISupportInitialize)(this.gcUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatoABuscar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUbicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.TextEdit txtDatoABuscar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}