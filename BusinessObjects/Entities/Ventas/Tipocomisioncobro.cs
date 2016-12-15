using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("tipocomisioncobro")]
	public class Tipocomisioncobro
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocomisioncobro")]
		public int Idtipocomisioncobro { get; set; }
		public string Nombretipocomisioncobro { get; set; }
	}
}
