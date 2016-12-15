using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("grupousuarioitem")]
    public class Grupousuarioitem
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idgrupoitem")]
        public int Idgrupoitem { get; set; }
        public int Idgrupousuario { get; set; }
        public int Idpaginaitem { get; set; }
        public bool Activo { get; set; }
    }
}
