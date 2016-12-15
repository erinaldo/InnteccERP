namespace WinFormsApp
{
    partial class ConsultaSunatFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaSunatFrm));
            this.btnRefrescarCaptcha = new DevExpress.XtraEditors.SimpleButton();
            this.iRuc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iRazonSocial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iNombreComercial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.iEstado = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iCondicion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.iDireccionFiscal = new DevExpress.XtraEditors.TextEdit();
            this.iIddistrito = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.peCaptcha = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.iCaptcha = new DevExpress.XtraEditors.TextEdit();
            this.btnImportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.chkCorregirRazonSocial = new DevExpress.XtraEditors.CheckEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.iReferencia = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iRuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombreComercial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCondicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDireccionFiscal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIddistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCaptcha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCaptcha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCorregirRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iReferencia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefrescarCaptcha
            // 
            this.btnRefrescarCaptcha.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescarCaptcha.Image")));
            this.btnRefrescarCaptcha.Location = new System.Drawing.Point(294, 20);
            this.btnRefrescarCaptcha.Name = "btnRefrescarCaptcha";
            this.btnRefrescarCaptcha.Size = new System.Drawing.Size(120, 23);
            this.btnRefrescarCaptcha.TabIndex = 1;
            this.btnRefrescarCaptcha.Text = "Refrescar captcha";
            this.btnRefrescarCaptcha.Click += new System.EventHandler(this.btnRefrescarCaptcha_Click);
            // 
            // iRuc
            // 
            this.iRuc.Location = new System.Drawing.Point(169, 82);
            this.iRuc.Name = "iRuc";
            this.iRuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iRuc.Properties.Appearance.Options.UseFont = true;
            this.iRuc.Properties.MaxLength = 11;
            this.iRuc.Size = new System.Drawing.Size(120, 20);
            this.iRuc.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "N° RUC";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(149, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Ape. y Nombres ó Razon Social";
            // 
            // iRazonSocial
            // 
            this.iRazonSocial.Location = new System.Drawing.Point(169, 108);
            this.iRazonSocial.Name = "iRazonSocial";
            this.iRazonSocial.Properties.ReadOnly = true;
            this.iRazonSocial.Size = new System.Drawing.Size(521, 20);
            this.iRazonSocial.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 137);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Nombre comercial";
            // 
            // iNombreComercial
            // 
            this.iNombreComercial.Location = new System.Drawing.Point(169, 134);
            this.iNombreComercial.Name = "iNombreComercial";
            this.iNombreComercial.Properties.ReadOnly = true;
            this.iNombreComercial.Size = new System.Drawing.Size(521, 20);
            this.iNombreComercial.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 163);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(122, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Estado del Contribuyente";
            // 
            // iEstado
            // 
            this.iEstado.Location = new System.Drawing.Point(169, 160);
            this.iEstado.Name = "iEstado";
            this.iEstado.Properties.ReadOnly = true;
            this.iEstado.Size = new System.Drawing.Size(521, 20);
            this.iEstado.TabIndex = 12;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 189);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(135, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Condición del Contribuyente";
            // 
            // iCondicion
            // 
            this.iCondicion.Location = new System.Drawing.Point(169, 186);
            this.iCondicion.Name = "iCondicion";
            this.iCondicion.Properties.ReadOnly = true;
            this.iCondicion.Size = new System.Drawing.Size(521, 20);
            this.iCondicion.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 215);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(132, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Dirección del Domicilio Fiscal";
            // 
            // iDireccionFiscal
            // 
            this.iDireccionFiscal.Location = new System.Drawing.Point(169, 212);
            this.iDireccionFiscal.Name = "iDireccionFiscal";
            this.iDireccionFiscal.Size = new System.Drawing.Size(521, 20);
            this.iDireccionFiscal.TabIndex = 16;
            // 
            // iIddistrito
            // 
            this.iIddistrito.Location = new System.Drawing.Point(169, 264);
            this.iIddistrito.Name = "iIddistrito";
            this.iIddistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIddistrito.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIddistrito.Properties.View = this.gridView1;
            this.iIddistrito.Size = new System.Drawing.Size(521, 20);
            this.iIddistrito.TabIndex = 20;
            this.iIddistrito.Tag = "Seleccione el ubigeo";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Id.";
            this.gridColumn4.FieldName = "Iddistrito";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ubigeo";
            this.gridColumn5.FieldName = "Nombreubigeo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(10, 267);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(33, 13);
            this.labelControl15.TabIndex = 19;
            this.labelControl15.Text = "Ubigeo";
            // 
            // peCaptcha
            // 
            this.peCaptcha.Location = new System.Drawing.Point(169, 12);
            this.peCaptcha.Name = "peCaptcha";
            this.peCaptcha.Size = new System.Drawing.Size(119, 38);
            this.peCaptcha.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Código Captcha";
            // 
            // iCaptcha
            // 
            this.iCaptcha.Location = new System.Drawing.Point(169, 56);
            this.iCaptcha.Name = "iCaptcha";
            this.iCaptcha.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.iCaptcha.Properties.Appearance.Options.UseFont = true;
            this.iCaptcha.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCaptcha.Properties.MaxLength = 4;
            this.iCaptcha.Size = new System.Drawing.Size(119, 20);
            this.iCaptcha.TabIndex = 3;
            this.iCaptcha.Validating += new System.ComponentModel.CancelEventHandler(this.iCaptcha_Validating);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Location = new System.Drawing.Point(502, 290);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(102, 23);
            this.btnImportar.TabIndex = 23;
            this.btnImportar.Text = "Importar datos";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(610, 290);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 23);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkCorregirRazonSocial
            // 
            this.chkCorregirRazonSocial.Location = new System.Drawing.Point(470, 79);
            this.chkCorregirRazonSocial.Name = "chkCorregirRazonSocial";
            this.chkCorregirRazonSocial.Properties.Caption = "Corregir razón social / Nombre comercial";
            this.chkCorregirRazonSocial.Size = new System.Drawing.Size(220, 19);
            this.chkCorregirRazonSocial.TabIndex = 25;
            this.chkCorregirRazonSocial.TabStop = false;
            this.chkCorregirRazonSocial.CheckedChanged += new System.EventHandler(this.chkCorregirRazonSocial_CheckedChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(294, 53);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar RUC";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnConsultar.Enter += new System.EventHandler(this.btnConsultar_Enter);
            this.btnConsultar.Leave += new System.EventHandler(this.btnConsultar_Leave);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(10, 241);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 13);
            this.labelControl8.TabIndex = 17;
            this.labelControl8.Text = "Referencia";
            // 
            // iReferencia
            // 
            this.iReferencia.Location = new System.Drawing.Point(169, 238);
            this.iReferencia.Name = "iReferencia";
            this.iReferencia.Size = new System.Drawing.Size(521, 20);
            this.iReferencia.TabIndex = 18;
            // 
            // ConsultaSunatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(701, 322);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.iReferencia);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.chkCorregirRazonSocial);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.iCaptcha);
            this.Controls.Add(this.peCaptcha);
            this.Controls.Add(this.iIddistrito);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.iDireccionFiscal);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iCondicion);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.iEstado);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iNombreComercial);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iRazonSocial);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iRuc);
            this.Controls.Add(this.btnRefrescarCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ConsultaSunatFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar datos SUNAT";
            this.Load += new System.EventHandler(this.ConsultaSunatFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsultaSunatFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iRuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iRazonSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombreComercial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCondicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDireccionFiscal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIddistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peCaptcha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCaptcha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCorregirRazonSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iReferencia.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRefrescarCaptcha;
        private DevExpress.XtraEditors.TextEdit iRuc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iRazonSocial;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iNombreComercial;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit iEstado;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iCondicion;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit iDireccionFiscal;
        private DevExpress.XtraEditors.SearchLookUpEdit iIddistrito;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.PictureEdit peCaptcha;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit iCaptcha;
        private DevExpress.XtraEditors.SimpleButton btnImportar;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.CheckEdit chkCorregirRazonSocial;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit iReferencia;
    }
}