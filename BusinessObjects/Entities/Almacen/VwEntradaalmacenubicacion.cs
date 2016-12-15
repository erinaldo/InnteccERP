using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwentradaalmacenubicacion")]
	public class VwEntradaalmacenubicacion
	{
		[PrimaryKey]
		[Alias("identradaalmacenubicacion")]
		public int  Identradaalmacenubicacion { get; set; }
		public int  Identradaalmacendet { get; set; }
		public int?  Idubicacion { get; set; }
		public int?  Idsucursal { get; set; }
		public int?  Idalmacen { get; set; }
		public string Ambiente { get; set; }
		public string Columna { get; set; }
		public string Fila { get; set; }
		public decimal Cantidadarticulo { get; set; }
		public string Nombreubicacion { get; set; }
	}
}
