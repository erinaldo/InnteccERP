using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("inventarioinicial")]
	public class Inventarioinicial
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idinventarioinicial")]
		public int Idinventarioinicial { get; set; }
		public int Idempresa { get; set; }
		public DateTime Fechainventarioinicial { get; set; }
	}
}
