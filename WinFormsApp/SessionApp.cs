using System;
using System.Linq;
using ActionService;
using BusinessObjects.Entities;

namespace WinFormsApp
{
    public class SessionApp
    {
        internal static Sucursal SucursalSel { get; set; }
        internal static Empresa EmpresaSel { get; set; }
        internal static Usuario UsuarioSel { get; set; }
        internal static Grupousuario GrupoUsarioSel { get; set; }
        internal static Empleado EmpleadoSel { get; set; }
        internal static VwEmpleado VwEmpleadoSel { get; set; }
        internal static string NombreBaseDeDatos { get; set; }
        internal static string NombreServidor { get; set; }
        internal static DateTime DateServer { get; set; }
        internal static int EjercicioActual { get; set; }
        internal static VwInventario VwInventarioInicial { get; set; }

        static readonly IService Service = new Service();

        internal static string VersionApp { get; set; }
        internal static void RecargarInventarioInicial()
        {        
            string orden = "fechainventarioinicial desc limit 1";
            string where = string.Format("idempresa = {0}", EmpresaSel.Idempresa);
            VwInventarioInicial = Service.GetAllVwInventario(where, orden).FirstOrDefault();
        }
    }
}