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
    public partial class RequerimientoAprobacionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();
        public VwRequerimientodet VwRequerimientodet { get; set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public VwRequerimiento VwRequerimientoSel { get; set; }
        public ParametrosRequerimiento Parametros { get; set; }
        public List<Estadoreq> EstadoreqList { get; set; }
        public RequerimientoAprobacionFrm(ParametrosRequerimiento parametros)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            Parametros = parametros;

        }
        private void RequerimientoAprobacionFrm_Load(object sender, EventArgs e)
        {
            CargarRequerimientos();
          //  CargarReferencias();

            switch (Parametros.TipoConsultaReq)
            {
                case 0: //Pendiente de aprobacion
                    Text = @"Listado de requerimientos pendientes de aprobación";
                    break;
                case 1: //Req Aproados
                    Text = @"Listado de requerimientos aprobados";
                    break;
            }
        }
        private void CargarRequerimientos()
        {

            rTotalbruto.EditValue = 0m;
            rTotalgravado.EditValue = 0m;
            rTotalinafecto.EditValue = 0m;
            rtotalexonerado.EditValue = 0m;
            rTotalimpuesto.EditValue = 0m;
            rImportetotal.EditValue = 0m;
            rPorcentajepercepcion.EditValue = 0m;
            rImportetotalpercepcion.EditValue = 0m;
            rTotaldocumento.EditValue = 0m;


            iGlosareq.Text = string.Empty;
            iObservacionReq.Text = string.Empty;

            Cursor = Cursors.WaitCursor;
            gcConsulta.DataSource = null;
            gcDetalle.DataSource = null;
            gcConsulta.BeginUpdate();

            //idestadoreq = 2 (pendientes de aprobacion)

            string where = string.Format("idsucursal = {0} and idarea = {1} and idproyecto = {2} and idempleado = {3} and idestadoreq = {4} and idempleadoaprueba = {5}",
            Parametros.IdSucursal,
            Parametros.IdArea,
            Parametros.IdProyecto,
            Parametros.IdEmpleado,
            Parametros.IdEstadoReq,
            Parametros.IdEmpleadoLogeado);

            var resul = Service.GetAllVwRequerimiento(where, "nombretipoformato,seriereq,numeroreq");
            gcConsulta.DataSource = resul;

            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();

            Cursor = Cursors.Default; 
        }
        private void CargarReferencias()
        {
            
            VwRequerimiento vwRequerimiento = (VwRequerimiento)gvConsulta.GetFocusedRow();
            if (vwRequerimiento != null)
            {
                Parametros.Idcptooperacion = vwRequerimiento.Idcptooperacion ?? 0;
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
            VwRequerimiento vwRequerimiento = (VwRequerimiento) gvConsulta.GetRow(e.FocusedRowHandle);
            if (vwRequerimiento != null)
            {
                VwRequerimientoSel = vwRequerimiento;
                iGlosareq.EditValue = vwRequerimiento.Glosareq;
                CargarDetalle(vwRequerimiento.Idrequerimiento);
                CargarReferencias();

                if (vwRequerimiento.Idestadoreq == 5) //Preaprobado
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
        private void CargarDetalle(int idRequerimiento)
        {
            string where = string.Format("idrequerimiento = '{0}'", idRequerimiento);
            gcDetalle.BeginUpdate();
            VwRequerimientodetList = Service.GetAllVwRequerimientodet(where, "numeroitem");
            gcDetalle.DataSource = VwRequerimientodetList;
            SumarTotales();
            gvDetalle.BestFitColumns();
            gcDetalle.EndUpdate();

        }
        private void SumarTotales()
        {
            gvDetalle.BeginDataUpdate();
            gvDetalle.RefreshData();
            

            decimal totalbruto = VwRequerimientodetList.Where(w => w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Cantidad * s.Preciounitario);
            rTotalbruto.EditValue = totalbruto;
            decimal totalgravado = VwRequerimientodetList.Where(w => w.Gravado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalinafecto = VwRequerimientodetList.Where(w => w.Inafecto && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            decimal totalexonerado = VwRequerimientodetList.Where(w => w.Exonerado && w.DataEntityState != DataEntityState.Deleted && w.Calcularitem).Sum(s => s.Importetotal);
            //Impuesto impuestoSel = ImpuestoList.FirstOrDefault(x => x.Idimpuesto == (int)iIdimpuesto.EditValue);
            if (VwRequerimientoSel != null)
            {
                decimal porcentajeImpuesto = VwRequerimientoSel.Porcentajeimpuesto;
                decimal factorImpuesto = 1 + (porcentajeImpuesto / 100);

                //sumart total percepcion gravados de impuesto
                decimal totalValorPercepcion = VwRequerimientodetList.Where(
                    w => w.DataEntityState != DataEntityState.Deleted
                    && w.Porcentajepercepcion > 0
                    && w.Gravado
                    && w.Calcularitem).Sum(s => s.Importetotal * (s.Porcentajepercepcion / 100));

                rPorcentajepercepcion.EditValue = totalValorPercepcion > 0 ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;

                rImportetotalpercepcion.EditValue = decimal.Round(VwRequerimientoSel.Incluyeimpuestoitems ? totalValorPercepcion : totalValorPercepcion * factorImpuesto, 2);
                rTotalgravado.EditValue = decimal.Round(VwRequerimientoSel.Incluyeimpuestoitems ? totalgravado / factorImpuesto : totalgravado, 2);
                rTotalinafecto.EditValue = decimal.Round(VwRequerimientoSel.Incluyeimpuestoitems ? totalinafecto / factorImpuesto : totalinafecto, 2);
                rtotalexonerado.EditValue = decimal.Round(VwRequerimientoSel.Incluyeimpuestoitems ? totalexonerado / factorImpuesto : totalexonerado, 2);

                rTotalimpuesto.EditValue = decimal.Round(VwRequerimientoSel.Incluyeimpuestoitems ? totalgravado - (decimal)rTotalgravado.EditValue : totalgravado * porcentajeImpuesto / 100, 2);
                rImportetotal.EditValue = (decimal)rTotalgravado.EditValue + (decimal)rTotalinafecto.EditValue + (decimal)rtotalexonerado.EditValue + +(decimal)rTotalimpuesto.EditValue;
                rTotaldocumento.EditValue = (decimal)rImportetotal.EditValue + (decimal)rImportetotalpercepcion.EditValue;
            }

            gvDetalle.EndDataUpdate();
            gvDetalle.BestFitColumns(true);
        }
        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwRequerimientodet vwRequerimientodet = (VwRequerimientodet)gvDetalle.GetFocusedRow();
            switch (e.Column.FieldName)
            {
                case "Cantidad":
                case "Preciounitario":
                case "Porcentajepercepcion":
                    CalculaItem();
                    break;
                case "Aprobado":
                    vwRequerimientodet.DataEntityState = DataEntityState.Modified;
                    gvDetalle.UpdateCurrentRow();
                    CalculaItem();
                    break;

            }             
        }
        private void CalculaItem()
        {
            VwRequerimientodet item = (VwRequerimientodet)gvDetalle.GetFocusedRow();

            TipoMantenimiento tipoMnt = item.Idrequerimientodet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;

            switch (tipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    item.Createdby = SessionApp.UsuarioSel.Idusuario;
                    item.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    item.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                    item.Lastmodified = DateTime.Now;
                    break;
            }

            item.Importetotal = item.Cantidad * item.Preciounitario;
            item.DataEntityState = DataEntityState.Modified;

            //Actualizar la cantidad inicial mientras el estado del requerimiento este en registrado
            Estadoreq estadoreq = Service.GetEstadoRequerimiento(IdEntidadMnt);
            if (estadoreq != null && estadoreq.Idestadoreq == 1)
            {
                item.Cantidadinicial = item.Cantidad;
            }

            SumarTotales();
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            gvDetalle.PostEditor();
        }
        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {

            switch (Parametros.TipoConsultaReq)
            {
                case 0: //Pendiente de aprobacion
                    break;
                case 1: //Req Aproados
                    if (Service.RequerimientoTieneReferenciasOrdenDeCompra(VwRequerimientoSel.Idrequerimiento))
                    {
                        XtraMessageBox.Show("Requerimiento ya tiene referencia en ordenes de compra.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    break;
            }
            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("No hay requerimientos pendientes de aprobación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (gvDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("El requerimiento no tiene items.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int totalItemsSeleccionados = VwRequerimientodetList.Count(x => x.Aprobado);

            if (totalItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar items a aprobar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    if (Service.RequerimientoAprobado(VwRequerimientoSel.Idrequerimiento))
                    {
                        XtraMessageBox.Show("Requerimiento ya esta aprobado.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                        CargarRequerimientos();
                        return;
                    }
                    break;
                case 1: // Aprobados

                    break;

            }                    

            if (DialogResult.Yes == XtraMessageBox.Show("Desea actualizar el estado del requerimiento",
                                                     "Atención", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                Requerimiento requerimiento = Service.GetRequerimiento(x => x.Idrequerimiento == VwRequerimientoSel.Idrequerimiento);

                if (requerimiento != null)
                {
                    int idRequerimientoSel = requerimiento.Idrequerimiento;
                    requerimiento.Totalbruto = (decimal)rTotalbruto.EditValue;
                    requerimiento.Totalgravado = (decimal)rTotalgravado.EditValue;
                    requerimiento.Totalinafecto = (decimal)rTotalinafecto.EditValue;
                    requerimiento.Totalexonerado = (decimal)rtotalexonerado.EditValue;
                    requerimiento.Totalimpuesto = (decimal)rTotalimpuesto.EditValue;
                    requerimiento.Importetotal = (decimal)rImportetotal.EditValue;
                    requerimiento.Porcentajepercepcion = (decimal)rPorcentajepercepcion.EditValue;
                    requerimiento.Importetotalpercepcion = (decimal)rImportetotalpercepcion.EditValue;
                    requerimiento.Totaldocumento = (decimal)rTotaldocumento.EditValue;

                    requerimiento.Idestadoreq = (int)iIdestadoreq.EditValue;

                    //IdEstadoreq: 3 (Aprobado)

                    requerimiento.Fechaaprobacion = (int) idEstadoSel == 3 ? (DateTime?) DateTime.Now : null;

                    requerimiento.Idempleadoaprueba = SessionApp.UsuarioSel.Idusuario;
                    requerimiento.Observacionaprobacion = iObservacionReq.Text.Trim();

                    Service.UpdateRequerimiento(requerimiento);

                    foreach (var item in VwRequerimientodetList)
                    {
                        ////Eliminar los desaprobado
                        //if (!item.Itemseleccionado)
                        //{
                        //    Service.DeleteRequerimientodet(item.Idrequerimientodet);
                        //}

                        //Si se modifico la cantidad
                        if (item.DataEntityState == DataEntityState.Modified && item.Itemseleccionado)
                        {
                            Requerimientodet itemRedDet = Service.GetRequerimientodet(item.Idrequerimientodet);
                            itemRedDet.Cantidad = item.Cantidad;
                            itemRedDet.Importetotal = item.Importetotal;
                            itemRedDet.Aprobado = item.Aprobado;
                            Service.UpdateRequerimientodet(itemRedDet);
                        }
                    }

                    if ((int)idEstadoSel == 3 || (int)idEstadoSel == 5) //Cuando este aprobado o desaprobado
                    {
                        Tipocp tipocpReq = Service.GetTipocp(x => x.Idtipocp == requerimiento.Idtipocp);
                        if (tipocpReq != null)
                        {
                            //Insertar informacion de aprobacion de documento
                            Documentoaprobacion documentoaprobacionReq = new Documentoaprobacion
                            {
                                Idtipodocmov = tipocpReq.Idtipodocmov,
                                Iddocumentomov = requerimiento.Idrequerimiento,
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
                    if ((int) idEstadoSel == 1 || (int) idEstadoSel == 4 && idRequerimientoSel > 0)
                    {
                        //3:REQUERIMIENTO
                        Service.EliminarReferenciasDocumentoAprobacion(3, idRequerimientoSel);
                    }
                    CargarRequerimientos();
                }
            }

        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarRequerimientos();
        }
        private void RequerimientoAprobacionFrm_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (VwRequerimientoSel != null)
                    {
                        string whereReq = string.Format("iddocumentomov = {0} and idtipodocmov = {1}",
                        VwRequerimientoSel.Idrequerimiento, VwRequerimientoSel.Idtipodocmov);
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

        private void riCalcularItem_EditValueChanged(object sender, EventArgs e)
        {
            gvDetalle.PostEditor();
        }
    }
}