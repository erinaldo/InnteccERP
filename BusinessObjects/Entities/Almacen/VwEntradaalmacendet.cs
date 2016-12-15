using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("vwentradaalmacendet")]
    public class VwEntradaalmacendet : BusinessObject
    {
        [PrimaryKey]
        [Alias("identradaalmacendet")]
        public int Identradaalmacendet { get; set; }
        public int? Identradaalmacen { get; set; }
        public string Serieentradaalmacen { get; set; }
        public string Numeroentradaalmacen { get; set; }
        public int Numeroitem { get; set; }
        public int Idarticulo { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Codigodebarra { get; set; }
        public int? Idunidadinventario { get; set; }
        public int? Idarticuloclasificacion { get; set; }
        public string Codigoclasificacion { get; set; }
        public string Nombreclasificacion { get; set; }
        public int? Idmarca { get; set; }
        public string Nombremarca { get; set; }
        public string Nombrearticulo { get; set; }
        public string Especificacion { get; set; }
        public decimal Cantidad { get; set; }
        public int Idunidadmedida { get; set; }
        public string Codigounidadmedida { get; set; }
        public string Nombreunidadmedida { get; set; }
        public string Abrunidadmedida { get; set; }
        public int? Factorconversion { get; set; }
        public decimal Preciounitario { get; set; }
        public int Idimpuesto { get; set; }
        public decimal Importetotal { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int? Idordencompradet { get; set; }
        public string Abreviaturaigv { get; set; }
        public string Nombreimpuesto { get; set; }
        public decimal? Porcentajeimpuesto { get; set; }       
        public decimal Cantidadverificada { get; set; }
        public decimal Diferencia { get; set; }
        public string Serienumeroordencompra { get; set; }
        public int Idordencompra { get; set; }
        public bool Ordencompraanulado { get; set; }
        public int Idcentrodecosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public int Idarea { get; set; }
        public string Codigoarea { get; set; }
        public string Nombrearea { get; set; }
        public int Idproyecto { get; set; }
        public string Nombreproyecto { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public string Codigotipoafectacionigv { get; set; }
        public string Nombretipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public bool Calcularitem { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
    }
}
