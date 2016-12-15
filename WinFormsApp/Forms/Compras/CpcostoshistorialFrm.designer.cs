namespace WinFormsApp
{
    partial class CpcostoshistorialFrm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpcostoshistorialFrm));
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.gcCostos = new DevExpress.XtraGrid.GridControl();
            this.gvCostos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.iIdarticulo = new DevExpress.XtraEditors.TextEdit();
            this.beArticulo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iCodigoarticulo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.speTop = new DevExpress.XtraEditors.SpinEdit();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTop.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCostos
            // 
            this.gcCostos.Location = new System.Drawing.Point(5, 34);
            this.gcCostos.MainView = this.gvCostos;
            this.gcCostos.Name = "gcCostos";
            this.gcCostos.Size = new System.Drawing.Size(1059, 226);
            this.gcCostos.TabIndex = 2;
            this.gcCostos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCostos});
            // 
            // gvCostos
            // 
            this.gvCostos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn13});
            this.gvCostos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvCostos.GridControl = this.gcCostos;
            this.gvCostos.Name = "gvCostos";
            this.gvCostos.OptionsBehavior.Editable = false;
            this.gvCostos.OptionsBehavior.ReadOnly = true;
            this.gvCostos.OptionsView.ColumnAutoWidth = false;
            this.gvCostos.OptionsView.ShowGroupPanel = false;
            this.gvCostos.OptionsView.ShowViewCaption = true;
            this.gvCostos.ViewCaption = "Historial de costos";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "fechaemision";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Código";
            this.gridColumn6.FieldName = "codigoarticulo";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tipo";
            this.gridColumn5.FieldName = "abreviaturatipoformato";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nº Documento";
            this.gridColumn1.FieldName = "documento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Razon Social";
            this.gridColumn9.FieldName = "razonsocial";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cantidad";
            this.gridColumn7.FieldName = "cantidad";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Moneda";
            this.gridColumn10.FieldName = "simbolomoneda";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Valor Uni.";
            this.gridColumn4.FieldName = "preciounitarioneto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Importe";
            this.gridColumn8.FieldName = "importetotal";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Peso Unit.(Kg)";
            this.gridColumn11.FieldName = "pesounitario";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Peso Total";
            this.gridColumn12.FieldName = "pesototal";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Costo Unit.";
            this.gridColumn3.FieldName = "costounitario";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Costo Total";
            this.gridColumn13.FieldName = "costototal";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnClose.Location = new System.Drawing.Point(980, 265);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cerrar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::WinFormsApp.Properties.Resources.Action_Search;
            this.btnConsultar.Location = new System.Drawing.Point(760, 5);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 23);
            toolTipTitleItem1.Text = "Seleccionar registro";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnConsultar.SuperTip = superToolTip1;
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // iIdarticulo
            // 
            this.iIdarticulo.EditValue = 0;
            this.iIdarticulo.Location = new System.Drawing.Point(5, 268);
            this.iIdarticulo.Name = "iIdarticulo";
            this.iIdarticulo.Properties.AllowFocused = false;
            this.iIdarticulo.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdarticulo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdarticulo.Properties.ReadOnly = true;
            this.iIdarticulo.Size = new System.Drawing.Size(56, 20);
            this.iIdarticulo.TabIndex = 33;
            this.iIdarticulo.TabStop = false;
            this.iIdarticulo.Visible = false;
            this.iIdarticulo.EditValueChanged += new System.EventHandler(this.iIdarticulo_EditValueChanged);
            // 
            // beArticulo
            // 
            this.beArticulo.EditValue = "";
            this.beArticulo.Location = new System.Drawing.Point(205, 5);
            this.beArticulo.Name = "beArticulo";
            toolTipTitleItem2.Text = "Buscar Registro (F3)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.beArticulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F3), serializableAppearanceObject1, "", null, superToolTip2, true)});
            this.beArticulo.Properties.ReadOnly = true;
            this.beArticulo.Size = new System.Drawing.Size(433, 22);
            this.beArticulo.TabIndex = 32;
            this.beArticulo.Tag = "Seleccione el Articulo";
            this.beArticulo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beArticulo_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Código";
            // 
            // iCodigoarticulo
            // 
            this.iCodigoarticulo.Location = new System.Drawing.Point(58, 6);
            this.iCodigoarticulo.Name = "iCodigoarticulo";
            this.iCodigoarticulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigoarticulo.Properties.MaxLength = 10;
            this.iCodigoarticulo.Properties.ReadOnly = true;
            this.iCodigoarticulo.Size = new System.Drawing.Size(99, 20);
            this.iCodigoarticulo.TabIndex = 30;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(163, 10);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 13);
            this.labelControl8.TabIndex = 31;
            this.labelControl8.Text = "Artículo";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(645, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 13);
            this.labelControl5.TabIndex = 34;
            this.labelControl5.Text = "Ultimos";
            // 
            // speTop
            // 
            this.speTop.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speTop.Location = new System.Drawing.Point(685, 7);
            this.speTop.Name = "speTop";
            this.speTop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speTop.Properties.Mask.EditMask = "####";
            this.speTop.Properties.MaxLength = 4;
            this.speTop.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.speTop.Size = new System.Drawing.Size(71, 20);
            this.speTop.TabIndex = 35;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(899, 266);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(76, 23);
            toolTipTitleItem3.Text = "Imprimir";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnImprimir.SuperTip = superToolTip3;
            this.btnImprimir.TabIndex = 36;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // CpcostoshistorialFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1068, 292);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.speTop);
            this.Controls.Add(this.iIdarticulo);
            this.Controls.Add(this.beArticulo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iCodigoarticulo);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gcCostos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CpcostoshistorialFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de compras por producto";
            this.Load += new System.EventHandler(this.CpcostoshistorialFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigoarticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTop.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCostos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCostos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.TextEdit iIdarticulo;
        private DevExpress.XtraEditors.ButtonEdit beArticulo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iCodigoarticulo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit speTop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
    }
}