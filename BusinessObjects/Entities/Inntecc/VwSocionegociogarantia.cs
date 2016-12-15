using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegociogarantia")]
	public class VwSocionegociogarantia
	{
		[PrimaryKey]
		[Alias("idsocionegociogarantia")]
		public int  Idsocionegociogarantia { get; set; }
		public int  Idsocionegocio { get; set; }
		public int  Idtipogarantia { get; set; }
		public string Nombretipogarantia { get; set; }
		public int  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public int  Identfinaciera { get; set; }
		public string Codentidadfinaciera { get; set; }
		public string Nombreentidadfinanciera { get; set; }
		public decimal  Importe { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Descripicion { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
