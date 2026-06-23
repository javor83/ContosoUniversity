using System.Globalization;

namespace ContosoUniversity.Models
{
    public static class DateTimeExtension
    {
        //********************************************************************************
        public static string BulgarianDate(this DateTime sender)
        {
            return sender.ToString(new CultureInfo("bg-bg"));
        }
        //********************************************************************************
        public static string BulgarianDate(this DateTime? sender)
        {
            return sender.Value.ToString(new CultureInfo("bg-bg"));
        }
        //********************************************************************************
    }
}
