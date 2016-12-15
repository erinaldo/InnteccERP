using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipogarantia")]
	public class Tipogarantia
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipogarantia")]
		public int Idtipogarantia { get; set; }
		public string Nombretipogarantia { get; set; }
	}
}
