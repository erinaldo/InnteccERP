using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("movil")]
	[Alias("plan")]
	public class Plan
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idplan")]
		public int Idplan { get; set; }
		public string Nombreplan { get; set; }
	}
}
