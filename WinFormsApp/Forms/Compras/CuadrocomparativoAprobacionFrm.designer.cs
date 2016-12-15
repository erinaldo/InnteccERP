namespace WinFormsApp
{
    partial class CuadrocomparativoAprobacionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuadrocomparativoAprobacionFrm));
            this.btnActualizarEstado = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.iGlosareq = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.iIdestadoreq = new DevExpress.XtraEditors.LookUpEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.iObservacionReq = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.rTotaldocumento = new DevExpress.XtraEditors.TextEdit();
            this.tcRequerimientos = new DevExpress.XtraTab.XtraTabControl();
            this.tpRequerimientos = new DevExpress.XtraTab.XtraTabPage();
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiTotal = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tpEstadoAprobacion = new DevExpress.XtraTab.XtraTabPage();
            this.gcHistorialAproReq = new DevExpress.XtraGrid.GridControl();
            this.gvHistorialAproReq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riFechaHora = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iGlosareq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdestadoreq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iObservacionReq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTotaldocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcRequerimientos)).BeginInit();
            this.tcRequerimientos.SuspendLayout();
            this.tpRequerimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.tpEstadoAprobacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistorialAproReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistorialAproReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Image = global::WinFormsApp.Properties.Resources.Action_Save_New;
            this.btnActualizarEstado.Location = new System.Drawing.Point(902, 455);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(110, 23);
            this.btnActualizarEstado.TabIndex = 3;
            this.btnActualizarEstado.Text = "Cambiar estado";
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(10, 398);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(58, 13);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "Justificación";
            // 
            // iGlosareq
            // 
            this.iGlosareq.Location = new System.Drawing.Point(74, 395);
            this.iGlosareq.Name = "iGlosareq";
            this.iGlosareq.Properties.ReadOnly = true;
            this.iGlosareq.Size = new System.Drawing.Size(450, 35);
            this.iGlosareq.TabIndex = 28;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(635, 460);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(33, 13);
            this.labelControl17.TabIndex = 63;
            this.labelControl17.Text = "Estado";
            // 
            // iIdestadoreq
            // 
            this.iIdestadoreq.Location = new System.Drawing.Point(674, 456);
            this.iIdestadoreq.Name = "iIdestadoreq";
            this.iIdestadoreq.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.iIdestadoreq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdestadoreq.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Idestadoreq", "Id.", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombreestadoreq", "Descripción")});
            this.iIdestadoreq.Properties.NullText = "";
            this.iIdestadoreq.Properties.ShowFooter = false;
            this.iIdestadoreq.Properties.ShowHeader = false;
            this.iIdestadoreq.Size = new System.Drawing.Size(224, 20);
            this.iIdestadoreq.TabIndex = 62;
            this.iIdestadoreq.Tag = "Seleccione el estado del requerimiento";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::WinFormsApp.Properties.Resources.Action_Refresh;
            this.btnConsultar.Location = new System.Drawing.Point(10, 452);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 23);
            this.btnConsultar.TabIndex = 64;
            this.btnConsultar.Text = "Actualizar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // iObservacionReq
            // 
            this.iObservacionReq.Location = new System.Drawing.Point(596, 394);
            this.iObservacionReq.Name = "iObservacionReq";
            this.iObservacionReq.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iObservacionReq.Size = new System.Drawing.Size(416, 35);
            this.iObservacionReq.TabIndex = 65;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(532, 399);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "Observación";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(871, 435);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(67, 13);
            this.labelControl24.TabIndex = 90;
            this.labelControl24.Text = "T. Documento";
            // 
            // rTotaldocumento
            // 
            this.rTotaldocumento.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rTotaldocumento.Location = new System.Drawing.Point(944, 432);
            this.rTotaldocumento.Name = "rTotaldocumento";
            this.rTotaldocumento.Properties.Appearance.Options.UseTextOptions = true;
            this.rTotaldocumento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rTotaldocumento.Properties.Mask.EditMask = "n";
            this.rTotaldocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rTotaldocumento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.rTotaldocumento.Properties.ReadOnly = true;
            this.rTotaldocumento.Size = new System.Drawing.Size(70, 20);
            this.rTotaldocumento.TabIndex = 91;
            this.rTotaldocumento.TabStop = false;
            // 
            // tcRequerimientos
            // 
            this.tcRequerimientos.Location = new System.Drawing.Point(10, 7);
            this.tcRequerimientos.Name = "tcRequerimientos";
            this.tcRequerimientos.SelectedTabPage = this.tpRequerimientos;
            this.tcRequerimientos.Size = new System.Drawing.Size(1002, 380);
            this.tcRequerimientos.TabIndex = 92;
            this.tcRequerimientos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpRequerimientos,
            this.tpEstadoAprobacion});
            this.tcRequerimientos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tcRequerimientos_MouseUp);
            // 
            // tpRequerimientos
            // 
            this.tpRequerimientos.Controls.Add(this.gcConsulta);
            this.tpRequerimientos.Name = "tpRequerimientos";
            this.tpRequerimientos.Size = new System.Drawing.Size(996, 352);
            this.tpRequerimientos.Text = "Requerimientos pendientes de aprobación";
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConsulta.Location = new System.Drawing.Point(0, 0);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.riDocumento,
            this.tiTotal});
            this.gcConsulta.Size = new System.Drawing.Size(996, 352);
            this.gcConsulta.TabIndex = 2;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            this.gvConsulta.OptionsView.ShowGroupPanel = false;
            this.gvConsulta.ViewCaption = "Requerimientos";
            this.gvConsulta.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvConsulta_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idcuadrocomparativo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 40;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tipo";
            this.gridColumn3.FieldName = "Nombretipoformato";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Serie";
            this.gridColumn4.FieldName = "Seriecc";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Documento";
            this.gridColumn5.ColumnEdit = this.riDocumento;
            this.gridColumn5.FieldName = "Numerocc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // riDocumento
            // 
            this.riDocumento.AutoHeight = false;
            this.riDocumento.Mask.EditMask = "d8";
            this.riDocumento.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riDocumento.Name = "riDocumento";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fechaemision";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Empleado";
            this.gridColumn6.FieldName = "Nombreresponsable";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.ColumnEdit = this.tiTotal;
            this.gridColumn9.FieldName = "Totalbuenapro";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // tiTotal
            // 
            this.tiTotal.AutoHeight = false;
            this.tiTotal.Mask.EditMask = "n2";
            this.tiTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tiTotal.Name = "tiTotal";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Concepto";
            this.gridColumn11.FieldName = "Nombrecptooperacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Estado";
            this.gridColumn12.FieldName = "Nombreestado";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Sucursal";
            this.gridColumn13.FieldName = "Nombresucursal";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // tpEstadoAprobacion
            // 
            this.tpEstadoAprobacion.Controls.Add(this.gcHistorialAproReq);
            this.tpEstadoAprobacion.Name = "tpEstadoAprobacion";
            this.tpEstadoAprobacion.Size = new System.Drawing.Size(996, 352);
            this.tpEstadoAprobacion.Text = "Historial de Aprobación";
            // 
            // gcHistorialAproReq
            // 
            this.gcHistorialAproReq.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcHistorialAproReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHistorialAproReq.Location = new System.Drawing.Point(0, 0);
            this.gcHistorialAproReq.MainView = this.gvHistorialAproReq;
            this.gcHistorialAproReq.Name = "gcHistorialAproReq";
            this.gcHistorialAproReq.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riFechaHora});
            this.gcHistorialAproReq.Size = new System.Drawing.Size(996, 352);
            this.gcHistorialAproReq.TabIndex = 3;
            this.gcHistorialAproReq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHistorialAproReq});
            // 
            // gvHistorialAproReq
            // 
            this.gvHistorialAproReq.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn30,
            this.gridColumn31});
            this.gvHistorialAproReq.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvHistorialAproReq.GridControl = this.gcHistorialAproReq;
            this.gvHistorialAproReq.Name = "gvHistorialAproReq";
            this.gvHistorialAproReq.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvHistorialAproReq.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvHistorialAproReq.OptionsBehavior.ReadOnly = true;
            this.gvHistorialAproReq.OptionsView.ColumnAutoWidth = false;
            this.gvHistorialAproReq.OptionsView.ShowGroupPanel = false;
            this.gvHistorialAproReq.ViewCaption = "Requerimientos";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Id.";
            this.gridColumn16.FieldName = "Iddocumentoaprobacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idecargo", "Nº {0}")});
            this.gridColumn16.Width = 67;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Empleado que aprueba";
            this.gridColumn17.FieldName = "Nombreempleado";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 0;
            this.gridColumn17.Width = 139;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Fecha y hora";
            this.gridColumn18.ColumnEdit = this.riFechaHora;
            this.gridColumn18.FieldName = "Fechaaprobacion";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            // 
            // riFechaHora
            // 
            this.riFechaHora.AutoHeight = false;
            this.riFechaHora.Mask.EditMask = "g";
            this.riFechaHora.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.riFechaHora.Mask.UseMaskAsDisplayFormat = true;
            this.riFechaHora.Name = "riFechaHora";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Aprobado";
            this.gridColumn30.FieldName = "Aprobado";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 2;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Comentario";
            this.gridColumn31.FieldName = "Comentario";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 3;
            // 
            // CuadrocomparativoAprobacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 484);
            this.Controls.Add(this.tcRequerimientos);
            this.Controls.Add(this.labelControl24);
            this.Controls.Add(this.rTotaldocumento);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iObservacionReq);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.iIdestadoreq);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.iGlosareq);
            this.Controls.Add(this.btnActualizarEstado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuadrocomparativoAprobacionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobacion de Estudio de Mercado";
            this.Load += new System.EventHandler(this.CuadrocomparativoAprobacionFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CuadrocomparativoAprobacionFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iGlosareq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdestadoreq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iObservacionReq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTotaldocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcRequerimientos)).EndInit();
            this.tcRequerimientos.ResumeLayout(false);
            this.tpRequerimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.tpEstadoAprobacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHistorialAproReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistorialAproReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnActualizarEstado;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.MemoEdit iGlosareq;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LookUpEdit iIdestadoreq;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.MemoEdit iObservacionReq;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.TextEdit rTotaldocumento;
        private DevExpress.XtraTab.XtraTabControl tcRequerimientos;
        private DevExpress.XtraTab.XtraTabPage tpRequerimientos;
        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tiTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraTab.XtraTabPage tpEstadoAprobacion;
        private DevExpress.XtraGrid.GridControl gcHistorialAproReq;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistorialAproReq;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riFechaHora;


    }
}