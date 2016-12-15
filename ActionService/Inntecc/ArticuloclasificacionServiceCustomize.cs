namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoClasificacionArticulo()
        {
            return ArticuloclasificacionDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoClasificacionArticuloExiste(string codigo)
        {
            return ArticuloclasificacionDao.ExistsAlphanumericCorrelative(codigo);
        }
    }
}