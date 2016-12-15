using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("pais")]
	public class Pais
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idpais")]
        public int Idpais { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public short Prefijo { get; set; }
        public string Nombrepais { get; set; }
        public string Continente { get; set; }
        public string Subcontinente { get; set; }
        public string IsoMoneda { get; set; }
        public string NombreMoneda { get; set; }
		
	}
}
