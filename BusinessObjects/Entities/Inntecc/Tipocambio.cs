using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipocambio")]
	public class Tipocambio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocambio")]
		public int Idtipocambio { get; set; }
		public int Idtipomoneda { get; set; }
		public DateTime Fechatipocambio { get; set; }
		public decimal Valorcomprasunat { get; set; }
		public decimal Valorventasunat { get; set; }
	}
}
