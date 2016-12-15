using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cuadrocomparativoarticulo")]
	public class Cuadrocomparativoarticulo
	{
		[PrimaryKey]
        [AutoIncrement]
		[Alias("idcuadrocomparativoarticulo")]
		public int Idcuadrocomparativoarticulo { get; set; }
		public int Idcuadrocomparativoprv { get; set; }
		public int Idcotizacionprvdet { get; set; }
		public decimal Preciounitario { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Descuento1 { get; set; }
		public decimal Descuento2 { get; set; }
		public decimal Descuento3 { get; set; }
		public decimal Descuento4 { get; set; }
		public decimal Porcentajepercepcion { get; set; }
		public decimal Preciounitarioneto { get; set; }
		public decimal Importetotal { get; set; }
		public int Diasdeentrega { get; set; }
		public string Justificacion { get; set; }
		public bool Buenapro { get; set; }
	}
}
