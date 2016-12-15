using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("categoriasocionegocio")]
	public class Categoriasocionegocio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcategoriasocionegocio")]
		public int Idcategoriasocionegocio { get; set; }
        public string Nombrecategoriasocionegoio { get; set; }
	}
}
