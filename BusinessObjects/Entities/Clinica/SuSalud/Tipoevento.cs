using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipoevento")]
	public class Tipoevento
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipoevento")]
		public int Idtipoevento { get; set; }
		public string Codigotipoevento { get; set; }
		public string Descripciontipoevento { get; set; }
	}
}
