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
    public partial class GuiaremisionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwGuiaremisiondet VwGuiaremisiondetMnt { get; set; }
        public List<VwGuiaremisiondet> VwGuiaremisiondetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public int? IdCentroDeCostoPorDefecto { get; set; }
        public int? IdProyectoPorDefecto { get; set; }
        public int? IdAreaPorDefecto { get; set; }
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<VwArea> VwAreaList { get; set; }
        public List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public List<VwGuiaremisiondet> VwVwGuiaremisiondetComponenteList { get; set; }
        public GuiaremisionMntItemFrm(TipoMantenimiento tipoMnt, VwGuiaremisiondet vwGuiaremisiondetMnt)
        {

            InitializeComponent();
            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwGuiaremisiondetMnt = vwGuiaremisiondetMnt;         
        }
        private void GuiaremisionMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    iNumeroitem.EditValue = VwGuiaremisiondetMnt.Numeroitem;
                    var idAlmacen =SessionApp.SucursalSel;
                    if (idAlmacen != null)
                    {
                        BuscarArticulo();
                        //iCantidad.Select();
                        iIdcentrodecosto.Select();
                    }
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
            iNumeroitem.EditValue = VwGuiaremisiondetMnt.Numeroitem;

            if (IdCentroDeCostoPorDefecto > 0)
            {
                iIdcentrodecosto.EditValue = IdCentroDeCostoPorDefecto;
            }

            if (IdProyectoPorDefecto > 0)
            {
                iIdproyecto.EditValue = IdProyectoPorDefecto;
            }

            if (IdAreaPorDefecto > 0)
            {
                iIdarea.EditValue = IdAreaPorDefecto;
            }
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwGuiaremisiondetMnt.Numeroitem;
            iIdarticulo.EditValue = VwGuiaremisiondetMnt.Idarticulo;

            iEspecificacion.EditValue = VwGuiaremisiondetMnt.Especificacion;
            iCantidad.EditValue = VwGuiaremisiondetMnt.Cantidad;
            iPreciounitario.EditValue = VwGuiaremisiondetMnt.Preciounitario;
            iImportetotal.EditValue = VwGuiaremisiondetMnt.Importetotal;
            iPesounitario.EditValue = VwGuiaremisiondetMnt.Pesounitario;
            iPesototal.EditValue = VwGuiaremisiondetMnt.Pesototal;
            nPorcentajepercepcion.EditValue = VwGuiaremisiondetMnt.Porcentajepercepcion;

            iIdproyecto.EditValue = VwGuiaremisiondetMnt.Idproyecto;
            iIdarea.EditValue = VwGuiaremisiondetMnt.Idarea;
            iIdcentrodecosto.EditValue = VwGuiaremisiondetMnt.Idcentrodecosto;

        }
        private void CargarReferencias()
        {


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


			        VwGuiaremisiondetMnt.Numeroitem = (int)iNumeroitem.EditValue;
			        VwGuiaremisiondetMnt.Idarticulo = (int)iIdarticulo.EditValue;
			        VwGuiaremisiondetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
			        VwGuiaremisiondetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
			        VwGuiaremisiondetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwGuiaremisiondetMnt.Abrunidadmedida = iUnidadmedida.Text.Trim();
			        VwGuiaremisiondetMnt.Nombremarca = iMarcaarticulo.Text.Trim();
			        VwGuiaremisiondetMnt.Nombrearticulo = beArticulo.Text.Trim();
			        VwGuiaremisiondetMnt.Cantidad = (decimal)iCantidad.EditValue;
			        VwGuiaremisiondetMnt.Abrunidadmedida = iUnidadmedida.Text.Trim();
			        VwGuiaremisiondetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwGuiaremisiondetMnt.Especificacion = iEspecificacion.Text.Trim();
			        VwGuiaremisiondetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwGuiaremisiondetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwGuiaremisiondetMnt.Pesounitario = (decimal)iPesounitario.EditValue;
                    VwGuiaremisiondetMnt.Pesototal = (decimal)iPesototal.EditValue;
                    VwGuiaremisiondetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwGuiaremisiondetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;                    
                    VwGuiaremisiondetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwGuiaremisiondetMnt.Gravado = VwArticuloSel.Gravado;
                    VwGuiaremisiondetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwGuiaremisiondetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwGuiaremisiondetMnt.Exportacion = VwArticuloSel.Exportacion;
                    VwGuiaremisiondetMnt.Idarea = (int)iIdarea.EditValue;
                    VwGuiaremisiondetMnt.Nombrearea = iIdarea.Text.Trim();
                    VwGuiaremisiondetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwGuiaremisiondetMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwGuiaremisiondetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwGuiaremisiondetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwGuiaremisiondetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwGuiaremisiondetMnt.Idordendeventadet = null;


                    //Los items por defecto se calculan
                    VwGuiaremisiondetMnt.Calcularitem = true;

                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwGuiaremisiondetMnt.Idarticulo);
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            //VwCotizacionclientedetMnt.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwCotizacionclientedetMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            //VwCotizacionclientedetMnt.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwCotizacionclientedetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwGuiaremisiondetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwGuiaremisiondetMnt.DataEntityState = DataEntityState.Modified;
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
            VwVwGuiaremisiondetComponenteList = new List<VwGuiaremisiondet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwGuiaremisiondet vwGuiaremisiondet = new VwGuiaremisiondet();

                vwGuiaremisiondet.Numeroitem = numeroItem;
                vwGuiaremisiondet.Idarticulo = item.Idarticulodetalle;
                vwGuiaremisiondet.Codigoarticulo = item.Codigoarticulo;
                vwGuiaremisiondet.Codigoproveedor = item.Codigoproveedor;
                vwGuiaremisiondet.Idunidadmedida = item.Idunidadinventario;
                vwGuiaremisiondet.Abrunidadmedida = item.Abrunidadmedida;
                vwGuiaremisiondet.Nombremarca = item.Nombremarca;
                vwGuiaremisiondet.Nombrearticulo = item.Nombremarca;
                vwGuiaremisiondet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwGuiaremisiondet.Abrunidadmedida = item.Abrunidadmedida;
                vwGuiaremisiondet.Preciounitario = 0m;
                vwGuiaremisiondet.Especificacion = string.Empty;
                vwGuiaremisiondet.Preciounitario = 0m;
                vwGuiaremisiondet.Importetotal = 0m;
                vwGuiaremisiondet.Pesounitario = 0m;
                vwGuiaremisiondet.Pesototal = item.Cantidaddetalle * (decimal)iCantidad.EditValue * item.Pesoarticulo;
                vwGuiaremisiondet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                vwGuiaremisiondet.Idimpuesto = item.Idimpuesto;
                vwGuiaremisiondet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwGuiaremisiondet.Gravado = item.Gravado;
                vwGuiaremisiondet.Exonerado = item.Exonerado;
                vwGuiaremisiondet.Inafecto = item.Inafecto;
                vwGuiaremisiondet.Exportacion = item.Exportacion;
                vwGuiaremisiondet.Idarea = (int)iIdarea.EditValue;
                vwGuiaremisiondet.Nombrearea = iIdarea.Text.Trim();
                vwGuiaremisiondet.Idproyecto = (int)iIdproyecto.EditValue;
                vwGuiaremisiondet.Nombreproyecto = iIdproyecto.Text.Trim();
                vwGuiaremisiondet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwGuiaremisiondet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwGuiaremisiondet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                vwGuiaremisiondet.Idordendeventadet = null;


                //Se estable a false no se calcula el item
                vwGuiaremisiondet.Calcularitem = false;

                //switch (TipoMnt)
                //{
                //    case TipoMantenimiento.Nuevo:
                //        vwGuiaremisiondet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                //        vwGuiaremisiondet.Creationdate = DateTime.Now;
                //        break;
                //    case TipoMantenimiento.Modificar:
                //        vwGuiaremisiondet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                //        vwGuiaremisiondet.Lastmodified = DateTime.Now;
                //        break;
                //}

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwGuiaremisiondet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwGuiaremisiondet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                VwVwGuiaremisiondetComponenteList.Add(vwGuiaremisiondet);
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
        private void GuiaremisionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
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
        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal) iCantidad.EditValue;
            var precioUniatario = (decimal) iPreciounitario.EditValue;
            var importeTotal = Decimal.Round(cantidad * precioUniatario, 2);
            var pesoUniatario = (decimal)iPesounitario.EditValue;
            var pesototal = Decimal.Round(cantidad * pesoUniatario, 2);
            iImportetotal.EditValue = importeTotal;
            iPesototal.EditValue = pesototal;

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
                //Asignar al edit value del campo id foraneo               
                iIdarticulo.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Idarticulo;
                iEspecificacion.Text = VwArticuloSel.Caracteristicas;
                var cencosArticulo = VwArticuloSel.Idcentrodecosto;
                iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                if (cencosArticulo != null)
                {
                    iIdcentrodecosto.EditValue = VwArticuloSel.Idcentrodecosto;
                    iIdcentrodecosto.Enabled = false;
                    iCantidad.Select();
                }
            }

            else
            {
                beArticulo.Select();
            }
        }
    }
}