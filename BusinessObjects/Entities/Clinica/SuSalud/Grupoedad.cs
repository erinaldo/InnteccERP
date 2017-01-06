using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("grupoedad")]
	public class Grupoedad
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idgrupoedad")]
		public int Idgrupoedad { get; set; }
		public int Codigogrupoedad { get; set; }
		public string Descripciongrupoedad { get; set; }
		public int Edadinicial { get; set; }
		public int Edadfinal { get; set; }
	}
}
