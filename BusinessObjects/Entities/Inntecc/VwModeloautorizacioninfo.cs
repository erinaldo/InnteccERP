using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwmodeloautorizacioninfo")]
	public class VwModeloautorizacioninfo
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
		public int?  Idetapaautorizacion { get; set; }
		public string Nombreetapaautorizacion { get; set; }
		public int?  Cantautorizacionesreq { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersonaempleado { get; set; }
		public string Nombreempleado { get; set; }
		public int?  Ordenautorizacion { get; set; }
		public int?  Idmodeloautorizacionetapa { get; set; }
		public int?  Idautorizaciontipocondicion { get; set; }
		public string Nombreautorizaciontipocondicion { get; set; }
		public int?  Idtiporatio { get; set; }
		public string Nombretiporatio { get; set; }
		public string Operador { get; set; }
		public decimal?  Valor1 { get; set; }
		public decimal?  Valor2 { get; set; }
	}
}
