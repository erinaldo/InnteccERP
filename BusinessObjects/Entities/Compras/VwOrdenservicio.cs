using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwordenservicio")]
	public class VwOrdenservicio
	{
		[PrimaryKey]
		[Alias("idordenservicio")]
		public int?  Idordenservicio { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public int?  Maxnumeroitems { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public int?  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
		public string Serieorden { get; set; }
		public string Numeroorden { get; set; }
		public DateTime?  Fechaordenservicio { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public string Nombreresponsable { get; set; }
		public int?  Idproveedor { get; set; }
		public string Razonsocial { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public string Nrodocentidadprincipal { get; set; }
		public string Direccionfiscal { get; set; }
		public int?  Idprioridad { get; set; }
		public string Nombreprioridad { get; set; }
		public string Codigoprioridad { get; set; }
		public decimal?  Tipocambio { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public int?  Idtipocondicion { get; set; }
		public string Codigocondicion { get; set; }
		public string Nombrecondicion { get; set; }
		public int?  Diascondicion { get; set; }
		public decimal?  Totalbruto { get; set; }
		public decimal?  Totalgravado { get; set; }
		public decimal?  Totalinafecto { get; set; }
		public decimal?  Totalexonerado { get; set; }
		public decimal?  Totalimpuesto { get; set; }
		public decimal?  Importetotal { get; set; }
		public decimal?  Porcentajepercepcion { get; set; }
		public decimal?  Importetotalpercepcion { get; set; }
		public decimal?  Totaldocumento { get; set; }
		public string Glosaordenservicio { get; set; }
		public DateTime?  Fechaentrega { get; set; }
		public bool?  Aprobado { get; set; }
		public DateTime?  Fechaapobacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idsucursalentrega { get; set; }
		public string Nombresucursalentrega { get; set; }
		public int?  Idestadopago { get; set; }
		public string Nombreestadopago { get; set; }
		public string Nropedidoproveedor { get; set; }
		public bool?  Incluyeimpuestoitems { get; set; }
	}
}
