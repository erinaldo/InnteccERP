using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("plantillahistoriadet")]
	public class Plantillahistoriadet
	{
		[PrimaryKey]
        [AutoIncrement]
		[Alias("idplantillahistoriadet")]
		public int Idplantillahistoriadet { get; set; }
		public int?  Idplantillahistoria { get; set; }
		public int?  Iditemhistoria { get; set; }
        public int Ordenitemplantilla { get; set; }
	}
}
