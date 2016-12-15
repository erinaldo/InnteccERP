using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("sucursal")]
    public class Sucursal
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idsucursal")]
        public int Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int Iddistrito { get; set; }
        public string Direccionsucursal { get; set; }
        public bool Principal { get; set; }
        public int? Idempresa { get; set; }
        public int? Idempleadoaprueba { get; set; }
        public int? Idalmacendefecto { get; set; }
        public int Idtipolistadefecto { get; set; }
        public int? Idcptooperacionordenservicio { get; set; }
        public int? Idcptooperacionordencompra { get; set; }
        public int? Idcentrobeneficioventadefecto { get; set; }
    }
}
