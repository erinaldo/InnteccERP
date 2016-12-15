using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class CpCompraDetSerieMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwCpcompradet VwCpcompradet { get; set; }
        public List<VwInventariostock> VwInventariostockList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwCpcompradetserie> VwCpcompradetserieList { get; set; }
        public string UbicacionSeleccionada { get; set; }
        public CpCompraDetSerieMntFrm(TipoMantenimiento tipoMnt, VwCpcompradet vwCpcompradet, string ubicacionSeleccionada)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCpcompradet = vwCpcompradet;
            UbicacionSeleccionada = ubicacionSeleccionada;
            IdEntidadMnt = vwCpcompradet.Idcpcompradet;


        }
        private void CpCompraDetSerieMntFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    rUbicacion.EditValue = UbicacionSeleccionada;
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:
                    rUbicacion.EditValue = UbicacionSeleccionada;
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }
        }

        private void CargarDetalle()
        {
            Cursor = Cursors.WaitCursor;
            gcDetalle.BeginUpdate();
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idcpcompradet = '{0}'", IdEntidadMnt);

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwCpcompradetserieList = new List<VwCpcompradetserie>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwCpcompradetserieList = Service.GetAllVwCpcompradetserie(where, "idcpcompradetserie");
                    break;
            }

            gcDetalle.DataSource = VwCpcompradetserieList;
            gcDetalle.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
           
            iIdcpcompradet.EditValue = VwCpcompradet.Idcpcompradet;
            iCodigoarticulo.EditValue = VwCpcompradet.Codigoarticulo;
            iCodigoproveedor.EditValue = VwCpcompradet.Codigoproveedor;
            iCodigodebarra.EditValue = VwCpcompradet.Codigodebarra;
            beArticulo.EditValue = VwCpcompradet.Nombrearticulo;
            iMarcaarticulo.EditValue = VwCpcompradet.Nombremarca;
            iAbrunidad.EditValue = VwCpcompradet.Abrunidadmedida;

        }
        private void CargarDatosForaneos()
        {


           

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    
                    //VwCpcompradet.Idcpcompradet = (int)iIdcpcompradet.EditValue;
                    //VwCpcompradet.Codigoarticulo = (string) iCodigoarticulo.EditValue;
                    //VwCpcompradet.Nombrearticulo = beArticulo.Text.Trim();
                    //VwCpcompradet.Abrunidadmedida = iAbrunidad.Text.Trim();
                    //VwCpcompradet.Nombremarca = iMarcaarticulo.Text.Trim();


                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                        //    VwInventariostock.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //    VwInventariostock.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                        //    VwInventariostock.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //    VwInventariostock.Lastmodified = DateTime.Now;
                           break;
                    }

                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpProducto, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void CpCompraDetSerieMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void bmSeries_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            CpCompraDetSerieMntItemDinamicoFrm cpCompraDetSerieMntItemDinamicoFrm;
            VwCpcompradetserie vwCpcompradetserie;
            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }


                    vwCpcompradetserie = new VwCpcompradetserie();

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    cpCompraDetSerieMntItemDinamicoFrm = new CpCompraDetSerieMntItemDinamicoFrm(tipoMantenimientoItem, VwCpcompradet, vwCpcompradetserie);
                    cpCompraDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (cpCompraDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Cpcompradetserie cpcompradetserie = AsignarCpCompraDetSerie(vwCpcompradetserie);
                        int idinventariostockdetserie = Service.SaveCpcompradetserie(cpcompradetserie);
                        if (idinventariostockdetserie > 0)
                        {
                            vwCpcompradetserie.Idcpcompradetserie = idinventariostockdetserie;
                            VwCpcompradetserieList.Add(vwCpcompradetserie);
                            ActualizarDetalle();
                            if (!gvDetalle.IsLastRow)
                            {
                                gvDetalle.MoveLastVisible();
                                gvDetalle.Focus();
                            }
                        }
                    }
                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    vwCpcompradetserie = (VwCpcompradetserie) gvDetalle.GetFocusedRow();
                    cpCompraDetSerieMntItemDinamicoFrm = new CpCompraDetSerieMntItemDinamicoFrm(TipoMantenimiento.Modificar, VwCpcompradet, vwCpcompradetserie);
                    cpCompraDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (cpCompraDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Cpcompradetserie cpcompradetserie = AsignarCpCompraDetSerie(vwCpcompradetserie);
                        if (cpcompradetserie.Idcpcompradetserie > 0)
                        {
                            Service.UpdateCpcompradetserie(cpcompradetserie);
                            ActualizarDetalle();
                        }
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwCpcompradetserie = (VwCpcompradetserie)gvDetalle.GetFocusedRow();
                        if (vwCpcompradetserie != null && vwCpcompradetserie.Idcpcompradetserie> 0)
                        {
                            Service.DeleteInventariostockdetserie(vwCpcompradetserie.Idcpcompradetserie);
                            vwCpcompradetserie.DataEntityState = DataEntityState.Deleted;
                            if (!gvDetalle.IsFirstRow)
                            {
                                gvDetalle.MovePrev();
                            }
                            ActualizarDetalle();
                        }
                    }
                    break;
            }
        }

        private void ActualizarDetalle()
        {
            gvDetalle.BeginUpdate();
            gvDetalle.RefreshData();
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        private Cpcompradetserie AsignarCpCompraDetSerie(VwCpcompradetserie vwCpcompradetserie)
        {
            Cpcompradetserie cpcompradetserie = new Cpcompradetserie();
            cpcompradetserie.Idcpcompradetserie = vwCpcompradetserie.Idcpcompradetserie;
            cpcompradetserie.Idcpcompradet = vwCpcompradetserie.Idcpcompradet;
            cpcompradetserie.Idseriearticulo = vwCpcompradetserie.Idseriearticulo;
            return cpcompradetserie;
        }
    }
}