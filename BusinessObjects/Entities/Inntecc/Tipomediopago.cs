using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipomediopago")]
	public class Tipomediopago
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmediopago")]
		public  int Idmediopago{ get; set; }
        [Required]
        [StringLength(3)]
		public  string Codigomediopago{ get; set; }
		public  string Nombremediopago{ get; set; }
		public  bool Essunat{ get; set; }
	    public int Orden { get; set; }
	}
}
