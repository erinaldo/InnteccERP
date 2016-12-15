using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwarticulocompuesto")]
	public class VwArticulocompuesto
	{
		[PrimaryKey]
		[Alias("idarticulocompuesto")]
		public int  Idarticulocompuesto { get; set; }
		public int  Idarticulo { get; set; }
		public string Codigoarticulo { get; set; }
		public string Codigoproveedor { get; set; }
		public string Codigodebarra { get; set; }
		public int?  Idarticuloclasificacion { get; set; }
		public string Codigoclasificacion { get; set; }
		public string Nombreclasificacion { get; set; }
		public int?  Idmarca { get; set; }
		public string Nombremarca { get; set; }
		public string Nombrearticulo { get; set; }
		public int  Idimpuesto { get; set; }
		public string Abreviaturaigv { get; set; }
		public string Nombreimpuesto { get; set; }
		public decimal?  Porcentajeimpuesto { get; set; }
		public bool?  Activo { get; set; }
		public bool?  Muevekardex { get; set; }
		public decimal  Pesoarticulo { get; set; }
		public decimal?  Stockminarticulo { get; set; }
		public bool?  Aplicapercepcion { get; set; }
		public decimal?  Stockmaximo { get; set; }
		public string Comentario { get; set; }
		public bool?  Esarticuloinventario { get; set; }
		public bool?  Esarticulodeventa { get; set; }
		public bool?  Esarticulodecompra { get; set; }
		public bool?  Esactivofijo { get; set; }
		public int  Idtipoafectacionigv { get; set; }
		public string Codigotipoafectacionigv { get; set; }
		public string Nombretipoafectacionigv { get; set; }
		public bool  Gravado { get; set; }
		public bool  Exonerado { get; set; }
		public bool  Inafecto { get; set; }
		public bool  Exportacion { get; set; }
		public string Caracteristicas { get; set; }
		public int?  Idtipoarticulo { get; set; }
		public string Numerodeserie { get; set; }
		public int?  Idelementogasto { get; set; }
		public string Codigoelementogasto { get; set; }
		public string Nombreelementogasto { get; set; }
		public int  Idunidadinventario { get; set; }
		public string Codigounidadmedida { get; set; }
		public string Nombreunidadmedida { get; set; }
		public string Abrunidadmedida { get; set; }
		public int?  Factorconversion { get; set; }
		public bool?  Essunat { get; set; }
		public decimal  Cantidaddetalle { get; set; }
		public decimal  Valorunitario { get; set; }
		public int?  Idtipomoneda { get; set; }
		public string Codigotipomoneda { get; set; }
		public string Simbolomoneda { get; set; }
		public string Nombretipomoneda { get; set; }
        public int Idarticulodetalle { get; set; }
	}
}
