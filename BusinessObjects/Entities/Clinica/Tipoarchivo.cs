using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipoarchivo")]
	public class Tipoarchivo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoarchivo")]
		public int Idtipoarchivo { get; set; }
		public string Nombretipoarchivo { get; set; }
	}
}
