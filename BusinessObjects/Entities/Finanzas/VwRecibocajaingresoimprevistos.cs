using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrecibocajaingresoimprevisto")]
	public class VwRecibocajaingresoimprevisto
	{
		[PrimaryKey]
		[Alias("idrecibocajaingresoimprevisto")]
		public  int  Idrecibocajaingresoimprevisto{ get; set; }
		public  int  Idrecibocajaingresodet{ get; set; }
		public  int  Idtipocp{ get; set; }
		public  int?  Idtipoformato{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  int?  Maxnumeroitems{ get; set; }
		public  string Serietipocp{ get; set; }
		public  string Numerotipocp{ get; set; }
		public  decimal  Importepago{ get; set; }
	}
}
