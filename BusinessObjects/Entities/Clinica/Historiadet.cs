using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiadet")]
	public class Historiadet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriadet")]
		public int Idhistoriadet { get; set; }
		public int Idhistoria { get; set; }
		public DateTime Fechahistoriadet { get; set; }
		public int? Idprogramacioncitadet { get; set; }
		public int? Idtipohistoria { get; set; }
	}
}
