using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("ordentrabajo")]
	public class Ordentrabajo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idordentrabajo")]
		public int Idordentrabajo { get; set; }
		public int Idsucursal { get; set; }
		public int Idtipocp { get; set; }
		public int Idcptooperacion { get; set; }
		public string Serieordentrabajo { get; set; }
		public string Numeroordentrabajo { get; set; }
		public DateTime Fecharegistro { get; set; }
		public DateTime Fechainicial { get; set; }
		public DateTime Fechafinal { get; set; }
		public bool Otterminada { get; set; }
		public string Programacion { get; set; }
		public string Ejecutado { get; set; }
		public string Observacion { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int Idresponsable { get; set; }
        public string Descripcionot { get; set; }
        public int? Idcentrodecosto { get; set; }



	}
}
