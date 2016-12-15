using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cuadrocomparativo")]
	public class Cuadrocomparativo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcuadrocomparativo")]
		public int Idcuadrocomparativo { get; set; }
		public int Idsucursal { get; set; }
		public int Idtipocp { get; set; }
		public int Idcptooperacion { get; set; }
		public string Seriecc { get; set; }
		public string Numerocc { get; set; }
		public DateTime Fechaemision { get; set; }
		public int?  Idresponsable { get; set; }
		public bool Culminado { get; set; }
		public DateTime? Fechaculminacion { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public string Observacion { get; set; }
		public int? Idcotizacionprv { get; set; }
        public int? Idempleadoaprueba { get; set; }
        public int? Idestadocuadrocomparativo { get; set; }
        public string Observacionaprobacion { get; set; }
        public Decimal Totalbuenapro { get; set; }
        public DateTime? Fechaaprobacion { get; set; } 

	}
}
