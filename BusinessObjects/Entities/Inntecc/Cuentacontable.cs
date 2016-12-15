using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("cuentacontable")]
	public class Cuentacontable
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcuentacontable")]
		public  int Idcuentacontable{ get; set; }
		public  string Codigocuenta{ get; set; }
		public  string Nombrecuenta{ get; set; }
	}
}
