using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("vwreciboresumen")]
	public class VwReciboresumen
	{
		[PrimaryKey]
		[Alias("fecharecibo")]
		public DateTime?  Fecharecibo { get; set; }
		public int?  Idempleado { get; set; }
		public string Nombreempleado { get; set; }
		public string Nrodocentidadempleado { get; set; }
		public int  Idcptooperacion { get; set; }
		public string Nombrecptooperacion { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int  Idmediopago { get; set; }
		public string Nombremediopago { get; set; }
		public decimal  Subtotal { get; set; }
	}
}
