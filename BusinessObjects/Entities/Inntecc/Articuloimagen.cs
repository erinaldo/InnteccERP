using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("articuloimagen")]
	public class Articuloimagen
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarticuloimagen")]
		public  int Idarticuloimagen{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  string Nombrearchivo{ get; set; }
		public  string Comentario{ get; set; }
	}
}
