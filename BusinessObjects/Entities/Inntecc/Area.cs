using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("area")]
	public class Area
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idarea")]
		public  int Idarea{ get; set; }
		public  int?  Idempresa{ get; set; }
	    [Required]
        [StringLength(2)]
	    public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int?  Idareapadre{ get; set; }
	}
}
