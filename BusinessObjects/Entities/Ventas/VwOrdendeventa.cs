using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwordendeventa")]
	public class VwOrdendeventa
	{
		[PrimaryKey]
		[Alias("idordendeventa")]
		public  int  Idordendeventa{ get; set; }
		public  int  Idtipocp{ get; set; }
		public  string Codigotipocp{ get; set; }
		public  int  Idtipoformato{ get; set; }
		public  int  Maxnumeroitems{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  string Serieordenventa{ get; set; }
		public  string  Numeroordenventa{ get; set; }
        public string Serienumeroordenventa { get; set; }
		public  DateTime  Fechaordenventa{ get; set; }
		public  DateTime  Fechaentrega{ get; set; }
		public  string Listadocotizacioncliente{ get; set; }
		public  bool  Anulado{ get; set; }
		public  DateTime  Fechaanulado{ get; set; }
		public  decimal  Tipocambio{ get; set; }
		public  bool  Incluyeimpuestoitems{ get; set; }
		public  int  Idcliente{ get; set; }
		public  string Razonsocial{ get; set; }
		public  string Nombretipodocentidad{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
		public  string Nrodocentidadprincipal{ get; set; }
		public  string Nombreubigeo{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  int? Personacontacto{ get; set; }
		public  int  Idtipolista{ get; set; }
		public  string Codigotipolista{ get; set; }
		public  string Nombretipolista{ get; set; }
		public  decimal  Porcentajedescuento{ get; set; }
		public  int  Idempleado{ get; set; }
		public  string Nombreresponsable{ get; set; }
		public  int  Idtipomoneda{ get; set; }
		public  string Codigotipomoneda{ get; set; }
		public  string Nombretipomoneda{ get; set; }
		public  string Simbolomoneda{ get; set; }
		public  int  Idtipocondicion{ get; set; }
		public  string Codigocondicion{ get; set; }
		public  string Nombrecondicion{ get; set; }
		public  int  Diascondicion{ get; set; }
		public  string Docrefcliente{ get; set; }
		public  decimal  Totalbruto{ get; set; }
		public  decimal  Totalgravado{ get; set; }
        public decimal Totalinafecto { get; set; }
		public  decimal  Totalexonerado{ get; set; }
		public  int  Idimpuesto{ get; set; }
		public  decimal  Totalimpuesto{ get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
		public  decimal  Totaldocumento{ get; set; }
		public  string Glosaordenventa{ get; set; }
		public  decimal  Pordescuentoadi{ get; set; }
		public  decimal  Totaldescuentoadi{ get; set; }
		public  int  Idsocionegociodireccion{ get; set; }
		public  string Direccionsocionegocio{ get; set; }
		public  string Referencia{ get; set; }
		public  string Personadestinario{ get; set; }
		public  int  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
        public int Idcptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public int Iddireccionentrega { get; set; }
        public int Iddireccionfacturacion { get; set; }
        public decimal Cantidadimportada { get; set; }
        public decimal Cantidadorden { get; set; }
        public string Estadofacturacion { get; set; }
        public int? Idtipocpventa { get; set; }
        public string Listadocotcliref { get; set; }
	}
}
