using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("ubicacion")]
    public class Ubicacion
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idubicacion")]
        public int Idubicacion { get; set; }
        public int Idsucursal { get; set; }
        public int Idalmacen { get; set; }
        public string Ambiente { get; set; }
        public string Columna { get; set; }
        public string Fila { get; set; }
        public string Nombreubicacion { get; set; }
    }
}
