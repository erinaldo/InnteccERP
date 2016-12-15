using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("maquinaria")]
    [Alias("vwvalorizaciondanioelemento")]
    public class VwValorizaciondanioelemento
    {
        [PrimaryKey]
        [Alias("idvalorizaciondanioelemento")]
        public int? Idvalorizaciondanioelemento { get; set; }
        public int? Idtipocp { get; set; }
        public int? Idtipoformato { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Codigocptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public string Seriede { get; set; }
        public string Numerode { get; set; }
        public string Serienumerode { get; set; }
        public bool? Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public int? Idvalorizacion { get; set; }
        public string Serievalorizacion { get; set; }
        public string Numerovalorizacion { get; set; }
        public DateTime? Fechavalorizacion { get; set; }
        public int? Idsocionegocio { get; set; }
        public int? Idpersonasocionegocio { get; set; }
        public string Nombresocionegocio { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int? Idresponsable { get; set; }
        public int? Idpersonaresponsable { get; set; }
        public string Nombreresponsable { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Idproyecto { get; set; }
        public string Codigoproyecto { get; set; }
        public string Nombreproyecto { get; set; }
        public int? Idequipo { get; set; }
        public string Codigoequipo { get; set; }
        public string Nombreequipo { get; set; }
        public int? Idcentrocosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public string Comentario { get; set; }
        public decimal? Totaldanio { get; set; }
        public decimal? Totalelemento { get; set; }
        public decimal? Totaldocumento { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public decimal? Totalvalorizacion { get; set; }
    }
}
