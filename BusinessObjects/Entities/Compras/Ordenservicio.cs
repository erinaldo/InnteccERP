using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("ordenservicio")]
	public class Ordenservicio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idordenservicio")]
		public int Idordenservicio { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Serieorden { get; set; }
		public string Numeroorden { get; set; }
		public DateTime Fechaordenservicio { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public int  Idproveedor { get; set; }
		public int?  Idprioridad { get; set; }
		public decimal Tipocambio { get; set; }
		public int?  Idtipomoneda { get; set; }
		public int?  Idtipocondicion { get; set; }
		public string Glosaordenservicio { get; set; }
		public DateTime?  Fechaentrega { get; set; }
		public bool Aprobado { get; set; }
		public DateTime?  Fechaapobacion { get; set; }
		public int Idimpuesto { get; set; }
		public int?  Idsucursal { get; set; }
		public bool Incluyeimpuestoitems { get; set; }
		public int?  Idsucursalentrega { get; set; }
		public int?  Idempresatransporte { get; set; }
		public int?  Idestadopago { get; set; }
		public string Nropedidoproveedor { get; set; }
		public int?  Personacontacto { get; set; }
		public int?  Tiporegistroorden { get; set; }
		public decimal Totalbruto { get; set; }
		public decimal Totalgravado { get; set; }
		public decimal Totalinafecto { get; set; }
		public decimal Totalexonerado { get; set; }
		public decimal Totalimpuesto { get; set; }
		public decimal Importetotal { get; set; }
		public decimal Porcentajepercepcion { get; set; }
		public decimal Importetotalpercepcion { get; set; }
		public decimal Totaldocumento { get; set; }
		public int?  Createdby { get; set; }
		public DateTime?  Creationdate { get; set; }
		public int?  Modifiedby { get; set; }
		public DateTime?  Lastmodified { get; set; }
	}
}
