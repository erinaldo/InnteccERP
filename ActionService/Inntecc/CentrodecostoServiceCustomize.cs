namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoCentroDeCosto(int idSucursal)
        {
            return CentrodecostoDao.GetSiguienteCodigoCentroDeCosto(idSucursal);
        }

        public bool CodigoCentroDeCostoExiste(string codigo, int idSucursal)
        {
            var centroDeCosto  = CentrodecostoDao.Get(x => x.Codigocentrodecosto == codigo && x.Idempresa == idSucursal);
            return centroDeCosto != null;
        }
    }
}