using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("equipo")]
	public class Equipo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idequipo")]
		public int Idequipo { get; set; }
        [Required]
        [StringLength(5)]
		public string Codigoequipo { get; set; }
		public string Nombreequipo { get; set; }
		public string Numeroserieequipo { get; set; }
		public string Placaequipo { get; set; }
		public string Colorequipo { get; set; }
		public int Anioequipo { get; set; }
		public string Capacidadequipo { get; set; }
		public int?  Idclasificacionequipo { get; set; }
		public int?  Idmodeloequipo { get; set; }
		public string Marcamotor { get; set; }
		public string Modelomotor { get; set; }
		public string Potenciamotor { get; set; }
		public string Numeromotor { get; set; }
		public string Numeroseriemotor { get; set; }
		public string Observaciones { get; set; }
		public int Idcentrocosto { get; set; }
		public DateTime?  Vigenciaseguro { get; set; }
        public string Codigodebarra { get; set; }
        public DateTime? Vencimientoitv { get; set; }
        public Decimal Horaminima { get; set; }
	    public bool Alquilado { get; set; }
	}
}
