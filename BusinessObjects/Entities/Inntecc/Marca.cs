using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("marca")]
	public class Marca
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmarca")]
		public  int Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
	}
}
