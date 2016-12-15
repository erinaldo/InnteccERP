using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("articulocompuesto")]
	public class Articulocompuesto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarticulocompuesto")]
		public int Idarticulocompuesto { get; set; }
		public int Idarticulo { get; set; }
		public int Idunidadinventario { get; set; }
		public decimal Cantidaddetalle { get; set; }
		public decimal Valorunitario { get; set; }
		public int?  Idtipomoneda { get; set; }
        public int Idarticulodetalle { get; set; }
	}
}
