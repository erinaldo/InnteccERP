using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("vwinventario")]
    public class VwInventario
    {
        [PrimaryKey]
        [Alias("idinventario")]
        public int Idinventario { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public string Direccionsucursal { get; set; }
        public int Idalmacen { get; set; }
        public string Codigoalmacen { get; set; }
        public string Nombrealmacen { get; set; }
        public string Direccionalmacen { get; set; }
        public int? Idtipocp { get; set; }
        public string Codigotipocp { get; set; }
        public int? Idtipoformato { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int? Maxnumeroitems { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Codigocptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public int? Idresponsable { get; set; }
        public int? Idpersona { get; set; }
        public string Razonsocial { get; set; }
        public string Nrodocentidad { get; set; }
        public string Denominacionfuncion { get; set; }
        public string Numeroinventario { get; set; }
        public string Serieinventario { get; set; }
        public DateTime? Fechainventario { get; set; }
        public bool? Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public bool? Cierreinventario { get; set; }
        public int Idempresa { get; set; }
        public string Nombreempresa { get; set; }
        public int Idinventarioinicial { get; set; }
        public DateTime Fechainventarioinicial { get; set; }
    }
}
