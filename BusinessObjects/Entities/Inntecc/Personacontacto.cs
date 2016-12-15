using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("personacontacto")]
	public class Personacontacto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idpersonacontacto")]
		public  int Idpersonacontacto{ get; set; }
		public  int  Idpersona{ get; set; }
		public  int Idtipocontacto{ get; set; }
		public  string Datocontacto{ get; set; }
	}
}
