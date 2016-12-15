using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwubicacion")]
	public class VwUbicacion
	{
		[PrimaryKey]
		[Alias("idubicacion")]
		public  int  Idubicacion{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  string Direccionsucursal{ get; set; }
		public  int?  Idalmacen{ get; set; }
		public  string Codigoalmacen{ get; set; }
		public  string Nombrealmacen{ get; set; }
		public  string Direccionalmacen{ get; set; }
		public  string Ambiente{ get; set; }
		public  string Columna{ get; set; }
		public  string Fila{ get; set; }
		public  string Nombreubicacion{ get; set; }
	}
}
