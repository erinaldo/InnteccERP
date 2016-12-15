using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrecibocajaegreso")]
	public class VwRecibocajaegreso
	{
		[PrimaryKey]
		[Alias("idrecibocajaegreso")]
		public int?  Idrecibocajaegreso { get; set; }
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
		public string Direccionsucursal { get; set; }
		public string Serierecibo { get; set; }
		public string Numerorecibo { get; set; }
		public DateTime?  Fecharecibo { get; set; }
		public DateTime?  Fechapago { get; set; }
		public int?  Idsocionegocio { get; set; }
		public string Razonsocial { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public string Ruc { get; set; }
		public bool  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idempleado { get; set; }
		public string Nombreresponsable { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public decimal?  Tipocambio { get; set; }
		public string Comentario { get; set; }
		public decimal?  Totaldocumento { get; set; }
        public int? Idresponsable { get; set; }
        public int? Idrendicioncajachica { get; set; }
        public string Rendicionterminada { get; set; }
	}
}
