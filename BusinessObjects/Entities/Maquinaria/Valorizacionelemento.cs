using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizacionelemento")]
	public class Valorizacionelemento
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizacionelemento")]
		public int Idvalorizacionelemento { get; set; }
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
