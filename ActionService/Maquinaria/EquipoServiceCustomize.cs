using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoEquipo()
        {
            return EquipoDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoEquipoExiste(string codigo)
        {
            return EquipoDao.ExistsAlphanumericCorrelative(codigo);
        }

        public bool CodigoBarraEquipoExiste(string codigoBarra)
        {
            Equipo equipo = EquipoDao.Get(x => x.Codigodebarra == codigoBarra);
            return equipo != null;
        }
    }
}