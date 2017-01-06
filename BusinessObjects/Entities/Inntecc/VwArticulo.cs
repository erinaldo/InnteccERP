using System.Security.AccessControl;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwarticulo")]
	public class VwArticulo
	{
		[PrimaryKey]
		[Alias("idarticulo")]
		public  int  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int?  Idunidadinventario{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Codigoclasificacion{ get; set; }
		public  string Nombreclasificacion{ get; set; }
        public  string Codigoclasificacionpadre{ get; set; }
		public  string Nombreclasificacionpadre{ get; set; }               
        public string Nombreclasificaciondetalle { get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  int?  Idimpuestoisc{ get; set; }
		public  string Abreviaturaisc{ get; set; }
		public  string Nombreimpuestoisc{ get; set; }
		public  decimal?  Porcentajeimpuestoisc{ get; set; }
		public  bool?  Activo{ get; set; }
		public  bool?  Muevekardex{ get; set; }
		public  decimal?  Pesoarticulo{ get; set; }
		public  decimal?  Stockminarticulo{ get; set; }
		public  decimal?  Stockmaximo{ get; set; }
		public  bool  Aplicapercepcion{ get; set; }
		public  string Comentario{ get; set; }
		public  bool?  Esarticuloinventario{ get; set; }
		public  bool?  Esarticulodeventa{ get; set; }
		public  bool?  Esarticulodecompra{ get; set; }
		public  bool?  Esactivofijo{ get; set; }
		public  int?  Idcuentacontable{ get; set; }
		public  string Codigocuenta{ get; set; }
		public  string Nombrecuenta{ get; set; }
        public int Idtipoafectacionigv { get; set; }
        public string Codigotipoafectacionigv { get; set; }
        public string Nombretipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public string Caracteristicas { get; set; }
        public string Numerodeserie { get; set; }
        public int? Idcentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public bool Esarticulocompuesto { get; set; }
        public int? Idclasificacionequipo { get; set; }
        public int Idtipoarticulo { get; set; }
        public string Nombretipoarticulo { get; set; }
	    public int Idempresa { get; set; }
	    public string Nombreempresa { get; set; }
        public bool Esserviciomedico { get; set; }
        public bool Motivopordefectoprogramacion { get; set; }
        public string Tiempoduracion { get; set; }

	}
}
