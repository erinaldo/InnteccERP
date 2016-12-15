using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipociclomenstrual")]
	public class Tipociclomenstrual
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipociclomenstrual")]
		public int Idtipociclomenstrual { get; set; }
		public string Nombretipociclomenstrual { get; set; }
		public string Descricpciontipociclomenstrual { get; set; }
	}
}
