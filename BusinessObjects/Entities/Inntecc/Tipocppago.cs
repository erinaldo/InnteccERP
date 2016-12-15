using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipocppago")]
	public class Tipocppago
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocppago")]
		public  int Idtipocppago{ get; set; }
		public  string Codigotipocppago{ get; set; }
		public  string Nombretipocppago{ get; set; }
		public  bool Essunat{ get; set; }
		public  bool Regventas{ get; set; }
		public  bool Regcompras{ get; set; }
	}
}
