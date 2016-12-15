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
    public partial class SalidaalmacenMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();        
        public VwSalidaalmacendet VwSalidaalmacendetMnt { get; set; }
        public List<VwSalidaalmacendet> VwSalidaalmacendetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<VwArea> VwAreaList { get; set; }
        public List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }

        public List<VwSalidaalmacendet> VwSalidaalmacendetComponenteList { get; set; }
        public SalidaalmacenMntItemFrm(TipoMantenimiento tipoMnt, VwSalidaalmacendet vwSalidaalmacendetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSalidaalmacendetMnt = vwSalidaalmacendetMnt;
            

        }
        private void SalidaalmacenMntItemFrm_Load(object sender, EventArgs e)
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;
            }
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    iNumeroitem.EditValue = VwSalidaalmacendetMnt.Numeroitem;                    
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
            
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwSalidaalmacendetMnt.Numeroitem;
            iIdarticulo.EditValue = VwSalidaalmacendetMnt.Idarticulo;
            iEspecificacion.EditValue = VwSalidaalmacendetMnt.Especificacion;
            iCantidad.EditValue = VwSalidaalmacendetMnt.Cantidad;
            iPreciounitario.EditValue = VwSalidaalmacendetMnt.Preciounitario;
            iImportetotal.EditValue = VwSalidaalmacendetMnt.Importetotal;

            iIdproyecto.EditValue = VwSalidaalmacendetMnt.Idproyecto;
            iIdarea.EditValue = VwSalidaalmacendetMnt.Idarea;
            iIdcentrodecosto.EditValue = VwSalidaalmacendetMnt.Idcentrodecosto;
            nPorcentajepercepcion.EditValue = VwSalidaalmacendetMnt.Porcentajepercepcion;
            iIdtipoafectacionigv.EditValue = VwSalidaalmacendetMnt.Idtipoafectacionigv;
            iIdimpuesto.EditValue = VwSalidaalmacendetMnt.Idimpuesto;
            iCantidadutilizada.EditValue = VwSalidaalmacendetMnt.Cantidadutilizada;

        }
        private void CargarReferencias()
        {
            VwArticuloList = Service.GetAllVwArticulo("nombrearticulo,nombremarca");         

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

                    VwSalidaalmacendetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwSalidaalmacendetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwSalidaalmacendetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwSalidaalmacendetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwSalidaalmacendetMnt.Codigodebarra = iCodigodebarra.Text.Trim();
                    VwSalidaalmacendetMnt.Nombrearticulo = beArticulo.Text.Trim();
                    VwSalidaalmacendetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwSalidaalmacendetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwSalidaalmacendetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwSalidaalmacendetMnt.Abrunidadmedida = iUnidadmedida.Text.Trim();
                    VwSalidaalmacendetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwSalidaalmacendetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwSalidaalmacendetMnt.Preciounitario  = (decimal)iPreciounitario.EditValue;
                    VwSalidaalmacendetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwSalidaalmacendetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwSalidaalmacendetMnt.Idarea = (int)iIdarea.EditValue;
                    VwSalidaalmacendetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwSalidaalmacendetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwSalidaalmacendetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwSalidaalmacendetMnt.Cantidadutilizada = (decimal) iCantidadutilizada.EditValue;
                    VwSalidaalmacendetMnt.Cantidadadevolver = (decimal)rCantidadadevolver.EditValue;

                    if (VwSalidaalmacendetMnt.Idguiaremisiondet == null)
                    {
                        VwSalidaalmacendetMnt.Idguiaremisiondet = null;
                    }

                    //Los items por defecto se calculan
                    VwSalidaalmacendetMnt.Calcularitem = true;

                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwSalidaalmacendetMnt.Idarticulo);
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
            VwSalidaalmacendetComponenteList = new List<VwSalidaalmacendet>();

            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (VwArticulocompuesto item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwSalidaalmacendet vwSalidaalmacendet = new VwSalidaalmacendet();
                vwSalidaalmacendet.Numeroitem = numeroItem;
                vwSalidaalmacendet.Idarticulo = item.Idarticulodetalle;
                vwSalidaalmacendet.Codigoarticulo = item.Codigoarticulo;
                vwSalidaalmacendet.Codigoproveedor = item.Codigoproveedor;
                vwSalidaalmacendet.Codigodebarra = item.Codigodebarra;
                vwSalidaalmacendet.Nombrearticulo = item.Nombrearticulo;
                vwSalidaalmacendet.Nombremarca = item.Nombremarca;
                vwSalidaalmacendet.Idimpuesto = item.Idimpuesto;
                vwSalidaalmacendet.Idunidadmedida = item.Idunidadinventario;
                vwSalidaalmacendet.Abrunidadmedida = item.Abrunidadmedida;
                vwSalidaalmacendet.Especificacion = string.Empty;

                vwSalidaalmacendet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwSalidaalmacendet.Preciounitario = 0m;
                vwSalidaalmacendet.Importetotal = 0m;
                vwSalidaalmacendet.Idproyecto = (int)iIdproyecto.EditValue;
                vwSalidaalmacendet.Idarea = (int)iIdarea.EditValue;
                vwSalidaalmacendet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwSalidaalmacendet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                vwSalidaalmacendet.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;

                //Se estable a false no se calcula el item
                vwSalidaalmacendet.Calcularitem = false;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwSalidaalmacendet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwSalidaalmacendet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwSalidaalmacendet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwSalidaalmacendet.Lastmodified = DateTime.Now;
                        break;
                }

                VwSalidaalmacendetComponenteList.Add(vwSalidaalmacendet);
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
        private void SalidaalmacenMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal) iCantidad.EditValue;
            var precioUniatario = (decimal) iPreciounitario.EditValue;
            var importeTotal = Decimal.Round(cantidad * precioUniatario, 2);
            iImportetotal.EditValue = importeTotal;            
        }
        private void BuscarArticulo()
        {
            BuscadorArticuloFrm buscadorArticuloFrm = new BuscadorArticuloFrm
            (
                IdSucursalConsulta = IdSucursalConsulta,
                IdAlmacenConsulta = IdAlmacenConsulta,
                IdTipoListaConsulta = IdTipoListaConsulta
            );
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                //Asignar al edit value del campo id foraneo               
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Idarticulo;
            }
            else
            {
                beArticulo.Select();
            }
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
                iCodigodebarra.EditValue = VwArticuloSel.Codigodebarra;
                beArticulo.Text = VwArticuloSel.Nombrearticulo.Trim();
                iMarcaarticulo.EditValue = VwArticuloSel.Nombremarca;
                iIdimpuesto.EditValue = VwArticuloSel.Idimpuesto;
                iUnidadmedida.EditValue = VwArticuloSel.Abrunidadmedida;
                iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
                iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
                nPorcentajepercepcion.EditValue = VwArticuloSel.Aplicapercepcion ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;
                iEspecificacion.Text = VwArticuloSel.Caracteristicas;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                iCodigodebarra.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iIdtipoafectacionigv.EditValue = null;
                nPorcentajepercepcion.EditValue = 0m;
                iUnidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
            }  
        }
        private void iCantidadutilizada_EditValueChanged(object sender, EventArgs e)
        {
            rCantidadadevolver.EditValue = (decimal)iCantidad.EditValue - (decimal)iCantidadutilizada.EditValue;
        }

    }
}