namespace WinFormsApp
{
    partial class MantenimientoMntItemFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoMntItemFrm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager(this.components);
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tcProductos = new DevExpress.XtraTab.XtraTabControl();
            this.tpProducto = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.iComentario = new DevExpress.XtraEditors.MemoEdit();
            this.iNombrearchivo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.iNumeroitem = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).BeginInit();
            this.tcProductos.SuspendLayout();
            this.tpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrearchivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(623, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 287);
            this.barDockControlBottom.Size = new System.Drawing.Size(623, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 256);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(623, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 256);
            // 
            // tcProductos
            // 
            this.tcProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProductos.Location = new System.Drawing.Point(0, 31);
            this.tcProductos.Name = "tcProductos";
            this.tcProductos.SelectedTabPage = this.tpProducto;
            this.tcProductos.Size = new System.Drawing.Size(623, 256);
            this.tcProductos.TabIndex = 0;
            this.tcProductos.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProducto});
            // 
            // tpProducto
            // 
            this.tpProducto.Controls.Add(this.labelControl1);
            this.tpProducto.Controls.Add(this.iComentario);
            this.tpProducto.Controls.Add(this.iNombrearchivo);
            this.tpProducto.Controls.Add(this.labelControl12);
            this.tpProducto.Controls.Add(this.labelControl13);
            this.tpProducto.Controls.Add(this.iNumeroitem);
            this.tpProducto.Name = "tpProducto";
            this.tpProducto.Size = new System.Drawing.Size(617, 228);
            this.tpProducto.Text = "Item comprobante de venta";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 66);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Comentario";
            // 
            // iComentario
            // 
            this.iComentario.Location = new System.Drawing.Point(79, 63);
            this.iComentario.MenuManager = this.bmMntItems;
            this.iComentario.Name = "iComentario";
            this.iComentario.Size = new System.Drawing.Size(527, 149);
            this.iComentario.TabIndex = 5;
            // 
            // iNombrearchivo
            // 
            this.iNombrearchivo.Location = new System.Drawing.Point(79, 37);
            this.iNombrearchivo.Name = "iNombrearchivo";
            toolTipTitleItem3.Text = "Seleccionar archivo de imagen";
            superToolTip3.Items.Add(toolTipTitleItem3);
            toolTipTitleItem4.Text = "Abrir y visualizar archivo de imagen";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.iNombrearchivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("iNombrearchivo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip3, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("iNombrearchivo.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip4, true)});
            this.iNombrearchivo.Properties.ReadOnly = true;
            this.iNombrearchivo.Size = new System.Drawing.Size(527, 22);
            this.iNombrearchivo.TabIndex = 3;
            this.iNombrearchivo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.iNombrearchivo_ButtonClick);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 40);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(36, 13);
            this.labelControl12.TabIndex = 2;
            this.labelControl12.Text = "Archivo";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(11, 14);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(37, 13);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "N° Item";
            // 
            // iNumeroitem
            // 
            this.iNumeroitem.EditValue = 0;
            this.iNumeroitem.Location = new System.Drawing.Point(79, 11);
            this.iNumeroitem.Name = "iNumeroitem";
            this.iNumeroitem.Properties.AllowFocused = false;
            this.iNumeroitem.Properties.Appearance.Options.UseTextOptions = true;
            this.iNumeroitem.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iNumeroitem.Properties.ReadOnly = true;
            this.iNumeroitem.Size = new System.Drawing.Size(79, 20);
            this.iNumeroitem.TabIndex = 1;
            this.iNumeroitem.TabStop = false;
            // 
            // MantenimientoMntItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 287);
            this.Controls.Add(this.tcProductos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MantenimientoMntItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item de Mantenimiento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MantenimientoMntItemFrm_FormClosed);
            this.Load += new System.EventHandler(this.MantenimientoMntItemFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MantenimientoMntItemFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcProductos)).EndInit();
            this.tcProductos.ResumeLayout(false);
            this.tpProducto.ResumeLayout(false);
            this.tpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNombrearchivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNumeroitem.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraTab.XtraTabControl tcProductos;
        private DevExpress.XtraTab.XtraTabPage tpProducto;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit iNumeroitem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit iComentario;
        private DevExpress.XtraEditors.ButtonEdit iNombrearchivo;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}