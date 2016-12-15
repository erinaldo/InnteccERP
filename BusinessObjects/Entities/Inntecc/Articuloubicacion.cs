using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("articuloubicacion")]
    public class Articuloubicacion
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idarticuloubicacion")]
        public int Idarticuloubicacion { get; set; }
        public int Idarticulo { get; set; }
        public int Idubicacion { get; set; }
    }
}
