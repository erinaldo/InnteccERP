using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwperiodo")]
    public class VwPeriodo
    {
        [PrimaryKey]
        [Alias("idperiodo")]
        public int Idperiodo { get; set; }
        public int? Idejercicio { get; set; }
        public int? Anioejercicio { get; set; }
        public int? Idempresa { get; set; }
        public string Mes { get; set; }
        public string Periodo { get; set; }
        public bool? Cerrado { get; set; }
        public string Nombremes { get; set; }
    }
}
