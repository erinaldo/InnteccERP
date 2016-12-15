using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwplantillahistoria")]
	public class VwPlantillahistoria
	{
		[PrimaryKey]
		[Alias("idplantillahistoria")]
		public int?  Idplantillahistoria { get; set; }
		public int?  Idtipohistoria { get; set; }
		public string Codigotipohistoria { get; set; }
		public string Nombretipohistoria { get; set; }
		public int?  Ordentipohistoria { get; set; }
	}
}
