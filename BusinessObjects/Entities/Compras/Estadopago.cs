using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("estadopago")]
	public class Estadopago
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadopago")]
		public  int Idestadopago{ get; set; }
		public  string Nombreestadopago{ get; set; }
	}
}
