namespace ActionService
{
    public partial class Service
    {
        public bool ContraseniaValida(string contraseniaUsuario, string contraseniaIngresada)
        {
            return contraseniaUsuario == contraseniaIngresada;
        }
    }
}