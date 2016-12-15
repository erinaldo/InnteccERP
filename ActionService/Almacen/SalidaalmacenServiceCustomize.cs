using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public void AnularSalidaDeAlmacen(string sqlCommand)
        {
            SalidaalmacenDao.ExecuteNonQuery(sqlCommand);
        }

        public bool ActualizarTotalesSalidaAlmacen(Salidaalmacen salidaalmacen)
        {
            return SalidaalmacenDao.ActualizarTotalesSalidaAlmacen(salidaalmacen);
        }

        public bool NumeroSalidaAlmacenExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            Salidaalmacen salidaalmacen = SalidaalmacenDao.Get(x => x.Idsucursal == idSucursal
                  && x.Idtipocp == idTipoCp
                  && x.Seriesalidaalmacen == numeroSerie
                  && x.Numerosalidaalmacen == numeroDocumento);
            return salidaalmacen != null;
        }
    }
}