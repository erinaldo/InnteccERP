using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("cpventadet")]
	public class Cpventadet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcpventadet")]
		public  int Idcpventadet{ get; set; }
		public  int Idcpventa{ get; set; }
		public  int Numeroitem{ get; set; }
		public  int Idarticulo{ get; set; }
		public  bool Articulomodificado{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int Idunidadmedida{ get; set; }
		public  int Idimpuesto{ get; set; }
		public  decimal Cantidad{ get; set; }
		public  decimal Preciounitario{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal Descuento1{ get; set; }
		public  decimal Descuento2{ get; set; }
		public  decimal Descuento4{ get; set; }
		public  decimal Descuento3{ get; set; }
		public  decimal Preciounitarioneto{ get; set; }
		public  decimal Importetotal{ get; set; }
		public  decimal Porcentajepercepcion{ get; set; }
		public  int Idtipoafectacionigv{ get; set; }
		public  int Idalmacen{ get; set; }
        public int Idcentrodecosto { get; set; }
        public int Idarea { get; set; }
        public int Idproyecto { get; set; }
        public int? Idordendeventadet { get; set; }
        public int? Idvalorizacion { get; set; }
        public bool Calcularitem { get; set; }
        public int? Idubicacion { get; set; }
	    public bool Bonificacion { get; set; }
        public bool Articulomoficado { get; set; }
        public int? Idclase { get; set; }
        public int? Idplan { get; set; }
        public int? Idtipo { get; set; }
        public int? Idtipotope { get; set; }
        public string Numerolinea { get; set; }
	    public int? Idseriearticulo { get; set; }
	}
}
