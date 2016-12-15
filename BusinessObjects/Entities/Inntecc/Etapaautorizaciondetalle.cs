using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("etapaautorizaciondetalle")]
	public class Etapaautorizaciondetalle
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idetapaautorizaciondetalle")]
		public int Idetapaautorizaciondetalle { get; set; }
		public int?  Idetapaautorizacion { get; set; }
		public int?  Idempleado { get; set; }
        public int Ordenautorizacion { get; set; }
        public bool Requiereautorizacion { get; set; }
	}
}
