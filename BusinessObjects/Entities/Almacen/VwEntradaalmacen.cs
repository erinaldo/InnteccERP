using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("almacen")]
    [Alias("vwentradaalmacen")]
    public class VwEntradaalmacen 
    {
        [PrimaryKey]
        [Alias("identradaalmacen")]
        public int? Identradaalmacen { get; set; }
        public int? Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int? Idalmacen { get; set; }
        public string Codigoalmacen { get; set; }
        public string Nombrealmacen { get; set; }
        public string Direccionalmacen { get; set; }
        public int? Idtipocp { get; set; }
        public string Codigotipocp { get; set; }
        public int? Idtipoformato { get; set; }
        public int? Maxnumeroitems { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int? Idcptooperacion { get; set; }
        public string Codigocptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public int? Idtipodocmov { get; set; }
        public string Codigotipodocmov { get; set; }
        public string Nombretipodocmov { get; set; }
        public string Serieentradaalmacen { get; set; }
        public string Numeroentradaalmacen { get; set; }
        public string Serienumeroentrada { get; set; }
        public int? Idempleado { get; set; }
        public string Nombreresponsable { get; set; }
        public int Idsocionegocio { get; set; }
        public string Razonsocial { get; set; }
        public string Nombretipodocentidad { get; set; }
        public string Abreviaturadocentidad { get; set; }
        public string Nrodocentidadprincipal { get; set; }
        public string Direccionfiscal { get; set; }
        public DateTime? Fechaentrada { get; set; }
        public bool? Anulado { get; set; }
        public DateTime? Fechaanulado { get; set; }
        public decimal? Tipocambio { get; set; }
        public int? Idtipomoneda { get; set; }
        public string Codigotipomoneda { get; set; }
        public string Nombretipomoneda { get; set; }
        public string Simbolomoneda { get; set; }
        public int? Idimpuesto { get; set; }
        public string Abreviaturaigv { get; set; }
        public string Nombreimpuesto { get; set; }
        public decimal? Porcentajeimpuesto { get; set; }
        public decimal? Totalgravado { get; set; }
        public decimal? Totalimpuesto { get; set; }
        public decimal? Importetotalpercepcion { get; set; }
        public decimal? Totaldocumento { get; set; }
        public string Glosa { get; set; }
        public decimal? Totalexonerado { get; set; }
        public DateTime? Fechaverificacion { get; set; }
        public int? Idresponsableverifica { get; set; }
        public int? Idalmacendestino { get; set; }
        public string Nombredocumentoingreso { get; set; }
        public string Serieguiaremision { get; set; }
        public string Numeroguiaremision { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
    }
}
