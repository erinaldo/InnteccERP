using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("maquinaria")]
	[Alias("mantenimientoimagen")]
	public class Mantenimientoimagen
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idmantenimientoimagen")]
		public int Idmantenimientoimagen { get; set; }
		public int?  Idmantenimiento { get; set; }
		public string Nombrearchivo { get; set; }
		public string Comentario { get; set; }
        public int Numeroitem { get; set; }
        [Ignore]
        public string RutaArchivo { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }

	}
}
