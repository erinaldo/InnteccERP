using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwordentrabajo")]
	public class VwOrdentrabajo
	{
		[PrimaryKey]
		[Alias("idordentrabajo")]
		public int?  Idordentrabajo { get; set; }
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
		public string Serieordentrabajo { get; set; }
		public string Numeroordentrabajo { get; set; }
        public string Serienumeroot { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public DateTime?  Fechainicial { get; set; }
		public DateTime?  Fechafinal { get; set; }
		public bool?  Otterminada { get; set; }
		public string Programacion { get; set; }
		public string Ejecutado { get; set; }
		public string Observacion { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idresponsable { get; set; }
		public int?  Idpersonaresponsable { get; set; }
		public string Nombreresponsable { get; set; }
        public string Descripcionot { get; set; }
        public int? Idcentrodecosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
	}
}
