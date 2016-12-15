using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("notacreditoclidet")]
	public class Notacreditoclidet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idnotacreditoclidet")]
		public int Idnotacreditoclidet { get; set; }
		public int Idnotacreditocli { get; set; }
		public int Numeroitem { get; set; }
		public int Idarticulo { get; set; }
		public bool Articulomodificado { get; set; }
		public string Nombrearticulo { get; set; }
		public int Idunidadmedida { get; set; }
		public int Idimpuesto { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Preciounitario { get; set; }
		public string Especificacion { get; set; }
		public decimal Descuento1 { get; set; }
		public decimal Descuento2 { get; set; }
		public decimal Descuento4 { get; set; }
		public decimal Descuento3 { get; set; }
		public decimal Preciounitarioneto { get; set; }
		public decimal Importetotal { get; set; }
		public decimal Porcentajepercepcion { get; set; }
		public int Idtipoafectacionigv { get; set; }
		public int Idalmacen { get; set; }
		public int?  Idarea { get; set; }
		public int?  Idproyecto { get; set; }
		public int?  Idcentrodecosto { get; set; }
		public int?  Idcpventadet { get; set; }
        public int? Idubicacion { get; set; }
	}
}
