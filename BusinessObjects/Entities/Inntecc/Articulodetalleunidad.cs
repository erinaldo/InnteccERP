using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("articulodetalleunidad")]
	public class Articulodetalleunidad
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarticulodetalleunidad")]
		public  int Idarticulodetalleunidad{ get; set; }
		public  int Idarticulo{ get; set; }
		public  int Idunidadmedida{ get; set; }
	}
}
