using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwhistoriaarchivo")]
	public class VwHistoriaarchivo
	{
		[PrimaryKey]
		[Alias("idhistoriaarchivo")]
		public int?  Idhistoriaarchivo { get; set; }
		public int?  Idhistoriadetitem { get; set; }
		public int?  Idtipoarchivo { get; set; }
		public string Nombretipoarchivo { get; set; }
		public string Descripcion { get; set; }
		public DateTime?  Fechadocumento { get; set; }
		public string Nombrearchivo { get; set; }
	}
}
