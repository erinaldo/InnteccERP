using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwprogramacioncitadethistorial")]
	public class VwProgramacioncitadethistorial
	{
		[PrimaryKey]
		[Alias("idprogramacioncitadethistorial")]
		public int?  Idprogramacioncitadethistorial { get; set; }
		public int?  Idprogramacioncitadet { get; set; }
		public DateTime?  Fechahorahistorial { get; set; }
		public int?  Idpersona { get; set; }
		public string Razonsocialpersona { get; set; }
		public int?  Idestadocita { get; set; }
		public string Nombreestadocita { get; set; }
		public int?  Idmotivocita { get; set; }
		public string Nombremotivocita { get; set; }
	}
}
