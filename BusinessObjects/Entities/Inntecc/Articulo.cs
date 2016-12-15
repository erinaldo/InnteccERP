using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("articulo")]
	public class Articulo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarticulo")]
		public  int Idarticulo{ get; set; }
        [Required]
        [StringLength(5)]
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int Idunidadinventario{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  int? Idmarca{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int Idimpuesto{ get; set; }
		public  int? Idimpuestoisc{ get; set; }
		public  bool Activo{ get; set; }
		public  bool Muevekardex{ get; set; }
		public  decimal Pesoarticulo{ get; set; }
		public  decimal Stockminarticulo{ get; set; }
		public  decimal Stockmaximo{ get; set; }
		public  bool Aplicapercepcion{ get; set; }
		public  string Comentario{ get; set; }
		public  bool Esarticuloinventario{ get; set; }
		public  bool Esarticulodeventa{ get; set; }
		public  bool Esarticulodecompra{ get; set; }
		public  bool Esactivofijo{ get; set; }
		public  int?  Idcuentacontable{ get; set; }
        public int Idtipoafectacionigv { get; set; }
        public string Caracteristicas { get; set; }
        public int Idtipoarticulo { get; set; }
        public int? Idequipo { get; set; }
        public string Numerodeserie { get; set; }
        public int? Idelementogasto { get; set; }
        public bool Esarticulocompuesto { get; set; }
        public int? Idtipomonedacosto { get; set; }
        public decimal Costounitario { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idclasificacionequipo { get; set; }
        public string Nombrearticulocorto { get; set; }
        public string Nombrearticuloalterno { get; set; }
        public decimal Stockcritico { get; set; }
        public decimal Stockreposicion { get; set; }
        public bool Reposicionautomatica { get; set; }
        public bool Pagacomision { get; set; }
        public bool Controldeserie { get; set; }
        public decimal Variacioncantidadentregada { get; set; }
        public int? Idtipogestionarticulo { get; set; }
	    public int? Idestadoarticulo { get; set; }
        public byte[] Imagenarticulo { get; set; }
        public bool Aplicacuarentena { get; set; }
        public int Idempresa { get; set; }
        public bool Esserviciomedico { get; set; }
        public bool Motivopordefectoprogramacion { get; set; }
        public string Tiempoduracion { get; set; }
	}
}
