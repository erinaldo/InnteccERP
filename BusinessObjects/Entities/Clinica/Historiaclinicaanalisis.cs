using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiaclinicaanalisis")]
	public class Historiaclinicaanalisis
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriaclinicaanalisis")]
		public int Idhistoriaclinicaanalisis { get; set; }
		public int?  Idhistoriaclinicacita { get; set; }
		public int?  Idservicio { get; set; }
		public int?  Idtipoanalisis { get; set; }
		public string Numerodeorden { get; set; }
		public DateTime Fechaorden { get; set; }
		public DateTime?  Fecharesultado { get; set; }
		public int Idresponsable { get; set; }
		public int?  Idregistrador { get; set; }
		public string Nombrearchivo { get; set; }
		public string Extensionarchivo { get; set; }
		public string Comentario { get; set; }
	}
}
