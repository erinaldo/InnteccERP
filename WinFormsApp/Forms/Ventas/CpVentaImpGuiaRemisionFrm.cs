using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace WinFormsApp
{
    public partial class CpVentaImpGuiaRemisionFrm : XtraForm
    {
        static readonly IService Service = new Service();
        private List<VwTipocp> VwTipocpList { get; set; }
        private List<VwSocionegocioproyecto> VwSocionegocioproyectoList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public List<VwGuiaremisiondetimpcpventadet> VwGuiaremisiondetimpcpventadetList { get; set; }
        private List<VwCpventadet> VwCpventadetList { get; set; }
        private List<ItemGuiaRemisionCpVenta> ItemGuiaRemisionCpVentaList { get; set; }
        public CpVentaImpGuiaRemisionFrm(List<VwCpventadet> vwCpventadetList, VwSocionegocio vwSocionegocioSel)
        {
            InitializeComponent();
            VwCpventadetList = vwCpventadetList;
            VwSocionegocioSel = vwSocionegocioSel;

        }
        private void ValoresPorDefecto()
        {
            iIdalmacen.EditValue = SessionApp.SucursalSel.Idalmacendefecto;
        }
        private void CargarReferencias()
        {
            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDEN-VENTA", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacen.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void dgTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstablecerOpcionesDeBusqueda();
        }
        private void EstablecerOpcionesDeBusqueda()
        {
            iIdtipocp.Enabled = false;
            beSocioNegocio.Enabled = false;
            iIdproyecto.Enabled = false;
            rNumeroordenventa.Enabled = false;

            switch (dgTipoBusqueda.SelectedIndex)
            {
                case 0: //Orden de venta
                    iIdtipocp.Enabled = true;
                    rNumeroordenventa.Enabled = true;
                    break;
                case 1: //Cliente
                    beSocioNegocio.Enabled = true;
                    iIdproyecto.Enabled = true;
                    break;
            }
            gcGuiaRemision.DataSource = null;
            gcDetalle.DataSource = null;

            //Si se selecciono el cliente
            if (VwSocionegocioSel != null)
            {
                beSocioNegocio.Enabled = false;
            }
        }
        private void CpVentaImpGuiaRemisionFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            EstablecerOpcionesDeBusqueda();
            CargarSocioNegocioSeleccionado();
            ValoresPorDefecto();
        }
        private void CargarSocioNegocioSeleccionado()
        {
            if (VwSocionegocioSel != null)
            {
                CargarDatosSocioNegocio(VwSocionegocioSel.Idsocionegocio);
                beSocioNegocio.Enabled = false;
            }
            else
            {
                iIdcliente.EditValue = 0;
                beSocioNegocio.Text = string.Empty;
                iIdproyecto.Properties.DataSource = null;
                beSocioNegocio.Enabled = true;
            }
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                rSerieordenventa.EditValue = vwTipocp.Seriecp;
            }
            else
            {
                rSerieordenventa.EditValue = @"0000";
                rNumeroordenventa.EditValue = 0;
            }
            rNumeroordenventa.SelectAll();
            rNumeroordenventa.Select();
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {            
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        CargarDatosSocioNegocio(buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio);
                    }
                    break;
            }
        }
        private void CargarDatosSocioNegocio(int idSocioNegocio)
        {
            VwSocionegocioSel = Service.GetVwSocionegocio(idSocioNegocio);

            if (VwSocionegocioSel != null)
            {
                beSocioNegocio.Text = VwSocionegocioSel.Razonsocial.Trim();
                iIdcliente.EditValue = VwSocionegocioSel.Idsocionegocio;
                CargarProyectosCliente();
            }
        }
        private void CargarProyectosCliente()
        {
            if (VwSocionegocioSel != null)
            {
                string whereSocioNegocio = string.Format("idsocionegocio = '{0}'", VwSocionegocioSel.Idsocionegocio);
                VwSocionegocioproyectoList = Service.GetAllVwSocionegocioproyecto(whereSocioNegocio, "Nombreproyecto");
                VwSocionegocioproyecto vwSocionegocioproyecto = new VwSocionegocioproyecto
                {
                    Idproyecto = 0,
                    Codigoproyecto = "0000",
                    Nombreproyecto = "(TODOS)",

                };
                VwSocionegocioproyectoList.Add(vwSocionegocioproyecto);
                iIdproyecto.Properties.DataSource = VwSocionegocioproyectoList;
                iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
                iIdproyecto.Properties.ValueMember = "Idproyecto";
                iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

                if (VwSocionegocioproyectoList != null)
                {
                    iIdproyecto.EditValue = 0;
                }
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var idAlmacenSalida = iIdalmacen.EditValue;
            if (idAlmacenSalida == null)
            {
                XtraMessageBox.Show("Seleccione el almacen de salida", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                iIdalmacen.Select();
                return;
            }

            string condicionBusqueda = string.Empty;
            string camposOrden = "serienumeroordenventa,numeroitem";
            switch (dgTipoBusqueda.SelectedIndex)
            {
                case 0: //Orden de venta

                    //Validaciones
                    var idTipoCp = iIdtipocp.EditValue;
                    if (idTipoCp == null)
                    {
                        XtraMessageBox.Show("Seleccione el tipo de documento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        iIdtipocp.Select();
                        return;
                    }

                    if (int.Parse(rNumeroordenventa.Text.Trim()) == 0)
                    {
                        XtraMessageBox.Show("Ingrese un número de documento valido.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        rNumeroordenventa.Select();
                        return;
                    }

                    condicionBusqueda = string.Format(@"anulado = '0' 
                    and saldoaimportar > 0
                    and idsucursal = {0}
                    and idtipocp = {1} 
                    and serieordenventa = '{2}' 
                    and  numeroordenventa = '{3}'
                    and almacenorigen = '{4}'",
                    SessionApp.SucursalSel.Idsucursal,
                    (int)iIdtipocp.EditValue,
                    rSerieordenventa.Text.Trim(),
                    rNumeroordenventa.Text.Trim(),
                    (int)idAlmacenSalida);

                    break;
                case 1: //Cliente

                    int idSocioNegocio = (int)iIdcliente.EditValue;
                    if (idSocioNegocio == 0)
                    {
                        XtraMessageBox.Show("Seleccione el cliente.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        beSocioNegocio.Select();
                        return;
                    }

                    var idProyectoSel = iIdproyecto.EditValue;
                    if (idProyectoSel == null)
                    {
                        XtraMessageBox.Show("Ingrese un número de documento valido.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        iIdproyecto.Select();
                        return;
                    }

                    string condicionProyecto = (int) iIdproyecto.EditValue == 0 ? string.Empty : string.Format(" and idproyecto = '{0}'", (int) iIdproyecto.EditValue);

                    condicionBusqueda = string.Format(@"anulado = '0' 
                    and saldoaimportar > 0
                    and idsucursal = {0}
                    and idsocionegocio = {1} {2}
                    and almacenorigen = '{3}'",
                    SessionApp.SucursalSel.Idsucursal,
                    (int)iIdcliente.EditValue,
                    condicionProyecto,
                    (int)idAlmacenSalida);

                    break;
            }


            VwGuiaremisiondetimpcpventadetList = Service.GetAllVwGuiaremisiondetimpcpventadet(condicionBusqueda, camposOrden);
            gcGuiaRemision.DataSource = VwGuiaremisiondetimpcpventadetList;
        }
        private void gvGuiaRemision_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwGuiaremisiondetimpcpventadet itemSel = (VwGuiaremisiondetimpcpventadet)gvGuiaRemision.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Cantidadaimportar":
                    if (itemSel.Cantidadaimportar > itemSel.Saldoaimportar)
                    {
                        XtraMessageBox.Show("Cantidad a importar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Itemseleccionado = itemSel.Cantidadaimportar > 0;
                    }
                    gvGuiaRemision.RefreshData();
                    break;
                case "Itemseleccionado":

                    if (itemSel.Saldoaimportar == 0)
                    {
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Cantidadaimportar = itemSel.Itemseleccionado ? itemSel.Saldoaimportar : 0;
                    }
                    gvGuiaRemision.RefreshData();
                    break;
            }
        }
        private void riSeleccionado_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvGuiaRemision.PostEditor();
        }
        private void chkSeleccionarTodo_EditValueChanged(object sender, EventArgs e)
        {
            if (gvGuiaRemision.RowCount == 0) return;

            foreach (var item in VwGuiaremisiondetimpcpventadetList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvGuiaRemision.RefreshData();
        }
        private bool Validaciones()
        {
            if (gvGuiaRemision.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información de guias de remisión, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            int cantidadItemsSeleccionados = VwGuiaremisiondetimpcpventadetList.Count(x => x.Itemseleccionado);
            if (cantidadItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar los items a agregar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool ValidacionesImportacion()
        {
            if (gvDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay registros para importar, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        private void btnAgregarItems_Click(object sender, EventArgs e)
        {
            if (!Validaciones()) return;

            List<ItemGuiaRemisionCpVenta> itemsGuia = null;

            switch (rgTipoResumen.SelectedIndex)
            {

                case 0: //Resumido
                    itemsGuia = VwGuiaremisiondetimpcpventadetList.Where(x=>x.Itemseleccionado)
                    .Select(x =>
                        new ItemGuiaRemisionCpVenta
                        {
                            Codigoarticulo = x.Codigoarticulo,
                            Codigoproveedor = x.Codigoproveedor,
                            Nombrearticulo = x.Nombrearticulo,
                            Abrunidadmedida = x.Abrunidadmedida,
                            Preciounitario = x.Preciounitario,
                            Idarticulo = x.Idarticulo,
                            Nombremarca = x.Nombremarca,
                            Idunidadmedida = x.Idunidadmedida,
                            Cantidadaimportar = x.Cantidadaimportar,

                            Idimpuesto = x.Idimpuesto,
                            Idcentrodecosto = x.Idcentrodecosto,
                            Descripcioncentrodecosto = x.Descripcioncentrodecosto,
                            Porcentajepercepcion = x.Porcentajepercepcion,
                            Idarea = x.Idarea,
                            Nombrearea = x.Nombrearea,
                            Idproyecto = x.Idproyecto,
                            Nombreproyecto = x.Nombreproyecto,
                            Idtipoafectacionigv = x.Idtipoafectacionigv,
                            Gravado = x.Gravado,
                            Exonerado = x.Exonerado,
                            Inafecto = x.Inafecto,
                            Exportacion = x.Exportacion,
                            Calcularitem = x.Calcularitem

                        }
                     )
                     .GroupBy(s => new
                     {
                         s.Codigoarticulo,
                         s.Codigoproveedor,
                         s.Nombrearticulo,
                         s.Abrunidadmedida,
                         s.Preciounitario,
                         s.Idarticulo,
                         s.Nombremarca,
                         s.Idunidadmedida,

                         s.Idimpuesto,
                         s.Idcentrodecosto,
                         s.Descripcioncentrodecosto,
                         s.Porcentajepercepcion,
                         s.Idarea,
                         s.Nombrearea,
                         s.Idproyecto,
                         s.Nombreproyecto,
                         s.Idtipoafectacionigv,
                         s.Gravado,
                         s.Exonerado,
                         s.Inafecto,
                         s.Exportacion,
                         s.Calcularitem
                         
                     })
                     .Select(g =>
                            new ItemGuiaRemisionCpVenta
                            {
                                Codigoarticulo = g.Key.Codigoarticulo,
                                Codigoproveedor = g.Key.Codigoproveedor,
                                Nombrearticulo = g.Key.Nombrearticulo,
                                Abrunidadmedida = g.Key.Abrunidadmedida,
                                Preciounitario = g.Key.Preciounitario,
                                Idarticulo = g.Key.Idarticulo,
                                Nombremarca = g.Key.Nombremarca,
                                Idunidadmedida = g.Key.Idunidadmedida,

                                Idimpuesto = g.Key.Idimpuesto,
                                Idcentrodecosto = g.Key.Idcentrodecosto,
                                Descripcioncentrodecosto = g.Key.Descripcioncentrodecosto,
                                Porcentajepercepcion = g.Key.Porcentajepercepcion,
                                Idarea = g.Key.Idarea,
                                Nombrearea = g.Key.Nombrearea,
                                Idproyecto = g.Key.Idproyecto,
                                Nombreproyecto = g.Key.Nombreproyecto,
                                Idtipoafectacionigv = g.Key.Idtipoafectacionigv,
                                Gravado = g.Key.Gravado,
                                Exonerado = g.Key.Exonerado,
                                Inafecto = g.Key.Inafecto,
                                Exportacion = g.Key.Exportacion,
                                Calcularitem = g.Key.Calcularitem,
                                Cantidadaimportar = g.Sum(x => x.Cantidadaimportar)
                            }
                     ).ToList();
                    break;
                case 1: //Detallado
                    itemsGuia = VwGuiaremisiondetimpcpventadetList.Where(x => x.Itemseleccionado)
                                 .Select(x =>
                                     new ItemGuiaRemisionCpVenta
                                     {
                                         Codigoarticulo = x.Codigoarticulo,
                                         Codigoproveedor = x.Codigoproveedor,
                                         Nombrearticulo = x.Nombrearticulo,
                                         Abrunidadmedida = x.Abrunidadmedida,
                                         Preciounitario = x.Preciounitario,
                                         Idarticulo = x.Idarticulo,
                                         Nombremarca = x.Nombremarca,
                                         Idunidadmedida = x.Idunidadmedida,
                                         Cantidadaimportar = x.Cantidadaimportar,
                                         Idimpuesto = x.Idimpuesto,
                                         Idcentrodecosto = x.Idcentrodecosto,
                                         Descripcioncentrodecosto = x.Descripcioncentrodecosto,
                                         Porcentajepercepcion = x.Porcentajepercepcion,
                                         Idarea = x.Idarea,
                                         Nombrearea = x.Nombrearea,
                                         Idproyecto = x.Idproyecto,
                                         Nombreproyecto = x.Nombreproyecto,
                                         Idtipoafectacionigv = x.Idtipoafectacionigv,
                                         Gravado = x.Gravado,
                                         Exonerado = x.Exonerado,
                                         Inafecto = x.Inafecto,
                                         Exportacion = x.Exportacion
                                     }
                                  ).ToList();
                    break;
            }

            if (itemsGuia != null)
            {
                //Enumerar
                int numeracion = 1;
                foreach (var item in itemsGuia)
                {
                    item.Numeroitem = numeracion;
                    numeracion++;
                }

                ItemGuiaRemisionCpVentaList = itemsGuia;
                gcDetalle.DataSource = null;
                gcDetalle.DataSource = ItemGuiaRemisionCpVentaList;
                gcDetalle.RefreshDataSource();

                iIdalmacen.Enabled = false;
            }


        }
        private void rgTipoResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            gcDetalle.DataSource = null;
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (!ValidacionesImportacion()) return;

            foreach (var item in ItemGuiaRemisionCpVentaList)
            {
                VwCpventadet vwCpventadet = new VwCpventadet();
                vwCpventadet.Numeroitem = item.Numeroitem;
                vwCpventadet.Idarticulo = item.Idarticulo;
                vwCpventadet.Codigoarticulo = item.Codigoarticulo;
                vwCpventadet.Codigoproveedor = item.Codigoproveedor;
                vwCpventadet.Idunidadmedida = item.Idunidadmedida;
                vwCpventadet.Nombremarca = item.Nombremarca;
                vwCpventadet.Nombrearticulo = item.Nombrearticulo;
                vwCpventadet.Cantidad = item.Cantidadaimportar;
                vwCpventadet.Idunidadmedida = item.Idunidadmedida;
                vwCpventadet.Abrunidadmedida = item.Abrunidadmedida;
                vwCpventadet.Preciounitario = item.Preciounitario;
                vwCpventadet.Especificacion = string.Empty;
                vwCpventadet.Descuento1 = 0m;
                vwCpventadet.Descuento2 = 0m;
                vwCpventadet.Descuento3 = 0m;
                vwCpventadet.Descuento4 = 0m;
                vwCpventadet.Preciounitarioneto = item.Preciounitario;
                vwCpventadet.Importetotal = 0m;
                vwCpventadet.Idimpuesto = item.Idimpuesto;
                vwCpventadet.Idcentrodecosto = item.Idcentrodecosto;
                vwCpventadet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                vwCpventadet.Porcentajepercepcion = item.Porcentajepercepcion;
                vwCpventadet.Idarea = item.Idarea;
                vwCpventadet.Nombrearea = item.Nombrearea;
                vwCpventadet.Idproyecto = item.Idproyecto;
                vwCpventadet.Nombreproyecto = item.Nombreproyecto;
                vwCpventadet.Idordendeventadet = null;
                vwCpventadet.Serienumeroordenventa = string.Empty;
                vwCpventadet.Idalmacen = (int) iIdalmacen.EditValue;
                vwCpventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwCpventadet.Gravado = item.Gravado;
                vwCpventadet.Exonerado = item.Exonerado;
                vwCpventadet.Inafecto = item.Inafecto;
                vwCpventadet.Exportacion = item.Inafecto;
                vwCpventadet.Calcularitem = item.Calcularitem;
                vwCpventadet.DataEntityState = DataEntityState.Added;                

                VwCpventadetList.Add(vwCpventadet);
            }
            DialogResult = DialogResult.OK;
        }
    }
}