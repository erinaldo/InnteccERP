using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwhistoriaclinicaanalisis")]
	public class VwHistoriaclinicaanalisis
	{
		[PrimaryKey]
		[Alias("idhistoriaclinicaanalisis")]
		public int?  Idhistoriaclinicaanalisis { get; set; }
		public int?  Idhistoriaclinicacita { get; set; }
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
		public int?  Idtipoanalisis { get; set; }
		public string Nombretipoanalisis { get; set; }
		public string Numerodeorden { get; set; }
		public DateTime?  Fechaorden { get; set; }
		public DateTime?  Fecharesultado { get; set; }
		public int?  Idresponsable { get; set; }
		public int?  Idpersonaresponsable { get; set; }
		public string Nombreresponsable { get; set; }
		public int?  Idregistrador { get; set; }
		public int?  Idpersonaregistrador { get; set; }
		public string Nombreregistrador { get; set; }
		public string Nombrearchivo { get; set; }
		public string Extensionarchivo { get; set; }
		public string Comentario { get; set; }
	}
}
