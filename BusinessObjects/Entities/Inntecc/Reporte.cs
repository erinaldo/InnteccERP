using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("reporte")]
	public class Reporte
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idreporte")]
		public int Idreporte { get; set; }
		public string Nombreparametro { get; set; }
		public string Tipoparametro { get; set; }
		public string Operador { get; set; }
	}
}
