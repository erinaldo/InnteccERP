using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegentidadfinanciera")]
	public class VwSocionegentidadfinanciera
	{
		[PrimaryKey]
		[Alias("idsocionegentidadfinanciera")]
		public int  Idsocionegentidadfinanciera { get; set; }
		public int?  Idsocionegocio { get; set; }
		public int  Identfinaciera { get; set; }
		public string Codentidadfinaciera { get; set; }
		public string Nombreentidadfinanciera { get; set; }
		public int  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public string Nrocuenta { get; set; }
		public string Nrocuentainterbancario { get; set; }
		public bool  Escuentadetraccion { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
