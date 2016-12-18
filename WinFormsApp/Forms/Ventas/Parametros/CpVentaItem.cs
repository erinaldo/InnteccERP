namespace WinFormsApp
{
    public class CpVentaItem
    {
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public int IdTipoMonedaConsulta { get; set; }
        public int IdTipoCondicion { get; set; }
        public int? IdAreaEmpleado { get; set; }
        public int? IdProyectoCliente { get; set; }
        public int? IdCentroBeneficio { get; set; }
        public int IdCliente { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public decimal Porcentajeimpuesto { get; set; }
    }
}