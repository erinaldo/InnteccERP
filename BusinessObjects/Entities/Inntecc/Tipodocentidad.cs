using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("tipodocentidad")]
	public class Tipodocentidad
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idtipodocent")]
		public  int Idtipodocent{ get; set; }
		public  string Codigotipodocentidad{ get; set; }
		public  string Nombretipodocentidad{ get; set; }
		public  string Abreviaturadocentidad{ get; set; }
		public  bool Essunat{ get; set; }
        public int Longitud{ get; set; }
	}
}
