using System;
using System.Collections.Generic;
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
    public partial class EquipoMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public EquipoFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Equipo EquipoMnt { get; set; }
        public List<Clasificacionequipo> ClasificacionequipoList { get; set; }
        public List<VwModeloequipo> VwModeloequipoList { get; set; }
        private List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public EquipoMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, EquipoFrm formParent) 
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
        private void EquipoMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
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
                    EquipoMnt = new Equipo();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    break;
            }           
        }
        private void CargarReferencias()
        {
            ClasificacionequipoList = Service.GetAllClasificacionequipo("Nombreclasificacionequipo");
            iIdclasificacionequipo.Properties.DataSource = ClasificacionequipoList;
            iIdclasificacionequipo.Properties.DisplayMember = "Nombreclasificacionequipo";
            iIdclasificacionequipo.Properties.ValueMember = "Idclasificacionequipo";
            iIdclasificacionequipo.Properties.BestFitMode = BestFitMode.BestFit;

            VwModeloequipoList = Service.GetAllVwModeloequipo("nombremarcaequipo,nombremodeloequipo");
            iIdmodeloequipo.Properties.DataSource = VwModeloequipoList;
            iIdmodeloequipo.Properties.DisplayMember = "Marcamodelo";
            iIdmodeloequipo.Properties.ValueMember = "Idmodeloequipo";
            iIdmodeloequipo.Properties.BestFitMode = BestFitMode.BestFit;

            VwCentrodecostoList = Service.GetAllVwCentrodecosto("descripcioncentrodecosto");
            iIdcentrocosto.Properties.DataSource = VwCentrodecostoList;
            iIdcentrocosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdcentrocosto.Properties.ValueMember = "Idcentrodecosto";
            iIdcentrocosto.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {

                EquipoMnt = Service.GetEquipo(IdEntidadMnt);

                rCodigoequipo.EditValue = EquipoMnt.Codigoequipo;
                iNombreequipo.EditValue = EquipoMnt.Nombreequipo;
                iColorequipo.EditValue = EquipoMnt.Colorequipo;
                iPlacaequipo.EditValue = EquipoMnt.Placaequipo;
                iNumeroserieequipo.EditValue = EquipoMnt.Numeroserieequipo;
                iAnioequipo.EditValue = EquipoMnt.Anioequipo;
                iCapacidadequipo.EditValue = EquipoMnt.Capacidadequipo;
                iIdclasificacionequipo.EditValue = EquipoMnt.Idclasificacionequipo;
                iIdmodeloequipo.EditValue = EquipoMnt.Idmodeloequipo;
                iMarcamotor.EditValue = EquipoMnt.Marcamotor;
                iModelomotor.EditValue = EquipoMnt.Modelomotor;
                iPotenciamotor.EditValue = EquipoMnt.Potenciamotor;
                iNumeromotor.EditValue = EquipoMnt.Numeromotor;
                iNumeroseriemotor.EditValue = EquipoMnt.Numeroseriemotor;
                iObservaciones.EditValue = EquipoMnt.Observaciones;
                iIdcentrocosto.EditValue = EquipoMnt.Idcentrocosto;
                iVigenciaseguro.EditValue = EquipoMnt.Vigenciaseguro;
                iCodigodebarra.EditValue = EquipoMnt.Codigodebarra;
                iVencimientoitv.EditValue = EquipoMnt.Vencimientoitv;
                nHoraminima.EditValue = EquipoMnt.Horaminima;
                Alquilado.EditValue = EquipoMnt.Alquilado;
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


            EquipoMnt.Codigoequipo = rCodigoequipo.Text.Trim();
            EquipoMnt.Nombreequipo = iNombreequipo.Text.Trim();
            EquipoMnt.Numeroserieequipo = iNumeroserieequipo.Text.Trim();
            EquipoMnt.Placaequipo = iPlacaequipo.Text.Trim();
            EquipoMnt.Colorequipo = iColorequipo.Text.Trim();
            EquipoMnt.Anioequipo = (int)iAnioequipo.Value;
            EquipoMnt.Capacidadequipo = iCapacidadequipo.Text.Trim();
            EquipoMnt.Idclasificacionequipo = (int?)iIdclasificacionequipo.EditValue;
            EquipoMnt.Idmodeloequipo = (int?)iIdmodeloequipo.EditValue;
            EquipoMnt.Marcamotor = iMarcamotor.Text.Trim();
            EquipoMnt.Modelomotor = iModelomotor.Text.Trim();
            EquipoMnt.Potenciamotor = iPotenciamotor.Text.Trim();
            EquipoMnt.Numeromotor = iNumeromotor.Text.Trim();
            EquipoMnt.Numeroseriemotor = iNumeroseriemotor.Text.Trim();
            EquipoMnt.Observaciones = iObservaciones.Text.Trim();
            EquipoMnt.Idcentrocosto = (int)iIdcentrocosto.EditValue;
            EquipoMnt.Vigenciaseguro = (DateTime?)iVigenciaseguro.EditValue;
            EquipoMnt.Codigodebarra = (string)iCodigodebarra.EditValue;
            EquipoMnt.Vencimientoitv = (DateTime?)iVencimientoitv.EditValue;
            EquipoMnt.Horaminima = (Decimal)nHoraminima.EditValue;
            EquipoMnt.Alquilado = (bool)Alquilado.EditValue;

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
                    IdEntidadMnt = Service.SaveEquipo(EquipoMnt);
                    EquipoMnt.Idequipo = IdEntidadMnt;
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    break;
                case TipoMantenimiento.Modificar:
                    Service.UpdateEquipo(EquipoMnt);
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
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (Service.CodigoEquipoExiste(rCodigoequipo.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                rCodigoequipo.EditValue = Service.GetSiguienteCodigoEquipo();
            }

            if (Service.CodigoBarraEquipoExiste(rCodigoequipo.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                XtraMessageBox.Show("Código de barras ya existe verifique.", Resources.titAtencion, MessageBoxButtons.OK,
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
                        Service.DeleteEquipo(IdEntidadMnt);
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

                    EquipoMnt = null;
                    EquipoMnt = new Equipo();

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

                        EquipoMnt = null;
                        EquipoMnt = new Equipo();
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
                        EquipoMnt = null;
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
        private void EquipoMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
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
            rCodigoequipo.EditValue = Service.GetSiguienteCodigoEquipo();
        }
        private void EquipoMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void iIdclasificacionequipo_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            var clasificacionequipoFrm = new ClasificacionequipoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            clasificacionequipoFrm.ShowDialog();
            if (clasificacionequipoFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Clasificacionequipo clasificacionequipo = clasificacionequipoFrm.ClasificacionequipoMnt;
                if (clasificacionequipo.Idclasificacionequipo > 0)
                {
                    ClasificacionequipoList.Add(clasificacionequipo);
                    e.Cancel = false;
                    e.NewValue = clasificacionequipo.Idclasificacionequipo;
                }
            }
        }
        private void iIdmodeloequipo_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            var modeloequipoMntFrm = new ModeloequipoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            modeloequipoMntFrm.ShowDialog();
            if (modeloequipoMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                VwModeloequipo vwModeloequipo = Service.GetVwModeloequipo(modeloequipoMntFrm.IdEntidadMnt);
                if (vwModeloequipo.Idmodeloequipo > 0)
                {
                    VwModeloequipoList.Add(vwModeloequipo);
                    e.Cancel = false;
                    e.NewValue = vwModeloequipo.Idmodeloequipo;
                }
            }
        }
        private void iIdcentrocosto_AddNewValue(object sender, AddNewValueEventArgs e)
        {

            CentrodecostoMntFrm centrodecostoMntFrm = new CentrodecostoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            centrodecostoMntFrm.ShowDialog();
            if (centrodecostoMntFrm.IdEntidadMnt > 0)
            {
                VwCentrodecosto vwCentrodecosto = Service.GetVwCentrodecosto(x => x.Idcentrodecosto == centrodecostoMntFrm.IdEntidadMnt);
                if (vwCentrodecosto != null)
                {
                    VwCentrodecostoList.Add(vwCentrodecosto);
                    e.Cancel = false;
                    e.NewValue = vwCentrodecosto.Idcentrodecosto;
                }
            }
        }
        private void cmdGenEan13_Click(object sender, EventArgs e)
        {
            if (Service.CodigoEquipoExiste(rCodigoequipo.Text.Trim()))
            {
                rCodigoequipo.EditValue = Service.GetSiguienteCodigoEquipo();
            }
            iCodigodebarra.EditValue = GenerarEan13();
        }
        private object GenerarEan13()
        {
            string nroRucEmpresaSel = SessionApp.EmpresaSel.Ruc.Trim();
            string codigoBarra12 = "775" + nroRucEmpresaSel.Substring(4,4) + rCodigoequipo.Text.Trim();           
            int iSum = 0;
            int iSumInpar = 0;
            int iDigit;
            string ean = codigoBarra12; // 12 digitos unicamente
            ean = ean.PadLeft(13, '0');
            for (int i = ean.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(ean.Substring(i - 1, 1));
                if (i % 2 != 0)
                {
                    iSumInpar += iDigit;
                }
                else
                {
                    iSum += iDigit;
                }
            }
            iDigit = (iSumInpar * 3) + iSum;
            int iCheckSum = (10 - (iDigit % 10)) % 10;
            return codigoBarra12 + iCheckSum;
        }
    }
}