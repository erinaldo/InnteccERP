using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("listaprecio")]
	public class Listaprecio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idlistaprecio")]
		public  int Idlistaprecio{ get; set; }
		public  int Idtipolista{ get; set; }
		public  int Idtipomoneda{ get; set; }
		public  int Idsucursal{ get; set; }
        public bool Agregararticuloauto { get; set; }
        public int Idcondicioncreditoopcion1 { get; set; }
        public int Idcondicioncreditoopcion2 { get; set; }
        public bool Listaprecioincluyeimpuesto { get; set; }

	}
}
