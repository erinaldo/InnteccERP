using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("modeloautorizacion")]
	public class Modeloautorizacion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmodeloautorizacion")]
		public int Idmodeloautorizacion { get; set; }
		public string Nombremodelo { get; set; }
		public bool Esactivo { get; set; }
		public bool Todoslosautores { get; set; }
		public int?  Idtipodocmov { get; set; }
		public int?  Idempresa { get; set; }
        public int? Idcptooperacion { get; set; }
	}
}
