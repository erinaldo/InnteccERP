using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("autorizaciontipocondicion")]
	public class Autorizaciontipocondicion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idautorizaciontipocondicion")]
		public int Idautorizaciontipocondicion { get; set; }
		public string Nombreautorizaciontipocondicion { get; set; }
	}
}
