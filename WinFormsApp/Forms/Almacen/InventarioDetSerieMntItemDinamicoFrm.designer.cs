namespace WinFormsApp
{
    partial class InventarioDetSerieMntItemDinamicoFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioDetSerieMntItemDinamicoFrm));
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iIdinventariostockdetserie = new DevExpress.XtraEditors.TextEdit();
            this.iCodigointernoitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroserieitem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.iIdseriearticulo = new DevExpress.XtraEditors.TextEdit();
            this.iFecharegistro = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdinventariostockdetserie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigointernoitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroserieitem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdseriearticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecharegistro.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecharegistro.Properties)).BeginInit();
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
            toolTipTitleItem5.Text = "Grabar y cerrar (Ctrl + Enter)";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.btnGrabarItem.SuperTip = superToolTip5;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Caption = "Cancelar";
            this.btnCancelarItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancelarItem.Glyph")));
            this.btnCancelarItem.Id = 1;
            this.btnCancelarItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCancelarItem.Name = "btnCancelarItem";
            toolTipTitleItem6.Text = "Cancelar y cerrar ventana (Ctrl + S)";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnCancelarItem.SuperTip = superToolTip6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(547, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 118);
            this.barDockControlBottom.Size = new System.Drawing.Size(547, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 87);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(547, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 87);
            // 
            // iIdinventariostockdetserie
            // 
            this.iIdinventariostockdetserie.EditValue = 0;
            this.iIdinventariostockdetserie.Location = new System.Drawing.Point(261, 63);
            this.iIdinventariostockdetserie.Name = "iIdinventariostockdetserie";
            this.iIdinventariostockdetserie.Properties.AllowFocused = false;
            this.iIdinventariostockdetserie.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdinventariostockdetserie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdinventariostockdetserie.Properties.ReadOnly = true;
            this.iIdinventariostockdetserie.Size = new System.Drawing.Size(59, 20);
            this.iIdinventariostockdetserie.TabIndex = 8;
            this.iIdinventariostockdetserie.TabStop = false;
            this.iIdinventariostockdetserie.Visible = false;
            // 
            // iCodigointernoitem
            // 
            this.iCodigointernoitem.Location = new System.Drawing.Point(95, 63);
            this.iCodigointernoitem.Name = "iCodigointernoitem";
            this.iCodigointernoitem.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iCodigointernoitem.Properties.MaxLength = 50;
            this.iCodigointernoitem.Size = new System.Drawing.Size(160, 20);
            this.iCodigointernoitem.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Código interno";
            // 
            // iNumeroserieitem
            // 
            this.iNumeroserieitem.Location = new System.Drawing.Point(95, 37);
            this.iNumeroserieitem.Name = "iNumeroserieitem";
            this.iNumeroserieitem.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iNumeroserieitem.Properties.MaxLength = 50;
            this.iNumeroserieitem.Size = new System.Drawing.Size(409, 20);
            this.iNumeroserieitem.TabIndex = 1;
            this.iNumeroserieitem.Tag = "Ingrese el Nº de serie";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Nº Serie";
            // 
            // iIdseriearticulo
            // 
            this.iIdseriearticulo.EditValue = 0;
            this.iIdseriearticulo.Location = new System.Drawing.Point(326, 63);
            this.iIdseriearticulo.Name = "iIdseriearticulo";
            this.iIdseriearticulo.Properties.AllowFocused = false;
            this.iIdseriearticulo.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdseriearticulo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdseriearticulo.Properties.ReadOnly = true;
            this.iIdseriearticulo.Size = new System.Drawing.Size(59, 20);
            this.iIdseriearticulo.TabIndex = 13;
            this.iIdseriearticulo.TabStop = false;
            this.iIdseriearticulo.Visible = false;
            // 
            // iFecharegistro
            // 
            this.iFecharegistro.EditValue = null;
            this.iFecharegistro.Location = new System.Drawing.Point(95, 89);
            this.iFecharegistro.MenuManager = this.bmMntItems;
            this.iFecharegistro.Name = "iFecharegistro";
            this.iFecharegistro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFecharegistro.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFecharegistro.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.iFecharegistro.Size = new System.Drawing.Size(100, 20);
            this.iFecharegistro.TabIndex = 18;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Fecha registro";
            // 
            // InventarioDetSerieMntItemDinamicoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 118);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iFecharegistro);
            this.Controls.Add(this.iIdseriearticulo);
            this.Controls.Add(this.iCodigointernoitem);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iNumeroserieitem);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.iIdinventariostockdetserie);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventarioDetSerieMntItemDinamicoFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serie de articulo";
            this.Load += new System.EventHandler(this.InventarioDetSerieMntItemDinamicoFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InventarioDetSerieMntItemDinamicoFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdinventariostockdetserie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iCodigointernoitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroserieitem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdseriearticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecharegistro.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFecharegistro.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit iIdinventariostockdetserie;
        private DevExpress.XtraEditors.TextEdit iCodigointernoitem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit iNumeroserieitem;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit iIdseriearticulo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit iFecharegistro;
    }
}