using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("empleadoareaproyecto")]
	public class Empleadoareaproyecto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idempleadoareaproyecto")]
		public  int Idempleadoareaproyecto{ get; set; }
		public  int?  Idempleadoarea{ get; set; }
		public  int?  Idproyecto{ get; set; }
	}
}
