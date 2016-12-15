namespace WinFormsApp
{
    partial class HistorialDocumentosFrm
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
            this.gcHistorial = new DevExpress.XtraGrid.GridControl();
            this.gvHistorial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboBuscar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.iNumero = new DevExpress.XtraEditors.TextEdit();
            this.iSerie = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iIdrequerimiento = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdrequerimiento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHistorial
            // 
            this.gcHistorial.Location = new System.Drawing.Point(2, 31);
            this.gcHistorial.MainView = this.gvHistorial;
            this.gcHistorial.Name = "gcHistorial";
            this.gcHistorial.Size = new System.Drawing.Size(1068, 262);
            this.gcHistorial.TabIndex = 4;
            this.gcHistorial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHistorial});
            // 
            // gvHistorial
            // 
            this.gvHistorial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn16,
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.gvHistorial.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvHistorial.GridControl = this.gcHistorial;
            this.gvHistorial.Name = "gvHistorial";
            this.gvHistorial.OptionsBehavior.Editable = false;
            this.gvHistorial.OptionsBehavior.ReadOnly = true;
            this.gvHistorial.OptionsView.ColumnAutoWidth = false;
            this.gvHistorial.OptionsView.ShowGroupPanel = false;
            this.gvHistorial.OptionsView.ShowViewCaption = true;
            this.gvHistorial.ViewCaption = "Historial de Documentos";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Serie";
            this.gridColumn2.FieldName = "seriereq";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Numero";
            this.gridColumn5.FieldName = "numeroreq";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Fecha Rq";
            this.gridColumn7.FieldName = "fechareq";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Fecha Aprueba";
            this.gridColumn16.FieldName = "fechaaprobacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Solicitante";
            this.gridColumn1.FieldName = "solicitante";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Operacion";
            this.gridColumn9.FieldName = "nombrecptooperacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nº Orden Compra";
            this.gridColumn4.FieldName = "numeroordencompra";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha O/C";
            this.gridColumn3.FieldName = "fechaordencompra";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ruc";
            this.gridColumn6.FieldName = "ruc";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Razon Social";
            this.gridColumn8.FieldName = "razonsocial";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tipo";
            this.gridColumn10.FieldName = "abreviaturatipoformato";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nº Comprobante";
            this.gridColumn11.FieldName = "numerocpcompra";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Fecha";
            this.gridColumn12.FieldName = "fechaemision";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Moneda";
            this.gridColumn13.FieldName = "simbolomoneda";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Importe";
            this.gridColumn14.FieldName = "totaldocumento";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 14;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Condicion";
            this.gridColumn15.FieldName = "nombrecondicion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(985, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::WinFormsApp.Properties.Resources.Action_Search;
            this.btnConsultar.Location = new System.Drawing.Point(477, 3);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Buscar";
            this.btnConsultar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 69;
            this.labelControl2.Text = "Buscar por";
            // 
            // cboBuscar
            // 
            this.cboBuscar.Location = new System.Drawing.Point(67, 5);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBuscar.Properties.Items.AddRange(new object[] {
            "NUMERO DE REQUERIMIENTO",
            "NUMERO DE ORDEN DE COMPRA"});
            this.cboBuscar.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBuscar.Size = new System.Drawing.Size(195, 20);
            this.cboBuscar.TabIndex = 0;
            // 
            // iNumero
            // 
            this.iNumero.EditValue = "0";
            this.iNumero.Location = new System.Drawing.Point(386, 5);
            this.iNumero.Name = "iNumero";
            this.iNumero.Properties.Mask.EditMask = "d8";
            this.iNumero.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iNumero.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iNumero.Size = new System.Drawing.Size(85, 20);
            this.iNumero.TabIndex = 2;
            // 
            // iSerie
            // 
            this.iSerie.EditValue = "0";
            this.iSerie.Location = new System.Drawing.Point(342, 5);
            this.iSerie.Name = "iSerie";
            this.iSerie.Properties.Appearance.Options.UseTextOptions = true;
            this.iSerie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iSerie.Properties.Mask.EditMask = "d4";
            this.iSerie.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.iSerie.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.iSerie.Size = new System.Drawing.Size(41, 20);
            this.iSerie.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(265, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 72;
            this.labelControl1.Text = "Serie y número";
            // 
            // iIdrequerimiento
            // 
            this.iIdrequerimiento.EditValue = 0;
            this.iIdrequerimiento.Location = new System.Drawing.Point(6, 295);
            this.iIdrequerimiento.Name = "iIdrequerimiento";
            this.iIdrequerimiento.Properties.AllowFocused = false;
            this.iIdrequerimiento.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdrequerimiento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdrequerimiento.Properties.ReadOnly = true;
            this.iIdrequerimiento.Size = new System.Drawing.Size(56, 20);
            this.iIdrequerimiento.TabIndex = 73;
            this.iIdrequerimiento.TabStop = false;
            this.iIdrequerimiento.Visible = false;
            // 
            // HistorialDocumentosFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1075, 322);
            this.Controls.Add(this.iIdrequerimiento);
            this.Controls.Add(this.iNumero);
            this.Controls.Add(this.iSerie);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboBuscar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistorialDocumentosFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Documentos";
            this.Load += new System.EventHandler(this.HistorialDocumentosFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HistorialDocumentosFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gcHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdrequerimiento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcHistorial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistorial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboBuscar;
        private DevExpress.XtraEditors.TextEdit iNumero;
        private DevExpress.XtraEditors.TextEdit iSerie;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.TextEdit iIdrequerimiento;
    }
}