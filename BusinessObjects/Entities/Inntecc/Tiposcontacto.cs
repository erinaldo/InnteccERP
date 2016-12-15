using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tiposcontacto")]
	public class Tiposcontacto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocontacto")]
		public  int Idtipocontacto{ get; set; }
		public  string Nombretipocontacto{ get; set; }
	}
}
