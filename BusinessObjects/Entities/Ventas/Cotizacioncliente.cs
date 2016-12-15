using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("cotizacioncliente")]
    public class Cotizacioncliente : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idcotizacioncliente")]
        public int Idcotizacioncliente { get; set; }
        public int? Idtipocp { get; set; }
        public string Seriecotizacion { get; set; }
        public string Numerocotizacion { get; set; }
        public int Numeronegociacion { get; set; }
        public DateTime Fechacotizacion { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal Tipocambio { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public int Idcliente { get; set; }
        public int? Personacontacto { get; set; }
        public int Idtipolista { get; set; }
        public int? Idproyecto { get; set; }
        public int Idempleado { get; set; }
        public int Idtipomoneda { get; set; }
        public int Idtipocondicion { get; set; }
        public string Docrefcliente { get; set; }
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Pordescuentoadi { get; set; }
        public decimal Totaldescuentoadi { get; set; }
        public int Idimpuesto { get; set; }
        public decimal Totalimpuesto { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public string Glosacotizacion { get; set; }
        public int Iddireccionentrega { get; set; }
        public string Personadestinario { get; set; }
        public int Idsucursal { get; set; }
        public bool Aprobado { get; set; }
        public DateTime? Fechaaprobacion { get; set; }
        public int Idcptooperacion { get; set; }
        public int Idarea { get; set; }
        public int Iddireccionfacturacion { get; set; }
        public string Alcanzecondicion { get; set; }
        
    }
}
