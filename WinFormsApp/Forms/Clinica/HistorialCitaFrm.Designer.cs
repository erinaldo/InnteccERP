namespace WinFormsApp
{
    partial class HistorialCitaFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialCitaFrm));
            this.dataSet1 = new System.Data.DataSet();
            this.dataTableLookUp = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iHoraprogramacion = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iFechaprogramacion = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iIdservicio = new DevExpress.XtraEditors.TextEdit();
            this.iIdmedico = new DevExpress.XtraEditors.TextEdit();
            this.gcCitas = new DevExpress.XtraGrid.GridControl();
            this.gvCitas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFechaHoraEvento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMotivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.riFechaHora = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraprogramacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaprogramacion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaprogramacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdservicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmedico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableLookUp});
            // 
            // dataTableLookUp
            // 
            this.dataTableLookUp.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTableLookUp.TableName = "TableLookUp";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Id";
            this.dataColumn1.ColumnName = "clnId";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Name";
            this.dataColumn2.ColumnName = "clnName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Department";
            this.dataColumn3.ColumnName = "clnDepartment";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(192, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Hora cita ";
            // 
            // iHoraprogramacion
            // 
            this.iHoraprogramacion.EditValue = new System.DateTime(2016, 8, 30, 0, 0, 0, 0);
            this.iHoraprogramacion.Location = new System.Drawing.Point(244, 12);
            this.iHoraprogramacion.Name = "iHoraprogramacion";
            this.iHoraprogramacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iHoraprogramacion.Properties.Appearance.Options.UseFont = true;
            this.iHoraprogramacion.Properties.Appearance.Options.UseTextOptions = true;
            this.iHoraprogramacion.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iHoraprogramacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iHoraprogramacion.Properties.Mask.EditMask = "t";
            this.iHoraprogramacion.Properties.ReadOnly = true;
            this.iHoraprogramacion.Size = new System.Drawing.Size(100, 20);
            this.iHoraprogramacion.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Fecha";
            // 
            // iFechaprogramacion
            // 
            this.iFechaprogramacion.EditValue = null;
            this.iFechaprogramacion.Location = new System.Drawing.Point(82, 12);
            this.iFechaprogramacion.Name = "iFechaprogramacion";
            this.iFechaprogramacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaprogramacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechaprogramacion.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.iFechaprogramacion.Properties.ReadOnly = true;
            this.iFechaprogramacion.Size = new System.Drawing.Size(99, 20);
            this.iFechaprogramacion.TabIndex = 1;
            this.iFechaprogramacion.Tag = "Ingrese la fecha";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(13, 94);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(33, 13);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "Medico";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Código";
            // 
            // iCodigoarticulo
            // 
            this.iCodigoarticulo.Location = new System.Drawing.Point(82, 38);
            this.iCodigoarticulo.Name = "iCodigoarticulo";
            this.iCodigoarticulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoarticulo.Properties.MaxLength = 10;
            this.iCodigoarticulo.Properties.ReadOnly = true;
            this.iCodigoarticulo.Size = new System.Drawing.Size(99, 20);
            this.iCodigoarticulo.TabIndex = 5;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(13, 68);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Servicio";
            // 
            // iIdservicio
            // 
            this.iIdservicio.EditValue = "";
            this.iIdservicio.Location = new System.Drawing.Point(82, 65);
            this.iIdservicio.Name = "iIdservicio";
            this.iIdservicio.Properties.NullText = "[EditValue is null]";
            this.iIdservicio.Properties.ReadOnly = true;
            this.iIdservicio.Size = new System.Drawing.Size(560, 20);
            this.iIdservicio.TabIndex = 7;
            this.iIdservicio.Tag = "Seleccione el servicio";
            // 
            // iIdmedico
            // 
            this.iIdmedico.EditValue = "";
            this.iIdmedico.Location = new System.Drawing.Point(82, 91);
            this.iIdmedico.Name = "iIdmedico";
            this.iIdmedico.Properties.NullText = "[EditValue is null]";
            this.iIdmedico.Properties.ReadOnly = true;
            this.iIdmedico.Size = new System.Drawing.Size(560, 20);
            this.iIdmedico.TabIndex = 9;
            this.iIdmedico.Tag = "Seleccione el medico";
            // 
            // gcCitas
            // 
            this.gcCitas.Location = new System.Drawing.Point(13, 117);
            this.gcCitas.MainView = this.gvCitas;
            this.gcCitas.Name = "gcCitas";
            this.gcCitas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riFechaHora});
            this.gcCitas.Size = new System.Drawing.Size(629, 317);
            this.gcCitas.TabIndex = 10;
            this.gcCitas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCitas});
            // 
            // gvCitas
            // 
            this.gvCitas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcId,
            this.gcFechaHoraEvento,
            this.gcPaciente,
            this.gcMotivo,
            this.gcEstado});
            this.gvCitas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvCitas.GridControl = this.gcCitas;
            this.gvCitas.Name = "gvCitas";
            this.gvCitas.OptionsBehavior.Editable = false;
            this.gvCitas.OptionsCustomization.AllowColumnMoving = false;
            this.gvCitas.OptionsCustomization.AllowGroup = false;
            this.gvCitas.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvCitas.OptionsMenu.EnableColumnMenu = false;
            this.gvCitas.OptionsMenu.EnableFooterMenu = false;
            this.gvCitas.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvCitas.OptionsView.ColumnAutoWidth = false;
            this.gvCitas.OptionsView.ShowGroupPanel = false;
            this.gvCitas.OptionsView.ShowViewCaption = true;
            this.gvCitas.ViewCaption = "Historial de eventos";
            // 
            // gcId
            // 
            this.gcId.Caption = "Id.";
            this.gcId.FieldName = "Idprogramacioncitadethistorial";
            this.gcId.Name = "gcId";
            this.gcId.Width = 61;
            // 
            // gcFechaHoraEvento
            // 
            this.gcFechaHoraEvento.Caption = "Fecha Hora Evento";
            this.gcFechaHoraEvento.DisplayFormat.FormatString = "g";
            this.gcFechaHoraEvento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcFechaHoraEvento.FieldName = "Fechahorahistorial";
            this.gcFechaHoraEvento.Name = "gcFechaHoraEvento";
            this.gcFechaHoraEvento.Visible = true;
            this.gcFechaHoraEvento.VisibleIndex = 0;
            this.gcFechaHoraEvento.Width = 104;
            // 
            // gcPaciente
            // 
            this.gcPaciente.Caption = "Paciente";
            this.gcPaciente.FieldName = "Razonsocialpersona";
            this.gcPaciente.Name = "gcPaciente";
            this.gcPaciente.Visible = true;
            this.gcPaciente.VisibleIndex = 1;
            this.gcPaciente.Width = 285;
            // 
            // gcMotivo
            // 
            this.gcMotivo.Caption = "Motivo";
            this.gcMotivo.FieldName = "Nombremotivocita";
            this.gcMotivo.Name = "gcMotivo";
            this.gcMotivo.Visible = true;
            this.gcMotivo.VisibleIndex = 2;
            this.gcMotivo.Width = 128;
            // 
            // gcEstado
            // 
            this.gcEstado.Caption = "Estado";
            this.gcEstado.FieldName = "Nombreestadocita";
            this.gcEstado.Name = "gcEstado";
            this.gcEstado.Visible = true;
            this.gcEstado.VisibleIndex = 3;
            this.gcEstado.Width = 87;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(555, 440);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 23);
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // riFechaHora
            // 
            this.riFechaHora.AutoHeight = false;
            this.riFechaHora.Mask.EditMask = "g";
            this.riFechaHora.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.riFechaHora.Name = "riFechaHora";
            // 
            // HistorialCitaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 468);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gcCitas);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iFechaprogramacion);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iCodigoarticulo);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iHoraprogramacion);
            this.Controls.Add(this.iIdservicio);
            this.Controls.Add(this.iIdmedico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistorialCitaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eventos por turno";
            this.Load += new System.EventHandler(this.HistorialCitaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iHoraprogramacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaprogramacion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechaprogramacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdservicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdmedico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTableLookUp;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit iHoraprogramacion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit iFechaprogramacion;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iCodigoarticulo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit iIdservicio;
        private DevExpress.XtraEditors.TextEdit iIdmedico;
        private DevExpress.XtraGrid.GridControl gcCitas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCitas;
        private DevExpress.XtraGrid.Columns.GridColumn gcId;
        private DevExpress.XtraGrid.Columns.GridColumn gcFechaHoraEvento;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaciente;
        private DevExpress.XtraGrid.Columns.GridColumn gcMotivo;
        private DevExpress.XtraGrid.Columns.GridColumn gcEstado;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riFechaHora;

    }
}