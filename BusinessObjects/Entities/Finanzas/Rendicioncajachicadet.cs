using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("rendicioncajachicadet")]
	public class Rendicioncajachicadet
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrendicioncajachicadet")]
		public int Idrendicioncajachicadet { get; set; }
		public int Idrendicioncajachica { get; set; }
		public int Idsocionegocio { get; set; }
		public int Numeroitem { get; set; }
		public int Idtipocp { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal Importepago { get; set; }
		public DateTime Fechatipocp { get; set; }	
		public string Descripciongasto { get; set; }
        public int? Idcpcompra { get; set; }
	}
}
