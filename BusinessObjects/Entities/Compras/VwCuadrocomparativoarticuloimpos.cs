using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcuadrocomparativoarticuloimpos")]
	public class VwCuadrocomparativoarticuloimpos
	{
		[PrimaryKey]
		[Alias("idcuadrocomparativoarticulo")]
		public int?  Idcuadrocomparativoarticulo { get; set; }
		public int?  Idcuadrocomparativoprv { get; set; }
		public bool?  Anuladocc { get; set; }
		public int?  Idcotizacionprv { get; set; }
		public int?  Idcotizacionprvdet { get; set; }
		public int?  Idrequerimientodet { get; set; }
		public int?  Idrequerimiento { get; set; }
		public string Serienumeroreq { get; set; }
		public int?  Numeroitem { get; set; }
		public int?  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Nombrearticulo { get; set; }
		public string Especificacion { get; set; }
		public decimal?  Pesoarticulo { get; set; }
		public int?  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public int?  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal?  Porcentajeimpuesto { get; set; }
		public int?  Idtipoafectacionigv { get; set; }
		public string Codigotipoafectacionigv { get; set; }
		public string Nombretipoafectacionigv { get; set; }
		public bool?  Gravado { get; set; }
		public bool?  Exonerado { get; set; }
		public bool?  Inafecto { get; set; }
		public bool?  Exportacion { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public int?  Factorconversion { get; set; }
		public int?  Idunidadmedida { get; set; }
		public decimal?  Preciounitario { get; set; }
		public decimal?  Cantidad { get; set; }
		public decimal?  Cantidadimportada { get; set; }
		public decimal?  Saldoaimportar { get; set; }
		public decimal?  Descuento1 { get; set; }
		public decimal?  Descuento2 { get; set; }
		public decimal?  Descuento3 { get; set; }
		public decimal?  Descuento4 { get; set; }
		public decimal?  Porcentajepercepcion { get; set; }
		public decimal?  Preciounitarioneto { get; set; }
		public decimal?  Importetotal { get; set; }
		public int?  Diasdeentrega { get; set; }
		public string Justificacion { get; set; }
		public bool?  Buenapro { get; set; }
		public int?  Idcuadrocomparativo { get; set; }
		public int?  Idproyecto { get; set; }
		public string Codigoproyecto { get; set; }
		public string Nombreproyecto { get; set; }
		public int?  Idcentrodecosto { get; set; }
		public string Codigocentrodecosto { get; set; }
		public string Descripcioncentrodecosto { get; set; }
		public int?  Idarea { get; set; }
		public string Codigoarea { get; set; }
		public string Nombrearea { get; set; }
		public int?  Idcptooperacion { get; set; }
		public string Codigocptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
	}
}
