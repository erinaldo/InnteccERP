using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("impuesto")]
	public class Impuesto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idimpuesto")]
		public  int Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal Porcentajeimpuesto{ get; set; }
	}
}
