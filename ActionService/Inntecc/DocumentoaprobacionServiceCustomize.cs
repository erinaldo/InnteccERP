namespace ActionService
{
    public partial class Service
    {
        public bool EliminarReferenciasDocumentoAprobacion(int idtipodocmov, int iddocumentomov)
        {
            return DocumentoaprobacionDao.EliminarReferenciasDocumentoAprobacion(idtipodocmov, iddocumentomov);
        }
    }
}