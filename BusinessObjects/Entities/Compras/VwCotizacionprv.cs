using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcotizacionprv")]
	public class VwCotizacionprv
	{
		[PrimaryKey]
		[Alias("idcotizacionprv")]
		public int?  Idcotizacionprv { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public string Direccionsucursal { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public bool?  Tieneimpuesto { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Maxnumeroitems { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public string Seriecotizacionprv { get; set; }
		public string Numerocotizacionprv { get; set; }
		public DateTime?  Fechaemision { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public int?  Idresponsable { get; set; }
		public string Razonsocial { get; set; }
		public string Nrodocentidad { get; set; }
		public int?  Idalmacenentrega { get; set; }
		public string Codigoalmacen { get; set; }
		public string Nombrealmacen { get; set; }
		public string Direccionalmacen { get; set; }
		public string Observacion { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
	}
}
