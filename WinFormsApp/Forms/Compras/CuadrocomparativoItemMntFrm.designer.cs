namespace WinFormsApp
{
    partial class CuadrocomparativoItemMntFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuadrocomparativoItemMntFrm));
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            this.bmMntItems = new DevExpress.XtraBars.BarManager();
            this.barMntItems = new DevExpress.XtraBars.Bar();
            this.btnGrabarItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelarItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iIdsocionegocio = new DevExpress.XtraEditors.TextEdit();
            this.beSocioNegocio = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.iIncluyeimpuestoitems = new DevExpress.XtraEditors.CheckEdit();
            this.iFormadepago = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.eDiasvalidez = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.iFechacotizacionrecepcion = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.rNroDocPersona = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIncluyeimpuestoitems.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFormadepago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDiasvalidez.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechacotizacionrecepcion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechacotizacionrecepcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNroDocPersona.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(693, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 122);
            this.barDockControlBottom.Size = new System.Drawing.Size(693, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 91);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(693, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 91);
            // 
            // iIdsocionegocio
            // 
            this.iIdsocionegocio.EditValue = 0;
            this.iIdsocionegocio.Location = new System.Drawing.Point(228, 65);
            this.iIdsocionegocio.Name = "iIdsocionegocio";
            this.iIdsocionegocio.Properties.AllowFocused = false;
            this.iIdsocionegocio.Properties.Appearance.Options.UseTextOptions = true;
            this.iIdsocionegocio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.iIdsocionegocio.Properties.ReadOnly = true;
            this.iIdsocionegocio.Size = new System.Drawing.Size(56, 20);
            this.iIdsocionegocio.TabIndex = 3;
            this.iIdsocionegocio.TabStop = false;
            this.iIdsocionegocio.Visible = false;
            // 
            // beSocioNegocio
            // 
            this.beSocioNegocio.EditValue = "";
            this.beSocioNegocio.Location = new System.Drawing.Point(85, 37);
            this.beSocioNegocio.Name = "beSocioNegocio";
            toolTipTitleItem3.Text = "Buscar Registro (F4)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            toolTipTitleItem4.Text = "Nuevo Registro (Ctrl + Ins)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            toolTipTitleItem5.Text = "Modificar Registro (Ctrl + M)";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.beSocioNegocio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4), serializableAppearanceObject1, "", null, superToolTip3, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.add, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)), serializableAppearanceObject2, "", null, superToolTip4, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::WinFormsApp.Properties.Resources.Action_Edit_12x12, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)), serializableAppearanceObject3, "", null, superToolTip5, true)});
            this.beSocioNegocio.Properties.ReadOnly = true;
            this.beSocioNegocio.Size = new System.Drawing.Size(445, 22);
            toolTipTitleItem6.Text = "Presione F4 para buscar el proveedor";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.beSocioNegocio.SuperTip = superToolTip6;
            this.beSocioNegocio.TabIndex = 1;
            this.beSocioNegocio.Tag = "Seleccione el proveedor";
            this.beSocioNegocio.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beSocioNegocio_ButtonClick);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(7, 42);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(50, 13);
            this.labelControl17.TabIndex = 0;
            this.labelControl17.Text = "Proveedor";
            // 
            // iIncluyeimpuestoitems
            // 
            this.iIncluyeimpuestoitems.Location = new System.Drawing.Point(536, 39);
            this.iIncluyeimpuestoitems.Name = "iIncluyeimpuestoitems";
            this.iIncluyeimpuestoitems.Properties.AutoWidth = true;
            this.iIncluyeimpuestoitems.Properties.Caption = "Ingluye impuesto en items";
            this.iIncluyeimpuestoitems.Size = new System.Drawing.Size(147, 19);
            this.iIncluyeimpuestoitems.TabIndex = 2;
            // 
            // iFormadepago
            // 
            this.iFormadepago.EditValue = "";
            this.iFormadepago.Location = new System.Drawing.Point(85, 91);
            this.iFormadepago.MenuManager = this.bmMntItems;
            this.iFormadepago.Name = "iFormadepago";
            this.iFormadepago.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.iFormadepago.Properties.NullText = "50";
            this.iFormadepago.Size = new System.Drawing.Size(238, 20);
            this.iFormadepago.TabIndex = 5;
            this.iFormadepago.Tag = "Ingrese la forma de pago";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 95);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Forma de pago";
            // 
            // eDiasvalidez
            // 
            this.eDiasvalidez.EditValue = 0;
            this.eDiasvalidez.Location = new System.Drawing.Point(403, 91);
            this.eDiasvalidez.Name = "eDiasvalidez";
            this.eDiasvalidez.Properties.Appearance.Options.UseTextOptions = true;
            this.eDiasvalidez.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.eDiasvalidez.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.eDiasvalidez.Properties.Mask.EditMask = "n0";
            this.eDiasvalidez.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.eDiasvalidez.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.eDiasvalidez.Size = new System.Drawing.Size(55, 20);
            this.eDiasvalidez.TabIndex = 7;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(326, 95);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(71, 13);
            this.labelControl11.TabIndex = 6;
            this.labelControl11.Text = "Días de validez";
            // 
            // iFechacotizacionrecepcion
            // 
            this.iFechacotizacionrecepcion.EditValue = null;
            this.iFechacotizacionrecepcion.Location = new System.Drawing.Point(583, 91);
            this.iFechacotizacionrecepcion.MenuManager = this.bmMntItems;
            this.iFechacotizacionrecepcion.Name = "iFechacotizacionrecepcion";
            this.iFechacotizacionrecepcion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechacotizacionrecepcion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFechacotizacionrecepcion.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.iFechacotizacionrecepcion.Size = new System.Drawing.Size(100, 20);
            this.iFechacotizacionrecepcion.TabIndex = 9;
            this.iFechacotizacionrecepcion.Tag = "Ingrese la fecha de registro de cotización";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(464, 95);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Fecha recep. cotización";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(7, 68);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(33, 13);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "N° Ruc";
            // 
            // rNroDocPersona
            // 
            this.rNroDocPersona.Location = new System.Drawing.Point(85, 65);
            this.rNroDocPersona.Name = "rNroDocPersona";
            this.rNroDocPersona.Properties.MaxLength = 150;
            this.rNroDocPersona.Properties.ReadOnly = true;
            this.rNroDocPersona.Size = new System.Drawing.Size(137, 20);
            this.rNroDocPersona.TabIndex = 14;
            this.rNroDocPersona.TabStop = false;
            // 
            // CuadrocomparativoItemMntFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 122);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.rNroDocPersona);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.iFechacotizacionrecepcion);
            this.Controls.Add(this.eDiasvalidez);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.iFormadepago);
            this.Controls.Add(this.iIncluyeimpuestoitems);
            this.Controls.Add(this.iIdsocionegocio);
            this.Controls.Add(this.beSocioNegocio);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuadrocomparativoItemMntFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedor de cotización";
            this.Load += new System.EventHandler(this.CuadrocomparativoItemMntFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CuadrocomparativoItemMntFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bmMntItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsocionegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beSocioNegocio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIncluyeimpuestoitems.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFormadepago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDiasvalidez.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechacotizacionrecepcion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFechacotizacionrecepcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNroDocPersona.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit iIdsocionegocio;
        private DevExpress.XtraEditors.ButtonEdit beSocioNegocio;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CheckEdit iIncluyeimpuestoitems;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit iFormadepago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit iFechacotizacionrecepcion;
        private DevExpress.XtraEditors.TextEdit eDiasvalidez;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit rNroDocPersona;
    }
}