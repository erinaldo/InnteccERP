using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegociodireccion")]
	public class VwSocionegociodireccion
	{
		[PrimaryKey]
		[Alias("idsocionegociodireccion")]
		public  int  Idsocionegociodireccion{ get; set; }
		public  int?  Idsocionegocio{ get; set; }
		public  int  Iddistrito{ get; set; }
		public  string Codigodistrito{ get; set; }
		public  string Nombredistrito{ get; set; }
		public  int?  Idprovincia{ get; set; }
		public  string Codigoprovincia{ get; set; }
		public  string Nombreprovincia{ get; set; }
		public  int?  Iddepartamento{ get; set; }
		public  string Codigodepartamento{ get; set; }
		public  string Nombredepartamento{ get; set; }
		public  string Nombreubigeo{ get; set; }
		public  string Direccionsocionegocio{ get; set; }
		public  string Referencia{ get; set; }
		public  bool  Principal{ get; set; }
        public int? Idpais { get; set; }
        public string Nombrepais { get; set; }
        public string Tipolocal { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
