using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwitemhistoria")]
	public class VwItemhistoria
	{
		[PrimaryKey]
		[Alias("iditemhistoria")]
		public int?  Iditemhistoria { get; set; }
		public int  Idcategoriaitem { get; set; }
		public string Codigocategoriaitem { get; set; }
		public string Nombrecategoriaitem { get; set; }
		public int?  Ordencategoriaitem { get; set; }
		public int?  Ordenitemhistoria { get; set; }
		public string Nombreitemhistoria { get; set; }
		public string Tipodatoitemhistoria { get; set; }
		public bool?  Requierearchivo { get; set; }
		public bool?  Requiereplanembarazoparto { get; set; }
	}
}
