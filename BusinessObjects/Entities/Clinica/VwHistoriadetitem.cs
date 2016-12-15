using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwhistoriadetitem")]
	public class VwHistoriadetitem
	{
		[PrimaryKey]
		[Alias("idhistoriadetitem")]
		public int  Idhistoriadetitem { get; set; }
		public int  Idhistoriadet { get; set; }
		public int?  Idhistoria { get; set; }
		public int?  Idsucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public string Seriehistoria { get; set; }
		public string Numerohistoria { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public int?  Idempleado { get; set; }
		public int?  Idpersonaempleado { get; set; }
		public string Nombrereempleado { get; set; }
		public int?  Idpacientetitular { get; set; }
		public int?  Idpersonaclientetitular { get; set; }
		public string Apepaternoclientetitular { get; set; }
		public string Apematernoclientetitular { get; set; }
		public string Nombrespersonaclientetitular { get; set; }
		public string Razonsocialclientetitular { get; set; }
		public int?  Idtipodocentclientetitular { get; set; }
		public string Nombretipodocentidadclientetitular { get; set; }
		public string Abreviaturadocentidadclientetitular { get; set; }
		public string Nrodocentidadclientetitular { get; set; }
		public int?  Idestadocivil { get; set; }
		public string Nombreestadocivil { get; set; }
		public int?  Idpersonaconyugue { get; set; }
		public string Apepaternoconyugue { get; set; }
		public string Apematernoconyugue { get; set; }
		public string Nombrespersonaconyugue { get; set; }
		public string Razonsocialconyugue { get; set; }
		public int?  Idtipodocentconyugue { get; set; }
		public string Nombretipodocentidadconyugue { get; set; }
		public string Abreviaturadocentidadconyugue { get; set; }
		public string Nrodocentidadconyugue { get; set; }
		public string Observacion { get; set; }
		public int?  Idtipohistoria { get; set; }
		public string Codigotipohistoria { get; set; }
		public int?  Ordentipohistoria { get; set; }
		public string Nombretipohistoria { get; set; }
		public DateTime?  Fechahistoriadet { get; set; }
		public int?  Idprogramacioncitadet { get; set; }
		public TimeSpan?  Horaprogramacion { get; set; }
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
		public int?  Colorestadocita { get; set; }
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
		public int?  Idprogramacioncita { get; set; }
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
		public DateTime?  Fechaprogramacion { get; set; }
		public bool?  Activo { get; set; }
		public int?  Idmotivocita { get; set; }
		public string Nombremotivocita { get; set; }
		public int?  Iditemhistoria { get; set; }
		public int?  Idcategoriaitem { get; set; }
		public string Codigocategoriaitem { get; set; }
		public string Nombrecategoriaitem { get; set; }
		public int?  Ordencategoriaitem { get; set; }
		public int?  Ordenitemhistoria { get; set; }
		public string Nombreitemhistoria { get; set; }
		public string Tipodatoitemhistoria { get; set; }
		public bool?  Requierearchivo { get; set; }
		public bool?  Requiereplanembarazoparto { get; set; }
		public string Valoritemhistoria { get; set; }
        public int Ordenhistoriadetitem { get; set; }
        [Ignore]
	    public DataEntityState DataEntityState { get; set; }
	}
}
