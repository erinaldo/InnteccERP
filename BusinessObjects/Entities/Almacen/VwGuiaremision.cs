using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwguiaremision")]
	public class VwGuiaremision
	{
		[PrimaryKey]
		[Alias("idguiaremision")]
		public int?  Idguiaremision { get; set; }
		public int?  Almacenorigen { get; set; }
		public string Nombrealmaorigen { get; set; }
		public string Direccionalmacenorigen { get; set; }
		public int?  Iddistritoalmaorigen { get; set; }
		public string Nombreubigeoalmaorigen { get; set; }
		public string Nombredepartamentoalmaorigen { get; set; }
		public string Nombreprovinciaalmaorigen { get; set; }
		public string Nombredistritoalmaorigen { get; set; }
		public int?  Almacendestino { get; set; }
		public string Nombrealmadestino { get; set; }
		public string Direccionalmacenalmadestino { get; set; }
		public int?  Iddistritoalmadestino { get; set; }
		public string Nombreubigeoalmadestino { get; set; }
		public string Nombredepartamentoalmadestino { get; set; }
		public string Nombreprovinciaalmadestino { get; set; }
		public string Nombredistritoalmadestino { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
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
		public string Serieguiaremision { get; set; }
		public string Numeroguiaremision { get; set; }
		public bool  Incluyeimpuestoitems { get; set; }
		public int?  Idempleado { get; set; }
		public string Nombreresponsable { get; set; }
		public int?  Idsocionegocio { get; set; }
		public string Razonsocial { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public string Nrodocentidadprincipal { get; set; }
		public string Direccionfiscal { get; set; }
		public int?  Iddireccionsocio { get; set; }
		public string Direccionsocionegocio { get; set; }
		public int?  Idguiaremisionmotivo { get; set; }
		public string Nombreguiaremisionmotivo { get; set; }
		public DateTime?  Fechaguiaremision { get; set; }
		public DateTime?  Fechatrasladoguia { get; set; }
		public string Glosaguiaremision { get; set; }
		public int?  Idempresatransporte { get; set; }
		public string Empresatransporte { get; set; }
		public string Placavehiculo { get; set; }
		public string Marcavehiculo { get; set; }
		public string Certificadovehiculo { get; set; }
		public string Chofervehiculo { get; set; }
		public string Licenciachofer { get; set; }
		public string Dnichofer { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public decimal?  Tipocambio { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public int?  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal?  Porcentajeimpuesto { get; set; }
		public decimal?  Totalbruto { get; set; }
		public decimal?  Totalgravado { get; set; }
		public decimal?  Totalinafecto { get; set; }
		public decimal?  Totalexonerado { get; set; }
		public decimal?  Totalimpuesto { get; set; }
		public decimal?  Importetotal { get; set; }
		public decimal?  Porcentajepercepcion { get; set; }
		public decimal?  Importetotalpercepcion { get; set; }
		public decimal?  Totaldocumento { get; set; }
	}
}
