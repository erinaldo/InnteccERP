using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class CpVentaDetSerieMntItemDinamicoFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwCpventadet VwCpventadet { get; set; }
        public VwCpventadetserie VwCpventadetserie { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<Programacioncitadet> VwProgramacioncitadetListMnt { get; set; }
        public List<VwArticuloseriedet> VwArticuloseriedetList { get; set; }

        public CpVentaDetSerieMntItemDinamicoFrm(TipoMantenimiento tipoMnt, VwCpventadet vwCpventadet, VwCpventadetserie vwCpventadetserie)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCpventadet = vwCpventadet;
            VwCpventadetserie = vwCpventadetserie;

        }

        private void CpVentaDetSerieMntItemDinamicoFrm_Load(object sender, EventArgs e)
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
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {



        }

        private void TraerDatos()
        {

            iIdcpventadetserie.EditValue = VwCpventadetserie.Idcpventadetserie;
            iIdseriearticulo.EditValue = VwCpventadetserie.Idseriearticulo;
            iSerieutilizada.EditValue = VwCpventadetserie.Serieutilizada;

        }

        private void CargarReferencias()
        {
            
            string condicion = null;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    condicion = string.Format("idarticulo = {0} and not serieutilizada", VwCpventadet.Idarticulo);
                    break;
                case TipoMantenimiento.Modificar:
                    condicion = string.Format("idarticulo = {0}", VwCpventadet.Idarticulo);
                    break;
            }
            VwArticuloseriedetList = Service.GetAllVwArticuloseriedet(condicion, "Numeroserieitem");
            iIdseriearticulo.Properties.DataSource = VwArticuloseriedetList;
            iIdseriearticulo.Properties.DisplayMember = "Numeroserieitem";
            iIdseriearticulo.Properties.ValueMember = "Idseriearticulo";


        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;



                    switch (e.Item.Name)
                    {
                        case "btnGrabarItem":

                            if (!Validaciones()) return;

                            VwCpventadetserie.Idcpventadetserie = (int)iIdcpventadetserie.EditValue;
                            VwCpventadetserie.Idcpventadet = VwCpventadet.Idcpventadet;
                            VwCpventadetserie.Idseriearticulo = (int)iIdseriearticulo.EditValue;
                            VwCpventadetserie.Numeroserieitem = iIdseriearticulo.Text.Trim();
                            VwCpventadetserie.Codigointernoitem = rCodigointernoitem.Text.Trim();
                            VwCpventadetserie.Serieutilizada = iSerieutilizada.Checked;

                            if (VwCpventadetserie.Idseriearticulo > 0)
                            {
                                Service.EstablecerSerieUtilizada(VwCpventadetserie.Idseriearticulo,
                                    iSerieutilizada.Checked);
                            }

                            DialogResult = DialogResult.OK;




                            break;
                        case "btnCancelarItem":
                            DialogResult = DialogResult.Cancel;
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
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CpVentaDetSerieMntItemDinamicoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIdseriearticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idSeriearticulo = iIdseriearticulo.EditValue;
            if (idSeriearticulo != null)
            {
                VwArticuloseriedet vwArticuloseriedet = VwArticuloseriedetList.FirstOrDefault(x => x.Idseriearticulo == (int)idSeriearticulo);
                if (vwArticuloseriedet != null)
                {
                    rCodigointernoitem.EditValue = vwArticuloseriedet.Codigointernoitem;
                }

                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    iSerieutilizada.Checked = true;
                }
            }
        }
    }
}