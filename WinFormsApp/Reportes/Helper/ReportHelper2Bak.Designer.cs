namespace WinFormsApp
{
    partial class ReportHelper2Bak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportHelper2Bak));
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.gcReporte = new DevExpress.XtraEditors.GroupControl();
            this.lbcOpciones = new DevExpress.XtraEditors.ListBoxControl();
            this.saveFileDialogPdf = new System.Windows.Forms.SaveFileDialog();
            this.btnDiseño = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).BeginInit();
            this.gcReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbcOpciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::WinFormsApp.Properties.Resources.Action_Grant;
            this.btnAceptar.Location = new System.Drawing.Point(174, 95);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnCerrar.Location = new System.Drawing.Point(251, 95);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gcReporte
            // 
            this.gcReporte.Controls.Add(this.lbcOpciones);
            this.gcReporte.Location = new System.Drawing.Point(7, 12);
            this.gcReporte.Name = "gcReporte";
            this.gcReporte.Size = new System.Drawing.Size(319, 79);
            this.gcReporte.TabIndex = 17;
            this.gcReporte.Text = "Opciones";
            // 
            // lbcOpciones
            // 
            this.lbcOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcOpciones.Items.AddRange(new object[] {
            "Vista previa",
            "Impresora",
            "Archivo PDF"});
            this.lbcOpciones.Location = new System.Drawing.Point(2, 21);
            this.lbcOpciones.Name = "lbcOpciones";
            this.lbcOpciones.Size = new System.Drawing.Size(315, 56);
            this.lbcOpciones.TabIndex = 17;
            // 
            // btnDiseño
            // 
            this.btnDiseño.Image = ((System.Drawing.Image)(resources.GetObject("btnDiseño.Image")));
            this.btnDiseño.Location = new System.Drawing.Point(7, 95);
            this.btnDiseño.Name = "btnDiseño";
            this.btnDiseño.Size = new System.Drawing.Size(75, 23);
            this.btnDiseño.TabIndex = 18;
            this.btnDiseño.Text = "Diseño";
            this.btnDiseño.Click += new System.EventHandler(this.btnDiseño_Click);
            // 
            // ReportHelper2Bak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(338, 123);
            this.Controls.Add(this.btnDiseño);
            this.Controls.Add(this.gcReporte);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportHelper2Bak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportHelper2Bak_FormClosed);
            this.Load += new System.EventHandler(this.ReportHelper2Bak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).EndInit();
            this.gcReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbcOpciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraEditors.GroupControl gcReporte;
        private DevExpress.XtraEditors.ListBoxControl lbcOpciones;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPdf;
        private DevExpress.XtraEditors.SimpleButton btnDiseño;
    }
}