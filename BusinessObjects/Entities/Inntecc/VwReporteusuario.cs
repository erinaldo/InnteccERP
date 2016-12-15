using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwreporteusuario")]
	public class VwReporteusuario
	{
		[PrimaryKey]
		[Alias("idreporteusuario")]
		public int?  Idreporteusuario { get; set; }
		public int?  Idpagina { get; set; }
		public string Namepagina { get; set; }
		public string Titulopagina { get; set; }
		public string Nombrereporte { get; set; }
		public string Descripcionreporte { get; set; }
		public string Nombreformulario { get; set; }
	}
}
