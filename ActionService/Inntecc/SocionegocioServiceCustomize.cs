using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoSocioNegocio()
        {
            return SocionegocioDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoSocioNegocioExiste(string codigo)
        {
            return SocionegocioDao.ExistsAlphanumericCorrelative(codigo);
        }

        public int GetIdDireccionPrincipal(int idSocioNegocio)
        {
            Socionegociodireccion socionegociodireccion = SocionegociodireccionDao.Get(x => x.Idsocionegocio == idSocioNegocio && x.Principal);
            if (socionegociodireccion != null)
            {
                return socionegociodireccion.Idsocionegociodireccion;
            }
            return 0;
        }
    }
}