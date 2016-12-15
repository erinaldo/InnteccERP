using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("cierrecajadet")]
	public class Cierrecajadet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcierrecajadet")]
		public int Idcierrecajadet { get; set; }
		public int Idcierrecaja { get; set; }
		public int Idmediopago { get; set; }
		public decimal Importe { get; set; }
        public int? Idcptooperacion { get; set; }
	}
}
