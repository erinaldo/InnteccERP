using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipocontratoempleado")]
	public class Tipocontratoempleado
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocontratoempleado")]
		public int Idtipocontratoempleado { get; set; }
		public string Nombretipocontratoempleado { get; set; }
	}
}
