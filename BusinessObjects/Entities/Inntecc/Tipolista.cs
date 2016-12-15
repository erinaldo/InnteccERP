using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipolista")]
	public class Tipolista
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipolista")]
		public  int Idtipolista{ get; set; }
		public  string Codigotipolista{ get; set; }
		public  string Nombretipolista{ get; set; }
		public  decimal Porcentajedescuento{ get; set; }
	}
}
