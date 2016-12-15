using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("tiporegistroorden")]
	public class Tiporegistroorden
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtiporegistroorden")]
		public int Idtiporegistroorden { get; set; }
		public string Nombretiporegistroorden { get; set; }
	}
}
