using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("persona")]
	public class Persona
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idpersona")]
		public  int Idpersona{ get; set; }
		public  string Codigo{ get; set; }
		public  string Apepaterno{ get; set; }
		public  string Apematerno{ get; set; }
		public  string Nombrespersona{ get; set; }
		public  string Razonsocial{ get; set; }
		public  int Idtipodocent{ get; set; }
		public  string Nrodocentidad{ get; set; }
		public  int  Iddistrito{ get; set; }
		public  string Direccionfiscal{ get; set; }
        public string Referencia { get; set; }
		public  string Telefono{ get; set; }
		public  string Movil{ get; set; }
		public  string Email{ get; set; }
		public  DateTime?  Fechanacimiento{ get; set; }
		public  string Comentario{ get; set; }
		public  string Sexo{ get; set; }
        public string Nombrecomercial { get; set; }
        public int Idpais { get; set; }
        public int? Idtipodocent2 { get; set; }
        public string Nrodocentidad2 { get; set; }
	}
}
