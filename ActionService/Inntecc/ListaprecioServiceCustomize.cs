using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public int GuardarListaprecio(TipoMantenimiento tipoMantenimiento, Listaprecio listaprecioMnt)
        {
            return ListaprecioDao.GuardarListaprecio(tipoMantenimiento, listaprecioMnt);
        }
    }
}