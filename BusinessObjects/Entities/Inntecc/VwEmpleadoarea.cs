using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwempleadoarea")]
	public class VwEmpleadoarea
	{
		[PrimaryKey]
		[Alias("idempleadoarea")]
		public  int  Idempleadoarea{ get; set; }
		public  int  Idempleado{ get; set; }
		public  int  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
	}
}
