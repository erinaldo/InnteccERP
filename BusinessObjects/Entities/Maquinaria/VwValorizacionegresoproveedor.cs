using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwvalorizacionegresoproveedor")]
	public class VwValorizacionegresoproveedor
	{
		[PrimaryKey]
		[Alias("idvalorizacionegresoproveedor")]
		public int  Idvalorizacionegresoproveedor { get; set; }
		public int  Idvalorizacionproveedor { get; set; }
		public string Serievalorizacion { get; set; }
		public string Numerovalorizacion { get; set; }
		public DateTime?  Fechavalorizacion { get; set; }
		public DateTime?  Fechainicio { get; set; }
		public DateTime?  Fechafinal { get; set; }
		public int?  Idtipoegresovalorizacion { get; set; }
		public string Nombretipoegresovaloriza { get; set; }
		public decimal  Cantidad { get; set; }
		public decimal  Preciounitario { get; set; }
		public decimal  Importetotal { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
	}
}
