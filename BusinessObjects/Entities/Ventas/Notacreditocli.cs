using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("notacreditocli")]
	public class Notacreditocli
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idnotacreditocli")]
		public int Idnotacreditocli { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idcptooperacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Serienotacredito { get; set; }
		public string Numeronotacredito { get; set; }
		public DateTime Fechaemision { get; set; }
		public DateTime Fechavencimiento { get; set; }
		public int  Idcliente { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int Idempleado { get; set; }
		public decimal Tipocambio { get; set; }
		public int Idtipomoneda { get; set; }
		public decimal Totalbruto { get; set; }
		public decimal Totalgravado { get; set; }
		public decimal Totalinafecto { get; set; }
		public decimal Totalexonerado { get; set; }
		public int Idimpuesto { get; set; }
		public decimal Totalimpuesto { get; set; }
		public decimal Importetotal { get; set; }
		public decimal Porcentajepercepcion { get; set; }
		public decimal Importetotalpercepcion { get; set; }
		public decimal Totaldocumento { get; set; }
		public bool Incluyeimpuestoitems { get; set; }
		public string Glosanotacredito { get; set; }
		public int Idperiodo { get; set; }
		public int?  Idtipolista { get; set; }
		public int?  Iddireccionfacturacion { get; set; }
        public string Listadocpventaref { get; set; }
	    public int? Idcpventa { get; set; }

	}
}
