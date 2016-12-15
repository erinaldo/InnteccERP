using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiaclinicacita")]
	public class Historiaclinicacita
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriaclinicacita")]
		public int Idhistoriaclinicacita { get; set; }
		public int?  Idhistoriaclinica { get; set; }
		public int Idprogramacioncitadet { get; set; }
		public string Comentariomotivocita { get; set; }
	}
}
