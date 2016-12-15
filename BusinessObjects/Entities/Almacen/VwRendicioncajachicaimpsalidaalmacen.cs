using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwrendicioncajachicaimpsalidaalmacen")]
	public class VwRendicioncajachicaimpsalidaalmacen
	{
		[PrimaryKey]
		[Alias("idrendicioncajachicadet")]
		public int?  Idrendicioncajachicadet { get; set; }
		public int?  Idrendicioncajachica { get; set; }
		public int?  Idsucursalrendicioncajachica { get; set; }
		public string Serierendicioncaja { get; set; }
		public string Numerorendicioncaja { get; set; }
		public DateTime?  Fecharendicioncaja { get; set; }
		public int?  Idsocionegocio { get; set; }
		public string Razonsocial { get; set; }
		public string Codigotipodocentidad { get; set; }
		public string Nrodocentidadprincipal { get; set; }
		public string Direccionfiscal { get; set; }
		public int?  Numeroitemrendicioncajachicadet { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Maxnumeroitems { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal?  Importepago { get; set; }
		public DateTime?  Fechatipocp { get; set; }
		public string Descripciongasto { get; set; }
		public int?  Idcpcompradet { get; set; }
		public int?  Idcpcompra { get; set; }
		public string Seriecpcompra { get; set; }
		public string Numerocpcompra { get; set; }
		public string Serienumerocpcompra { get; set; }
        public bool Anulado { get; set; }
		public DateTime?  Fechaemision { get; set; }
		public int?  Idproveedor { get; set; }
		public int?  Idsucursal { get; set; }
		public int  Numeroitem { get; set; }
		public int?  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Codigodebarra { get; set; }
		public int?  Idunidadinventario { get; set; }
		public int?  Idarticuloclasificacion { get; set; }
		public string Codigoclasificacion { get; set; }
		public string Nombreclasificacion { get; set; }
		public int?  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public string Nombrearticulo { get; set; }
		public decimal  Cantidad { get; set; }
		public decimal  Cantidadimportada { get; set; }
		public decimal  Saldoaimportar { get; set; }
		public int  Idunidadmedida { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public int  Factorconversion { get; set; }
		public decimal  Preciounitario { get; set; }
		public string Especificacion { get; set; }
		public decimal  Descuento1 { get; set; }
		public decimal  Descuento2 { get; set; }
		public decimal  Descuento3 { get; set; }
		public decimal  Descuento4 { get; set; }
		public decimal  Preciounitarioneto { get; set; }
		public decimal  Importetotal { get; set; }
		public decimal  Pesounitario { get; set; }
		public decimal  Pesototal { get; set; }
		public decimal  Costounitario { get; set; }
		public int  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal  Porcentajeimpuesto { get; set; }
		public int  Idcentrodecosto { get; set; }
		public string Codigocentrodecosto { get; set; }
		public string Descripcioncentrodecosto { get; set; }
		public decimal  Porcentajepercepcion { get; set; }
		public int  Idarea { get; set; }
		public string Codigoarea { get; set; }
		public string Nombrearea { get; set; }
		public int?  Idproyecto { get; set; }
		public string Nombreproyecto { get; set; }
		public decimal  Descuentoproveedorcosto { get; set; }
		public int  Idtipoafectacionigv { get; set; }
		public string Codigotipoafectacionigv { get; set; }
		public string Nombretipoafectacionigv { get; set; }
		public bool  Gravado { get; set; }
		public bool  Exonerado { get; set; }
		public bool  Inafecto { get; set; }
		public bool  Exportacion { get; set; }
        public bool Calcularitem { get; set; }
		public int  Idempleado { get; set; }
		public string Nombreempleado { get; set; }
		public string Dniempleado { get; set; }
		public string Denominacionfuncion { get; set; }
		public string Nombreareaempleado { get; set; }
        public string Numerordendetrabajo { get; set; }
        public DateTime? Fechaordentrabajo { get; set; }
        public string Descripcionordentrabajo { get; set; }   
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
        [Ignore]
        public decimal Cantidadaimportar { get; set; }
	}
}
