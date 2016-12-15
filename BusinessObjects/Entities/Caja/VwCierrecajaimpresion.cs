using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("vwcierrecajaimpresion")]
	public class VwCierrecajaimpresion
	{
		[PrimaryKey]
		[Alias("idcierrecajadet")]
		public int?  Idcierrecajadet { get; set; }
		public int?  Idcierrecaja { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public DateTime?  Fechacierre { get; set; }
		public int?  Idempleado { get; set; }
		public string Nombreempleado { get; set; }
		public string Nrodocentidadempleado { get; set; }
		public string Comentario { get; set; }
		public int?  Idmediopago { get; set; }
		public string Nombremediopago { get; set; }
		public decimal?  Importe { get; set; }
		public decimal?  Totalcierrecaja { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
	}
}
