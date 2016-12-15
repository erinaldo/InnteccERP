using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("salidaalmacenubicacion")]
	public class Salidaalmacenubicacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsalidaalmacenubicacion")]
		public  int Idsalidaalmacenubicacion{ get; set; }
		public  int Idsalidaalmacendet{ get; set; }
		public  int Idubicacion{ get; set; }
		public  decimal Cantidadarticulo{ get; set; }
	}
}
