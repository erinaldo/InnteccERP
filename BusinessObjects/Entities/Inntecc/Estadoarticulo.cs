using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("estadoarticulo")]
	public class Estadoarticulo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadoarticulo")]
		public int Idestadoarticulo { get; set; }
		public string Nombreestadoarticulo { get; set; }
        public bool Permitecomprar { get; set; }
        public bool Permitevender { get; set; }
        public bool Permiteconsumointerno { get; set; }
	}
}
