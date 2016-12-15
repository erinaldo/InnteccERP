using System.Security.AccessControl;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwarticuloubicacion")]
    public class VwArticuloubicacion
    {
        [PrimaryKey]
        [Alias("idarticuloubicacion")]
        public int Idarticuloubicacion { get; set; }
        public int? Idarticulo { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Codigodebarra { get; set; }
        public string Nombrearticulo { get; set; }
        public int? Idarticuloclasificacion { get; set; }
        public string Nombreclasificacion { get; set; }
        public int Idubicacion { get; set; }
        public string Ambiente { get; set; }
        public string Columna { get; set; }
        public string Fila { get; set; }
        public string Nombreubicacion { get; set; }
        public int? Idalmacen { get; set; }
        public string Codigoalmacen { get; set; }
        public string Nombrealmacen { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int Idempresa { get; set; }
        public string Nombreempresa { get; set; }

    }
}
