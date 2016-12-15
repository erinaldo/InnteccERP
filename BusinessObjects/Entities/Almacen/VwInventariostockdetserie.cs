using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("almacen")]
	[Alias("vwinventariostockdetserie")]
	public class VwInventariostockdetserie
	{
		[PrimaryKey]
		[Alias("idinventariostockdetserie")]
		public int  Idinventariostockdetserie { get; set; }
		public int  Idinventariostock { get; set; }
		public bool  Inventarioanulado { get; set; }
		public int  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
        public int Idseriearticulo { get; set; }
		public string Numeroserieitem { get; set; }
		public string Codigointernoitem { get; set; }
        public DateTime? Fecharegistro { get; set; }
        [Ignore]
	    public DataEntityState DataEntityState { get; set; }

	}
}
