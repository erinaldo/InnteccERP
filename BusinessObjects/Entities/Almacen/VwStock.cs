using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwstock")]
	public class VwStock
	{
		[PrimaryKey]
		[Alias("idarticulo")]
		public  int?  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Nombreclasifiacion{ get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
		public  int?  Idunidadinventario{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  int?  Idalmacen{ get; set; }
		public  string Nombrealmacen{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Codigoperiodo{ get; set; }
		public  decimal Cantidadstock{ get; set; }
	}
}
