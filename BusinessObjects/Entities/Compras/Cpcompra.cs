using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("compras")]
    [Alias("cpcompra")]
    public class Cpcompra : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idcpcompra")]
        public int Idcpcompra { get; set; }
        public int Idtipocp { get; set; }
        public int? Idcptooperacion { get; set; }
        public int? Idsucursal { get; set; }
        public string Seriecpcompra { get; set; }
        public string Numerocpcompra { get; set; }
        public DateTime Fechaemision { get; set; }
        public DateTime? Fecharecepcion { get; set; }
        public int Idproveedor { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public int? Idempleado { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idtipocondicion { get; set; }
        public int? Idtipomoneda { get; set; }
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Totalimpuesto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public string Glosacpcompra { get; set; }
        public int? Idimpuesto { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Idperiodo { get; set; }
        public decimal Descuentounicosteo { get; set; }
        public decimal Otrosgastossoles { get; set; }
        public decimal Fletetmsoles { get; set; }
        public decimal Pesototalkg { get; set; }
        public int Idestadopago { get; set; }
        public string Numerordendetrabajo { get; set; }
        public DateTime? Fechaordentrabajo { get; set; }
        public string Descripcionordentrabajo { get; set; }
        public DateTime? Horatransaccion { get; set; }
    }
}
