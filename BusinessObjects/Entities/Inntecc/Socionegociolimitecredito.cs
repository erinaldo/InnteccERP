using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegociolimitecredito")]
	public class Socionegociolimitecredito
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegociolimitecredito")]
		public  int Idsocionegociolimitecredito{ get; set; }
		public  int Idsocionegocio{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
		public  decimal Limitecredito{ get; set; }
        public int Tipolimitecredito { get; set; }
        public int Cantidadtransacciones { get; set; }
	}
}
