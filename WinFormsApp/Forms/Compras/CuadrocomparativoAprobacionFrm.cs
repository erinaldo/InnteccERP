using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using Utilities;

namespace WinFormsApp
{
    public partial class CuadrocomparativoAprobacionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();
        public VwRequerimientodet VwRequerimientodet { get; set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwCuadrocomparativo VwCuadrocomparativoSel { get; set; }
        public ParametrosCuadrocomparativo Parametros { get; set; }
        public List<Estadoreq> EstadoreqList { get; set; }
        public CuadrocomparativoAprobacionFrm(ParametrosCuadrocomparativo parametros)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            Parametros = parametros;

        }
        private void CuadrocomparativoAprobacionFrm_Load(object sender, EventArgs e)
        {
            CargarRequerimientos();
          //  CargarReferencias();

            switch (Parametros.TipoConsultaReq)
            {
                case 0: //Pendiente de aprobacion
                    Text = @"Listado de Estudio de Mercado pendientes de aprobación";
                    break;
                case 1: //Req Aproados
                    Text = @"Listado de Estudio de Mercado aprobados";
                    break;
            }
        }
        private void CargarRequerimientos()
        {

           
            rTotaldocumento.EditValue = 0m;


            iGlosareq.Text = string.Empty;
            iObservacionReq.Text = string.Empty;

            Cursor = Cursors.WaitCursor;
            gcConsulta.DataSource = null;
           
            gcConsulta.BeginUpdate();

            //idestadoreq = 2 (pendientes de aprobacion)

            string where = string.Format("idsucursal = {0} and Idresponsable = {1} and idestadocuadrocomparativo = {2} and idempleadoaprueba = {3}",
            Parametros.IdSucursal,
            Parametros.IdEmpleado,
            Parametros.IdEstadoReq,
            Parametros.IdEmpleadoLogeado);

            var resul = Service.GetAllVwCuadrocomparativo(where, "nombretipoformato,seriecc,numerocc");
            gcConsulta.DataSource = resul;

            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();

            Cursor = Cursors.Default; 
        }
        private void CargarReferencias()
        {
            VwCuadrocomparativo vwCuadrocomparativo = (VwCuadrocomparativo)gvConsulta.GetFocusedRow();
            if (vwCuadrocomparativo != null)
            {
                Parametros.Idcptooperacion = vwCuadrocomparativo.Idcptooperacion ?? 0;
                //Obtener el empleado que aprueba modelo de autorizacion
                int idEmpleadoApruebaModelo = Service.ObtenerIdEmpleadoApruebaModeloAutorizacion(Parametros.Idtipodocmov, Parametros.Idcptooperacion, (decimal)rTotaldocumento.EditValue);
                string whereEstadoReq = Parametros.IdEmpleadoLogeado == idEmpleadoApruebaModelo ? "idestadoreq IN (1,3,4)" : "idestadoreq IN (1,4,5)";
                EstadoreqList = Service.GetAllEstadoreq(whereEstadoReq, "idestadoreq");
                iIdestadoreq.Properties.DataSource = EstadoreqList;
                iIdestadoreq.Properties.DisplayMember = "Nombreestadoreq";
                iIdestadoreq.Properties.ValueMember = "Idestadoreq";
                iIdestadoreq.Properties.BestFitMode = BestFitMode.BestFit;
            }

        }
        private void gvConsulta_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwCuadrocomparativo vwCuadrocomparativo = (VwCuadrocomparativo)gvConsulta.GetRow(e.FocusedRowHandle);
            if (vwCuadrocomparativo != null)
            {

                VwCuadrocomparativoSel = vwCuadrocomparativo;
                iGlosareq.EditValue = vwCuadrocomparativo.Observacion;
                rTotaldocumento.EditValue = vwCuadrocomparativo.Totalbuenapro;

                //CargarDetalle(vwCuadrocomparativo.Idcuadrocomparativo);
                CargarReferencias();

                if (vwCuadrocomparativo.Idempleadoaprueba == 5) //Preaprobado
                {
                    Estadoreq estadoReqPreaprobado = EstadoreqList.FirstOrDefault(x => x.Idestadoreq == 5);
                    if (estadoReqPreaprobado != null)
                    {
                        EstadoreqList.Remove(estadoReqPreaprobado);
                        iIdestadoreq.Refresh();
                    }
                }
            }

        }
        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {

            switch (Parametros.TipoConsultaReq)
            {
                case 0: //Pendiente de aprobacion
                    break;
                case 1: //Req Aproados
                    //if (Service.RequerimientoTieneReferenciasOrdenDeCompra(VwCuadrocomparativoSel.Idcuadrocomparativo))
                    //{
                    //    XtraMessageBox.Show("Requerimiento ya tiene referencia en ordenes de compra.", "Atención",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    break;
            }
            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("No hay requerimientos pendientes de aprobación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("El requerimiento no tiene items.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var idEstadoSel = iIdestadoreq.EditValue;

            if (idEstadoSel == null)
            {
                XtraMessageBox.Show("Seleccione el estado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            switch (Parametros.IdEstadoReq)
            {
                case 0: // Pendientes de Aprobacion

                    //if (Service.RequerimientoAprobado(VwCuadrocomparativoSel.Idcuadrocomparativo))
                    //{
                    //    XtraMessageBox.Show("Requerimiento ya esta aprobado.", "Atención", MessageBoxButtons.OK,
                    //        MessageBoxIcon.Exclamation);

                    //    CargarRequerimientos();
                    //    return;
                    //}
                    break;
                case 1: // Aprobados

                    break;

            }                    

            if (DialogResult.Yes == XtraMessageBox.Show("Desea actualizar el estado del requerimiento",
                                                     "Atención", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                Cuadrocomparativo cuadrocomparativo = Service.GetCuadrocomparativo(x => x.Idcuadrocomparativo == VwCuadrocomparativoSel.Idcuadrocomparativo);

                if (cuadrocomparativo != null)
                {

                    int idCuadrocomparativo = cuadrocomparativo.Idcuadrocomparativo;
                    cuadrocomparativo.Totalbuenapro = (decimal)rTotaldocumento.EditValue;
                    cuadrocomparativo.Idestadocuadrocomparativo = (int)iIdestadoreq.EditValue;
                    //IdEstadoreq: 3 (Aprobado)
                    cuadrocomparativo.Fechaaprobacion = (int) idEstadoSel == 3 ? (DateTime?) DateTime.Now : null;
                    cuadrocomparativo.Idempleadoaprueba = SessionApp.UsuarioSel.Idusuario;
                    cuadrocomparativo.Observacionaprobacion = iObservacionReq.Text.Trim();

                    Service.UpdateCuadrocomparativo(cuadrocomparativo);

                   

                    if ((int)idEstadoSel == 3 || (int)idEstadoSel == 5) //Cuando este aprobado o desaprobado
                    {
                        Tipocp tipocpReq = Service.GetTipocp(x => x.Idtipocp == cuadrocomparativo.Idtipocp);
                        if (tipocpReq != null)
                        {
                            //Insertar informacion de aprobacion de documento
                            Documentoaprobacion documentoaprobacionReq = new Documentoaprobacion
                            {
                                Idtipodocmov = tipocpReq.Idtipodocmov,
                                Iddocumentomov = cuadrocomparativo.Idcuadrocomparativo,
                                Empleadoaprueba = SessionApp.EmpleadoSel.Idempleado,
                                Fechaaprobacion = DateTime.Now,
                                Aprobado = true,
                                Comentario = iObservacionReq.Text.Trim()
                            };
                            int iddocumentoaprobacion = Service.SaveDocumentoaprobacion(documentoaprobacionReq);
                            if (iddocumentoaprobacion > 0)
                            {
                            }
                        }
                    }

                    //Si se cambia a registrado o desaprobado eliminar registros de documentoaprobacion
                    if ((int)idEstadoSel == 1 || (int)idEstadoSel == 4 && idCuadrocomparativo > 0)
                    {
                        //23: CUADROCC
                        Service.EliminarReferenciasDocumentoAprobacion(23, idCuadrocomparativo);
                    }

                    CargarRequerimientos();
                }
            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarRequerimientos();
        }
        private void CuadrocomparativoAprobacionFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void tcRequerimientos_MouseUp(object sender, MouseEventArgs e)
        {
            XtraTabControl xtc = sender as XtraTabControl;

            Point pos = new Point(e.X, e.Y);

            if (xtc != null)
            {
                DevExpress.XtraTab.ViewInfo.XtraTabHitInfo xthi = xtc.CalcHitInfo(pos);

                //MessageBox.Show(tp + " is clicked!", "xtraTabControl1_MouseUp");
                if (xthi != null && xthi.Page.Name == "tpEstadoAprobacion")
                {
                    if (VwCuadrocomparativoSel != null)
                    {
                        string whereReq = string.Format("iddocumentomov = {0} and idtipodocmov = {1}",
                        VwCuadrocomparativoSel.Idcuadrocomparativo, VwCuadrocomparativoSel.Idtipodocmov);
                        gvHistorialAproReq.BeginUpdate();
                        gcHistorialAproReq.DataSource = Service.GetAllVwDocumentoaprobacion(whereReq, "fechaaprobacion desc");
                        gvHistorialAproReq.EndDataUpdate();
                        gvHistorialAproReq.BestFitColumns(true);
                    }
                    else
                    {
                        gcHistorialAproReq.DataSource = null;
                    }
                }
            }
        }
    }
}