using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("notacredito")]
	public class Notacredito : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idnotacredito")]
		public  int Idnotacredito{ get; set; }
		public  int?  Idtipocp{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Serienotacredito{ get; set; }
		public  string Numeronotacredito{ get; set; }
		public  DateTime Fechaemision{ get; set; }
		public  DateTime?  Fecharecepcion{ get; set; }
		public  DateTime Fecharegistro{ get; set; }
		public  int  Idproveedor{ get; set; }
		public  bool Anulado{ get; set; }
		public  DateTime?  Fechaanulado{ get; set; }
		public  int Idempleado{ get; set; }
		public  decimal Tipocambio{ get; set; }
		public  int Idtipomoneda{ get; set; }
		public  decimal Totalbruto{ get; set; }
		public  decimal Baseimponible{ get; set; }
		public  decimal Totalimpuesto{ get; set; }
		public  decimal Totalneto{ get; set; }
		public  decimal Totalpercepcion{ get; set; }
		public  decimal Totaldocumento{ get; set; }
		public  string Glosanotacredito{ get; set; }
		public  int Idimpuesto{ get; set; }
		public  bool Incluyeimpuestoitems{ get; set; }
		public  int Idperiodo{ get; set; }
	}
}
