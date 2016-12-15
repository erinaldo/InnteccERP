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
    public partial class RendicioncajachicaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRendicioncajachicadet VwRendicioncajachicadetMnt { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajadetList { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        public List<Tipomediopago> TipomediopagoList { get; set; }

        //Propiedades 
        public int Idrecibocaja { get; set; }
        public Decimal Saldoarendir { get; set; }
        //
        public RendicioncajachicaMntItemFrm(TipoMantenimiento tipoMnt, VwRendicioncajachicadet vwRendicioncajachicadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwRendicioncajachicadetMnt = vwRendicioncajachicadet;

         
        }
        private void RendicioncajachicaMntItemFrm_Load(object sender, EventArgs e)
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
                    iNumeroitem.EditValue = VwRendicioncajachicadetMnt.Numeroitem;
                    rPorrendir.EditValue = Saldoarendir;
                  
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    rPorrendir.EditValue = Saldoarendir + (decimal) rImportepago.EditValue;
                    break;
            }
            //
           

        }
        private void ValoresPorDefecto()
        {
            iFechatipocp.EditValue = SessionApp.DateServer;
            
        }
        private void TraerDatos()
        {
           
            iIdsocionegocio.EditValue = VwRendicioncajachicadetMnt.Idsocionegocio;
            iNumeroitem.EditValue = VwRendicioncajachicadetMnt.Numeroitem;
            iIdtipocp.EditValue = VwRendicioncajachicadetMnt.Idtipocp;
            iSerietipocp.EditValue = VwRendicioncajachicadetMnt.Serietipocp;
            iNumerotipocp.EditValue = VwRendicioncajachicadetMnt.Numerotipocp;
            rImportepago.EditValue = VwRendicioncajachicadetMnt.Importepago;
            iFechatipocp.EditValue = VwRendicioncajachicadetMnt.Fechatipocp;           
            iDescripciongasto.EditValue = VwRendicioncajachicadetMnt.Descripciongasto;
            iNumerordendetrabajo.EditValue = VwRendicioncajachicadetMnt.Numerordendetrabajo;
            iFechaordentrabajo.EditValue = VwRendicioncajachicadetMnt.Fechaordentrabajo;
            iDescripcionordentrabajo.EditValue = VwRendicioncajachicadetMnt.Descripcionordentrabajo;
            iIdcpcompra.EditValue = VwRendicioncajachicadetMnt.Idcpcompra;


        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = 'CPCOMPRA' and idsucursal = '{0}'", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;

          
     
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":
                    var saldoporrendir = (decimal) rPorrendir.EditValue;

                    var importegastado = (decimal) rImportepago.EditValue;
                    
                    if (importegastado > saldoporrendir)
                    {
                        XtraMessageBox.Show("Gasto es Mayor al Saldo", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        //break;
                    }


            int idTipoCp = (int)iIdtipocp.EditValue;
            int idSucursal = SessionApp.SucursalSel.Idsucursal;
            int idSocionegocio = (int) iIdsocionegocio.EditValue;
            string serieCotizacion = (string)iSerietipocp.EditValue;
            string numeroCotizacion = (string)iNumerotipocp.EditValue;

            VwCpcompra cpcompra = Service.GetVwCpcompra(
                x => x.Idtipocp == idTipoCp
                     && x.Idsucursal == idSucursal
                     && x.Seriecpcompra == serieCotizacion.Trim()
                     && x.Numerocpcompra == numeroCotizacion.Trim()
                     && x.Idproveedor == idSocionegocio
                     && x.Escajachica
                     && !x.Anulado
                );

                    if (cpcompra == null)
                    {
                        XtraMessageBox.Show("Comprobante no registrado en comprobante", "Atencion",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                       // iNumerotipocp.Text = @"0";
                        iNumerotipocp.Focus();
                        iNumerotipocp.Select();
                        iNumerotipocp.SelectAll();
                        return;
                       
                    }



                    if (!Validaciones()) return;

                   
                    //VwRendicioncajachicadetMnt.Idrendicioncajachica = (int)iIdrendicioncajachica.EditValue;
                    VwRendicioncajachicadetMnt.Idsocionegocio = (int)iIdsocionegocio.EditValue;
                    VwRendicioncajachicadetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwRendicioncajachicadetMnt.Idtipocp = (int)iIdtipocp.EditValue;
                    VwRendicioncajachicadetMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRendicioncajachicadetMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRendicioncajachicadetMnt.Importepago = (decimal)rImportepago.EditValue;
                    VwRendicioncajachicadetMnt.Fechatipocp = (DateTime)iFechatipocp.EditValue;                
                    VwRendicioncajachicadetMnt.Descripciongasto = iDescripciongasto.Text.Trim();
                    VwRendicioncajachicadetMnt.Idcpcompra = (int) iIdcpcompra.EditValue;
                 


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
        private void RendicioncajachicaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            VwSocionegocio vwSocionegocioSel;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        vwSocionegocioSel = buscarSocioNegocioFrm.VwSocionegocioSel;

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;

                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdsocionegocio.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            vwSocionegocioSel = Service.GetVwSocionegocio(socionegocioMntFrm.IdEntidadMnt);

                            beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                            iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                        }
                    }
                    break;
            }
        }

        private void iIdsocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioMnt = iIdsocionegocio.EditValue;
            if (idSocioNegocioMnt == null || (int)idSocioNegocioMnt <= 0) return;

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int)idSocioNegocioMnt);
            if (vwSocionegocioSel != null)
            {
                beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;

            }
        }

        private void btnBuscarCp_Click(object sender, EventArgs e)
        {
            var idSocio = (int)iIdsocionegocio.EditValue;
            if (idSocio == 0)
            {
                XtraMessageBox.Show("Seleccione el SOCIO DE NEGOCIO", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                beSocioNegocio.Select();
                return;
            }
            
            var idTipoCp = iIdtipocp.EditValue;
            if (idTipoCp == null)
            {
                XtraMessageBox.Show("Seleccione el tipo de documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iIdtipocp.Select();
                return;
            }


            int idSucursal = SessionApp.SucursalSel.Idsucursal;
            int idSocionegocio = (int) iIdsocionegocio.EditValue;
            string serieCotizacion = (string)iSerietipocp.EditValue;
            string numeroCotizacion = (string)iNumerotipocp.EditValue;

            VwCpcompra cpcompra = Service.GetVwCpcompra(
                x => x.Idtipocp == (int)idTipoCp
                     && x.Idsucursal == idSucursal
                     && x.Seriecpcompra == serieCotizacion.Trim()
                     && x.Numerocpcompra == numeroCotizacion.Trim()
                     && x.Idproveedor == idSocionegocio
                     && x.Escajachica
                     && !x.Anulado
                );

            if (cpcompra != null)
            {
                //Verificar si tiene items el comprobante de compra
                long cantidadItemsCotizacion = Service.CountCpcompradet(x => x.Idcpcompra == cpcompra.Idcpcompra);
                if (cantidadItemsCotizacion <= 0)
                {
                    XtraMessageBox.Show("El comprobante no tiene items, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumerotipocp.Text = @"0";
                    iNumerotipocp.Focus();
                    iNumerotipocp.Select();
                    iNumerotipocp.SelectAll();
                    return;
                }


                //Verificar si el recibo tiene cuadro rendicion
                Rendicioncajachicadet rendicioncajachicadet = Service.GetRendicioncajachicadet(
                    x => x.Idtipocp == cpcompra.Idtipocp
                    && x.Serietipocp == cpcompra.Seriecpcompra
                    && x.Numerotipocp == cpcompra.Numerocpcompra
                    && x.Idsocionegocio == cpcompra.Idproveedor);

                if (rendicioncajachicadet != null)
                {
                   // string numeroDocCc = string.Format("{0}-{1}", rendicioncajachicadet.Serierendicioncaja.Trim(), rendicioncajachicadet.Numerorendicioncaja);
                    XtraMessageBox.Show("Comprobante ya fue importado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iNumerotipocp.Text = @"0";
                    rImportepago.EditValue = 0m;
                    iNumerotipocp.Focus();
                    iNumerotipocp.Select();
                    iNumerotipocp.SelectAll();
                    return;
                }

                List<VwCpcompradet> vwCpcompradets = Service.GetAllVwCpcompradet(x => x.Idcpcompra == cpcompra.Idcpcompra);

                string listadoitems = null;
                foreach (var item in vwCpcompradets)
                {
                    listadoitems = listadoitems +  item.Nombrearticulo+ " " + item.Nombremarca+", " ;
                }
                
                rImportepago.EditValue = cpcompra.Totaldocumento;
                iFechatipocp.EditValue = cpcompra.Fechaemision;
                iIdsocionegocio.EditValue = cpcompra.Idproveedor;
                if (listadoitems != null) iDescripciongasto.EditValue = listadoitems.Trim();

                iNumerordendetrabajo.EditValue = cpcompra.Numerordendetrabajo;
                iFechaordentrabajo.EditValue = cpcompra.Fechaordentrabajo;
                iDescripcionordentrabajo.EditValue = cpcompra.Descripcionordentrabajo;
                iIdcpcompra.EditValue = cpcompra.Idcpcompra;

                rImportepago.Enabled = false;
                iFechatipocp.Enabled = false;
               
                
                XtraMessageBox.Show("COMPROBANTE DE COMPRA encontrado con exito", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("No se encontró el número de Recibo de Caja, verifique", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                iNumerotipocp.EditValue = @"00000000";
                iNumerotipocp.Focus();
                iNumerotipocp.Select();
                iNumerotipocp.SelectAll();
            }
        }
    

    }
}