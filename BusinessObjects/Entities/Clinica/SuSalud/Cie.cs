using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("cie")]
	public class Cie
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcie")]
		public int Idcie { get; set; }
		public string Codigocie { get; set; }
		public string Descripcioncie { get; set; }
		public string Sexo { get; set; }
		public int Edadinicial { get; set; }
		public int Edadfinal { get; set; }
		public string Descripcionciebusqueda { get; set; }
	}
}
