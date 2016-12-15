namespace WinFormsApp
{
    partial class SocionegocioDireccionMntItemFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SocionegocioDireccionMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iIddistrito = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.iDireccionsocionegocio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iReferencia = new DevExpress.XtraEditors.TextEdit();
            this.iPrincipal = new DevExpress.XtraEditors.CheckEdit();
            this.iIdpais = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iTipolocal = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIddistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDireccionsocionegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPrincipal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdpais.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipolocal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bmMntItems
            // 
            this.bmMntItems.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMntItems});
            this.bmMntItems.DockControls.Add(this.barDockControlTop);
            this.bmMntItems.DockControls.Add(this.barDockControlBottom);
            this.bmMntItems.DockControls.Add(this.barDockControlLeft);
            this.bmMntItems.DockControls.Add(this.barDockControlRight);
            this.bmMntItems.Form = this;
            this.bmMntItems.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnGrabarItem,
            this.btnCancelarItem});
            this.bmMntItems.MaxItemId = 3;
            this.bmMntItems.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmMntItems_ItemClick);
            // 
            // barMntItems
            // 
            this.barMntItems.BarName = "Tools";
            this.barMntItems.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMntItems.DockCol = 0;
            this.barMntItems.DockRow = 0;
            this.barMntItems.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMntItems.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGrabarItem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancelarItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMntItems.OptionsBar.UseWholeRow = true;
            this.barMntItems.Text = "Tools";
            // 
            // btnGrabarItem
            // 
            this.btnGrabarItem.Caption = "Grabar";
            this.btnGrabarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGrabarItem.Glyph")));
            this.btnGrabarItem.Id = 0;
            this.btnGrabarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnGrabarItem.Name = "btnGrabarItem";
            toolTipTitleItem1.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnGrabarItem.SuperTip = superToolTip1;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Caption = "Cancelar";
            this.btnCancelarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelarItem.Glyph")));
            this.btnCancelarItem.Id = 1;
            this.btnCancelarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCancelarItem.Name = "btnCancelarItem";
            toolTipTitleItem2.Text = "Cancelar y cerrar ventana (Ctrl + S)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnCancelarItem.SuperTip = superToolTip2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(537, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 211);
            this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 180);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(537, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 180);
            // 
            // iIddistrito
            // 
            this.iIddistrito.Location = new System.Drawing.Point(95, 67);
            this.iIddistrito.Name = "iIddistrito";
            this.iIddistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIddistrito.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIddistrito.Properties.View = this.gridView1;
            this.iIddistrito.Size = new System.Drawing.Size(430, 20);
            this.iIddistrito.TabIndex = 3;
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
            this.labelControl15.Location = new System.Drawing.Point(3, 68);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(33, 13);
            this.labelControl15.TabIndex = 2;
            this.labelControl15.Text = "Ubigeo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(4, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Dirección";
            // 
            // iDireccionsocionegocio
            // 
            this.iDireccionsocionegocio.Location = new System.Drawing.Point(96, 93);
            this.iDireccionsocionegocio.Name = "iDireccionsocionegocio";
            this.iDireccionsocionegocio.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iDireccionsocionegocio.Properties.MaxLength = 150;
            this.iDireccionsocionegocio.Size = new System.Drawing.Size(430, 20);
            this.iDireccionsocionegocio.TabIndex = 5;
            this.iDireccionsocionegocio.Tag = "Ingrese la dirección";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 122);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Referencia";
            // 
            // iReferencia
            // 
            this.iReferencia.Location = new System.Drawing.Point(96, 119);
            this.iReferencia.Name = "iReferencia";
            this.iReferencia.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iReferencia.Properties.MaxLength = 100;
            this.iReferencia.Size = new System.Drawing.Size(430, 20);
            this.iReferencia.TabIndex = 7;
            // 
            // iPrincipal
            // 
            this.iPrincipal.Location = new System.Drawing.Point(95, 145);
            this.iPrincipal.MenuManager = this.bmMntItems;
            this.iPrincipal.Name = "iPrincipal";
            this.iPrincipal.Properties.AutoWidth = true;
            this.iPrincipal.Properties.Caption = "Direccion principal";
            this.iPrincipal.Size = new System.Drawing.Size(107, 19);
            this.iPrincipal.TabIndex = 8;
            // 
            // iIdpais
            // 
            this.iIdpais.Location = new System.Drawing.Point(95, 37);
            this.iIdpais.Name = "iIdpais";
            this.iIdpais.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdpais.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdpais.Properties.View = this.gridView2;
            this.iIdpais.Size = new System.Drawing.Size(430, 20);
            this.iIdpais.TabIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Id.";
            this.gridColumn6.FieldName = "Idpais";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "País";
            this.gridColumn7.FieldName = "Nombrepais";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(3, 40);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(19, 13);
            this.labelControl16.TabIndex = 0;
            this.labelControl16.Text = "País";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 173);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Tipo local";
            // 
            // iTipolocal
            // 
            this.iTipolocal.Location = new System.Drawing.Point(96, 170);
            this.iTipolocal.Name = "iTipolocal";
            this.iTipolocal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iTipolocal.Properties.MaxLength = 100;
            this.iTipolocal.Size = new System.Drawing.Size(430, 20);
            this.iTipolocal.TabIndex = 10;
            // 
            // SocionegocioDireccionMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 211);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iTipolocal);
            this.Controls.Add(this.iIdpais);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.iPrincipal);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iReferencia);
            this.Controls.Add(this.iIddistrito);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.iDireccionsocionegocio);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SocionegocioDireccionMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dirección de socio de negocio";
            this.Load += new System.EventHandler(this.SocionegocioDireccionMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SocionegocioDireccionMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIddistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDireccionsocionegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPrincipal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdpais.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTipolocal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmMntItems;
        private DevExpress.XtraBars.Bar barMntItems;
        private DevExpress.XtraBars.BarButtonItem btnGrabarItem;
        private DevExpress.XtraBars.BarButtonItem btnCancelarItem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckEdit iPrincipal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit iReferencia;
        private DevExpress.XtraEditors.SearchLookUpEdit iIddistrito;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit iDireccionsocionegocio;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iTipolocal;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdpais;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LabelControl labelControl16;
    }
}