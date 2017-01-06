using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipodiagnostico")]
	public class Tipodiagnostico
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipodiagnostico")]
		public int Idtipodiagnostico { get; set; }
		public string Codigotipodiagnostico { get; set; }
		public string Descripciontipodiagnostico { get; set; }
	}
}
