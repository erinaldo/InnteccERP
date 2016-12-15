using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("articuloseriedet")]
	public class Articuloseriedet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarticuloseriedet")]
		public int Idarticuloseriedet { get; set; }
		public int Idarticulo { get; set; }
		public int Idseriearticulo { get; set; }
	}
}
