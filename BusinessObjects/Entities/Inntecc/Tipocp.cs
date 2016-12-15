using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipocp")]
	public class Tipocp
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipocp")]
		public  int Idtipocp{ get; set; }
		public  int Idsucursal{ get; set; }
		public  string Codigotipocp{ get; set; }
		public  int?  Idtipoformato{ get; set; }
		public  bool Tieneimpuesto{ get; set; }
		public  int Idimpuesto{ get; set; }
		public  int?  Idtipocppago{ get; set; }
        public int Idtipodocmov { get; set; }
		public  string Seriecp{ get; set; }
		public  int Numerocorrelativocp{ get; set; }
		public  bool Numeracionauto{ get; set; }
		public  int Maxnumeroitems{ get; set; }
		public  bool Esactivo{ get; set; }
		public  string Nombrereporte{ get; set; }
        public int Tiporeporteador { get; set; }
        public bool Enumerarporsocionegocio { get; set; }
        public bool Requierenumerorucvalido { get; set; }
	}
}
