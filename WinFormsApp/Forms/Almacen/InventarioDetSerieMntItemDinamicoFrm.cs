using System;
using System.Collections.Generic;
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
    public partial class InventarioDetSerieMntItemDinamicoFrm : XtraForm
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

        public InventarioDetSerieMntItemDinamicoFrm(TipoMantenimiento tipoMnt, VwInventariostock inventariostock, VwInventariostockdetserie vwInventariostockdetserie)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwInventariostock = inventariostock;
            VwInventariostockdetserie = vwInventariostockdetserie;

        }

        private void InventarioDetSerieMntItemDinamicoFrm_Load(object sender, EventArgs e)
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
            iNumeroserieitem.EditValue = VwInventariostockdetserie.Numeroserieitem;
            iCodigointernoitem.EditValue = VwInventariostockdetserie.Codigointernoitem;
            iIdseriearticulo.EditValue = VwInventariostockdetserie.Idseriearticulo;
            iFecharegistro.EditValue = VwInventariostockdetserie.Fecharegistro;

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



                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:

                            Seriearticulo seriearticuloNuevo = new Seriearticulo();
                            seriearticuloNuevo.Idseriearticulo = 0;
                            seriearticuloNuevo.Numeroserieitem = iNumeroserieitem.Text.Trim();
                            seriearticuloNuevo.Codigointernoitem = iCodigointernoitem.Text.Trim();
                            seriearticuloNuevo.Fecharegistro = (DateTime?)iFecharegistro.EditValue;
                            

                            int idseriearticulonew = Service.SaveSeriearticulo(seriearticuloNuevo);
                            if (idseriearticulonew > 0)
                            {
                                Articuloseriedet articuloseriedet = new Articuloseriedet();
                                articuloseriedet.Idarticuloseriedet = 0;
                                articuloseriedet.Idarticulo = VwInventariostock.Idarticulo;
                                articuloseriedet.Idseriearticulo = idseriearticulonew;
                                int idarticuloseriedet = Service.SaveArticuloseriedet(articuloseriedet);

                                if (idseriearticulonew > 0 && idarticuloseriedet > 0)
                                {
                                    VwInventariostockdetserie.Idinventariostockdetserie = (int)iIdinventariostockdetserie.EditValue;
                                    VwInventariostockdetserie.Idinventariostock = VwInventariostock.Idinventariostock;
                                    VwInventariostockdetserie.Idseriearticulo = idseriearticulonew;
                                    VwInventariostockdetserie.Numeroserieitem = iNumeroserieitem.Text.Trim();
                                    VwInventariostockdetserie.Codigointernoitem = iCodigointernoitem.Text.Trim();
                                    VwInventariostockdetserie.Fecharegistro = (DateTime?)iFecharegistro.EditValue;
                                }
                            }


                            break;
                        case TipoMantenimiento.Modificar:


                            Seriearticulo seriearticuloModificar = new Seriearticulo();
                            seriearticuloModificar.Idseriearticulo = (int)iIdseriearticulo.EditValue;
                            seriearticuloModificar.Numeroserieitem = iNumeroserieitem.Text.Trim();
                            seriearticuloModificar.Codigointernoitem = iCodigointernoitem.Text.Trim();
                            seriearticuloModificar.Fecharegistro = (DateTime?)iFecharegistro.EditValue;

                            if (seriearticuloModificar.Idseriearticulo > 0)
                            {
                                Service.UpdateSeriearticulo(seriearticuloModificar);

                                VwInventariostockdetserie.Idinventariostockdetserie = (int)iIdinventariostockdetserie.EditValue;
                                VwInventariostockdetserie.Idinventariostock = VwInventariostock.Idinventariostock;
                                VwInventariostockdetserie.Idseriearticulo = (int)iIdseriearticulo.EditValue;
                                VwInventariostockdetserie.Numeroserieitem = iNumeroserieitem.Text.Trim();
                                VwInventariostockdetserie.Codigointernoitem = iCodigointernoitem.Text.Trim();
                                VwInventariostockdetserie.Fecharegistro = (DateTime?) iFecharegistro.EditValue;
                            }


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

            if (TipoMnt == TipoMantenimiento.Nuevo)
            {
                if (Service.SerieArticuloExiste(iNumeroserieitem.Text.Trim()))
                {
                    XtraMessageBox.Show("El Nº de serie ya existe, verifique", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }               
            }
            return true;
        }

        private void InventarioDetSerieMntItemDinamicoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}