using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
    [Schema("inntecc")]
    [Alias("empleado")]
    public class Empleado
    {
        [PrimaryKey]
        [AutoIncrement]
        [Alias("idempleado")]
        public int Idempleado { get; set; }
        public int Idpersona { get; set; }
        public int Idarea { get; set; }
        public string Denominacionfuncion { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime? Fechacese { get; set; }
        public string Motivocese { get; set; }
        public string Comentario { get; set; }
        public string Nombrearchivofoto { get; set; }
        public string Movil { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int? Idtipocpventa { get; set; }
        public int? Idcptooperacionventa { get; set; }
        public int? Idtipocpreciboingreso { get; set; }
        public int? Idcptooperacionreciboingreso { get; set; }
        public string Numerosegurosocial { get; set; }
        public int? Idtiposnp { get; set; }
        public string Celularempresa { get; set; }
        public string Emailempresa { get; set; }
        public int? Idestadocivil { get; set; }
        public int Numerohijos { get; set; }
        public int? Idpais { get; set; }
        public string Nivelestudio { get; set; }
        public string Especialidad { get; set; }
        public decimal Comisionclasificacionproducto { get; set; }
        public decimal Bono { get; set; }
        public int? Idbancocuentasueldo { get; set; }
        public string Numerocuentasueldo { get; set; }
        public int? Idtipocontratoempleado { get; set; }
        public DateTime? Vencimientocontrato { get; set; }
        public string Categoria { get; set; }
        public int? Idtipomonedasueldo { get; set; }
        public decimal Sueldobruto { get; set; }
        public int? Iddistritotrabajo { get; set; }
        public string Nombreconyugue { get; set; }
        public string Telefonoconyugue { get; set; }
        public string Nombrecontactoemergencia { get; set; }
        public string Telefonoemergencia { get; set; }
        public bool Esactivo { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public byte[] Fotoempleado { get; set; }
        public string Nombrefuente { get; set; }
        public decimal Fuentetamanio { get; set; }
        public bool Fuentenegrita { get; set; }
    }
}
