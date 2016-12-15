using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwpersona")]
	public class VwPersona
	{
		[PrimaryKey]
		[Alias("idpersona")]
		public  int  Idpersona{ get; set; }
		public  string Apepaterno{ get; set; }
		public  string Codigo{ get; set; }
		public  string Apematerno{ get; set; }
		public  string Nombrespersona{ get; set; }
		public  string Razonsocial{ get; set; }
        public string Nombrecomercial { get; set; }
		public  int  Idtipodocent{ get; set; }
		public  string Codigotipodocentidad{ get; set; }
		public  string Nombretipodocentidad{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
		public  string Nrodocentidad{ get; set; }
		public  int  Iddistrito{ get; set; }
		public  string Nombredistrito{ get; set; }
		public  string Nombreprovincia{ get; set; }
		public  string Nombredepartamento{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  string Telefono{ get; set; }
		public  string Movil{ get; set; }
		public  string Emailcliente{ get; set; }
		public  DateTime?  Fechanacimiento{ get; set; }
		public  string Comentario{ get; set; }
        public int? Idtipodocent2 { get; set; }
        public string Nombretipodocentidad2 { get; set; }
        public string Abreviaturadocentidad2 { get; set; }
        public string Nrodocentidad2 { get; set; }
        public string Nombreubigeo { get; set; }
	    public int Idpais { get; set; }
	    public string Nombrepais { get; set; }
	    public string Referencia { get; set; }
	    public string Sexo { get; set; }
	}
}
