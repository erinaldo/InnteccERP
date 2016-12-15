using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("motivocita")]
	public class Motivocita
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmotivocita")]
		public int Idmotivocita { get; set; }
		public string Nombremotivocita { get; set; }
        public bool Motivopordefectoprogramacion { get; set; }
        public string Tiempoduracion { get; set; }
	}
}
