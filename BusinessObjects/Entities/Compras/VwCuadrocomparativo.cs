using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcuadrocomparativo")]
	public class VwCuadrocomparativo
	{
		[PrimaryKey]
		[Alias("idcuadrocomparativo")]
		public int  Idcuadrocomparativo { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public string Seriecc { get; set; }
		public string Numerocc { get; set; }
	    public string Serienumerocc { get; set; }
	    public DateTime?  Fechaemision { get; set; }
		public int?  Idresponsable { get; set; }
		public int?  Idpersonaresponsable { get; set; }
		public string Nombreresponsable { get; set; }
		public bool?  Culminado { get; set; }
		public DateTime?  Fechaculminacion { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public string Observacion { get; set; }
		public int?  Idcotizacionprv { get; set; }
		public string Sericotizacionprv { get; set; }
		public string Numerocotizacionprv { get; set; }
        public DateTime? Fechacotizacion { get; set; }
        public string Serienumerocotizacion { get; set; }
        public int Idestadocuadrocomparativo { get; set; }
        public string Nombreestado { get; set; }
        public int? Idtipodocmov { get; set; }
        public int Idempleadoaprueba { get; set; }
        public decimal Totalbuenapro { get; set; }
	}
}
