using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("guiaremisionmotivo")]
	public class Guiaremisionmotivo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idguiaremisionmotivo")]
		public  int Idguiaremisionmotivo{ get; set; }
		public  string Nombreguiaremisionmotivo{ get; set; }
	}
}
