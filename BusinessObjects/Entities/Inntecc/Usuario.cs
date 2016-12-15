using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("usuario")]
    public class Usuario
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idusuario")]
        public int Idusuario { get; set; }
        public int Idgrupousuario { get; set; }
        public string Nombreusuario { get; set; }
        public string Descripcionusuario { get; set; }
        public string Pwdusuario { get; set; }
        public bool Suspendido { get; set; }
        public DateTime Fecharegistro { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Lastmodified { get; set; }
        public int? Idempleado { get; set; }
        public int? Idempresa { get; set; }
    }
}
