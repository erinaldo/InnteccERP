using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipoanalisis")]
	public class Tipoanalisis
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoanalisis")]
		public int Idtipoanalisis { get; set; }
		public string Nombretipoanalisis { get; set; }
	}
}
