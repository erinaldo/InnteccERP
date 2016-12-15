using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipomoneda")]
	public class Tipomoneda
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipomoneda")]
		public  int Idtipomoneda{ get; set; }
		public  string Codigotipomoneda{ get; set; }
		public  string Nombretipomoneda{ get; set; }
		public  string Simbolomoneda{ get; set; }
		public  bool Essunat{ get; set; }
	}
}
