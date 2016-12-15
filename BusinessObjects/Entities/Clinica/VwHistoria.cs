using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwhistoria")]
	public class VwHistoria
	{
		[PrimaryKey]
		[Alias("idhistoria")]
		public int?  Idhistoria { get; set; }
		public int?  Idsucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public string Seriehistoria { get; set; }
		public string Numerohistoria { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersonaempleado { get; set; }
		public string Nombrereempleado { get; set; }
		public int?  Idpacientetitular { get; set; }
		public int?  Idpersonaclientetitular { get; set; }
		public string Apepaternoclientetitular { get; set; }
		public string Apematernoclientetitular { get; set; }
		public string Nombrespersonaclientetitular { get; set; }
		public string Razonsocialclientetitular { get; set; }
		public int?  Idtipodocentclientetitular { get; set; }
		public string Nombretipodocentidadclientetitular { get; set; }
		public string Abreviaturadocentidadclientetitular { get; set; }
		public string Nrodocentidadclientetitular { get; set; }
		public int?  Idestadocivil { get; set; }
		public string Nombreestadocivil { get; set; }
		public int?  Idpersonaconyugue { get; set; }
		public string Apepaternoconyugue { get; set; }
		public string Apematernoconyugue { get; set; }
		public string Nombrespersonaconyugue { get; set; }
		public string Razonsocialconyugue { get; set; }
		public int?  Idtipodocentconyugue { get; set; }
		public string Nombretipodocentidadconyugue { get; set; }
		public string Abreviaturadocentidadconyugue { get; set; }
		public string Nrodocentidadconyugue { get; set; }
		public string Observacion { get; set; }
	}
}
