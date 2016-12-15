using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcotizacionprvdet")]
	public class VwCotizacionprvdet
	{
		[PrimaryKey]
		[Alias("idcotizacionprvdet")]
		public int?  Idcotizacionprvdet { get; set; }
		public int?  Idcotizacionprv { get; set; }
		public string Seriecotizacionprv { get; set; }
		public string Numerocotizacionprv { get; set; }
		public DateTime?  Fechaemision { get; set; }
		public int  Numeroitem { get; set; }
		public decimal?  Cantidad { get; set; }
		public int?  Idrequerimientodet { get; set; }
		public int?  Idrequerimiento { get; set; }
		public string Seriereq { get; set; }
		public string Numeroreq { get; set; }
		public string Serienumeroreq { get; set; }
		public DateTime?  Fechareq { get; set; }
		public int?  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigodebarra { get; set; }
		public int?  Idarticuloclasificacion { get; set; }
		public string Codigoclasificacion { get; set; }
		public string Nombreclasificacion { get; set; }
		public int?  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public string Nombrearticulo { get; set; }
		public int?  Idimpuesto { get; set; }
		public int?  Idunidadmedida { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Especificacion { get; set; }
        public bool Anulado { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
