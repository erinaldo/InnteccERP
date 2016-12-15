using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("rendicioncajachica")]
	public class Rendicioncajachica
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrendicioncajachica")]
		public int Idrendicioncajachica { get; set; }
		public int Idrecibocaja { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idcptooperacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Serierendicioncaja { get; set; }
		public string Numerorendicioncaja { get; set; }
		public DateTime?  Fecharendicioncaja { get; set; }
		public bool  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public string Comentario { get; set; }
		public decimal?  Totaldocumento { get; set; }
        public bool Rendicionterminada { get; set; }
        public int? Idtipomoneda { get; set; }
	}
}
