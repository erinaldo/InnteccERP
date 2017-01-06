using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipocirugia")]
	public class Tipocirugia
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocirugia")]
		public int Idtipocirugia { get; set; }
		public string Codigotipocirugia { get; set; }
		public string Descripciontipocirugia { get; set; }
	}
}
