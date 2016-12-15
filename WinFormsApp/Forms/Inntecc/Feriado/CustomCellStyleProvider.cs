using System.Drawing;
using DevExpress.XtraEditors.Controls;

namespace WinFormsApp
{
    public class CustomCellStyleProvider : ICalendarCellStyleProvider
    {
        public void UpdateAppearance(CalendarCellStyle cell)
        {
            string holidayText;
            if (Holidays.IsHoliday(cell.Date, out holidayText))
            {
                cell.Appearance.ForeColor = Color.Yellow;
                cell.Appearance.Font = new Font(cell.Appearance.Font, FontStyle.Bold);
                //cell.Appearance.BackColor = cell.Active ? Color.HotPink : Color.LightPink;
                cell.Appearance.BackColor = Color.Red;
            }
        }
    }
}