using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("guiaremisiondet")]
	public class Guiaremisiondet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idguiaremisiondet")]
		public int Idguiaremisiondet { get; set; }
		public int Idguiaremision { get; set; }
		public int Idarticulo { get; set; }
		public bool Articulomoficado { get; set; }
		public string Nombrearticulo { get; set; }
		public int Idunidadmedida { get; set; }
		public int?  Idimpuesto { get; set; }
		public int Numeroitem { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Pesounitario { get; set; }
		public decimal Pesototal { get; set; }
		public decimal Preciounitario { get; set; }
		public decimal Importetotal { get; set; }
		public string Especificacion { get; set; }
		public int?  Idordendeventadet { get; set; }
		public int?  Idtipoafectacionigv { get; set; }
		public decimal Porcentajepercepcion { get; set; }
		public int?  Idproyecto { get; set; }
		public int?  Idarea { get; set; }
		public int?  Idcentrodecosto { get; set; }
        public int? Idrequerimientodet { get; set; }
        public bool Calcularitem { get; set; }
	    public int? Idcpcompradet { get; set; }
        public int? Identradaalmacendet { get; set; }
	    public int? Idubicacion { get; set; }
	    public string Nombreubicacion { get; set; }

	}
}
