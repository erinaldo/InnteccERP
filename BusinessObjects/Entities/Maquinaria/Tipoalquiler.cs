using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("tipoalquiler")]
	public class Tipoalquiler
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoalquiler")]
		public int Idtipoalquiler { get; set; }
		public string Nombretipoalquiler { get; set; }
	}
}
