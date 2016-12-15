using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("empresa")]
	public class Empresa
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idempresa")]
		public  int Idempresa{ get; set; }
		public  string Razonsocial{ get; set; }
		public  string Ruc{ get; set; }
		public  string Direccionfiscal{ get; set; }
		public  string Telefono{ get; set; }
		public  string Paginaweb{ get; set; }
		public  decimal Porcentajepercepcion{ get; set; }
		public  decimal Porcentajeretencion{ get; set; }
		public  decimal Importeretencion{ get; set; }
		public  bool Ignorarstock{ get; set; }
		public  bool Autoenumerararticulos{ get; set; }
		public  bool Autoenumerarsocionegocio{ get; set; }
		public  string Rutaarchivos{ get; set; }
		public  int Idimpuestopordefecto{ get; set; }       
	    public byte[] Logo { get; set; }
	    public int? Idproyectopordefecto { get; set; }
        public int? Idarticulodanio { get; set; }
        public int? Idarticuloelementodesgaste { get; set; }
        public int Limitediasinactividadsocio { get; set; }
        public int? Idestadosocionegocioinactivo { get; set; }
        public bool Listaprecioincluyeimpuesto { get; set; }

	}
}
