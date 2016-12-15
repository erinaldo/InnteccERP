using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("grupoeconomico")]
	public class Grupoeconomico
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idgrupoeconomico")]
		public int Idgrupoeconomico { get; set; }
		public string Nombregrupoeconomico { get; set; }
	}
}
