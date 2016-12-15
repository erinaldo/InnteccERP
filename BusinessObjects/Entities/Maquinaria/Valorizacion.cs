using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("valorizacion")]
	public class Valorizacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idvalorizacion")]
		public int Idvalorizacion { get; set; }
		public int Idtipocp { get; set; }
		public string Serievalorizacion { get; set; }
		public string Numerovalorizacion { get; set; }
		public DateTime Fechavalorizacion { get; set; }
		public DateTime Fechainicio { get; set; }
		public DateTime Fechafinal { get; set; }
		public int Idsocionegocio { get; set; }
		public int Idproyecto { get; set; }
		public int Idequipo { get; set; }
		public int Idtipoalquiler { get; set; }
		public bool Esmaquinaseca { get; set; }
		public bool Esmaquinaconductor { get; set; }
		public decimal Importetarifa { get; set; }
		public decimal Horaminima { get; set; }
		public DateTime Fechaingreso { get; set; }
		public decimal Totalhorometro { get; set; }
		public decimal Totaldescuentohorometro { get; set; }
		public decimal Totalhorometroreal { get; set; }
		public decimal Totalhorometrominimo { get; set; }
		public decimal Totaldiastrabajo { get; set; }
		public decimal Totalvalorizado { get; set; }
		public decimal Totaldescuento { get; set; }
		public decimal Totalimpuesto { get; set; }
		public decimal Porcentajedetraccion { get; set; }
		public decimal Totaldetraccion { get; set; }
		public decimal Totaldocumento { get; set; }
		public int Idsucursal { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idtipomoneda { get; set; }
        public int? Idimpuesto { get; set; }
        public string Glosavalorizacion { get; set; }
        public int? Idempleado { get; set; }
        public int? Idordendeventadet { get; set; }
	    public int? Diames { get; set; }
	}
}
