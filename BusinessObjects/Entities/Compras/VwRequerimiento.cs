using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwrequerimiento")]
	public class VwRequerimiento
	{
		[PrimaryKey]
		[Alias("idrequerimiento")]
		public  int  Idrequerimiento{ get; set; }
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
        public string Serienumeroreq { get; set; }
		public  DateTime?  Fechareq{ get; set; }
	    public DateTime? Fechaaprobacion { get; set; }
	    public  int?  Idempleado{ get; set; }
		public  int?  Idpersona{ get; set; }
		public  string Nombrepersonaempleado{ get; set; }
		public  string Nrodocentidadempleado{ get; set; }
		public  bool?  Anulado{ get; set; }
		public  DateTime?  Fechaanulado{ get; set; }
		public  decimal?  Tipocambio{ get; set; }
		public  int?  Idtipomoneda{ get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  string Abreviaturaigv{ get; set; }
		public  string Nombreimpuesto{ get; set; }
		public  decimal  Porcentajeimpuesto{ get; set; }
		public  decimal  Totalexonerado{ get; set; }
		public  decimal  Totalgravado{ get; set; }
		public  decimal  Totalimpuesto{ get; set; }
		public  decimal  Totaldocumento{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  string Codigocptooperacion{ get; set; }
		public  string Nombrecptooperacion{ get; set; }
        public bool Generasalida { get; set; }
        public bool Tieneordenservicio { get; set; }
        public bool Tieneordencompra { get; set; }
		public  int?  Idtipodocmov{ get; set; }
		public  string Codigotipodocmov{ get; set; }
		public  string Nombretipodocmov{ get; set; }
		public  string Glosareq { get; set; }
        public int Idestadoreq { get; set; }
        public string Nombreestadoreq { get; set; }
        public int Idempresa { get; set; }
        public int Idempleadoaprueba { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public string Listadoordentrabajoref { get; set; }
	    public string Numerordendetrabajo { get; set; }
	    public DateTime Fechaordentrabajo { get; set; }
	    public string Descripcionordentrabajo { get; set; }
	}
}
