using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICpcompraDao : IDao<Cpcompra>
	{
        bool GuardarCpCompra(TipoMantenimiento tipoMantenimiento, Cpcompra entidadCab, List<VwCpcompradet> entidadDetList, List<VwEntradaalmacendet> vwEntradaalmacendetListOrigen);
	    string SiguienteNumeroCpCompraPorProveedor(int idTipoCp, int idProveedor,string numeroserie);
        bool CpCompraTieneReferenciasRendicionCajaChica(int idTipoCp, int idProveedor, string numeroserie, string numero);
	}
}
