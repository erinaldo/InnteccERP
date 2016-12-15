using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("maquinaria")]
    [Alias("vwmantenimiento")]
    public class VwMantenimiento
    {
        [PrimaryKey]
        [Alias("idmantenimiento")]
        public int? Idmantenimiento { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int? Idtipocp { get; set; }
        public string Codigotipocp { get; set; }
        public int? Idtipoformato { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Codigocptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public string Seriemantenimiento { get; set; }
        public string Numeromantenimiento { get; set; }
        public string Serienumeromantenimiento { get; set; }
        public DateTime? Fechamantenimiento { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Idregistrador { get; set; }
        public string Nombreregistrador { get; set; }
        public string Trabajorealizado { get; set; }
        public bool? Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public int? Idequipo { get; set; }
        public string Codigoequipo { get; set; }
        public string Nombreequipo { get; set; }
        public string Numeroserieequipo { get; set; }
        public string Placaequipo { get; set; }
        public string Colorequipo { get; set; }
        public int? Anioequipo { get; set; }
        public string Capacidadequipo { get; set; }
        public int? Idclasificacionequipo { get; set; }
        public int? Idmodeloequipo { get; set; }
        public string Marcamotor { get; set; }
        public string Modelomotor { get; set; }
        public string Potenciamotor { get; set; }
        public string Numeromotor { get; set; }
        public string Numeroseriemotor { get; set; }
        public string Observaciones { get; set; }
        public int? Idcentrocosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public DateTime? Vigenciaseguro { get; set; }
        public string Codigodebarra { get; set; }
        public DateTime? Vencimientoitv { get; set; }
        public decimal? Horaminima { get; set; }
    }
}
