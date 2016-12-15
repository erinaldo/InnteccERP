using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("clinica")]
	[Alias("historiaclinica")]
	public class Historiaclinica
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idhistoriaclinica")]
		public int Idhistoriaclinica { get; set; }
		public int?  Idtipocp { get; set; }
		public string Seriehistoria { get; set; }
		public string Numerohistoria { get; set; }
		public DateTime Fecharegistro { get; set; }
		public int Idregistrador { get; set; }
		public int Idclientetitular { get; set; }
		public int Idestadociviltitular { get; set; }
		public DateTime Fechanacimientotitular { get; set; }
		public string Ocupaciontitular { get; set; }
		public int?  Idclienteconyugue { get; set; }
		public string Comentario { get; set; }
		public string Antecedentesheredofamiliares { get; set; }
		public string Habitacion { get; set; }
		public string Alimentacion { get; set; }
		public bool Tabaquismo { get; set; }
		public bool Alcoholismo { get; set; }
		public bool Toxicomanias { get; set; }
		public string Actividadsedentarismo { get; set; }
		public string Alergias { get; set; }
		public string Patologias { get; set; }
		public string Quirurgicos { get; set; }
		public string Traumaticos { get; set; }
		public string Transfusionales { get; set; }
		public string Farmacologicos { get; set; }
		public string Geneticos { get; set; }
		public int Menarquia { get; set; }
		public int?  Idtipociclomenstrual { get; set; }
		public int Edadiniciorelacionsexual { get; set; }
		public int Metodoanticonceptivo { get; set; }
		public int Tiempousometodo { get; set; }
		public DateTime Fechaultimaregla { get; set; }
		public DateTime Fechaprobabledeparto { get; set; }
		public int Numerodegestaciones { get; set; }
		public int Numerodepartos { get; set; }
		public int Numerodecesareas { get; set; }
		public int Numerodeabortos { get; set; }
		public int Numerodeparejassexuales { get; set; }
		public string Tiempointentoembarazo { get; set; }
		public string Tiempodetratamiento { get; set; }
	}
}
