using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegociodireccion")]
	public class Socionegociodireccion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegociodireccion")]
		public int Idsocionegociodireccion{ get; set; }
		public int Idsocionegocio{ get; set; }
		public int Iddistrito{ get; set; }
		public string Direccionsocionegocio{ get; set; }
		public string Referencia{ get; set; }
        public bool Principal { get; set; }
        public int? Idpais { get; set; }
	    public string Tipolocal { get; set; }
	}
}
