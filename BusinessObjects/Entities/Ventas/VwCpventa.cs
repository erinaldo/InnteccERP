using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwcpventa")]
	public class VwCpventa : BusinessObject
	{
		[PrimaryKey]
		[Alias("idcpventa")]
		public  int  Idcpventa{ get; set; }
		public  int  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  int  Idtipocp{ get; set; }
		public  string Codigotipocp{ get; set; }
		public  int?  Idtipoformato{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  bool?  Tieneimpuesto{ get; set; }
		public  int?  Idtipocppago{ get; set; }
		public  string Codigotipocppago{ get; set; }
		public  string Nombretipocppago{ get; set; }
		public  int?  Maxnumeroitems{ get; set; }
		public  string Nombrereporte{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  string Codigocptooperacion{ get; set; }
		public  string Nombrecptooperacion{ get; set; }
		public  bool?  Generasalida{ get; set; }
		public  bool?  Tienecpcaja{ get; set; }
		public  bool?  Tienecpcobrarpagar{ get; set; }
		public  string Seriecpventa{ get; set; }
		public  string Numerocpventa{ get; set; }
		public  int  Idcliente{ get; set; }
		public  string Codigosocio{ get; set; }
		public  string Nrodocentidadcliente{ get; set; }
		public  string Razonsocialcliente{ get; set; }
		public  int?  Idtipodocent{ get; set; }
		public  string Codigotipodocentidadcliente{ get; set; }
		public  string Nombretipodocentidadcliente{ get; set; }
		public  string Abreviaturadocentidadcliente{ get; set; }
		public  string Nrodocprincipalcliente{ get; set; }
		public  DateTime  Fechaemision{ get; set; }
		public  int?  Idperiodo{ get; set; }
		public  int?  Anioejercicio{ get; set; }
		public  string Mes{ get; set; }
		public  DateTime?  Fechavencimiento{ get; set; }
		public  bool?  Anulado{ get; set; }
		public  DateTime?  Fechaanulado{ get; set; }
		public  int?  Idvendedor{ get; set; }
		public  int?  Idpersonavendedor{ get; set; }
		public  string Nombrevendedor{ get; set; }
		public  int?  Idtipocondicion{ get; set; }
		public  string Codigocondicion{ get; set; }
		public  string Nombrecondicion{ get; set; }
		public  int?  Diascondicion{ get; set; }
		public  decimal Tipocambio{ get; set; }
		public  int  Idtipomoneda{ get; set; }
		public  string Codigotipomoneda{ get; set; }
		public  string Nombretipomoneda{ get; set; }
		public  string Simbolomoneda{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  bool  Incluyeimpuestoitems{ get; set; }
		public  string Glosacpventa{ get; set; }
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Totalimpuesto { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public int Idtipolista { get; set; }
        public string Nombretipolista { get; set; }
        public int? Iddireccionfacturacion { get; set; }
        public string Direccionsocionegocio { get; set; }
        public string Referencia { get; set; }
        public string Listadoordenventaref { get; set; }
        public string Listadoguiaremref { get; set; }
        public int Idtipodocmov { get; set; }
        public string Nombretipodocmov { get; set; }
	    public decimal Cantidadventa { get; set; }
        public DateTime? Horatransaccion { get; set; }
	}
}
