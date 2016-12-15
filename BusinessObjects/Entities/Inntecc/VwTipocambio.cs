using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwtipocambio")]
	public class VwTipocambio
	{
		[PrimaryKey]
		[Alias("idtipocambio")]
		public int  Idtipocambio { get; set; }
		public int  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public DateTime  Fechatipocambio { get; set; }
		public decimal  Valorcomprasunat { get; set; }
        public decimal Valorventasunat { get; set; }
	}
}
