using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("inventariostock")]
	public class Inventariostock
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idinventariostock")]
		public  int Idinventariostock{ get; set; }
		public  int Idinventarioubicacion{ get; set; }
		public  int Idarticulo{ get; set; }
		public  decimal Cantidadinventario{ get; set; }
		public  decimal Cantidadajuste{ get; set; }
		public  decimal Costounisoles{ get; set; }
		public  decimal Costototsoles{ get; set; }
        public decimal Costounidolares { get; set; }
        public decimal Costototdolares { get; set; }
        public decimal Tipocambio { get; set; }


	}
}
