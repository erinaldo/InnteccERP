using System;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public int GetIdPeriodo(DateTime fecha)
        {
            VwPeriodo vwPeriodo = VwPeriodoDao.Get(x => x.Anioejercicio == fecha.Year && x.Mes == fecha.Month.ToString("d2"));
            if (vwPeriodo != null)
            {
                return vwPeriodo.Idperiodo;
            }
            return 0;
        }
    }
}