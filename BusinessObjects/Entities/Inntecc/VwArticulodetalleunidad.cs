using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwarticulodetalleunidad")]
	public class VwArticulodetalleunidad
	{
		[PrimaryKey]
		[Alias("idarticulodetalleunidad")]
		public  int  Idarticulodetalleunidad{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Nombreclasificacion{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  int  Idunidadmedida{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
	}
}
