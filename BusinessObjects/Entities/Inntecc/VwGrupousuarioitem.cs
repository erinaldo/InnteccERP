using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwgrupousuarioitem")]
    public class VwGrupousuarioitem
    {
        [PrimaryKey]
        [Alias("idaccesoform")]
        public int Idaccesoform { get; set; }
        public int Idusuario { get; set; }
        public int Idgrupoitem { get; set; }
        public int Idgrupousuario { get; set; }
        public string Nombregrupo { get; set; }
        public int Idpaginaitem { get; set; }
        public int? Idpagina { get; set; }
        public string Namepagina { get; set; }
        public string Titulopagina { get; set; }
        public string Titulopaginaitem { get; set; }
        public string Tituloform { get; set; }
        public string Namepaginaitem { get; set; }
        public string Nameform { get; set; }
        public bool Activo { get; set; }
        public bool Permitir { get; set; }
        public bool Buscar { get; set; }
        public bool Nuevo { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Imprimir { get; set; }
        public bool Anular { get; set; }
        public int Idempresa { get; set; }
        public string Nombreempresa { get; set; }

    }
}