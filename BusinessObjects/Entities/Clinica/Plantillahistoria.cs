using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("plantillahistoria")]
	public class Plantillahistoria
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idplantillahistoria")]
		public int Idplantillahistoria { get; set; }
		public int?  Idtipohistoria { get; set; }
	}
}
