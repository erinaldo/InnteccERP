using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("inventariostockdetserie")]
	public class Inventariostockdetserie
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idinventariostockdetserie")]
		public int Idinventariostockdetserie { get; set; }
		public int Idinventariostock { get; set; }
        public int Idseriearticulo { get; set; }
	}
}
