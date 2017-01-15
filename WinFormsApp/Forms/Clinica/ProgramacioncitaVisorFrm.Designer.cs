namespace WinFormsApp
{
    partial class ProgramacioncitaVisorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramacioncitaVisorFrm));
            this.sccPrincipal = new DevExpress.XtraEditors.SplitContainerControl();
            this.sccPrincipalDerecho = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.iCalendarioCita = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVerPagos = new DevExpress.XtraEditors.SimpleButton();
            this.btnCpVenta = new DevExpress.XtraEditors.SimpleButton();
            this.cmdVerHistorial = new DevExpress.XtraEditors.SimpleButton();
            this.btnVerEditarrCita = new DevExpress.XtraEditors.SimpleButton();
            this.iFiltroEspecialidad = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.iFiltroMedico = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReciboCajaLay = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.VerModificarCitaLay = new DevExpress.XtraLayout.LayoutControlItem();
            this.VerHistorialLay = new DevExpress.XtraLayout.LayoutControlItem();
            this.ComprobanteVentaLay = new DevExpress.XtraLayout.LayoutControlItem();
            this.ActualizarLay = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtcCitas = new DevExpress.XtraTab.XtraTabControl();
            this.tpCitas = new DevExpress.XtraTab.XtraTabPage();
            this.gcCitas = new DevExpress.XtraGrid.GridControl();
            this.gvCitas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHoraInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gcHoraTermino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMotivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPaciente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcImagenestado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riPictureEstado = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gcEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMedico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcServicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpAdicionales = new DevExpress.XtraTab.XtraTabPage();
            this.tpLog = new DevExpress.XtraTab.XtraTabPage();
            this.sccEventosPrincipal = new DevExpress.XtraEditors.SplitContainerControl();
            this.bmCitas = new DevExpress.XtraBars.BarManager(this.components);
            this.barCitas = new DevExpress.XtraBars.Bar();
            this.btnVerEditarrCita1 = new DevExpress.XtraBars.BarButtonItem();
            this.cmdVerHistorial1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCpVenta1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerPagos1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAnularCita = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminarProgramacion = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.sccPrincipal)).BeginInit();
            this.sccPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccPrincipalDerecho)).BeginInit();
            this.sccPrincipalDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iCalendarioCita.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltroEspecialidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltroMedico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReciboCajaLay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerModificarCitaLay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerHistorialLay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprobanteVentaLay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualizarLay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcCitas)).BeginInit();
            this.xtcCitas.SuspendLayout();
            this.tpCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPictureEstado)).BeginInit();
            this.tpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccEventosPrincipal)).BeginInit();
            this.sccEventosPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bmCitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // sccPrincipal
            // 
            this.sccPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccPrincipal.Location = new System.Drawing.Point(0, 0);
            this.sccPrincipal.Name = "sccPrincipal";
            this.sccPrincipal.Panel1.Controls.Add(this.sccPrincipalDerecho);
            this.sccPrincipal.Panel1.Text = "PanelDerecho";
            this.sccPrincipal.Panel2.Controls.Add(this.xtcCitas);
            this.sccPrincipal.Panel2.Text = "PanelGrid";
            this.sccPrincipal.Size = new System.Drawing.Size(1165, 529);
            this.sccPrincipal.SplitterPosition = 256;
            this.sccPrincipal.TabIndex = 0;
            this.sccPrincipal.Text = "splitContainerControl1";
            // 
            // sccPrincipalDerecho
            // 
            this.sccPrincipalDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccPrincipalDerecho.Horizontal = false;
            this.sccPrincipalDerecho.Location = new System.Drawing.Point(0, 0);
            this.sccPrincipalDerecho.Name = "sccPrincipalDerecho";
            this.sccPrincipalDerecho.Panel1.Controls.Add(this.groupControl1);
            this.sccPrincipalDerecho.Panel1.Text = "PanelCalendario";
            this.sccPrincipalDerecho.Panel2.Controls.Add(this.groupControl2);
            this.sccPrincipalDerecho.Panel2.Text = "PanelPropiedades";
            this.sccPrincipalDerecho.Size = new System.Drawing.Size(256, 529);
            this.sccPrincipalDerecho.SplitterPosition = 224;
            this.sccPrincipalDerecho.TabIndex = 0;
            this.sccPrincipalDerecho.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSize = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.iCalendarioCita);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(256, 224);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Calendario de citas";
            // 
            // iCalendarioCita
            // 
            this.iCalendarioCita.CalendarAppearance.DayCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.iCalendarioCita.CalendarAppearance.DayCell.Options.UseFont = true;
            this.iCalendarioCita.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iCalendarioCita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iCalendarioCita.DrawCellLines = true;
            this.iCalendarioCita.Location = new System.Drawing.Point(2, 20);
            this.iCalendarioCita.Name = "iCalendarioCita";
            this.iCalendarioCita.ShowMonthHeaders = false;
            this.iCalendarioCita.Size = new System.Drawing.Size(252, 202);
            this.iCalendarioCita.TabIndex = 0;
            this.iCalendarioCita.DateTimeChanged += new System.EventHandler(this.iCalendarioCita_DateTimeChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSize = true;
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(256, 300);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Filtros";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnEliminarProgramacion);
            this.layoutControl1.Controls.Add(this.btnActualizar);
            this.layoutControl1.Controls.Add(this.btnVerPagos);
            this.layoutControl1.Controls.Add(this.btnCpVenta);
            this.layoutControl1.Controls.Add(this.cmdVerHistorial);
            this.layoutControl1.Controls.Add(this.btnVerEditarrCita);
            this.layoutControl1.Controls.Add(this.iFiltroEspecialidad);
            this.layoutControl1.Controls.Add(this.iFiltroMedico);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ReciboCajaLay});
            this.layoutControl1.Location = new System.Drawing.Point(2, 20);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(309, 202, 409, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(252, 278);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Appearance.Options.UseTextOptions = true;
            this.btnActualizar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(12, 170);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(228, 22);
            this.btnActualizar.StyleController = this.layoutControl1;
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.ToolTip = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.Appearance.Options.UseTextOptions = true;
            this.btnVerPagos.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnVerPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnVerPagos.Image")));
            this.btnVerPagos.Location = new System.Drawing.Point(12, 170);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(228, 22);
            this.btnVerPagos.StyleController = this.layoutControl1;
            this.btnVerPagos.TabIndex = 9;
            this.btnVerPagos.Text = "Recibo de caja";
            this.btnVerPagos.ToolTip = "Recibo de caja";
            this.btnVerPagos.Visible = false;
            this.btnVerPagos.Click += new System.EventHandler(this.btnVerPagos_Click);
            // 
            // btnCpVenta
            // 
            this.btnCpVenta.Appearance.Options.UseTextOptions = true;
            this.btnCpVenta.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnCpVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnCpVenta.Image")));
            this.btnCpVenta.Location = new System.Drawing.Point(12, 144);
            this.btnCpVenta.Name = "btnCpVenta";
            this.btnCpVenta.Size = new System.Drawing.Size(228, 22);
            this.btnCpVenta.StyleController = this.layoutControl1;
            this.btnCpVenta.TabIndex = 8;
            this.btnCpVenta.Text = "Comprobante de Venta";
            this.btnCpVenta.ToolTip = "Comprobante de Venta";
            this.btnCpVenta.Click += new System.EventHandler(this.btnCpVenta_Click);
            // 
            // cmdVerHistorial
            // 
            this.cmdVerHistorial.Appearance.Options.UseTextOptions = true;
            this.cmdVerHistorial.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cmdVerHistorial.Image = ((System.Drawing.Image)(resources.GetObject("cmdVerHistorial.Image")));
            this.cmdVerHistorial.Location = new System.Drawing.Point(12, 118);
            this.cmdVerHistorial.Name = "cmdVerHistorial";
            this.cmdVerHistorial.Size = new System.Drawing.Size(228, 22);
            this.cmdVerHistorial.StyleController = this.layoutControl1;
            this.cmdVerHistorial.TabIndex = 7;
            this.cmdVerHistorial.Text = "Ver Historial";
            this.cmdVerHistorial.ToolTip = "Ver Historial";
            this.cmdVerHistorial.Click += new System.EventHandler(this.cmdVerHistorial_Click);
            // 
            // btnVerEditarrCita
            // 
            this.btnVerEditarrCita.Appearance.Options.UseTextOptions = true;
            this.btnVerEditarrCita.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnVerEditarrCita.Image = ((System.Drawing.Image)(resources.GetObject("btnVerEditarrCita.Image")));
            this.btnVerEditarrCita.Location = new System.Drawing.Point(12, 92);
            this.btnVerEditarrCita.Name = "btnVerEditarrCita";
            this.btnVerEditarrCita.Size = new System.Drawing.Size(228, 22);
            this.btnVerEditarrCita.StyleController = this.layoutControl1;
            this.btnVerEditarrCita.TabIndex = 6;
            this.btnVerEditarrCita.Text = "Ver/Modificar Cita";
            this.btnVerEditarrCita.ToolTip = "Ver/Modificar Cita";
            this.btnVerEditarrCita.Click += new System.EventHandler(this.btnVerEditarrCita_Click);
            // 
            // iFiltroEspecialidad
            // 
            this.iFiltroEspecialidad.Location = new System.Drawing.Point(12, 28);
            this.iFiltroEspecialidad.Name = "iFiltroEspecialidad";
            this.iFiltroEspecialidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFiltroEspecialidad.Properties.View = this.searchLookUpEdit2View;
            this.iFiltroEspecialidad.Size = new System.Drawing.Size(228, 20);
            this.iFiltroEspecialidad.StyleController = this.layoutControl1;
            this.iFiltroEspecialidad.TabIndex = 5;
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // iFiltroMedico
            // 
            this.iFiltroMedico.Location = new System.Drawing.Point(12, 68);
            this.iFiltroMedico.Name = "iFiltroMedico";
            this.iFiltroMedico.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iFiltroMedico.Properties.View = this.searchLookUpEdit1View;
            this.iFiltroMedico.Size = new System.Drawing.Size(228, 20);
            this.iFiltroMedico.StyleController = this.layoutControl1;
            this.iFiltroMedico.TabIndex = 4;
            this.iFiltroMedico.EditValueChanged += new System.EventHandler(this.iFiltroMedico_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Id.";
            this.gridColumn5.FieldName = "Idempleado";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Medico";
            this.gridColumn6.FieldName = "Razonsocial";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // ReciboCajaLay
            // 
            this.ReciboCajaLay.Control = this.btnVerPagos;
            this.ReciboCajaLay.Location = new System.Drawing.Point(0, 158);
            this.ReciboCajaLay.Name = "ReciboCajaLay";
            this.ReciboCajaLay.Size = new System.Drawing.Size(232, 26);
            this.ReciboCajaLay.TextSize = new System.Drawing.Size(0, 0);
            this.ReciboCajaLay.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.VerModificarCitaLay,
            this.VerHistorialLay,
            this.ComprobanteVentaLay,
            this.ActualizarLay,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(252, 278);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.iFiltroMedico;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 40);
            this.layoutControlItem1.Text = "Medico";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.iFiltroEspecialidad;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(232, 40);
            this.layoutControlItem2.Text = "Especialidad";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 210);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(232, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // VerModificarCitaLay
            // 
            this.VerModificarCitaLay.Control = this.btnVerEditarrCita;
            this.VerModificarCitaLay.Location = new System.Drawing.Point(0, 80);
            this.VerModificarCitaLay.Name = "VerModificarCitaLay";
            this.VerModificarCitaLay.Size = new System.Drawing.Size(232, 26);
            this.VerModificarCitaLay.TextSize = new System.Drawing.Size(0, 0);
            this.VerModificarCitaLay.TextVisible = false;
            // 
            // VerHistorialLay
            // 
            this.VerHistorialLay.Control = this.cmdVerHistorial;
            this.VerHistorialLay.Location = new System.Drawing.Point(0, 106);
            this.VerHistorialLay.Name = "VerHistorialLay";
            this.VerHistorialLay.Size = new System.Drawing.Size(232, 26);
            this.VerHistorialLay.TextSize = new System.Drawing.Size(0, 0);
            this.VerHistorialLay.TextVisible = false;
            // 
            // ComprobanteVentaLay
            // 
            this.ComprobanteVentaLay.Control = this.btnCpVenta;
            this.ComprobanteVentaLay.Location = new System.Drawing.Point(0, 132);
            this.ComprobanteVentaLay.Name = "ComprobanteVentaLay";
            this.ComprobanteVentaLay.Size = new System.Drawing.Size(232, 26);
            this.ComprobanteVentaLay.TextSize = new System.Drawing.Size(0, 0);
            this.ComprobanteVentaLay.TextVisible = false;
            // 
            // ActualizarLay
            // 
            this.ActualizarLay.Control = this.btnActualizar;
            this.ActualizarLay.Location = new System.Drawing.Point(0, 158);
            this.ActualizarLay.Name = "ActualizarLay";
            this.ActualizarLay.Size = new System.Drawing.Size(232, 26);
            this.ActualizarLay.TextSize = new System.Drawing.Size(0, 0);
            this.ActualizarLay.TextVisible = false;
            // 
            // xtcCitas
            // 
            this.xtcCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcCitas.Location = new System.Drawing.Point(0, 0);
            this.xtcCitas.Name = "xtcCitas";
            this.xtcCitas.SelectedTabPage = this.tpCitas;
            this.xtcCitas.Size = new System.Drawing.Size(904, 529);
            this.xtcCitas.TabIndex = 0;
            this.xtcCitas.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpCitas,
            this.tpAdicionales,
            this.tpLog});
            // 
            // tpCitas
            // 
            this.tpCitas.Controls.Add(this.gcCitas);
            this.tpCitas.Name = "tpCitas";
            this.tpCitas.Size = new System.Drawing.Size(898, 501);
            this.tpCitas.Text = "Citas programadas";
            // 
            // gcCitas
            // 
            this.gcCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCitas.Location = new System.Drawing.Point(0, 0);
            this.gcCitas.MainView = this.gvCitas;
            this.gcCitas.Name = "gcCitas";
            this.gcCitas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riTime,
            this.riPictureEstado});
            this.gcCitas.Size = new System.Drawing.Size(898, 501);
            this.gcCitas.TabIndex = 1;
            this.gcCitas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCitas});
            // 
            // gvCitas
            // 
            this.gvCitas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcId,
            this.gcHoraInicio,
            this.gcHoraTermino,
            this.gcMotivo,
            this.gcPaciente,
            this.gcImagenestado,
            this.gcEstado,
            this.gcMedico,
            this.gcServicio,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn1});
            this.gvCitas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvCitas.GridControl = this.gcCitas;
            this.gvCitas.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvCitas.Name = "gvCitas";
            this.gvCitas.OptionsBehavior.ReadOnly = true;
            this.gvCitas.OptionsCustomization.AllowColumnMoving = false;
            this.gvCitas.OptionsCustomization.AllowGroup = false;
            this.gvCitas.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvCitas.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvCitas.OptionsView.ColumnAutoWidth = false;
            this.gvCitas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvCitas.OptionsView.ShowGroupPanel = false;
            this.gvCitas.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvCitas.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvCitas_RowCellStyle);
            this.gvCitas.ShownEditor += new System.EventHandler(this.gvCitas_ShownEditor);
            this.gvCitas.DoubleClick += new System.EventHandler(this.gvCitas_DoubleClick);
            // 
            // gcId
            // 
            this.gcId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcId.AppearanceHeader.Options.UseFont = true;
            this.gcId.Caption = "Id.";
            this.gcId.FieldName = "Idprogramacioncitadet";
            this.gcId.Name = "gcId";
            this.gcId.Width = 61;
            // 
            // gcHoraInicio
            // 
            this.gcHoraInicio.AppearanceCell.Options.UseTextOptions = true;
            this.gcHoraInicio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcHoraInicio.Caption = "Hora inicio";
            this.gcHoraInicio.ColumnEdit = this.riTime;
            this.gcHoraInicio.FieldName = "Horaprogramacion";
            this.gcHoraInicio.Name = "gcHoraInicio";
            this.gcHoraInicio.Visible = true;
            this.gcHoraInicio.VisibleIndex = 1;
            this.gcHoraInicio.Width = 100;
            // 
            // riTime
            // 
            this.riTime.AutoHeight = false;
            this.riTime.Mask.EditMask = "t";
            this.riTime.Mask.UseMaskAsDisplayFormat = true;
            this.riTime.Name = "riTime";
            // 
            // gcHoraTermino
            // 
            this.gcHoraTermino.Caption = "Hora fin";
            this.gcHoraTermino.ColumnEdit = this.riTime;
            this.gcHoraTermino.FieldName = "Horatermino";
            this.gcHoraTermino.Name = "gcHoraTermino";
            this.gcHoraTermino.Visible = true;
            this.gcHoraTermino.VisibleIndex = 2;
            this.gcHoraTermino.Width = 100;
            // 
            // gcMotivo
            // 
            this.gcMotivo.Caption = "Motivo";
            this.gcMotivo.FieldName = "Nombremotivocita";
            this.gcMotivo.Name = "gcMotivo";
            this.gcMotivo.Visible = true;
            this.gcMotivo.VisibleIndex = 4;
            this.gcMotivo.Width = 146;
            // 
            // gcPaciente
            // 
            this.gcPaciente.Caption = "Paciente";
            this.gcPaciente.FieldName = "Razonsocialpaciente";
            this.gcPaciente.Name = "gcPaciente";
            this.gcPaciente.Visible = true;
            this.gcPaciente.VisibleIndex = 3;
            this.gcPaciente.Width = 213;
            // 
            // gcImagenestado
            // 
            this.gcImagenestado.Caption = "Estado";
            this.gcImagenestado.ColumnEdit = this.riPictureEstado;
            this.gcImagenestado.FieldName = "Imagenestado";
            this.gcImagenestado.Name = "gcImagenestado";
            this.gcImagenestado.OptionsColumn.ReadOnly = true;
            this.gcImagenestado.Visible = true;
            this.gcImagenestado.VisibleIndex = 5;
            this.gcImagenestado.Width = 81;
            // 
            // riPictureEstado
            // 
            this.riPictureEstado.Name = "riPictureEstado";
            this.riPictureEstado.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // gcEstado
            // 
            this.gcEstado.Caption = "Estado";
            this.gcEstado.FieldName = "Nombreestadocita";
            this.gcEstado.Name = "gcEstado";
            this.gcEstado.Width = 171;
            // 
            // gcMedico
            // 
            this.gcMedico.Caption = "Medico";
            this.gcMedico.FieldName = "Nombrecomercialmedico";
            this.gcMedico.Name = "gcMedico";
            this.gcMedico.Visible = true;
            this.gcMedico.VisibleIndex = 0;
            this.gcMedico.Width = 102;
            // 
            // gcServicio
            // 
            this.gcServicio.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcServicio.AppearanceHeader.Options.UseFont = true;
            this.gcServicio.Caption = "Servicio";
            this.gcServicio.FieldName = "Nombrearticulo";
            this.gcServicio.Name = "gcServicio";
            this.gcServicio.Width = 59;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cp. Venta";
            this.gridColumn2.FieldName = "Tiposerienumerocpventa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 117;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "N° Recibo Ingreso";
            this.gridColumn4.FieldName = "Tiposerienumerorecibo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 106;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id. Recibo";
            this.gridColumn3.FieldName = "Idrecibocajaingreso";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id. Cp Venta";
            this.gridColumn1.FieldName = "Idcpventa";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // tpAdicionales
            // 
            this.tpAdicionales.Name = "tpAdicionales";
            this.tpAdicionales.PageVisible = false;
            this.tpAdicionales.Size = new System.Drawing.Size(898, 501);
            this.tpAdicionales.Text = "Adicionales";
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.sccEventosPrincipal);
            this.tpLog.Name = "tpLog";
            this.tpLog.PageVisible = false;
            this.tpLog.Size = new System.Drawing.Size(898, 501);
            this.tpLog.Text = "Eventos";
            // 
            // sccEventosPrincipal
            // 
            this.sccEventosPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccEventosPrincipal.Horizontal = false;
            this.sccEventosPrincipal.Location = new System.Drawing.Point(0, 0);
            this.sccEventosPrincipal.Name = "sccEventosPrincipal";
            this.sccEventosPrincipal.Panel1.Text = "PanelEventos";
            this.sccEventosPrincipal.Panel2.Text = "PanelUsuarios";
            this.sccEventosPrincipal.Size = new System.Drawing.Size(898, 501);
            this.sccEventosPrincipal.SplitterPosition = 448;
            this.sccEventosPrincipal.TabIndex = 9;
            this.sccEventosPrincipal.Text = "splitContainerControl1";
            // 
            // bmCitas
            // 
            this.bmCitas.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barCitas});
            this.bmCitas.DockControls.Add(this.barDockControlTop);
            this.bmCitas.DockControls.Add(this.barDockControlBottom);
            this.bmCitas.DockControls.Add(this.barDockControlLeft);
            this.bmCitas.DockControls.Add(this.barDockControlRight);
            this.bmCitas.Form = this;
            this.bmCitas.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnVerEditarrCita1,
            this.btnAnularCita,
            this.btnVerPagos1,
            this.btnActualizar1,
            this.cmdVerHistorial1,
            this.btnCpVenta1});
            this.bmCitas.MaxItemId = 9;
            this.bmCitas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmCitas_ItemClick);
            // 
            // barCitas
            // 
            this.barCitas.BarName = "Tools Citas";
            this.barCitas.DockCol = 0;
            this.barCitas.DockRow = 0;
            this.barCitas.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barCitas.FloatLocation = new System.Drawing.Point(40, 186);
            this.barCitas.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVerEditarrCita1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cmdVerHistorial1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCpVenta1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnVerPagos1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnActualizar1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barCitas.OptionsBar.UseWholeRow = true;
            this.barCitas.Text = "Tools";
            this.barCitas.Visible = false;
            // 
            // btnVerEditarrCita1
            // 
            this.btnVerEditarrCita1.Caption = "Ver/Modificar Cita";
            this.btnVerEditarrCita1.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerEditarrCita1.Glyph")));
            this.btnVerEditarrCita1.Id = 2;
            this.btnVerEditarrCita1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerEditarrCita1.LargeGlyph")));
            this.btnVerEditarrCita1.Name = "btnVerEditarrCita1";
            // 
            // cmdVerHistorial1
            // 
            this.cmdVerHistorial1.Caption = "Ver Historial";
            this.cmdVerHistorial1.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdVerHistorial1.Glyph")));
            this.cmdVerHistorial1.Id = 7;
            this.cmdVerHistorial1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cmdVerHistorial1.LargeGlyph")));
            this.cmdVerHistorial1.Name = "cmdVerHistorial1";
            // 
            // btnCpVenta1
            // 
            this.btnCpVenta1.Caption = "Comprobante de venta";
            this.btnCpVenta1.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCpVenta1.Glyph")));
            this.btnCpVenta1.Id = 8;
            this.btnCpVenta1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCpVenta1.LargeGlyph")));
            this.btnCpVenta1.Name = "btnCpVenta1";
            // 
            // btnVerPagos1
            // 
            this.btnVerPagos1.Caption = "Recibo de caja";
            this.btnVerPagos1.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerPagos1.Glyph")));
            this.btnVerPagos1.Id = 4;
            this.btnVerPagos1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerPagos1.LargeGlyph")));
            this.btnVerPagos1.Name = "btnVerPagos1";
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.Caption = "Actualizar";
            this.btnActualizar1.Glyph = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.Glyph")));
            this.btnActualizar1.Id = 6;
            this.btnActualizar1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.LargeGlyph")));
            this.btnActualizar1.Name = "btnActualizar1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1165, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 529);
            this.barDockControlBottom.Size = new System.Drawing.Size(1165, 31);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1165, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 529);
            // 
            // btnAnularCita
            // 
            this.btnAnularCita.Caption = "Anular Cita";
            this.btnAnularCita.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAnularCita.Glyph")));
            this.btnAnularCita.Id = 3;
            this.btnAnularCita.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAnularCita.LargeGlyph")));
            this.btnAnularCita.Name = "btnAnularCita";
            // 
            // btnEliminarProgramacion
            // 
            this.btnEliminarProgramacion.Appearance.Options.UseTextOptions = true;
            this.btnEliminarProgramacion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnEliminarProgramacion.Image = global::WinFormsApp.Properties.Resources.Action_Delete_12x12;
            this.btnEliminarProgramacion.Location = new System.Drawing.Point(12, 196);
            this.btnEliminarProgramacion.Name = "btnEliminarProgramacion";
            this.btnEliminarProgramacion.Size = new System.Drawing.Size(228, 22);
            this.btnEliminarProgramacion.StyleController = this.layoutControl1;
            this.btnEliminarProgramacion.TabIndex = 11;
            this.btnEliminarProgramacion.Text = "Eliminar programación";
            this.btnEliminarProgramacion.Click += new System.EventHandler(this.btnEliminarProgramacion_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEliminarProgramacion;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 184);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ProgramacioncitaVisorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 560);
            this.Controls.Add(this.sccPrincipal);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ProgramacioncitaVisorFrm";
            this.Text = "Citas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramacioncitaVisorFrm_FormClosing);
            this.Load += new System.EventHandler(this.ProgramacioncitaVisorFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sccPrincipal)).EndInit();
            this.sccPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccPrincipalDerecho)).EndInit();
            this.sccPrincipalDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iCalendarioCita.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iFiltroEspecialidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iFiltroMedico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReciboCajaLay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerModificarCitaLay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerHistorialLay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprobanteVentaLay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualizarLay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcCitas)).EndInit();
            this.xtcCitas.ResumeLayout(false);
            this.tpCitas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPictureEstado)).EndInit();
            this.tpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccEventosPrincipal)).EndInit();
            this.sccEventosPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bmCitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccPrincipal;
        private DevExpress.XtraEditors.SplitContainerControl sccPrincipalDerecho;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Controls.CalendarControl iCalendarioCita;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit iFiltroEspecialidad;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit iFiltroMedico;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarManager bmCitas;
        private DevExpress.XtraBars.Bar barCitas;
        private DevExpress.XtraBars.BarButtonItem btnVerEditarrCita1;
        private DevExpress.XtraBars.BarButtonItem btnAnularCita;
        private DevExpress.XtraBars.BarButtonItem btnVerPagos1;
        private DevExpress.XtraBars.BarButtonItem btnActualizar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl xtcCitas;
        private DevExpress.XtraTab.XtraTabPage tpCitas;
        private DevExpress.XtraGrid.GridControl gcCitas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCitas;
        private DevExpress.XtraGrid.Columns.GridColumn gcId;
        private DevExpress.XtraGrid.Columns.GridColumn gcHoraInicio;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit riTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcServicio;
        private DevExpress.XtraGrid.Columns.GridColumn gcMedico;
        private DevExpress.XtraGrid.Columns.GridColumn gcPaciente;
        private DevExpress.XtraGrid.Columns.GridColumn gcEstado;
        private DevExpress.XtraTab.XtraTabPage tpAdicionales;
        private DevExpress.XtraTab.XtraTabPage tpLog;
        private DevExpress.XtraEditors.SplitContainerControl sccEventosPrincipal;
        private DevExpress.XtraGrid.Columns.GridColumn gcMotivo;
        private DevExpress.XtraBars.BarButtonItem cmdVerHistorial1;
        private DevExpress.XtraBars.BarButtonItem btnCpVenta1;
        private DevExpress.XtraGrid.Columns.GridColumn gcHoraTermino;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnVerPagos;
        private DevExpress.XtraEditors.SimpleButton btnCpVenta;
        private DevExpress.XtraEditors.SimpleButton cmdVerHistorial;
        private DevExpress.XtraEditors.SimpleButton btnVerEditarrCita;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem VerModificarCitaLay;
        private DevExpress.XtraLayout.LayoutControlItem VerHistorialLay;
        private DevExpress.XtraLayout.LayoutControlItem ComprobanteVentaLay;
        private DevExpress.XtraLayout.LayoutControlItem ReciboCajaLay;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraLayout.LayoutControlItem ActualizarLay;
        private DevExpress.XtraGrid.Columns.GridColumn gcImagenestado;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit riPictureEstado;
        private DevExpress.XtraEditors.SimpleButton btnEliminarProgramacion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}