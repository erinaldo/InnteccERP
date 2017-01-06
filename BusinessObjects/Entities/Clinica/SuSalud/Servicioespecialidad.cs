using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("servicioespecialidad")]
	public class Servicioespecialidad
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idservicioespecialidad")]
		public int Idservicioespecialidad { get; set; }
		public string Codigoservicioespecialidad { get; set; }
		public string Descripcionservicioespecialidad { get; set; }
	}
}
