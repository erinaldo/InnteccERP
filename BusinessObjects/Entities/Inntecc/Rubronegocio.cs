using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("rubronegocio")]
	public class Rubronegocio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrubronegocio")]
		public int Idrubronegocio { get; set; }
		public string Nombrerubronegocio { get; set; }
	}
}
