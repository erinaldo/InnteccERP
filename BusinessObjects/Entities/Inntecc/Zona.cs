using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("zona")]
	public class Zona
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idzona")]
		public int Idzona { get; set; }
		public string Nombrezona { get; set; }
	}
}
