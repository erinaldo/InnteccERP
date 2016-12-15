using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("entradaalmacen")]
    public class Entradaalmacen : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("identradaalmacen")]
        public int Identradaalmacen { get; set; }
        public int? Idsucursal { get; set; }
        public int? Idalmacen { get; set; }
        public int? Idtipocp { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Serieentradaalmacen { get; set; }
        public string Numeroentradaalmacen { get; set; }
        public int? Idempleado { get; set; }
        public int? Idsocionegocio { get; set; }
        public DateTime Fechaentrada { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idtipomoneda { get; set; }
        public int? Idimpuesto { get; set; }
        public string Glosa { get; set; }
        public int? Iddocumentocompra { get; set; }
        public string Seriecpcompra { get; set; }
        public string Numerocpcompra { get; set; }
        public int Iddocumentoingreso { get; set; }
        public string Serieguiaremision { get; set; }
        public string Numeroguiaremision { get; set; }
        public DateTime? Fechaverificacion { get; set; }
        public int? Idresponsableverifica { get; set; }
        public int? Idalmacendestino { get; set; }
        public string Listadodocreferencia { get; set; }
        public int? Idtipodocmov { get; set; }
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public decimal Totalimpuesto { get; set; }
        public int? Idordencompra { get; set; }
        public int? Idsalidaalmacen { get; set; }
        public int? Idcpcompra { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public int? Idnotacreditocli { get; set; }
        public DateTime Horatransaccion { get; set; }
    }
}
