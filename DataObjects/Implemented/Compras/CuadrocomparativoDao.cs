using System.Diagnostics;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class CuadrocomparativoDao : Dao<Cuadrocomparativo>, ICuadrocomparativoDao
	{
        public void AnularReferenciaCotizacionPrvCuadroComparativo(int idcuadrocomparativo)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                Cuadrocomparativo cuadrocomparativo = new Cuadrocomparativo
                {
                    Idcotizacionprv = null,
                    Idcuadrocomparativo = idcuadrocomparativo
                };

                db.Update<Cuadrocomparativo>(new
                {
                    cuadrocomparativo.Idcotizacionprv
                }, p => p.Idcuadrocomparativo == idcuadrocomparativo);

                Debug.WriteLine(db.GetLastSql());
            }
	    }
	}
}
