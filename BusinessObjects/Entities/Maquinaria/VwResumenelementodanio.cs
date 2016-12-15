using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwresumenelementodanio")]
	public class VwResumenelementodanio
	{
		[PrimaryKey]
		[Alias("idvalorizacion")]
		public int  Idvalorizacion { get; set; }
		public int  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Nombrearticulo { get; set; }
		public int  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public int  Idunidadinventario { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public int  Idimpuesto { get; set; }
		public string Nombreimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public decimal  Porcentajeimpuesto { get; set; }
		public int  Idtipoafectacionigv { get; set; }
		public bool  Gravado { get; set; }
		public bool  Exonerado { get; set; }
		public bool  Inafecto { get; set; }
		public bool  Exportacion { get; set; }
		public decimal  Total { get; set; }
        public decimal Totalimportado { get; set; }
        public decimal Saldoaimportar { get; set; }
        public bool Anulado { get; set; }
        [Ignore]
        public decimal Montoaimportar { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
