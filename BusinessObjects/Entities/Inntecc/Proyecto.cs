using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("proyecto")]
    public class Proyecto
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idproyecto")]
        public int Idproyecto { get; set; }
        [Required]
        [StringLength(4)]
        public string Codigoproyecto { get; set; }
        public string Nombreproyecto { get; set; }
        public bool Esactivo { get; set; }
        public int Idempresa { get; set; }
    }
}
