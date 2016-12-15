using System;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoArticulo()
        {
            return ArticuloDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoArticuloExiste(string codigo)
        {
            return ArticuloDao.ExistsAlphanumericCorrelative(codigo);
        }

        public bool CodigoBarraArticuloExiste(string codigoBarra, int idEmpresaSel)
        {
            Articulo articulo = ArticuloDao.Get(x => x.Codigodebarra == codigoBarra && x.Idempresa == idEmpresaSel);
            return articulo != null;
        }

        public decimal ObtenerStockAlmacen(int idArticulo, DateTime fechaInicial, DateTime fechaFinal, int? idAlmacen)
        {
            return ArticuloDao.ObtenerStockAlmacen(idArticulo, fechaInicial, fechaFinal, idAlmacen);
        }
    }
}