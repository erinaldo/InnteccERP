using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwdocumentoaprobacion")]
	public class VwDocumentoaprobacion
	{
		[PrimaryKey]
		[Alias("iddocumentoaprobacion")]
		public int?  Iddocumentoaprobacion { get; set; }
		public int?  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
		public int?  Iddocumentomov { get; set; }
		public int?  Empleadoaprueba { get; set; }
		public int?  Idpersona { get; set; }
		public int?  Idarea { get; set; }
		public string Denominacionfuncion { get; set; }
		public string Email { get; set; }
		public string Nombreempleado { get; set; }
		public string Nrodocentidad { get; set; }
		public int?  Idusuario { get; set; }
		public int?  Idgrupousuario { get; set; }
		public string Nombreusuario { get; set; }
		public string Descripcionusuario { get; set; }
		public bool?  Suspendido { get; set; }
		public DateTime?  Fechaaprobacion { get; set; }
		public bool?  Aprobado { get; set; }
		public string Comentario { get; set; }
	}
}
