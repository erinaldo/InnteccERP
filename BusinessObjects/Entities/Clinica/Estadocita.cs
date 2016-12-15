using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("estadocita")]
	public class Estadocita
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadocita")]
		public int Idestadocita { get; set; }
		public string Nombreestadocita { get; set; }
		public int Colorestadocita { get; set; }
        public bool Estadopordefectoprogramacion { get; set; }
        public byte[] Imagenestado { get; set; }
        
	}
}
