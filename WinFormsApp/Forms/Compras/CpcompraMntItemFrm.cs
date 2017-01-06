using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class CpcompraMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwCpcompradet VwCpcompradetMnt { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }

        public VwArticulo VwArticuloSel { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }

        public int IdCentroDeCostoPorDefecto { get; set; }
        public int IdProyectoPorDefecto { get; set; }
        public int IdAreaPorDefecto { get; set; }
        public List<VwCpcompradet> VwCpcompradetComponenteList { get; set; }

        public CpcompraMntItemFrm(TipoMantenimiento tipoMnt, VwCpcompradet vwCpcompradet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCpcompradetMnt = vwCpcompradet;

        }

        private void CpcompraMntItemFrm_Load(object sender, EventArgs e)
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
                    CargarReferencias();
                    ValoresPorDefecto();
                    BuscarArticulo();
                    
                    iCantidad.Select();

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            beArticulo.Select();
        }

        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwCpcompradetMnt.Numeroitem;

            ////Centro de costo por defecto
            if (IdCentroDeCostoPorDefecto > 0)
            {
                iIdcentrodecosto.EditValue = IdCentroDeCostoPorDefecto;
            }
            ////Proyecto por defecto
            if (IdProyectoPorDefecto > 0)
            {
                iIdproyecto.EditValue = IdProyectoPorDefecto;
            }
            ////Area por defecto
            if (IdAreaPorDefecto > 0)
            {
                iIdarea.EditValue = IdAreaPorDefecto;
            }
        }

        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwCpcompradetMnt.Numeroitem;
            iIdarticulo.EditValue = VwCpcompradetMnt.Idarticulo;
            iIdcentrodecosto.EditValue = VwCpcompradetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwCpcompradetMnt.Idarea;
            iIdproyecto.EditValue = VwCpcompradetMnt.Idproyecto;
            iEspecificacion.EditValue = VwCpcompradetMnt.Especificacion;
            iCantidad.EditValue = VwCpcompradetMnt.Cantidad;
            iPreciounitario.EditValue = VwCpcompradetMnt.Preciounitario;
            iImportetotal.EditValue = VwCpcompradetMnt.Importetotal;


        }

        private void CargarReferencias()
        {
            VwArticuloList = Service.GetAllVwArticulo("nombrearticulo,nombremarca");


            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("nombreunidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = Service.GetAllImpuesto("nombreimpuesto");
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereCentroCosto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwCentrodecostoList = Service.GetAllVwCentrodecosto(whereCentroCosto, "descripcioncentrodecosto");
            iIdcentrodecosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            string whereArea = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwAreaList = Service.GetAllVwArea(whereArea, "Codigoarea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            string whereProyecto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwProyectoList = Service.GetAllVwProyecto(whereProyecto, "codigoproyecto");
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;


            TipoafectacionigvList = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DataSource = TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;


                    VwCpcompradetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwCpcompradetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwCpcompradetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwCpcompradetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwCpcompradetMnt.Idunidadinventario = (int)iIdunidadmedida.EditValue;
                    VwCpcompradetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwCpcompradetMnt.Nombrearticulo = beArticulo.Text.Trim();
                    VwCpcompradetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwCpcompradetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwCpcompradetMnt.Abrunidadmedida = iIdunidadmedida.Text.Trim();
                    VwCpcompradetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwCpcompradetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwCpcompradetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
                    VwCpcompradetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
                    VwCpcompradetMnt.Descuento3 = (decimal)iDescuento3.EditValue;
                    VwCpcompradetMnt.Descuento4 = (decimal)iDescuento4.EditValue;
                    VwCpcompradetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
                    VwCpcompradetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwCpcompradetMnt.Pesounitario = (decimal)rPesoarticulo.EditValue;
                    VwCpcompradetMnt.Pesototal = VwCpcompradetMnt.Cantidad * VwCpcompradetMnt.Pesounitario;

                    VwCpcompradetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;

                    VwCpcompradetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwCpcompradetMnt.Gravado = VwArticuloSel.Gravado;
                    VwCpcompradetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwCpcompradetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwCpcompradetMnt.Exportacion = VwArticuloSel.Exportacion;

                    VwCpcompradetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwCpcompradetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwCpcompradetMnt.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
                    VwCpcompradetMnt.Idarea = (int)iIdarea.EditValue;
                    VwCpcompradetMnt.Nombrearea = iIdarea.Text.Trim();
                    VwCpcompradetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwCpcompradetMnt.Nombreproyecto = iIdproyecto.Text.Trim();

                    //Los items por defecto se calculan
                    VwCpcompradetMnt.Calcularitem = true;

                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwCpcompradetMnt.Idarticulo);
                    }

                    if (VwCpcompradetMnt.Idordencompradet == null)
                    {
                        VwCpcompradetMnt.Idordencompradet = null;
                        VwCpcompradetMnt.Serienumeroorden = string.Empty;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwCpcompradetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwCpcompradetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwCpcompradetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwCpcompradetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwCpcompradetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwCpcompradetMnt.DataEntityState = DataEntityState.Modified;                            
                            break;
                    }
                                        
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void AsignarDetalleDeArticulosCompuestos(int idarticulo)
        {
            VwCpcompradetComponenteList = new List<VwCpcompradet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwCpcompradet vwCpcompradet = new VwCpcompradet();
                vwCpcompradet.Numeroitem = numeroItem;
                vwCpcompradet.Idarticulo = item.Idarticulodetalle;
                vwCpcompradet.Codigoarticulo = item.Codigoarticulo;
                vwCpcompradet.Codigoproveedor = item.Codigoproveedor;
                vwCpcompradet.Idunidadinventario = item.Idunidadinventario;
                vwCpcompradet.Nombremarca = item.Nombremarca;
                vwCpcompradet.Nombrearticulo = item.Nombrearticulo;
                vwCpcompradet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwCpcompradet.Idunidadmedida = item.Idunidadinventario;
                vwCpcompradet.Abrunidadmedida = item.Abrunidadmedida;
                vwCpcompradet.Preciounitario = 0m;
                vwCpcompradet.Especificacion = string.Empty;
                vwCpcompradet.Descuento1 = 0m;
                vwCpcompradet.Descuento2 = 0m;
                vwCpcompradet.Descuento3 = 0m;
                vwCpcompradet.Descuento4 = 0m;
                vwCpcompradet.Preciounitarioneto = 0m;
                vwCpcompradet.Importetotal = 0m;
                vwCpcompradet.Pesounitario = 0m;
                vwCpcompradet.Pesototal = 0m;

                vwCpcompradet.Idimpuesto = item.Idimpuesto;

                vwCpcompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwCpcompradet.Gravado = item.Gravado;
                vwCpcompradet.Exonerado = item.Exonerado;
                vwCpcompradet.Inafecto = item.Inafecto;
                vwCpcompradet.Exportacion = item.Exportacion;

                vwCpcompradet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwCpcompradet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwCpcompradet.Porcentajepercepcion = (decimal)iPorcentajepercepcion.EditValue;
                vwCpcompradet.Idarea = (int)iIdarea.EditValue;
                vwCpcompradet.Nombrearea = iIdarea.Text.Trim();
                vwCpcompradet.Idproyecto = (int)iIdproyecto.EditValue;
                vwCpcompradet.Nombreproyecto = iIdproyecto.Text.Trim();

                //Se estable a false no se calcula el item
                vwCpcompradet.Calcularitem = false;

                if (vwCpcompradet.Idordencompradet == null)
                {
                    vwCpcompradet.Idordencompradet = null;
                    vwCpcompradet.Serienumeroorden = string.Empty;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCpcompradet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwCpcompradet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCpcompradet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwCpcompradet.Lastmodified = DateTime.Now;
                        break;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCpcompradet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCpcompradet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                VwCpcompradetComponenteList.Add(vwCpcompradet);
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

        private void CpcompraMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal)iCantidad.EditValue;
            var precioUniatario = (decimal)iPreciounitario.EditValue;
            var descuento1 = (decimal)iDescuento1.EditValue;
            var descuento2 = (decimal)iDescuento2.EditValue;
            var descuento3 = (decimal)iDescuento3.EditValue;
            var descuento4 = (decimal)iDescuento4.EditValue;

            var preciounitarioneto = Decimal.Round(precioUniatario
                * (1 - descuento1 / 100)
                * (1 - descuento2 / 100)
                * (1 - descuento3 / 100)
                * (1 - descuento4 / 100), 4);

            var importeTotal = Decimal.Round(cantidad * preciounitarioneto, 2);

            iPreciounitarioneto.EditValue = preciounitarioneto;
            iImportetotal.EditValue = importeTotal;
        }

        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ArticuloMntFrm articuloMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
                    break;
                case 1: //Nuevo registro
                    articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    articuloMntFrm.ShowDialog();

                    if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                    {
                        iIdarticulo.EditValue = 0;
                        iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idArticuloMnt = iIdarticulo.EditValue;
                    if (idArticuloMnt != null && (int)idArticuloMnt > 0)
                    {
                        articuloMntFrm = new ArticuloMntFrm((int)idArticuloMnt, TipoMantenimiento.Modificar, null, null);
                        articuloMntFrm.ShowDialog();
                        if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                        {
                            iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }       
        }

        private void BuscarArticulo()
        {
            //var buscadorArticuloFrm = new BuscadorArticuloFrmBase();
            var buscadorArticuloFrm = new BuscadorArticuloUnidadFrm();
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidad != null)
            {
                //Asignar al edit value del campo id foraneo
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticulounidad.Idarticulo;
                iIdunidadmedida.EditValue = buscadorArticuloFrm.VwArticulounidad.Idunidadinventario;

            }
        }

        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;

            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            VwArticuloSel = Service.GetVwArticulo(((int)idArticuloSel));
            if (VwArticuloSel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = VwArticuloSel.Codigoarticulo;
                iCodigoproveedor.EditValue = VwArticuloSel.Codigoproveedor;
                beArticulo.Text = VwArticuloSel.Nombrearticulo.Trim();
                iMarcaarticulo.EditValue = VwArticuloSel.Nombremarca;
                iIdimpuesto.EditValue = VwArticuloSel.Idimpuesto;
                iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
                rPesoarticulo.EditValue = VwArticuloSel.Pesoarticulo;
                iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                rPesoarticulo.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;
            }           
        }
    }
}