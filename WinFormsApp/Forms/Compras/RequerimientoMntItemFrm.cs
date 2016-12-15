using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class RequerimientoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRequerimientodet VwRequerimientodet { get; set; }
        public List<Centrodecosto> CentrodecostoList { get; private set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public int IdCentroDeCostoPorDefecto { get; set; }
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public VwCptooperacion VwCptooperacionSel { get; set; }
        public List<VwRequerimientodet> VwRequerimientoComponenteList { get; set; }
        public RequerimientoMntItemFrm(TipoMantenimiento tipoMnt, VwRequerimientodet vwRequerimientodet, List<VwRequerimientodet> vwRequerimientodetList)
        {

            InitializeComponent();
            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwRequerimientodet = vwRequerimientodet;
            VwRequerimientodetList = vwRequerimientodetList;
        }
        private void RequerimientoMntItemFrm_Load(object sender, EventArgs e)
        {
            if (IdSucursalConsulta <= 0)
            {
                throw new ArgumentException("El valor IdSucursalConsulta debe contener un valor valido.");
            }

            if (IdAlmacenConsulta <= 0)
            {
                throw new ArgumentException("El valor IdAlmacenConsulta debe contener un valor valido.");
            }

            if (IdTipoListaConsulta <= 0)
            {
                throw new ArgumentException("El valor IdTipoListaConsulta debe contener un valor valido.");
            }

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
            BringToFront();
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    BuscarArticulo();
                    iIdcentrodecosto.Select();
                    //iCantidad.Select();

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
            iNumeroitem.EditValue = VwRequerimientodet.Numeroitem;
            //Centro de costo por defecto
            //if (CentrodecostoList != null && CentrodecostoList.Count == 1)
            //{
            //    Centrodecosto centrodecostoPorDefecto = CentrodecostoList.FirstOrDefault();
            //    if (centrodecostoPorDefecto != null)
            //        iIdcentrodecosto.EditValue = centrodecostoPorDefecto.Idcentrodecosto;
            //}
            if (IdCentroDeCostoPorDefecto > 0)
            {
                iIdcentrodecosto.EditValue = IdCentroDeCostoPorDefecto;
            }
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwRequerimientodet.Numeroitem;
            iIdarticulo.EditValue = VwRequerimientodet.Idarticulo;

            iCodigoarticulo.EditValue = VwRequerimientodet.Codigoarticulo;
            iCodigoproveedor.EditValue = VwRequerimientodet.Codigoproveedor;
            iCodigodebarra.EditValue = VwRequerimientodet.Codigodebarra;
            beArticulo.Text = VwRequerimientodet.Nombrearticulo.Trim();
            iMarcaarticulo.EditValue = VwRequerimientodet.Nombremarca;
            iAbrunidadmedida.EditValue = VwRequerimientodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwRequerimientodet.Idunidadmedida;
            iGravado.EditValue = VwRequerimientodet.Gravado;
            iExonerado.EditValue = VwRequerimientodet.Exonerado;
            iInafecto.EditValue = VwRequerimientodet.Inafecto;
            iExportacion.EditValue = VwRequerimientodet.Exportacion;
            
            //
            iCalcularitem.EditValue = VwRequerimientodet.Calcularitem;

            nPorcentajepercepcion.EditValue = VwRequerimientodet.Porcentajepercepcion;
            iIdtipoafectacionigv.EditValue = VwRequerimientodet.Idtipoafectacionigv;
            iIdimpuesto.EditValue = VwRequerimientodet.Idimpuesto;
            iAbrunidadmedida.EditValue = VwRequerimientodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwRequerimientodet.Idunidadmedida;

            iIdcentrodecosto.EditValue = VwRequerimientodet.Idcentrodecosto;
            iEspecificacion.EditValue = VwRequerimientodet.Especificacion;
            iCantidad.EditValue = VwRequerimientodet.Cantidad;
            iPreciounitario.EditValue = VwRequerimientodet.Preciounitario;
            iImportetotal.EditValue = VwRequerimientodet.Importetotal;
            iIdunidadmedida.EditValue = VwRequerimientodet.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwRequerimientodet.Abrunidadmedida;
            iIdtipoafectacionigv.EditValue = VwRequerimientodet.Idtipoafectacionigv;
            iStock.EditValue = VwRequerimientodet.Stock;
        }
        private void CargarReferencias()
        {
            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            CentrodecostoList = CacheObjects.CentrodecostoList.Where(x => x.Idempresa == SessionApp.SucursalSel.Idsucursal).ToList();
            iIdcentrodecosto.Properties.DataSource = CentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

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


                    VwRequerimientodet.Numeroitem = (int)iNumeroitem.EditValue;
                    VwRequerimientodet.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwRequerimientodet.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwRequerimientodet.Nombrearticulo = beArticulo.Text.Trim();
                    VwRequerimientodet.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwRequerimientodet.Cantidad = (decimal)iCantidad.EditValue;
                    VwRequerimientodet.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwRequerimientodet.Importetotal = (decimal)iImportetotal.EditValue;
                    VwRequerimientodet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwRequerimientodet.Especificacion = iEspecificacion.Text.Trim();
                    VwRequerimientodet.Idarticulo = (int?)iIdarticulo.EditValue;
                    VwRequerimientodet.Idimpuesto = (int?)iIdimpuesto.EditValue;
                    VwRequerimientodet.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwRequerimientodet.Abrunidadmedida = iAbrunidadmedida.Text.Trim();
                    VwRequerimientodet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    Centrodecosto centroDeCostoSel = CentrodecostoList.FirstOrDefault(x => x.Idcentrodecosto == VwRequerimientodet.Idcentrodecosto);
                    VwRequerimientodet.Codigocentrodecosto = centroDeCostoSel == null ? string.Empty : centroDeCostoSel.Codigocentrodecosto;
                    VwRequerimientodet.Cantidadinicial = VwRequerimientodet.Cantidad;
                    VwRequerimientodet.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwRequerimientodet.Gravado = (bool)iGravado.EditValue;
                    VwRequerimientodet.Exonerado = (bool)iExonerado.EditValue;
                    VwRequerimientodet.Inafecto = (bool)iInafecto.EditValue;
                    VwRequerimientodet.Exportacion = (bool)iExportacion.EditValue;
                    VwRequerimientodet.Aprobado = true;
                    VwRequerimientodet.Stock = (decimal)iStock.EditValue;
                    VwRequerimientodet.Porcentajepercepcion = (decimal) nPorcentajepercepcion.EditValue;


                    //Los items por defecto se calculan
                    VwRequerimientodet.Calcularitem = (bool)iCalcularitem.EditValue;

                    //Si es un articulo compuesto agregar detalle
                    if ((bool)iCalcularitem.EditValue)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwRequerimientodet.Idarticulo);
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwRequerimientodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwRequerimientodet.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwRequerimientodet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwRequerimientodet.Lastmodified = DateTime.Now;
                            break;
                    }

                    if (TipoMnt == TipoMantenimiento.Nuevo)
                    {
                        int cantReferenciasItem = VwRequerimientodetList.Count(x => x.Idarticulo == VwRequerimientodet.Idarticulo
                            && x.Idunidadmedida == VwRequerimientodet.Idunidadmedida
                            && x.DataEntityState != DataEntityState.Deleted);

                        if (cantReferenciasItem > 0)
                        {
                            string mensaje = string.Format("El articulo {0} ya fue agregado ¿Desea continuar?",
                                VwRequerimientodet.Nombrearticulo);
                            if (DialogResult.No == XtraMessageBox.Show(mensaje,
                                Resources.titPregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2))
                            {
                                return;
                            }
                        }
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwRequerimientodet.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwRequerimientodet.DataEntityState = DataEntityState.Modified;                            
                            break;
                    }
                                        
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private void AsignarDetalleDeArticulosCompuestos(int? idarticulo)
        {
            VwRequerimientoComponenteList = new List<VwRequerimientodet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwRequerimientodet vwRequerimientodet = new VwRequerimientodet();
                vwRequerimientodet.Numeroitem = numeroItem;
                vwRequerimientodet.Codigoarticulo = item.Codigoarticulo;
                vwRequerimientodet.Codigoproveedor = item.Codigoproveedor;
                vwRequerimientodet.Nombrearticulo = item.Nombrearticulo;
                vwRequerimientodet.Nombremarca = item.Nombremarca;
                vwRequerimientodet.Cantidad = item.Cantidaddetalle * (decimal) iCantidad.EditValue;
                vwRequerimientodet.Preciounitario = 0m;
                vwRequerimientodet.Importetotal = 0m;
                vwRequerimientodet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwRequerimientodet.Especificacion = string.Empty;
                vwRequerimientodet.Idarticulo = item.Idarticulodetalle;
                vwRequerimientodet.Idimpuesto = item.Idimpuesto;
                vwRequerimientodet.Idunidadmedida = item.Idunidadinventario;
                vwRequerimientodet.Abrunidadmedida = item.Abrunidadmedida;
                vwRequerimientodet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;

                Centrodecosto centroDeCostoSel = CentrodecostoList.FirstOrDefault(x => x.Idcentrodecosto == VwRequerimientodet.Idcentrodecosto);
                VwRequerimientodet.Codigocentrodecosto = centroDeCostoSel == null ? string.Empty : centroDeCostoSel.Codigocentrodecosto;

                vwRequerimientodet.Cantidadinicial = item.Cantidaddetalle;
                vwRequerimientodet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwRequerimientodet.Gravado = item.Gravado;
                vwRequerimientodet.Exonerado = item.Exonerado;
                vwRequerimientodet.Inafecto = item.Inafecto;
                vwRequerimientodet.Exportacion = item.Exportacion;
                vwRequerimientodet.Aprobado = true;
                vwRequerimientodet.Stock = 0m;//(decimal)iStock.EditValue;

                //Se estable a false no se calcula el item
                vwRequerimientodet.Calcularitem = false;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwRequerimientodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwRequerimientodet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwRequerimientodet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwRequerimientodet.Lastmodified = DateTime.Now;
                        break;
                }


                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwRequerimientodet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwRequerimientodet.DataEntityState = DataEntityState.Modified;
                        break;
                }
                VwRequerimientoComponenteList.Add(vwRequerimientodet);
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

            
            if (VwCptooperacionSel.Validarvalorunitario && (decimal)iPreciounitario.EditValue <= 0m)
            {
                XtraMessageBox.Show("Ingrese un valor valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iPreciounitario.Select();
                return false;
            }

            if (VwCptooperacionSel.Validarstock && ( (decimal)iStock.EditValue - (decimal)iCantidad.EditValue < 0))
            {
                XtraMessageBox.Show("No hay stock", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iCantidad.Select();
                return false;
            }
            return true;
        }
        private void RequerimientoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CargarDatosArticuloSeleccionado(VwArticulounidad vwArticulounidad)
        {
          
            if (vwArticulounidad != null)
            {
                //Cargar datos a controles
                iIdarticulo.EditValue = vwArticulounidad.Idarticulo;                
                iCodigoarticulo.EditValue = vwArticulounidad.Codigoarticulo;
                iCodigoproveedor.EditValue = vwArticulounidad.Codigoproveedor;
                iCodigodebarra.EditValue = vwArticulounidad.Codigodebarra;
                beArticulo.Text = vwArticulounidad.Nombrearticulo.Trim();
                iMarcaarticulo.EditValue = vwArticulounidad.Nombremarca;
                iIdimpuesto.EditValue = vwArticulounidad.Idimpuesto;
                iAbrunidadmedida.EditValue = vwArticulounidad.Abrunidadmedida;
                iIdunidadmedida.EditValue = vwArticulounidad.Idunidadinventario;
                nPorcentajepercepcion.EditValue = vwArticulounidad.Aplicapercepcion
                    ? SessionApp.EmpresaSel.Porcentajepercepcion
                    : 0m;
                iIdtipoafectacionigv.EditValue = vwArticulounidad.Idtipoafectacionigv;

                iGravado.EditValue = vwArticulounidad.Gravado;
                iExonerado.EditValue = vwArticulounidad.Exonerado;
                iInafecto.EditValue = vwArticulounidad.Inafecto;
                iExportacion.EditValue = vwArticulounidad.Exportacion;
                iCalcularitem.EditValue = true;
            }

            else
            {
                iIdarticulo.EditValue = 0;
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                iCodigodebarra.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iAbrunidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
                nPorcentajepercepcion.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;

                iGravado.EditValue = false;
                iExonerado.EditValue = false;
                iInafecto.EditValue = false;
                iExportacion.EditValue = false;
                iCalcularitem.EditValue = false;
            }
        }
        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal) iCantidad.EditValue;
            var precioUniatario = (decimal) iPreciounitario.EditValue;

            var importeTotal = Decimal.Round(cantidad * precioUniatario,4);
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
            BuscadorArticuloFrm buscadorArticuloFrm = new BuscadorArticuloFrm(
                IdSucursalConsulta,
                IdAlmacenConsulta,
                IdTipoListaConsulta);

            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK &&
                buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                CargarDatosArticuloSeleccionado(buscadorArticuloFrm.VwArticulounidadSel);
                iStock.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Stock;
                iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
            }
        }

    }
}