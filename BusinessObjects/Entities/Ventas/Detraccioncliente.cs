using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("detraccioncliente")]
    public class Detraccioncliente
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("iddetraccioncliente")]
        public int Iddetraccioncliente { get; set; }
        public int Idsucursal { get; set; }
        public int Idtipocp { get; set; }
        public int Idcptooperacion { get; set; }
        public string Seriedetraccion { get; set; }
        public string Numerodetraccion { get; set; }
        public DateTime Fechapago { get; set; }
        public int Idresponsable { get; set; }
        public decimal Porcentajedetraccion { get; set; }
        public int Idcpventa { get; set; }
        public decimal Importedeposito { get; set; }
        public Boolean Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public string Observacion { get; set; }
        public decimal Tipocambio { get; set; }
    }
}
