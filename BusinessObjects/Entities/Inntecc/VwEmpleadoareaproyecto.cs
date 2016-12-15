using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwempleadoareaproyecto")]
	public class VwEmpleadoareaproyecto
	{
		[PrimaryKey]
		[Alias("idempleadoareaproyecto")]
		public  int  Idempleadoareaproyecto{ get; set; }
		public  int?  Idempleadoarea{ get; set; }
		public  int?  Idempleado{ get; set; }
		public  int?  Idpersonaempleado{ get; set; }
		public  string Nombreempleado{ get; set; }
		public  int?  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int?  Idproyecto{ get; set; }
		public  string Codigoproyecto{ get; set; }
		public  string Nombreproyecto{ get; set; }
	}
}
