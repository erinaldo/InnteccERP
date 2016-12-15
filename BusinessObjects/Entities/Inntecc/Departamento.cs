using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("departamento")]
	public class Departamento
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("iddepartamento")]
		public  int Iddepartamento{ get; set; }
		public  string Codigodepartamento{ get; set; }
		public  string Nombredepartamento{ get; set; }
	}
}
