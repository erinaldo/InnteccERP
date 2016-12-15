using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("salidaalmacendet")]
    public class Salidaalmacendet : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idsalidaalmacendet")]
        public int Idsalidaalmacendet { get; set; }
        public int? Idsalidaalmacen { get; set; }
        public int Numeroitem { get; set; }
        public int? Idarticulo { get; set; }
        public string Especificacion { get; set; }
        public decimal Cantidad { get; set; }
        public int? Idunidadmedida { get; set; }
        public decimal Preciounitario { get; set; }
        public int? Idimpuesto { get; set; }
        public decimal Importetotal { get; set; }
        public int? Idguiaremisiondet { get; set; }
        public int? Idproyecto { get; set; }
        public int? Idarea { get; set; }
        public int? Idcentrodecosto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int? Idtipoafectacionigv { get; set; }
        public decimal Cantidadutilizada { get; set; }
        public bool Calcularitem { get; set; }
        public int? Idrendicioncajachicadet { get; set; }
        public int? Idcpcompradetrendicioncajachicadet { get; set; }
        public int? Idcpventadet { get; set; }
    }
}
