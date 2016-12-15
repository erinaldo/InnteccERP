using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class AreaDao : Dao<Area>, IAreaDao
	{
        public string GetSiguienteCodigoArea(int idEmpresa)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sgteCodigo = db.SqlScalar<int>(string.Format("SELECT Max(cast(codigoarea as integer)) FROM {0} where idempresa = {1}", NameRelation,idEmpresa)) + 1;
                return sgteCodigo.ToString("D2");
            }
	    }
	}
}
