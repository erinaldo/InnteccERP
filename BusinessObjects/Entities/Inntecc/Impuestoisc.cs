using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("impuestoisc")]
	public class Impuestoisc
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idimpuestoisc")]
		public  int Idimpuestoisc{ get; set; }
		public  string Abreviaturaisc{ get; set; }
		public  string Nombreimpuestoisc{ get; set; }
		public  decimal Porcentajeimpuestoisc{ get; set; }
	}
}
