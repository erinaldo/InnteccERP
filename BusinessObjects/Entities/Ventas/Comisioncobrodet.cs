using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("comisioncobrodet")]
	public class Comisioncobrodet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcomisioncobrodet")]
		public int Idcomisioncobrodet { get; set; }
		public int Idcomisioncobro { get; set; }
		public int Rangoinicial { get; set; }
		public int Rangofinal { get; set; }
		public decimal Porcentajecomision { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
	}
}
