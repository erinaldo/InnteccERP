using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("vwdetraccioncliente")]
    public class VwDetraccioncliente
    {
        [PrimaryKey]
        [Alias("iddetraccioncliente")]
        public int? Iddetraccioncliente { get; set; }
        public int? Idsucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int? Idtipocp { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public string Serienumerodetraccion { get; set; }
        public string Numerodetraccion { get; set; }
        public DateTime? Fechapago { get; set; }
        public int? Idresponsable { get; set; }
        public string Nombreresponsable { get; set; }
        public int? Idcpventa { get; set; }
        public string Serienumerocpventa { get; set; }
        public int? Idcliente { get; set; }
        public string Nombrecliente { get; set; }
        public string Nrodocentidadcliente { get; set; }
        public DateTime? Fechaemision { get; set; }
        public decimal? Tipocambio { get; set; }
        public decimal? Totaldocumento { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public decimal? Porcentajedetraccion { get; set; }
        public decimal? Importedeposito { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public string Observacion { get; set; }
    }
}
