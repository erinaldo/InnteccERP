using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("compras")]
	[Alias("requerimientodet")]
	public class Requerimientodet : BusinessObject
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idrequerimientodet")]
		public  int Idrequerimientodet{ get; set; }
		public  int?  Idrequerimiento{ get; set; }
		public  int Numeroitem{ get; set; }
		public  int?  Idarticulo{ get; set; }
		public  int?  Idimpuesto{ get; set; }
		public  int?  Idunidadmedida{ get; set; }
		public  string Especificacion{ get; set; }
		public  decimal Cantidad{ get; set; }
		public  decimal Preciounitario{ get; set; }
		public  decimal Importetotal{ get; set; }
		public  int?  Idcentrodecosto{ get; set; }
        public decimal Cantidadinicial { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public bool Aprobado { get; set; }
        public bool Calcularitem { get; set; }
	}
}
