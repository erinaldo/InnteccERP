using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizacionegreso")]
	public class Valorizacionegreso
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizacionegreso")]
		public int Idvalorizacionegreso { get; set; }
		public int?  Idvalorizacion { get; set; }
		public int?  Idtipoegresovalorizacion { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Preciounitario { get; set; }
		public decimal Importetotal { get; set; }
	}
}
