using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CantidadReferenciasItemOrdenCompra(int idordencompradet)
        {
            long cntReferenciasEntrada = VwEntradaalmacendetDao.Count(x =>
                x.Idordencompradet == idordencompradet
                && !x.Ordencompraanulado);
            return cntReferenciasEntrada;
        }

        public Ordencompradet UltimoRegistroOrdenCompraDet()
        {
            return OrdencompradetDao.UltimoRegistroOrdenCompraDet();
        }
    }
}