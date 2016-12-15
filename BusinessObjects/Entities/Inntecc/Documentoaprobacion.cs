using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("documentoaprobacion")]
	public class Documentoaprobacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("iddocumentoaprobacion")]
		public int Iddocumentoaprobacion { get; set; }
		public int Idtipodocmov { get; set; }
		public int Iddocumentomov { get; set; }
		public int Empleadoaprueba { get; set; }
		public DateTime Fechaaprobacion { get; set; }
		public bool Aprobado { get; set; }
		public string Comentario { get; set; }
	}
}
