using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipocomplicacionparto")]
	public class Tipocomplicacionparto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocomplicacionparto")]
		public int Idtipocomplicacionparto { get; set; }
		public string Codigotipocomplicacionparto { get; set; }
		public string Descripciontipocomplicacionparto { get; set; }
	}
}
