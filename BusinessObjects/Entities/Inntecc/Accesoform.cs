using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("accesoform")]
    public class Accesoform
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idaccesoform")]
        public int Idaccesoform { get; set; }
        public int Idusuario { get; set; }
        public int Idgrupoitem { get; set; }
        public bool Permitir { get; set; }
        public bool Buscar { get; set; }
        public bool Nuevo { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Imprimir { get; set; }
        public bool Anular { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Lastmodified { get; set; }
    }
}
