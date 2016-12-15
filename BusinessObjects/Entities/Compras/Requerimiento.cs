using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("compras")]
    [Alias("requerimiento")]
    public class Requerimiento : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idrequerimiento")]
        public int Idrequerimiento { get; set; }
        public int? Idarea { get; set; }
        public int? Idproyecto { get; set; }
        public int? Idtipocp { get; set; }
        public string Seriereq { get; set; }
        public string Numeroreq { get; set; }
        public DateTime Fechareq { get; set; }
        public int? Idempleado { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idtipomoneda { get; set; }       
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Importetotal { get; set; }
        public int? Idimpuesto { get; set; }
        public decimal Totalimpuesto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }                        
        public decimal Totaldocumento { get; set; }
        public string Glosareq { get; set; }
        public int? Idcptooperacion { get; set; }
        public int Idsucursal { get; set; }
        public int Idestadoreq { get; set; }
        public DateTime? Fechaaprobacion { get; set; }
        public int? Idempleadoaprueba { get; set; }
        public string Observacionaprobacion { get; set; }
        public int Idtipolista { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public string Listadoordentrabajoref { get; set; }
        public string Numerordendetrabajo { get; set; }
        public DateTime? Fechaordentrabajo { get; set; }
        public int? Idalmacen { get; set; }
    }
}
