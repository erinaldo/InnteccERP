using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class CentrodecostoDao : Dao<Centrodecosto>, ICentrodecostoDao
	{
	    public string GetSiguienteCodigoCentroDeCosto(int idEmpresa)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sgteCodigo = db.SqlScalar<int>(string.Format("SELECT Max(cast(codigocentrodecosto as integer)) FROM {0} where idempresa = {1}", NameRelation, idEmpresa)) + 1;
                return sgteCodigo.ToString("D3");
            }
	    }
	}
}
