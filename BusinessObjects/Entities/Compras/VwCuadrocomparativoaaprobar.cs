using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcuadrocomparativoaaprobar")]
	public class VwCuadrocomparativoaaprobar
	{
		[PrimaryKey]
		[Alias("idarea")]
		public  int  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  int  Idempleado{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  int?  Idpersona{ get; set; }
		public  string Nombrepersonaempleado{ get; set; }
		public  string Nrodocentidadempleado{ get; set; }
		public  int?  Cantcuadrocomparativo{ get; set; }
		public  int  Idestadocuadrocomparativo{ get; set; }
		public  int?  Idempleadoaprueba{ get; set; }
	}
}
