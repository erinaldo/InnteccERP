using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IDocumentoaprobacionDao : IDao<Documentoaprobacion>
	{
        bool EliminarReferenciasDocumentoAprobacion(int idtipodocmov, int iddocumentomov);
	}
}
