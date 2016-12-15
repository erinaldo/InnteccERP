using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
    [Alias("entradaalmacendetitemcpcompradet")]
	public class Entradaalmacendetitemcpcompradet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("identradaalmacendetitemcpcompradet")]
		public int Identradaalmacendetitemcpcompradet { get; set; }
		public int?  Identradaalmacendet { get; set; }
		public decimal?  Cantidadimportada { get; set; }
		public int?  Idcpcompra { get; set; }
	}
}
