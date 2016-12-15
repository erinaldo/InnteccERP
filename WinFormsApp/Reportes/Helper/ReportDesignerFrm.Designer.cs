namespace WinFormsApp
{
    partial class ReportDesignerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDesignerFrm));
            this.designerControlFrm = new FastReport.Design.StandardDesigner.DesignerControl();
            this.report1 = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.designerControlFrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // designerControlFrm
            // 
            this.designerControlFrm.AskSave = false;
            this.designerControlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControlFrm.LayoutState = resources.GetString("designerControlFrm.LayoutState");
            this.designerControlFrm.Location = new System.Drawing.Point(0, 0);
            this.designerControlFrm.Name = "designerControlFrm";
            this.designerControlFrm.Size = new System.Drawing.Size(937, 466);
            this.designerControlFrm.TabIndex = 0;
            this.designerControlFrm.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // ReportDesignerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 466);
            this.Controls.Add(this.designerControlFrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportDesignerFrm";
            this.Text = "Diseñador de de reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportDesignerFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.designerControlFrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Design.StandardDesigner.DesignerControl designerControlFrm;
        private FastReport.Report report1;
    }
}