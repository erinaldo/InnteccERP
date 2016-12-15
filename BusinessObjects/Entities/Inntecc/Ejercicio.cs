using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("ejercicio")]
	public class Ejercicio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idejercicio")]
		public  int Idejercicio{ get; set; }
		public  int Anioejercicio{ get; set; }
		public  bool Cerrado{ get; set; }
		public  int?  Idempresa{ get; set; }
	}
}
