﻿namespace WinFormsApp
{
    partial class OrdendeventaFrm
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdendeventaFrm));
            this.gcAnulado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bmConsulta = new DevExpress.XtraBars.BarManager();
            this.BarMnt = new DevExpress.XtraBars.Bar();
            this.btnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnModificar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.bsiExportar = new DevExpress.XtraBars.BarSubItem();
            this.btnExportCsv = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportMht = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportImg = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportRtf = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportTxt = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportXls = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnListado1 = new DevExpress.XtraBars.BarButtonItem();
            this.gcConsulta = new DevExpress.XtraGrid.GridControl();
            this.gvConsulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerocotiza = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riTotaln2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bmConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerocotiza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotaln2)).BeginInit();
            this.SuspendLayout();
            // 
            // gcAnulado
            // 
            this.gcAnulado.Caption = "Anulado";
            this.gcAnulado.FieldName = "Anulado";
            this.gcAnulado.Name = "gcAnulado";
            this.gcAnulado.Visible = true;
            this.gcAnulado.VisibleIndex = 10;
            // 
            // bmConsulta
            // 
            this.bmConsulta.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarMnt});
            this.bmConsulta.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Mantenimiento", new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5")),
            new DevExpress.XtraBars.BarManagerCategory("Navegación", new System.Guid("914e515b-0bf8-4995-97b2-cce8dc1d7479")),
            new DevExpress.XtraBars.BarManagerCategory("Exportar", new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97"))});
            this.bmConsulta.DockControls.Add(this.barDockControlTop);
            this.bmConsulta.DockControls.Add(this.barDockControlBottom);
            this.bmConsulta.DockControls.Add(this.barDockControlLeft);
            this.bmConsulta.DockControls.Add(this.barDockControlRight);
            this.bmConsulta.Form = this;
            this.bmConsulta.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNuevo,
            this.btnModificar,
            this.btnEliminar,
            this.bsiExportar,
            this.btnListado1,
            this.btnExportCsv,
            this.btnExportHtml,
            this.btnExportImg,
            this.btnExportMht,
            this.btnExportPdf,
            this.btnExportRtf,
            this.btnExportTxt,
            this.btnExportXls,
            this.btnExportXlsx,
            this.btnCerrar,
            this.btnActualizar,
            this.btnImprimir});
            this.bmConsulta.MaxItemId = 79;
            this.bmConsulta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmConsulta_ItemClick);
            // 
            // BarMnt
            // 
            this.BarMnt.BarName = "Tools Mantenimiento";
            this.BarMnt.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)(((((DevExpress.XtraBars.BarCanDockStyle.Left | DevExpress.XtraBars.BarCanDockStyle.Top) 
            | DevExpress.XtraBars.BarCanDockStyle.Right) 
            | DevExpress.XtraBars.BarCanDockStyle.Bottom) 
            | DevExpress.XtraBars.BarCanDockStyle.Standalone)));
            this.BarMnt.DockCol = 0;
            this.BarMnt.DockRow = 0;
            this.BarMnt.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarMnt.FloatLocation = new System.Drawing.Point(376, 165);
            this.BarMnt.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNuevo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnModificar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImprimir, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEliminar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnActualizar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bsiExportar, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCerrar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.BarMnt.OptionsBar.UseWholeRow = true;
            this.BarMnt.Text = "Barra de herramientas";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnNuevo.Glyph = global::WinFormsApp.Properties.Resources.Action_New;
            this.btnNuevo.Id = 55;
            this.btnNuevo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNuevo.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_New_32x32;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.ShortcutKeyDisplayString = "Ctrl +N";
            toolTipTitleItem1.Text = "Nuevo (Ctrl + N)";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnNuevo.SuperTip = superToolTip1;
            // 
            // btnModificar
            // 
            this.btnModificar.Caption = "Modificar";
            this.btnModificar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnModificar.Glyph = global::WinFormsApp.Properties.Resources.Action_Edit;
            this.btnModificar.Id = 56;
            this.btnModificar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M));
            this.btnModificar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Edit_32x32;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.ShortcutKeyDisplayString = "Ctrl + M";
            toolTipTitleItem2.Text = "Modificar (Ctrl + M)";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnModificar.SuperTip = superToolTip2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Glyph = global::WinFormsApp.Properties.Resources.Action_Printing_Print;
            this.btnImprimir.Id = 78;
            this.btnImprimir.Name = "btnImprimir";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnEliminar.Glyph = global::WinFormsApp.Properties.Resources.Action_Delete;
            this.btnEliminar.Id = 57;
            this.btnEliminar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnEliminar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Delete_32x32;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ShortcutKeyDisplayString = "Ctrl + E";
            toolTipTitleItem3.Text = "Eliminar (Ctrl + E)\r\n";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnEliminar.SuperTip = superToolTip3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.CategoryGuid = new System.Guid("bf24888c-c336-4331-92ed-90df15ac84f5");
            this.btnActualizar.Glyph = global::WinFormsApp.Properties.Resources.Action_Refresh;
            this.btnActualizar.Id = 77;
            this.btnActualizar.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnActualizar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Refresh_32x32;
            this.btnActualizar.Name = "btnActualizar";
            toolTipTitleItem4.Text = "Actualizar (F5)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnActualizar.SuperTip = superToolTip4;
            // 
            // bsiExportar
            // 
            this.bsiExportar.Caption = "Exportar";
            this.bsiExportar.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.bsiExportar.Glyph = global::WinFormsApp.Properties.Resources.Action_Export;
            this.bsiExportar.Id = 62;
            this.bsiExportar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_32x32;
            this.bsiExportar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportCsv),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportHtml),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportMht),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportImg),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportRtf),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportTxt),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportXlsx)});
            this.bsiExportar.Name = "bsiExportar";
            this.bsiExportar.ShortcutKeyDisplayString = "Exportar a...";
            toolTipTitleItem5.Text = "Exportar a ...";
            superToolTip5.Items.Add(toolTipTitleItem5);
            this.bsiExportar.SuperTip = superToolTip5;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Caption = "Archivo CSV";
            this.btnExportCsv.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportCsv.Description = "CSV";
            this.btnExportCsv.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToCSV;
            this.btnExportCsv.Id = 66;
            this.btnExportCsv.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToCSV_32x32;
            this.btnExportCsv.Name = "btnExportCsv";
            // 
            // btnExportHtml
            // 
            this.btnExportHtml.Caption = "Archivo Html";
            this.btnExportHtml.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportHtml.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToHTML;
            this.btnExportHtml.Id = 67;
            this.btnExportHtml.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToHTML_32x32;
            this.btnExportHtml.Name = "btnExportHtml";
            // 
            // btnExportMht
            // 
            this.btnExportMht.Caption = "Archivo MHT";
            this.btnExportMht.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportMht.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToMHT;
            this.btnExportMht.Id = 69;
            this.btnExportMht.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToMHT_32x32;
            this.btnExportMht.Name = "btnExportMht";
            // 
            // btnExportImg
            // 
            this.btnExportImg.Caption = "Archivo Imagen";
            this.btnExportImg.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportImg.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToImage;
            this.btnExportImg.Id = 68;
            this.btnExportImg.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToImage_32x32;
            this.btnExportImg.Name = "btnExportImg";
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Caption = "Archivo PDF";
            this.btnExportPdf.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportPdf.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToPDF;
            this.btnExportPdf.Id = 70;
            this.btnExportPdf.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToPDF_32x32;
            this.btnExportPdf.Name = "btnExportPdf";
            // 
            // btnExportRtf
            // 
            this.btnExportRtf.Caption = "Archivo RTF";
            this.btnExportRtf.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportRtf.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToRTF;
            this.btnExportRtf.Id = 71;
            this.btnExportRtf.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToRTF_32x32;
            this.btnExportRtf.Name = "btnExportRtf";
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Caption = "Archivo de Texto";
            this.btnExportTxt.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportTxt.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToText;
            this.btnExportTxt.Id = 72;
            this.btnExportTxt.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToText_32x32;
            this.btnExportTxt.Name = "btnExportTxt";
            // 
            // btnExportXls
            // 
            this.btnExportXls.Caption = "Archivo XLS";
            this.btnExportXls.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportXls.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToXls;
            this.btnExportXls.Id = 73;
            this.btnExportXls.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToXls_32x32;
            this.btnExportXls.Name = "btnExportXls";
            // 
            // btnExportXlsx
            // 
            this.btnExportXlsx.Caption = "Archivo XLSX";
            this.btnExportXlsx.CategoryGuid = new System.Guid("a9f1f2eb-11e3-4541-aa36-34a8926e4a97");
            this.btnExportXlsx.Glyph = global::WinFormsApp.Properties.Resources.Action_Export_ToXLSX;
            this.btnExportXlsx.Id = 74;
            this.btnExportXlsx.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Export_ToXLSX_32x32;
            this.btnExportXlsx.Name = "btnExportXlsx";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Caption = "Salir";
            this.btnCerrar.CategoryGuid = new System.Guid("914e515b-0bf8-4995-97b2-cce8dc1d7479");
            this.btnCerrar.Glyph = global::WinFormsApp.Properties.Resources.Action_Close;
            this.btnCerrar.Id = 75;
            this.btnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCerrar.LargeGlyph = global::WinFormsApp.Properties.Resources.Action_Close_32x32;
            this.btnCerrar.Name = "btnCerrar";
            toolTipTitleItem6.Text = "Salir de ventana (Ctrl + S)";
            superToolTip6.Items.Add(toolTipTitleItem6);
            this.btnCerrar.SuperTip = superToolTip6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(863, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 305);
            this.barDockControlBottom.Size = new System.Drawing.Size(863, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 274);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(863, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 274);
            // 
            // btnListado1
            // 
            this.btnListado1.Caption = "Listado";
            this.btnListado1.Id = 65;
            this.btnListado1.Name = "btnListado1";
            // 
            // gcConsulta
            // 
            this.gcConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConsulta.Location = new System.Drawing.Point(0, 31);
            this.gcConsulta.MainView = this.gvConsulta;
            this.gcConsulta.MenuManager = this.bmConsulta;
            this.gcConsulta.Name = "gcConsulta";
            this.gcConsulta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerocotiza,
            this.riTotaln2});
            this.gcConsulta.Size = new System.Drawing.Size(863, 274);
            this.gcConsulta.TabIndex = 0;
            this.gcConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConsulta});
            this.gcConsulta.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcConsulta_ProcessGridKey);
            // 
            // gvConsulta
            // 
            this.gvConsulta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn9,
            this.gridColumn12,
            this.gcAnulado,
            this.gridColumn7});
            this.gvConsulta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gcAnulado;
            gridFormatRule1.ColumnApplyTo = this.gcAnulado;
            gridFormatRule1.Name = "FormatAnulado";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[Anulado]";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gvConsulta.FormatRules.Add(gridFormatRule1);
            this.gvConsulta.GridControl = this.gcConsulta;
            this.gvConsulta.Name = "gvConsulta";
            this.gvConsulta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvConsulta.OptionsBehavior.ReadOnly = true;
            this.gvConsulta.OptionsView.ColumnAutoWidth = false;
            this.gvConsulta.OptionsView.ShowFooter = true;
            this.gvConsulta.ShownEditor += new System.EventHandler(this.gvConsulta_ShownEditor);
            this.gvConsulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvConsulta_KeyDown);
            this.gvConsulta.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gvConsulta_MouseWheel);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id.";
            this.gridColumn1.FieldName = "Idordendeventa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "idordendeventa", "Nº {0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 67;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tipo";
            this.gridColumn3.FieldName = "Nombretipoformato";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Serie";
            this.gridColumn4.FieldName = "Serieordenventa";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Cotizacion";
            this.gridColumn5.ColumnEdit = this.riNumerocotiza;
            this.gridColumn5.FieldName = "Numeroordenventa";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // riNumerocotiza
            // 
            this.riNumerocotiza.AutoHeight = false;
            this.riNumerocotiza.Mask.EditMask = "d8";
            this.riNumerocotiza.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerocotiza.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerocotiza.Name = "riNumerocotiza";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fechaordenventa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ruc";
            this.gridColumn6.FieldName = "Nrodocentidadprincipal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cliente";
            this.gridColumn8.FieldName = "Razonsocial";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.ColumnEdit = this.riTotaln2;
            this.gridColumn9.FieldName = "Totaldocumento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // riTotaln2
            // 
            this.riTotaln2.AutoHeight = false;
            this.riTotaln2.Mask.EditMask = "n2";
            this.riTotaln2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riTotaln2.Mask.UseMaskAsDisplayFormat = true;
            this.riTotaln2.Name = "riTotaln2";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Condicion";
            this.gridColumn12.FieldName = "Nombrecondicion";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estado Facturación";
            this.gridColumn7.FieldName = "Estadofacturacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 11;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Moneda";
            this.gridColumn11.FieldName = "Simbolomoneda";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            // 
            // OrdendeventaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 305);
            this.Controls.Add(this.gcConsulta);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdendeventaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdendeventaFrm_FormClosing);
            this.Load += new System.EventHandler(this.OrdendeventaFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bmConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerocotiza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTotaln2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnNuevo;
        private DevExpress.XtraBars.BarButtonItem btnModificar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarSubItem bsiExportar;
        private DevExpress.XtraBars.BarButtonItem btnListado1;
        private DevExpress.XtraBars.BarButtonItem btnExportCsv;
        private DevExpress.XtraBars.BarButtonItem btnExportHtml;
        private DevExpress.XtraBars.BarButtonItem btnExportImg;
        private DevExpress.XtraBars.BarButtonItem btnExportMht;
        private DevExpress.XtraBars.BarButtonItem btnExportPdf;
        private DevExpress.XtraBars.BarButtonItem btnExportRtf;
        private DevExpress.XtraBars.BarButtonItem btnExportTxt;
        private DevExpress.XtraBars.BarButtonItem btnExportXls;
        private DevExpress.XtraBars.BarButtonItem btnExportXlsx;
        private DevExpress.XtraBars.BarButtonItem btnCerrar;
        private DevExpress.XtraBars.Bar BarMnt;
        private DevExpress.XtraBars.BarManager bmConsulta;
        private DevExpress.XtraGrid.GridControl gcConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConsulta;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerocotiza;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gcAnulado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riTotaln2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}