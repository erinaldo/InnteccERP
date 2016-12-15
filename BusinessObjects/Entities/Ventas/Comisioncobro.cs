using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("comisioncobro")]
	public class Comisioncobro
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcomisioncobro")]
		public int Idcomisioncobro { get; set; }
		public int Idsucursal { get; set; }
		public int Idtipocomisioncobro { get; set; }
	}
}
