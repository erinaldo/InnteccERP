using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwmodeloequipo")]
	public class VwModeloequipo
	{
		[PrimaryKey]
		[Alias("idmodeloequipo")]
		public int?  Idmodeloequipo { get; set; }
		public string Nombremodeloequipo { get; set; }
		public int?  Idmarcaequipo { get; set; }
		public string Nombremarcaequipo { get; set; }
	    public string Marcamodelo { get; set; }
	}
}
