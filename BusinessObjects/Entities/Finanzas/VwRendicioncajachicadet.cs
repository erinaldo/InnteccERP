using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrendicioncajachicadet")]
	public class VwRendicioncajachicadet
	{
		[PrimaryKey]
		[Alias("idrendicioncajachicadet")]
		public int  Idrendicioncajachicadet { get; set; }
		public int  Idrendicioncajachica { get; set; }
		public int  Idsucursal { get; set; }
		public string Serierendicioncaja { get; set; }
		public string Numerorendicioncaja { get; set; }
		public DateTime?  Fecharendicioncaja { get; set; }
		public int  Idsocionegocio { get; set; }
		public string Razonsocial { get; set; }
		public string Codigotipodocentidad { get; set; }
		public string Nrodocentidadprincipal { get; set; }
		public string Direccionfiscal { get; set; }
		public int  Numeroitem { get; set; }
		public int  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int  Maxnumeroitems { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal  Importepago { get; set; }
		public DateTime  Fechatipocp { get; set; }	
		public string Descripciongasto { get; set; }
        public string Numerordendetrabajo { get; set; }
        public DateTime? Fechaordentrabajo { get; set; }
        public string Descripcionordentrabajo { get; set; }
        public int? Idcpcompra { get; set; } 
        
	}
}
