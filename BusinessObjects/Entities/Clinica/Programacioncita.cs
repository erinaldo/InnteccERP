using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("programacioncita")]
	public class Programacioncita
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idprogramacioncita")]
		public int Idprogramacioncita { get; set; }
		public int Idservicio { get; set; }
		public int Idmedico { get; set; }
		public DateTime Fechaprogramacion { get; set; }
		public bool Activo { get; set; }
		public int Idsucursal { get; set; }
	}
}
