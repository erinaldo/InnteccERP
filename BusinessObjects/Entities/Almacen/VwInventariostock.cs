using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwinventariostock")]
	public class VwInventariostock
	{
		[PrimaryKey]
		[Alias("idinventariostock")]
		public  int  Idinventariostock{ get; set; }
		public  int?  Idinventarioubicacion{ get; set; }
		public  string Ambiente{ get; set; }
		public  string Columna{ get; set; }
		public  string Fila{ get; set; }
		public  string Numeroinventario{ get; set; }
		public  DateTime?  Fechainventario{ get; set; }
        public string Ubicacion{ get; set; }
		public  int  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
        public string Codigoproveedor { get; set; }
		public  string Codigodebarra{ get; set; }
		public  int  Idunidadinventario{ get; set; }
        public string Numerodeserie { get; set; }
        public string Caracteristicas { get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Codigoclasificacion{ get; set; }
		public  string Nombreclasificacion{ get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  bool?  Muevekardex{ get; set; }
		public  decimal  Cantidadinventario{ get; set; }
		public  decimal Cantidadajuste{ get; set; }
		public  decimal  Costounisoles{ get; set; }
		public  decimal  Costototsoles{ get; set; }
        public decimal Costounidolares { get; set; }
        public decimal Costototdolares { get; set; }
        public decimal Tipocambio { get; set; }
	    public decimal Cantidadtotal { get; set; }
	}
}
