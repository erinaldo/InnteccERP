using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tiporatio")]
	public class Tiporatio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtiporatio")]
		public int Idtiporatio { get; set; }
		public string Nombretiporatio { get; set; }
		public string Operador { get; set; }
	}
}
