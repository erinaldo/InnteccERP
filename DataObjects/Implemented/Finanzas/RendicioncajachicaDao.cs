using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class RendicioncajachicaDao : Dao<Rendicioncajachica>, IRendicioncajachicaDao
	{
	    public bool ActualizarTotalesRendicionCajaChica(Rendicioncajachica rendicioncajachica)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Rendicioncajachica>(new
                {
                    rendicioncajachica.Totaldocumento
                }, p => p.Idrendicioncajachica == rendicioncajachica.Idrendicioncajachica);
                return true;
            }
	    }


	}
}
