using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizaciondanio")]
	public class Valorizaciondanio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizaciondanio")]
		public int Idvalorizaciondanio { get; set; }
		public int Idvalorizaciondanioelemento { get; set; }
		public int Idarticulo { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Valorunitario { get; set; }
		public decimal Subtotal { get; set; }
		public int Idunidadmedida { get; set; }
		public string Comentario { get; set; }
		public int Numeroitem { get; set; }
	}
}
