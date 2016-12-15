using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("programacioncitadet")]
	public class Programacioncitadet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idprogramacioncitadet")]
		public int Idprogramacioncitadet { get; set; }
		public int Idprogramacioncita { get; set; }
		public DateTime Horaprogramacion { get; set; }
		public int?  Idpersona { get; set; }
		public int?  Idestadocita { get; set; }
        public int? Idmotivocita { get; set; }
        public DateTime? Horatermino { get; set; }
	}
}
