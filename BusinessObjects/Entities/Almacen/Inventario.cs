using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("inventario")]
	public class Inventario
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idinventario")]
		public  int Idinventario{ get; set; }
		public  int?  Idsucursal{ get; set; }
		public  int?  Idalmacen{ get; set; }
		public  int?  Idtipocp{ get; set; }
		public  int?  Idcptooperacion{ get; set; }
		public  int?  Idresponsable{ get; set; }
		public  string Numeroinventario{ get; set; }
		public  DateTime Fechainventario{ get; set; }
		public  bool Anulado{ get; set; }
		public  DateTime? Fechaanulado{ get; set; }
		public  bool Cierreinventario{ get; set; }
		public  string Serieinventario{ get; set; }
        public DateTime Horatransaccion { get; set; }

        public int? Idinventarioinicial { get; set; }
	}
}
