using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("unidadmedida")]
	public class Unidadmedida
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idunidadmedida")]
		public  int Idunidadmedida{ get; set; }

        [Required]
        [StringLength(2)]
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int Factorconversion{ get; set; }
		public  bool Essunat{ get; set; }
	}
}
