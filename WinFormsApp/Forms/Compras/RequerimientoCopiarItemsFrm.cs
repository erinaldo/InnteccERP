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
using DevExpress.XtraGrid.Views.Base;
using Utilities;

namespace WinFormsApp
{
    public partial class RequerimientoCopiarItemsFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwRequerimiento> _vwRequerimientoList;
        public VwRequerimiento VwRequerimientoSel { get; set; }

        private List<VwTipocp> _vwTipocpsList;
        public List<VwRequerimientodet> VwRequerimientodetACopiarList { get; set; }
        public List<VwRequerimientodet> VwRequerimientodetList { get; set; }
        private List<VwSucursal> VwSucursalList { get; set; }
        public List<VwRequerimientodet> VwRequerimientoComponenteList { get; set; }
        public string NumerordendetrabajoImportado { get; set; }
        public RequerimientoCopiarItemsFrm(List<VwRequerimientodet> vwRequerimientodetACopiarList, string numerordendetrabajoImportado)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwRequerimientodetACopiarList = vwRequerimientodetACopiarList;
            NumerordendetrabajoImportado = numerordendetrabajoImportado;
        }
        private void RequerimientoCopiarItemsFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

            //Valores por defectto
            //iIdsucursal.EditValue = UsuarioAutenticado.SucursalSel.Idsucursal;
            iIdsucursal.EditValue = 0;

            cboBuscarPor.SelectedIndex = 0; //Todos
        }
        private void CargarReferencias()
        {
            VwSucursalList = Service.GetAllVwSucursal("Nombresucursal");
            VwSucursal vwSucursal = new VwSucursal {
                Idsucursal = 0
                ,Codigosucursal  = "000"
                ,Nombresucursal = "(TODAS LAS SUCURSALES)"};

            VwSucursalList.Add(vwSucursal);

            iIdsucursal.Properties.DataSource = VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //iIdsucursal.EditValue = UsuarioAutenticado.SucursalSel.Idsucursal;
            //iIdsucursal.EditValue = 0;


        }
        private void CargarRequerimientos()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereReq = string.Empty;


            var idSucursalSel = iIdsucursal.EditValue;
            var whereSucursal = idSucursalSel == null || (int) idSucursalSel == 0 ? "0=0" : string.Format(" idsucursal = {0}", (int) idSucursalSel);

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereReq = whereSucursal;
                    break;
                case 1: //Requerimiento
                    whereReq = string.Format(@"idtipocp = {0} and seriereq = '{1}'
                        and numeroreq = '{2}' and {3}",
                        (int)iIdtipocp.EditValue,                        
                        rSeriereq.Text.Trim(),
                        iNumeroreq.Text.Trim(),
                        whereSucursal);
                    break;
            }


            _vwRequerimientoList = Service.GetAllVwRequerimiento(whereReq, "nombretipoformato,seriereq,numeroreq");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwRequerimientoList;
            gcConsulta.EndUpdate();
            gvConsulta.BestFitColumns();

            Cursor = Cursors.Default;
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            

            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                    VwRequerimientoSel = (VwRequerimiento)gvConsulta.GetFocusedRow();

                    foreach (var item in VwRequerimientodetList.Where(x => x.Itemseleccionado))
                    {
                        VwRequerimientodet vwRequerimientodet = new VwRequerimientodet();
                        vwRequerimientodet.Idrequerimiento = 0;
                        vwRequerimientodet.Numeroitem = 0;
                        vwRequerimientodet.Idarticulo = item.Idarticulo;
                        vwRequerimientodet.Codigoarticulo = item.Codigoarticulo;
                        vwRequerimientodet.Codigoproveedor = item.Codigoproveedor;
                        vwRequerimientodet.Idunidadmedida = item.Idunidadmedida;
                        vwRequerimientodet.Nombremarca = item.Nombremarca;
                        vwRequerimientodet.Nombrearticulo = item.Nombrearticulo;
                        vwRequerimientodet.Cantidad = item.Cantidadaimportar;
                        vwRequerimientodet.Cantidadinicial = item.Cantidadaimportar;
                        vwRequerimientodet.Idunidadmedida = item.Idunidadmedida;
                        vwRequerimientodet.Abrunidadmedida = item.Abrunidadmedida;
                        vwRequerimientodet.Preciounitario = item.Preciounitario;
                        vwRequerimientodet.Especificacion = item.Especificacion;
                        vwRequerimientodet.Importetotal = 0m;
                        vwRequerimientodet.Idimpuesto = item.Idimpuesto;

                        vwRequerimientodet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwRequerimientodet.Gravado = item.Gravado;
                        vwRequerimientodet.Exonerado = item.Exonerado;
                        vwRequerimientodet.Inafecto = item.Inafecto;
                        vwRequerimientodet.Exportacion = item.Exportacion;

                        vwRequerimientodet.Idcentrodecosto = item.Idcentrodecosto;
                        vwRequerimientodet.Codigocentrodecosto = item.Codigocentrodecosto;
                        vwRequerimientodet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwRequerimientodet.Porcentajepercepcion = 0m;
                        vwRequerimientodet.Idrequerimientodet = 0;
                        vwRequerimientodet.DataEntityState = DataEntityState.Added;

                        vwRequerimientodet.NumerordendetrabajoImportado = VwRequerimientoSel.Numerordendetrabajo;
                        TipoMnt = vwRequerimientodet.Idrequerimientodet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;

                        //Los items por defecto se calculan
                        vwRequerimientodet.Calcularitem = item.Calcularitem;

                        //Si es un articulo compuesto agregar detalle
                        if (vwRequerimientodet.Calcularitem)
                        {
                            AsignarDetalleDeArticulosCompuestos(item);
                        }

                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                vwRequerimientodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                                vwRequerimientodet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                vwRequerimientodet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                                vwRequerimientodet.Lastmodified = DateTime.Now;
                                break;
                        }



                        //sgtItem++;
                        VwRequerimientodetACopiarList.Add(vwRequerimientodet);

                        
                    }


                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarRequerimientos();
                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private void AsignarDetalleDeArticulosCompuestos(VwRequerimientodet vwRequerimientodetSel)
        {
            VwRequerimientoComponenteList = new List<VwRequerimientodet>();
            string whereArticulo = string.Format("idarticulo = {0}", vwRequerimientodetSel.Idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = 0;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwRequerimientodet vwRequerimientodet = new VwRequerimientodet();
                vwRequerimientodet.Numeroitem = numeroItem;
                vwRequerimientodet.Codigoarticulo = item.Codigoarticulo;
                vwRequerimientodet.Codigoproveedor = item.Codigoproveedor;
                vwRequerimientodet.Nombrearticulo = item.Nombrearticulo;
                vwRequerimientodet.Nombremarca = item.Nombremarca;
                vwRequerimientodet.Cantidad = item.Cantidaddetalle * vwRequerimientodetSel.Cantidad;
                vwRequerimientodet.Cantidadinicial = vwRequerimientodet.Cantidad;
                vwRequerimientodet.Preciounitario = 0m;
                vwRequerimientodet.Importetotal = 0m;
                vwRequerimientodet.Descripcioncentrodecosto = vwRequerimientodetSel.Descripcioncentrodecosto;
                vwRequerimientodet.Especificacion = string.Empty;
                vwRequerimientodet.Idarticulo = item.Idarticulodetalle;
                vwRequerimientodet.Idimpuesto = item.Idimpuesto;
                vwRequerimientodet.Idunidadmedida = item.Idunidadinventario;
                vwRequerimientodet.Abrunidadmedida = item.Abrunidadmedida;
                vwRequerimientodet.Idcentrodecosto = vwRequerimientodetSel.Idcentrodecosto;

                vwRequerimientodet.Codigocentrodecosto = vwRequerimientodetSel.Codigocentrodecosto;

                
                vwRequerimientodet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwRequerimientodet.Gravado = item.Gravado;
                vwRequerimientodet.Exonerado = item.Exonerado;
                vwRequerimientodet.Inafecto = item.Inafecto;
                vwRequerimientodet.Exportacion = item.Exportacion;
                vwRequerimientodet.Aprobado = true;
                vwRequerimientodet.Stock = 0m;//(decimal)iStock.EditValue;

                //Se estable a false no se calcula el item
                vwRequerimientodet.Calcularitem = false;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwRequerimientodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwRequerimientodet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwRequerimientodet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                        vwRequerimientodet.Lastmodified = DateTime.Now;
                        break;
                }


                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwRequerimientodet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwRequerimientodet.DataEntityState = DataEntityState.Modified;
                        break;
                }
                VwRequerimientoComponenteList.Add(vwRequerimientodet);
            }
        }
        private bool ValidacionDatosConsulta()
        {
            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    var idTipoCel = iIdtipocp.EditValue;

                    if (idTipoCel == null)
                    {
                        XtraMessageBox.Show("Seleccion el tipo de documento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iIdtipocp.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(iNumeroreq.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumeroreq.Focus();
                        return false;
                    }
                    break;
            }

            return true;
        }
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0 || gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información requerimientos, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            int cantidadItemsSeleccionados = VwRequerimientodetList.Count(x => x.Itemseleccionado);
            if (cantidadItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar los items a importar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            VwRequerimiento vwRequerimiento = (VwRequerimiento) gvConsulta.GetFocusedRow();
            List<VwRequerimientodet> vwRequerimientodetListValidacionOt = VwRequerimientodetACopiarList.Where(x => x.DataEntityState != DataEntityState.Deleted).ToList();
            if (vwRequerimientodetListValidacionOt.Count > 0 && vwRequerimiento.Numerordendetrabajo.Trim() != NumerordendetrabajoImportado.Trim())
            {                
                XtraMessageBox.Show("Ya seleccionar la OT " + NumerordendetrabajoImportado, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    if (string.IsNullOrEmpty(iNumeroreq.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumeroreq.Focus();
                        return false;                        
                    }      
                    break;
            }


            return true;
        }
        private void RequerimientoCopiarItemsFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwRequerimientodet itemSel = (VwRequerimientodet)gvDetalleImp.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Cantidadaimportar":
                    if (itemSel.Cantidadaimportar > itemSel.Cantidad)
                    {
                        XtraMessageBox.Show("Cantidad a copiar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Itemseleccionado = itemSel.Cantidadaimportar > 0;
                    }
                    gvDetalleImp.RefreshData();
                    break;
                case "Itemseleccionado":

                    itemSel.Cantidadaimportar = itemSel.Itemseleccionado ? itemSel.Cantidad : 0;

                    gvDetalleImp.RefreshData();
                    break;
            }
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvDetalleImp.PostEditor();

        }
        private void gvConsulta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleRequerimiento();
        }
        private void CargarDetalleRequerimiento()
        {
            VwRequerimiento vwRequerimientoSel = (VwRequerimiento)gvConsulta.GetFocusedRow();

            if (vwRequerimientoSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idrequerimiento = {0} and calcularitem = '1'", vwRequerimientoSel.Idrequerimiento);
                VwRequerimientodetList = Service.GetAllVwRequerimientodet(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = VwRequerimientodetList;
                gcDetalleImp.EndUpdate();

                foreach (var item in VwRequerimientodetList)
                {
                    item.Itemseleccionado = false;
                }

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                rSeriereq.EditValue = vwTipocp.Seriecp;
                rSeriereq.Properties.ReadOnly = true;
                iNumeroreq.Focus();
            }
            else
            {
                rSeriereq.EditValue = @"0000";
                iNumeroreq.EditValue = 0;
            }
        }
        private void cboBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipocp.Enabled = false;
            rSeriereq.Enabled = false;
            iNumeroreq.Enabled = false;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0: //Todos
                    break;
                case 1: //N° Requerimiento de compra
                    iIdtipocp.Enabled = true;
                    rSeriereq.Enabled = true;
                    iNumeroreq.Enabled = true;
                    iIdtipocp.Focus();
                    break;
            }
        }
        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in VwRequerimientodetList)
            {
                item.Itemseleccionado = chkSeleccionarTodo.Checked;
                item.Cantidadaimportar = chkSeleccionarTodo.Checked ? item.Cantidad : 0;
            }
            gvDetalleImp.RefreshData();
        }
        private void iIdsucursal_EditValueChanged(object sender, EventArgs e)
        {
            var idSucursal = iIdsucursal.EditValue;
            if (idSucursal != null && (int) idSucursal > 0)
            {
                cboBuscarPor.Enabled = true;
                iIdtipocp.Enabled = true;
                iNumeroreq.Enabled = true;

                string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "REQUERIMIENTO", (int)idSucursal);
                _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
                iIdtipocp.Properties.DataSource = _vwTipocpsList;
                iIdtipocp.Properties.DisplayMember = "Nombretipocp";
                iIdtipocp.Properties.ValueMember = "Idtipocp";
                iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
            }
            else
            {

                cboBuscarPor.Enabled = false;
                iIdtipocp.Enabled = false;                
                iNumeroreq.Enabled = false;

            }
        }
    }
}