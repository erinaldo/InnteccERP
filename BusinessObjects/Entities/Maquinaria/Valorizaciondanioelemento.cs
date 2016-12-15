using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizaciondanioelemento")]
	public class Valorizaciondanioelemento
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizaciondanioelemento")]
		public int Idvalorizaciondanioelemento { get; set; }
		public int Idtipocp { get; set; }
		public int Idcptooperacion { get; set; }
		public int Idvalorizacion { get; set; }
		public int Idsucursal { get; set; }
		public int Idresponsable { get; set; }
		public DateTime Fecharegistro { get; set; }
		public int Idarticulodanio { get; set; }
		public int Idarticuloelementodesgaste { get; set; }
		public string Comentario { get; set; }
		public bool Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public string Seriede { get; set; }
		public string Numerode { get; set; }
        public decimal Totaldanio { get; set; }
        public decimal Totalelemento { get; set; }
        public decimal Totaldocumento { get; set; }
	}
}
