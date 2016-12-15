using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("Logistica")]
    [Alias("LOG_Stocks")]
    public class LogStocks
    {
        [Alias("ALMAC_Id")]
        public int AlmacId { get; set; }

        [PrimaryKey]
        [Alias("ARTIC_Codigo")]
        public string ArticCodigo { get; set; }

        [PrimaryKey]
        [Alias("PERIO_Codigo")]
        public string PerioCodigo { get; set; }

        [PrimaryKey]
        [Alias("STOCK_Id")]
        public int StockId { get; set; }

        [Alias("TIPOS_CodTipoUnidad")]
        public string TiposCodTipoUnidad { get; set; }

        [Alias("INGCO_Id")]
        public int? IngcoId { get; set; }

        [Alias("INGCD_Item")]
        public int? IngcdItem { get; set; }

        [Alias("STOCK_Fecha")]
        public DateTime StockFecha { get; set; }

        [Alias("STOCK_CantidadIngreso")]
        public decimal StockCantidadIngreso { get; set; }

        [Alias("STOCK_Estado")]
        public string StockEstado { get; set; }

        [Alias("TIPOS_CodTipoMotivo")]
        public string TiposCodTipoMotivo { get; set; }

        [Alias("STOCK_UsrCrea")]
        public string StockUsrCrea { get; set; }

        [Alias("STOCK_FecCrea")]
        public DateTime StockFecCrea { get; set; }

    }
}
