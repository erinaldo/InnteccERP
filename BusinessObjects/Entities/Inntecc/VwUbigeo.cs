using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwubigeo")]
	public class VwUbigeo
	{
		[PrimaryKey]
		[Alias("iddistrito")]
		public  int?  Iddistrito{ get; set; }
		public  string Codigodistrito{ get; set; }
		public  string Nombredistrito{ get; set; }
		public  int?  Idprovincia{ get; set; }
		public  string Codigoprovincia{ get; set; }
		public  string Nombreprovincia{ get; set; }
		public  int?  Iddepartamento{ get; set; }
		public  string Codigodepartamento{ get; set; }
		public  string Nombredepartamento{ get; set; }
		public  string Nombreubigeo{ get; set; }
	}
}
