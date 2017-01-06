using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("cpt")]
	public class Cpt
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcpt")]
		public int Idcpt { get; set; }
		public int?  Orden { get; set; }
		public int?  Codigogrupo { get; set; }
		public string Nombregrupo { get; set; }
		public string Codigoseccion { get; set; }
		public string Descripcionseccion { get; set; }
		public string Codigosubseccion { get; set; }
		public string Subdivisionanatomica { get; set; }
		public string Cptcode { get; set; }
		public string Nuevo { get; set; }
		public string Revisado { get; set; }
		public string Eliminado { get; set; }
		public string Cambiogramatical { get; set; }
		public string Referemciacruzada { get; set; }
		public string Denominacionprocedimiento { get; set; }
		public string Codigoperuano { get; set; }
		public string Denominacionprocedimientobusqueda { get; set; }
	}
}
