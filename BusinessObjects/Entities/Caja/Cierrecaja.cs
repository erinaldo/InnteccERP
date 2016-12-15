using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("cierrecaja")]
	public class Cierrecaja
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcierrecaja")]
		public int Idcierrecaja { get; set; }
		public DateTime Fecharegistro { get; set; }
		public DateTime Fechacierre { get; set; }
		public int Idempleado { get; set; }
		public string Comentario { get; set; }
		public decimal Totalcierrecaja { get; set; }
		public int Idejercicio { get; set; }
		public int Idsucursal { get; set; }
		public int Idtipomoneda { get; set; }
	}
}
