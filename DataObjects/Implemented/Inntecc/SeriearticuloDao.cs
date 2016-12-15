using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
    public class SeriearticuloDao : Dao<Seriearticulo>, ISeriearticuloDao
    {
        public bool EstablecerSerieUtilizada(int idseriearticulo, bool serieutilizada)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.UpdateOnly(new Seriearticulo { Serieutilizada = serieutilizada },
                q => q.Update(p => p.Serieutilizada).Where(x => x.Idseriearticulo == idseriearticulo));
                return true;
            }
        }
    }
}
