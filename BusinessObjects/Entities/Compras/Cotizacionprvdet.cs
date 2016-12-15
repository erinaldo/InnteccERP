using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cotizacionprvdet")]
	public class Cotizacionprvdet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcotizacionprvdet")]
		public int Idcotizacionprvdet { get; set; }
		public int Idcotizacionprv { get; set; }
		public int Numeroitem { get; set; }
		public decimal Cantidad { get; set; }
		public int Idrequerimientodet { get; set; }
	}
}
