using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("salidaalmacen")]
    public class Salidaalmacen : BusinessObject
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idsalidaalmacen")]
        public int Idsalidaalmacen { get; set; }
        public int? Idsucursal { get; set; }
        public int? Idalmacen { get; set; }
        public int? Idtipocp { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Seriesalidaalmacen { get; set; }
        public string Numerosalidaalmacen { get; set; }
        public int? Idempleado { get; set; }
        public int? Idsocionegocio { get; set; }
        public DateTime Fechasalida { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal Tipocambio { get; set; }
        public int? Idtipomoneda { get; set; }
        public int? Idimpuesto { get; set; }
        public string Glosa { get; set; }
        public int? Iddocumentosalida { get; set; }
        public string Serieguiaremision { get; set; }
        public string Numeroguiaremision { get; set; }
        public int? Iddocproveedor { get; set; }
        public string Seriedocproveedor { get; set; }
        public string Numerodocproveedor { get; set; }
        public int? Idestadoreclamo { get; set; }
        public decimal Totalbruto { get; set; }
        public decimal Totalgravado { get; set; }
        public decimal Totalinafecto { get; set; }
        public decimal Totalexonerado { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public decimal Importetotalpercepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public decimal Totalimpuesto { get; set; }
        public int Idtipodocmov { get; set; }
        public int? Idguiaremision { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public int? Idrendicioncajachica { get; set; }
        public DateTime Horatransaccion { get; set; }
        public int? Idcpventa { get; set; }
    }
}
