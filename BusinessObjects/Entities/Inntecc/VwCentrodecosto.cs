using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwcentrodecosto")]
	public class VwCentrodecosto
	{
		[PrimaryKey]
		[Alias("idcentrodecosto")]
		public int?  Idcentrodecosto { get; set; }
		public string Codigocentrodecosto { get; set; }
		public string Descripcioncentrodecosto { get; set; }
		public bool?  Esactivo { get; set; }	
		public int?  Idempresa { get; set; }
		public string Nombreempresa { get; set; }
	}
}
