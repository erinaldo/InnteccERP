using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipooperacion")]
	public class Tipooperacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipooperacion")]
		public  int Idtipooperacion{ get; set; }
		public  string Codigotipooperacion{ get; set; }
		public  string Nombretipooperacion{ get; set; }
		public  bool Essunat{ get; set; }
	}
}
