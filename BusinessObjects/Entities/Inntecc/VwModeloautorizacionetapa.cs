using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwmodeloautorizacionetapa")]
	public class VwModeloautorizacionetapa
	{
		[PrimaryKey]
		[Alias("idmodeloautorizacionetapa")]
		public int  Idmodeloautorizacionetapa { get; set; }
		public int  Idmodeloautorizacion { get; set; }
		public int  Idetapaautorizacion { get; set; }
		public string Nombreetapaautorizacion { get; set; }
		public int  Cantautorizacionesreq { get; set; }
	}
}
