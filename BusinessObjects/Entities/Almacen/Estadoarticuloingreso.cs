using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("estadoarticuloingreso")]
	public class Estadoarticuloingreso
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadoarticulo")]
		public  int Idestadoarticulo{ get; set; }
		public  string Nombreestado{ get; set; }
		public  bool Procedereclamo{ get; set; }
	}
}
