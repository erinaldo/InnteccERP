using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("recibocajaingresodet")]
	public class Recibocajaingresodet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrecibocajaingresodet")]
		public int Idrecibocajaingresodet { get; set; }
		public int Idrecibocajaingreso { get; set; }
		public decimal Importepago { get; set; }
		public int Idmediopago { get; set; }
		public string Numeromediopago { get; set; }
        public int Numeroitem { get; set; }
        public string Comentario { get; set; }
        public int? Idcpventa { get; set; }
        public int? Idnotacreditocli { get; set; }
        public decimal Importenc { get; set; }
	}
}
