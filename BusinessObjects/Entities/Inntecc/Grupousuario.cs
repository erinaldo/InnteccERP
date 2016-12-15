using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("grupousuario")]
    public class Grupousuario
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idgrupousuario")]
        public int Idgrupousuario { get; set; }
        public string Nombregrupo { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Lastmodified { get; set; }
        public int? Idempresa { get; set; }
    }
}
