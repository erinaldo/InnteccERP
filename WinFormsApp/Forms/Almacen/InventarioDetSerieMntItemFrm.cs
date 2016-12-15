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
    public partial class InventarioDetSerieMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwInventariostock VwInventariostock { get; set; }
        public VwInventariostockdetserie VwInventariostockdetserie { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<Programacioncitadet> VwProgramacioncitadetListMnt { get; set; }
        public List<VwArticuloseriedet> VwArticuloseriedetList { get; set; }

        public InventarioDetSerieMntItemFrm(TipoMantenimiento tipoMnt, VwInventariostock inventariostock, VwInventariostockdetserie vwInventariostockdetserie)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwInventariostock = inventariostock;
            VwInventariostockdetserie = vwInventariostockdetserie;

        }

        private void InventarioDetSerieMntItemFrm_Load(object sender, EventArgs e)
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

            //rIdestadocita.EditValue = VwProgramacioncitadetMnt.Idestadocita;
            //rIdmotivocita.EditValue = VwProgramacioncitadetMnt.Idmotivocita;


            iIdinventariostockdetserie.EditValue = VwInventariostockdetserie.Idinventariostockdetserie;
            VwInventariostock.Idinventariostock = VwInventariostockdetserie.Idinventariostock;
            iIdseriearticulo.EditValue = VwInventariostockdetserie.Idseriearticulo;
            rCodigointernoitem.EditValue = VwInventariostockdetserie.Codigointernoitem;

        }

        private void CargarReferencias()
        {
            string condicion = string.Format("idarticulo = {0}", VwInventariostock.Idarticulo); 
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

			        VwInventariostockdetserie.Idinventariostockdetserie = (int)iIdinventariostockdetserie.EditValue;
                    VwInventariostockdetserie.Idinventariostock = VwInventariostock.Idinventariostock;
                    VwInventariostockdetserie.Idseriearticulo = (int)iIdseriearticulo.EditValue;
                    VwInventariostockdetserie.Numeroserieitem = iIdseriearticulo.Text.Trim();
                    VwInventariostockdetserie.Codigointernoitem = rCodigointernoitem.Text.Trim();

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
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InventarioDetSerieMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            }
        }
    }
}