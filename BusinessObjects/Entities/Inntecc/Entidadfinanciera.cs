using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("entidadfinanciera")]
	public class Entidadfinanciera
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("identfinaciera")]
		public  int Identfinaciera{ get; set; }
		public  string Codentidadfinaciera{ get; set; }
		public  string Nombreentidadfinanciera{ get; set; }
		public  bool Essunat{ get; set; }
	}
}
