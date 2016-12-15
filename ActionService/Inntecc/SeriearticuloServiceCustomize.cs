using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool EstablecerSerieUtilizada(int idseriearticulo, bool serieutilizada)
        {
            return SeriearticuloDao.EstablecerSerieUtilizada(idseriearticulo, serieutilizada);
        }

        public bool SerieArticuloExiste(string numeroserieitem)
        {
            Seriearticulo seriearticulo = SeriearticuloDao.Get(x => x.Numeroserieitem == numeroserieitem.Trim());
            return seriearticulo != null;
        }
    }
}