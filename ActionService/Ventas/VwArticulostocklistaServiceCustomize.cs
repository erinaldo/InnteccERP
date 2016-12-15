using System;
using System.Collections.Generic;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, string condicion)
        {
            return VwArticulostocklistaDao.ConsultaArticuloStockLista(idSucursal, idAlmacen, idTipoLista, fechaConsulta, condicion);
        }

        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idArticulo, int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta)
        {
            return VwArticulostocklistaDao.ConsultaArticuloStockLista(idArticulo, idSucursal, idAlmacen, idTipoLista, fechaConsulta);
        }

        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, int idArticulo)
        {
            return VwArticulostocklistaDao.ConsultaArticuloStockLista(idSucursal, idAlmacen, idTipoLista, fechaConsulta, idArticulo);
        }
    }
}