using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipodocmov")]
	public class Tipodocmov
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipodocmov")]
		public  int Idtipodocmov{ get; set; }
		public  string Codigotipodocmov{ get; set; }
		public  string Nombretipodocmov{ get; set; }
	}
}
