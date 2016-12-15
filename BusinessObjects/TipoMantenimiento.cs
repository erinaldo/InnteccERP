using System;

namespace BusinessObjects
{
    [Flags]
    public enum TipoMantenimiento
    {
        SinEspecificar = 0,
        Nuevo = 1,
        Modificar = 2,
        Eliminar = 3        
    }
}