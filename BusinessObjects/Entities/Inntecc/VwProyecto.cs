using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwproyecto")]
	public class VwProyecto
	{
		[PrimaryKey]
		[Alias("idproyecto")]
		public  int?  Idproyecto{ get; set; }
		public  string Codigoproyecto{ get; set; }
		public  string Nombreproyecto{ get; set; }
		public  bool?  Esactivo{ get; set; }
		public  int  Idempresa{ get; set; }
		public  string Nombreempresa{ get; set; }
	}
}
