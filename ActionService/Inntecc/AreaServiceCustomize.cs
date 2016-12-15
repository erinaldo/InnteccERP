using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoArea(int idEmpresa)
        {
            return AreaDao.GetSiguienteCodigoArea(idEmpresa);
        }

        public bool CodigoAreaExiste(string codigo,int idEmpresa)
        {
            Area area = AreaDao.Get(x => x.Codigoarea == codigo && x.Idempresa == idEmpresa);
            return area != null;
        }

    }
}