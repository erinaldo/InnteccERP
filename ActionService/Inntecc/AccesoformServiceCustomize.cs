using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public Accesoform GetPermisosForm(int idUsuario, string nameFormMnt)
        {
            Accesoform accesoform = new Accesoform();

            VwUsuario vwUsuario = VwUsuarioDao.Get(x => x.Idusuario == idUsuario);

            if (vwUsuario.Nombreusuario == "ADMIN" || vwUsuario.Nombregrupo == "ADMINISTRADORES DEL SISTEMA")
            {
                accesoform.Permitir = true;
                accesoform.Buscar = true;
                accesoform.Nuevo = true;
                accesoform.Editar = true;
                accesoform.Eliminar = true;
                accesoform.Imprimir = true;
                accesoform.Anular = true;
                return accesoform;
            }

            var vwAccesoform = VwAccesoformDao.Get(x => x.Idusuario == idUsuario && x.Nameform == nameFormMnt) ??
                                new VwAccesoform
                                {
                                    Permitir = false,
                                    Buscar = false,
                                    Nuevo = false,
                                    Editar = false,
                                    Eliminar = false,
                                    Imprimir = false,
                                    Anular = false,
                                };

            accesoform.Permitir = vwAccesoform.Permitir;
            accesoform.Buscar = vwAccesoform.Buscar;
            accesoform.Nuevo = vwAccesoform.Nuevo;
            accesoform.Editar = vwAccesoform.Editar;
            accesoform.Eliminar = vwAccesoform.Eliminar;
            accesoform.Imprimir = vwAccesoform.Imprimir;
            accesoform.Anular = vwAccesoform.Anular;

            return accesoform;
        }
    }
}