using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegociocontacto")]
	public class Socionegociocontacto
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegociocontacto")]
		public  int Idsocionegociocontacto{ get; set; }
        public int? Idsocionegocio { get; set; }
		public  string Nombrecontacto{ get; set; }
		public  string Area{ get; set; }
		public  string Direccion{ get; set; }
		public  string Telefono{ get; set; }
		public  string Movil{ get; set; }
		public  string Email{ get; set; }
		public  string Observaciones{ get; set; }
        public string Cargo { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public DateTime? Fechaaniversario { get; set; }
        public string Nombreconyugue { get; set; }
        public byte[] Foto { get; set; }
        public string Numeroanexo { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
