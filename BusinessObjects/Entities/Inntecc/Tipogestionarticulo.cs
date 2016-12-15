using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipogestionarticulo")]
	public class Tipogestionarticulo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipogestionarticulo")]
		public int Idtipogestionarticulo { get; set; }
		public string Codigotipogestionarticulo { get; set; }
		public string Nombretipogestionarticulo { get; set; }
	}
}
