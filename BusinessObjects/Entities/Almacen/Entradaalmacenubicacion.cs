using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("entradaalmacenubicacion")]
	public class Entradaalmacenubicacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("identradaalmacenubicacion")]
		public  int Identradaalmacenubicacion{ get; set; }
		public  int Identradaalmacendet{ get; set; }
		public  int?  Idubicacion{ get; set; }
		public  decimal Cantidadarticulo{ get; set; }
	}
}
