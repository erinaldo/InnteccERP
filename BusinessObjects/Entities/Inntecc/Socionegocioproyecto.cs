using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegocioproyecto")]
	public class Socionegocioproyecto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegocioproyecto")]
		public  int Idsocionegocioproyecto{ get; set; }
		public  int Idsocionegocio{ get; set; }
		public  int Idproyecto{ get; set; }
        public bool Proyectopordefecto{ get; set; }
	}
}
