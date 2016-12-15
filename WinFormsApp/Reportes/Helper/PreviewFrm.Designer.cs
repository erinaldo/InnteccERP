namespace WinFormsApp
{
    partial class PreviewFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewFrm));
            this.report1 = new FastReport.Report();
            this.previewControlFrm = new FastReport.Preview.PreviewControl();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // previewControlFrm
            // 
            this.previewControlFrm.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControlFrm.Buttons = ((FastReport.PreviewButtons)((((((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save) 
            | FastReport.PreviewButtons.Email) 
            | FastReport.PreviewButtons.Find) 
            | FastReport.PreviewButtons.Zoom) 
            | FastReport.PreviewButtons.PageSetup) 
            | FastReport.PreviewButtons.Navigator) 
            | FastReport.PreviewButtons.Close)));
            this.previewControlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControlFrm.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControlFrm.Location = new System.Drawing.Point(0, 0);
            this.previewControlFrm.Name = "previewControlFrm";
            this.previewControlFrm.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControlFrm.Size = new System.Drawing.Size(1000, 489);
            this.previewControlFrm.TabIndex = 0;
            this.previewControlFrm.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            // 
            // PreviewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 489);
            this.Controls.Add(this.previewControlFrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreviewFrm";
            this.Text = "Vista preliminar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PreviewFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Report report1;
        private FastReport.Preview.PreviewControl previewControlFrm;

    }
}