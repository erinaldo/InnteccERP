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
    public partial class CajaCobroMedioPagoCpVentaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwRecibocajaingresodet VwRecibocajadetMnt { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajadetList { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<Tipomediopago> TipomediopagoList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public VwCpventa VwCpventa { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajaingresodetListMnt { get; set; }
        public CajaCobroMedioPagoCpVentaMntItemFrm(TipoMantenimiento tipoMnt, VwRecibocajaingresodet vwRecibocajadet, VwCpventa vwCpventa, List<VwRecibocajaingresodet> vwRecibocajaingresodetListMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwRecibocajadetMnt = vwRecibocajadet;
            VwCpventa = vwCpventa;
            VwRecibocajaingresodetListMnt = vwRecibocajaingresodetListMnt;
        }
        private void CajaCobroMedioPagoCpVentaMntItemFrm_Load(object sender, EventArgs e)
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
            iIdmediopago.Select();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;
                    CargarDatosCpVenta();   
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    CargarDatosCpVenta();   
                    break;
            }
            iNumeroitem.Select();
        }
        private void CargarDatosCpVenta()
        {
            iTipoCp.EditValue = VwCpventa.Nombretipocppago;
            iSerietipocp.EditValue = VwCpventa.Seriecpventa;
            iNumerotipocp.EditValue = VwCpventa.Numerocpventa;
            iTotalDocumento.EditValue = VwCpventa.Totaldocumento;
        }
        private void ValoresPorDefecto()
        {
            if (VwRecibocajaingresodetListMnt.Count == 0)
            {
                iIdmediopago.EditValue = 9; //Efectivo
            }
            else
            {
                iIdmediopago.EditValue = 6; //Tarjeta de credito
            }
            iImportepago.EditValue = VwRecibocajadetMnt.ImportePendiente;            
        

        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwRecibocajadetMnt.Numeroitem;         
            iIdmediopago.EditValue = VwRecibocajadetMnt.Idmediopago;
            iNumeromediopago.EditValue = VwRecibocajadetMnt.Numeromediopago;
            iComentario.EditValue = VwRecibocajadetMnt.Comentario;          
            iImportepago.EditValue = VwRecibocajadetMnt.Importepago;
            iRecibidomediopago.EditValue = VwRecibocajadetMnt.Recibidomediopago;
           
        }
        private void CargarReferencias()
        {
            string condicionMedioPago = "orden > 0";
            iIdmediopago.Properties.DataSource = Service.GetAllTipomediopago(condicionMedioPago,"orden");
            iIdmediopago.Properties.DisplayMember = "Nombremediopago";
            iIdmediopago.Properties.ValueMember = "Idmediopago";
            iIdmediopago.Properties.BestFitMode = BestFitMode.BestFit;               
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwRecibocajadetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwRecibocajadetMnt.Idtipodocmov = VwCpventa.Idtipodocmov;
                    VwRecibocajadetMnt.Idtipocp = VwCpventa.Idtipocp;
                    VwRecibocajadetMnt.Serietipocp = iSerietipocp.Text.Trim();
                    VwRecibocajadetMnt.Numerotipocp = iNumerotipocp.Text.Trim();
                    VwRecibocajadetMnt.Importepago = (decimal)iImportepago.EditValue;
                    VwRecibocajadetMnt.Idmediopago = (int)iIdmediopago.EditValue;
                    VwRecibocajadetMnt.Nombremediopago = iIdmediopago.Text;
                    VwRecibocajadetMnt.Numeromediopago = iNumeromediopago.Text.Trim();
                    VwRecibocajadetMnt.Comentario = iComentario.Text.Trim();
                    VwRecibocajadetMnt.Recibidomediopago = (decimal) iRecibidomediopago.EditValue;
                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwRecibocajadetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwRecibocajadetMnt.DataEntityState = DataEntityState.Modified;
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
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            //if ((decimal) iRecibidomediopago.EditValue < (decimal) iImportepago.EditValue && (int)iIdmediopago.EditValue == 9)
            //{
            //    WinFormUtils.MessageWarning("Ingrese un monto recibido, valido.");
            //    iRecibidomediopago.Select();
            //    return false;
            //}

            //decimal totalMedioPago = VwRecibocajaingresodetListMnt.Where(x => x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Importepago);
            //if (totalMedioPago == 0)
            //{

            //}


            return true;
        }
        private void CajaCobroMedioPagoCpVentaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIdmediopago_EditValueChanged(object sender, EventArgs e)
        {
            var idMedioPago = iIdmediopago.EditValue;
            if (idMedioPago != null && (int) idMedioPago == 9) //Efectivo
            {
                iRecibidomediopago.Enabled = true;
            }
            else
            {
                iRecibidomediopago.Enabled = false;
            }
        }
    }
}