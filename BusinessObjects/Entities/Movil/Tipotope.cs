using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("movil")]
	[Alias("tipotope")]
	public class Tipotope
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipotope")]
		public int Idtipotope { get; set; }
		public string Nombretipotope { get; set; }
	}
}
