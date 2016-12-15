using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("estadoreq")]
	public class Estadoreq
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadoreq")]
		public  int Idestadoreq{ get; set; }
		public  string Nombreestadoreq{ get; set; }
	    public bool Estadoinicial { get; set; }
	}
}
