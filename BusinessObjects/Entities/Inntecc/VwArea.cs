using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwarea")]
	public class VwArea
	{
		[PrimaryKey]
		[Alias("idarea")]
		public  int?  Idarea{ get; set; }
		public  string Codigoarea{ get; set; }
		public  string Nombrearea{ get; set; }
		public  int?  Idempresa{ get; set; }
		public  string Nombreempresa{ get; set; }
		public  int?  Idareapadre{ get; set; }
		public  string Codigoareapadre{ get; set; }
		public  string Nombreareapadre{ get; set; }
        public string Nombreareaempresa { get; set; }
        
	}
}
