using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("compras")]
    [Alias("vwrequerimientodet")]
    public class VwRequerimientodet : BusinessObject
    {
        public VwRequerimientodet()
        {
            Itemseleccionado = true;
        }

        [PrimaryKey]
        [Alias("idrequerimientodet")]
        public int Idrequerimientodet { get; set; }
        public int? Idrequerimiento { get; set; }
        public int Numeroitem { get; set; }
        public int? Idarticulo { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Codigodebarra { get; set; }
        public string Nombrearticulo { get; set; }
        public int? Idmarca { get; set; }
        public string Nombremarca { get; set; }
        public int? Idimpuesto { get; set; }
        public string Abreviaturaigv { get; set; }
        public string Nombreimpuesto { get; set; }
        public decimal? Porcentajeimpuesto { get; set; }
        public int? Idunidadmedida { get; set; }
        public string Codigounidadmedida { get; set; }
        public string Nombreunidadmedida { get; set; }
        public string Abrunidadmedida { get; set; }
        public int? Factorconversion { get; set; }
        public string Especificacion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Importetotal { get; set; }
        public int Idcentrodecosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public decimal Cantidadinicial { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public string Codigotipoafectacionigv { get; set; }
        public string Nombretipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public bool Aprobado { get; set; }
        public bool Calcularitem { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
        [Ignore]
        public decimal Cantidadaimportar { get; set; }
        [Ignore]
        public decimal Stock { get; set; }

        public string NumerordendetrabajoImportado { get; set; }
    }
}
