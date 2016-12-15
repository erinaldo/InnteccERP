using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("compras")]
    [Alias("vwcuadrocomparativoprv")]
    public class VwCuadrocomparativoprv
    {
        [PrimaryKey]
        [Alias("idcuadrocomparativoprv")]
        public int Idcuadrocomparativoprv { get; set; }
        public int Idcuadrocomparativo { get; set; }
        public bool Anuladocc { get; set; }
        public int Idsucursal { get; set; }
        public string Codigosucursal { get; set; }
        public string Nombresucursal { get; set; }
        public int Idtipocp { get; set; }
        public int Idtipoformato { get; set; }
        public string Nombretipoformato { get; set; }
        public string Abreviaturatipoformato { get; set; }
        public int Idcptooperacion { get; set; }
        public string Codigocptooperacion { get; set; }
        public string Nombrecptooperacion { get; set; }
        public string Seriecc { get; set; }
        public string Numerocc { get; set; }
        public string Serienumerocc { get; set; }
        public DateTime Fechaemision { get; set; }
        public int Idresponsable { get; set; }
        public int Idpersonaresponsable { get; set; }
        public string Nombreresponsable { get; set; }
        public bool Culminado { get; set; }
        public DateTime? Fechaculminacion { get; set; }
        public bool Anulado { get; set; }
        public DateTime Fechaanulado { get; set; }
        public string Observacion { get; set; }
        public int Idcotizacionprv { get; set; }
        public string Sericotizacionprv { get; set; }
        public string Numerocotizacionprv { get; set; }
        public DateTime Fechacotizacion { get; set; }
        public string Serienumerocotizacion { get; set; }
        public int Idsocionegocio { get; set; }
        public int Idpersona { get; set; }
        public string Nombresocionegocio { get; set; }
        public int Idtipodocent { get; set; }
        public string Abreviaturadocentidad { get; set; }
        public string Codigotipodocentidad { get; set; }
        public string Nombretipodocentidad { get; set; }
        public string Nrodocentidad { get; set; }
        public string Telefonoprv { get; set; }
        public string Movilprv { get; set; }
        public int Iddistritoprv { get; set; }
        public string Nombreubigeoprv { get; set; }
        public string Nombredepartamentoprv { get; set; }
        public string Nombreprovinciaprv { get; set; }
        public string Nombredistritoprv { get; set; }
        public bool Incluyeimpuestoitems { get; set; }
        public string Formadepago { get; set; }
        public int Diasvalidez { get; set; }
        public DateTime Fechacotizacionrecepcion { get; set; }
        public decimal Totaldocumento { get; set; }
        public int Idestadocuadrocomparativo { get; set; }
        public string Nombreestado { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
    }
}
