using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("vwtipocp")]
    public class VwTipocp
    {
        [PrimaryKey]
        [Alias("idtipocp")]
        public int? Idtipocp { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public string Codigotipocp { get; set; }
        public string Nombretipocp { get; set; }
        public string Abreviaciontipocp { get; set; }
        public bool? Tieneimpuesto { get; set; }
        public int? Idimpuesto { get; set; }
        public string Nombreimpuesto { get; set; }
        public decimal? Porcentajeimpuesto { get; set; }
        public int? Idtipocppago { get; set; }
        public string Nombretipocppago { get; set; }
        public int? Idtipodocmov { get; set; }
        public string Nombretipodocmov { get; set; }
        public string Seriecp { get; set; }
        public string Numerocorrelativocp { get; set; }
        public bool Numeracionauto { get; set; }
        public bool Enumerarporsocionegocio { get; set; }        
        public int? Maxnumeroitems { get; set; }
        public bool? Esactivo { get; set; }
        public string Nombrereporte { get; set; }
        public bool Requierenumerorucvalido { get; set; }
        public int Idempresa { get; set; }
        public string Nombreempresa { get; set; }
    }
}
