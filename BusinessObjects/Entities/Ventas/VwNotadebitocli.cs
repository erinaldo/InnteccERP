using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwnotadebitocli")]
	public class VwNotadebitocli
	{
		[PrimaryKey]
		[Alias("idnotadebitocli")]
		public int?  Idnotadebitocli { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Idtipocppago { get; set; }
		public string Codigotipocppago { get; set; }
		public string Nombretipocppago { get; set; }
		public bool?  Regventas { get; set; }
		public string Serienotadebito { get; set; }
		public string Numeronotadebito { get; set; }
		public DateTime?  Fechaemision { get; set; }
		public DateTime?  Fechavencimiento { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idempresa { get; set; }
		public string Razonsocialempresa { get; set; }
		public int?  Idcliente { get; set; }
		public int?  Idpersonasocio { get; set; }
		public string Razonsocialsocio { get; set; }
		public string Rucsocio { get; set; }
		public int?  Idtipodocent { get; set; }
		public string Codigotipodocentidad { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersonaempleado { get; set; }
		public string Nombreempleado { get; set; }
		public string Nrodocentidadempleado { get; set; }
		public decimal?  Tipocambio { get; set; }
		public int?  Idtipomoneda { get; set; }
        public string Codigotipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
		public decimal?  Totalbruto { get; set; }
		public decimal?  Totalgravado { get; set; }
		public decimal?  Totalinafecto { get; set; }
		public decimal?  Totalexonerado { get; set; }
		public int?  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal?  Porcentajeimpuesto { get; set; }
		public decimal?  Totalimpuesto { get; set; }
		public decimal?  Importetotal { get; set; }
		public decimal?  Porcentajepercepcion { get; set; }
		public decimal?  Importetotalpercepcion { get; set; }
		public decimal?  Totaldocumento { get; set; }
		public bool?  Incluyeimpuestoitems { get; set; }
	}
}
