using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("recibocajaingreso")]
	public class Recibocajaingreso
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrecibocajaingreso")]
		public int Idrecibocajaingreso { get; set; }
		public int Idtipocp { get; set; }
		public int Idcptooperacion { get; set; }
		public int Idsucursal { get; set; }
        public int Idtiporecibo { get; set; }
		public string Serierecibo { get; set; }
		public string Numerorecibo { get; set; }
		public DateTime Fecharecibo { get; set; }
		public DateTime Fechapago { get; set; }
		public int Idsocionegocio { get; set; }
		public bool  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int Idempleado { get; set; }
		public int Idtipomoneda { get; set; }
		public decimal Tipocambio { get; set; }
		public string Comentario { get; set; }
		public decimal Totaldocumento { get; set; }
	}
}
