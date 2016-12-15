using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("elementogasto")]
	public class Elementogasto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idelementogasto")]
		public int Idelementogasto { get; set; }
		public string Codigoelementogasto { get; set; }
		public string Nombreelementogasto { get; set; }
	}
}
