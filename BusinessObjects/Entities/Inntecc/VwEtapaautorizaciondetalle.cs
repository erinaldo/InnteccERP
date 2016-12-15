using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwetapaautorizaciondetalle")]
	public class VwEtapaautorizaciondetalle
	{
		[PrimaryKey]
		[Alias("idetapaautorizaciondetalle")]
		public int  Idetapaautorizaciondetalle { get; set; }
		public int?  Idetapaautorizacion { get; set; }
		public string Nombreetapaautorizacion { get; set; }
		public int?  Cantautorizacionesreq { get; set; }
		public int?  Idempresa { get; set; }
		public string Nombreempresa { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersona { get; set; }
		public string Nrodocentidad { get; set; }
		public string Codigo { get; set; }
		public string Nombreempleado { get; set; }
		public int?  Idusuario { get; set; }
		public string Nombreusuario { get; set; }
		public int?  Idgrupousuario { get; set; }
        public int Ordenautorizacion { get; set; }
        public bool Requiereautorizacion { get; set; }
        
        
	}
}
