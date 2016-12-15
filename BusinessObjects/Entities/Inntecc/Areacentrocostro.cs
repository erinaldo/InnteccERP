using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("areacentrocostro")]
	public class Areacentrocostro
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idareacentrocostro")]
		public  int Idareacentrocostro{ get; set; }
		public  int Idarea{ get; set; }
		public  int Idcentrodecosto{ get; set; }
	}
}
