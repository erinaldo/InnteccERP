using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegocio")]
	public class VwSocionegocio
	{
		[PrimaryKey]
		[Alias("idsocionegocio")]
		public  int  Idsocionegocio{ get; set; }
		public  int?  Idpersona{ get; set; }
		public  string Apepaterno{ get; set; }
		public  string Apematerno{ get; set; }
		public  string Nombrespersona{ get; set; }
		public  string Razonsocial{ get; set; }
        public string Nombrecomercial { get; set; }
		public  int?  Idtipodocent{ get; set; }
		public  string Codigotipodocentidad{ get; set; }
		public  string Nombretipodocentidad{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
        public string Nrodocentidadprincipal { get; set; }
		public  int?  Iddistrito{ get; set; }
		public  string Nombreubigeo{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  string Telefono{ get; set; }
		public  string Movil{ get; set; }
		public  string Email{ get; set; }
		public  DateTime?  Fechanacimiento{ get; set; }
		public  string Sexo{ get; set; }
		public  int?  Idtiposocio{ get; set; }
		public  string Nombretiposocio{ get; set; }
		public  string Codigosocio{ get; set; }
		public  DateTime?  Fecharegistro{ get; set; }
		public  string Nrodocentidad{ get; set; }
		public  int?  Idtipocondicion{ get; set; }
		public  string Codigocondicion{ get; set; }
		public  string Nombrecondicion{ get; set; }
		public  int?  Diascondicion{ get; set; }
		public  int?  Idtipolista{ get; set; }
		public  string Codigotipolista{ get; set; }
		public  string Nombretipolista{ get; set; }
		public  decimal?  Procentajedescuento{ get; set; }
		public  bool?  Esagenteretenedor{ get; set; }
		public  bool?  Esactivo{ get; set; }
		public  decimal?  Pordescuentototal{ get; set; }
		public  string Comentario{ get; set; }
		public  bool?  Incluyeigvitems{ get; set; }
        public int Idestadosocionegocio { get; set; }
        public string Nombreestadosocionegocio { get; set; }
	    public int? Idempresa { get; set; }
	    public string Nombreempresa { get; set; }


	}
}
