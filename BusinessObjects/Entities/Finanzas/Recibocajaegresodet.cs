using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("recibocajaegresodet")]
	public class Recibocajaegresodet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrecibocajaegresodet")]
		public int Idrecibocajaegresodet { get; set; }
		public int Idrecibocajaegreso { get; set; }
		public decimal Importepago { get; set; }
		public int Idmediopago { get; set; }
		public string Numeromediopago { get; set; }
		public int Numeroitem { get; set; }
		public string Comentario { get; set; }
        public int? Idcpcompra { get; set; }
	}
}
