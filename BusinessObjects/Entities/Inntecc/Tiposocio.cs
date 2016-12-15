using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tiposocio")]
	public class Tiposocio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtiposocio")]
		public  int Idtiposocio{ get; set; }
		public  string Nombretiposocio{ get; set; }
	}
}
