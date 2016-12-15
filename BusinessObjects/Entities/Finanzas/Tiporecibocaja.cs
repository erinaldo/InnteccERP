using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("tiporecibocaja")]
	public class Tiporecibocaja
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtiporecibo")]
		public  int Idtiporecibo{ get; set; }
		public  string Nombretiporecibo{ get; set; }
	}
}
