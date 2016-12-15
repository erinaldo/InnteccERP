using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("categoriaitem")]
	public class Categoriaitem
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcategoriaitem")]
		public int Idcategoriaitem { get; set; }
		public string Codigocategoriaitem { get; set; }
		public string Nombrecategoriaitem { get; set; }
		public int Ordencategoriaitem { get; set; }
	}
}
