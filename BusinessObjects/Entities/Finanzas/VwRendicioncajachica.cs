using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrendicioncajachica")]
	public class VwRendicioncajachica
	{
		[PrimaryKey]
		[Alias("idrendicioncajachica")]
		public int?  Idrendicioncajachica { get; set; }
		public int?  Idrecibocaja { get; set; }
		public string Serierecibo { get; set; }
		public string Numerorecibo { get; set; }
		public string Serienumerorecibo { get; set; }
		public DateTime?  Fecharecibo { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Maxnumeroitems { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public string Serierendicioncaja { get; set; }
		public string Numerorendicioncaja { get; set; }
		public DateTime?  Fecharendicioncaja { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersona { get; set; }
		public string Nombreempleado { get; set; }
		public string Nrodocentidad { get; set; }
        public bool Rendicionterminada { get; set; }
        public decimal Totaldocumento { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Codigotipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
	}
}
