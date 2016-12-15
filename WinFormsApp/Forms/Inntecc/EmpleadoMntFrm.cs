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
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class EmpleadoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public EmpleadoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Empleado EmpleadoMnt { get; set; }
        public List<Tipoformato> TipoformatoList { get; set; }
        private List<VwArea> VwAreaList { get; set; }
        public List<VwTipocp> VwTipoCpVentaList { get; set; }
        public List<VwCptooperacion> VwCptooperacionCpVentaList { get; set; }
        public List<VwTipocp> VwTipocReciboIngresoList { get; set; }
        public List<VwCptooperacion> VwCptooperacionReciboIngresoList { get; set; }
        public List<Tiposnp> TiposnpList { get; set; }
        public EmpleadoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EmpleadoFrm formParent) 
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
            WinFormUtils.SetEnterMoveNextControl(tpDatos, true);
            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;            

        }

        private void EmpleadoMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Crear " + Text;
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
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    EmpleadoMnt = new Empleado();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iIdpersona.Enabled = false;
                    break;
            }           
        }
        private void CargarReferencias()
        {

           
            //iIdpersona.Properties.DataSource = Service.GetAllVwPersona();
            //iIdpersona.Properties.DisplayMember = "Razonsocial";
            //iIdpersona.Properties.ValueMember = "Idpersona";
            //iIdpersona.Properties.BestFitMode = BestFitMode.BestFit;
            string condicionArea = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwAreaList = Service.GetAllVwArea(condicionArea, "Nombrearea");
            iIdarea.Properties.DataSource = VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            TiposnpList = Service.GetAllTiposnp();
            iIdtiposnp.Properties.DataSource = TiposnpList;
            iIdtiposnp.Properties.DisplayMember = "Nombretiposnp";
            iIdtiposnp.Properties.ValueMember = "Idtiposnp";
            iIdtiposnp.Properties.BestFitMode = BestFitMode.BestFit;

            iIdestadocivil.Properties.DataSource = Service.GetAllEstadocivil("idestadocivil");
            iIdestadocivil.Properties.DisplayMember = "Nombreestadocivil";
            iIdestadocivil.Properties.ValueMember = "Idestadocivil";
            iIdestadocivil.Properties.BestFitMode = BestFitMode.BestFit;

            iIdpais.Properties.DataSource = CacheObjects.PaisList;
            iIdpais.Properties.DisplayMember = "Nombrepais";
            iIdpais.Properties.ValueMember = "Idpais";
            iIdpais.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipomonedasueldo.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomonedasueldo.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomonedasueldo.Properties.ValueMember = "Idtipomoneda";
            iIdtipomonedasueldo.Properties.BestFitMode = BestFitMode.BestFit;

            iIdbancocuentasueldo.Properties.DataSource = CacheObjects.EntidadfinancieraList;
            iIdbancocuentasueldo.Properties.DisplayMember = "Nombreentidadfinanciera";
            iIdbancocuentasueldo.Properties.ValueMember = "Identfinaciera";
            iIdbancocuentasueldo.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipocontratoempleado.Properties.DataSource = Service.GetAllTipocontratoempleado("Nombretipocontratoempleado");
            iIdtipocontratoempleado.Properties.DisplayMember = "Nombretipocontratoempleado";
            iIdtipocontratoempleado.Properties.ValueMember = "Idtipocontratoempleado";
            iIdtipocontratoempleado.Properties.BestFitMode = BestFitMode.BestFit;

            iIddistritotrabajo.Properties.DataSource = CacheObjects.UbigeoList;
            iIddistritotrabajo.Properties.DisplayMember = "Nombreubigeo";
            iIddistritotrabajo.Properties.ValueMember = "Iddistrito";
            iIddistritotrabajo.Properties.BestFitMode = BestFitMode.BestFit;

            CargarReferenciasCpVenta();

        }
        private void TraerDatos()
        {
            try
            {

                EmpleadoMnt = Service.GetEmpleado(IdEntidadMnt);
                iIdpersona.EditValue = EmpleadoMnt.Idpersona;
                iIdarea.EditValue = EmpleadoMnt.Idarea;
                iNivelestudio.EditValue = EmpleadoMnt.Denominacionfuncion;
                iFechainicio.EditValue = EmpleadoMnt.Fechainicio;
                iFechacese.EditValue = EmpleadoMnt.Fechacese;
                iMotivocese.EditValue = EmpleadoMnt.Motivocese;
                iComentario.EditValue = EmpleadoMnt.Comentario;
                iMovil.EditValue = EmpleadoMnt.Movil;
                iTelefono.EditValue = EmpleadoMnt.Telefono;
                iEmail.EditValue = EmpleadoMnt.Email;
                iIdtipoCpVenta.EditValue = EmpleadoMnt.Idtipocpventa;
                iIdcptooperacionCpVenta.EditValue = EmpleadoMnt.Idcptooperacionventa;
                iIdtipocpreciboingreso.EditValue = EmpleadoMnt.Idtipocpreciboingreso;
                iIdcptooperacionReciboIngreso.EditValue = EmpleadoMnt.Idcptooperacionreciboingreso;
                iNumerosegurosocial.EditValue = EmpleadoMnt.Numerosegurosocial;
                iIdtiposnp.EditValue = EmpleadoMnt.Idtiposnp;
                iCelularempresa.EditValue = EmpleadoMnt.Celularempresa;
                iEmailempresa.EditValue = EmpleadoMnt.Emailempresa;
                iIdestadocivil.EditValue = EmpleadoMnt.Idestadocivil;
                eNumerohijos.EditValue = EmpleadoMnt.Numerohijos;
                iIdpais.EditValue = EmpleadoMnt.Idpais;
                iNivelestudio.EditValue = EmpleadoMnt.Nivelestudio;
                iEspecialidad.EditValue = EmpleadoMnt.Especialidad;
                nComisionclasificacionproducto.EditValue = EmpleadoMnt.Comisionclasificacionproducto;
                nBono.EditValue = EmpleadoMnt.Bono;
                iIdbancocuentasueldo.EditValue = EmpleadoMnt.Idbancocuentasueldo;
                iNumerocuentasueldo.EditValue = EmpleadoMnt.Numerocuentasueldo;
                iIdtipocontratoempleado.EditValue = EmpleadoMnt.Idtipocontratoempleado;
                iVencimientocontrato.EditValue = EmpleadoMnt.Vencimientocontrato;
                iCategoria.EditValue = EmpleadoMnt.Categoria;
                iIdtipomonedasueldo.EditValue = EmpleadoMnt.Idtipomonedasueldo;
                nSueldobruto.EditValue = EmpleadoMnt.Sueldobruto;
                iIddistritotrabajo.EditValue = EmpleadoMnt.Iddistritotrabajo;
                iNombreconyugue.EditValue = EmpleadoMnt.Nombreconyugue;
                iTelefonoconyugue.EditValue = EmpleadoMnt.Telefonoconyugue;
                iNombrecontactoemergencia.EditValue = EmpleadoMnt.Nombrecontactoemergencia;
                iTelefonoemergencia.EditValue = EmpleadoMnt.Telefonoemergencia;
                iEsactivo.EditValue = EmpleadoMnt.Esactivo;
                iFechanacimiento.EditValue = EmpleadoMnt.Fechanacimiento;
                iFotoempleado.EditValue = EmpleadoMnt.Fotoempleado;
                iDenominacionfuncion.EditValue = EmpleadoMnt.Denominacionfuncion;
                iNombrefuente.EditValue = EmpleadoMnt.Nombrefuente;
                iFuentetamanio.EditValue = EmpleadoMnt.Fuentetamanio;
                iFuentenegrita.EditValue = EmpleadoMnt.Fuentenegrita;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }
        private bool Guardar()
        {
 
            if (!Validaciones()) return false;

            EmpleadoMnt.Idpersona = (int)iIdpersona.EditValue;
            EmpleadoMnt.Idarea = (int)iIdarea.EditValue;
            EmpleadoMnt.Denominacionfuncion = iNivelestudio.Text.Trim();
            EmpleadoMnt.Fechainicio = (DateTime) iFechainicio.EditValue;
            EmpleadoMnt.Fechacese = (DateTime?)iFechacese.EditValue;
            EmpleadoMnt.Motivocese = iMotivocese.Text.Trim();
            EmpleadoMnt.Comentario = iComentario.Text.Trim();
            EmpleadoMnt.Movil = iMovil.Text.Trim();
            EmpleadoMnt.Telefono = iTelefono.Text.Trim();
            EmpleadoMnt.Email = iEmail.Text.Trim();
            EmpleadoMnt.Idtipocpventa = (int?) iIdtipoCpVenta.EditValue;
            EmpleadoMnt.Idcptooperacionventa = (int?) iIdcptooperacionCpVenta.EditValue;
            EmpleadoMnt.Idtipocpreciboingreso = (int?)iIdtipocpreciboingreso.EditValue;
            EmpleadoMnt.Idcptooperacionreciboingreso = (int?)iIdcptooperacionReciboIngreso.EditValue;

            EmpleadoMnt.Numerosegurosocial = iNumerosegurosocial.Text.Trim();
            EmpleadoMnt.Idtiposnp = (int?)iIdtiposnp.EditValue;
            EmpleadoMnt.Celularempresa = iCelularempresa.Text.Trim();
            EmpleadoMnt.Emailempresa = iEmailempresa.Text.Trim();
            EmpleadoMnt.Idestadocivil = (int?)iIdestadocivil.EditValue;
            EmpleadoMnt.Numerohijos = (int)eNumerohijos.EditValue;
            EmpleadoMnt.Idpais = (int?)iIdpais.EditValue;
            EmpleadoMnt.Nivelestudio = iNivelestudio.Text.Trim();
            EmpleadoMnt.Especialidad = iEspecialidad.Text.Trim();
            EmpleadoMnt.Comisionclasificacionproducto = (decimal)nComisionclasificacionproducto.EditValue;
            EmpleadoMnt.Bono = (decimal)nBono.EditValue;
            EmpleadoMnt.Idbancocuentasueldo = (int?)iIdbancocuentasueldo.EditValue;
            EmpleadoMnt.Numerocuentasueldo = iNumerocuentasueldo.Text.Trim();
            EmpleadoMnt.Idtipocontratoempleado = (int?)iIdtipocontratoempleado.EditValue;
            EmpleadoMnt.Vencimientocontrato = (DateTime?)iVencimientocontrato.EditValue;
            EmpleadoMnt.Categoria = iCategoria.Text.Trim();
            EmpleadoMnt.Idtipomonedasueldo = (int?)iIdtipomonedasueldo.EditValue;
            EmpleadoMnt.Sueldobruto = (decimal)nSueldobruto.EditValue;
            EmpleadoMnt.Iddistritotrabajo = (int?)iIddistritotrabajo.EditValue;
            EmpleadoMnt.Nombreconyugue = iNombreconyugue.Text.Trim();
            EmpleadoMnt.Telefonoconyugue = iTelefonoconyugue.Text.Trim();
            EmpleadoMnt.Nombrecontactoemergencia = iNombrecontactoemergencia.Text.Trim();
            EmpleadoMnt.Telefonoemergencia = iTelefonoemergencia.Text.Trim();
            EmpleadoMnt.Esactivo = (bool)iEsactivo.EditValue;
            EmpleadoMnt.Fechanacimiento = (DateTime?)iFechanacimiento.EditValue;
            EmpleadoMnt.Fotoempleado = (byte[])iFotoempleado.EditValue;
            EmpleadoMnt.Denominacionfuncion = iDenominacionfuncion.Text.Trim();

            EmpleadoMnt.Nombrefuente = iNombrefuente.Text.Trim();
            EmpleadoMnt.Fuentetamanio = (decimal)iFuentetamanio.EditValue;
            EmpleadoMnt.Fuentenegrita = (bool)iFuentenegrita.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //PersonaMnt.Createdby = IdUsuario;
                    //PersonaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //PersonaMnt.Modifiedby = IdUsuario;
                    //PersonaMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = Service.SaveEmpleado(EmpleadoMnt);
                    EmpleadoMnt.Idempleado = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateEmpleado(EmpleadoMnt);
                    break;
                }
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


            return true;
        }
        private void EliminaRegistro()
        {
            if (Convert.ToInt32(pkIdEntidad.EditValue) > 0)
            {
                if (DialogResult.Yes == XtraMessageBox.Show(Resources.msgEliminarRegistro,
                                                        Resources.titPregunta, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        Service.DeleteEmpleado(IdEntidadMnt);
                        SeEliminoObjeto = true;
                        Close();
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
                        SeEliminoObjeto = false;
                        DeshabilitarBtnMnt();
                        CamposSoloLectura(true);
                        throw;
                    }
                }
            }
        }
        private void EstablecerPermisos()
        {
            if (FormParent == null)
            {
                int index = Name.Trim().LastIndexOf("Mnt", StringComparison.Ordinal);
                string nameFrm = Name.Substring(0, index) + "Frm";
                Permisos = Service.GetPermisosForm(IdUsuario, nameFrm);
            }
            else
            {
                Permisos = FormParent.Permisos;
            }            

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Nuevo;
                    btnGrabarCerrar.Enabled = Permisos.Nuevo;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    CamposSoloLectura(!Permisos.Editar);
                    break;
            }
        }
        private void bmMantenimiento_ItemClick(object sender, ItemClickEventArgs e)
        {            
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();
                    TipoMnt = TipoMantenimiento.Nuevo;
                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    EmpleadoMnt = null;
                    EmpleadoMnt = new Empleado();

                    btnGrabar.Enabled = true;
                    btnGrabarCerrar.Enabled = true;
                    btnGrabarNuevo.Enabled = true;      

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                    ValoresPorDefecto();

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);
                    break;

                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        btnGrabar.Enabled = false;
                        btnGrabarCerrar.Enabled = false;
                        btnGrabarNuevo.Enabled = false;
                        TipoMnt = TipoMantenimiento.Modificar;

                        if (Permisos.Eliminar)
                        {
                            btnEliminar.Enabled = true;
                            btnActualizar.Enabled = true;
                        }
                    }                    
                    break;
                case "btnGrabarCerrar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        Close();
                    }                    
                    break;
                case "btnGrabarNuevo":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        LimpiarCampos();
                        TipoMnt = TipoMantenimiento.Nuevo;
                        pkIdEntidad.EditValue = 0;
                        IdEntidadMnt = 0;

                        btnEliminar.Enabled = false;
                        btnActualizar.Enabled = false;

                        ValoresPorDefecto();

                        EmpleadoMnt = null;
                        EmpleadoMnt = new Empleado();
                    }

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);

                    break;
                case "btnEliminar":
                    EliminaRegistro();
                    break;
                case "btnLimpiarCampos":
                    LimpiarCampos();
                    break;
                case "btnActualizar":
                    if (IdEntidadMnt > 0)
                    {
                        TraerDatos();
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        Close();
                    }
                    else
                    {
                        EmpleadoMnt = null;
                        Close();
                    }                    
                    break;
            }
        }
        private void DeshabilitarBtnMnt()
        {
            pkIdEntidad.EditValue = 0;
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = false;
            btnGrabarCerrar.Enabled = false;
            btnGrabarNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnActualizar.Enabled = false;
        }
        private void EmpleadoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }
        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }
        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(this, readOnly);
        }
        private void ValoresPorDefecto()
        {
            bePersona.Select();
        }
        private void EmpleadoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormParent != null)
            {                
                if (SeEliminoObjeto)
                {
                    FormParent.CargarDatosConsulta();
                }
                if (SeGuardoObjeto)
                {                    
                    FormParent.IdEntidadMnt = IdEntidadMnt;
                    FormParent.CargarDatosConsulta();
                    FormParent.SetFocusIdEntity();
                }
            }
            e.Cancel = false;
        }
        private void iIdarea_EditValueChanged(object sender, EventArgs e)
        {
            var idAreaSel = iIdarea.EditValue;
            if (idAreaSel != null)
            {
                VwArea vwAreaSel = VwAreaList.FirstOrDefault(x => x.Idarea == (int) idAreaSel);
                rNombreempresa.EditValue = vwAreaSel != null ? vwAreaSel.Nombreempresa : string.Empty;
            }
            else
            {
                rNombreempresa.EditValue = string.Empty;
            }

        }

        private void CargarReferenciasCpVenta()
        {

            VwTipoCpVentaList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "CPVENTA" && x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdtipoCpVenta.Properties.DataSource = VwTipoCpVentaList;
            iIdtipoCpVenta.Properties.DisplayMember = "Nombretipocp";
            iIdtipoCpVenta.Properties.ValueMember = "Idtipocp";
            iIdtipoCpVenta.Properties.BestFitMode = BestFitMode.BestFit;

            VwCptooperacionCpVentaList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "CPVENTA" && x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdcptooperacionCpVenta.Properties.DataSource = VwCptooperacionCpVentaList;
            iIdcptooperacionCpVenta.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacionCpVenta.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacionCpVenta.Properties.BestFitMode = BestFitMode.BestFit;

            VwTipocReciboIngresoList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "RECIBO-INGRESO" && x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdtipocpreciboingreso.Properties.DataSource = VwTipocReciboIngresoList;
            iIdtipocpreciboingreso.Properties.DisplayMember = "Nombretipocp";
            iIdtipocpreciboingreso.Properties.ValueMember = "Idtipocp";
            iIdtipocpreciboingreso.Properties.BestFitMode = BestFitMode.BestFit;


            VwCptooperacionReciboIngresoList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "RECIBO-INGRESO" && x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();

            iIdcptooperacionReciboIngreso.Properties.DataSource = VwCptooperacionReciboIngresoList;
            iIdcptooperacionReciboIngreso.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacionReciboIngreso.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacionReciboIngreso.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void iIdtipocpcaja_EditValueChanged(object sender, EventArgs e)
        {
            var iIdtipocpcajaSel = iIdtipoCpVenta.EditValue;
            if (iIdtipocpcajaSel != null)
            {
                VwTipocp vwTipocpSel = VwTipoCpVentaList.FirstOrDefault(x => x.Idtipocp == (int)iIdtipocpcajaSel);
                if (vwTipocpSel != null)
                {
                    rSerieCpVenta.EditValue = vwTipocpSel.Seriecp;
                    rSucursalTipoCpVenta.EditValue = vwTipocpSel.Nombresucursal;
                }
                else
                {
                    rSerieCpVenta.EditValue = null;
                    rSucursalTipoCpVenta.EditValue = null;

                }
            }
            else
            {
                rSerieCpVenta.EditValue = null;
                rSucursalTipoCpVenta.EditValue = null;  
            }
        }

        private void iIdcptooperacioncaja_EditValueChanged(object sender, EventArgs e)
        {
            var iIdcptooperacioncajaSel = iIdcptooperacionCpVenta.EditValue;
            if (iIdcptooperacioncajaSel == null)
            {
                rSucursalOperacionCpVenta.EditValue = null;
            }
            else
            {
                VwCptooperacion vwCptooperacionSel = VwCptooperacionCpVentaList.FirstOrDefault(x => x.Idcptooperacion == (int) iIdcptooperacioncajaSel);
                rSucursalOperacionCpVenta.EditValue = vwCptooperacionSel != null ? vwCptooperacionSel.Nombresucursal : null;
            }
        }

        private void iIdtipocpreciboingreso_EditValueChanged(object sender, EventArgs e)
        {
            var idtipocpreciboingresoSel = iIdtipocpreciboingreso.EditValue;
            if (idtipocpreciboingresoSel != null)
            {
                VwTipocp vwTipocpSel = VwTipocReciboIngresoList.FirstOrDefault(x => x.Idtipocp == (int)idtipocpreciboingresoSel);
                if (vwTipocpSel != null)
                {
                    rSerieReciboIngreso.EditValue = vwTipocpSel.Seriecp;
                    rSucursalTipoCpRecibo.EditValue = vwTipocpSel.Nombresucursal;
                }
                else
                {
                    rSerieReciboIngreso.EditValue = null;
                    rSucursalTipoCpRecibo.EditValue = null;

                }
            }
            else
            {
                rSerieReciboIngreso.EditValue = null;
                rSucursalTipoCpRecibo.EditValue = null;
            }
        }

        private void bePersona_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            BaseMntFrm personaMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    var buscadorPersonaFrm = new BuscadorPersonaFrm();
                    buscadorPersonaFrm.ShowDialog();

                    if (buscadorPersonaFrm.DialogResult == DialogResult.OK &&
                        buscadorPersonaFrm.PersonaSel != null)
                    {
                        //Asignar al edit value del campo id foraneo
                        iIdpersona.EditValue = buscadorPersonaFrm.PersonaSel.Idpersona;
                    }
                    break;
                case 1: //Nuevo registro
                    personaMntFrm = new BaseMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    personaMntFrm.ShowDialog();

                    if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                    {
                        iIdpersona.EditValue = personaMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idPersonaMnt = iIdpersona.EditValue;
                    if (idPersonaMnt != null && (int)idPersonaMnt > 0)
                    {
                        personaMntFrm = new BaseMntFrm((int)idPersonaMnt, TipoMantenimiento.Modificar, null, null);
                        personaMntFrm.ShowDialog();
                        if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                        {
                            iIdpersona.EditValue = 0;
                            iIdpersona.EditValue = personaMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }
        }

        private void iIdpersona_EditValueChanged(object sender, EventArgs e)
        {
            var idPersona = iIdpersona.EditValue;
            if (idPersona == null || (int)idPersona <= 0) return;

            VwPersona personaSel = Service.GetVwPersona(((int)idPersona));
            if (personaSel != null)
            {
                //Cargar datos a controles
                bePersona.Text = personaSel.Razonsocial.Trim();
                iIdpersona.EditValue = personaSel.Idpersona;
                rNroDocPersona.EditValue = string.Format("{0} {1}", personaSel.Abreviaturadocentidad2, personaSel.Nrodocentidad2);
                rDireccionfiscal.EditValue = string.Format("{0} {1}", personaSel.Direccionfiscal, personaSel.Nombreubigeo);
            }
        }
    }
}