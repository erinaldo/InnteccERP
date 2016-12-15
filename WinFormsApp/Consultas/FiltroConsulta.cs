using System;

namespace WinFormsApp
{
    public class FiltroConsulta
    {
        public TipoFiltro Tipo { get; set; }
        public int Ejercicio { get; set; }
        public string Mes { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string DescripcionFiltro { get; set; }
    }
}