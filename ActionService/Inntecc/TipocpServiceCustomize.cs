using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoTipoCp()
        {
            return TipocpDao.GetSiguienteCodigoTipoCp();
        }

        public bool CodigoTipoCpExiste(string codigotipocp)
        {
            var tipoCp = TipocpDao.Get(x => x.Codigotipocp == codigotipocp);
            return tipoCp != null;
        }

        public int ObtenerSiguienteCorrelativo(int idtipocp)
        {
            Tipocp tipocp = TipocpDao.Get(idtipocp);
            return tipocp.Numerocorrelativocp;
        }

        public bool ActualizarCorrelativo(int idtipocp, int sgtNumerocorrelativocp)
        {
            return TipocpDao.ActualizarCorrelativo(idtipocp, sgtNumerocorrelativocp);
        }
    }
}