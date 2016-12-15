using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("ventas")]
	[Alias("vwcpventadetserie")]
	public class VwCpventadetserie
	{
		[PrimaryKey]
		[Alias("idcpventadetserie")]
		public int  Idcpventadetserie { get; set; }
		public int  Idcpventadet { get; set; }
		public bool? Ventaanulado { get; set; }
		public int  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
        public int Idseriearticulo { get; set; }
		public string Numeroserieitem { get; set; }
		public string Codigointernoitem { get; set; }
	    public DataEntityState DataEntityState { get; set; }
	    public bool Serieutilizada { get; set; }
	}
}
