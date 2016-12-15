using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors.Controls;

namespace WinFormsApp
{
    public partial class Controles : Form
    {

        static readonly IService Service = new Service();
        public Controles()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm; 
            VwSocionegocio vwSocionegocioSel;

            switch (e.Button.Index)
            {
                case  0: //Buscar
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
                    socionegocioMntFrm = new SocionegocioMntFrm(0,TipoMantenimiento.Nuevo,null,null);
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
                    if (idSocioNegocioMnt != null && (int) idSocioNegocioMnt > 0)
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

        private void Asignar_Click(object sender, EventArgs e)
        {
            iIdsocionegocio.EditValue = 5;
        }

        private void iIdsocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioMnt = iIdsocionegocio.EditValue;
            if (idSocioNegocioMnt == null || (int) idSocioNegocioMnt <= 0) return;

            VwSocionegocio vwSocionegocioSel = Service.GetVwSocionegocio((int) idSocioNegocioMnt);
            if (vwSocionegocioSel != null)
            {
                beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
            }
        }
    }
}
