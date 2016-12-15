using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("modeloautorizacioncondicion")]
	public class Modeloautorizacioncondicion
	{
		[PrimaryKey]
        [AutoIncrement]
		[Alias("idmodeloautorizacioncondicion")]
		public int Idmodeloautorizacioncondicion { get; set; }
        public int Idmodeloautorizacionetapa { get; set; }
		public int Idautorizaciontipocondicion { get; set; }
		public int Idtiporatio { get; set; }
		public decimal Valor1 { get; set; }
		public decimal Valor2 { get; set; }
	}
}
