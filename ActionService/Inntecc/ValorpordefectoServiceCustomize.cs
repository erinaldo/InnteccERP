using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public Valorpordefecto ObtenerObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov)
        {
            return ValorpordefectoDao.Get(x =>
                x.Idsucursal == idSucursal &&
                x.Idempleado == idEmpleado &&
                x.Nombretipodocmov == nombreTipodocMov);
        }

        public bool RegistrarObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov, int idTipoCpPorDefecto,int idCptoOperacionPorDefecto)
        {
            return ValorpordefectoDao.RegistrarObjectoValoresPorDefecto(idSucursal, idEmpleado, nombreTipodocMov,
                idTipoCpPorDefecto, idCptoOperacionPorDefecto);

        }
    }
}