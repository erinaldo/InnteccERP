using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("ventas")]
    [Alias("articulolistaprecio")]
    public class Articulolistaprecio
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idarticulolistaprecio")]
        public int Idarticulolistaprecio { get; set; }
        public int? Idarticulo { get; set; }
        public int? Idlistaprecio { get; set; }
        public int? Idunidadmedida { get; set; }
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
    }
}
