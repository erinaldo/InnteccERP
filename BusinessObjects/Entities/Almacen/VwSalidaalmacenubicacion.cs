using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwsalidaalmacenubicacion")]
	public class VwSalidaalmacenubicacion
	{
		[PrimaryKey]
		[Alias("idsalidaalmacenubicacion")]
		public int  Idsalidaalmacenubicacion { get; set; }
		public int  Idsalidaalmacendet { get; set; }
		public int  Idubicacion { get; set; }
		public int?  Idsucursal { get; set; }
		public int?  Idalmacen { get; set; }
		public string Ambiente { get; set; }
		public string Columna { get; set; }
		public string Fila { get; set; }
		public decimal Cantidadarticulo { get; set; }
		public string Nombreubicacion { get; set; }
	}
}
