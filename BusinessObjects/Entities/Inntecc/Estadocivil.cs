using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("estadocivil")]
	public class Estadocivil
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadocivil")]
		public int Idestadocivil { get; set; }
		public string Nombreestadocivil { get; set; }
	}
}
