using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("vwarticulostocklista")]
    public class VwArticulostocklista
    {
        [PrimaryKey]
        [Alias("idarticulolistaprecio")]
        public int Idarticulolistaprecio { get; set; }
        public int? Idarticulo { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Codigodebarra { get; set; }
        public string Nombrearticulo { get; set; }
        public int? Idmarca { get; set; }
        public string Nombremarca { get; set; }
        public int? Idunidadmedida { get; set; }
        public string Codigounidadmedida { get; set; }
        public string Nombreunidadmedida { get; set; }
        public int? Factorconversion { get; set; }
        public string Abrunidadmedida { get; set; }
        public decimal Stock { get; set; }
        public int? Idarticuloclasificacion { get; set; }
        public string Codigoclasificacion { get; set; }
        public string Nombreclasificacion { get; set; }
        public int? Idtipoarticulo { get; set; }
        public string Nombretipoarticulo { get; set; }
        public int? Idimpuesto { get; set; }
        public string Abreviaturaigv { get; set; }
        public string Nombreimpuesto { get; set; }
        public decimal? Porcentajeimpuesto { get; set; }
        public bool? Activo { get; set; }
        public decimal? Pesoarticulo { get; set; }
        public bool Aplicapercepcion { get; set; }
        public int? Idtipoafectacionigv { get; set; }
        public string Codigotipoafectacionigv { get; set; }
        public string Nombretipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public string Caracteristicas { get; set; }
        public int? Idlistaprecio { get; set; }
        public int? Idtipolista { get; set; }
        public string Codigotipolista { get; set; }
        public string Nombretipolista { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Codigotipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public int? Idsucursal { get; set; }
        public int? Idimpuestoisc { get; set; }
        public string Abreviaturaisc { get; set; }
        public string Nombreimpuestoisc { get; set; }
        public decimal? Porcentajeimpuestoisc { get; set; }
        public bool? Muevekardex { get; set; }
        public decimal? Stockminarticulo { get; set; }
        public decimal? Stockmaximo { get; set; }
        public bool? Esarticuloinventario { get; set; }
        public bool? Esarticulodeventa { get; set; }
        public bool? Esarticulodecompra { get; set; }
        public bool? Esactivofijo { get; set; }
        public int? Idcuentacontable { get; set; }
        public string Codigocuenta { get; set; }
        public string Nombrecuenta { get; set; }
        public string Comentario { get; set; }
        public int? Idcentrodecosto { get; set; }
        public string Codigocentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public bool Esarticulocompuesto { get; set; }
        public decimal Costolista { get; set; }
        public decimal Porcentajemargencontado { get; set; }
        public decimal Preciocontado { get; set; }
        public decimal Porcentajemargencreditoopcion1 { get; set; }
        public decimal Preciocreditoopcion1 { get; set; }
        public decimal Porcentajemargencreditoopcion2 { get; set; }
        public decimal Preciocreditoopcion2 { get; set; }
        public decimal Porcentajemargenpreciosugerido { get; set; }
        public decimal Preciosugerido { get; set; }
        public DateTime? Lastmodified { get; set; }
        public string Lastchangeby { get; set; }
        public bool Listaprecioincluyeimpuesto { get; set; }
    }
}
