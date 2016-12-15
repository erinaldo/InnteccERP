using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tiposnp")]
	public class Tiposnp
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtiposnp")]
		public int Idtiposnp { get; set; }
		public string Nombretiposnp { get; set; }
	}
}
