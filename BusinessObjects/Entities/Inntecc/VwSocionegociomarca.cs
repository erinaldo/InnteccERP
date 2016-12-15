using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("vwsocionegociomarca")]
	public class VwSocionegociomarca
	{
		[PrimaryKey]
		[Alias("idsocionegociomarca")]
		public int  Idsocionegociomarca { get; set; }
		public int  Idsocionegocio { get; set; }
		public int  Idmarca { get; set; }
		public string Nombremarca { get; set; }
        [Ignore]
        public DataEntityState DataEntityState { get; set; }
        [Ignore]
        public bool Itemseleccionado { get; set; }
	}
}
