using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcuadrocomparativomodeloautorizacion")]
	public class VwCuadrocomparativomodeloautorizacion
	{
		[PrimaryKey]
		[Alias("idcuadrocomparativo")]
		public  int?  Idcuadrocomparativo{ get; set; }
		public  string Numerocc{ get; set; }
		public  decimal?  Totaldocumento{ get; set; }
		public  decimal?  Valor1{ get; set; }
		public  decimal?  Valor2{ get; set; }
		public  int?  Ordenautorizacion{ get; set; }
		public  int?  Idempleado{ get; set; }
		public  string Nombreempleado{ get; set; }
		public  int?  Idtipodocmov{ get; set; }
		public  string Nombretipodocmov{ get; set; }
		public  int?  Idestadocuadrocomparativo{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
	}
}
