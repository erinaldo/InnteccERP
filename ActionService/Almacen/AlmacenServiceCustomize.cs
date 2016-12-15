using System.Collections.Generic;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool RegistrarUbicacionPorDefectoInventario(int idempresa, int idArticulo, int idInventarioInicial)
        {
            string condicionEmpresa = string.Format("idempresa = {0}", idempresa);
            List<VwAlmacen> vwAlmacenList = VwAlmacenDao.GetAll(condicionEmpresa, "idalmacen");
            foreach (var vwAlmacen in vwAlmacenList)
            {
                int idAlmacen = vwAlmacen.Idalmacen;
                int idUbicacionPorDefecto = vwAlmacen.Idubicaciondefecto;
                List<VwInventario> vwInventarioList = VwInventarioDao.GetAll(x => x.Idinventarioinicial == idInventarioInicial && x.Idalmacen == idAlmacen);
                foreach (VwInventario vwInventario in vwInventarioList)
                {
                    int idInventario = vwInventario.Idinventario;
                    Inventarioubicacion inventarioubicacion = InventarioubicacionDao.Get(x => x.Idinventario == idInventario && x.Idubicacion == idUbicacionPorDefecto);
                    
                    if (inventarioubicacion == null)
                    {
                        Inventarioubicacion inventarioubicacionNuevo = new Inventarioubicacion();
                        inventarioubicacionNuevo.Idinventarioubicacion = 0;
                        inventarioubicacionNuevo.Idinventario = idInventario;
                        inventarioubicacionNuevo.Idubicacion = idUbicacionPorDefecto;
                        int idinventarioubicacionNuevo  = InventarioubicacionDao.Save(inventarioubicacionNuevo);
                        if (idinventarioubicacionNuevo > 0)
                        {
                            Inventariostock inventariostockNuevo = AsignarInventarioStock(idArticulo, idinventarioubicacionNuevo);
                            InventariostockDao.Save(inventariostockNuevo);
                            GuardarUbicacionEnArticulo(idArticulo, idUbicacionPorDefecto);
                        }
                    }
                    else
                    {
                        var inventariostockNuevo = AsignarInventarioStock(idArticulo, inventarioubicacion.Idinventarioubicacion);
                        InventariostockDao.Save(inventariostockNuevo);
                        GuardarUbicacionEnArticulo(idArticulo, idUbicacionPorDefecto);
                    }
                }
            }
            
           
          

            return true;
        }

        private static void GuardarUbicacionEnArticulo(int idArticulo, int idUbicacionPorDefecto)
        {
            Articuloubicacion articuloubicacion = new Articuloubicacion();
            articuloubicacion.Idarticuloubicacion = 0;
            articuloubicacion.Idarticulo = idArticulo;
            articuloubicacion.Idubicacion = idUbicacionPorDefecto;
            ArticuloubicacionDao.Save(articuloubicacion);
        }

        private static Inventariostock AsignarInventarioStock(int idArticulo, int idinventarioubicacionNuevo)
        {
            Inventariostock inventariostockNuevo = new Inventariostock();
            inventariostockNuevo.Idinventariostock = 0;
            inventariostockNuevo.Idinventarioubicacion = idinventarioubicacionNuevo;
            inventariostockNuevo.Idarticulo = idArticulo;
            inventariostockNuevo.Cantidadinventario = 0m;
            inventariostockNuevo.Cantidadajuste = 0m;
            inventariostockNuevo.Costounisoles = 0m;
            inventariostockNuevo.Costototsoles = 0m;
            inventariostockNuevo.Costounidolares = 0m;
            inventariostockNuevo.Costototdolares = 0m;
            inventariostockNuevo.Tipocambio = 0m;
            return inventariostockNuevo;
        }
    }
}