using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using Utilities;

namespace WinFormsApp
{
    public partial class UsuarioIngresoFrm : XtraForm
    {
        static readonly IService Service = new Service();
        public Sucursal SucursalSel { get; set; }
        public Empresa EmpresaSel { get; set; }
        public Grupousuario GrupousuarioSel { get; set; }
        public Empleado EmpleadoSel { get; set; }
        public List<Sucursal> SucursalList { get; set; }
        public List<Empresa> EmpresaList { get; set; }

        private readonly HelperDb _helperDb;
        public UsuarioIngresoFrm()
        {
            InitializeComponent();
            Activate();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);   

            _helperDb = new HelperDb();

        }
        private void CargarEmpresas()
        {
            EmpresaList = Service.GetAllEmpresa("Razonsocial");
            iIdempresa.Properties.DataSource = EmpresaList;
            iIdempresa.Properties.DisplayMember = "Razonsocial";
            iIdempresa.Properties.ValueMember = "Idempresa";
            iIdempresa.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarSucursales(int idempresa)
        {
            string where = string.Format("idempresa = {0}", idempresa);
            SucursalList = Service.GetAllSucursal(where, "Nombresucursal");
            iIdsucursal.Properties.DataSource = SucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var idEmpresaSel = iIdempresa.EditValue;
            if (idEmpresaSel == null)
            {
                XtraMessageBox.Show("Seleccione la empresa", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iIdempresa.Focus();
                return;
            }

            var idSucursalSel = iIdsucursal.EditValue;
            if (idSucursalSel == null)
            {
                XtraMessageBox.Show("Seleccione la sucursal", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iIdsucursal.Focus();
                return;
            }

            if (txtUsuario.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Digite el nombre de usuario", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == string.Empty)
            {
                XtraMessageBox.Show("Digite la contraseña", "Error en contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;

            Usuario usuarioLogin = Service.GetUsuario(x => x.Nombreusuario == txtUsuario.Text.Trim() && x.Idempresa == (int)idEmpresaSel);

            Cursor = Cursors.Default;

            if (usuarioLogin == null)
            {
                XtraMessageBox.Show("Error en identificación del usuario, revise los datos", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                txtUsuario.SelectAll();
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                //VwEmpleado vwEmpleado = Service.GetVwEmpleado(x => x.Idempleado == usuarioLogin.Idempleado);

                //if (vwEmpleado != null)
                //{
                //    if ((int)idSucursalSel != vwEmpleado.Idsucursal)
                //    {
                //        XtraMessageBox.Show("El usuario no tiene acceso a la sucursal seleccionada", "Atención",
                //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        Cursor = Cursors.Default;
                //        return;
                //    }
                //}


                if (Service.ContraseniaValida(usuarioLogin.Pwdusuario.Trim(), Cryptography.EncryptStringAes(txtPassword.Text.Trim())))
                {
                    Cursor = Cursors.Default;
                    var sucursalSel = SucursalList.FirstOrDefault(x => x.Idsucursal == (int) iIdsucursal.EditValue);
                    var empresaSel = EmpresaList.FirstOrDefault(x => x.Idempresa == (int) iIdempresa.EditValue);
                    var usuarioSel = Service.GetUsuario(x => x.Nombreusuario == txtUsuario.Text.Trim());
                    var grupoUsuarioSel = Service.GetGrupousuario(x => x.Idgrupousuario == usuarioSel.Idgrupousuario);
                    var empleadoSel = Service.GetEmpleado(x => x.Idempleado == usuarioSel.Idempleado);
                    var vwEmpleadoSel = Service.GetVwEmpleado(x => x.Idempleado == usuarioSel.Idempleado);
                    string condicion = "fechainventarioinicial desc limit 1";
                    string where = string.Format("idempresa = {0}", (int) iIdempresa.EditValue);
                    VwInventario vwInventario = Service.GetAllVwInventario(where, condicion).FirstOrDefault();
                    SessionApp.SucursalSel = sucursalSel;
                    SessionApp.EmpresaSel = empresaSel;
                    SessionApp.UsuarioSel = usuarioSel;
                    SessionApp.GrupoUsarioSel = grupoUsuarioSel;
                    SessionApp.EmpleadoSel = empleadoSel;
                    SessionApp.VwEmpleadoSel = vwEmpleadoSel;
                    SessionApp.DateServer = _helperDb.FechaActualServidor();
                    SessionApp.EjercicioActual = (int)speAnio.Value;
                    SessionApp.VwInventarioInicial = vwInventario;

                    GuardarDatosEmpresaSucursal();


                    //if (!ExisteTipoDeCambioFechaActual())
                    //{                        
                    //    return;
                    //}

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show("Error en la contraseña", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }

            
        }
        private void ObtenerDatosEmpresaSucursal()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    var idEmpresaSel = Convert.ToInt32(registryKey.GetValue("EmpresaPorDefecto", "0"));
                    var idSucursalSel =Convert.ToInt32(registryKey.GetValue("SucursalPorDefecto", "0"));
                    if (idEmpresaSel > 0)
                    {
                        iIdempresa.EditValue = idEmpresaSel;
                        iIdsucursal.EditValue = idSucursalSel;
                        txtUsuario.Select();
                    }
                }
                

            }
        }
        private void GuardarDatosEmpresaSucursal()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue("EmpresaPorDefecto", iIdempresa.EditValue.ToString(), RegistryValueKind.String);
                    registryKey.SetValue("SucursalPorDefecto", iIdsucursal.EditValue.ToString(), RegistryValueKind.String);
                }                
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void UsuarioIngresoFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void UsuarioIngresoFrm_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = _helperDb.FechaActualServidor();
            //DateTime fechaActual = DateTime.Now;
            speAnio.EditValue = fechaActual.Year;
            CargarEmpresas();

            BringToFront();
            TopMost = true;
            TopMost = false;
            Activate();

            iIdempresa.Focus();
            iIdempresa.Select();

            ObtenerDatosEmpresaSucursal();

            MostrarVersion();


            ////Valores por defecto
            //txtUsuario.EditValue = @"ADMIN";
            //txtPassword.EditValue = @"123456";
            //btnAceptar.Select();


        }
        private void MostrarVersion()
        {
            string rutaEjecucion = Application.StartupPath;
            string nombreEjecutable = string.Format("{0}\\{1}", rutaEjecucion, "InnteccErp.exe");
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(nombreEjecutable);
            lblVersion.Text = string.Format("v.{0}",fileVersionInfo.ProductVersion);
        }
        private void iIdempresa_EditValueChanged(object sender, EventArgs e)
        {
            int idEmpresaSel = (int)iIdempresa.EditValue;
            if (idEmpresaSel > 0)
            {
                CargarSucursales(idEmpresaSel);    
            }
            
        }      
    }
}