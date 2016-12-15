namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoPrioridad()
        {
            return PrioridadDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoPrioridadExiste(string codigo)
        {
            return PrioridadDao.ExistsAlphanumericCorrelative(codigo);
        }
    }
}