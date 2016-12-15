using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwprogramacioncita")]
	public class VwProgramacioncita
	{
		[PrimaryKey]
		[Alias("idprogramacioncita")]
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
		public int?  Idsucursal { get; set; }
		public string Codigosucursal { get; set; }
		public string Nombresucursal { get; set; }
		public int?  Idempresa { get; set; }
		public string Razonsocialempresa { get; set; }
	}
}
