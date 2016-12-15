using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("mantenimiento")]
	public class Mantenimiento
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmantenimiento")]
		public int Idmantenimiento { get; set; }
		public int  Idsucursal { get; set; }
		public int  Idtipocp { get; set; }
		public int  Idcptooperacion { get; set; }
		public string Seriemantenimiento { get; set; }
		public string Numeromantenimiento { get; set; }
		public DateTime  Fechamantenimiento { get; set; }
		public int  Idregistrador { get; set; }
		public string Trabajorealizado { get; set; }
		public bool  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public DateTime  Fecharegistro { get; set; }
        public int Idequipo { get; set; }
	}
}
