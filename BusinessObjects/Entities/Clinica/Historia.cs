using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historia")]
	public class Historia
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoria")]
		public int Idhistoria { get; set; }
		public int?  Idsucursal { get; set; }
		public int?  Idtipocp { get; set; }
		public string Seriehistoria { get; set; }
		public string Numerohistoria { get; set; }
		public DateTime Fecharegistro { get; set; }
		public int Idempleado { get; set; }
		public int Idpacientetitular { get; set; }
		public int Idestadocivil { get; set; }
		public int?  Idpersonaconyugue { get; set; }
		public string Observacion { get; set; }
	    public DateTime Fechanacimiento { get; set; }
	}
}
