using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwrequerimientodetcotizaprvimp")]
	public class VwRequerimientodetcotizaprvimp
	{
		[PrimaryKey]
		[Alias("idrequerimientodet")]
		public  int  Idrequerimientodet{ get; set; }
		public  int?  Idrequerimiento{ get; set; }
		public  int?  Numeroitem{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Nombrearticulo{ get; set; }
		public  decimal?  Pesoarticulo{ get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  bool?  Exoneradoimpuesto{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal  Cantidad{ get; set; }
		public  decimal  Cantidadimportada{ get; set; }
		public  decimal  Saldoaimportar{ get; set; }
		public  decimal?  Preciounitario{ get; set; }
		public  decimal?  Importetotal{ get; set; }
		public  int?  Idcentrodecosto{ get; set; }
		public  string Codigocentrodecosto{ get; set; }
		public  string Descripcioncentrodecosto{ get; set; }
		public  int?  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  int?  Idproyecto{ get; set; }
		public  string Codigoproyecto{ get; set; }
		public  string Nombreproyecto{ get; set; }
		public  int?  Idtipocp{ get; set; }
		public  int?  Idtipoformato{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  string Codigotipocp{ get; set; }
		public  int?  Maxnumeroitems{ get; set; }
		public  string Seriereq{ get; set; }
		public  string Numeroreq{ get; set; }
		public  string Serienumeroreq{ get; set; }
		public  DateTime?  Fechareq{ get; set; }
		public  int?  Idempleado{ get; set; }
		public  int?  Idpersona{ get; set; }
		public  string Nombrepersonaempleado{ get; set; }
		public  string Nrodocentidadempleado{ get; set; }
		public  bool?  Anulado{ get; set; }
		public  DateTime?  Fechaanulado{ get; set; }
		public  decimal?  Tipocambio{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
		public  int?  Idimpuestoreq{ get; set; }
		public  string Abreviaturaigvreq{ get; set; }
		public  string Nombreimpuestoreq{ get; set; }
		public  decimal?  Porcentajeimpuestoreq{ get; set; }
		public  decimal?  Totalexonerado{ get; set; }
		public  decimal?  Baseimponible{ get; set; }
		public  decimal?  Totalimpuesto{ get; set; }
		public  decimal?  Totaldocumento{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  string Codigocptooperacion{ get; set; }
		public  string Nombrecptooperacion{ get; set; }
		public  int?  Idtipodocmov{ get; set; }
		public  string Codigotipodocmov{ get; set; }
		public  string Nombretipodocmov{ get; set; }
		public  string Glosareq{ get; set; }
        [Ignore]
        public decimal Cantidadaimportar { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
