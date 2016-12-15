using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("vwcierrecaja")]
	public class VwCierrecaja
	{
		[PrimaryKey]
		[Alias("idcierrecaja")]
		public int?  Idcierrecaja { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public DateTime?  Fechacierre { get; set; }
		public int?  Idejercicio { get; set; }
		public int?  Anioejercicio { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersona { get; set; }
		public string Razonsocial { get; set; }
		public string Nrodocentidad { get; set; }
		public int?  Idsucursal { get; set; }
		public string Comentario { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public decimal?  Totalcierrecaja { get; set; }
	}
}
