using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("prioridad")]
	public class Prioridad
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idprioridad")]
		public  int Idprioridad{ get; set; }
        [Required]
        [StringLength(2)]
		public  string Codigoprioridad{ get; set; }
		public  string Nombreprioridad{ get; set; }
	}
}
