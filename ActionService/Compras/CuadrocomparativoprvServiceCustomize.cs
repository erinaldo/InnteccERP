using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public void AnularReferenciaCotizacionPrvCuadroComparativo(int idcuadrocomparativo)
        {
            CuadrocomparativoDao.AnularReferenciaCotizacionPrvCuadroComparativo(idcuadrocomparativo);
        }

        public bool ActualizarTotalCuadroComparativoPrv(int idcuadrocomparativoprv, decimal totalDocumento)
        {
            return CuadrocomparativoprvDao.ActualizarTotalCuadroComparativoPrv(idcuadrocomparativoprv, totalDocumento);
        }

        public bool ActualizarItemBuenaProCuadroComparativoPrv(int idcuadrocomparativoprv, bool buenapro)
        {
            return CuadrocomparativoprvDao.ActualizarItemBuenaProCuadroComparativoPrv(idcuadrocomparativoprv, buenapro);
        }

        public bool CuadrocomparativoAprobado(int idcuadrocomparativo)
        {
            //Id Estado = 3 (Aprobado)
            Cuadrocomparativo cuadrocomparativo = CuadrocomparativoDao.Get(x => x.Idcuadrocomparativo == idcuadrocomparativo && x.Idestadocuadrocomparativo == 3);
            return cuadrocomparativo != null;
        }
    }
}