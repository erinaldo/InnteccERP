using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("caja")]
	[Alias("vwcierrecajadet")]
	public class VwCierrecajadet
	{
		[PrimaryKey]
		[Alias("idcierrecajadet")]
		public int  Idcierrecajadet { get; set; }
		public int  Idcierrecaja { get; set; }
		public DateTime  Fecharegistro { get; set; }
		public DateTime  Fechacierre { get; set; }
		public int  Idmediopago { get; set; }
		public string Nombremediopago { get; set; }
        public int  Idcptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }        
		public decimal  Importe { get; set; }
	    [Ignore]
	    public DataEntityState DataEntityState { get; set; }
	}
}
