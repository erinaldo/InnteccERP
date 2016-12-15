using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwvalorizacionproveedordet")]
	public class VwValorizacionproveedordet
	{
		[PrimaryKey]
		[Alias("idvalorizacionproveedordet")]
		public int  Idvalorizacionproveedordet { get; set; }
		public int  Idvalorizacionproveedor { get; set; }
		public string Serievalorizacion { get; set; }
		public string Numerovalorizacion { get; set; }
		public DateTime  Fechavalorizacion { get; set; }
		public DateTime  Fechainicio { get; set; }
		public DateTime  Fechafinal { get; set; }
		public int  Numeroitem { get; set; }
		public DateTime  Fecha { get; set; }
		public string Turno { get; set; }
		public decimal  Horometroinicio { get; set; }
		public decimal  Horometrofinal { get; set; }
		public decimal  Horometrodia { get; set; }
		public decimal  Descuentohorometro { get; set; }
		public decimal  Horometrorealdia { get; set; }
		public decimal  Horometrominimo { get; set; }
		public decimal  Diastrabajo { get; set; }
		public int  Idcentrodecosto { get; set; }
		public string Codigocentrodecosto { get; set; }
		public string Descripcioncentrodecosto { get; set; }
		public string Observaciones { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
