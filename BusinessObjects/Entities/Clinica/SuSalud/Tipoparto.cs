using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipoparto")]
	public class Tipoparto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoparto")]
		public int Idtipoparto { get; set; }
		public string Codigotipoparto { get; set; }
		public string Descripciontipoparto { get; set; }
	}
}
