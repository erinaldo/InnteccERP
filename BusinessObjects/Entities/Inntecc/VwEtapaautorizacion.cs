using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwetapaautorizacion")]
	public class VwEtapaautorizacion
	{
		[PrimaryKey]
		[Alias("idetapaautorizacion")]
		public int?  Idetapaautorizacion { get; set; }
		public string Nombreetapaautorizacion { get; set; }
		public int?  Cantautorizacionesreq { get; set; }
		public int?  Idempresa { get; set; }
		public string Razonsocial { get; set; }
		public string Ruc { get; set; }
		public string Direccionfiscal { get; set; }
		public string Telefono { get; set; }
		public string Paginaweb { get; set; }
	}
}
