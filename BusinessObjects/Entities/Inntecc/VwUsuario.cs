using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwusuario")]
    public class VwUsuario
    {
        [PrimaryKey]
        [Alias("idusuario")]
        public int? Idusuario { get; set; }
        public int? Idgrupousuario { get; set; }
        public string Nombregrupo { get; set; }
        public string Nombreusuario { get; set; }
        public string Descripcionusuario { get; set; }
        public string Pwdusuario { get; set; }
        public bool? Suspendido { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Idempleado { get; set; }
        public int? Idpersonaempleado { get; set; }
        public string Nombrempleado { get; set; }
        public string Nrodocentidad { get; set; }
        public int? Idempresa { get; set; }
        public string Nombreempresa { get; set; }
    }
}
