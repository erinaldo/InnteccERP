using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipoarticulo")]
	public class Tipoarticulo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoarticulo")]
		public int Idtipoarticulo { get; set; }
		public string Nombretipoarticulo { get; set; }
	}
}
