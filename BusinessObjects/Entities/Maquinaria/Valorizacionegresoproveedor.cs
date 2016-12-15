using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizacionegresoproveedor")]
	public class Valorizacionegresoproveedor
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizacionegresoproveedor")]
		public int Idvalorizacionegresoproveedor { get; set; }
		public int?  Idvalorizacionproveedor { get; set; }
		public int?  Idtipoegresovalorizacion { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Preciounitario { get; set; }
		public decimal Importetotal { get; set; }
	}
}
