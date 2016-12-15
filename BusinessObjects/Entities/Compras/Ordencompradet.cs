using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("ordencompradet")]
	public class Ordencompradet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idordencompradet")]
		public  int Idordencompradet{ get; set; }
		public  int?  Idordencompra{ get; set; }
		public  int? Numeroitem{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  decimal? Cantidad{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  decimal Preciounitario{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal Descuento1{ get; set; }
		public  decimal Descuento2{ get; set; }
		public  decimal Descuento3{ get; set; }
		public  decimal Descuento4{ get; set; }
		public  decimal Preciounitarioneto{ get; set; }
		public  decimal Importetotal{ get; set; }
		public  int? Idimpuesto{ get; set; }
		public  int? Idcentrodecosto{ get; set; }
		public  decimal Porcentajepercepcion{ get; set; }
	    public int? Idrequerimientodet { get; set; }
        public int? Idarea { get; set; }
        public int? Idproyecto { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public bool Calcularitem { get; set; }
        public DateTime? Fechaentrega { get; set; }
	}
}
