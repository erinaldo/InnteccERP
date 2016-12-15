namespace ActionService
{
    public partial class Service
    {
        public int ObtenerIdEmpleadoApruebaModeloAutorizacion(int idtipodocmov, int idcptooperacion, decimal importeDocumento)
        {
            return VwModeloautorizacioninfoDao.ObtenerIdEmpleadoApruebaModeloAutorizacion(idtipodocmov, idcptooperacion, importeDocumento);
        }
    }
}