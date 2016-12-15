using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("centrodecosto")]
	public class Centrodecosto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcentrodecosto")]
		public  int Idcentrodecosto{ get; set; }
		public  string Codigocentrodecosto{ get; set; }
		public  string Descripcioncentrodecosto{ get; set; }
		public  bool Esactivo{ get; set; }
	    public int Idempresa { get; set; }
        public bool Escentrodecosto { get; set; }
        public bool Escentrodebeneficio { get; set; }
	}
}
