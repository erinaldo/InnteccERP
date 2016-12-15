using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("movil")]
	[Alias("tipo")]
	public class Tipo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipo")]
		public int Idtipo { get; set; }
		public string Nombretipo { get; set; }
	}
}
