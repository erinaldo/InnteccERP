using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("etapaautorizacion")]
	public class Etapaautorizacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idetapaautorizacion")]
		public int Idetapaautorizacion { get; set; }
		public string Nombreetapaautorizacion { get; set; }
		public int Cantautorizacionesreq { get; set; }
		public int?  Idempresa { get; set; }
	}
}
