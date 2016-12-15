using System;
using System.Linq;
using BusinessObjects.Entities;

namespace WinFormsApp
{
    public class Holidays
    {
        public static bool IsHoliday(DateTime dt, out string holidayText)
        {
            holidayText = string.Empty;

            foreach (var diaferiado in CacheObjects.DiaferiadoList)
            {
                if (dt.Day == diaferiado.Fechaferiado.Day && dt.Month == diaferiado.Fechaferiado.Month)
                {
                    holidayText = diaferiado.Motivodiaferiado;
                }
            }
            return !string.IsNullOrEmpty(holidayText);
        } 
    }
}