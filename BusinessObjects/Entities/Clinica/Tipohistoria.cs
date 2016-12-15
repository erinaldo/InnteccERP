using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipohistoria")]
	public class Tipohistoria
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipohistoria")]
		public int Idtipohistoria { get; set; }
		public string Codigotipohistoria { get; set; }
		public string Nombretipohistoria { get; set; }
		public int Ordentipohistoria { get; set; }
	}
}
