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
    public partial class ValorizacionelementoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwValorizacionelemento VwValorizacionelementodet { get; set; }
        public List<VwValorizacionelemento> VwValorizacionelementodetList { get; set; }
        public ValorizacionelementoMntItemFrm(TipoMantenimiento tipoMnt, VwValorizacionelemento vwValorizacionelementoDet, List<VwValorizacionelemento> vwValorizacionelementodetList)
        {

            InitializeComponent();
            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwValorizacionelementodet = vwValorizacionelementoDet;
            VwValorizacionelementodetList = vwValorizacionelementodetList;
        }
        private void ValorizacionelementoMntItemFrm_Load(object sender, EventArgs e)
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
            iNumeroitem.EditValue = VwValorizacionelementodet.Numeroitem;
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwValorizacionelementodet.Numeroitem;
            iIdarticulo.EditValue = VwValorizacionelementodet.Idarticulo;

            iCodigoarticulo.EditValue = VwValorizacionelementodet.Codigoarticulo;
            iCodigoproveedor.EditValue = VwValorizacionelementodet.Codigoproveedor;
            beArticulo.Text = VwValorizacionelementodet.Nombrearticulo.Trim();
            iMarcaarticulo.EditValue = VwValorizacionelementodet.Nombremarca;
            iAbrunidadmedida.EditValue = VwValorizacionelementodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwValorizacionelementodet.Idunidadmedida;       
            iAbrunidadmedida.EditValue = VwValorizacionelementodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwValorizacionelementodet.Idunidadmedida;

            iEspecificacion.EditValue = VwValorizacionelementodet.Comentario;
            iCantidad.EditValue = VwValorizacionelementodet.Cantidad;
            iPreciounitario.EditValue = VwValorizacionelementodet.Valorunitario;
            iImportetotal.EditValue = VwValorizacionelementodet.Subtotal;
            iIdunidadmedida.EditValue = VwValorizacionelementodet.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwValorizacionelementodet.Abrunidadmedida;
        }
        private void CargarReferencias()
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


                    VwValorizacionelementodet.Numeroitem = (int)iNumeroitem.EditValue;
                    VwValorizacionelementodet.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwValorizacionelementodet.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwValorizacionelementodet.Nombrearticulo = beArticulo.Text.Trim();
                    VwValorizacionelementodet.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwValorizacionelementodet.Cantidad = (decimal)iCantidad.EditValue;
                    VwValorizacionelementodet.Valorunitario = (decimal)iPreciounitario.EditValue;
                    VwValorizacionelementodet.Subtotal = (decimal)iImportetotal.EditValue;
                    VwValorizacionelementodet.Comentario = iEspecificacion.Text.Trim();
                    VwValorizacionelementodet.Idarticulo = (int)iIdarticulo.EditValue;                    
                    VwValorizacionelementodet.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwValorizacionelementodet.Abrunidadmedida = iAbrunidadmedida.Text.Trim();                   

                    //switch (TipoMnt)
                    //{
                    //    case TipoMantenimiento.Nuevo:
                    //        VwValorizacionelementodet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                    //        VwValorizacionelementodet.Creationdate = DateTime.Now;
                    //        break;
                    //    case TipoMantenimiento.Modificar:
                    //        VwValorizacionelementodet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                    //        VwValorizacionelementodet.Lastmodified = DateTime.Now;
                    //        break;
                    //}

                    if (TipoMnt == TipoMantenimiento.Nuevo)
                    {
                        int cantReferenciasItem = VwValorizacionelementodetList.Count(x => x.Idarticulo == VwValorizacionelementodet.Idarticulo
                            && x.Idunidadmedida == VwValorizacionelementodet.Idunidadmedida
                            && x.DataEntityState != DataEntityState.Deleted);

                        if (cantReferenciasItem > 0)
                        {
                            string mensaje = string.Format("El articulo {0} ya fue agregado ¿Desea continuar?",
                                VwValorizacionelementodet.Nombrearticulo);
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
                            VwValorizacionelementodet.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwValorizacionelementodet.DataEntityState = DataEntityState.Modified;                            
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
        private void ValorizacionelementoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CargarDatosArticuloSeleccionado(VwArticulo vwArticulounidad)
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
                iAbrunidadmedida.EditValue = vwArticulounidad.Abrunidadmedida;
                iIdunidadmedida.EditValue = vwArticulounidad.Idunidadinventario;
            }

            else
            {
                iIdarticulo.EditValue = 0;
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                iCodigodebarra.EditValue = string.Empty;
                beArticulo.Text = string.Empty;
                iMarcaarticulo.EditValue = string.Empty;
                iAbrunidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
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
            BuscadorArticuloFrmBase buscadorArticuloFrmBase = new BuscadorArticuloFrmBase();

            buscadorArticuloFrmBase.ShowDialog();

            if (buscadorArticuloFrmBase.DialogResult == DialogResult.OK &&
                buscadorArticuloFrmBase.VwArticuloSel != null)
            {
                CargarDatosArticuloSeleccionado(buscadorArticuloFrmBase.VwArticuloSel);
            }
        }

    }
}