using System.Security.AccessControl;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwlistaprecio")]
	public class VwListaprecio
	{
		[PrimaryKey]
		[Alias("idlistaprecio")]
		public  int  Idlistaprecio{ get; set; }
		public  int?  Idtipolista{ get; set; }
		public  string Codigotipolista{ get; set; }
		public  string Nombretipolista{ get; set; }
		public  decimal?  Porcentajedescuento{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
		public  string Codigotipomoneda{ get; set; }
		public  string Nombretipomoneda{ get; set; }
		public  string Simbolomoneda{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
        public string Tipolistaprecio { get; set; }
		public  bool?  Principal{ get; set; }
        public bool Agregararticuloauto { get; set; }
        public int Idcondicioncreditoopcion1 { get; set; }
        public string Nombrecondicion1 { get; set; }
        public int Diascondicion1 { get; set; }
        public int Idcondicioncreditoopcion2 { get; set; }
        public string Nombrecondicion2 { get; set; }
        public int Diascondicion2 { get; set; }
        public bool Listaprecioincluyeimpuesto { get; set; }
	}
}
