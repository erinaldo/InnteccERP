using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("entradaalmacendet")]
	public class Entradaalmacendet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("identradaalmacendet")]
		public  int? Identradaalmacendet{ get; set; }
		public  int?  Identradaalmacen{ get; set; }
		public  int? Numeroitem{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal Cantidad{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  decimal? Preciounitario{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  decimal? Importetotal{ get; set; }
		public  int?  Idordencompradet{ get; set; }
        public decimal Cantidadverificada { get; set; }
        public int? Idproyecto { get; set; }
        public int? Idarea { get; set; }
        public int? Idcentrodecosto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int? Idtipoafectacionigv { get; set; }
        public int? Idsalidaalmacendet { get; set; }
        public int? Idcpcompradet { get; set; }
        public bool Calcularitem { get; set; }
        public int? Idnotacreditoclidet { get; set; }
	}
}
