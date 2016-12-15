using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("clasificacionequipo")]
	public class Clasificacionequipo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idclasificacionequipo")]
		public int Idclasificacionequipo { get; set; }
		public string Nombreclasificacionequipo { get; set; }
	}
}
