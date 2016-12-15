using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("cuadrocomparativoprv")]
	public class Cuadrocomparativoprv
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idcuadrocomparativoprv")]
		public int Idcuadrocomparativoprv { get; set; }
		public int Idcuadrocomparativo { get; set; }
		public int Idsocionegocio { get; set; }
		public bool Incluyeimpuestoitems { get; set; }
		public string Formadepago { get; set; }
		public int Diasvalidez { get; set; }
		public DateTime Fechacotizacionrecepcion { get; set; }
	    public decimal Totaldocumento { get; set; }
	}
}
