using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("socionegocio")]
	public class Socionegocio
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idsocionegocio")]
		public  int Idsocionegocio{ get; set; }
		public  int Idpersona{ get; set; }
		public  int?  Idtiposocio{ get; set; }
        [Required]
        [StringLength(6)]
		public  string Codigosocio{ get; set; }
		public  DateTime Fecharegistro{ get; set; }
		public  string Nrodocentidad{ get; set; }
		public  int Idtipocondicion{ get; set; }
		public  int? Idtipolista{ get; set; }
		public  bool Esagenteretenedor{ get; set; }
		public  bool Esactivo{ get; set; }
		public  decimal Pordescuentototal{ get; set; }
		public  string Comentario{ get; set; }
		public  bool Incluyeimpuestoitems{ get; set; }
        public bool Sujetoadetraccion { get; set; }
        public DateTime? Fechafundacion { get; set; }
        public string Paginaweb { get; set; }
        public DateTime? Fechaaniversario { get; set; }
        public int? Idrubronegocio { get; set; }
        public int? Idgrupoeconomico { get; set; }
        public int? Idcategoriaproveedor { get; set; }
        public bool Esagentepercepcion { get; set; }
        public int? Idzona { get; set; }
        public int Secuenciareparto { get; set; }
        public int Diavisitasemana { get; set; }
        public int Frecuenciavisita { get; set; }
	    public int? Idestadosocionegocio { get; set; }
        public DateTime? Iniciosuspension { get; set; }
        public DateTime? Finsuspension { get; set; }
	    public string Motivosuspension { get; set; }
	    public int? Idvendedor { get; set; }
	    public int? Idempresa { get; set; }
	}
}
