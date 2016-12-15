using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("provincia")]
	public class Provincia
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idprovincia")]
		public  int Idprovincia{ get; set; }
		public  string Codigoprovincia{ get; set; }
		public  string Nombreprovincia{ get; set; }
		public  int Iddepartamento{ get; set; }
	}
}
