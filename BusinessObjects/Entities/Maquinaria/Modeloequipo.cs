using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("modeloequipo")]
	public class Modeloequipo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmodeloequipo")]
		public int Idmodeloequipo { get; set; }
		public string Nombremodeloequipo { get; set; }
		public int?  Idmarcaequipo { get; set; }
	}
}
