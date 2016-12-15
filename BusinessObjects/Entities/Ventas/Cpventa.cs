using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("cpventa")]
	public class Cpventa : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcpventa")]
		public  int Idcpventa{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  int?  Idtipocp{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  string Seriecpventa{ get; set; }
		public  string Numerocpventa{ get; set; }
		public  int Idcliente{ get; set; }
		public  DateTime Fechaemision{ get; set; }
		public  int?  Idperiodo{ get; set; }
		public  DateTime Fechavencimiento{ get; set; }
		public  bool Anulado{ get; set; }
		public  DateTime? Fechaanulado{ get; set; }
		public  int?  Idvendedor{ get; set; }
		public  int?  Idtipocondicion{ get; set; }
		public  decimal Tipocambio{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
		public  decimal Totalbruto{ get; set; }
		public  decimal Totalgravado{ get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
		public  decimal Totalimpuesto{ get; set; }
		public  decimal Importetotal{ get; set; }
		public  decimal Porcentajepercepcion{ get; set; }
		public  decimal Importetotalpercepcion{ get; set; }
		public  decimal Totaldocumento{ get; set; }
		public  string Glosacpventa{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  bool Incluyeimpuestoitems{ get; set; }
        public int Idtipolista { get; set; }
        public int Iddireccionfacturacion { get; set; }
        public string Listadoordenventaref { get; set; }
        public string Listadoguiaremref { get; set; }
	    public int? Idprogramacioncitadet { get; set; }
        public DateTime Horatransaccion { get; set; }
	}
}
