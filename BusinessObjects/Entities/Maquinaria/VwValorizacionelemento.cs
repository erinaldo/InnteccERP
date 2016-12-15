using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwvalorizacionelemento")]
	public class VwValorizacionelemento
	{
		[PrimaryKey]
		[Alias("idvalorizacionelemento")]
		public int  Idvalorizacionelemento { get; set; }
		public int  Idvalorizaciondanioelemento { get; set; }
		public int  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Nombrearticulo { get; set; }
		public int  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public int  Idunidadmedida { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public decimal  Cantidad { get; set; }
		public decimal  Valorunitario { get; set; }
		public decimal  Subtotal { get; set; }
		public string Comentario { get; set; }
		public int  Numeroitem { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
	}
}
