namespace BusinessObjects.Entities
{
    public class ItemGuiaRemisionCpVenta
    {
        public int Numeroitem { get; set; }
        public string Codigoarticulo { get; set; }
        public string Codigoproveedor { get; set; }
        public string Nombrearticulo { get; set; }
        public string Abrunidadmedida { get; set; }
        public decimal Preciounitario { get; set; }
        public int Idarticulo { get; set; }
        public string Nombremarca { get; set; }
        public int Idunidadmedida { get; set; }
        public decimal Cantidadaimportar { get; set; }

        public int Idimpuesto { get; set; }
        public int Idcentrodecosto { get; set; }
        public string Descripcioncentrodecosto { get; set; }
        public decimal Porcentajepercepcion { get; set; }
        public int Idarea { get; set; }
        public string Nombrearea { get; set; }
        public int Idproyecto { get; set; }
        public string Nombreproyecto { get; set; }       
        public int Idalmacen { get; set; }
        public int Idtipoafectacionigv { get; set; }
        public bool Gravado { get; set; }
        public bool Exonerado { get; set; }
        public bool Inafecto { get; set; }
        public bool Exportacion { get; set; }
        public bool Calcularitem { get; set; }


    }
}