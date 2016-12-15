using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("finanzas")]
	[Alias("vwrecibocajaegresodet")]
	public class VwRecibocajaegresodet
	{
		[PrimaryKey]
		[Alias("idrecibocajaegresodet")]
		public int  Idrecibocajaegresodet { get; set; }
		public int  Idrecibocajaegreso { get; set; }
		public int  Numeroitem { get; set; }
		public string Serierecibo { get; set; }
		public string Numerorecibo { get; set; }
		public DateTime?  Fecharecibo { get; set; }
		public DateTime?  Fechapago { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Idtipodocmov { get; set; }
		public string Codigotipodocmov { get; set; }
		public string Nombretipodocmov { get; set; }
        public int? Idcpcompra { get; set; }
		public string Serietipocp { get; set; }
		public string Numerotipocp { get; set; }
		public decimal  Importepago { get; set; }
		public int  Idmediopago { get; set; }
		public string Codigomediopago { get; set; }
		public string Nombremediopago { get; set; }
		public string Numeromediopago { get; set; }
		public string Comentario { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
