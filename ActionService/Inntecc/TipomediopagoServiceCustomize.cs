namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoMedioPago()
        {
            return TipomediopagoDao.GetNextAlphanumericCorrelative();
        }

        public bool CodigoCodigoMedioPagoExiste(string codigo)
        {
            return TipocondicionDao.ExistsAlphanumericCorrelative(codigo);
        }
    }
}
