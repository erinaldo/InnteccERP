using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwcotizacionclientedet")]
	public class VwCotizacionclientedet : BusinessObject
	{
		[PrimaryKey]
		[Alias("idcotizacionclientedet")]
		public  int  Idcotizacionclientedet{ get; set; }
		public  int?  Idcotizacioncliente{ get; set; }
		public  string Seriecotizacion{ get; set; }
		public  int?  Numerocotizacion{ get; set; }
		public  int?  Numeronegociacion{ get; set; }
		public  DateTime?  Fechacotizacion{ get; set; }
		public  DateTime?  Fechavencimiento{ get; set; }
		public  int  Numeroitem{ get; set; }
		public  int  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int?  Idunidadinventario{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Codigoclasificacion{ get; set; }
		public  string Nombreclasificacion{ get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  bool?  Articulomodificado{ get; set; }
		public  int?  Diasdeentrega{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal  Cantidad{ get; set; }
		public  decimal  Preciounitario{ get; set; }
		public  decimal  Descuento1{ get; set; }
		public  decimal  Descuento2{ get; set; }
		public  decimal  Descuento3{ get; set; }
		public  decimal  Descuento4{ get; set; }
		public  decimal  Preciounitarioneto{ get; set; }
		public  decimal  Importetotal{ get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public string Codigotipoafectacionigv { get; set; }
        public string Nombretipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public int? Idcentrodecosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public int Idalmacen { get; set; }
        public string Codigoalmacen { get; set; }
        public string Nombrealmacen { get; set; }
        public bool Calcularitem { get; set; }
        public bool Bonificacion { get; set; }
	    public int? Idubicacion { get; set; }
	    public string Nombreubicacion { get; set; }
	    [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
        
	}
}
