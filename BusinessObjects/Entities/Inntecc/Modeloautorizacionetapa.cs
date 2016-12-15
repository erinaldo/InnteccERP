using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("modeloautorizacionetapa")]
	public class Modeloautorizacionetapa
	{
		[PrimaryKey]
        [AutoIncrement]
		[Alias("idmodeloautorizacionetapa")]
		public int Idmodeloautorizacionetapa { get; set; }
		public int?  Idmodeloautorizacion { get; set; }
		public int?  Idetapaautorizacion { get; set; }
	}
}
