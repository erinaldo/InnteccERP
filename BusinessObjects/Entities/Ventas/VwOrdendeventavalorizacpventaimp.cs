using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwordendeventavalorizacpventaimp")]
	public class VwOrdendeventavalorizacpventaimp
	{
		[PrimaryKey]
        [Alias("Idvalorizacion")]

        public int Idvalorizacion { get; set; }
		public  int?  Idordendeventadet{ get; set; }
		public  int?  Idordendeventa{ get; set; }
       
		public  string Serievalorizacion{ get; set; }
		public  string Numerovalorizacion{ get; set; }
		public  string Serienumerovalorizacion{ get; set; }
		public  DateTime?  Fechavalorizacion{ get; set; }
		public  bool?  Anulado{ get; set; }
		public  int?  Numeroitem{ get; set; }
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
		public  decimal?  Pesoarticulo{ get; set; }
		public  decimal?  Cantidad{ get; set; }
		public  decimal?  Cantidadimportada{ get; set; }
		public  decimal  Saldoaimportar{ get; set; }
		public  int  Idunidadmedida{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  decimal  Preciounitario{ get; set; }
		public  decimal?  Importebruto{ get; set; }
		public  bool  Gravado{ get; set; }
		public  bool  Exonerado{ get; set; }
		public  bool  Inafecto{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal  Descuento1{ get; set; }
		public  decimal  Descuento2{ get; set; }
		public  decimal  Descuento3{ get; set; }
		public  decimal  Descuento4{ get; set; }
		public  decimal  Preciounitarioneto{ get; set; }
		public  decimal  Importetotal{ get; set; }
		public  int  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  bool?  Exoneradoimpuesto{ get; set; }
		public  int  Idcentrodecosto{ get; set; }
		public  string Codigocentrodecosto{ get; set; }
		public  string Descripcioncentrodecosto{ get; set; }
		public  decimal  Porcentajepercepcion{ get; set; }
		public  int  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int  Idproyecto{ get; set; }
		public  string Nombreproyecto{ get; set; }
		public  int?  Idcotizacionclientedet{ get; set; }
		public  string Serienumerocotizacion{ get; set; }
		public  int  Idalmacen{ get; set; }
		public  int  Idtipoafectacionigv{ get; set; }
		public  string Serienumeroordenventa{ get; set; }
        [Ignore]
        public decimal Cantidadaimportar { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
