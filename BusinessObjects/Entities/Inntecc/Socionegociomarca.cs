using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegociomarca")]
	public class Socionegociomarca
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegociomarca")]
		public int Idsocionegociomarca { get; set; }
		public int Idsocionegocio { get; set; }
		public int Idmarca { get; set; }
	}
}
