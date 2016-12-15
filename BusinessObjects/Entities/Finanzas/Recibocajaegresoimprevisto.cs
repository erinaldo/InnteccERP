using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("recibocajaegresoimprevisto")]
	public class Recibocajaegresoimprevisto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrecibocajaegresoimprevisto")]
		public int Idrecibocajaegresoimprevisto { get; set; }
		public int Idrecibocajaegresodet { get; set; }
		public int Idtipocp { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal Importepago { get; set; }
	}
}
