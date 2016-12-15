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
    public partial class EntradaalmacenMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwEntradaalmacendet VwEntradaalmacendetMnt { get; set; }
        public List<VwEntradaalmacendet> VwEntradaalmacendetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<VwArea> VwAreaList { get; set; }
        public List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public List<VwEntradaalmacendet> VwEntradaalmacendetComponenteList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }        
        public EntradaalmacenMntItemFrm(TipoMantenimiento tipoMnt, VwEntradaalmacendet vwEntradaalmacendetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwEntradaalmacendetMnt = vwEntradaalmacendetMnt;

         
        }
        private void EntradaalmacenMntItemFrm_Load(object sender, EventArgs e)
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
                    iNumeroitem.EditValue = VwEntradaalmacendetMnt.Numeroitem;
                    BuscarArticulo();
                    iCantidad.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwEntradaalmacendetMnt.Numeroitem;
            iIdarticulo.EditValue = VwEntradaalmacendetMnt.Idarticulo;
            iEspecificacion.EditValue = VwEntradaalmacendetMnt.Especificacion;
            iCantidad.EditValue = VwEntradaalmacendetMnt.Cantidad;
            iPreciounitario.EditValue = VwEntradaalmacendetMnt.Preciounitario;
            iImportetotal.EditValue = VwEntradaalmacendetMnt.Importetotal;

            iIdproyecto.EditValue = VwEntradaalmacendetMnt.Idproyecto;
            iIdarea.EditValue = VwEntradaalmacendetMnt.Idarea;
            iIdcentrodecosto.EditValue = VwEntradaalmacendetMnt.Idcentrodecosto;
            nPorcentajepercepcion.EditValue = VwEntradaalmacendetMnt.Porcentajepercepcion;
            iIdtipoafectacionigv.EditValue = VwEntradaalmacendetMnt.Idtipoafectacionigv;
            iIdimpuesto.EditValue = VwEntradaalmacendetMnt.Idimpuesto;
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

                    VwEntradaalmacendetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwEntradaalmacendetMnt.Idarticulo = (int)iIdarticulo.EditValue;
                    VwEntradaalmacendetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwEntradaalmacendetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwEntradaalmacendetMnt.Codigodebarra = iCodigodebarra.Text.Trim();
                    VwEntradaalmacendetMnt.Nombrearticulo = beArticulo.Text.Trim();
                    VwEntradaalmacendetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwEntradaalmacendetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwEntradaalmacendetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwEntradaalmacendetMnt.Abrunidadmedida = iUnidadmedida.Text.Trim();
                    VwEntradaalmacendetMnt.Especificacion = iEspecificacion.Text.Trim();
                    VwEntradaalmacendetMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwEntradaalmacendetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwEntradaalmacendetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwEntradaalmacendetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwEntradaalmacendetMnt.Idarea = (int)iIdarea.EditValue;
                    VwEntradaalmacendetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwEntradaalmacendetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwEntradaalmacendetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;

                    VwEntradaalmacendetMnt.Gravado = VwArticuloSel.Gravado;
                    VwEntradaalmacendetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwEntradaalmacendetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwEntradaalmacendetMnt.Exportacion = VwArticuloSel.Exportacion;

                    if (VwEntradaalmacendetMnt.Idordencompradet == null)
                    {
                        VwEntradaalmacendetMnt.Idordencompradet = null;
                    }

                    //Los items por defecto se calculan
                    VwEntradaalmacendetMnt.Calcularitem = true;

                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwEntradaalmacendetMnt.Idarticulo);
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

            VwEntradaalmacendetComponenteList = new List<VwEntradaalmacendet>();

            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (VwArticulocompuesto item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwEntradaalmacendet vwEntradaalmacendet = new VwEntradaalmacendet();
                vwEntradaalmacendet.Numeroitem = numeroItem;
                vwEntradaalmacendet.Idarticulo = item.Idarticulodetalle;
                vwEntradaalmacendet.Codigoarticulo = item.Codigoarticulo;
                vwEntradaalmacendet.Codigoproveedor = item.Codigoproveedor;
                vwEntradaalmacendet.Codigodebarra = item.Codigodebarra;
                vwEntradaalmacendet.Nombrearticulo = item.Nombrearticulo;
                vwEntradaalmacendet.Nombremarca = item.Nombremarca;
                vwEntradaalmacendet.Idimpuesto = item.Idimpuesto;
                vwEntradaalmacendet.Idunidadmedida = item.Idunidadinventario;
                vwEntradaalmacendet.Abrunidadmedida = item.Abrunidadmedida;
                vwEntradaalmacendet.Especificacion = string.Empty;

                vwEntradaalmacendet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwEntradaalmacendet.Preciounitario = 0m;
                vwEntradaalmacendet.Importetotal = 0m;
                vwEntradaalmacendet.Idproyecto = (int)iIdproyecto.EditValue;
                vwEntradaalmacendet.Idarea = (int)iIdarea.EditValue;
                vwEntradaalmacendet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwEntradaalmacendet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                vwEntradaalmacendet.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;

                //Se estable a false no se calcula el item
                vwEntradaalmacendet.Calcularitem = false;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwEntradaalmacendet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwEntradaalmacendet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwEntradaalmacendet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwEntradaalmacendet.Lastmodified = DateTime.Now;
                        break;
                }

                VwEntradaalmacendetComponenteList.Add(vwEntradaalmacendet);
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
        private void EntradaalmacenMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}