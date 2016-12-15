using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("guiaremision")]
	public class Guiaremision : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idguiaremision")]
		public int Idguiaremision { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Serieguiaremision { get; set; }
		public string Numeroguiaremision { get; set; }
		public DateTime Fechaguiaremision { get; set; }
		public DateTime Fechatrasladoguia { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public bool Incluyeimpuestoitems { get; set; }
		public int?  Idsucursal { get; set; }
		public int?  Almacenorigen { get; set; }
		public int?  Almacendestino { get; set; }
		public int  Idsocionegocio { get; set; }
		public int?  Iddireccionsocio { get; set; }
		public int?  Idguiaremisionmotivo { get; set; }
		public int?  Idempleado { get; set; }
		public string Glosaguiaremision { get; set; }
		public int?  Idempresatransporte { get; set; }
		public string Placavehiculo { get; set; }
		public string Marcavehiculo { get; set; }
		public string Certificadovehiculo { get; set; }
		public string Chofervehiculo { get; set; }
		public string Licenciachofer { get; set; }
		public string Dnichofer { get; set; }
		public int Idtipomoneda { get; set; }
		public int Idimpuesto { get; set; }
		public decimal Tipocambio { get; set; }
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
        public string Listadoreqref { get; set; }
        public string Listadoordenventaref { get; set; }
        public string Listadpcpcompraref { get; set; }
        public string Listadoentradaalmacenref { get; set; }
	}
}
