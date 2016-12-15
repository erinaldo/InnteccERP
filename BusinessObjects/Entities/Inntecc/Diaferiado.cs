using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("diaferiado")]
	public class Diaferiado
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("iddiaferiado")]
		public int Iddiaferiado { get; set; }
		public DateTime Fechaferiado { get; set; }
        public string Motivodiaferiado { get; set; }
	}
}
