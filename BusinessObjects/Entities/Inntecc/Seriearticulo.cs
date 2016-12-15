using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("seriearticulo")]
	public class Seriearticulo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idseriearticulo")]
		public int Idseriearticulo { get; set; }
		public string Numeroserieitem { get; set; }
		public string Codigointernoitem { get; set; }
        public bool Serieutilizada { get; set; }
        public DateTime? Fecharegistro { get; set; }
	}
}
