using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cpcompradetserie")]
	public class Cpcompradetserie
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcpcompradetserie")]
		public int Idcpcompradetserie { get; set; }
		public int Idcpcompradet { get; set; }
        public int Idseriearticulo { get; set; }
	}
}
