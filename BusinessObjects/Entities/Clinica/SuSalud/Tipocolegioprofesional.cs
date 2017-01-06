using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("tipocolegioprofesional")]
	public class Tipocolegioprofesional
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocolegioprofesional")]
		public int Idtipocolegioprofesional { get; set; }
		public string Codigotipocolegioprofesional { get; set; }
		public string Descripciontipocolegioprofesional { get; set; }
	}
}
