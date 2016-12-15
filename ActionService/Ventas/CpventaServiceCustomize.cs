using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarCpVenta(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, List<VwGuiaremisiondetimpcpventadet> vwGuiaremisiondetimpcpventadetImpList)
        {
            return CpventaDao.GuardarCpVenta(tipoMantenimiento, entidadCab, entidadDetList, vwGuiaremisiondetimpcpventadetImpList);
        }

        public bool CpVentaTieneReferenciaCaja(int idTipoCp, string serieTipoCp, string numeroTipoCp)
        {
            return VwRecibocajaingresodetDao.Count(x => x.Idtipocp == idTipoCp && x.Serietipocp == serieTipoCp && x.Numerotipocp == numeroTipoCp && !x.Anulado ) > 0;
        }

        public bool CpVentaTieneNotacredito(int idCpventa)
        {
            return VwNotacreditoclidetDao.Count(x => x.Idcpventa == idCpventa) > 0;
        }

        public int GuardarCpVentaReciboIngreso(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList)
        {
            return CpventaDao.GuardarCpVentaReciboIngreso(tipoMantenimiento, entidadCab, entidadDetList, recibocajaingreso, vWrecibocajaingresodetList);
        }

        public bool CpVentaTieneReferenciaSalidaAlmacen(int idCpVenta)
        {
            return VwSalidaalmacendetDao.Count(x => x.Idcpventa == idCpVenta && !x.Anulado) > 0;
        }
    }
}