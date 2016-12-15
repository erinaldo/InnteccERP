using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("cotizacionclientedet")]
	public class Cotizacionclientedet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcotizacionclientedet")]
		public  int Idcotizacionclientedet{ get; set; }
		public  int Idcotizacioncliente{ get; set; }
		public  int? Numeroitem{ get; set; }
		public  int? Idarticulo{ get; set; }
		public  bool Articulomodificado{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int? Diasdeentrega{ get; set; }
		public  int? Idunidadmedida{ get; set; }
		public  int? Idimpuesto{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal Cantidad{ get; set; }
		public  decimal Preciounitario{ get; set; }
		public  decimal Descuento1{ get; set; }
		public  decimal Descuento2{ get; set; }
		public  decimal Descuento3{ get; set; }
		public  decimal Descuento4{ get; set; }
		public  decimal Preciounitarioneto{ get; set; }
		public  decimal Importetotal{ get; set; }
        public int Idtipoafectacionigv { get; set; }
        public int? Idcentrodecosto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int Idalmacen { get; set; }
        public bool Calcularitem { get; set; }
	    public bool Bonificacion { get; set; }
        public int? Idubicacion { get; set; }
        
	}
}
