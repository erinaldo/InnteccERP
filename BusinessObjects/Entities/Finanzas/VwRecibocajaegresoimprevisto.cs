using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrecibocajaegresoimprevisto")]
	public class VwRecibocajaegresoimprevisto
	{
		[PrimaryKey]
		[Alias("idrecibocajaegresoimprevisto")]
		public int  Idrecibocajaegresoimprevisto { get; set; }
		public int  Idrecibocajaegresodet { get; set; }
		public int  Idtipocp { get; set; }
		public int  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int  Maxnumeroitems { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal  Importepago { get; set; }
	}
}
