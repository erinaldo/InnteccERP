using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool ActualizarTotalesReciboCajaEgreso(Recibocajaegreso recibocajaegreso)
        {
            return RecibocajaegresoDao.ActualizarTotalesReciboCajaEgreso(recibocajaegreso);
        }


        public bool CajaegresoTieneReferenciaCajaChica(int idRecibocajaegreo)
        {
            return VwRendicioncajachicaDao.Count(x => x.Idrecibocaja == idRecibocajaegreo) > 0;
        }
    }
}