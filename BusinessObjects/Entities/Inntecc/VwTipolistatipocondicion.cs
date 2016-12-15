using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwtipolistatipocondicion")]
	public class VwTipolistatipocondicion
	{
		[PrimaryKey]
		[Alias("idtipolistatipocondicion")]
		public int?  Idtipolistatipocondicion { get; set; }
		public int?  Idtipolista { get; set; }
		public string Codigotipolista { get; set; }
		public string Nombretipolista { get; set; }
		public decimal?  Porcentajedescuento { get; set; }
		public int?  Idtipocondicion { get; set; }
		public string Codigocondicion { get; set; }
		public string Nombrecondicion { get; set; }
		public bool?  Essunat { get; set; }
		public int?  Diascondicion { get; set; }
        public int? Idlistaprecio { get; set; }
        public int? Idtipolistaprecio { get; set; }
        public string Nombretipolistaprecio { get; set; }
	    public int Idsucursal { get; set; }
	    public string Nombresucursal { get; set; }
	    public int Idempresa { get; set; }
	    public string Nombreempresa { get; set; }

	}
}
