using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegocioproyecto")]
	public class VwSocionegocioproyecto
	{
		[PrimaryKey]
		[Alias("idsocionegocioproyecto")]
		public int  Idsocionegocioproyecto { get; set; }
		public int?  Idsocionegocio { get; set; }
		public int  Idproyecto { get; set; }
		public string Codigoproyecto { get; set; }
		public string Nombreproyecto { get; set; }
		public bool?  Esactivo { get; set; }
		public int?  Idempresa { get; set; }
		public string Nombreempresa { get; set; }
        public bool Proyectopordefecto { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
