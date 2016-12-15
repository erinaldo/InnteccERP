using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("finanzas")]
    [Alias("vwctacteproveedor")]
    public class VwCtacteproveedor
    {
        public int? Idcpcompra { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int Idtipodocmov { get; set; }
        public int Idtipocp { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public string Serietipocp { get; set; }
        public string Numerotipocp { get; set; }
        public int? Idsocionegocio { get; set; }
        public string Nroruc { get; set; }
        public string Razonsocial { get; set; }
        public DateTime? Fechadocumento { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public decimal? Totaldocumento { get; set; }
        public decimal Totalnotacredito { get; set; }
        public decimal Totalnotadebito { get; set; }
        public decimal? Totalpagado { get; set; }
        public decimal Totalsaldo { get; set; }
        [Ignore]
        public decimal Saldoaimportar { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
    }
}
