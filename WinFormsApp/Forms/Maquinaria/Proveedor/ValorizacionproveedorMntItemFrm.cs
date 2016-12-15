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
    public partial class ValorizacionproveedorMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwValorizacionproveedordet VwValorizacionproveedordetMnt { get; set; }
        public List<Centrodecosto> CentrodecostoList { get; private set; }
        public int IdcentroCosto { get; set; }

        public ValorizacionproveedorMntItemFrm(TipoMantenimiento tipoMnt, VwValorizacionproveedordet vwValorizacionproveedordetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwValorizacionproveedordetMnt = vwValorizacionproveedordetMnt;

        }
        private void ValorizacionproveedorMntItemFrm_Load(object sender, EventArgs e)
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
                    iHorometrofinal.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    //ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
         
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwValorizacionproveedordetMnt.Numeroitem;
            iFecha.EditValue =   VwValorizacionproveedordetMnt.Fecha;
            iTurno.EditValue = VwValorizacionproveedordetMnt.Turno;
            iHorometroinicio.EditValue = VwValorizacionproveedordetMnt.Horometroinicio;
            iHorometrofinal.EditValue = VwValorizacionproveedordetMnt.Horometroinicio;
            iIdcentrodecosto.EditValue = IdcentroCosto;
            //iIdcentrodecosto.EditValue = VwValorizaciondetalleMnt.Idcentrodecosto;
        }
        private void TraerDatos()
        {
          
            iNumeroitem.EditValue = VwValorizacionproveedordetMnt.Numeroitem;
            iFecha.EditValue = VwValorizacionproveedordetMnt.Fecha;
            iTurno.EditValue = VwValorizacionproveedordetMnt.Turno;
            iHorometroinicio.EditValue = VwValorizacionproveedordetMnt.Horometroinicio;
            iHorometrofinal.EditValue = VwValorizacionproveedordetMnt.Horometrofinal;
            iHorometrodia.EditValue = VwValorizacionproveedordetMnt.Horometrodia;
            iDescuentohorometro.EditValue = VwValorizacionproveedordetMnt.Descuentohorometro;
            iHorometrorealdia.EditValue = VwValorizacionproveedordetMnt.Horometrorealdia;
            iHorometrominimo.EditValue = VwValorizacionproveedordetMnt.Horometrominimo;
            iDiastrabajo.EditValue = VwValorizacionproveedordetMnt.Diastrabajo;
            iIdcentrodecosto.EditValue = VwValorizacionproveedordetMnt.Idcentrodecosto;
            iObservaciones.EditValue = VwValorizacionproveedordetMnt.Observaciones;

        }
        private void CargarReferencias()
        {

            string whereCc = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            CentrodecostoList = Service.GetAllCentrodecosto(whereCc, "descripcioncentrodecosto");
            iIdcentrodecosto.Properties.DataSource = CentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;


            iTurno.Properties.DataSource = CacheObjects.TurnoValorizacionList;
            iTurno.Properties.DisplayMember = "DescripcionTurno";
            iTurno.Properties.ValueMember = "Turno";


        
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwValorizacionproveedordetMnt.Numeroitem = (int)iNumeroitem.EditValue;
                    VwValorizacionproveedordetMnt.Fecha = (DateTime)iFecha.EditValue;
                    VwValorizacionproveedordetMnt.Turno = (string) iTurno.EditValue;
                    VwValorizacionproveedordetMnt.Horometroinicio = (decimal)iHorometroinicio.EditValue;
                    VwValorizacionproveedordetMnt.Horometrofinal = (decimal)iHorometrofinal.EditValue;
                    VwValorizacionproveedordetMnt.Horometrodia = (decimal)iHorometrodia.EditValue;
                    VwValorizacionproveedordetMnt.Descuentohorometro = (decimal)iDescuentohorometro.EditValue;
                    VwValorizacionproveedordetMnt.Horometrorealdia = (decimal)iHorometrorealdia.EditValue;
                    VwValorizacionproveedordetMnt.Horometrominimo = (decimal)iHorometrominimo.EditValue;
                    VwValorizacionproveedordetMnt.Diastrabajo = (decimal)iDiastrabajo.EditValue;
                    VwValorizacionproveedordetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwValorizacionproveedordetMnt.Observaciones = iObservaciones.Text.Trim();

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            //VwValorizaciondetalleMnt.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwValorizaciondetalleMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            //VwValorizaciondetalleMnt.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwValorizaciondetalleMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwValorizacionproveedordetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwValorizacionproveedordetMnt.DataEntityState = DataEntityState.Modified;                            
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
        private void ValorizacionproveedorMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CalcularTotal(object sender, EventArgs e)
        {
            var hinicial = (decimal)iHorometroinicio.EditValue;
            var hfinal = (decimal)iHorometrofinal.EditValue;
            var hdia = Decimal.Round(hfinal - hinicial, 2);
            var hdes = (decimal)iDescuentohorometro.EditValue;
            var hreal = hdia - hdes;
            var valHrsMinMes = DatosvalorizacionProveedor.HorasMinima;
            var diasmes = DatosvalorizacionProveedor.Diames;
            var valHrsMinDia = Decimal.Round(valHrsMinMes / diasmes,2);
            iHorometrodia.EditValue = hdia;
            iHorometrorealdia.EditValue = hreal;
            iHorometrominimo.EditValue = valHrsMinDia;
            if (hdia == 0)
            {
                iDiastrabajo.EditValue = 0m;
            }
            else
            {
                iDiastrabajo.EditValue =1m;
            }


        }
    }
}