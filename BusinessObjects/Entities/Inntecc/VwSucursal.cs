using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsucursal")]
	public class VwSucursal
	{
		[PrimaryKey]
		[Alias("idsucursal")]
		public  int  Idsucursal{ get; set; }
		public  string Codigosucursal{ get; set; }
		public  string Nombresucursal{ get; set; }
		public  string Direccionsucursal{ get; set; }
		public  int?  Iddistrito{ get; set; }
		public  string Nombreubigeo{ get; set; }
		public  int?  Iddepartamento{ get; set; }
		public  string Codigodepartamento{ get; set; }
		public  string Nombredepartamento{ get; set; }
		public  int?  Idprovincia{ get; set; }
		public  string Codigoprovincia{ get; set; }
		public  string Nombreprovincia{ get; set; }
		public  string Codigodistrito{ get; set; }
		public  string Nombredistrito{ get; set; }
	    public int Idempresa { get; set; }
        public string Ruc { get; set; }
        public string Razonsocialempresa { get; set; }
        public string Direccionfiscal { get; set; }
        public string Paginaweb { get; set; }
        public string Telefono { get; set; }
        public byte[] Logo { get; set; }
        public int Idalmacendefecto { get; set; }
        public string Codigoalmacen { get; set; }
        public string Nombrealmacen { get; set; }
	}
}
