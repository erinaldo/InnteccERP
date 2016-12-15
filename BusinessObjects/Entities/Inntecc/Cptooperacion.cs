using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("cptooperacion")]
    public class Cptooperacion
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idcptooperacion")]
        public int Idcptooperacion { get; set; }
        public int Idsucursal { get; set; }
        public int Idtipodocmov { get; set; }
        [Required]
        [StringLength(3)]
        public string Codigocptooperacion { get; set; }
        public int? Idtipooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public bool Generasalida { get; set; }
        public bool Tienecpcaja { get; set; }
        public bool Tienecpcobrarpagar { get; set; }
        public bool Esactivo { get; set; }
        public bool Tieneordenservicio { get; set; }
        public bool Escajachica { get; set; }
        public bool Generadevolucion { get; set; }
        public bool Validarvalorunitario { get; set; }
        public bool Validarstock { get; set; }
        public bool Generatrasladoentrealmacenes { get; set; }
        public bool Generaentrada { get; set; }
        public bool Tieneordencompra { get; set; }
        public bool Buscarsoloitemservicio { get; set; }

    }
}
