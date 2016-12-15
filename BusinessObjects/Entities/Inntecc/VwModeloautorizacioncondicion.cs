using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwmodeloautorizacioncondicion")]
	public class VwModeloautorizacioncondicion
	{
		[PrimaryKey]
		[Alias("idmodeloautorizacioncondicion")]
		public int  Idmodeloautorizacioncondicion { get; set; }
        public int Idmodeloautorizacionetapa { get; set; }
		public int  Idautorizaciontipocondicion { get; set; }
		public string Nombreautorizaciontipocondicion { get; set; }
		public int  Idtiporatio { get; set; }
		public string Nombretiporatio { get; set; }
		public string Operador { get; set; }
		public decimal  Valor1 { get; set; }
		public decimal  Valor2 { get; set; }
	}
}
