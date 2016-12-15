using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarMantenimiento(TipoMantenimiento tipoMantenimiento, Mantenimiento entidadCab, List<Mantenimientoimagen> entidadDetList, string rutaArchivosServidor)
        {
            return MantenimientoDao.GuardarMantenimiento(tipoMantenimiento, entidadCab, entidadDetList, rutaArchivosServidor);
        }

        public bool NumeroMantenimientoExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var mantenimiento = MantenimientoDao.Get(x => x.Idsucursal == idSucursal
              && x.Idtipocp == idTipoCp
              && x.Seriemantenimiento == numeroSerie
              && x.Numeromantenimiento == numeroDocumento);
            return mantenimiento != null;
        }
    }
}