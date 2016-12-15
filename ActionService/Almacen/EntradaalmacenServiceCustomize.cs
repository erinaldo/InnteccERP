using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public void AnularReferenciaEntradaOrdenCompraDet(int identradaalmacen)
        {
            EntradaalmacenDao.AnularReferenciaEntradaOrdenCompraDet(identradaalmacen);
        }

        public bool EntradaAlmacenTieneReferenciaVerificacion(int idEntradaAlmacen)
        {
            return VwEntradaalmacendetDao.Count(x => x.Identradaalmacen == idEntradaAlmacen && x.Cantidadverificada > 0) > 0;
        }

        public void AnularEntradaDeAlmacen(string sqlCommand)
        {
            EntradaalmacenDao.ExecuteNonQuery(sqlCommand);
        }

        public void ActualizarArticuloListaPrecioDesdeCostoPromedio(int idArticulo, int idlistaprecio, decimal costoPromedio)
        {
            string sqlCommandActualizar = string.Format(@"UPDATE ventas.articulolistaprecio 
                                                        set preciolista = {0} 
                                                        where   idarticulo = {1} and idlistaprecio = {2}"
                                       , costoPromedio
                                       , idArticulo
                                       , idlistaprecio);

            EntradaalmacenDao.ExecuteNonQuery(sqlCommandActualizar);
        }

        public bool ActualizarTotalesEntradaAlmacen(Entradaalmacen entradaalmacen)
        {
            return EntradaalmacenDao.ActualizarTotalesEntradaAlmacen(entradaalmacen);
        }

        public bool NumeroEntradaAlmacenExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            Entradaalmacen entradaalmacen = EntradaalmacenDao.Get(x => x.Idsucursal == idSucursal
                  && x.Idtipocp == idTipoCp
                  && x.Serieentradaalmacen == numeroSerie
                  && x.Numeroentradaalmacen == numeroDocumento);
            return entradaalmacen != null;
        }
    }
}