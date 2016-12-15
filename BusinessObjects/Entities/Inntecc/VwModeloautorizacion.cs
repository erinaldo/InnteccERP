using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwmodeloautorizacion")]
	public class VwModeloautorizacion
	{
		[PrimaryKey]
		[Alias("idmodeloautorizacion")]
		public int?  Idmodeloautorizacion { get; set; }
		public string Nombremodelo { get; set; }
		public bool?  Esactivo { get; set; }
		public bool?  Todoslosautores { get; set; }
		public int?  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
		public int?  Idempresa { get; set; }
		public string Razonsocialempresa { get; set; }
        public int Idcptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
	}
}
