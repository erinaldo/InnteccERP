using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipolistatipocondicion")]
	public class Tipolistatipocondicion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipolistatipocondicion")]
		public int Idtipolistatipocondicion { get; set; }
		public int?  Idtipolista { get; set; }
		public int?  Idtipocondicion { get; set; }
	    public int? Idlistaprecio { get; set; }

	}
}
