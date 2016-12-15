using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwequipo")]
	public class VwEquipo
	{
		[PrimaryKey]
		[Alias("idequipo")]
		public int?  Idequipo { get; set; }
		public string Codigoequipo { get; set; }
		public string Nombreequipo { get; set; }
		public string Numeroserieequipo { get; set; }
		public string Placaequipo { get; set; }
		public string Colorequipo { get; set; }
		public int?  Anioequipo { get; set; }
		public string Capacidadequipo { get; set; }
		public int?  Idclasificacionequipo { get; set; }
		public string Nombreclasificacionequipo { get; set; }
		public int?  Idmodeloequipo { get; set; }
		public string Nombremodeloequipo { get; set; }
		public int?  Idmarcaequipo { get; set; }
		public string Nombremarcaequipo { get; set; }
		public string Marcamotor { get; set; }
		public string Modelomotor { get; set; }
		public string Potenciamotor { get; set; }
		public string Numeromotor { get; set; }
		public string Numeroseriemotor { get; set; }
		public string Observaciones { get; set; }
		public int?  Idcentrocosto { get; set; }
		public string Codigocentrodecosto { get; set; }
		public string Descripcioncentrodecosto { get; set; }
		public bool?  Esactivo { get; set; }
		public int?  Idsucursal { get; set; }
        public Decimal Horaminima { get; set; }
    }
}
