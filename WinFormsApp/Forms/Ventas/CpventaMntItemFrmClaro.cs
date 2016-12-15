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
    public partial class CpventaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwCpventadet VwCpventadetMnt { get; set; }
        public List<Tipoafectacionigv> TipoafectacionigvList { get; set; }
        public VwArticulo VwArticuloSel { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        private List<VwProyecto> VwProyectoList { get; set; }
        public List<VwCpventadet> VwCpventadetdetComponenteList { get; set; }
        public List<VwCpventadet> VwCpventadetList { get; set; }
        CpVentaItem CpVentaItemParameter { get; set; }
        public List<VwUbicacion> UbicacionList { get; set; }
        public UserAudit UserAudit { get; set; }
        public List<Almacen> AlmacenList { get; set; }
        public List<VwArticuloseriedet> VwArticuloseriedetList { get; set; }
        public CpventaMntItemFrm(TipoMantenimiento tipoMnt, VwCpventadet vwCpventadetMnt, List<VwCpventadet> vwCpventadetList, CpVentaItem cpVentaItemParameter)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCpventadetMnt = vwCpventadetMnt;
            VwCpventadetList = vwCpventadetList;
            CpVentaItemParameter = cpVentaItemParameter;
            UserAudit = new UserAudit();
        }
        private void CpventaMntItemFrm_Load(object sender, EventArgs e)
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
                    var idAlmacen = iIdalmacen.EditValue;
                    if (idAlmacen != null)
                    {
                        BuscarArticulo();
                        iIdcentrodecosto.Select();
                    }
                    else
                    {
                        iIdalmacen.Select();
                    }
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    //ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            iNombrearticulo.Select();
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = VwCpventadetMnt.Numeroitem;            
            iIdalmacen.EditValue = CpVentaItemParameter.IdAlmacenConsulta;

            if (VwCpventadetList.Count(x => x.DataEntityState != DataEntityState.Deleted) == 0)
            {
                iIdcentrodecosto.EditValue = CpVentaItemParameter.IdCentroBeneficio;
                iIdproyecto.EditValue = CpVentaItemParameter.IdProyectoCliente;
                iIdarea.EditValue = CpVentaItemParameter.IdAreaEmpleado;
            }
            else
            {
                VwCpventadet vwCpventadetUltimo = VwCpventadetList.LastOrDefault(x => x.DataEntityState != DataEntityState.Deleted);
                if (vwCpventadetUltimo != null)
                {
                    iIdcentrodecosto.EditValue = vwCpventadetUltimo.Idcentrodecosto;
                    iIdproyecto.EditValue = vwCpventadetUltimo.Idproyecto;
                    iIdarea.EditValue = vwCpventadetUltimo.Idarea;
                }
            }

            Almacen almacen = AlmacenList.FirstOrDefault(x => x.Idalmacen == (int)iIdalmacen.EditValue);
            if (almacen != null)
            {
                iIdubicacion.EditValue = almacen.Idubicaciondefecto;
            }

        }
        private void TraerDatos()
        {


            iNumeroitem.EditValue = VwCpventadetMnt.Numeroitem;
            iIdarticulo.EditValue = VwCpventadetMnt.Idarticulo;
            CargarReferenciasSeries(VwCpventadetMnt.Idarticulo);

            iCodigoarticulo.EditValue = VwCpventadetMnt.Codigoarticulo;
            iCodigoproveedor.EditValue = VwCpventadetMnt.Codigoproveedor;
            iIdunidadmedida.EditValue = VwCpventadetMnt.Idunidadmedida;
            iNombremarca.EditValue = VwCpventadetMnt.Nombremarca;
            iNombrearticulo.EditValue = VwCpventadetMnt.Nombrearticulo;
            iIdunidadmedida.EditValue = VwCpventadetMnt.Idunidadmedida;
            iAbrunidadmedida.EditValue = VwCpventadetMnt.Abrunidadmedida;
            iIdimpuesto.EditValue = VwCpventadetMnt.Idimpuesto;
            iEspecificacion.Text = VwCpventadetMnt.Especificacion;
            iCantidad.EditValue = VwCpventadetMnt.Cantidad;
            iPreciounitario.EditValue = VwCpventadetMnt.Preciounitario;
            iDescuento1.EditValue = VwCpventadetMnt.Descuento1;
            iDescuento2.EditValue = VwCpventadetMnt.Descuento2;
            //iDescuento3.EditValue = VwCpventadetMnt.Descuento3;
            //iDescuento4.EditValue = VwCpventadetMnt.Descuento4;
            iPreciounitarioneto.EditValue = VwCpventadetMnt.Preciounitarioneto;
            iImportetotal.EditValue = VwCpventadetMnt.Importetotal;
            iIdtipoafectacionigv.EditValue = VwCpventadetMnt.Idtipoafectacionigv;
            iGravado.EditValue = VwCpventadetMnt.Gravado;
            iExonerado.EditValue = VwCpventadetMnt.Exonerado;
            iInafecto.EditValue = VwCpventadetMnt.Inafecto;
            iExportacion.EditValue = VwCpventadetMnt.Exportacion;
            iIdalmacen.EditValue = VwCpventadetMnt.Idalmacen;
            iIdcentrodecosto.EditValue = VwCpventadetMnt.Idcentrodecosto;
            iIdarea.EditValue = VwCpventadetMnt.Idarea;
            iIdproyecto.EditValue = VwCpventadetMnt.Idproyecto;
            iCalcularitem.EditValue = VwCpventadetMnt.Calcularitem;
            iBonificacion.EditValue = VwCpventadetMnt.Bonificacion;
            iIdubicacion.EditValue = VwCpventadetMnt.Idubicacion;

            iIdclase.EditValue = VwCpventadetMnt.Idclase;
            iIdplan.EditValue = VwCpventadetMnt.Idplan;
            iIdtipo.EditValue = VwCpventadetMnt.Idtipo;
            iIdtipotope.EditValue = VwCpventadetMnt.Idtipotope;
            iNumerolinea.EditValue = VwCpventadetMnt.Numerolinea;

            UserAudit.Createdby = VwCpventadetMnt.Createdby;
            UserAudit.Creationdate = VwCpventadetMnt.Creationdate;
            UserAudit.Modifiedby = VwCpventadetMnt.Modifiedby;
            UserAudit.Lastmodified = VwCpventadetMnt.Lastmodified;

            iIdseriearticulo.EditValue = VwCpventadetMnt.Idseriearticulo;
            rCodigointernoitem.EditValue = VwCpventadetMnt.Codigointernoitem;
            iFecharegistro.EditValue = VwCpventadetMnt.Fecharegistro;
            iSerieutilizada.EditValue = VwCpventadetMnt.Serieutilizada;

        }
        private void CargarReferencias()
        {

            iIdalmacen.EditValue = SessionApp.SucursalSel.Idalmacendefecto;

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            AlmacenList = CacheObjects.AlmacenList.Where(x => x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();
            iIdalmacen.Properties.DataSource = AlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

            TipoafectacionigvList = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DataSource = TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

            VwCentrodecostoList = CacheObjects.VwCentrodecostoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdcentrodecosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrodecosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrodecosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrodecosto.Properties.BestFitMode = BestFitMode.BestFit;

            VwAreaList = CacheObjects.VwAreaList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();//Service.GetAllVwArea(whereArea, "Codigoarea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            VwProyectoList = CacheObjects.VwProyectoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;

            UbicacionList = Service.GetAllVwUbicacion(x => x.Idalmacen == CpVentaItemParameter.IdAlmacenConsulta);
            iIdubicacion.Properties.DataSource = UbicacionList;
            iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
            iIdubicacion.Properties.ValueMember = "Idubicacion";
            iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;


            iIdplan.Properties.DataSource = Service.GetAllPlan("nombreplan");
            iIdplan.Properties.DisplayMember = "Nombreplan";
            iIdplan.Properties.ValueMember = "Idplan";
            iIdplan.Properties.BestFitMode = BestFitMode.BestFit;


            iIdtipo.Properties.DataSource = Service.GetAllTipo("nombretipo");
            iIdtipo.Properties.DisplayMember = "Nombretipo";
            iIdtipo.Properties.ValueMember = "Idtipo";
            iIdtipo.Properties.BestFitMode = BestFitMode.BestFit;

            iIdclase.Properties.DataSource = Service.GetAllClase("Nombreclase");
            iIdclase.Properties.DisplayMember = "Nombreclase";
            iIdclase.Properties.ValueMember = "Idclase";
            iIdclase.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipotope.Properties.DataSource = Service.GetAllTipotope("nombretipotope");
            iIdtipotope.Properties.DisplayMember = "Nombretipotope";
            iIdtipotope.Properties.ValueMember = "Idtipotope";
            iIdtipotope.Properties.BestFitMode = BestFitMode.BestFit;




        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

			        VwCpventadetMnt.Numeroitem = (int)iNumeroitem.EditValue;
			        VwCpventadetMnt.Idarticulo = (int)iIdarticulo.EditValue;
			        VwCpventadetMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
			        VwCpventadetMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
			        VwCpventadetMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                    VwCpventadetMnt.Abrunidadmedida = iAbrunidadmedida.Text.Trim();
			        VwCpventadetMnt.Nombremarca = iNombremarca.Text.Trim();
			        VwCpventadetMnt.Nombrearticulo = iNombrearticulo.Text.Trim();
			        VwCpventadetMnt.Cantidad = (decimal)iCantidad.EditValue;
			        VwCpventadetMnt.Abrunidadmedida = iAbrunidadmedida.Text.Trim();
			        VwCpventadetMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
			        VwCpventadetMnt.Especificacion = iEspecificacion.Text.Trim();
			        VwCpventadetMnt.Descuento1 = (decimal)iDescuento1.EditValue;
			        VwCpventadetMnt.Descuento2 = (decimal)iDescuento2.EditValue;
			        VwCpventadetMnt.Descuento3 = 0m;
			        VwCpventadetMnt.Descuento4 = 0m;
			        VwCpventadetMnt.Preciounitarioneto = (decimal)iPreciounitarioneto.EditValue;
			        VwCpventadetMnt.Importetotal = (decimal)iImportetotal.EditValue;
                    VwCpventadetMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
                    VwCpventadetMnt.Idalmacen = (int) iIdalmacen.EditValue;
                    VwCpventadetMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
                    VwCpventadetMnt.Gravado = VwArticuloSel.Gravado;
                    VwCpventadetMnt.Exonerado = VwArticuloSel.Exonerado;
                    VwCpventadetMnt.Inafecto = VwArticuloSel.Inafecto;
                    VwCpventadetMnt.Exportacion = VwArticuloSel.Exportacion;
                    VwCpventadetMnt.Idarea = (int)iIdarea.EditValue;
                    VwCpventadetMnt.Nombrearea = iIdarea.Text.Trim();
                    VwCpventadetMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwCpventadetMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwCpventadetMnt.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                    VwCpventadetMnt.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                    VwCpventadetMnt.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;
                    VwCpventadetMnt.Idubicacion = (int)iIdubicacion.EditValue;
                    VwCpventadetMnt.Idclase = (int?)iIdclase.EditValue;
                    VwCpventadetMnt.Nombreclase = iIdclase.EditValue == null ? null : iIdclase.Text.Trim();
                    VwCpventadetMnt.Idplan = (int?)iIdplan.EditValue;
                    VwCpventadetMnt.Nombreplan = iIdplan.EditValue == null ? null : iIdplan.Text.Trim();
                    VwCpventadetMnt.Idtipo = (int?) iIdtipo.EditValue;
                    VwCpventadetMnt.Nombretipo = iIdtipo.EditValue == null ? null : iIdtipo.Text.Trim();
                    VwCpventadetMnt.Idtipotope = (int?)iIdtipotope.EditValue;
                    VwCpventadetMnt.Nombretipotope = iIdtipotope.EditValue == null ? null : iIdtipotope.Text.Trim();
			        VwCpventadetMnt.Numerolinea = iNumerolinea.Text.Trim();
                    VwCpventadetMnt.Idseriearticulo = (int?)iIdseriearticulo.EditValue;
                    VwCpventadetMnt.Codigointernoitem = rCodigointernoitem.Text.Trim();
                    VwCpventadetMnt.Fecharegistro = (DateTime?)iFecharegistro.EditValue;
                    VwCpventadetMnt.Serieutilizada = (bool)iSerieutilizada.EditValue;


                    //Los items por defecto se calculan
                    VwCpventadetMnt.Calcularitem = true;
                    VwCpventadetMnt.Bonificacion = (bool)iBonificacion.EditValue;

                    //Si es un articulo compuesto agregar detalle
                    if (VwArticuloSel.Esarticulocompuesto)
                    {
                        AsignarDetalleDeArticulosCompuestos(VwCpventadetMnt.Idarticulo);
                    }

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            VwCpventadetMnt.Createdby = SessionApp.UsuarioSel.Idusuario;
                            VwCpventadetMnt.Creationdate = SessionApp.DateServer;
                            VwCpventadetMnt.Modifiedby = UserAudit.Modifiedby;
                            VwCpventadetMnt.Lastmodified = UserAudit.Lastmodified;

                            break;
                        case TipoMantenimiento.Modificar:
                            VwCpventadetMnt.Createdby = UserAudit.Createdby;
                            VwCpventadetMnt.Creationdate = UserAudit.Creationdate;
                            VwCpventadetMnt.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                            VwCpventadetMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            VwCpventadetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            VwCpventadetMnt.DataEntityState = DataEntityState.Modified;                            
                            break;
                    }
                                        
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void AsignarDetalleDeArticulosCompuestos(int idarticulo)
        {

            VwCpventadetdetComponenteList = new List<VwCpventadet>();
            string whereArticulo = string.Format("idarticulo = {0}", idarticulo);

            List<VwArticulocompuesto> vwArticuloDetalleComponenteList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");

            int numeroItem = (int)iNumeroitem.EditValue;

            foreach (var item in vwArticuloDetalleComponenteList)
            {
                numeroItem++;
                VwCpventadet vwCpventadet = new VwCpventadet();

                vwCpventadet.Numeroitem = numeroItem;
                vwCpventadet.Idarticulo = item.Idarticulodetalle;
                vwCpventadet.Codigoarticulo = item.Codigoarticulo;
                vwCpventadet.Codigoproveedor = item.Codigoproveedor;
                vwCpventadet.Idunidadmedida = item.Idunidadinventario;                
                vwCpventadet.Nombremarca = item.Nombremarca;
                vwCpventadet.Nombrearticulo = item.Nombrearticulo;
                vwCpventadet.Cantidad = item.Cantidaddetalle * (decimal)iCantidad.EditValue;
                vwCpventadet.Abrunidadmedida = item.Abrunidadmedida;
                vwCpventadet.Preciounitario = 0m;
                vwCpventadet.Especificacion = string.Empty;
                vwCpventadet.Descuento1 = 0m;
                vwCpventadet.Descuento2 = 0m;
                vwCpventadet.Descuento3 = 0m;
                vwCpventadet.Descuento4 = 0m;
                vwCpventadet.Preciounitarioneto = 0m;
                vwCpventadet.Importetotal = 0m;
                vwCpventadet.Idimpuesto = item.Idimpuesto;
                vwCpventadet.Idalmacen = (int)iIdalmacen.EditValue;
                vwCpventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                vwCpventadet.Gravado = item.Gravado;
                vwCpventadet.Exonerado = item.Exonerado;
                vwCpventadet.Inafecto = item.Inafecto;
                vwCpventadet.Exportacion = item.Exportacion;
                vwCpventadet.Idarea = (int)iIdarea.EditValue;
                vwCpventadet.Nombrearea = iIdarea.Text.Trim();
                vwCpventadet.Idproyecto = (int)iIdproyecto.EditValue;
                vwCpventadet.Nombreproyecto = iIdproyecto.Text.Trim();
                vwCpventadet.Idcentrodecosto = (int)iIdcentrodecosto.EditValue;
                vwCpventadet.Descripcioncentrodecosto = iIdcentrodecosto.Text.Trim();
                vwCpventadet.Porcentajepercepcion = (decimal)nPorcentajepercepcion.EditValue;

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        //vwCotizacionclientedet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwCotizacionclientedet.Creationdate = DateTime.Now;
                        break;
                    case TipoMantenimiento.Modificar:
                        //vwCotizacionclientedet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwCotizacionclientedet.Lastmodified = DateTime.Now;
                        break;
                }

                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        vwCpventadet.DataEntityState = DataEntityState.Added;
                        break;
                    case TipoMantenimiento.Modificar:
                        vwCpventadet.DataEntityState = DataEntityState.Modified;
                        break;
                }

                //Se estable a false no se calcula el item
                vwCpventadet.Calcularitem = false;


                VwCpventadetdetComponenteList.Add(vwCpventadet);
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
        private void CpventaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal)iCantidad.EditValue;
            var precioUniatario = (decimal)iPreciounitario.EditValue;
            var descuento1 = (decimal)iDescuento1.EditValue;
            var descuento2 = (decimal)iDescuento2.EditValue;
            const decimal descuento3 = 0m;
            const decimal descuento4 = 0m;

            decimal preciounitarioneto = precioUniatario
                                         * (1 - descuento1 / 100)
                                         * (1 - descuento2 / 100)
                                         * (1 - descuento3 / 100)
                                         * (1 - descuento4 / 100);

            var importeTotal = Decimal.Round(cantidad * preciounitarioneto, 2);

            iPreciounitarioneto.EditValue = decimal.Round(preciounitarioneto, 2);
            iImportetotal.EditValue = importeTotal;
        }
        private void iIdarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idArticuloSel = iIdarticulo.EditValue;

            if (idArticuloSel == null || (int)idArticuloSel <= 0) return;

            VwArticuloSel = Service.GetVwArticulo(((int)idArticuloSel));
            if (VwArticuloSel != null)
            {
                //Cargar datos a controles
                iCodigoarticulo.EditValue = VwArticuloSel.Codigoarticulo;
                iCodigoproveedor.EditValue = VwArticuloSel.Codigoproveedor;
                iNombrearticulo.Text = VwArticuloSel.Nombrearticulo.Trim();
                iNombremarca.EditValue = VwArticuloSel.Nombremarca;
                iIdimpuesto.EditValue = VwArticuloSel.Idimpuesto;
                iIdunidadmedida.EditValue = VwArticuloSel.Idunidadinventario;
                iAbrunidadmedida.EditValue = VwArticuloSel.Abrunidadmedida;
                iIdtipoafectacionigv.EditValue = VwArticuloSel.Idtipoafectacionigv;
                nPorcentajepercepcion.EditValue = VwArticuloSel.Aplicapercepcion ? SessionApp.EmpresaSel.Porcentajepercepcion : 0m;
                iEspecificacion.Text = VwArticuloSel.Caracteristicas;
            }

            else
            {
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                iNombrearticulo.Text = string.Empty;
                iNombremarca.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iIdtipoafectacionigv.EditValue = null;
                nPorcentajepercepcion.EditValue = 0m;
            }     
        }
        private void beArticulo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ArticuloMntFrm articuloMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscarArticulo();
                    
                    break;
                case 1: //Nuevo registro
                    articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    articuloMntFrm.ShowDialog();

                    if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                    {
                        iIdarticulo.EditValue = 0;
                        iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                       
                    }
                    break;
                case 2: //Modificar registro
                    var idArticuloMnt = iIdarticulo.EditValue;
                    if (idArticuloMnt != null && (int)idArticuloMnt > 0)
                    {
                        articuloMntFrm = new ArticuloMntFrm((int)idArticuloMnt, TipoMantenimiento.Modificar, null, null);
                        articuloMntFrm.ShowDialog();
                        if (articuloMntFrm.DialogResult == DialogResult.OK && articuloMntFrm.IdEntidadMnt > 0)
                        {
                            iIdarticulo.EditValue = articuloMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }
        }

        private void CargarReferenciasSeries(int? idArticulo)
        {

            string condicion = null;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    condicion = string.Format("idarticulo = {0} and not serieutilizada", idArticulo);
                    break;
                case TipoMantenimiento.Modificar:
                    condicion = string.Format("idarticulo = {0}", idArticulo);
                    break;
            }
            VwArticuloseriedetList = Service.GetAllVwArticuloseriedet(condicion, "fecharegistro,Numeroserieitem");
            iIdseriearticulo.Properties.DataSource = VwArticuloseriedetList;
            iIdseriearticulo.Properties.DisplayMember = "Numeroserieitem";
            iIdseriearticulo.Properties.ValueMember = "Idseriearticulo";
        }

        private void BuscarArticulo()
        {
            BuscadorArticuloCondicionFrm buscadorArticuloFrm = new BuscadorArticuloCondicionFrm(
              CpVentaItemParameter.IdSucursalConsulta,
              CpVentaItemParameter.IdAlmacenConsulta,
              CpVentaItemParameter.IdTipoListaConsulta,
              CpVentaItemParameter.IdTipoMonedaConsulta,
              CpVentaItemParameter.IdTipoCondicion);
            buscadorArticuloFrm.ShowDialog();

            if (buscadorArticuloFrm.DialogResult == DialogResult.OK && buscadorArticuloFrm.VwArticulounidadSel != null)
            {
                CargarDatosArticuloSeleccionado(buscadorArticuloFrm.VwArticulounidadSel);
                iStock.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Stock;

                if (CpVentaItemParameter.Incluyeimpuestoitems && buscadorArticuloFrm.VwArticulounidadSel.Listaprecioincluyeimpuesto)
                {
                    iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                }
                else if (!CpVentaItemParameter.Incluyeimpuestoitems && !buscadorArticuloFrm.VwArticulounidadSel.Listaprecioincluyeimpuesto)
                {
                    iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                }
                else if (CpVentaItemParameter.Incluyeimpuestoitems && !buscadorArticuloFrm.VwArticulounidadSel.Listaprecioincluyeimpuesto)
                {
                    iPreciounitario.EditValue = decimal.Round(buscadorArticuloFrm.VwArticulounidadSel.Preciolista * (1 + CpVentaItemParameter.Porcentajeimpuesto / 100), 4, MidpointRounding.AwayFromZero);
                }
                else if (!CpVentaItemParameter.Incluyeimpuestoitems && buscadorArticuloFrm.VwArticulounidadSel.Listaprecioincluyeimpuesto)
                {
                    iPreciounitario.EditValue = decimal.Round(buscadorArticuloFrm.VwArticulounidadSel.Preciolista * (1 + CpVentaItemParameter.Porcentajeimpuesto / 100), 4, MidpointRounding.AwayFromZero);
                }

                //iPreciounitario.EditValue = buscadorArticuloFrm.VwArticulounidadSel.Preciolista;
                iCantidad.Select();

            }


        }

        private void CargarDatosArticuloSeleccionado(VwArticulounidad vwArticulounidad)
        {
            if (vwArticulounidad != null)
            {
                //Cargar datos a controles
                iIdarticulo.EditValue = vwArticulounidad.Idarticulo;
                iCodigoarticulo.EditValue = vwArticulounidad.Codigoarticulo;
                iCodigoproveedor.EditValue = vwArticulounidad.Codigoproveedor;
                //iCodigodebarra.EditValue = vwArticulounidad.Codigodebarra;
                iNombrearticulo.Text = vwArticulounidad.Nombrearticulo.Trim();
                iNombremarca.EditValue = vwArticulounidad.Nombremarca;
                iIdimpuesto.EditValue = vwArticulounidad.Idimpuesto;
                iAbrunidadmedida.EditValue = vwArticulounidad.Abrunidadmedida;
                iIdunidadmedida.EditValue = vwArticulounidad.Idunidadinventario;
                nPorcentajepercepcion.EditValue = vwArticulounidad.Aplicapercepcion
                    ? SessionApp.EmpresaSel.Porcentajepercepcion
                    : 0m;
                iIdtipoafectacionigv.EditValue = vwArticulounidad.Idtipoafectacionigv;

                iGravado.EditValue = vwArticulounidad.Gravado;
                iExonerado.EditValue = vwArticulounidad.Exonerado;
                iInafecto.EditValue = vwArticulounidad.Inafecto;
                iExportacion.EditValue = vwArticulounidad.Exportacion;
                iCalcularitem.EditValue = true;

                CargarReferenciasSeries(vwArticulounidad.Idarticulo);
            }

            else
            {
                iIdarticulo.EditValue = 0;
                iCodigoarticulo.EditValue = string.Empty;
                iCodigoproveedor.EditValue = string.Empty;
                //iCodigodebarra.EditValue = string.Empty;
                iNombrearticulo.Text = string.Empty;
                iNombremarca.EditValue = string.Empty;
                iIdimpuesto.EditValue = null;
                iAbrunidadmedida.EditValue = string.Empty;
                iIdunidadmedida.EditValue = 0;
                nPorcentajepercepcion.EditValue = 0m;
                iIdtipoafectacionigv.EditValue = null;

                iGravado.EditValue = false;
                iExonerado.EditValue = false;
                iInafecto.EditValue = false;
                iExportacion.EditValue = false;
                iCalcularitem.EditValue = false;
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
                    iFecharegistro.EditValue = vwArticuloseriedet.Fecharegistro;
                }
                else
                {
                    rCodigointernoitem.EditValue = null;
                    iFecharegistro.EditValue = null;
                }
                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    iSerieutilizada.Checked = true;
                }
            }
        }
    }
}