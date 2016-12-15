using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("vwcpcompradetserie")]
	public class VwCpcompradetserie
	{
		[PrimaryKey]
        [Alias("idcpcompradetserie")]
		public int  Idcpcompradetserie { get; set; }
		public int  Idcpcompradet { get; set; }
		public bool  Compraanulado { get; set; }
		public int Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
        public int Idseriearticulo { get; set; }
		public string Numeroserieitem { get; set; }
		public string Codigointernoitem { get; set; }
	    public DataEntityState DataEntityState { get; set; }
	}
}
