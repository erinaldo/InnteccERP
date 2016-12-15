using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("vwarticulolistaprecio")]
    public class VwArticulolistaprecio
    {
        [PrimaryKey]
        [Alias("idarticulolistaprecio")]
        public int Idarticulolistaprecio { get; set; }
        public int? Idarticulo { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Codigodebarra { get; set; }
        public int? Idmarca { get; set; }
        public string Nombremarca { get; set; }
        public string Nombrearticulo { get; set; }
        public int? Idarticuloclasificacion { get; set; }
        public string Codigoclasificacion { get; set; }
        public string Nombreclasificacion { get; set; }
        public int? Idlistaprecio { get; set; }
        public int? Idtipolista { get; set; }
        public string Codigotipolista { get; set; }
        public string Nombretipolista { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Codigotipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public int? Idsucursal { get; set; }
        public int? Idunidadmedida { get; set; }
        public string Codigounidadmedida { get; set; }
        public string Nombreunidadmedida { get; set; }
        public string Abrunidadmedida { get; set; }
        public int Factorconversion { get; set; }
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
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
    }
}
