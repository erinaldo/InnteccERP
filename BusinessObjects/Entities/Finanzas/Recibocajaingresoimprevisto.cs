using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("recibocajaingresoimprevisto")]
	public class Recibocajaingresoimprevisto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrecibocajaingresoimprevisto")]
		public  int Idrecibocajaingresoimprevisto{ get; set; }
		public  int Idrecibocajaingresodet{ get; set; }
		public  int Idtipocp{ get; set; }
		public  string Serietipocp{ get; set; }
		public  string Numerotipocp{ get; set; }
		public  decimal Importepago{ get; set; }
	}
}
