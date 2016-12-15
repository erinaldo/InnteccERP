using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiaarchivo")]
	public class Historiaarchivo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriaarchivo")]
		public int Idhistoriaarchivo { get; set; }
		public int Idhistoriadetitem { get; set; }
		public int Idtipoarchivo { get; set; }
		public string Descripcion { get; set; }
		public DateTime Fechadocumento { get; set; }
		public string Nombrearchivo { get; set; }
	}
}
