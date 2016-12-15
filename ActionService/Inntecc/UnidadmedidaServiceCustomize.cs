namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoUnidadDeMedida()
        {
            return UnidadmedidaDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoUnidadDeMedidaExiste(string codigo)
        {
            return UnidadmedidaDao.ExistsAlphanumericCorrelative(codigo);
        }
    }
}