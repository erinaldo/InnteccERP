using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("empleadoarea")]
	public class Empleadoarea
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idempleadoarea")]
		public  int Idempleadoarea{ get; set; }
		public  int Idempleado{ get; set; }
		public  int Idarea{ get; set; }
	}
}
