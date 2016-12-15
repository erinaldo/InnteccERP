using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipoafectacionigv")]
	public class Tipoafectacionigv
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoafectacionigv")]
		public  int Idtipoafectacionigv{ get; set; }
        public string Codigotipoafectacionigv { get; set; }
		public  string Nombretipoafectacionigv{ get; set; }
		public  bool Gravado{ get; set; }
		public  bool Exonerado{ get; set; }
		public  bool Inafecto{ get; set; }
		public  bool Exportacion{ get; set; }
	}
}
