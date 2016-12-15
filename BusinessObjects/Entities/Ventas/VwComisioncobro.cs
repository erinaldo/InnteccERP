using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwcomisioncobro")]
	public class VwComisioncobro
	{
		[PrimaryKey]
		[Alias("idcomisioncobro")]
		public int?  Idcomisioncobro { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idtipocomisioncobro { get; set; }
		public string Nombretipocomisioncobro { get; set; }
	}
}
