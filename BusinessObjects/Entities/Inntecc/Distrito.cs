using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("distrito")]
	public class Distrito
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("iddistrito")]
		public  int Iddistrito{ get; set; }
		public  string Codigodistrito{ get; set; }
		public  string Nombredistrito{ get; set; }
		public  int Idprovincia{ get; set; }
	}
}
