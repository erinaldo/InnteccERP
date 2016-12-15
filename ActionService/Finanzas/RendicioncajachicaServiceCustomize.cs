using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool ActualizarTotalesRendicionCajaChica(Rendicioncajachica rendicioncajachica)
        {
            return RendicioncajachicaDao.ActualizarTotalesRendicionCajaChica(rendicioncajachica);
        }
    }
}