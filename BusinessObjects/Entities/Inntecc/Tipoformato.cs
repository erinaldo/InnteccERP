using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipoformato")]
	public class Tipoformato
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoformato")]
		public  int Idtipoformato{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
	}
}
