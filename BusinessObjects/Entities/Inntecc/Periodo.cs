using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("periodo")]
	public class Periodo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idperiodo")]
		public  int Idperiodo{ get; set; }
		public  int Idejercicio{ get; set; }
		public  string Mes{ get; set; }
		public  bool Cerrado{ get; set; }
	}
}
