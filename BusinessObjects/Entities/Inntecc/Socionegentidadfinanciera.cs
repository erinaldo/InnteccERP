using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegentidadfinanciera")]
	public class Socionegentidadfinanciera
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegentidadfinanciera")]
		public  int Idsocionegentidadfinanciera{ get; set; }
		public  int Idsocionegocio{ get; set; }
		public  int Identfinaciera{ get; set; }
		public  int Idtipomoneda{ get; set; }
		public  string Nrocuenta{ get; set; }
		public  string Nrocuentainterbancario { get; set; }
        public  bool Escuentadetraccion { get; set; }
	}
}
