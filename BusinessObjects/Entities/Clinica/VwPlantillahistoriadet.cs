using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwplantillahistoriadet")]
	public class VwPlantillahistoriadet
	{
		[PrimaryKey]
		[Alias("idplantillahistoriadet")]
		public int  Idplantillahistoriadet { get; set; }
		public int?  Idplantillahistoria { get; set; }
		public int?  Idtipohistoria { get; set; }
		public string Codigotipohistoria { get; set; }
		public string Nombretipohistoria { get; set; }
		public int?  Ordentipohistoria { get; set; }
		public int?  Iditemhistoria { get; set; }
		public int?  Idcategoriahistoria { get; set; }
		public string Codigocategoriaitem { get; set; }
		public string Nombrecategoriaitem { get; set; }
		public int?  Ordencategoriaitem { get; set; }
		public int?  Ordenitemhistoria { get; set; }
		public string Nombreitemhistoria { get; set; }
		public string Tipodatoitemhistoria { get; set; }
		public bool?  Requierearchivo { get; set; }
		public bool?  Requiereplanembarazoparto { get; set; }
        public int Ordenitemplantilla { get; set; }
        [Ignore]
	    public DataEntityState DataEntityState { get; set; }
	}
}
