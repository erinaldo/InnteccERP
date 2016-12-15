using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarValorizacionDanioElemento(TipoMantenimiento tipoMantenimiento, Valorizaciondanioelemento entidadCab, List<VwValorizacionelemento> elementoDetList, List<VwValorizaciondanio> danioDetList)
        {
            return ValorizaciondanioelementoDao.GuardarValorizacionDanioElemento(tipoMantenimiento, entidadCab, elementoDetList, danioDetList);
        }

        public bool ValorizaciondanioelementoTieneReferenciaCpVenta(int idValorizacion, int idarticulodanio, int idarticuloelementodesgaste)
        {
            VwCpventadet vwCpventadet = VwCpventadetDao.Get(x => x.Idvalorizacion == idValorizacion
                                                                 && !x.Anulado
                                                                 && (x.Idarticulo == idarticulodanio ||
                                                                     x.Idarticulo == idarticuloelementodesgaste));
            return vwCpventadet != null;
        }
    }
}