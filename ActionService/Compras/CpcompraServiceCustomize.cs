using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarCpCompra(TipoMantenimiento tipoMantenimiento, Cpcompra entidadCab, List<VwCpcompradet> entidadDetList, List<VwEntradaalmacendet>  vwEntradaalmacendetListOrigen)
        {
            return CpcompraDao.GuardarCpCompra(tipoMantenimiento, entidadCab, entidadDetList, vwEntradaalmacendetListOrigen);
        }

        public string SiguienteNumeroCpCompraPorProveedor(int idTipoCp, int idProveedor, string numeroserie)
        {
            return CpcompraDao.SiguienteNumeroCpCompraPorProveedor(idTipoCp, idProveedor, numeroserie);
        }

        public bool CpCompraTieneReferenciasRendicionCajaChica(int idTipoCp, int idProveedor, string numeroserie, string numero)
        {
            return CpcompraDao.CpCompraTieneReferenciasRendicionCajaChica(idTipoCp, idProveedor, numeroserie, numero);
        }

        public bool CpCompraTieneReferenciaCaja(int idTipoCp, string serieTipoCp, string numeroTipoCp)
        {
            return VwRecibocajaegresodetDao.Count(x => x.Idtipocp == idTipoCp && x.Serietipocp == serieTipoCp && x.Numerotipocp == numeroTipoCp) > 0;
        }

        public bool CpCompraTieneNotaCredito(int idcpcompra)
        {
            
            return VwNotacreditodetDao.Count(x => x.Idcpcompra == idcpcompra) > 0;
        }
    }
}