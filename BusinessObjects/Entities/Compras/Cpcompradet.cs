using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("compras")]
    [Alias("cpcompradet")]
    public class Cpcompradet : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idcpcompradet")]
        public int Idcpcompradet { get; set; }
        public int Idcpcompra { get; set; }
        public int Numeroitem { get; set; }
        public int Idarticulo { get; set; }
        public decimal Cantidad { get; set; }
        public int Idunidadmedida { get; set; }
        public int Idimpuesto { get; set; }
        public decimal Preciounitario { get; set; }
        public string Especificacion { get; set; }
        public decimal Descuento1 { get; set; }
        public decimal Descuento2 { get; set; }
        public decimal Descuento3 { get; set; }
        public decimal Descuento4 { get; set; }
        public decimal Preciounitarioneto { get; set; }
        public decimal Importetotal { get; set; }
        public int Idcentrodecosto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int Idarea { get; set; }
        public int Idproyecto { get; set; }
        public int? Idordencompradet { get; set; }
        public decimal Pesounitario { get; set; }
        public decimal Pesototal { get; set; }
        public decimal Costounitario { get; set; }
        public decimal Descuentoproveedorcosto { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public int? Idordenserviciodet { get; set; }
        public bool Calcularitem { get; set; }
    }
}
