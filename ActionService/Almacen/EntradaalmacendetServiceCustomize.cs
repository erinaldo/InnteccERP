using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public void ActualizarEntradaalmacendetCantidadVerificada(Entradaalmacendet entradaalmacendet)
        {
            EntradaalmacendetDao.ActualizarEntradaalmacendetCantidadVerificada(entradaalmacendet);
        }
    }
}