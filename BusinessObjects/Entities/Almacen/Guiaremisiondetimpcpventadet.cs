using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("guiaremisiondetimpcpventadet")]
	public class Guiaremisiondetimpcpventadet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idguiaremisiondetimpcpventa")]
		public int Idguiaremisiondetimpcpventa { get; set; }
		public int Idguiaremisiondet { get; set; }
		public decimal Cantidadimportada { get; set; }
		public int Idcpventa { get; set; }
	}
}
