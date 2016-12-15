namespace ActionService
{
    public partial class Service
    {
        public string GetSiguienteCodigoProyecto(int idEmpresa)
        {
            return ProyectoDao.GetSiguienteCodigoProyecto(idEmpresa);
        }

        public bool CodigoProyectoExiste(string codigo, int idEmpresa)
        {
            var proyecto = ProyectoDao.Get(x => x.Codigoproyecto == codigo && x.Idempresa == idEmpresa);
            return proyecto != null;
        }
    }
}