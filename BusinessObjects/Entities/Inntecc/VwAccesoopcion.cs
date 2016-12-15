using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwaccesoopcion")]
	public class VwAccesoopcion
	{
		[PrimaryKey]
		[Alias("idusuario")]
		public  int Idusuario{ get; set; }
		public  int?  Idgrupousuario{ get; set; }
		public  string Nombreusuario{ get; set; }
		public  string Nombregrupo{ get; set; }
		public  string Titulopaginaitem{ get; set; }
		public  string Namepaginaitem{ get; set; }
		public  string Nameform{ get; set; }
		public  bool Permitir{ get; set; }
        public bool Activo { get; set; }
	}
}
