using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("vwhistoriaclinica")]
	public class VwHistoriaclinica
	{
		[PrimaryKey]
		[Alias("idhistoriaclinica")]
		public int?  Idhistoriaclinica { get; set; }
		public int?  Idtipocp { get; set; }
		public int?  Idtipoformato { get; set; }
		public string Nombretipoformato { get; set; }
		public string Abreviaturatipoformato { get; set; }
		public string Seriehistoria { get; set; }
		public string Numerohistoria { get; set; }
		public DateTime?  Fecharegistro { get; set; }
		public int?  Idregistrador { get; set; }
		public int?  Idpersonaregistrador { get; set; }
		public string Nombreregistrador { get; set; }
		public int?  Idclientetitular { get; set; }
		public int?  Idpersonaclientetitular { get; set; }
		public string Apepaternoclientetitular { get; set; }
		public string Apematernoclientetitular { get; set; }
		public string Nombrespersonaclientetitular { get; set; }
		public string Razonsocialclientetitular { get; set; }
		public int?  Idtipodocentclientetitular { get; set; }
		public string Nombretipodocentidadclientetitular { get; set; }
		public string Abreviaturadocentidadclientetitular { get; set; }
		public string Nrodocentidadclientetitular { get; set; }
		public int?  Idestadociviltitular { get; set; }
		public DateTime?  Fechanacimientotitular { get; set; }
		public string Ocupaciontitular { get; set; }
		public int?  Idclienteconyugue { get; set; }
		public int?  Idpersonaconyugue { get; set; }
		public string Apepaternoconyugue { get; set; }
		public string Apematernoconyugue { get; set; }
		public string Nombrespersonaconyugue { get; set; }
		public string Razonsocialconyugue { get; set; }
		public int?  Idtipodocentconyugue { get; set; }
		public string Nombretipodocentidadconyugue { get; set; }
		public string Abreviaturadocentidadconyugue { get; set; }
		public string Nrodocentidadconyugue { get; set; }
		public string Comentario { get; set; }
		public string Antecedentesheredofamiliares { get; set; }
		public string Habitacion { get; set; }
		public string Alimentacion { get; set; }
		public bool?  Tabaquismo { get; set; }
		public bool?  Alcoholismo { get; set; }
		public bool?  Toxicomanias { get; set; }
		public string Actividadsedentarismo { get; set; }
		public string Alergias { get; set; }
		public string Patologias { get; set; }
		public string Traumaticos { get; set; }
		public string Quirurgicos { get; set; }
		public string Transfusionales { get; set; }
		public string Farmacologicos { get; set; }
		public string Geneticos { get; set; }
		public int?  Menarquia { get; set; }
		public int?  Idtipociclomenstrual { get; set; }
		public string Nombretipociclomenstrual { get; set; }
		public string Descricpciontipociclomenstrual { get; set; }
		public int?  Edadiniciorelacionsexual { get; set; }
		public int?  Metodoanticonceptivo { get; set; }
		public int?  Tiempousometodo { get; set; }
		public DateTime?  Fechaultimaregla { get; set; }
		public DateTime?  Fechaprobabledeparto { get; set; }
		public int?  Numerodegestaciones { get; set; }
		public int?  Numerodepartos { get; set; }
		public int?  Numerodecesareas { get; set; }
		public int?  Numerodeabortos { get; set; }
		public int?  Numerodeparejassexuales { get; set; }
		public string Tiempointentoembarazo { get; set; }
		public string Tiempodetratamiento { get; set; }
	}
}
