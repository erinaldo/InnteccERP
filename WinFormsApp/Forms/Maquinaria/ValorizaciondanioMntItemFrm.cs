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
    public partial class ValorizaciondanioMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwValorizaciondanio VwValorizaciondaniodet { get; set; }
        public List<VwValorizaciondanio> VwValorizaciondaniodetList { get; set; }
        public ValorizaciondanioMntItemFrm(TipoMantenimiento tipoMnt, VwValorizaciondanio vwValorizaciondaniodet, List<VwValorizaciondanio> vwValorizaciondaniodetList)
        {

            InitializeComponent();
            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwValorizaciondaniodet = vwValorizaciondaniodet;
            VwValorizaciondaniodetList = vwValorizaciondaniodetList;
        }
        private void ValorizaciondanioMntItemFrm_Load(object sender, EventArgs e)
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
            iNumeroitem.EditValue = VwValorizaciondaniodet.Numeroitem;
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwValorizaciondaniodet.Numeroitem;
            iIdarticulo.EditValue = VwValorizaciondaniodet.Idarticulo;

            iCodigoarticulo.EditValue = VwValorizaciondaniodet.Codigoarticulo;
            iCodigoproveedor.EditValue = VwValorizaciondaniodet.Codigoproveedor;
            beArticulo.Text = VwValorizaciondaniodet.Nombrearticulo.Trim();
            iMarcaarticulo.EditValue = VwValorizaciondaniodet.Nombremarca;
            iAbrunidadmedida.EditValue = VwValorizaciondaniodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwValorizaciondaniodet.Idunidadmedida;       
            iAbrunidadmedida.EditValue = VwValorizaciondaniodet.Abrunidadmedida;
            iIdunidadmedida.EditValue = VwValorizaciondaniodet.Idunidadmedida;

            iEspecificacion.EditValue = VwValorizaciondaniodet.Comentario;
            iCantidad.EditValue = VwValorizaciondaniodet.Cantidad;
            iPreciounitario.EditValue = VwValorizaciondaniodet.Valorunitario;
            iImportetotal.EditValue = VwValorizaciondaniodet.Subtotal;
            iIdunidadmedida.EditValue = VwValorizaciondaniodet.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwValorizaciondaniodet.Abrunidadmedida;
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


                    VwValorizaciondaniodet.Numeroitem = (int)iNumeroitem.EditValue;
                    VwValorizaciondaniodet.Codigoarticulo = iCodigoarticulo.Text.Trim();
                    VwValorizaciondaniodet.Codigoproveedor = iCodigoproveedor.Text.Trim();
                    VwValorizaciondaniodet.Nombrearticulo = beArticulo.Text.Trim();
                    VwValorizaciondaniodet.Nombremarca = iMarcaarticulo.Text.Trim();
                    VwValorizaciondaniodet.Cantidad = (decimal)iCantidad.EditValue;
                    VwValorizaciondaniodet.Valorunitario = (decimal)iPreciounitario.EditValue;
                    VwValorizaciondaniodet.Subtotal = (decimal)iImportetotal.EditValue;
                    VwValorizaciondaniodet.Comentario = iEspecificacion.Text.Trim();
                    VwValorizaciondaniodet.Idarticulo = (int)iIdarticulo.EditValue;                    
                    VwValorizaciondaniodet.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwValorizaciondaniodet.Abrunidadmedida = iAbrunidadmedida.Text.Trim();                   

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
                        int cantReferenciasItem = VwValorizaciondaniodetList.Count(x => x.Idarticulo == VwValorizaciondaniodet.Idarticulo
                            && x.Idunidadmedida == VwValorizaciondaniodet.Idunidadmedida
                            && x.DataEntityState != DataEntityState.Deleted);

                        if (cantReferenciasItem > 0)
                        {
                            string mensaje = string.Format("El articulo {0} ya fue agregado ¿Desea continuar?",
                                VwValorizaciondaniodet.Nombrearticulo);
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
                            VwValorizaciondaniodet.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwValorizaciondaniodet.DataEntityState = DataEntityState.Modified;                            
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
        private void ValorizaciondanioMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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