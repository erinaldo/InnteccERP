using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwordencompraimpresion")]
	public class VwOrdencompraimpresion
	{
		[PrimaryKey]
		[Alias("idordencompradet")]
		public  int?  Idordencompradet{ get; set; }
		public  int?  Idordencompra{ get; set; }
		public  int?  Numeroitem{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  string Codigoarticulo{ get; set; }
		public  string Codigoproveedor{ get; set; }
		public  string Codigodebarra{ get; set; }
		public  int?  Idunidadinventario{ get; set; }
		public  int?  Idarticuloclasificacion{ get; set; }
		public  string Codigoclasificacion{ get; set; }
		public  string Nombreclasificacion{ get; set; }
		public  int?  Idmarca{ get; set; }
		public  string Nombremarca{ get; set; }
	    public decimal Pesototalarticulo { get; set; }
	    public  string Nombrearticulo{ get; set; }
		public  decimal?  Cantidad{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  string Codigounidadmedida{ get; set; }
		public  string Nombreunidadmedida{ get; set; }
		public  string Abrunidadmedida{ get; set; }
		public  int?  Factorconversion{ get; set; }
		public  decimal?  Preciounitario{ get; set; }
		public  decimal?  Importebruto{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal?  Descuento1{ get; set; }
		public  decimal?  Descuento2{ get; set; }
		public  decimal?  Descuento3{ get; set; }
		public  decimal?  Descuento4{ get; set; }
		public  decimal?  Preciounitarioneto{ get; set; }
		public  decimal?  Importetotal{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal?  Porcentajeimpuesto{ get; set; }
		public  bool?  Exoneradoimpuesto{ get; set; }
		public  int?  Idcentrodecosto{ get; set; }
		public  string Codigocentrodecosto{ get; set; }
		public  string Descripcioncentrodecosto{ get; set; }
		public  decimal?  Porcentajepercepcionitem{ get; set; }
		public  int?  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int?  Idproyecto{ get; set; }
		public  string Nombreproyecto{ get; set; }
		public  int?  Idtipocp{ get; set; }
		public  string Codigotipocp{ get; set; }
		public  int?  Idtipoformato{ get; set; }
		public  int?  Maxnumeroitems{ get; set; }
		public  string Nombretipoformato{ get; set; }
		public  string Abreviaturatipoformato{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  string Codigocptooperacion{ get; set; }
		public  string Nombrecptooperacion{ get; set; }
		public  int?  Idtipodocmov{ get; set; }
		public  string Codigotipodocmov{ get; set; }
		public  string Nombretipodocmov{ get; set; }
		public  string Serieorden{ get; set; }
		public  string Numeroorden{ get; set; }
		public  DateTime?  Fechaordencompra{ get; set; }
		public  bool?  Anulado{ get; set; }
		public  DateTime?  Fechaanulado{ get; set; }
		public  int?  Idempleado{ get; set; }
		public  string Nombreresponsable{ get; set; }
		public  int?  Idproveedor{ get; set; }
		public  string Razonsocial{ get; set; }
		public  string Nombretipodocentidad{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
		public  string Nrodocentidadprincipal{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  int?  Idprioridad{ get; set; }
		public  string Nombreprioridad{ get; set; }
		public  string Codigoprioridad{ get; set; }
		public  decimal?  Tipocambio{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
		public  string Codigotipomoneda{ get; set; }
		public  string Nombretipomoneda{ get; set; }
		public  string Simbolomoneda{ get; set; }
		public  int?  Idtipocondicion{ get; set; }
		public  string Codigocondicion{ get; set; }
		public  string Nombrecondicion{ get; set; }
		public  int?  Diascondicion{ get; set; }
        public decimal? Totalexonerado{ get; set; }
		public  decimal?  Totalbruto{ get; set; }
		public  decimal?  Baseimponible{ get; set; }
		public  decimal?  Totalimpuesto{ get; set; }
		public  decimal?  Totalneto{ get; set; }
		public  decimal?  Porcentajepercepcion{ get; set; }
		public  decimal?  Totalpercepcion{ get; set; }
		public  decimal?  Totaldocumento{ get; set; }
		public  string Glosaordencompra{ get; set; }
		public  DateTime?  Fechaentrega{ get; set; }
		public  bool?  Aprobado{ get; set; }
		public  DateTime?  Fechaapobacion{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
        public int Idsucursalentrega { get; set; }
        public string Nombresucursalentrega { get; set; }
        public string Direccionsucursalentrega { get; set; }
        public int Iddistritosucursalentrega { get; set; }
        public string Dirubisucursalentrega { get; set; }
	    public int Idempresatransporte { get; set; }
	    public int Idpersonaemptransporte { get; set; }
	    public string Razonsocialemptransporte { get; set; }

	}
}
