using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("cpventadetserie")]
	public class Cpventadetserie
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcpventadetserie")]
		public int Idcpventadetserie { get; set; }
		public int Idcpventadet { get; set; }
        public int Idseriearticulo { get; set; }
	}
}
