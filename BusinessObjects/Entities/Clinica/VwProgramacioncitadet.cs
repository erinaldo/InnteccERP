using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwprogramacioncitadet")]
	public class VwProgramacioncitadet
	{
		[PrimaryKey]
		[Alias("idprogramacioncitadet")]
		public int  Idprogramacioncitadet { get; set; }
		public DateTime  Horaprogramacion { get; set; }
		public int?  Idpaciente { get; set; }
		public string Apepaterno { get; set; }
		public string Apematerno { get; set; }
		public string Nombrespersona { get; set; }
		public string Razonsocialpaciente { get; set; }
		public int?  Idtipodocentpri { get; set; }
		public string Nombretipodocentidadpri { get; set; }
		public string Abreviaturadocentidadpri { get; set; }
		public string Nrodocentidadpri { get; set; }
		public int?  Idtipodocent { get; set; }
		public string Nombretipodocentidad { get; set; }
		public string Abreviaturadocentidad { get; set; }
		public string Nrodocentidad { get; set; }
		public int?  Idestadocita { get; set; }
		public string Nombreestadocita { get; set; }
		public int Colorestadocita { get; set; }
        public byte[] Imagenestado { get; set; }
		public int?  Idcpventa { get; set; }
		public int?  Idtipocpventa { get; set; }
		public int?  Idtipoformatoventa { get; set; }
		public string Nombretipoformatoventa { get; set; }
		public string Abreviaturatipoformatoventa { get; set; }
		public string Seriecpventa { get; set; }
		public string Numerocpventa { get; set; }
		public string Tiposerienumerocpventa { get; set; }
		public DateTime?  Fechaemision { get; set; }
		public decimal?  Totaldocumentoventa { get; set; }
		public int?  Idrecibocajaingreso { get; set; }
		public int?  Idtipocprecibo { get; set; }
		public int?  Idtipoformatorecibo { get; set; }
		public string Nombretipoformatorecibo { get; set; }
		public string Abreviaturatipoformatorecibo { get; set; }
		public string Serierecibo { get; set; }
		public string Numerorecibo { get; set; }
		public string Tiposerienumerorecibo { get; set; }
		public DateTime?  Fecharecibo { get; set; }
		public DateTime?  Fechapagorecibo { get; set; }
		public decimal?  Totaldocumentorecibo { get; set; }
		public int  Idprogramacioncita { get; set; }
		public int?  Idservicio { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public int?  Idunidadinventario { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public int?  Idarticuloclasificacion { get; set; }
		public string Codigoclasificacion { get; set; }
		public string Nombreclasificacion { get; set; }
		public int?  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public string Nombrearticulo { get; set; }
		public int?  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal?  Porcentajeimpuesto { get; set; }
		public int?  Idmedico { get; set; }
		public int?  Idpersonamedico { get; set; }
		public string Apepaternomedico { get; set; }
		public string Apematernomedico { get; set; }
		public string Nombrespersonamedico { get; set; }
		public string Razonsocialmedico { get; set; }
        public string Nombrecomercialmedico { get; set; }        
		public string Codigoprofesional { get; set; }
		public string Nivelestudio { get; set; }
		public string Especialidad { get; set; }
		public int?  Idtipodocentprimed { get; set; }
		public string Codigotipodocentidadprimed { get; set; }
		public string Nombretipodocentidadprimed { get; set; }
		public string Abreviaturadocentidadprimed { get; set; }
		public string Nrodocentidadprimed { get; set; }
		public int?  Idtipodocentmed { get; set; }
		public string Codigotipodocentidadmed { get; set; }
		public string Nombretipodocentidadmed { get; set; }
		public string Abreviaturadocentidadmed { get; set; }
		public string Nrodocentidadmed { get; set; }
		public DateTime  Fechaprogramacion { get; set; }
		public bool?  Activo { get; set; }
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idempresa { get; set; }
		public string Razonsocialempresa { get; set; }
        public int? Idmotivocita { get; set; }
        public string Nombremotivocita { get; set; }
        public DateTime? Horatermino { get; set; }

        [Ignore]
        public DataEntityState DataEntityState { get; set; }
	    
	}
}
