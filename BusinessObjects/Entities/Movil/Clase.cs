using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("movil")]
	[Alias("clase")]
	public class Clase
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idclase")]
		public int Idclase { get; set; }
		public string Nombreclase { get; set; }
	}
}
