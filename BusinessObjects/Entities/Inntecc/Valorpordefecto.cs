using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("valorpordefecto")]
	public class Valorpordefecto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorpordefecto")]
		public  int Idvalorpordefecto{ get; set; }
		public  int Idsucursal{ get; set; }
		public  int Idtipocp{ get; set; }
		public  int Idcptooperacion{ get; set; }
		public  int Idempleado{ get; set; }
		public  string Nombretipodocmov{ get; set; }
	}
}
