using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("marcaequipo")]
	public class Marcaequipo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmarcaequipo")]
		public int Idmarcaequipo { get; set; }
		public string Nombremarcaequipo { get; set; }
	}
}
