using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwaccesoform")]
    public class VwAccesoform
    {
        [PrimaryKey]
        [Alias("idaccesoform")]
        public int Idaccesoform { get; set; }
        public int Idusuario { get; set; }
        public int Idgrupousuario { get; set; }
        public string Nombregrupo { get; set; }
        public string Nombreusuario { get; set; }
        public string Descripcionusuario { get; set; }
        public bool Suspendido { get; set; }
        public int Idempresa { get; set; }
        public string Nombreempresa { get; set; }
        public int Idgrupoitem { get; set; }
        public int Idpaginaitem { get; set; }
        public string Tituloform { get; set; }
        public string Namepaginaitem { get; set; }
        public string Nameform { get; set; }
        public int Idpagina { get; set; }
        public string Namepagina { get; set; }
        public string Titulopagina { get; set; }
        public bool Permitir { get; set; }
        public bool Buscar { get; set; }
        public bool Nuevo { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool Imprimir { get; set; }
        public bool Anular { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
    }
}
