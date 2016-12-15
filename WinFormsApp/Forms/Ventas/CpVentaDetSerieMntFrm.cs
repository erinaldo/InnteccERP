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
    public partial class CpVentaDetSerieMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwCpventadet VwCpventadet { get; set; }
        public List<VwInventariostock> VwInventariostockList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwCpventadetserie> VwCpventadetserieList { get; set; }
        public string UbicacionSeleccionada { get; set; }
        public CpVentaDetSerieMntFrm(TipoMantenimiento tipoMnt, VwCpventadet vwCpventadet, string ubicacionSeleccionada)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCpventadet = vwCpventadet;
            UbicacionSeleccionada = ubicacionSeleccionada;
            IdEntidadMnt = vwCpventadet.Idcpventadet;


        }
        private void CpVentaDetSerieMntFrm_Load(object sender, EventArgs e)
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
            string where = string.Format("idcpventadet = '{0}'", IdEntidadMnt);

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwCpventadetserieList = new List<VwCpventadetserie>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwCpventadetserieList = Service.GetAllVwCpventadetserie(where, "idcpventadetserie");
                    break;
            }

            gcDetalle.DataSource = VwCpventadetserieList;
            gcDetalle.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {

            iIdcpventadet.EditValue = VwCpventadet.Idcpventadet;
            iCodigoarticulo.EditValue = VwCpventadet.Codigoarticulo;
            iCodigoproveedor.EditValue = VwCpventadet.Codigoproveedor;
            iCodigodebarra.EditValue = VwCpventadet.Codigodebarra;
            beArticulo.EditValue = VwCpventadet.Nombrearticulo;
            iMarcaarticulo.EditValue = VwCpventadet.Nombremarca;
            iAbrunidad.EditValue = VwCpventadet.Abrunidadmedida;

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


                    //VwCpventadet.Idcpventadet = (int)iIdcpventadet.EditValue;
                    //VwCpventadet.Codigoarticulo = (string)iCodigoarticulo.EditValue;
                    //VwCpventadet.Nombrearticulo = beArticulo.Text.Trim();
                    //VwCpventadet.Abrunidadmedida = iAbrunidad.Text.Trim();
                    //VwCpventadet.Nombremarca = iMarcaarticulo.Text.Trim();


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
        private void CpVentaDetSerieMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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


            CpVentaDetSerieMntItemDinamicoFrm cpCompraDetSerieMntItemDinamicoFrm;
            VwCpventadetserie vwCpventadetserie;
            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }


                    vwCpventadetserie = new VwCpventadetserie();


                    cpCompraDetSerieMntItemDinamicoFrm = new CpVentaDetSerieMntItemDinamicoFrm(TipoMantenimiento.Nuevo, VwCpventadet, vwCpventadetserie);
                    cpCompraDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (cpCompraDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Cpventadetserie cpventadetserie = AsignarCpVentaDetSerie(vwCpventadetserie);
                        int idinventariostockdetserie = Service.SaveCpventadetserie(cpventadetserie);
                        if (idinventariostockdetserie > 0)
                        {
                            vwCpventadetserie.Idcpventadetserie = idinventariostockdetserie;
                            VwCpventadetserieList.Add(vwCpventadetserie);
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

                    vwCpventadetserie = (VwCpventadetserie) gvDetalle.GetFocusedRow();
                    cpCompraDetSerieMntItemDinamicoFrm = new CpVentaDetSerieMntItemDinamicoFrm(TipoMantenimiento.Modificar, VwCpventadet, vwCpventadetserie);
                    cpCompraDetSerieMntItemDinamicoFrm.ShowDialog();

                    if (cpCompraDetSerieMntItemDinamicoFrm.DialogResult == DialogResult.OK)
                    {
                        Cpventadetserie cpventadetserie = AsignarCpVentaDetSerie(vwCpventadetserie);
                        if (cpventadetserie.Idcpventadetserie > 0)
                        {
                            Service.UpdateCpventadetserie(cpventadetserie);
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
                        vwCpventadetserie = (VwCpventadetserie)gvDetalle.GetFocusedRow();
                        if (vwCpventadetserie != null && vwCpventadetserie.Idcpventadetserie> 0)
                        {
                            Service.DeleteCpventadetserie(vwCpventadetserie.Idcpventadetserie);
                            if (vwCpventadetserie.Idseriearticulo > 0)
                            {
                                if (Service.EstablecerSerieUtilizada(vwCpventadetserie.Idseriearticulo, false))
                                {
                                    vwCpventadetserie.Serieutilizada = false;
                                }

                            }

                            vwCpventadetserie.DataEntityState = DataEntityState.Deleted;
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
            //gvDetalle.BestFitColumns(true);
        }

        private Cpventadetserie AsignarCpVentaDetSerie(VwCpventadetserie vwCpventadetserie)
        {
            Cpventadetserie cpventadetserie = new Cpventadetserie();
            cpventadetserie.Idcpventadetserie = vwCpventadetserie.Idcpventadetserie;
            cpventadetserie.Idcpventadet = vwCpventadetserie.Idcpventadet;
            cpventadetserie.Idseriearticulo = vwCpventadetserie.Idseriearticulo;
            return cpventadetserie;
        }
    }
}