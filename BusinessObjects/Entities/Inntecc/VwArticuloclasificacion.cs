using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwarticuloclasificacion")]
	public class VwArticuloclasificacion
	{
		[PrimaryKey]
		[Alias("idarticuloclasificacion")]
		public int?  Idarticuloclasificacion { get; set; }
		public string Codigoclasificacion { get; set; }
		public string Nombreclasificacion { get; set; }
		public string Codigoclasificacionpadre { get; set; }
		public string Nombreclasificacionpadre { get; set; }
        public string Nombreclasificaciondetalle { get; set; }
	}
}
