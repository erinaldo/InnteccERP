using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwalmacen")]
	public class VwAlmacen
	{
		[PrimaryKey]
		[Alias("idalmacen")]
		public  int  Idalmacen{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  string Direccionsucursal{ get; set; }
		public  string Codigoalmacen{ get; set; }
		public  string Nombrealmacen{ get; set; }
		public  int?  Iddistrito{ get; set; }
		public  string Codigodistrito{ get; set; }
		public  string Nombreubigeo{ get; set; }
		public  string Direccionalmacen{ get; set; }
	    public int Idempresa { get; set; }
	    public string Nombreempresa { get; set; }
        public int Idubicaciondefecto { get; set; }
	    public string Nombreubicacion { get; set; }
	}
}
