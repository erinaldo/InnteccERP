using System.Data;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class TipocpDao : Dao<Tipocp>, ITipocpDao
	{
        public string GetSiguienteCodigoTipoCp()
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sgteCodigo = db.SqlScalar<int>(string.Format("SELECT Max(cast(codigotipocp as integer)) FROM {0}", NameRelation)) + 1;
                return sgteCodigo.ToString("D3");
            }
        }

        public bool ActualizarCorrelativo(int idtipocp, int sgtNumerocorrelativocp)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    db.Update<Tipocp>(new { Numerocorrelativocp = sgtNumerocorrelativocp + 1 }, p => p.Idtipocp == idtipocp);
                    trans.Commit();
                    return true;
                }
            }
        }
	}
}
