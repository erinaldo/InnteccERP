using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cotizacionprv")]
	public class Cotizacionprv
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcotizacionprv")]
		public int Idcotizacionprv { get; set; }
		public int?  Idsucursal { get; set; }
		public int Idtipocp { get; set; }
		public int Idcptooperacion { get; set; }
		public string Seriecotizacionprv { get; set; }
		public string Numerocotizacionprv { get; set; }
		public DateTime Fechaemision { get; set; }
		public int?  Idtipomoneda { get; set; }
		public int?  Idresponsable { get; set; }
		public int?  Idalmacenentrega { get; set; }
		public string Observacion { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
	}
}
