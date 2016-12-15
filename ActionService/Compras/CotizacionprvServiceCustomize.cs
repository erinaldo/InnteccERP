namespace ActionService
{
    public partial class Service
    {
        public bool CotizacionPrvTieneReferenciaCuadroComparativo(int idcotizacionprv)
        {
            return VwCuadrocomparativoarticuloDao.Count(x => x.Idcotizacionprv == idcotizacionprv) > 0;
        }
    }
}