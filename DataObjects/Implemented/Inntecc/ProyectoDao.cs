using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class ProyectoDao : Dao<Proyecto>, IProyectoDao
	{
	    public string GetSiguienteCodigoProyecto(int idEmpresa)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sgteCodigo = db.SqlScalar<int>(string.Format("SELECT Max(cast(codigoproyecto as integer)) FROM {0} where idempresa = {1}", NameRelation, idEmpresa)) + 1;
                return sgteCodigo.ToString("D4");
            }
	    }
	}
}
