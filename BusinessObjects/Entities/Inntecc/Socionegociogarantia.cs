using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegociogarantia")]
	public class Socionegociogarantia
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegociogarantia")]
		public int Idsocionegociogarantia { get; set; }
		public int Idsocionegocio { get; set; }
		public int Idtipogarantia { get; set; }
		public int Idtipomoneda { get; set; }
		public decimal Importe { get; set; }
		public int Identfinaciera { get; set; }
		public DateTime Vencimiento { get; set; }
		public string Descripicion { get; set; }
	}
}
