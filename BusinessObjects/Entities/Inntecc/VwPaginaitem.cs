using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwpaginaitem")]
    public class VwPaginaitem
    {
        [PrimaryKey]
        [Alias("idpaginaitem")]
        public int Idpaginaitem { get; set; }
        public int? Idpagina { get; set; }
        public string Namepagina { get; set; }
        public string Titulopagina { get; set; }
        public string Titulopaginaitem { get; set; }
        public string Namepaginaitem { get; set; }
        public string Nameform { get; set; }
        [Ignore]
        public bool Activo { get; set; }
    }
}
