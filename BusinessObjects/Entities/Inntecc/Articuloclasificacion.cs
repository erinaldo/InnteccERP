using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("articuloclasificacion")]
    public class Articuloclasificacion
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idarticuloclasificacion")]
        public int Idarticuloclasificacion { get; set; }
        [Required]
        [StringLength(4)]
        public string Codigoclasificacion { get; set; }
        public string Nombreclasificacion { get; set; }
        public int? Idnodopadre { get; set; }
    }
}
