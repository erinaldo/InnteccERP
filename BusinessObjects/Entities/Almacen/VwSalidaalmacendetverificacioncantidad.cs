using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwsalidaalmacendetverificacioncantidad")]
	public class VwSalidaalmacendetverificacioncantidad
	{
		[PrimaryKey]
		[Alias("idsalidaalmacendet")]
		public int  Idsalidaalmacendet { get; set; }
		public int  Idsalidaalmacen { get; set; }
		public int  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Nombrearticulo { get; set; }
		public int  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public int  Idunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public decimal  Cantidad { get; set; }
		public decimal  Cantidadubicacion { get; set; }
	}
}
