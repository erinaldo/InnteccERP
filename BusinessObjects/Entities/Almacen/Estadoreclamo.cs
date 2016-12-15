using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("estadoreclamo")]
	public class Estadoreclamo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadoreclamo")]
		public  int Idestadoreclamo{ get; set; }
		public  string Nombreestadoreclamo{ get; set; }
	}
}
