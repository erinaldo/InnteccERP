using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("entradaalmacenobs")]
    public class Entradaalmacenobs
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("identradaalmacenobs")]
        public int Identradaalmacenobs { get; set; }
        public int Identradaalmacendet { get; set; }
        public int Idestadoarticulo { get; set; }
        public decimal Cantidad { get; set; }
        public bool Procedereclamo { get; set; }
    }
}
