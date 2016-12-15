using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwempleado")]
	public class VwEmpleado
	{
		[PrimaryKey]
		[Alias("idempleado")]
		public  int  Idempleado{ get; set; }
		public  int?  Idpersona{ get; set; }
		public  string Codigo{ get; set; }
		public  string Razonsocial{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
		public  string Nrodocentidad{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  string Telefono{ get; set; }
		public  string Movil{ get; set; }
		public  int?  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  string Denominacionfuncion{ get; set; }
		public  DateTime?  Fechainicio{ get; set; }
		public  DateTime?  Fechacese{ get; set; }
		public  string Motivocese{ get; set; }
		public  string Comentario{ get; set; }
		public  string Nombrearchivofoto{ get; set; }
        public int Idempresa { get; set; }
	    public string Nombreempresa { get; set; }
        public int? Idtipocomisioncobro { get; set; }
        public int? Idtipocpventa { get; set; }
        public int? Idcptooperacionventa { get; set; }
        public int? Idtipocpreciboingreso { get; set; }
        public int? Idcptooperacionreciboingreso { get; set; }
	}
}
