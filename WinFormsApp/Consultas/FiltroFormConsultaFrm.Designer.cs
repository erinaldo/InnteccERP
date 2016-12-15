namespace WinFormsApp
{
    partial class FiltroFormConsultaFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroFormConsultaFrm));
            this.deFechaInicial = new DevExpress.XtraEditors.DateEdit();
            this.cboTipoFiltro = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmdAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSalir = new DevExpress.XtraEditors.SimpleButton();
            this.deFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.cboEjercicio = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaInicial.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoFiltro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEjercicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaInicial
            // 
            this.deFechaInicial.EditValue = null;
            this.deFechaInicial.Location = new System.Drawing.Point(89, 90);
            this.deFechaInicial.Name = "deFechaInicial";
            this.deFechaInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaInicial.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.deFechaInicial.Size = new System.Drawing.Size(121, 20);
            this.deFechaInicial.TabIndex = 7;
            // 
            // cboTipoFiltro
            // 
            this.cboTipoFiltro.Location = new System.Drawing.Point(89, 12);
            this.cboTipoFiltro.Name = "cboTipoFiltro";
            this.cboTipoFiltro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoFiltro.Properties.Items.AddRange(new object[] {
            "TODO",
            "MES",
            "RANGO DE FECHAS"});
            this.cboTipoFiltro.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoFiltro.Size = new System.Drawing.Size(121, 20);
            this.cboTipoFiltro.TabIndex = 1;
            this.cboTipoFiltro.SelectedIndexChanged += new System.EventHandler(this.cboTipoFiltro_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tipo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ejercicio";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Mes";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Rango";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.cmdAceptar.Location = new System.Drawing.Point(54, 152);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 23);
            this.cmdAceptar.TabIndex = 9;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.cmdSalir.Location = new System.Drawing.Point(135, 152);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(75, 23);
            this.cmdSalir.TabIndex = 10;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // deFechaFinal
            // 
            this.deFechaFinal.EditValue = null;
            this.deFechaFinal.Location = new System.Drawing.Point(89, 115);
            this.deFechaFinal.Name = "deFechaFinal";
            this.deFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFinal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.deFechaFinal.Size = new System.Drawing.Size(121, 20);
            this.deFechaFinal.TabIndex = 8;
            // 
            // cboEjercicio
            // 
            this.cboEjercicio.Location = new System.Drawing.Point(89, 38);
            this.cboEjercicio.Name = "cboEjercicio";
            this.cboEjercicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEjercicio.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Anioejercicio", "Ejercicio")});
            this.cboEjercicio.Size = new System.Drawing.Size(121, 20);
            this.cboEjercicio.TabIndex = 3;
            this.cboEjercicio.EditValueChanged += new System.EventHandler(this.cboEjercicio_EditValueChanged);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(89, 64);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombremes", "Mes")});
            this.cboMes.Size = new System.Drawing.Size(121, 20);
            this.cboMes.TabIndex = 5;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "Hoy";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(8, 115);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Properties.Caption = "Hoy";
            this.hyperLinkEdit1.Properties.Image = ((System.Drawing.Image)(resources.GetObject("hyperLinkEdit1.Properties.Image")));
            this.hyperLinkEdit1.Size = new System.Drawing.Size(60, 24);
            this.hyperLinkEdit1.TabIndex = 12;
            this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit1_OpenLink);
            // 
            // FiltroFormConsultaFrm
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdSalir;
            this.ClientSize = new System.Drawing.Size(223, 187);
            this.Controls.Add(this.hyperLinkEdit1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboEjercicio);
            this.Controls.Add(this.deFechaFinal);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboTipoFiltro);
            this.Controls.Add(this.deFechaInicial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroFormConsultaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro";
            this.Load += new System.EventHandler(this.FiltroFormConsultaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaInicial.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoFiltro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEjercicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaInicial;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoFiltro;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton cmdAceptar;
        private DevExpress.XtraEditors.SimpleButton cmdSalir;
        private DevExpress.XtraEditors.DateEdit deFechaFinal;
        private DevExpress.XtraEditors.LookUpEdit cboEjercicio;
        private DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
    }
}