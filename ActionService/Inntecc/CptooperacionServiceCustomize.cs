namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoCptooperacion()
        {
            return CptooperacionDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoCptooperacionExiste(string codigo)
        {
            return CptooperacionDao.ExistsAlphanumericCorrelative(codigo);
        }
    }
}