namespace ActionService
{
    public partial class Service
    {
        public bool CodigoSucursalExiste(string codigoSucursal)
        {
            var sucursal = SucursalDao.Get(x => x.Codigosucursal.Trim() == codigoSucursal.Trim());
            return sucursal != null;
        }
    }
}