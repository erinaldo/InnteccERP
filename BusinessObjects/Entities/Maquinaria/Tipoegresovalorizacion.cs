using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("tipoegresovalorizacion")]
	public class Tipoegresovalorizacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoegresovalorizacion")]
		public int Idtipoegresovalorizacion { get; set; }
		public string Nombretipoegresovaloriza { get; set; }
	}
}
