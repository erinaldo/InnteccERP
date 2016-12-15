using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Utilities;

namespace WinFormsApp
{
    public partial class CotizacionClienteCopiarFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        public int Idcotizacioncliente { get; set; }
        public List<VwTipocp> VwTipocpListOrigen { get; set; }
        public List<VwCptooperacion> VwCptooperacionListOrigen { get; set; }
        public List<VwTipocp> VwTipocpListDestino { get; set; }
        public List<VwCptooperacion> VwCptooperacionListDestino { get; set; }
        public VwTipocp TipoCpMnt { get; set; }
        public VwCotizacioncliente VwCotizacionclienteInicial { get; set; }
        public CotizacionClienteCopiarFrm(int idcotizacioncliente)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            Idcotizacioncliente = idcotizacioncliente;
            CargarReferencias();
            CargarInfoCotizacionCliente();
            
        }
        private void CargarInfoCotizacionCliente()
        {
            VwCotizacionclienteInicial = Service.GetVwCotizacioncliente(x => x.Idcotizacioncliente == Idcotizacioncliente);
            rSeriecotizacionOrigen.EditValue = VwCotizacionclienteInicial.Seriecotizacion;
            rNumerocotizacionOrigen.EditValue = VwCotizacionclienteInicial.Numerocotizacion;
            iNumeronegociacionOrigen.EditValue = VwCotizacionclienteInicial.Numeronegociacion;
            iFechacotizacionOrigen.EditValue = VwCotizacionclienteInicial.Fechacotizacion;
            iIdtipocpOrigen.EditValue = VwCotizacionclienteInicial.Idtipocp;
            iIdcptooperacionOrigen.EditValue = VwCotizacionclienteInicial.Idcptooperacion;
            rIdempresaOrigen.Text = VwCotizacionclienteInicial.Nombreempresa;
            rIdsucursalOrigen.Text = VwCotizacionclienteInicial.Nombresucursal;
            iNombrecliente.Text = VwCotizacionclienteInicial.Razonsocial;


            rSeriecotizacionDestino.EditValue = VwCotizacionclienteInicial.Seriecotizacion;
            rNumerocotizacionDestino.EditValue = VwCotizacionclienteInicial.Numerocotizacion;
            iNumeronegociacionDestino.EditValue = VwCotizacionclienteInicial.Numeronegociacion + 1;

            iIdEmpresaDestino.EditValue = VwCotizacionclienteInicial.Idempresa;
            iIdSucursalDestino.EditValue = VwCotizacionclienteInicial.Idsucursal;

            iIdtipocpDestino.EditValue = VwCotizacionclienteInicial.Idtipocp;
            iIdcptooperacionDestino.EditValue = VwCotizacionclienteInicial.Idcptooperacion;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }
        private void CargarReferencias()
        {                    
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwTipocpListOrigen = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocpOrigen.Properties.DataSource = VwTipocpListOrigen;
            iIdtipocpOrigen.Properties.DisplayMember = "Nombretipocp";
            iIdtipocpOrigen.Properties.ValueMember = "Idtipocp";
            iIdtipocpOrigen.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-CLIENTE", SessionApp.SucursalSel.Idsucursal);
            VwCptooperacionListOrigen = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
            iIdcptooperacionOrigen.Properties.DataSource = VwCptooperacionListOrigen;
            iIdcptooperacionOrigen.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacionOrigen.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacionOrigen.Properties.BestFitMode = BestFitMode.BestFit;


            iIdEmpresaDestino.Properties.DataSource = Service.GetAllEmpresa("Razonsocial");
            iIdEmpresaDestino.Properties.DisplayMember = "Razonsocial";
            iIdEmpresaDestino.Properties.ValueMember = "Idempresa";
            iIdEmpresaDestino.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (VwCotizacionclienteInicial == null)
            {
                XtraMessageBox.Show("No hay información de cotización", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            //Obtener instancia de cotizacion cliente 
            Cotizacioncliente cotizacionclienteDestino = Service.GetCotizacioncliente(x => x.Idcotizacioncliente  == VwCotizacionclienteInicial.Idcotizacioncliente);
            if (cotizacionclienteDestino != null)
            {
                //Obtener el de detalle de cotizacion seleccionada
                List<VwCotizacionclientedet> cotizacionclientedetDestinoList =
                    Service.GetAllVwCotizacionclientedet(
                        x => x.Idcotizacioncliente == VwCotizacionclienteInicial.Idcotizacioncliente);

                cotizacionclienteDestino.Idcotizacioncliente = 0;
                cotizacionclienteDestino.Idtipocp = (int)iIdtipocpDestino.EditValue;
                cotizacionclienteDestino.Idcptooperacion = (int)iIdcptooperacionDestino.EditValue;
                cotizacionclienteDestino.Seriecotizacion = (string) rSeriecotizacionDestino.EditValue;
                cotizacionclienteDestino.Numerocotizacion = (string)rNumerocotizacionDestino.EditValue;
                cotizacionclienteDestino.Numeronegociacion = (int) iNumeronegociacionDestino.EditValue;
                cotizacionclienteDestino.Aprobado = false;

                foreach (var item in cotizacionclientedetDestinoList)
                {
                    item.Idcotizacionclientedet = 0;
                    item.Idcotizacioncliente = 0;
                    item.DataEntityState = DataEntityState.Added;
                }

                if (Service.GuardarCotizacionCliente(TipoMantenimiento.Nuevo, cotizacionclienteDestino,
                    cotizacionclientedetDestinoList))
                {
                    XtraMessageBox.Show("Se proceso correctamente", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }

            }

        }
        private void CotizacionClienteCopiarFrm_Load(object sender, EventArgs e)
        {

            CargarReferencias();
            ValoresPorDefecto();
            EstablecerFechasIniciales();
        }
        private void EstablecerFechasIniciales()
        {

        }
        private void ValoresPorDefecto()
        {

        }
        private void iIdEmpresaDestino_EditValueChanged(object sender, EventArgs e)
        {
            int idEmpresaSel = (int)iIdEmpresaDestino.EditValue;
            if (idEmpresaSel > 0)
            {
                CargarSucursales(idEmpresaSel);
            }
        }
        private void CargarSucursales(int idEmpresaSel)
        {
            string where = string.Format("idempresa = {0}", idEmpresaSel);
            iIdSucursalDestino.Properties.DataSource = Service.GetAllSucursal(where, "Nombresucursal"); 
            iIdSucursalDestino.Properties.DisplayMember = "Nombresucursal";
            iIdSucursalDestino.Properties.ValueMember = "Idsucursal";
            iIdSucursalDestino.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void iIdSucursalDestino_EditValueChanged(object sender, EventArgs e)
        {
            CargarReferenciasCotizacionDestino();
        }
        private void CargarReferenciasCotizacionDestino()
        {

            var idSucursalDestinoSel = iIdSucursalDestino.EditValue;

            if (idSucursalDestinoSel != null)
            {
                string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-CLIENTE", (int)idSucursalDestinoSel);
                VwTipocpListDestino = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
                iIdtipocpDestino.Properties.DataSource = VwTipocpListDestino;
                iIdtipocpDestino.Properties.DisplayMember = "Nombretipocp";
                iIdtipocpDestino.Properties.ValueMember = "Idtipocp";
                iIdtipocpDestino.Properties.BestFitMode = BestFitMode.BestFit;

                string whereTipoOpe = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "COTIZA-CLIENTE", (int)idSucursalDestinoSel);
                VwCptooperacionListDestino = Service.GetAllVwCptooperacion(whereTipoOpe, "nombrecptooperacion");
                iIdcptooperacionDestino.Properties.DataSource = VwCptooperacionListDestino;
                iIdcptooperacionDestino.Properties.DisplayMember = "Nombrecptooperacion";
                iIdcptooperacionDestino.Properties.ValueMember = "Idcptooperacion";
                iIdcptooperacionDestino.Properties.BestFitMode = BestFitMode.BestFit;
            }
            else
            {
                iIdtipocpDestino.Properties.DataSource = null;
                iIdcptooperacionDestino.Properties.DataSource = null;
            }

        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativoCotizacionAGenerar();
        }
        private void CargarInfoCorrelativoCotizacionAGenerar()
        {
            var idTipocp = iIdtipocpDestino.EditValue;
            if (idTipocp != null)
            {
                //VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                //TipoCpMnt = vwTipocp;
                //rSeriecotizacionDestino.EditValue = vwTipocp.Seriecp;
                //rNumerocotizacionDestino.Properties.ReadOnly = vwTipocp.Numeracionauto;
                //rNumerocotizacionDestino.EditValue = vwTipocp.Numerocorrelativocp;
                //rNumerocotizacionDestino.TabStop = !vwTipocp.Numeracionauto;
            }
            else
            {
                rSeriecotizacionDestino.EditValue = @"0000";
                rNumerocotizacionDestino.EditValue = 0;
            }
        }
    }
}