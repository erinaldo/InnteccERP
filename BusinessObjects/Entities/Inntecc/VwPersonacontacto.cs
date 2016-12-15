using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwpersonacontacto")]
	public class VwPersonacontacto
	{
		[PrimaryKey]
		[Alias("idpersonacontacto")]
		public  int  Idpersonacontacto{ get; set; }
		public  int  Idpersona{ get; set; }
		public  int  Idtipocontacto{ get; set; }
		public  string Nombretipocontacto{ get; set; }
		public  string Datocontacto{ get; set; }
        [Ignore]
	    public string Nombrepersona { get; set; }

	}
}
