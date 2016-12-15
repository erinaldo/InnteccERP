using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("programacioncitadethistorial")]
	public class Programacioncitadethistorial
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idprogramacioncitadethistorial")]
		public int Idprogramacioncitadethistorial { get; set; }
		public int?  Idprogramacioncitadet { get; set; }
		public DateTime?  Fechahorahistorial { get; set; }
		public int?  Idpersona { get; set; }
		public int?  Idestadocita { get; set; }
		public int?  Idmotivocita { get; set; }
	}
}
