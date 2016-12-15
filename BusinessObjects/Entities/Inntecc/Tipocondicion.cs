using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipocondicion")]
	public class Tipocondicion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocondicion")]
		public  int Idtipocondicion{ get; set; }
		public  string Codigocondicion{ get; set; }
		public  string Nombrecondicion{ get; set; }
		public  bool Essunat{ get; set; }
		public  int Diascondicion{ get; set; }
	}
}
