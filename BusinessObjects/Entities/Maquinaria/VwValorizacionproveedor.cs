using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("vwvalorizacionproveedor")]
	public class VwValorizacionproveedor
	{
		[PrimaryKey]
		[Alias("idvalorizacionproveedor")]
		public int?  Idvalorizacionproveedor { get; set; }
		public int?  Idtipocp { get; set; }
		public string Codigotipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public int?  Maxnumeroitems { get; set; }
		public string Serievalorizacion { get; set; }
		public string Numerovalorizacion { get; set; }
		public DateTime?  Fechavalorizacion { get; set; }
		public DateTime?  Fechainicio { get; set; }
		public DateTime?  Fechafinal { get; set; }
		public int?  Idsocionegocio { get; set; }
		public string Razonsocial { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public string Nrodocentidadprincipal { get; set; }
		public string Direccionfiscal { get; set; }
		public int?  Idproyecto { get; set; }
		public string Codigoproyecto { get; set; }
		public string Nombreproyecto { get; set; }
		public int?  Idequipo { get; set; }
		public string Codigoequipo { get; set; }
		public string Nombreequipo { get; set; }
		public string Numeroserieequipo { get; set; }
		public string Placaequipo { get; set; }
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
		public int?  Idtipoalquiler { get; set; }
		public string Nombretipoalquiler { get; set; }
		public bool?  Esmaquinaseca { get; set; }
		public bool?  Esmaquinaconductor { get; set; }
		public decimal?  Importetarifa { get; set; }
		public decimal?  Horaminima { get; set; }
		public DateTime?  Fechaingreso { get; set; }
		public decimal?  Totalhorometro { get; set; }
		public decimal?  Totaldescuentohorometro { get; set; }
		public decimal?  Totalhorometroreal { get; set; }
		public decimal?  Totalhorometrominimo { get; set; }
		public decimal?  Totaldiastrabajo { get; set; }
		public decimal?  Totalvalorizado { get; set; }
		public decimal?  Totaldescuento { get; set; }
		public decimal?  Totalimpuesto { get; set; }
		public decimal?  Porcentajedetraccion { get; set; }
		public decimal?  Totaldetraccion { get; set; }
		public decimal?  Totaldocumento { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public bool?  Anulado { get; set; }
		public DateTime?  Fechaanulado { get; set; }
		public decimal?  Tipocambio { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public int?  Idordenserviciodet { get; set; }
		public int?  Idordenservicio { get; set; }
	}
}
