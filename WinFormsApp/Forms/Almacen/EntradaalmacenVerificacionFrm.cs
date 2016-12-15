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
using DevExpress.XtraGrid;
using Microsoft.Win32;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class EntradaalmacenVerificacionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public EntradaalmacenFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        
        static readonly IService Service = new Service();
        public Entradaalmacen EntradaalmacenMnt { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }
        public List<VwSocionegocio> VwSocionegocioList { get; set; }
        public List<Tipodocmov> TipodocmovList { get; set; }
        public List<Impuesto> ImpuestoList { get; set; }

        public VwTipocp TipoCpMnt { get; set; }
        public List<VwEntradaalmacen> VwEntradaalmacenList { get; set; }
        public List<Estadoarticuloingreso> EstadoarticuloingresoList { get; set; }
        //Detalle
        public List<VwEntradaalmacendet> VwEntradaalmacendetList { get; set; }
        public List<VwEntradaalmacenobs> VwEntradaalmacendetobsList { get; set; }

        public EntradaalmacenVerificacionFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EntradaalmacenFrm formParent) 
        {
            if (tipoMnt == TipoMantenimiento.SinEspecificar && idEntidadMnt <= 0)
            {
                throw new ArgumentException("El valor primario de la entidad no contiene un valor valido.");
            }

            InitializeComponent();

            IdEntidadMnt = idEntidadMnt;
            TipoMnt = tipoMnt;
            SeEliminoObjeto = false;
            GridParent = gridParent;
            FormParent = formParent;

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;                       
        }
        private void EntradaalmacenVerificacionFrm_Load(object sender, EventArgs e)
        {
           // EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iFechaverificacion.EditValue = DateTime.Now;
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            cboBuscar.SelectedIndex = 0;
            if (!SessionApp.UsuarioSel.Nombreusuario.Equals("ADMIN"))
            {
                iIdresponsable.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdresponsable.ReadOnly = true;                
            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();
                    EntradaalmacenMnt = new Entradaalmacen();                    
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();
                    iSerie.Select();
                    //TraerDatos();
                    //CargarDetalle();

                   

                    break;
            }           
        }
        private void CargarReferencias()
        {

            iIdsucursal.Properties.DataSource = Service.GetAllSucursal();
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereTipoSocio = string.Format("idtiposocio = '{0}'", "2");
            VwSocionegocioList = Service.GetAllVwSocionegocio(whereTipoSocio, "razonsocial");
            rIdsocionegocio.Properties.DataSource = VwSocionegocioList;
            rIdsocionegocio.Properties.DisplayMember = "Razonsocial";
            rIdsocionegocio.Properties.ValueMember = "Idsocionegocio";
            rIdsocionegocio.Properties.BestFitMode = BestFitMode.BestFit;

            iIdresponsable.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdresponsable.Properties.DisplayMember = "Razonsocial";
            iIdresponsable.Properties.ValueMember = "Idempleado";
            iIdresponsable.Properties.BestFitMode = BestFitMode.BestFit;

            EstadoarticuloingresoList = Service.GetAllEstadoarticuloingreso("idestadoarticulo");
            iIdestadoarticulo.Properties.DataSource = EstadoarticuloingresoList;
            iIdestadoarticulo.Properties.DisplayMember = "Nombreestado";
            iIdestadoarticulo.Properties.ValueMember = "Idestadoarticulo";
            iIdestadoarticulo.Properties.BestFitMode = BestFitMode.BestFit;
            

            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacendestino.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen,"codigoalmacen");
            iIdalmacendestino.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacendestino.Properties.ValueMember = "Idalmacen";
            iIdalmacendestino.Properties.BestFitMode = BestFitMode.BestFit;


            
        }
      
        private void CargarDetalle()
        {
            string where = string.Format("idEntradaalmacen = '{0}'", IdEntidadMnt);
            gcDetalle.BeginUpdate();
            VwEntradaalmacendetList = Service.GetAllVwEntradaalmacendet(where, "numeroitem");
            gcDetalle.DataSource = VwEntradaalmacendetList;
            gvDetalle.BestFitColumns();
           // ActualizarTotales();
            if (IdEntidadMnt > 0)
            {
                ActualizarTotales();
            }

            gcDetalle.EndUpdate();

        }

        private void CargarDatosFiltro()
        {
            gcDetalle.DataSource = null;

           
            string whereFiltro = string.Empty;

            
            switch (cboBuscar.SelectedIndex)
            {
                case 0://Entrada almacen

                    whereFiltro = string.Format(@"serieentradaalmacen = '{0}'
                        and numeroentradaalmacen = '{1}' and anulado = '0' and idsucursal = {2}",
                        iSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue
                        );

                    break;
                case 1: // GUIA DE ENTRADA

                    whereFiltro = string.Format(@"Serieguiaremision = '{0}'
                        and numeroguiaremision = '{1}' and anulado = '0' and idsucursal = {2}",
                        iSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue
                        );

                    break;
            }


            VwEntradaalmacenList = Service.GetAllVwEntradaalmacen(whereFiltro, "identradaalmacen");

            if (VwEntradaalmacenList != null && VwEntradaalmacenList.Count>0)
            {
                Cursor = Cursors.WaitCursor;
                VwEntradaalmacen vwEntradaalmacen = VwEntradaalmacenList.FirstOrDefault();
                if (vwEntradaalmacen != null)
                {
                    rIdsocionegocio.EditValue = vwEntradaalmacen.Idsocionegocio;
                    rFechaentrada.EditValue = vwEntradaalmacen.Fechaentrada;
                    pkIdEntidad.EditValue = vwEntradaalmacen.Identradaalmacen;
                    //iIdresponsable.EditValue = vwEntradaalmacen.Idresponsableverifica;
                    iIdalmacendestino.EditValue = vwEntradaalmacen.Idalmacendestino;
                    EntradaalmacenMnt =
                    Service.GetEntradaalmacen(x => x.Identradaalmacen == vwEntradaalmacen.Identradaalmacen);
                }

                string wheredet = string.Format(@"identradaalmacen = '{0}'", pkIdEntidad.EditValue);
                VwEntradaalmacendetList = Service.GetAllVwEntradaalmacendet(wheredet, "identradaalmacen");

                gcDetalle.BeginUpdate();
                gcDetalle.DataSource = VwEntradaalmacendetList;
                gcDetalle.EndUpdate();
                gvDetalle.BestFitColumns();

                Cursor = Cursors.Default;
            }
            else
            {
                gcDetalle.DataSource = null;
                gcObservado.DataSource = null;
                rIdsocionegocio.EditValue = null;
                rFechaentrada.EditValue = null;
                pkIdEntidad.EditValue = 0;
                XtraMessageBox.Show("No hay información requerimientos, verifique", "Atención", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                iNumero.Select();
               
 
            }

            ObtenerAlmacenDestino();
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            EntradaalmacenMnt.Idalmacendestino = (int?)iIdalmacendestino.EditValue;
            EntradaalmacenMnt.Idresponsableverifica = (int?)iIdresponsable.EditValue;
            EntradaalmacenMnt.Fechaverificacion = (DateTime)iFechaverificacion.EditValue;
          
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    EntradaalmacenMnt.Createdby = IdUsuario;
                    EntradaalmacenMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    EntradaalmacenMnt.Modifiedby = IdUsuario;
                    EntradaalmacenMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveEntradaalmacen(EntradaalmacenMnt);
                    EntradaalmacenMnt.Identradaalmacen = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    
                        
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateEntradaalmacen(EntradaalmacenMnt);
                    break;
                }
                GuardarAlmacenDestino();
                Cursor = Cursors.Default;
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            //int idPersona = TipoMnt == TipoMantenimiento.Nuevo ? 0 : IdEntidadMnt;

            //if (Service.NroDocumentoPersonaExiste(iNrodocentidad.Text.Trim(), idPersona))
            //{
            //    XtraMessageBox.Show("Número de documento ya existe.", "Documento de identidad", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    iNrodocentidad.Focus();
            //    return false;
            //}
            
            return true;
        }
        
     
        private void EntradaalmacenVerificacionFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
       

        private void EntradaalmacenVerificacionFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (FormParent != null)
            //{                
            //    if (SeEliminoObjeto)
            //    {
            //        FormParent.CargarDatosConsulta();
            //    }
            //    if (SeGuardoObjeto)
            //    {                    
            //        FormParent.IdEntidadMnt = IdEntidadMnt;
            //        FormParent.CargarDatosConsulta();
            //        FormParent.SetFocusIdEntity();
            //    }
            //}
            //e.Cancel = false;
        }
      
        private void ActualizarTotales()
        {

            
           
        }
       
        
        private void iIdproveedor_EditValueChanged(object sender, EventArgs e)
        {
            var idSocioNegocioSel = rIdsocionegocio.EditValue;
            if (idSocioNegocioSel != null)
            {
                var vwSocionegocio = VwSocionegocioList.FirstOrDefault(x => x.Idsocionegocio == (int)idSocioNegocioSel);
                if (vwSocionegocio != null)
                {
                    iDireccion.Text = vwSocionegocio.Direccionfiscal;
                }
            }
            else
            {
                iDireccion.Text = string.Empty;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatosFiltro();

        }

        private void gvDetalle_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwEntradaalmacendet vwEntradaalmacendet = (VwEntradaalmacendet)gvDetalle.GetRow(e.FocusedRowHandle);
            if (vwEntradaalmacendet != null)
            {
               
                CargarDetalleObservado(vwEntradaalmacendet.Identradaalmacendet);
            }
        }

        private void CargarDetalleObservado(int? identradaalmacendet)
        {
            string wheredet = string.Format(@"identradaalmacendet = '{0}'", identradaalmacendet);
            VwEntradaalmacendetobsList = Service.GetAllVwEntradaalmacenobs(wheredet, "identradaalmacenobs");

            gcObservado.BeginUpdate();
            gcObservado.DataSource = VwEntradaalmacendetobsList;
            gcObservado.EndUpdate();
            gvObservado.BestFitColumns();   
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((decimal)iCantidad.EditValue == 0m)
            {
                XtraMessageBox.Show("Ingrese Cantidad", "Atencion", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                iCantidad.Select();
                return;
            }

            VwEntradaalmacendet vwEntradaalmacendet = (VwEntradaalmacendet) gvDetalle.GetFocusedRow();
            if (vwEntradaalmacendet != null)
            {
                var cantidadtotalobs = VwEntradaalmacendetobsList.Sum(x => x.Cantidad);
                if (cantidadtotalobs != null)
                {
                    if (cantidadtotalobs + (decimal)iCantidad.EditValue > vwEntradaalmacendet.Diferencia)
                    {
                        XtraMessageBox.Show("Cantidad de Diferencia Agotado", "Verifique", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iCantidad.EditValue = 0m;
                        iCantidad.Select();
                       return;
                    }
                }

                Guardar();

                Entradaalmacenobs entradaalmacenobs = new Entradaalmacenobs();
                entradaalmacenobs.Cantidad = (decimal)iCantidad.EditValue;
                entradaalmacenobs.Idestadoarticulo = (int) iIdestadoarticulo.EditValue;
                entradaalmacenobs.Identradaalmacendet = vwEntradaalmacendet.Identradaalmacendet;

                var estadosel =
                    EstadoarticuloingresoList.FirstOrDefault(
                        x => x.Idestadoarticulo == (int) iIdestadoarticulo.EditValue);

                if (estadosel != null)
                {
                     entradaalmacenobs.Procedereclamo = estadosel.Procedereclamo;
                     Service.SaveEntradaalmacenobs(entradaalmacenobs);
                     CargarDetalleObservado(vwEntradaalmacendet.Identradaalmacendet);
                     iIdestadoarticulo.EditValue = null;
                     iCantidad.EditValue = 0m;
                }
               
            }
           


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            VwEntradaalmacendet vwEntradaalmacendet = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();
            VwEntradaalmacenobs vwEntradaalmacenobs = (VwEntradaalmacenobs) gvObservado.GetFocusedRow();
            if (vwEntradaalmacenobs != null)
            {
               // Entradaalmacenobs entradaalmacenobs = new Entradaalmacenobs();
                //entradaalmacenobs.Identradaalmacenobs = vwEntradaalmacenobs.Identradaalmacenobs;
                Service.DeleteEntradaalmacenobs(vwEntradaalmacenobs.Identradaalmacenobs);
                CargarDetalleObservado(vwEntradaalmacendet.Identradaalmacendet);
            }
        }

        private void bmMantenimiento_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Name)
            {
                case "btnNuevo":
                    break;
                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        //btnGrabar.Enabled = false;
                        //btnGrabarCerrar.Enabled = false;
                        btnGrabarNuevo.Enabled = false;

                        if (IdEntidadMnt > 0)
                        {
                            TipoMnt = TipoMantenimiento.Modificar;
                        }

                        
                    }
                    break;
                case "btnGrabarCerrar":
                    
                    break;
                case "btnEliminar":
                    break;
                case "btnLimpiarCampos":
                    break;
                case "btnActualizar":
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        EntradaalmacenMnt = null;
                        DialogResult = DialogResult.OK;
                    }
                    break;
                case "btnImprimir":
                    
                    break;
            }
        }

        private void iIdestadoarticulo_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            //var tipoestadoMntFrm = new TipoformatoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            //tipoestadoMntFrm.ShowDialog();
            //if (tipoestadoMntFrm.IdEntidadMnt > 0)
            //{
            //    //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
            //    Tipoformato tipoFormato = tipoestadoMntFrm.TipoformatoMnt;
            //    if (tipoFormato.Idtipoformato > 0)
            //    {
            //        TipoformatoList.Add(tipoFormato);
            //        e.Cancel = false;
            //        e.NewValue = tipoFormato.Idtipoformato;
            //    }
            //}
        }

        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwEntradaalmacendet itemSel = (VwEntradaalmacendet)gvDetalle.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Cantidadverificada":
                    if (itemSel.Cantidadverificada > itemSel.Cantidad)
                    {
                        XtraMessageBox.Show("Cantidad a importar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        itemSel.Cantidadverificada = 0m;
                        
                    }
                    else
                    {
                        itemSel.Diferencia = (decimal) (itemSel.Cantidad - itemSel.Cantidadverificada);
                        Entradaalmacendet entradaalmacendet =new Entradaalmacendet();
                        entradaalmacendet.Cantidadverificada = itemSel.Cantidadverificada;
                        entradaalmacendet.Identradaalmacendet = itemSel.Identradaalmacendet;
                        Service.ActualizarEntradaalmacendetCantidadVerificada(entradaalmacendet);
                    }
                    gvDetalle.RefreshData();
                    break;
               

                   
            }
        }

        private void tpDetalleReq_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ObtenerAlmacenDestino()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    var idAlmacenDestinoVerificacion = Convert.ToInt32(registryKey.GetValue("AlmacenDestinoVerificacion", "0"));
                    if (idAlmacenDestinoVerificacion > 0)
                    {
                        iIdalmacendestino.EditValue = idAlmacenDestinoVerificacion;
                    }
                }


            }
        }

        private void GuardarAlmacenDestino()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue("AlmacenDestinoVerificacion", iIdalmacendestino.EditValue.ToString(), RegistryValueKind.String);
                }
            }
        }
    }
}