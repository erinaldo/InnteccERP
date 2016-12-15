using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("vwentradaalmacenobs")]
    public class VwEntradaalmacenobs
    {
        [PrimaryKey]
        [Alias("identradaalmacenobs")]
        public int Identradaalmacenobs { get; set; }
        public int? Identradaalmacendet { get; set; }
        public int? Idestadoarticulo { get; set; }
        public string Nombreestado { get; set; }
        public decimal? Cantidad { get; set; }
        public bool? Procedereclamo { get; set; }
    }
}
