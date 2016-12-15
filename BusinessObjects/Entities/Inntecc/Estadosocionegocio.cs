using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("estadosocionegocio")]
	public class Estadosocionegocio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idestadosocionegocio")]
		public int Idestadosocionegocio { get; set; }
		public string Nombreestadosocionegocio { get; set; }
        public bool Requiereperiodo { get; set; }
        public bool Requieremotivo { get; set; }
        public bool Permitirtransacciones { get; set; }
	}
}
