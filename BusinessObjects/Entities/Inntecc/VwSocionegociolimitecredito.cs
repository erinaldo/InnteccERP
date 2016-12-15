using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegociolimitecredito")]
	public class VwSocionegociolimitecredito
	{
		[PrimaryKey]
		[Alias("idsocionegociolimitecredito")]
		public int  Idsocionegociolimitecredito { get; set; }
		public int  Idsocionegocio { get; set; }
		public int  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public decimal  Limitecredito { get; set; }
        public int Tipolimitecredito { get; set; }
        public string Nombretipolimitecredito { get; set; }
        public int Cantidadtransacciones { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
