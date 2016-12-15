using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("inventarioubicacion")]
	public class Inventarioubicacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idinventarioubicacion")]
		public  int Idinventarioubicacion{ get; set; }
		public  int?  Idinventario{ get; set; }
		public  int   Idubicacion{ get; set; }
	}
}
