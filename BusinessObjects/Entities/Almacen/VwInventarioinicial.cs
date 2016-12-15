using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwinventarioinicial")]
	public class VwInventarioinicial
	{
		[PrimaryKey]
		[Alias("idinventarioinicial")]
		public int?  Idinventarioinicial { get; set; }
		public int?  Idempresa { get; set; }
		public string Ruc { get; set; }
		public string Nombreempresa { get; set; }
		public DateTime?  Fechainventarioinicial { get; set; }
        public string Fechainventarioinicialempresa { get; set; }
	}
}
