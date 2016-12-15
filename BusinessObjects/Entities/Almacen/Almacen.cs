using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("almacen")]
	public class Almacen
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idalmacen")]
		public  int Idalmacen{ get; set; }
		public  int Idsucursal{ get; set; }
		public  string Codigoalmacen{ get; set; }
		public  string Nombrealmacen{ get; set; }
		public  int Iddistrito{ get; set; }
		public  string Direccionalmacen{ get; set; }
		public  bool Esactivo{ get; set; }
        public int? Idubicaciondefecto { get; set; }               
	}
}
