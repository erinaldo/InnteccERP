namespace WinFormsApp
{
    partial class ListaprecioActualizacionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaprecioActualizacionFrm));
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.iIdsucursal = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.gcDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riNumerico2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMargenCreditoOpcion1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreditodia1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMargenCreditoOpcion2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreditodia2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riFechaHora = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.iIdlistaprecio = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminarArticulo = new DevExpress.XtraEditors.SimpleButton();
            this.rListaprecioincluyeimpuesto = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdlistaprecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rListaprecioincluyeimpuesto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(797, 7);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar Articulo";
            this.btnAgregar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // iIdsucursal
            // 
            this.iIdsucursal.Location = new System.Drawing.Point(77, 8);
            this.iIdsucursal.Name = "iIdsucursal";
            this.iIdsucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdsucursal.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdsucursal.Properties.View = this.gridView8;
            this.iIdsucursal.Size = new System.Drawing.Size(219, 20);
            this.iIdsucursal.TabIndex = 59;
            this.iIdsucursal.TabStop = false;
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41});
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Id.";
            this.gridColumn39.FieldName = "Idsucursal";
            this.gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Código";
            this.gridColumn40.FieldName = "Codigosucursal";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 0;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "Sucursal";
            this.gridColumn41.FieldName = "Nombresucursal";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 1;
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(5, 12);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(40, 13);
            this.labelControl26.TabIndex = 60;
            this.labelControl26.Text = "Sucursal";
            // 
            // gcDetalle
            // 
            this.gcDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcDetalle.Location = new System.Drawing.Point(5, 36);
            this.gcDetalle.MainView = this.gvDetalle;
            this.gcDetalle.Name = "gcDetalle";
            this.gcDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNumerico2,
            this.riNumerico4,
            this.riFechaHora});
            this.gcDetalle.Size = new System.Drawing.Size(1198, 470);
            this.gcDetalle.TabIndex = 65;
            this.gcDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetalle});
            this.gcDetalle.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcDetalle_ProcessGridKey);
            // 
            // gvDetalle
            // 
            this.gvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn19,
            this.gridColumn5,
            this.gridColumn20,
            this.gridColumn1,
            this.gridColumn21,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn6,
            this.gcMargenCreditoOpcion1,
            this.gcCreditodia1,
            this.gcMargenCreditoOpcion2,
            this.gcCreditodia2,
            this.gridColumn9,
            this.gridColumn26});
            this.gvDetalle.GridControl = this.gcDetalle;
            this.gvDetalle.Name = "gvDetalle";
            this.gvDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetalle.OptionsFind.AlwaysVisible = true;
            this.gvDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvDetalle.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetalle_CellValueChanged);
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Id.";
            this.gridColumn23.FieldName = "Idarticulo";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Width = 43;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Código";
            this.gridColumn19.FieldName = "Codigoarticulo";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 52;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cod.Prov.";
            this.gridColumn5.FieldName = "Codigoproveedor";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 61;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Nombre Artículo";
            this.gridColumn20.FieldName = "Nombrearticulo";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 2;
            this.gridColumn20.Width = 104;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Clasificacion";
            this.gridColumn1.FieldName = "Nombreclasificacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 85;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Marca";
            this.gridColumn21.FieldName = "Nombremarca";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 3;
            this.gridColumn21.Width = 79;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Unidad";
            this.gridColumn2.FieldName = "Abrunidadmedida";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 49;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Costo";
            this.gridColumn8.ColumnEdit = this.riNumerico4;
            this.gridColumn8.FieldName = "Costolista";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // riNumerico4
            // 
            this.riNumerico4.DisplayFormat.FormatString = "n4";
            this.riNumerico4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.EditFormat.FormatString = "n4";
            this.riNumerico4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico4.Mask.EditMask = "n4";
            this.riNumerico4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico4.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico4.Name = "riNumerico4";
            this.riNumerico4.EditValueChanged += new System.EventHandler(this.riNumerico4_EditValueChanged);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "% M. Contado";
            this.gridColumn7.ColumnEdit = this.riNumerico2;
            this.gridColumn7.FieldName = "Porcentajemargencontado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 81;
            // 
            // riNumerico2
            // 
            this.riNumerico2.DisplayFormat.FormatString = "n2";
            this.riNumerico2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico2.EditFormat.FormatString = "n2";
            this.riNumerico2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riNumerico2.Mask.EditMask = "n2";
            this.riNumerico2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.riNumerico2.Mask.UseMaskAsDisplayFormat = true;
            this.riNumerico2.Name = "riNumerico2";
            this.riNumerico2.EditValueChanged += new System.EventHandler(this.riNumerico2_EditValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Contado";
            this.gridColumn6.ColumnEdit = this.riNumerico4;
            this.gridColumn6.FieldName = "Preciocontado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gcMargenCreditoOpcion1
            // 
            this.gcMargenCreditoOpcion1.Caption = "% Margen";
            this.gcMargenCreditoOpcion1.ColumnEdit = this.riNumerico2;
            this.gcMargenCreditoOpcion1.FieldName = "Porcentajemargencreditoopcion1";
            this.gcMargenCreditoOpcion1.Name = "gcMargenCreditoOpcion1";
            this.gcMargenCreditoOpcion1.Visible = true;
            this.gcMargenCreditoOpcion1.VisibleIndex = 8;
            // 
            // gcCreditodia1
            // 
            this.gcCreditodia1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcCreditodia1.AppearanceHeader.Options.UseFont = true;
            this.gcCreditodia1.Caption = "Crédito";
            this.gcCreditodia1.ColumnEdit = this.riNumerico4;
            this.gcCreditodia1.FieldName = "Preciocreditoopcion1";
            this.gcCreditodia1.Name = "gcCreditodia1";
            this.gcCreditodia1.Visible = true;
            this.gcCreditodia1.VisibleIndex = 9;
            this.gcCreditodia1.Width = 63;
            // 
            // gcMargenCreditoOpcion2
            // 
            this.gcMargenCreditoOpcion2.Caption = "% Margen";
            this.gcMargenCreditoOpcion2.ColumnEdit = this.riNumerico2;
            this.gcMargenCreditoOpcion2.FieldName = "Porcentajemargencreditoopcion2";
            this.gcMargenCreditoOpcion2.Name = "gcMargenCreditoOpcion2";
            this.gcMargenCreditoOpcion2.Visible = true;
            this.gcMargenCreditoOpcion2.VisibleIndex = 10;
            this.gcMargenCreditoOpcion2.Width = 69;
            // 
            // gcCreditodia2
            // 
            this.gcCreditodia2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcCreditodia2.AppearanceHeader.Options.UseFont = true;
            this.gcCreditodia2.Caption = "Crédito";
            this.gcCreditodia2.ColumnEdit = this.riNumerico4;
            this.gcCreditodia2.FieldName = "Preciocreditoopcion2";
            this.gcCreditodia2.Name = "gcCreditodia2";
            this.gcCreditodia2.Visible = true;
            this.gcCreditodia2.VisibleIndex = 11;
            this.gcCreditodia2.Width = 85;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "% M. Sugerido";
            this.gridColumn9.ColumnEdit = this.riNumerico2;
            this.gridColumn9.FieldName = "Porcentajemargenpreciosugerido";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 80;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn26.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn26.AppearanceHeader.Options.UseFont = true;
            this.gridColumn26.Caption = "Sugerido/P.";
            this.gridColumn26.ColumnEdit = this.riNumerico4;
            this.gridColumn26.FieldName = "Preciosugerido";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 13;
            this.gridColumn26.Width = 74;
            // 
            // riFechaHora
            // 
            this.riFechaHora.Mask.EditMask = "g";
            this.riFechaHora.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.riFechaHora.Mask.UseMaskAsDisplayFormat = true;
            this.riFechaHora.Name = "riFechaHora";
            // 
            // iIdlistaprecio
            // 
            this.iIdlistaprecio.Location = new System.Drawing.Point(368, 8);
            this.iIdlistaprecio.Name = "iIdlistaprecio";
            this.iIdlistaprecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iIdlistaprecio.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.iIdlistaprecio.Properties.View = this.gridView2;
            this.iIdlistaprecio.Size = new System.Drawing.Size(244, 20);
            this.iIdlistaprecio.TabIndex = 101;
            this.iIdlistaprecio.Tag = "Seleccione el tipo de lista";
            this.iIdlistaprecio.EditValueChanged += new System.EventHandler(this.iIdlistaprecio_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id.";
            this.gridColumn3.FieldName = "Idtipolista";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tipo de Lista";
            this.gridColumn4.FieldName = "Tipolistaprecio";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(302, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 102;
            this.labelControl3.Text = "Tipo de Lista";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(1023, 7);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(107, 23);
            this.btnActualizar.TabIndex = 110;
            this.btnActualizar.Text = "Actualizar Lista";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Image = global::WinFormsApp.Properties.Resources.Action_Delete;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(910, 7);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarArticulo.TabIndex = 111;
            this.btnEliminarArticulo.Text = "Eliminar Articulo";
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // rListaprecioincluyeimpuesto
            // 
            this.rListaprecioincluyeimpuesto.Location = new System.Drawing.Point(618, 9);
            this.rListaprecioincluyeimpuesto.Name = "rListaprecioincluyeimpuesto";
            this.rListaprecioincluyeimpuesto.Properties.AutoWidth = true;
            this.rListaprecioincluyeimpuesto.Properties.Caption = "Lista de precio incluye impuesto";
            this.rListaprecioincluyeimpuesto.Properties.ReadOnly = true;
            this.rListaprecioincluyeimpuesto.Size = new System.Drawing.Size(173, 19);
            this.rListaprecioincluyeimpuesto.TabIndex = 112;
            // 
            // ListaprecioActualizacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 508);
            this.Controls.Add(this.rListaprecioincluyeimpuesto);
            this.Controls.Add(this.btnEliminarArticulo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.iIdlistaprecio);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.gcDetalle);
            this.Controls.Add(this.iIdsucursal);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaprecioActualizacionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizacion de Lista de Precios";
            this.Load += new System.EventHandler(this.ListaprecioActualizacionFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListaprecioActualizacionFrm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.iIdsucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riNumerico2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riFechaHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iIdlistaprecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rListaprecioincluyeimpuesto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdsucursal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        public DevExpress.XtraGrid.GridControl gcDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.SearchLookUpEdit iIdlistaprecio;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnEliminarArticulo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riNumerico2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riFechaHora;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreditodia1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreditodia2;
        private DevExpress.XtraEditors.CheckEdit rListaprecioincluyeimpuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcMargenCreditoOpcion1;
        private DevExpress.XtraGrid.Columns.GridColumn gcMargenCreditoOpcion2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;

    }
}