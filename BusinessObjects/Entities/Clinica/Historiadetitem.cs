using System;
using System.Security.AccessControl;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiadetitem")]
	public class Historiadetitem
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriadetitem")]
		public int Idhistoriadetitem { get; set; }
		public int Idhistoriadet { get; set; }
		public int?  Iditemhistoria { get; set; }
		public string Valoritemhistoria { get; set; }
        public int Ordenhistoriadetitem { get; set; }
	}
}
