using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("vwinventarioubicacion")]
    public class VwInventarioubicacion
    {
        [PrimaryKey]
        [Alias("idinventarioubicacion")]
        public int Idinventarioubicacion { get; set; }
        public int Idinventario { get; set; }
        public string Ambiente { get; set; }
        public string Columna { get; set; }
        public string Fila { get; set; }
        public string Ubicacion { get; set; }
        public int Idubicacion { get; set; }
        public string Numeroinventario { get; set; }
        public DateTime? Fechainventario { get; set; }
        public int Idalmaceninventario { get; set; }
    }
}
